using System;
using System.Security.Cryptography;

namespace Studio.Security
{
    /// <summary>
    /// Ω‚√‹‘ÀÀ„À„∑®
    /// </summary>
    internal class DecryptTransformer
    {
        private EncryptionAlgorithm algorithmID;
        private byte[] initVec;

        internal DecryptTransformer(EncryptionAlgorithm alg)
        {
            algorithmID = alg;
        }

        internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey)
        {
            // Pick the provider.
            switch (algorithmID)
            {
                case EncryptionAlgorithm.Des:
                    {
                        DES des = new DESCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;
                        des.Key = bytesKey;
                        des.IV = initVec;
                        return des.CreateDecryptor();
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        TripleDES des3 = new TripleDESCryptoServiceProvider();
                        des3.Mode = CipherMode.CBC;
                        return des3.CreateDecryptor(bytesKey, initVec);
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        RC2 rc2 = new RC2CryptoServiceProvider();
                        rc2.Mode = CipherMode.CBC;
                        return rc2.CreateDecryptor(bytesKey, initVec);
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijndael = new RijndaelManaged();
                        rijndael.Mode = CipherMode.CBC;
                        return rijndael.CreateDecryptor(bytesKey, initVec);
                    }
                default:
                    {
                        throw new CryptographicException("Algorithm ID '" + algorithmID +
                            "' not supported.");
                    }
            }
        } //end 

        internal byte[] IV
        {
            set { initVec = value; }
        }


    }
}
