<Query Kind="Program">
  <GACReference>Borland.Delphi, Version=11.0.5000.9245, Culture=neutral, PublicKeyToken=91d62ebb5b0d1b1b</GACReference>
  <GACReference>Borland.Vcl, Version=11.0.5000.9245, Culture=neutral, PublicKeyToken=91d62ebb5b0d1b1b</GACReference>
  <GACReference>Borland.VclRtl, Version=11.0.5000.9245, Culture=neutral, PublicKeyToken=91d62ebb5b0d1b1b</GACReference>
  <Namespace>Borland.Delphi</Namespace>
  <Namespace>Borland.Vcl</Namespace>
  <Namespace>Borland.Vcl.Units</Namespace>
  <CopyLocal>true</CopyLocal>
</Query>

void Main()
{
	var conversion = new TImplicitDateTimeConversion();
	Console.WriteLine( conversion.RunTest2() );
	TDateTime aDateTime2 = new TDateTime();
	var diff = SysUtils.Now() - aDateTime2;
	Console.WriteLine(diff);
}

    [CLSCompliant(false)]
    public class TImplicitDateTimeConversion
    {
        public TImplicitDateTimeConversion()
        {
        }

        public void Free()
        {
            TObjectHelper.Free(this);
        }

        public bool RunTest(DateTime input)
        {
            TDateTime aDateTime = new TDateTime();
            return input == (DateTime)aDateTime;
        }
        public bool RunTest2()
        {
            TDateTime aDateTime = new TDateTime();
			DateTime bDateTime = new DateTime();
            return aDateTime == (TDateTime)bDateTime;
        }
        public void RunTestOnAssignment()
        {
            TDateTime aDateTime = new TDateTime();
			DateTime bDateTime = new DateTime();
            TDateTime cDateTime = new TDateTime();
			aDateTime = bDateTime;
			bDateTime = cDateTime;
			
		}
		
        public bool RunTestOnComparisons()
        {
            TDateTime aDateTime = new TDateTime();
			DateTime bDateTime = new DateTime();
			bool isComparable ;
            isComparable = aDateTime == (TDateTime)bDateTime; // needs cast
            isComparable = aDateTime != (TDateTime)bDateTime; // needs cast
			isComparable = aDateTime > (TDateTime)bDateTime;
			isComparable = aDateTime < (TDateTime)bDateTime;
			isComparable = aDateTime <= (TDateTime)bDateTime;
			isComparable = aDateTime >= (TDateTime)bDateTime;

			isComparable = bDateTime == (DateTime)aDateTime; 
			isComparable = bDateTime != (DateTime)aDateTime; 
			isComparable = bDateTime > (DateTime)aDateTime;
			isComparable = bDateTime < (DateTime)aDateTime;
			isComparable = bDateTime <= (DateTime)aDateTime;
			isComparable = bDateTime >= (DateTime)aDateTime;
			return isComparable;
        }

        public bool RunTestOnComparisonsFixByMethod()
        {
            TDateTime aDateTime = new TDateTime();
			DateTime bDateTime = new DateTime();
			bool isComparable ;
            isComparable = aDateTime.ToOADate() == bDateTime.ToOADate(); 
            isComparable = aDateTime.ToOADate() != bDateTime.ToOADate(); 
			isComparable = aDateTime.ToOADate() > bDateTime.ToOADate();
			isComparable = aDateTime.ToOADate() < bDateTime.ToOADate();
			isComparable = aDateTime.ToOADate() <= bDateTime.ToOADate();
			isComparable = aDateTime.ToOADate() >= bDateTime.ToOADate();

			isComparable = bDateTime.ToOADate() == aDateTime.ToOADate(); 
			isComparable = bDateTime.ToOADate() != aDateTime.ToOADate(); 
			isComparable = bDateTime.ToOADate() > aDateTime.ToOADate();
			isComparable = bDateTime.ToOADate() < aDateTime.ToOADate();
			isComparable = bDateTime.ToOADate() <= aDateTime.ToOADate();
			isComparable = bDateTime.ToOADate() >= aDateTime.ToOADate();
			return isComparable;
        }
        public bool RunTestOnComparisons(DateTime input)
        {
            TDateTime aDateTime = new TDateTime();
            TDateTime bDateTime = new TDateTime();
            return (aDateTime > (TDateTime)input) | (input <= (DateTime)bDateTime);
        }	
    }