using System;
using System.Text;

/// <summary>
/// 安全设置类
/// </summary>
public class Secure
{
    public static string Encrypt(string plainText, string Key, string IV)
    {
        try
        {
            if (Key.Length < 24)
            {
                while (Key.Length < 24)
                {
                    Key += "$";
                }
            }
            if (IV.Length < 8)
            {
                while (IV.Length < 8) 
                {
                    IV += "$";
                }
            }
            Encryptor enc = new Encryptor(EncryptionAlgorithm.TripleDes);
            enc.IV = Encoding.ASCII.GetBytes(IV);
            byte[] cipherData = enc.Encrypt(Encoding.ASCII.GetBytes(plainText), Encoding.ASCII.GetBytes(Key));
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
            if (Key.Length < 24)
            {
                while (Key.Length < 24)
                {
                    Key += "$";
                }
            }
            if (IV.Length < 8)
            {
                while (IV.Length < 8)
                {
                    IV += "$";
                }
            }
            Decryptor dec = new Decryptor(EncryptionAlgorithm.TripleDes);
            dec.IV = Encoding.ASCII.GetBytes(IV);
            return Encoding.ASCII.GetString(dec.Decrypt(Convert.FromBase64String(cipherData), Encoding.ASCII.GetBytes(Key)));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}