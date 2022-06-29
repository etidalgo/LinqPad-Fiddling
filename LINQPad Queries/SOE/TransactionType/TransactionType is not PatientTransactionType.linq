<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.NETCore.App\5.0.17\System.ComponentModel.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.NETCore.App\5.0.17\System.ComponentModel.Primitives.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.NETCore.App\5.0.17\System.Private.CoreLib.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.NETCore.App\5.0.17\System.Runtime.dll</Reference>
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	var transactionType = PatientTransactionType.PatientProcedurePayment;
	transactionType.ToString().Dump();
	
	foreach(var tType in Enum.GetValues(typeof(TransactionType))){
		Console.WriteLine(tType.ToString());
		// this will fail where TransactionType doesn't have a corresponding PatientTransactionType
		tType.ToString().AsPatientTransactionType().Dump(); 
	}	
}

// You can define other methods, fields, classes and namespaces here
public static class PatientTransactionTypes {
        public static PatientTransactionType AsPatientTransactionType(this string patientTransactionType) =>
            Enum.Parse<PatientTransactionType>(patientTransactionType, ignoreCase: true);
}
			

[Description("patient ledger type")]
public enum PatientTransactionType
{
    [Description("patient procedure ledger")]
    PatientProcedureLedger,

    [Description("patient procedure payment")]
    PatientProcedurePayment,

    [Description("patient charge adjustment")]
    PatientChargeAdjustment,

    [Description("patient credit adjustment")]
    PatientCreditAdjustment,

    [Description("insurance payment")]
    InsurancePayment,

    [Description("insurance refund adjustment")]
    InsuranceRefundAdjustment,

    [Description("patient credit card void")]
    PatientCreditCardVoid,

    [Description("patient credit card refund")]
    PatientCreditCardRefund,

    [Description("laboratory fees")]
    LaboratoryFees
}

[Description("transaction type")]
public enum TransactionType : int
{
    /// <summary>procedure</summary>
    [Description("procedure")]
    Procedure = 1,
    /// <summary>charge adjustment</summary>
    [Description("charge adjustment")]
    ChargeAdjustment = 2,
    /// <summary>credit adjustment</summary>
    [Description("credit adjustment")]
    CreditAdjustment = 3,
    /// <summary>payment</summary>
    [Description("payment")]
    Payment = 4,
    /// <summary>insurance payment</summary>
    [Description("insurance payment")]
    InsurancePayment = 5,
    /// <summary>insurance claim</summary>
    [Description("insurance claim")]
    InsuranceClaim = 6,
    /// <summary>laboratory fees</summary>
    [Description("laboratory fees")]
    LaboratoryFees = 7
}	