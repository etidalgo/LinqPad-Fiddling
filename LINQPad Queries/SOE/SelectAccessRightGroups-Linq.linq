<Query Kind="Statements">
  <Connection>
    <ID>4b7cfa88-d81a-4a15-965b-455d152a367d</ID>
    <Persist>true</Persist>
    <Server>localhost</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>GryphonAdmin</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAVUHTCB9Oa02hU2ZKeC1xuQAAAAACAAAAAAADZgAAwAAAABAAAACp2CxFAgADZmY7CzHEt0fdAAAAAASAAACgAAAAEAAAAJXYzTaO2nmFtDox9RXwiZMYAAAANdHjFVEd7PXHl5jfcpa4VPuoc1UTlIreFAAAAMcGTxIn5fjaLlu8H0MItsCTGK6z</Password>
    <Database>UK_STAGING_GRYPHON</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>


// OrganizationRoles.Dump();
var accessRightGroups = 
	from role in OrganizationRoles
	join accessRight in OrganizationRoleAccessRights on role.OrganizationRoleID equals accessRight.OrganizationRoleID
	group accessRight by role;
accessRightGroups.Dump();