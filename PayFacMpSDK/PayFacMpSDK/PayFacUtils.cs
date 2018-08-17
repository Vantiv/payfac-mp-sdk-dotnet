using System;
using System.Collections.Generic;
using System.Text;

namespace PayFacMpSDK

{

    public class PayFacUtils
    {

        public static string BytesToString(List<byte> bytes)
        {
            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        public static byte[] StringToBytes(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string Encode64(string s, string encode)
        {
            return Convert.ToBase64String(System.Text.Encoding.GetEncoding(encode)
                .GetBytes(s));
        }
    }
}