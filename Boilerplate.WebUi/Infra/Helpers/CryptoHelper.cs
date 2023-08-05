using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Boilerplate.WebUi.Infra.Helpers
{
    /// <summary>
    /// Classe auxiliar para o processo de criptografia.
    /// </summary>
    public sealed class CryptoHelper
    {
        /// <summary>
        /// Possíveis tipos de criptografia aplicados.
        /// </summary>
        public enum CryptoType { AES256 }

        /// <summary>
        /// Obtém o algoritmo de criptografia AES com 256 bits.
        /// </summary>
        /// <param name="chave">chave de criptografia.</param>
        /// <returns>objeto responsável pela criptografia.</returns>
        private static AesManaged GetAesManaged(string chave)
        {
            var aes = new AesManaged();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = new byte[] { 66, 114, 64, 122, 49, 108, 68, 101, 35, 116, 65, 108, 80, 103, 84, 48 };
            aes.Key = Encoding.ASCII.GetBytes(chave.Length > 32 ? chave.Substring(0, 32) : chave.PadLeft(32, '0'));
            return aes;
        }

        /// <summary>
        /// Realiza a criptografia dos dados recebidos com base na chave e algoritmo informado.
        /// </summary>
        /// <param name="chave">chave de criptografia.</param>
        /// <param name="dadosACriptografar">dados para criptografar.</param>
        /// <param name="tipo">tipo de criptografia que será aplicado.</param>
        /// <returns>dados criptografados.</returns>
        public static string Criptografar(string chave, string dadosACriptografar, CryptoType tipo = CryptoType.AES256)
        {
            string dadosCriptografado = null;

            using (SymmetricAlgorithm aes = GetAesManaged(chave))
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(dadosACriptografar);
                        }
                        dadosCriptografado = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }

            }
            return dadosCriptografado;
        }

        /// <summary>
        /// Realiza a decriptografia dos dados recebidos com base na chave e algoritmo informados.
        /// </summary>
        /// <param name="chave">chave de criptografia.</param>
        /// <param name="dadosCriptografado">dados a serem decriptografados.</param>
        /// <param name="tipo">tipo de criptografia que será aplicado.</param>
        /// <returns>dados decriptografados.</returns>
        public static string Decriptografar(string chave, string dadosCriptografado, CryptoType tipo = CryptoType.AES256)
        {
            string dadosDecriptografado = null;

            using (SymmetricAlgorithm aes = GetAesManaged(chave))
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(dadosCriptografado)))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            dadosDecriptografado = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return dadosDecriptografado;
        }
    }
}
