<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Reference Assemblies\Microsoft\Framework\MonoAndroid\v1.0\Facades\System.Net.Mail.dll</Reference>
  <Namespace>System.Net.Mail</Namespace>
</Query>

void Main()
{
	var emails = new[] { "no-reply@ecargo.co.nz" };
	IsValidEmailAddress("no-reply@ecargo.co.nz");
	IsValidEmailAddress("no-reply@ecargo");
	IsValidEmailAddress("no-reply@ecargo.tld");
	IsValidEmailAddress("no  reply@ecargo.co.nz");
	IsValidEmailAddress("no-@reply@ecargo.co.nz");
	IsValidEmailAddress("noreply.@ecargo.co.nz");
	IsValidEmailAddress(".no-reply@ecargo.co.nz");
	IsValidEmailAddress("no..reply@ecargo.co.nz");
	IsValidEmailAddress("no-reply@ecargo.co.");
}

// Define other methods and classes here
void IsValidEmailAddress(string candidateEmail) {
	var test1 = IsValidEmailAddressByMailAddress(candidateEmail);
	var test2 = IsEmailAddressFormat(candidateEmail);
	Console.WriteLine($"<{candidateEmail}> {test1} {test2}");
}

// MailAddress Class (System.Net.Mail) | Microsoft Docs <https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress?view=netframework-4.7.2>
// I Knew How To Validate An Email Address Until I Read The RFC | You’ve Been Haacked <https://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx/>
bool IsValidEmailAddressByMailAddress(string candidateEmail) {
	try {
	var validAddress = new MailAddress(candidateEmail);
	return true;
	} 
	catch {}
	
	return false;
}

// How to: Verify that Strings Are in Valid Email Format | Microsoft Docs <https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format>
bool IsEmailAddressFormat(string candidateEmail) {
       // Return true if strIn is in valid email format.
       try {
          return Regex.IsMatch(candidateEmail,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
       }
       catch (RegexMatchTimeoutException) {
          return false;
       }
}