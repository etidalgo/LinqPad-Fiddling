<Query Kind="Program" />

void Main()
{
	var properties = typeof(PatientExternalLinkType).GetProperties(BindingFlags.Public | BindingFlags.Static);
	properties.Dump("properties"); // These are not properties
	properties.ToList().ForEach(pr => pr.GetValue(null, null).Dump(pr.Name)); // prints nothing
	
	var fields = typeof(PatientExternalLinkType).GetFields();
	// fields.Dump();
	fields.ToList().ForEach(fi => $"{fi.Name}: {fi.GetValue(null)}".Dump());
}

public static class PatientExternalLinkType
    {
        public const double None = 0.0;
        public const double Trophy = 1;
        public const double Schick = 2;
        public const double Vixwin = 3;
        public const double Digora = 4;
        public const double Dexis = 5;
        public const double Sidexis = 6;
        public const double Mpdx = 7;
        public const double Digident = 8;
        public const double Vipersoft = 9;
        public const double Visiquick = 10;
        public const double Dicom = 11;
        public const double Dimaxis = 12;
        public const double FloridaProbe = 13;
        public const double Vistadent = 14;
        public const double DentalOffice = 15;
        public const double Mediadent = 16;
        public const double Cliniview = 17;
        public const double Dbswin = 18;
        public const double Iox = 19;
        public const double Orthocad = 20;
        public const double Apteryx = 21;
        public const double Dolphin = 22;
        public const double Bluedental = 23;
        public const double Dentaleye = 24;
        public const double Orthometric = 25;
        public const double Imaginit = 26;
        public const double ExaminePro = 27;
        public const double Schickcode = 28;
        public const double Schicknumber = 29;
        public const double Schicknumberpad = 30;
        public const double DexisAdvanceNumber = 31;
        public const double DexisStandardNumber = 32;
        public const double Sopro = 33;
        public const double Sterinstock = 34;
        public const double Tigerview = 35;
        public const double Vistadentoc = 36;
        public const double Progeny = 37;
        public const double Emago = 38;
        public const double Guru = 39;
        public const double Romexis = 40;
        public const double Dios = 41;
        public const double Didactic = 42;
        public const double Scanora = 43;
        public const double Arkive = 44;
        public const double Iccms = 45;
        public const double Twainselect = 100;
        public const double Twainscan = 101;
        public const double Video = 102;
    }