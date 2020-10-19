<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
</Query>

void Main()
{
	var rawTestCases = new[]{
		"None",
		"Trophy,Vixwin",
		"Orthocad,Cliniview,Bogus"
	};
	
 	rawTestCases.ToList().ForEach(rtc => Test(rtc));
}

void Test(string testCase){
	try{
	testCase.Split(',').Select(tc => Enum.Parse(typeof(PatientExternalLinkType), tc)).Dump();
	}
	catch{
		Console.WriteLine("Failed to Enum.Parse");
	}
	testCase.Split(',').Where(tc => Enum.TryParse(tc, true, out PatientExternalLinkType _)).Select(tc => Enum.Parse(typeof(PatientExternalLinkType), tc)).Dump();
// 	testCase.Split(',').Select(tc => Enum.Parse<PatientExternalLinkType>(tc)).Dump();
	// JsonConvert.DeserializeObject<PatientExternalLinkType[]>(testCase).Dump(); // expects json format

	var jsonFormat = String.Join(",", testCase.Split(',').Select(tc => $"\"{tc}\""));
	jsonFormat.Dump("jsonFormat");

	try{
		JsonConvert.DeserializeObject<PatientExternalLinkType[]>($"[{jsonFormat}]").Dump();
	}
	catch{
		Console.WriteLine("JsonConvert.DeserializeObject");
	}
	// JsonConvert.DeserializeObject<PatientExternalLinkType[]>(jsonFormat).Dump();
	
}


[JsonConverter(typeof(StringEnumConverter))]
// Define other methods and classes here
public enum PatientExternalLinkType
{
    None = 0,
    Trophy = 1,
    Schick = 2,
    Vixwin = 3,
    Digora = 4,
    Dexis = 5,
    Sidexis = 6,
    Mpdx = 7,
    Digident = 8,
    Vipersoft = 9,
    Visiquick = 10,
    Dicom = 11,
    Dimaxis = 12,
    FloridaProbe = 13,
    Vistadent = 14,
    DentalOffice = 15,
    Mediadent = 16,
    Cliniview = 17,
    Dbswin = 18,
    Iox = 19,
    Orthocad = 20,
    Apteryx = 21,
    Dolphin = 22,
    Bluedental = 23,
    DentalEye = 24,
    Orthometric = 25,
    Imaginit = 26,
    ExaminePro = 27,
    SchickCode = 28,
    SchickNumber = 29,
    SchickNumberPad = 30,
    DexisAdvanceNumber = 31,
    DexisStandardNumber = 32,
    Sopro = 33,
    Sterinstock = 34,
    Tigerview = 35,
    VistaDentoc = 36,
    Progeny = 37,
    Emago = 38,
    Guru = 39,
    Romexis = 40,
    Dios = 41,
    Didactic = 42,
    Scanora = 43,
    Arkive = 44,
    Iccms = 45,
    TwainSelect = 100,
    TwainScan = 101,
    Video = 102
}