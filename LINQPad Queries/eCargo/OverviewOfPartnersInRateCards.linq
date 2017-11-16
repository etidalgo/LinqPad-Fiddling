<Query Kind="SQL">
  <Connection>
    <ID>3db91f8f-405c-4f62-b2b9-9ce8840a88f4</ID>
    <Persist>true</Persist>
    <Server>ecargoernestdev</Server>
    <Database>hub_200</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

select ChargeTypeId, ChargeTypeName, count(ChargeTypeId) from support.RateCard 
where 
	ownerid = 9168
group by ChargeTypeId, ChargeTypeName

select customerId, CustomerName, count(customerId) from support.RateCard 
where 
	ownerid = 9168
group by customerId, CustomerName
