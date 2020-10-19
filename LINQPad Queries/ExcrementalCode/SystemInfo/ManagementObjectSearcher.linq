<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Management</Namespace>
</Query>


using (var s = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
{
    foreach (var obj in s.Get())
    {
        string name = obj["Name"]?.ToString();
		name.Dump();
    }
}


// It would be nice to use Linq here but GetEnumerator is clumsy to convert to linq
//[ManagementObjectCollection.GetEnumerator Method (System.Management) | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/api/system.management.managementobjectcollection.getenumerator?view=dotnet-plat-ext-3.1#System_Management_ManagementObjectCollection_GetEnumerator)
//[ManagementObjectCollection Class (System.Management) | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/api/system.management.managementobjectcollection?view=dotnet-plat-ext-3.1)
//[ManagementBaseObject Class (System.Management) | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/api/system.management.managementbaseobject?view=dotnet-plat-ext-3.1)
//