<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.Cryptography.Algorithms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.Cryptography.X509Certificates.dll</Reference>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
</Query>

// [C# Online Compiler | .NET Fiddle] (https://dotnetfiddle.net/khZzCP)
public class Program
{
	public static void Main()
	{
		var encodedPublicKey = "MIIBCgKCAQEAvF7f0/KXR5O/FvG6lbO4meU6dv/hB2tgjZv9CfwIWhWS6f2O8jFw0LT34uJ3hbrM4W2K5TWXajpnFciKg1jTdjnmcllaB02ssRX4vNgvVTFAO5N2/KnKpLRH2rsm6tP621X2po9BphULonWIG39KULzc9NjJk34PDuBzosVNSHGP186efpG3YY4PtrGTSKBNgfs+FW2U2div/xF88DX4b49faOe2CcBNzgVPhO3EUcpkqI3M+PgvBPboXmNWEKk2F6OwBlqCp8NAFBhiSeChZlZIP17YpvVWvFsQSV+sJ/jfoAxiHjvwwtiCQOxfX5v6AkJ10VyANgO1qyJ8DoIzOQIDAQAB";
		var publicKey = Convert.FromBase64String(encodedPublicKey);
		
		RSA rsa = RSA.Create();

		//var privateKey = rsa.ExportRSAPrivateKey();
		//var encodedPrivateKey = Convert.ToBase64String(privateKey);
		//Console.WriteLine(encodedPrivateKey);

		rsa.ImportRSAPublicKey(publicKey, out int keyLength);
		var encryptedValue = Encrypt("My secret information", rsa);
		Console.WriteLine(encryptedValue);
		
		var encodedPrivateKey = "MIIEpAIBAAKCAQEAvF7f0/KXR5O/FvG6lbO4meU6dv/hB2tgjZv9CfwIWhWS6f2O8jFw0LT34uJ3hbrM4W2K5TWXajpnFciKg1jTdjnmcllaB02ssRX4vNgvVTFAO5N2/KnKpLRH2rsm6tP621X2po9BphULonWIG39KULzc9NjJk34PDuBzosVNSHGP186efpG3YY4PtrGTSKBNgfs+FW2U2div/xF88DX4b49faOe2CcBNzgVPhO3EUcpkqI3M+PgvBPboXmNWEKk2F6OwBlqCp8NAFBhiSeChZlZIP17YpvVWvFsQSV+sJ/jfoAxiHjvwwtiCQOxfX5v6AkJ10VyANgO1qyJ8DoIzOQIDAQABAoIBACSAzicob6BzRSiRF3NDLJbGERpWY6koacGHZPW2XXf3jkzB0h2k7xPCvfa9pCPKG0HkFHJufDUdtDRIdG8Xm4LhnYKzRfr8VmbKtzUBP8rmjGf/H6O+04IvXW1JrzT6dzZh5jZItJQWp/aHiCSr+h7DOp5IFGf8mbZsUHxOd7d91HSs5ar01kfkxayJ8hmGPtb7xIPuGhJEFlWZSkfptVxfjoj/0ZYEHGNImketDFQHD9ne8H6pze8NTbxOviOZzz533c3iS3Oc+DhJ6HOmtjttDqr3CQgoZey3mOWqv4WJO1gzKQ1JmmnAVu4HWvu/wDH+guifeCDMylVdbnhQ6MECgYEA+Rit9qInxR1+40ZyqZWT+uSBf8IjsTVd8tB+erF+kBE0aXnJxyG5IrWYgPgxSLDBYbfaU46vyAOavh7b8FollIB6tcgd2Pumrz0+bvE1EHi8WdeLuuCLKgJ6EYPyvZBvsTY5L8Tey3cyyu/ZMyA7AwPtsv/jATiNKiKgecB4eR0CgYEAwZdZiH+4Notvk0u6Yn5jzIC3//bVf/n7+gYGZII0MndAX/OBDlCmxGKVp5mR6QWsc2Zx9IE3S/oeYvqpSw7OE28vgMd3k4qPoMdT2Rw27/KdWyzE7O35p2we95HUWzHYqibFYjv2BqtMr9nbmTJXnOUKFFpBcXBXmcLjfnCPY80CgYEAylOxedLcWs9KcXCXUgec2v0f8pXOR/IBDWksUpw5IOvYlpPFwWky5255IMh3v4NSj/y16YjMXroOxr5qByAxxh1VjrGtDMHa8hvcymBBqc9nrdHWPUSFxOmeHPv//tmC334blSFjlgCL0SpgUZasWBaoy+vshuFYSBE4J6yeLkECgYEAm4VkFwVLzv3bZ8B5fnC86egqaUY5pDMGm4hFkG8NUdF9dNfhQMfIAZKVWWxEzKeTL64IM/2ul6nayXdHk5XUNcanqdQUmwHAetBG6u8Ar2j/wuRHW3OekUKJ6idMKurzfVXiUhWLgzYQSGFDSmIoAlH58/nCA0jWBx+KtOPmPa0CgYBmV0MKYnLos9EwTXB7j7uJqKJIZs3VfeB2vEKlHRKzNRzacVdpsgLUlEq+aAaxlv4lbaWZWXBqeTBlDRPZaV2brjvv6tmpD1cVuEEF0Vts+DZcANXGYp3yVyzPc3MLfdTMwc35mjqQ6hyGVzHllT7Bh+9/RnSDiZRppWhpFapfMA==";
		var privateKey = Convert.FromBase64String(encodedPrivateKey);

		rsa = RSA.Create();
		
		rsa.ImportRSAPrivateKey(privateKey, out keyLength);
		var decryptedValue = Decrypt(encryptedValue, rsa);
		Console.WriteLine(decryptedValue);
	}
	
	public static string Encrypt(string text, RSA rsa)
	{
		byte[] data = Encoding.UTF8.GetBytes(text);
		byte[] cipherText = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
		return Convert.ToBase64String(cipherText);
	}

	public static string Decrypt(string text, RSA rsa)
	{
		byte[] data = Convert.FromBase64String(text); 
		byte[] cipherText = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
		return Encoding.UTF8.GetString(cipherText);
	}	
}