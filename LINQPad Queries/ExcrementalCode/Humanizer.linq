<Query Kind="Program">
  <Reference Relative="..\..\..\eCargo\ThirdParty\NuGetPackages\Humanizer.1.37.7\lib\portable-win+net40+sl50+wp8+wpa81+MonoAndroid10+MonoTouch10+Xamarin.iOS10\Humanizer.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\Humanizer.1.37.7\lib\portable-win+net40+sl50+wp8+wpa81+MonoAndroid10+MonoTouch10+Xamarin.iOS10\Humanizer.dll</Reference>
  <Namespace>Humanizer</Namespace>
  <Namespace>System</Namespace>
</Query>

public enum RateCardImportActionType
    {
        /// <summary>
        /// Indicates the new rate card can be inserted.
        /// </summary>
        Insert,
        /// <summary>
        /// Indicates the existing rate card must be deleted before inserting the new one.
        /// </summary>
        DeleteAndInsert,
        /// <summary>
        /// Indicates the existing rate card must be truncated before inserting the new one.
        /// </summary>
        TruncateAndInsert,
        /// <summary>
        /// Indicates the general case of new and existing rate cards overlap such that the new one cannot be imported.
        /// Resolving depends on the user, i.e. remove existing or change the new one.
        /// </summary>
        RemoveInvalidOverlap,
        /// <summary>
        /// Indicates the new rate cards overlaps two or more adjacent rate cards.
        /// Resolve by truncating or deleting the adjacent rate cards.
        /// </summary>
        RemoveInvalidOverlapWhereNewRateCardOverlapsTwoOrMoreAdjacentRateCards,
        /// <summary>
        /// Indicates the existing rate card is an exact duplicate of the new one, so can be safely left unchanged.
        /// </summary>
        LeaveUnchanged
    }

    public static Tuple<string, string> DoSomething( int value ) {
        return new Tuple<string,string>(value.ToString(), value.ToWords());
    }

    void Main()
    {
        Console.WriteLine( DoSomething(43).ToString() );
        foreach( RateCardImportActionType actionType in Enum.GetValues(typeof(RateCardImportActionType))) {
            Console.WriteLine( "{0} - {1}", actionType.ToString().Humanize(), Enum.GetName(typeof(RateCardImportActionType), actionType) );
        }
    }

