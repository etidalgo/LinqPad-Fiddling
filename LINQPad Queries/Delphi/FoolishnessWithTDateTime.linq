<Query Kind="Program">
  <Reference Relative="..\..\..\eCargo\Components\CodeGear Shared Assemblies\Borland.Delphi.dll">D:\dev\eCargo\Components\CodeGear Shared Assemblies\Borland.Delphi.dll</Reference>
  <Reference Relative="..\..\..\eCargo\Components\CodeGear Shared Assemblies\Borland.Vcl.dll">D:\dev\eCargo\Components\CodeGear Shared Assemblies\Borland.Vcl.dll</Reference>
  <Reference Relative="..\..\..\eCargo\Components\CodeGear Shared Assemblies\Borland.VclRtl.dll">D:\dev\eCargo\Components\CodeGear Shared Assemblies\Borland.VclRtl.dll</Reference>
  <Namespace>Borland.Delphi</Namespace>
  <Namespace>Borland.Delphi.Units</Namespace>
  <Namespace>Borland.Vcl.Units</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	
}

// Define other methods and classes here


    [CLSCompliant(false)]
    public class TAmbiguousDateTimeConversion
    {
        public TAmbiguousDateTimeConversion()
        {
        }

        public void Free()
        {
            TObjectHelper.Free(this);
        }

        public double RunTest(TDateTime pInput)
        {
            return 1440d * (SysUtils.Now().ToOADate() - pInput.ToOADate());
        }

        public TDateTime RunTest_ImplicitCast(TDateTime pInput)
        {
            TDateTime Result = TDateTime.FromOADate(pInput.ToOADate() + SysUtils.EncodeTime(3, 0, 0, 0).ToOADate());
            return Result;
        }

        public string RunTest_IncrementTDateTime(TDateTime pInput)
        {
            pInput = pInput + 1;
            string Result = SysUtils.UpperCase(SysUtils.FormatDateTime("ddd", pInput, new CultureInfo("en-NZ")));
            return Result;
        }

        public void RunTest_UseFracAndInt(TDateTime pInput)
        {
            TDateTime dtTemp = TDateTime.FromOADate(Borland.Delphi.Units.System.Frac(pInput.ToOADate()));
            double dblDiff = pInput.ToOADate() - SysUtils.Now().ToOADate();
            dtTemp = TDateTime.FromOADate(dblDiff - Borland.Delphi.Units.System.Int(dblDiff));
        }
    }