<Query Kind="Program">
  <Reference>&lt;CommonProgramFiles&gt;\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Delphi.dll</Reference>
  <Reference>&lt;CommonProgramFiles&gt;\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Vcl.dll</Reference>
  <Reference>&lt;CommonProgramFiles&gt;\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.VclRtl.dll</Reference>
  <Namespace>Borland.Delphi</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>


void Main()
{
}


    [CLSCompliant(false)]
    public class TCurrencyBoxing
    {
        public TCurrencyBoxing()
        {
        }

        public void Free()
        {
            TObjectHelper.Free(this);
        }

        public string RunTest_FormatImplicit(Borland.Delphi.Currency val1)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:c}", val1);
        }

        public string RunTest_ToStringCastAsObject(Borland.Delphi.Currency val1)
        {
            return Convert.ToString((object)val1, CultureInfo.CurrentCulture);
            // return Convert.ToString(val1, CultureInfo.CurrentCulture); // invalid 
        }
    }
