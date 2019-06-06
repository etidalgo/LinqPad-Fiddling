<Query Kind="Statements" />

// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
string text = "A class is the most powerful data type in C#. Like a structure, " +
               "a class defines the data and behavior of the data type. ";
// WriteAllText creates a file, writes the specified string to the file,
// and then closes the file.    You do NOT need to call Flush() or Close().
// Directory must exist
System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);

