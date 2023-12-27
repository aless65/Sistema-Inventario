using System.Security.Cryptography;
using System.Text;

namespace AcademiaFS.Proyecto.Inventario.Utility
{
    public class EncriptarClave
    {
        public static byte[] GenerateSHA512Hash(string password)
        {
            // Truncate hashBytes to 36 bytes (288 bits)
            byte[] truncatedHash = Encoding.Unicode.GetBytes(password);

            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(truncatedHash);

                return hashBytes;
            }

        }

        public static string HashedString(byte[] hashBytes)
        {
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
