<Query Kind="Statements">
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\Newtonsoft.Json.8.0.3\lib\net45\Newtonsoft.Json.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\Newtonsoft.Json.8.0.3\lib\net45\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Net.Http.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Net.Http.Formatting.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Http.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Web.Http</Namespace>
</Query>

// Goes to internal implementation of HttpServer which needs proper configuration
// Returns "Not Found" meaning uri not found (it needs proper configuration)

var httpRequestMessage = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://localhost/")
};

var httpServer = new HttpServer();
// Console.WriteLine(httpServer.Configuration.Formatters);
var messageInvoker = new HttpMessageInvoker(httpServer);
var cancellationTokenSource = new CancellationTokenSource();
var response = await messageInvoker.SendAsync(httpRequestMessage, cancellationTokenSource.Token);
Console.WriteLine(response);
