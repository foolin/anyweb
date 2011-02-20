using System;
using System.Security.Cryptography;
using System.IO;
  

namespace Studio.Security
{
	/// <summary>
	/// Ω‚√‹¿‡
	/// </summary>
	internal class Decryptor
	{
		private DecryptTransformer transformer;
		private byte[] initVec;
		
		internal Decryptor(EncryptionAlgorithm algId)
		{
			transformer = new DecryptTransformer(algId);
		}
  
		internal byte[] Decrypt(byte[] bytesData, byte[] bytesKey)
		{
			//Set up the memory stream for the decrypted data.
			MemoryStream memStreamDecryptedData = new MemoryStream();

			//Pass in the initialization vector.
			transformer.IV = initVec;
			ICryptoTransform transform = transformer.GetCryptoServiceProvider(bytesKey);
			CryptoStream decStream = new CryptoStream(memStreamDecryptedData, 
				transform, 
				CryptoStreamMode.Write);
			try
			{
				decStream.Write(bytesData, 0, bytesData.Length);
			}
			catch(Exception ex)
			{
				throw new Exception("Error while writing encrypted data to the stream: \n" 
					+ ex.Message);
			}
			decStream.FlushFinalBlock();
			decStream.Close();
			// Send the data back.
			return memStreamDecryptedData.ToArray();
		} //end Decrypt
  
		internal byte[] IV
		{
			set{initVec = value;}
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
