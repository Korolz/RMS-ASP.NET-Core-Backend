using System.Security.Cryptography;
using System.Text;

namespace RMS_Backend
{
    public class HashHelper
    {
        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.Default.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                string hashedString = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                return hashedString;
            }
        }
    }
}
