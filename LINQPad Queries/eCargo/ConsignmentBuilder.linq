<Query Kind="Statements">
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\Common\Tests.Common\bin\Release\ECargo.Common.Domain.dll">D:\dev\eCargo\eCargo.CSharp\Common\Tests.Common\bin\Release\ECargo.Common.Domain.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\Common\Tests.Common\bin\Release\ECargo.Common.Tests.Common.dll">D:\dev\eCargo\eCargo.CSharp\Common\Tests.Common\bin\Release\ECargo.Common.Tests.Common.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\SystemTests\Common\bin\Release\ECargo.SystemTests.Common.dll">D:\dev\eCargo\eCargo.CSharp\SystemTests\Common\bin\Release\ECargo.SystemTests.Common.dll</Reference>
  <Namespace>ECargo.Common.Domain.Core.MasterData</Namespace>
  <Namespace>ECargo.Common.Tests.Common.Helpers.Builders</Namespace>
</Query>

            // No work
			var consignment = new ConsignmentBuilder()
                .MakeMinimumPersistable()
                .WithOwnerId(3983)
                .WithStatus(ConsignmentStatus.Offered)
                .Build();
