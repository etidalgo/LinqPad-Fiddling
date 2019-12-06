<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>System.Globalization</Namespace>
</Query>

var variousDateTimeText = new[]{
	//"28/11/2012 12:00:00 AM", "6/12/2012 12:00:00 AM", "9/01/2013 12:00:00 AM",
	//"09/01/2013 00:00:00", "28/11/2012 00:00:00"
	"2012-11-28 00:00:00"
	};

variousDateTimeText.ToList().ForEach(dt => {
	LINQPad.Extensions.Dump(dt, "Parsing: ");
	var dateTime = DateTime.Parse(dt, CultureInfo.InvariantCulture);
	LINQPad.Extensions.Dump(dateTime, "Got: ");
});

