//using System.Security.Cryptography;

//namespace Digital_Image_Analysis.Helpers
//{
//    public static class EncryptionHelper
//    {
//        public static string EncryptImageData(byte[] imageData, byte[] key, byte[] iv)
//        {
//            using (var aesAlg = Aes.Create())
//            {
//                aesAlg.Key = key;
//                aesAlg.IV = iv;

//                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
//                using (var msEncrypt = new MemoryStream())
//                {
//                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
//                    {
//                        csEncrypt.Write(imageData, 0, imageData.Length);
//                        csEncrypt.FlushFinalBlock();
//                    }

//                    var encryptedData = msEncrypt.ToArray();
//                    return Convert.ToBase64String(encryptedData);
//                }
//            }
//        }
//        public static byte[] DecryptImageData(byte[] encryptedData, byte[] key, byte[] iv)
//        {
//            byte[] decryptedData;

//            using (var aesAlg = Aes.Create())
//            {
//                aesAlg.Key = key;
//                aesAlg.IV = iv;

//                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
//                using (var msDecrypt = new MemoryStream(encryptedData))
//                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
//                using (var ms = new MemoryStream())
//                {
//                    int data;
//                    while ((data = csDecrypt.ReadByte()) != -1)
//                    {
//                        ms.WriteByte((byte)data);
//                    }

//                    decryptedData = ms.ToArray();
//                }
//            }

//            return decryptedData;
//        }
//    }
//}
using System;
using System.IO;
using System.Security.Cryptography;

namespace Digital_Image_Analysis.Helpers
{
    public static class EncryptionHelper
    {
        public static string EncryptImageData(byte[] imageData, byte[] key, byte[] iv)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(imageData, 0, imageData.Length);
                    }

                    var encryptedData = msEncrypt.ToArray();
                    return Convert.ToBase64String(encryptedData);
                }
            }
        }

        public static byte[] DecryptImageData(byte[] encryptedData, byte[] key, byte[] iv)
        {
            byte[] decryptedData;

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (var msDecrypt = new MemoryStream(encryptedData))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var ms = new MemoryStream())
                {
                    int data;
                    while ((data = csDecrypt.ReadByte()) != -1)
                    {
                        ms.WriteByte((byte)data);
                    }

                    decryptedData = ms.ToArray();
                }
            }

            return decryptedData;
        }
    }
}

