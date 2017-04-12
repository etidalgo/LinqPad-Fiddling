<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Net.Http.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
</Query>


using(var client = new HttpClient())
{
    var result = await client.GetAsync("https://localhost/api.V3/UpdateConsignment");
	Console.WriteLine(result);
}