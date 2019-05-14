<Query Kind="Statements">
  <Reference Relative="..\..\..\..\soeconversions\trunk\build\x86\debug\Flux.Runner\EntityFramework.dll">D:\Dev\soeconversions\trunk\build\x86\debug\Flux.Runner\EntityFramework.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions\trunk\build\x86\debug\Flux.Runner\EntityFramework.SqlServer.dll">D:\Dev\soeconversions\trunk\build\x86\debug\Flux.Runner\EntityFramework.SqlServer.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions\trunk\build\x86\debug\Flux.Runner\Flux.Conversion.Ascend.dll">D:\Dev\soeconversions\trunk\build\x86\debug\Flux.Runner\Flux.Conversion.Ascend.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions\trunk\build\x86\debug\Flux.Runner\Flux.Conversion.Core.dll">D:\Dev\soeconversions\trunk\build\x86\debug\Flux.Runner\Flux.Conversion.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions\trunk\build\x86\debug\Flux.Runner\Flux.Conversion.Exact.dll">D:\Dev\soeconversions\trunk\build\x86\debug\Flux.Runner\Flux.Conversion.Exact.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions\trunk\build\x86\debug\Flux.Runner\Flux.Framework.Core.dll">D:\Dev\soeconversions\trunk\build\x86\debug\Flux.Runner\Flux.Framework.Core.dll</Reference>
</Query>


var sqlConnection = new SqlConnection("server=AKDERNEST;Integrated Security=SSPI;database=Upsize_data_AU");
sqlConnection.Open();
var patientNotes = Flux.Conversion.Exact.Adapters.ExactAdapter.GetNotesUsingSuppiedFields(sqlConnection, "__NOTE_Merged", null);
var medicalNotes = Flux.Conversion.Exact.Adapters.ExactAdapter.GetMedicalNotesAndAlertsUsingSuppliedFields(sqlConnection, "__NOTE_Merged", null);
var clinicalNotes = Flux.Conversion.Exact.Adapters.ExactAdapter.GetClinicalNotes(sqlConnection, "__NOTE_Merged", null);
patientNotes.Count().Dump();
medicalNotes.Count().Dump();
clinicalNotes.Count().Dump();
// clinicalNotes.Dump();
