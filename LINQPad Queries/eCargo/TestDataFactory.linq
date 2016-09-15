<Query Kind="Statements">
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\Common\Tests.Common\bin\Release\ECargo.Common.Tests.Common.dll">D:\dev\eCargo\eCargo.CSharp\Common\Tests.Common\bin\Release\ECargo.Common.Tests.Common.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\SystemTests\Common\bin\Release\ECargo.SystemTests.Common.dll">D:\dev\eCargo\eCargo.CSharp\SystemTests\Common\bin\Release\ECargo.SystemTests.Common.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\SystemTests\Legacy\bin\Release\ECargo.SystemTests.Legacy.dll">D:\dev\eCargo\eCargo.CSharp\SystemTests\Legacy\bin\Release\ECargo.SystemTests.Legacy.dll</Reference>
  <Namespace>ECargo.Common.Tests.Common.Utilities</Namespace>
  <Namespace>ECargo.SystemTests.Common.ExternalResources</Namespace>
  <Namespace>ECargo.SystemTests.Common.Utilities</Namespace>
  <Namespace>ECargo.SystemTests.Legacy.Interfaces.Generic.ConsignmentIn.TestData</Namespace>
</Query>


// LegacyFtpDocumentSender.
	var consignmentNumber = StringGenerator.GenerateRandomString(20);
	Console.WriteLine(consignmentNumber);
    var inboundDocument = TestDataFactory.GetConsignmentInForColorpak(consignmentNumber);
	Console.Write(inboundDocument);
	await LegacyFtpDocumentSender.PostGenericConsignmentDocumentAsThoughItArrivedViaFtp(inboundDocument, false);
//    await LegacyEventQueue.WaitForMostRecentEventMatching("CONSIGNMENT", inboundDocument);
