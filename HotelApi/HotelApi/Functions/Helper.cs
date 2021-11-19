using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApi.Functions
{
    public class Helper
    {
        public string GetDateChangeFormat(string date)
        {
            string[] parte = null;
            parte = date.Trim().Split("/");
            return (parte[2].Trim() + "-" + parte[1].Trim() + "-" + parte[0].Trim());
        }

        public string GetDateChangeFormatCal(string date)
        {
            string[] parte = null;
            parte = date.Trim().Split("/");
            return (parte[2].Trim() + "-" + parte[1].Trim() + "-" + parte[0].Trim());
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        public static string GetToken()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[18];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        } 


    }
}
