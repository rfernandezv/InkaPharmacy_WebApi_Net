using System.Security.Cryptography;
using System.Text;
using System;
namespace InkaPharmacy.Api.Common.Security
{
    public class Hash{

    public static string GetHash(string text)  
    {  
        using(var sha256 = SHA256.Create())  
        {  
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text)); 
            var result = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            Console.WriteLine(result);
            return result;   
        }  
    }  

    }
}