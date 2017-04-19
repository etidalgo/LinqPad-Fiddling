<Query Kind="SQL">
  <Connection>
    <ID>3db91f8f-405c-4f62-b2b9-9ce8840a88f4</ID>
    <Persist>true</Persist>
    <Server>ecargoernestdev</Server>
    <Database>hub_200</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>


declare @consignmentNumber varchar(20) = '0097290707';
declare @consignmentId int = 8114181;
declare @latestConsignmentActionId int;

/****** Script for SelectTopNRows command from SSMS  ******/
declare @selectedConsignmentId int;
SELECT @selectedConsignmentId = [consignment_id], @latestConsignmentActionId = [latest_consignment_action_id]
FROM [hub_200].[dbo].[consignment] 
  where consignment_id = 8188140
--  where consignment_number = @consignmentNumber

SELECT TOP 1 * FROM [hub_200].[dbo].[consignment] 
  where consignment_id = @selectedConsignmentId

declare @resourceId int;
declare @objectActionId int;
  select * from object_action_instance where object_action_instance_id = @latestConsignmentActionId

  select oa.name as ActionName, oa.description as ActionDescription
	, rs.name as ResourceName
	from object_action_instance oai
		inner join object_action oa on oai.object_action_id = oa.object_action_id
		inner join resource rs on oai.resource_id = rs.resource_id
	where object_action_instance_id = @latestConsignmentActionId

 -- select @resourceId = oai.resource_id, @objectActionId = oai.object_action_id  
	--from object_action_instance oai
	--where object_action_instance_id = @latestConsignmentActionId
--  select * from object_action where object_action_id = @objectActionId
--  select * from resource where resource_id = @resourceId
  
