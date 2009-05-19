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
        public static string Encrypt(string plainText, string Key, ref string IV, bool AutoIV)
        {
            try
            {
                Encryptor enc = new Encryptor(EncryptionAlgorithm.TripleDes);
                if (!AutoIV && IV != "")
                {
                    enc.IV = Convert.FromBase64String(IV);
                }
                byte[] cipherData = enc.Encrypt(Encoding.ASCII.GetBytes(plainText), Encoding.ASCII.GetBytes(Key));
                IV = Encoding.ASCII.GetString(enc.IV);
                return Convert.ToBase64String(cipherData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Decrypt(string cipherData, string Key, string IV)
        {
            try
            {
                Decryptor dec = new Decryptor(EncryptionAlgorithm.TripleDes);
                dec.IV = Convert.FromBase64String(IV);
                return Encoding.ASCII.GetString(dec.Decrypt(Convert.FromBase64String(cipherData), Convert.FromBase64String(Key)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Decrypt(string cipherData)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"Software\AnyPSecure", false);
                string key = (string)rk.GetValue("KEY", "");
                string iv = (string)rk.GetValue("IV", "");
                if (key == "")
                {
                    return "";
                }
                return Decrypt(cipherData, key, iv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetAppSetting(string key)
        {
            string data = System.Configuration.ConfigurationSettings.AppSettings[key] + "";
            if (data != "")
            {
                return Decrypt(data);
            }
            else
            {
                return "";
            }
        }

        public static byte[] EncryptMd5ForStoring(string md5String)
        {
            return Encoding.ASCII.GetBytes(md5String);
        }

        public static byte[] EncryptForStoring(string plainText)
        {
            return Encoding.ASCII.GetBytes(Md5(plainText));
        }

        public static string Md5(string plainText)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(plainText, "md5");
        }
    }
}
