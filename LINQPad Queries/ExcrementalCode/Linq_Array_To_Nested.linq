<Query Kind="Program" />

void Main()
{
	var conversation = CreateThread("alpha", "beta", "alpha", "beta");
	PrintComment(conversation);
	
}

void PrintComment(Comment comment, int level = 0) {
	Console.WriteLine("{0}{1}", "".PadLeft(level*4), comment.Name);
	level++;
	foreach (var reply in comment.Replies) {
		PrintComment(reply, level);
	}
}

Comment CreateThread(params string[] threadParticipants) {
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
	public string Name {get; set;}
	public IEnumerable<Comment> Replies {get; set;}
	
	public Comment(string name, IEnumerable<Comment> replies) {
		Name = name;
		Replies = replies;
	}
}