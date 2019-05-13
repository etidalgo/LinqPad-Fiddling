<Query Kind="Program">
  <Connection>
    <ID>06206175-c66e-463a-8ad8-043642d969d6</ID>
    <Persist>true</Persist>
    <Server>uk-db.ascend.dental,21433</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>gryphonapp</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAiANtNTUKyUK4m/Yelz/nPQAAAAACAAAAAAADZgAAwAAAABAAAAA5QnsMuBj114IZs4XLdUJ1AAAAAASAAACgAAAAEAAAAAChQlJDQY7/azth7GhIvVwYAAAA+LJ5JcpT2cXdGajm35NL0jH4k2HaXVFtFAAAAEbLnSjGTOTtGmxv3er7nl2GJ2a4</Password>
    <Database>UK_BUPA_GRYPHON</Database>
    <ShowServer>true</ShowServer>
    <NoPluralization>true</NoPluralization>
  </Connection>
</Query>

void Main()
{
	
	var scheduleItems = 
	from siop in ScheduleItemOrganizationProcedure
	join si in ScheduleItem on siop.ScheduleItemID equals si.ScheduleItemID // appointment
	join op in OrganizationProcedure on siop.OrganizationProcedureID equals op.OrganizationProcedureID // practice procedure
	
	
	// where si.Patient
	select new {
		OrganizationID = siop.OrganizationID,
		ID = siop.ScheduleItemOrganizationProcedureID,
		StartDateTime = si.StartDateTime,
		ProcedureDescription = op.Description,
		AbbreviatedDescription = op.AbbreviatedDescription,
		Note = si.Note,
		Status = "OTHER", //  from AppointmentOrganizationProcedureNoteService.groovy
		Code = op.AdaCode,
		LocationID = si.LocationID,
		ProviderID = si.ProviderID,
		PatientID = si.PatientID
		
		// 
	};
	
	scheduleItems.Dump();
}

// Define other methods and classes here
//public class TreatmentNote {
//	public enum TreatmentNoteType {
//		Prescription,
//		ClinicalNote,
//		Procedure,
//		Condition,
//		OrganizationProcedure
//	};
//}