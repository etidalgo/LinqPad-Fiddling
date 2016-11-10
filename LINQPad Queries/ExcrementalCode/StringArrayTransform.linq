<Query Kind="Statements">
  <Namespace>System.Globalization</Namespace>
</Query>


string[] elements = {"EventService", "ECargo.Workers.EventService"};
string[] payloads = elements.Select( el => 
string.Format(
                CultureInfo.InvariantCulture,
                "OWNING_RESOURCE_ID=alpha;CONSIGNMENT_ID=beta;Event_Source={0}.exe;",
                el)).ToArray();
payloads.Dump();
				