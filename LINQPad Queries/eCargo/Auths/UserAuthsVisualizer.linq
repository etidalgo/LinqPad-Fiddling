<Query Kind="Statements">
  <Reference Relative="..\..\..\..\eCargo\eCargo.CSharp\Common\DataAccess\bin\Debug\ECargo.Common.DataAccess.dll">D:\dev\eCargo\eCargo.CSharp\Common\DataAccess\bin\Debug\ECargo.Common.DataAccess.dll</Reference>
  <Reference Relative="..\..\..\..\eCargo\eCargo.CSharp\Common\DataAccess\bin\Debug\ECargo.Common.Utilities.dll">D:\dev\eCargo\eCargo.CSharp\Common\DataAccess\bin\Debug\ECargo.Common.Utilities.dll</Reference>
  <Namespace>ECargo.Common.DataAccess.Core.Resources.Queries.AuthorisationsForCurrentUser</Namespace>
  <Namespace>ECargo.Common.DataAccess.Core.Users.Queries.UserAuthorisationsByUsers</Namespace>
</Query>

//var userAuths = UserAuthorisableFeatureMapper.InternalMapping;
//var features = UserAuthorisableFeatureMapper.GetMappedAuthorisableFeatures();
//foreach(var feature in features) {
//	Console.WriteLine($"{feature}");
//}
//
//foreach (UserAuthorisableFeature userAuth in Enum.GetValues(typeof(UserAuthorisableFeature))) {
//	Console.WriteLine($"UserAuth {userAuth}");
//}

var userAuths = ((UserAuthorisableFeature[])Enum.GetValues(typeof(UserAuthorisableFeature))).ToList();
var userAuthsF = userAuths.Select(uaf => uaf.ToString());
Console.WriteLine(",{0}", String.Join(",", userAuthsF));
//var hasUserAuths = UserAuthorisableFeatureMapper.Map(ECargo.Common.DataAccess.Core.Resources.Queries.AuthorisationsForCurrentUser.AuthorisableFeature.ViewRatesAndInvoicesAssignedToMySite);
//var visualHasUserAuth = userAuths.Select(uaf => hasUserAuths.Contains(uaf) ? "*" : " ");
//Console.WriteLine(String.Join(",", visualHasUserAuth));
var features = UserAuthorisableFeatureMapper.GetMappedAuthorisableFeatures();
foreach(var feature in features) {
	var hasUserAuths = UserAuthorisableFeatureMapper.Map(feature);
	var visualHasUserAuth = userAuths.Select(uaf => hasUserAuths.Contains(uaf) ? "*" : " ");
	var legacyAuth = AuthorisableFeatureMapper.Map(feature);
	
	Console.WriteLine("{0},{1}", feature, String.Join(",", visualHasUserAuth));
}