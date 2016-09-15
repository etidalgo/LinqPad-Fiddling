<Query Kind="Program">
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\Common\Tests.Common\bin\Release\ECargo.Common.Tests.Common.dll">D:\dev\eCargo\eCargo.CSharp\Common\Tests.Common\bin\Release\ECargo.Common.Tests.Common.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\SystemTests\Common\bin\Release\ECargo.SystemTests.Common.dll">D:\dev\eCargo\eCargo.CSharp\SystemTests\Common\bin\Release\ECargo.SystemTests.Common.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\SystemTests\Legacy\bin\Release\ECargo.SystemTests.Legacy.dll">D:\dev\eCargo\eCargo.CSharp\SystemTests\Legacy\bin\Release\ECargo.SystemTests.Legacy.dll</Reference>
  <Namespace>ECargo.Common.Tests.Common.Utilities</Namespace>
  <Namespace>ECargo.SystemTests.Common.ExternalResources</Namespace>
  <Namespace>ECargo.SystemTests.Common.Utilities</Namespace>
  <Namespace>ECargo.SystemTests.Legacy.Interfaces.Generic.ConsignmentIn.TestData</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

    public class EventServiceProcess
    {
        readonly Process process;
        public EventServiceProcess()
        {
            process = new Process();
            process.StartInfo.FileName = @"D:\dev\eCargo\eCargo.CSharp\Workers\EventService\bin\Debug\ECargo.Workers.EventService.exe";
            process.Start();
        }

        ~EventServiceProcess()
        {
            process.Kill();
        }

    }
	
public static void Main() {
	var consignmentNumber = StringGenerator.GenerateRandomString(20);
	Console.WriteLine(consignmentNumber);
    var inboundDocument = TestDataFactory.GetConsignmentInForColorpak(consignmentNumber);
	Console.Write(inboundDocument);
	LegacyFtpDocumentSender.PostGenericConsignmentDocumentAsThoughItArrivedViaFtp(inboundDocument, false).Wait();
	var eventServiceProcess = new EventServiceProcess();
	// System.Threading.Thread.Sleep(13167);
	
}
