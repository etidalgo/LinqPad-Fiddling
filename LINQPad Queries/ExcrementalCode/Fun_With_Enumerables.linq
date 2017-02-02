<Query Kind="Program" />

    public enum TeStatus : byte
    {
        stNull,
        stPending,
        stOpen,
        stOffered,
        stAssigned,
        stDispatched,
        stDelivered,
        stWithdrawn,
        stUnsent,
        stSent,
        stError,
        stInTransit,
        stAvailable,
        stTaken,
        stAccepted,
        stRejected,
        stScheduled,
        stSailed,
        stArrived
    }
	
	bool IsConsignmentStatusValidForAutoLeadTimeCalculation(TeStatus teStatus)
	{
	    return (teStatus < TeStatus.stDispatched || teStatus >= TeStatus.stUnsent ? 0 : 1) == 0;
	}
	

void Main()
{
	foreach (TeStatus teStatus in Enum.GetValues(typeof(TeStatus))) {
		Console.WriteLine("|{0,-15} |{1}|", teStatus, IsConsignmentStatusValidForAutoLeadTimeCalculation(teStatus) ? "Apply lead time" : "Do not apply lead time");
	}
}

