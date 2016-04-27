<Query Kind="Expression">
  <Connection>
    <ID>538db2cf-b270-4e1c-b517-c2751c9f31e6</ID>
    <Persist>true</Persist>
    <Server>aklqikdev</Server>
    <SqlSecurity>true</SqlSecurity>
    <NoPluralization>true</NoPluralization>
    <UserName>WEB_FNL</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAvRTNP875d0+cWTSmEXqnhwAAAAACAAAAAAADZgAAwAAAABAAAACevfmCZ1puNap8KtsO8esLAAAAAASAAACgAAAAEAAAAHsOf7L6RPhlxWAlYhlLKoAIAAAASWets9JtzbAUAAAA1olSXlkiiVt3Vn94PS55y2UrRz4=</Password>
    <Database>ML51_FNL</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>


// Look at the tables, they might have been pluralized
from apt in APTPSNAL where apt.ID == 779494 select apt