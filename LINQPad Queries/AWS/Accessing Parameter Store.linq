<Query Kind="Statements">
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\awssdk.core\3.3.101.2\lib\net45\AWSSDK.Core.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\awssdk.simplesystemsmanagement\3.3.101.3\lib\net45\AWSSDK.SimpleSystemsManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>Amazon.SimpleSystemsManagement</Namespace>
  <Namespace>Amazon.SimpleSystemsManagement.Model</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Can get from nuget
// Include references, AWSSDK.Core, AWSSDK.SimpleSystemsManagement, System.Threading.Tasks
// Include namespaces
// using Amazon.SimpleSystemsManagement
// using Amazon.SimpleSystemsManagement.Models
// using System.Threading.Tasks

// Uses current user's aws credentials. Originally expected AWS_DEFAULT_REGION to be set as system environment
var baseParameterPath = "/auth/v0/master/SOE/ascend-wavelength-api/";
var parameterName = baseParameterPath + "uk-dev/authorized_users/demouk/key"; // this might not exist
var awsRegion = "eu-west-2"; 
// var awsRegion = Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION"); // this needs to be set in Windows, SoE's AWS lambda sets this automatically
var endpoint = Amazon.RegionEndpoint.GetBySystemName(awsRegion);
var amazonSimpleSystemsManagementClient = new AmazonSimpleSystemsManagementClient(endpoint);

var responseTask = amazonSimpleSystemsManagementClient.GetParameterAsync(new GetParameterRequest
{
    Name = parameterName,
    WithDecryption = true
});

Task.WaitAll(responseTask);

responseTask.Result.Parameter.Value.Dump();