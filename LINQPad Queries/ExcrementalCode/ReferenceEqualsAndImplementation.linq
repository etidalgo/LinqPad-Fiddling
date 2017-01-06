<Query Kind="Program" />

void Main()
{
	Business businessA = new Business(13);
	Business businessB = new Business(13);	
	Console.WriteLine("businessA == businessB is {0}", (businessA == businessB) ? "true" : "false" );	
	Console.WriteLine("businessA.Equals(businessB) is {0}", (businessA.Equals(businessB)) ? "true" : "false" );	

	BusinessX businessXA = new BusinessX(13);
	BusinessX businessXB = new BusinessX(13);	
	Console.WriteLine("businessXA == businessXB is {0}", (businessXA == businessXB) ? "true" : "false" );	
	Console.WriteLine("businessXA.Equals(businessXB) is {0}", (businessXA.Equals(businessXB)) ? "true" : "false" );	

}

public class Business
{
    public int BusinessId { get; }

    public Business(int businessId)
    {
        BusinessId = businessId;
    }
}
	
public class BusinessX
{
    public int BusinessId { get; }

    public BusinessX(int businessId)
    {
        BusinessId = businessId;
    }
	
    public bool Equals(BusinessX other)
    {
        return BusinessId == other.BusinessId;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BusinessX)obj);
    }
    public override int GetHashCode()
    {
        unchecked
        {
            return BusinessId.GetHashCode();
		}
	}
}	