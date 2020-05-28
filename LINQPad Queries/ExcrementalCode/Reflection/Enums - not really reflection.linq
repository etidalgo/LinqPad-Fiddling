<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
</Query>


void Main()
{
	Enum.GetValues(typeof(PatientExternalLinkType)).Cast<int>().ToList().ForEach(pelt => pelt.Dump());
}

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
        Dentaleye = 24,
        Orthometric = 25,
        Imaginit = 26,
        ExaminePro = 27,
        Schickcode = 28,
        Schicknumber = 29,
        Schicknumberpad = 30,
        DexisAdvanceNumber = 31,
        DexisStandardNumber = 32,
        Sopro = 33,
        Sterinstock = 34,
        Tigerview = 35,
        Vistadentoc = 36,
        Progeny = 37,
        Emago = 38,
        Guru = 39,
        Romexis = 40,
        Dios = 41,
        Didactic = 42,
        Scanora = 43,
        Arkive = 44,
        Iccms = 45,
        Twainselect = 100,
        Twainscan = 101,
        Video = 102
    }