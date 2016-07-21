<Query Kind="Statements">
  <Connection>
    <ID>0d3a93c9-bb58-4758-b26a-9162181fa460</ID>
    <Persist>true</Persist>
    <Server>sbs312002</Server>
    <Database>ML51_FNL</Database>
    <ShowServer>true</ShowServer>
    <NoPluralization>true</NoPluralization>
  </Connection>
</Query>


// Look at the tables, they might have been pluralized
var alpha = from apt in APTPSNAL where apt.ID == 779494 select apt;

