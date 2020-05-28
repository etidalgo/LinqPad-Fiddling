<Query Kind="Statements" />

// (double) cast is same as Convert.ToDouble and supposedly faster.
int someValue = 13;
var doubleVersion = (double)someValue;
var otherDoubleVersion = Convert.ToDouble(someValue);
doubleVersion.Dump();
otherDoubleVersion.Dump();