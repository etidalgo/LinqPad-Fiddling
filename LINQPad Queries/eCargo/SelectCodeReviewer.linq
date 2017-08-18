<Query Kind="Program" />

void Main()
{
	List<string> TeamMembers = new List<string>{
        "bartj", "jamesgilberd", "ernesttidalgo"
    };

	foreach(var commitHash in TestCases()) {
		var reviewerPool = TeamMembers.Except( new List<string>{"bartj"} ).ToArray();
	    var sum = commitHash.ToCharArray().Sum(ch => Int32.Parse(string.Format($"{ch}"), System.Globalization.NumberStyles.HexNumber));
	    var selectedIdx = sum % reviewerPool.Count();
		Console.WriteLine(reviewerPool.ElementAt(selectedIdx));
	}	
}

// Define other methods and classes here
IEnumerable<string> TestCases(){
	yield return "9cc290951c4b2413dc89ffffde0ff80eecb3c2f1";
	yield return "59124a05a526e61d2270b3d68d5d22afb6a1e8b8";
	yield return "e03d0bcb0c49036c2d51aa107f891fa68b81a085";
	yield return "3326abfe8dbe0db91c7b68f6ea5a28283255c8b4";
	yield return "01da69d93cefa3ec1f15ccf287855a86591c8361";
	yield return "a0763238fb5b52d67fde9c871bec9b699e70d20b";
	yield return "439410499bede8f15b41e1051ed1d3cec51f3267";
	yield return "0f0135c7b7e74ce24e0defb10ef25f35d96cb0a2";
	yield return "ea0556a74fe4ad1775c4f9248ae16dc3d6445a36";
	yield return "ff9e2d4b7dca9ba4602c78915b13dfb43ba2d30e";
	yield return "09a65c939de91f589b6cb2b0b4249b24e0d27d17";
	yield return "2db025c8c18bfff0134c828b398af62b5f58706b";
	yield return "f09ec0d4c0d666c1acbf079608bf78f947098792";
	yield return "1ae9988f08c45171b8276887ae528365e066512e";
	yield return "4ac168e6422edf69517dce18b14a2701c0414204";
	yield return "01e59950de8cfb8a31832131a21daa6157fbfbf8";
	yield return "5ba3e0c532677f7510019f51d5508df1cc2f1353";
	yield return "57bd044b519ef1956748fd3f6ed6f9b0992569e4";
	yield return "5499b91142a12997f209654d9dcacd6ef2f739fe";
	yield return "cd2d286ae63ca946d1f692b9489747413b086d2a";
	yield return "49152beea817d09211cbbc88a10963d54260df68";
	yield return "363f07cacc475dd597ba018fa8a199f5bca22fdf";
	yield return "e237396b00685c401c9ce2773773803f2a155443";
	yield return "27667d62425581e931e4cbeac1ca8b5682e8fbeb";
	yield return "575abf074f78af4f3ff1d0693155e6a945daf221";
	yield return "bad29ecf291c9517ddca135ea299dd629b3899bd";
	yield return "fd17971fcdb2cfeb35a2008ff8d25522a05ab05c";
	yield return "8c0dd175cf27c9d104d68d53adb8a4c9dda152cc";
	yield return "65bdb6115174d6c9bc07e692a37922a4a77ccac3";
	yield return "df91b4d905c24be5f3970c32d32afd9cd58bb4b9";
	yield return "454a8301380baea0fb07ea0e76598bf557a865d8";
	yield return "3f2ed38941166ebb729ba04ee2cfb87779581dd9";
	yield return "ee11b65530742fc92ffddb4b6a56433bd7365b7e";
	yield return "2bc96a6317496d1d1328a1c77bcb7928f581dfc1";
	yield return "ec623f481b4040b3c7daa826487def618fd4d65e";
	yield return "63b10f028db86e536a7f999061b37b93c4b5b131";
	yield return "e651f9e354504fc265bc56896cfa39602f7641b8";
	yield return "1249568e9589dca55a09129daf0803359ffeba59";
	yield return "fef10cf9acb9b04122cff0275e5dfd8ad4b7028b";
	yield return "1ba1002cb2090944776be1bd79121dc6ed739d09";
	yield return "baf3b3c09c2a685fb4d42be9c4af2f3b63afd8b2";
	yield return "c7d5beec023d972a537adec1ffea5e25cca0d124";	
}
