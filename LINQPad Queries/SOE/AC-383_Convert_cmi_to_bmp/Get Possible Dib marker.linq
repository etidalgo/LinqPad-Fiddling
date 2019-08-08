<Query Kind="Statements" />


var pathSource = @"C:\Users\ernest.tidalgo\SOE\Tasks\AC-383 DI Tool to convert images from Mediasuite (D4W) to ExaminePro\RF_00050316.cmi";

var dibTag = new byte[]{(byte)'D', (byte)'I', (byte)'B'}; // 68, 73, 66
var wrnTag = new byte[]{(byte)'W', (byte)'r', (byte)'n'}; // 87, 114, 110
var wefTag = new byte[]{(byte)0x57, (byte)0xCB, (byte)0x46}; // WEF, at offset 34
using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read)){
	var numberBytesToRead = 100;
	var rawBytes = new byte[numberBytesToRead];
	
	fsSource.Read(rawBytes, 0, numberBytesToRead);
	var bytes = rawBytes.ToList();
	
	var possibleWrn = bytes.Skip(35).Take(3).ToList();
	possibleWrn.SequenceEqual(wrnTag).Dump();
	possibleWrn.Dump();
	wrnTag.Dump();
	
	//bytes = rawBytes.ToList();
	var possibleDib = bytes.Skip(43).Take(3).ToList();
	possibleDib.SequenceEqual(dibTag).Dump();
	possibleDib.Dump();
	dibTag.Dump();
}
