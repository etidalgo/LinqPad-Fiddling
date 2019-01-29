<Query Kind="Program" />

void Main()
{
	Console.WriteLine(nameof(IAudited.Created));
	var members = typeof(IAudited).GetMembers();
	members.ToList().ForEach(m => Console.WriteLine(m.Name.ToString()));
}

// Define other methods and classes here
    public interface IAudited
    {
        DateTime? Created { get; set; }
        string CreatedBy { get; set; }
        string CreatedByHost { get; set; }
        DateTime? LastModified { get; set; }
        string LastModifiedBy { get; set; }
        string LastModifiedByHost { get; set; }
    }