<Query Kind="Statements" />

var directory = @"C:\Users\ernest.tidalgo\SOE\Tasks\AC-383 DI Tool to convert images from Mediasuite (D4W) to ExaminePro\Dalby";

var files = Directory.EnumerateFiles(directory, "*.cMi", SearchOption.AllDirectories);
files.ToList().ForEach(file => {
	file.Dump();
});
