<Query Kind="Statements" />

var replaceLeadingCode = new Regex("^\\d{2,3} +([a-zA-z])");
var cases = new[]{"", string.Empty, "alpha", "00 Check up", "00 check up", "00   Leading spaces", "311 Review", "311 001 Review", "311 001 review", "3D printer", "3 month visit", "Forward 100 spaces"}.ToList();
cases.ForEach(str => replaceLeadingCode.Replace(str, "$1").Dump(str));
