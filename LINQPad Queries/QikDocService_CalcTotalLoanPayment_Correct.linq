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
</Query>

// Table names may need adjusting
var aptFinancial = APTFINCLs.Where( af => af.ID == 1489590 ).FirstOrDefault();
	decimal loanPayment = aptFinancial.CONTRACT_LOAN_PMT.HasValue ? aptFinancial.CONTRACT_LOAN_PMT.Value : 0m;
	decimal finalPayment = aptFinancial.CONTRACT_LOAN_FPMT.HasValue ? aptFinancial.CONTRACT_LOAN_FPMT.Value : 0m;
	int term = aptFinancial.NUM_PAYS.HasValue ? aptFinancial.NUM_PAYS.Value : 0;
	if (term == 1) { 
		term = 0;
	}
	var totalLoanAmount = loanPayment * (term) + finalPayment;
	
	loanPayment.Dump();
	finalPayment.Dump();
	term.Dump();
totalLoanAmount.Dump();
aptFinancial.Dump();

