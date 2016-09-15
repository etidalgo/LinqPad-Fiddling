<Query Kind="Statements">
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\Legacy\MigratedWin32\bin\Release\ECargo.Legacy.MigratedWin32.dll">D:\dev\eCargo\eCargo.CSharp\Legacy\MigratedWin32\bin\Release\ECargo.Legacy.MigratedWin32.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.Net\Win32\Output\eCargoWin32.dll">D:\dev\eCargo\eCargo.Net\Win32\Output\eCargoWin32.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.Net\Shared\ComImports\Interop.MSXML2.dll">D:\dev\eCargo\eCargo.Net\Shared\ComImports\Interop.MSXML2.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.DataSetExtensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.XML.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Linq.dll</Reference>
  <Namespace>ECargo.Legacy.MigratedWin32</Namespace>
  <Namespace>EventManager</Namespace>
</Query>

// Problems making this work , Need to run in Linqpad AnyCPU (x64)
// The type initializer for 'TXMgr.Units.TXMgr' threw an exception.
DelphiInitialiser.Initialise();
		using (TEventManager eventManager = new TEventManager())
            {
                eventManager.SetTX(null);
                eventManager.Execute("DEQUEUE_EVENTS");
            }