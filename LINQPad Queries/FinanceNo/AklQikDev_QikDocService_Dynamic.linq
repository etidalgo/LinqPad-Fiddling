<Query Kind="Statements">
  <Connection>
    <ID>2d5931da-d10c-415a-a88e-0968f875059c</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\Data\QikDocService\QikDocService_V_1_NET4.0\QikDocService\bin\QikDocService.dll</CustomAssemblyPath>
    <CustomTypeName>QikDocService.Model.ML51_FNLEntities</CustomTypeName>
    <AppConfigPath>C:\Data\QikDocService\QikDocService_V_1_NET4.0\QikDocService\Web.config</AppConfigPath>
    <IsProduction>true</IsProduction>
  </Connection>
  <Reference Relative="..\..\NuGet-Common\FluentValidationNA.1.2.16\lib\net40\FluentValidationNA.dll">C:\Dev\NuGet-Common\FluentValidationNA.1.2.16\lib\net40\FluentValidationNA.dll</Reference>
  <Reference Relative="..\..\NuGet-Common\System.Linq.Dynamic.Library.1.1.14\lib\net40\System.Linq.Dynamic.dll">C:\Dev\NuGet-Common\System.Linq.Dynamic.Library.1.1.14\lib\net40\System.Linq.Dynamic.dll</Reference>
  <Namespace>FluentValidationNA</Namespace>
  <Namespace>System.Linq.Dynamic</Namespace>
</Query>

// Connecting using QikDocService Entity Framework model
var first = APTPSNALs.Where ("C1_First=\"Mark\"").First();
	first.Dump();