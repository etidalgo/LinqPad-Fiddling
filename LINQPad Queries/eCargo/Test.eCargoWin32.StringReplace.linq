<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\Common Files\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Delphi.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Common Files\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Vcl.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Common Files\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.VclRtl.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\Legacy\MigratedWin32\bin\Release\ECargo.Legacy.MigratedWin32.dll">D:\dev\eCargo\eCargo.CSharp\Legacy\MigratedWin32\bin\Release\ECargo.Legacy.MigratedWin32.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.Net\Win32\Output\eCargoWin32.dll">D:\dev\eCargo\eCargo.Net\Win32\Output\eCargoWin32.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.Net\Shared\ComImports\Interop.MSXML2.dll">D:\dev\eCargo\eCargo.Net\Shared\ComImports\Interop.MSXML2.dll</Reference>
  <Namespace>Borland.Delphi</Namespace>
  <Namespace>Borland.Vcl</Namespace>
  <Namespace>Borland.Vcl.Units</Namespace>
  <Namespace>ECargo.Legacy</Namespace>
</Query>

int index = 1;
var bollocks = utils.Units.utils.ReplaceStr("TSAPDeliveryInterfaceAgent.TransformCarrierPartnerID|NO_AUTO_CARRIER|DELIVERY_NUMBER=1017808593", "|", "$");
Console.WriteLine("bollocks: {0}", bollocks);

string strMessageDesc, strMessageCode, strSource, strArgs;
strMessageDesc = "TSAPDeliveryInterfaceAgent.TransformCarrierPartnerID|NO_AUTO_CARRIER|DELIVERY_NUMBER=1017808593";
strMessageCode = "";
strSource = "";
strArgs = "";
utils.Units.utils.BustMessage(strMessageDesc, ref strMessageCode, ref strSource, ref strArgs);
Console.WriteLine("strMessageCode = {0}", strMessageCode);
Console.WriteLine("strSource = {0}", strSource);
Console.WriteLine("strArgs = {0}", strArgs);

string replaced = Borland.Vcl.Units.SysUtils.StringReplace(strMessageDesc, "|", "\r\n", TReplaceFlags.rfReplaceAll | TReplaceFlags.rfIgnoreCase);
Console.WriteLine(replaced);

TStringList objElements = new TStringListLegacy();
objElements.Text = utils.Units.utils.ReplaceStr("TSAPDeliveryInterfaceAgent.TransformCarrierPartnerID|NO_AUTO_CARRIER|DELIVERY_NUMBER=1017808593", "|", "\r\n");
Console.WriteLine(objElements.Count);