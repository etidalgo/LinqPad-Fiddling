<Query Kind="Statements" />

// Powershell , this doesn't work
// $env:TestEnvVar_ApiKey = 'ThisValue'
// [Environment.GetEnvironmentVariable Method (System) | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable?view=net-5.0)
// This seems to work but must be run prior to this exe
// setx TestEnvVar_ApiKey 'ThisValue1'
// echo %TestEnvVar_ApiKey%

var varName = "TestEnvVar_ApiKey";
var varValue = Environment.GetEnvironmentVariable(varName);
varValue.Dump(varName);
