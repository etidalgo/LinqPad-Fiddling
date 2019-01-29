<Query Kind="Program">
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\humanizer.core\2.2.0\lib\netstandard1.0\Humanizer.dll</Reference>
  <Namespace>Humanizer</Namespace>
  <Namespace>System</Namespace>
</Query>

// Requires Humanizer.dll 
public enum SomeObjectImportActionType
    {
        /// <summary>
        /// Indicates the new object can be inserted.
        /// </summary>
        Insert,
        /// <summary>
        /// Indicates the existing object must be deleted before inserting the new one.
        /// </summary>
        DeleteAndInsert,
        /// <summary>
        /// Indicates the existing object must be truncated before inserting the new one.
        /// </summary>
        TruncateAndInsert,
        /// <summary>
        /// Indicates the general case of new and existing objects overlap such that the new one cannot be imported.
        /// Resolving depends on the user, i.e. remove existing or change the new one.
        /// </summary>
        RemoveInvalidOverlap,
        /// <summary>
        /// Indicates the new objects overlaps two or more adjacent objects.
        /// Resolve by truncating or deleting the adjacent objects.
        /// </summary>
        RemoveInvalidOverlapWhereNewSomeObjectOverlapsTwoOrMoreAdjacentSomeObjects,
        /// <summary>
        /// Indicates the existing object is an exact duplicate of the new one, so can be safely left unchanged.
        /// </summary>
        LeaveUnchanged
    }

    public static Tuple<string, string> GetToStringAndToWords( int value ) {
        return new Tuple<string,string>(value.ToString(), value.ToWords());
    }

    void Main()
    {
        Console.WriteLine( GetToStringAndToWords(43).ToString() );
        foreach( SomeObjectImportActionType actionType in Enum.GetValues(typeof(SomeObjectImportActionType))) {
            Console.WriteLine( "{0} - {1}", actionType.ToString().Humanize(), Enum.GetName(typeof(SomeObjectImportActionType), actionType) );
        }
    }