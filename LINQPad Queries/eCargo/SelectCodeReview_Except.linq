<Query Kind="Program" />

void Main()
{
    List<CodeReviewUser> _workingTeamMembers = new List<CodeReviewUser>{
        new CodeReviewUser("bartjoy", "Bart Joy"),
        new CodeReviewUser("jamesgilberd", "James Gilberd"),
        new CodeReviewUser("ernesttidalgo", "Ernest Tidalgo")
    };

    var reviewerPool = _workingTeamMembers.ToArray();
        reviewerPool = reviewerPool.Except(new[] { new CodeReviewUser("jamesgilberd", "James Gilberd") }).ToArray();
    Console.WriteLine(reviewerPool.Length);

    var codeReviewUserB = new CodeReviewUser("jamesgilberd", "James Gilberd");
    Console.WriteLine(_workingTeamMembers[1] == codeReviewUserB );
    Console.WriteLine("{0}", _workingTeamMembers[1].GetHashCode());
    Console.WriteLine("{0}", codeReviewUserB.GetHashCode());
}

// Define other methods and classes here
    public class CodeReviewUser
    {
        public string UserIdentifier { get; }
        public string Name { get; }

        public CodeReviewUser(string userIdentifier, string name)
        {
            if(userIdentifier == null) throw new ArgumentNullException(nameof(userIdentifier));
            if(name == null) throw new ArgumentNullException(nameof(name));

            UserIdentifier = userIdentifier;
            Name = name;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (UserIdentifier.GetHashCode() * 397) ^ Name.GetHashCode();
            }
        }
    }

    readonly List<CodeReviewUser> _workingTeamMembers = new List<CodeReviewUser>{
        new CodeReviewUser("bartjoy", "Bart Joy"),
        new CodeReviewUser("jamesgilberd", "James Gilberd"),
        new CodeReviewUser("ernesttidalgo", "Ernest Tidalgo")
    };
