using System;
using System.Text;
using System.Web.Security;

using Microsoft.Win32;

namespace Studio.Security
{
    /// <summary>
    /// 安全设置类
    /// </summary>
    public class Secure
    {
        static string Key = "Anywell520!";
        static string IV = "Aw123!@#";
        public static string Decrypt( string cipherData )
        {
            if( cipherData.Length == 0 )
            {
                return "";
            }
            if( Key.Length < 24 )
            {
                while( Key.Length < 24 )
                {
                    Key += "$";
                }
            }
            if( IV.Length < 8 )
            {
                while( IV.Length < 8 )
                {
                    IV += "$";
                }
            }
            try
            {
                Decryptor dec = new Decryptor( EncryptionAlgorithm.TripleDes );
                dec.IV = Encoding.ASCII.GetBytes( IV );
                return Encoding.ASCII.GetString( dec.Decrypt( Convert.FromBase64String( cipherData ), Encoding.ASCII.GetBytes( Key ) ) );
            }
            catch( Exception ex )
            {
                throw ex;
            }
        }

        public static byte[] EncryptMd5ForStoring( string md5String )
        {
            return Encoding.ASCII.GetBytes( md5String );
        }

        public static byte[] EncryptForStoring( string plainText )
        {
            return Encoding.ASCII.GetBytes( Md5( plainText ) );
        }

        public static string Md5( string plainText )
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile( plainText, "md5" );
        }
    }

    public enum EncryptionAlgorithm
    {
        Des = 1,
        Rc2,
        Rijndael,
        TripleDes
    };
}
