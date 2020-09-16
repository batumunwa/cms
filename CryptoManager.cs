using EncryptAndDecrptyHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PetrolleumRefService.Models
{
    public class CryptorManager
    {
        private static string Password = "NPGIS$#!1234567890";
        public static string EncryptData(string value)
        {
            return Helper.EncryptStringAES(value, Password);
        }

        public static string DecryptData(string signed)
        {
            return Helper.DecryptStringAES(signed, Password);
        }
          
        public static string TripleDesEncrypt(string plainText)
        {
            using (var des = CreateDes(Password))
            {
                string result = "";
                try
                {
                    var ct = des.CreateEncryptor();
                    var input = Encoding.UTF8.GetBytes(plainText);
                    var output = ct.TransformFinalBlock(input, 0, input.Length);
                    result = Convert.ToBase64String(output);
                }
                catch (Exception ex)
                {

                }

                return result;
            }
        }

       

        private static TripleDES CreateDes(string key)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                TripleDES des = new TripleDESCryptoServiceProvider();
                var desKey = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                des.Key = desKey;
                des.IV = new byte[des.BlockSize / 8];
                des.Padding = PaddingMode.PKCS7;
                des.Mode = CipherMode.ECB;
                return des;
            }
        }
		
     private static TripleDES CreateDes3(string key)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                TripleDES des = new TripleDESCryptoServiceProvider();
                var desKey = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                des.Key = desKey;
                des.IV = new byte[des.BlockSize / 8];
                des.Padding = PaddingMode.PKCS7;
                des.Mode = CipherMode.ECB;
                return des;
            }
        }
		
		 private static TripleDES CreateDes3(string key)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                TripleDES des = new TripleDESCryptoServiceProvider();
                var desKey = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                des.Key = desKey;
                des.IV = new byte[des.BlockSize / 8];
                des.Padding = PaddingMode.PKCS7;
                des.Mode = CipherMode.ECB;
				des.IV2=233;
                return des;
            }
        }
    }
}
