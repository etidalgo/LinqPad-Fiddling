<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.dll</Reference>
  <Namespace>System.ComponentModel</Namespace>
</Query>


void Main()
{
	
}

// Define other methods and classes here
    public abstract class RecordIdentity : IRecordIdentity
    {
        [Description("Record ID")]
        public long Id { get; set; }

        public override string ToString() => $"{this.GetType().Name} ({this.Id})";
    }
	
    public interface IRecordIdentity
    {
        long Id { get; set; }
    }

	public interface IAuditedRecordIdentity : IRecordIdentity
    {
        [Description("date & time (UTC) when the record was created")]
        DateTime? Created { get; set; }

        [Description("date & time (UTC) when the record was last modified")]
        DateTime? LastModified { get; set; }
    }

	[Description("contains record audit information")]
    public abstract class AuditedRecordIdentity : RecordIdentity, IAuditedRecordIdentity
    {
        [Description("date & time (UTC) when the record was created")]
        public DateTime? Created { get; set; }

        [Description("date & time (UTC) when the record was last modified")]
        public DateTime? LastModified { get; set; }
    }

	public class SomeClassBase : AuditedRecordIdentity
    {
        [Description("the amount allocated")]
        public decimal? Amount { get; set; }

        public DateTime? CreatedInternal { get; set; }
    }
	
	public class SomeClass : SomeClassBase
    {
        [Description("the amount allocated")]
        public decimal? Amount { get; set; }

        public DateTime? CreatedInternal { get; set; }
    }