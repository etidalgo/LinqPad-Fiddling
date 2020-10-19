<Query Kind="Program">
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\awssdk.core\3.3.101.2\lib\net45\AWSSDK.Core.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\awssdk.simplesystemsmanagement\3.3.101.3\lib\net45\AWSSDK.SimpleSystemsManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>Amazon.SimpleSystemsManagement</Namespace>
  <Namespace>Amazon.SimpleSystemsManagement.Model</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Uses current user's aws credentials. Originally expected AWS_DEFAULT_REGION to be set as system environment
	var rootParameterPath = "/auth/v0/master/SOE/ascend-wavelength-api/";
	
	// get all organization_users under tier
	var tier = "ac-1545-au";
	
	var userAuthentications  = LoadUserAuthenticationsFromParameterStore(tier);
	userAuthentications.Dump();
}

// Define other methods and classes here
public interface IUserIdentity
{
    string Username { get; }
    int OrganizationId { get; }
}

public class UserAuthentication: IUserIdentity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public int OrganizationId { get; set; }
}

private IEnumerable<UserAuthentication> LoadUserAuthenticationsFromParameterStore(string tier)
{
    var rootParameterPath = "/auth/v0/master/SOE/ascend-wavelength-api/";

    var awsRegion = Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION");

    var endpoint = Amazon.RegionEndpoint.GetBySystemName(awsRegion);
    var amazonSimpleSystemsManagementClient = new AmazonSimpleSystemsManagementClient(endpoint);

    // get all organization_users under tier
    var parameterType = "organization_users";
    var organizationUsersBasePath = $"{rootParameterPath}{tier}/{parameterType}";
    var getParametersByPathResponseTask = amazonSimpleSystemsManagementClient.GetParametersByPathAsync(new GetParametersByPathRequest
    {
        Path = organizationUsersBasePath,
        Recursive = true,
        WithDecryption = true
    });
    Task.WaitAll(getParametersByPathResponseTask);

    var parameters = getParametersByPathResponseTask.Result.Parameters;

	return parameters.ToArray().Select(GetUserAuthenticationFromParameter);
}

(string userName, int organizationId) ExtractOrganizationUserValues(string organizationUserParameter){
	var rootParameterPath = "/auth/v0/master/SOE/ascend-wavelength-api/";
	var tier = "ac-1545-au";
	var parameterType = "organization_users";
	var organizationUsersBasePath = $"{rootParameterPath}{tier}/{parameterType}";

	var organizationUserSlashSeparatedValues = organizationUserParameter.Substring(organizationUsersBasePath.Length + 1);
	var organizationUserValues = organizationUserSlashSeparatedValues.Split('/');
	var userName = organizationUserValues[0];
	var organizationId = Int32.Parse(organizationUserValues[1]);
	return (userName, organizationId);
}

UserAuthentication GetUserAuthenticationFromParameter(Parameter parameter){
	var (userName, organizationId) = ExtractOrganizationUserValues(parameter.Name);
	var password = parameter.Value;
	
	return new UserAuthentication{
		Username = userName,
		Password = password,
		OrganizationId = organizationId
	};
}