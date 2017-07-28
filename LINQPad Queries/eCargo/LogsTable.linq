<Query Kind="Statements">
  <Connection>
    <ID>3db91f8f-405c-4f62-b2b9-9ce8840a88f4</ID>
    <Persist>true</Persist>
    <Server>ecargoernestdev</Server>
    <Database>EC2245</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

LogEntries.Dump();
LogEntries.Where( le => le.WrittenToLogDatabaseSequence == 6 ).Dump();

