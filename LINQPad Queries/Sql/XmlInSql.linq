<Query Kind="SQL">
  <Connection>
    <ID>3db91f8f-405c-4f62-b2b9-9ce8840a88f4</ID>
    <Persist>true</Persist>
    <Server>ecargoernestdev</Server>
    <Database>hub_200</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

declare @payload xml = '<CoreConsignmentsChangedPayload>
  <ConsignmentId>8188142</ConsignmentId>
</CoreConsignmentsChangedPayload>';

select @payload.value('(/CoreConsignmentsChangedPayload/ConsignmentId)[1]', 'int') 

select @payload.value('(//ConsignmentId)[1]', 'int') 
