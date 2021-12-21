<Query Kind="Program" />

void Main()
{
	var names = new[]{
		"Mr John Smith",
		"John Smith",
		"Smith, John"};
	
	names.ToList().ForEach(n => n.SplitFullName().Dump());
}

// You can define other methods, fields, classes and namespaces here
	// from Mark Justin 21 Dec '21
    public static class ProvidersExtensions
    {
		public static string TrimEx(this string str){
			return String.IsNullOrEmpty(str) ? String.Empty : str.Trim();
		}
		
        public static FullName SplitFullName(this string fullName)
		{
            var titleRegex = new Regex(@"^(mr|dr|mrs|miss|ms)", RegexOptions.IgnoreCase);
            var title = titleRegex.Match(fullName).Value;
            var fullNameWithoutTitle = titleRegex.Replace(fullName, string.Empty, 1);
            var names = fullNameWithoutTitle.Trim().Split(' ');
            return new FullName()
            {
                Title = title.TrimEx(),
                FirstName = names.First(),
                MiddleName = string.Join(' ', names.Skip(1).SkipLast(1)).TrimEx(),
                LastName = names.Last()
            };
        }
    }

    public class FullName
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }