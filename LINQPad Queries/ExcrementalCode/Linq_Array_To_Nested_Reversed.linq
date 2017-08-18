<Query Kind="Program" />

void Main()
{
	var threads = CreateThreads();
	foreach( var thread in threads ) {
		PrintComment(thread);
	}
	
	foreach( var thread in threads ) {
		foreach( var comment in GetLastComments(thread)) {
			PrintComment(comment);
		}
	}
}

IEnumerable<Comment> GetLastComments(Comment comment)
{
	if (comment.Replies.Count() == 0) {
		yield return comment;
	} 

	foreach( var reply in comment.Replies ) {
		foreach( var replycomment in GetLastComments(reply)) {
			yield return replycomment;
		}
	}
}

IEnumerable<Comment> CreateThreads() 
{
    var threads = new List<Comment>
    {
        CreateThread("alpha", "beta", "alpha", "beta"),
        CreateThread("gamma", "beta", "gamma")
    };
	return threads;
}

void PrintComment(Comment comment, int level = 0) {
	Console.WriteLine("{0}{1}", "".PadLeft(level*4), comment.Name);
	level++;
	foreach (var reply in comment.Replies) {
		PrintComment(reply, level);
	}
}

Comment CreateThread(params string[] threadParticipants) {
	var bottomUp = threadParticipants.Reverse();
	var parent = new Comment(bottomUp.ElementAt(0), new List<Comment>());
	var current = parent;
	foreach( var participant in bottomUp.Skip(1) ) {
		parent = new Comment(participant, new List<Comment>{ current });
		current = parent;
	}
	return current;
}
			
class Comment {
	public string Name {get; set;}
	public IEnumerable<Comment> Replies {get; set;}
	
	public Comment(string name, IEnumerable<Comment> replies) {
		Name = name;
		Replies = replies;
	}
}