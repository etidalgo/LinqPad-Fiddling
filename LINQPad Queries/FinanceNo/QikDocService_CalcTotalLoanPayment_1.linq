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

var aptFinancial = APTFINCLs.Where( af => af.ID == 779762 ).FirstOrDefault();
aptFinancial.Dump();
            decimal loanPayment = aptFinancial.LOAN_PMT.HasValue ? aptFinancial.LOAN_PMT.Value : 0m;
            decimal finalPayment = aptFinancial.LOAN_FPMT.HasValue ? aptFinancial.LOAN_FPMT.Value : 0m;
            decimal monthlyFee = aptFinancial.MONTHLY_SERVICE_FEE.HasValue ? aptFinancial.MONTHLY_SERVICE_FEE.Value : 0m;
            var payment = Decimal.Round((loanPayment + monthlyFee), 2);
            int term = aptFinancial.Term_of_Loan.HasValue ? aptFinancial.Term_of_Loan.Value : 0;
            int deferred = aptFinancial.Deferred_Term.HasValue ? aptFinancial.Deferred_Term.Value : 0;

            var totalLoanAmount = payment * (term - deferred - 1) + finalPayment;

			loanPayment.Dump();
			monthlyFee.Dump();
			payment.Dump();
			term.Dump();
			deferred.Dump();
totalLoanAmount.Dump();
//aptFinancial.Deferred_Term;
//aptFinancial.Term_of_Loan;
//aptFinancial.MONTHLY_SERVICE_FEE;
//aptFinancial.LOAN_PMT;
