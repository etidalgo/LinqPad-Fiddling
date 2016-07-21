<Query Kind="Program">
  <Connection>
    <ID>2d5931da-d10c-415a-a88e-0968f875059c</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\Data\QikDocService\QikDocService_V_1_NET4.0\QikDocService\bin\QikDocService.dll</CustomAssemblyPath>
    <CustomTypeName>QikDocService.Model.ML51_FNLEntities</CustomTypeName>
    <AppConfigPath>C:\Data\QikDocService\QikDocService_V_1_NET4.0\QikDocService\Web.config</AppConfigPath>
    <IsProduction>true</IsProduction>
  </Connection>
</Query>

void Main()
{
	int applicationId = 1628056;
      var apnsecto = APNSECTOes.FirstOrDefault(ast => 
          ( (string.Compare(ast.Ast_Type, "AVE", StringComparison.CurrentCultureIgnoreCase) == 0) ||
          (string.Compare(ast.Ast_Type, "OVE", StringComparison.CurrentCultureIgnoreCase) == 0)) && 
          (ast.App_ID == applicationId) ) ;
	apnsecto.Dump();
}

// Define other methods and classes here
