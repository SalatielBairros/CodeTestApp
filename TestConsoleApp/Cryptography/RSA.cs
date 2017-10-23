
using System;
using System.Security.Cryptography;
using System.Text;

namespace CodeTestApp.Cryptography
{
    internal class RSA
    {
        private static UTF8Encoding ByteConverter => new UTF8Encoding();

        private static byte[] RSAOperationExecute(byte[] data, RSAParameters keyInfo, RSAOperation op, bool padding = false)
        {
            try
            {
                byte[] returnData;

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    //Necessário para incluir as informações de chave (pública para encriptação e privada para decriptação).
                    rsa.ImportParameters(keyInfo);
                    returnData = op == RSAOperation.Encrypt ? rsa.Encrypt(data, padding) : rsa.Decrypt(data, padding);
                }
                return returnData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        internal static byte[] Encrypt(byte[] data, RSAParameters keyInfo, bool padding = false)
            => RSAOperationExecute(data, keyInfo, RSAOperation.Encrypt, padding);

        internal static byte[] Decrypt(byte[] data, RSAParameters keyInfo, bool padding = false)
            => RSAOperationExecute(data, keyInfo, RSAOperation.Decrypt, padding);

        internal static byte[] Encrypt(string data, RSAParameters keyInfo, bool padding = false)
            => RSAOperationExecute(ByteConverter.GetBytes(data), keyInfo, RSAOperation.Encrypt, padding);

        internal static byte[] Decrypt(string data, RSAParameters keyInfo, bool padding = false)
            => RSAOperationExecute(ByteConverter.GetBytes(data), keyInfo, RSAOperation.Decrypt, padding);

        internal static void Execute(string dataToConvert)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                var publicKey = rsa.ExportParameters(false);
                var encryptedData = Encrypt(dataToConvert, publicKey);

                var privateKey = rsa.ExportParameters(true);
                var decryptedData = Decrypt(encryptedData, privateKey);

                Console.WriteLine("Texto Original:");
                Console.WriteLine(dataToConvert);
                Console.WriteLine();
                Console.WriteLine("Texto Criptografado:");
                Console.WriteLine(Encoding.Default.GetString(encryptedData));
                Console.WriteLine();
                Console.WriteLine("Texto Criptografado com hash:");
                Console.WriteLine(CustomCryp.CreateHash(encryptedData));
                Console.WriteLine();
                Console.WriteLine("Texto Descriptografado:");
                Console.WriteLine(ByteConverter.GetString(decryptedData));
                Console.WriteLine();
            }
        }
    }

    internal enum RSAOperation
    {
        Encrypt,
        Decrypt
    }
}
