<Query Kind="Program" />

void Main()
{
	foreach( var comment in TestCasesComments() ) {
		Console.WriteLine("----------------");
		PrintComment(comment);
	}
}

IEnumerable<Comment> TestCasesComments() {
	yield return CreateThread(CodeReviewUsers.Alpha, CodeReviewUsers.Beta, CodeReviewUsers.Alpha, CodeReviewUsers.Beta);
	yield return new Comment(CodeReviewUsers.Alpha, 
		new[] { 
			CreateThread(CodeReviewUsers.Alpha, CodeReviewUsers.Beta, CodeReviewUsers.Alpha, CodeReviewUsers.Beta),
			new Comment(CodeReviewUsers.Beta,
				new[] {
					CreateThread(CodeReviewUsers.Gamma, CodeReviewUsers.Beta),
					CreateThread(CodeReviewUsers.Alpha, CodeReviewUsers.Beta)
					}),
			CreateThread(CodeReviewUsers.Beta, CodeReviewUsers.Alpha, CodeReviewUsers.Beta, CodeReviewUsers.Alpha, CodeReviewUsers.Beta)
			});
}

class CodeReviewUser {
	public string UserIdentifier { get; private set; }
	public string DisplayName { get; private set; }
	
	public CodeReviewUser(string userIdentifier, string displayName) {
		UserIdentifier = userIdentifier;
		DisplayName = displayName;
	}
}

class CodeReviewUsers {
	public static readonly CodeReviewUser Alpha = new CodeReviewUser( "alpha", "Alpha User" );
	public static readonly CodeReviewUser Beta = new CodeReviewUser( "beta", "Beta User" );
	public static readonly CodeReviewUser Gamma = new CodeReviewUser( "gamma", "Gamma User" );
}

void PrintComment(Comment comment, int level = 0) {
	Console.WriteLine("{0}{1}", "".PadLeft(level*4), comment.Poster.DisplayName);
	level++;
	foreach (var reply in comment.Replies) {
		PrintComment(reply, level);
	}
}

Comment CreateThread(params CodeReviewUser[] threadParticipants) {
	var parent = new Comment(threadParticipants.ElementAt(0), new List<Comment>());
	var root = parent;
	foreach( var participant in threadParticipants.Skip(1) ) {
		var child = new Comment(participant, new List<Comment>());
		parent.Replies = parent.Replies.Append(child);
		parent = child;
	}
	return root;
}

class Comment {
	public CodeReviewUser Poster {get; set;}
	public IEnumerable<Comment> Replies {get; set;}
	
	public Comment(CodeReviewUser poster, IEnumerable<Comment> replies) {
		Poster = poster;
		Replies = replies;
	}
}