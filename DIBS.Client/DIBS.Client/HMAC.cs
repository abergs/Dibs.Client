// This is in response to the question from Stackoverflow at:
// http://stackoverflow.com/questions/12185122/calculating-hmacsha256-using-c-sharp-to-match-payment-provider-example
//
// By: Jaxrtech

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace DIBS.Client
{
    public class HMACGenerator
    {
        #region Hash Hex Functions

        public static string HashHMACHex(string keyHex, string message)
        {
            byte[] hash = HashHMAC(HexDecode(keyHex), StringEncode(message));
            return HashEncode(hash);
        }

        private static string HashSHAHex(string innerKeyHex, string outerKeyHex, string message)
        {
            byte[] hash = HashSHA(HexDecode(innerKeyHex), HexDecode(outerKeyHex), StringEncode(message));
            return HashEncode(hash);
        }

        #endregion

        #region Hash Functions

        private static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }

        private static byte[] HashSHA(byte[] innerKey, byte[] outerKey, byte[] message)
        {
            var hash = new SHA256Managed();

            // Compute the hash for the inner data first
            var innerData = new byte[innerKey.Length + message.Length];
            Buffer.BlockCopy(innerKey, 0, innerData, 0, innerKey.Length);
            Buffer.BlockCopy(message, 0, innerData, innerKey.Length, message.Length);
            byte[] innerHash = hash.ComputeHash(innerData);

            // Compute the entire hash
            var data = new byte[outerKey.Length + innerHash.Length];
            Buffer.BlockCopy(outerKey, 0, data, 0, outerKey.Length);
            Buffer.BlockCopy(innerHash, 0, data, outerKey.Length, innerHash.Length);
            byte[] result = hash.ComputeHash(data);

            return result;
        }

        #endregion

        #region Encoding Helpers

        private static byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        private static byte[] HexDecode(string hex)
        {
            var bytes = new byte[hex.Length/2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byte.Parse(hex.Substring(i*2, 2), NumberStyles.HexNumber);
            }
            return bytes;
        }

        #endregion
    }
}