<Query Kind="Statements" />

var testValues = new[]{string.Empty, "alpha", string.Empty, "gamma" };
var withDefaults = testValues.Select((a, i) => string.IsNullOrEmpty(a) ? $"Memo{i+1}" : a);
withDefaults.ToList().ForEach(a => a.Dump());

