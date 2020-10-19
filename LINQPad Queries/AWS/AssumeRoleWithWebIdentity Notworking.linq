<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\AWS SDK for .NET\bin\Net45\AWSSDK.Core.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\AWS SDK for .NET\bin\Net45\AWSSDK.SecurityToken.dll</Reference>
  <Namespace>Amazon.Runtime</Namespace>
</Query>

var credentials = AssumeRoleWithWebIdentityCredentials.FromEnvironmentVariables();


