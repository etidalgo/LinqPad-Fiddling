<Query Kind="SQL">
  <Connection>
    <ID>5fe3cd54-1f3e-4a09-8673-126a8dad9184</ID>
    <Persist>true</Persist>
    <Provider>System.Data.SqlServerCe.4.0</Provider>
    <AttachFileName>D:\Data\Logs\Logs.sdf</AttachFileName>
    <MaxDatabaseSize>4091</MaxDatabaseSize>
  </Connection>
</Query>

select top 100 * from LogEntry
--where LogEntryId like '4f0db3d5%'-f967-4310-87e0-38866187e63b