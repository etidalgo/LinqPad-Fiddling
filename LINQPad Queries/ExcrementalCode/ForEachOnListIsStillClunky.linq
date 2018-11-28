<Query Kind="Statements" />

(new[]{ "CUSTOMER_INVOICE_INVLASTNO", "CUSTOMER_DEBIT_INVLASTNO", "CUSTOMER_CREDIT_INVLASTNO" })
	.ToList().ForEach(el => 
		Console.WriteLine(el));