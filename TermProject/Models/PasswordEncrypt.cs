using System.Text;
using System.Security.Cryptography;

namespace TermProject.Models
{
    public class PasswordEncrypt
    {
        public static string EncryptPass(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);

            }
        }


        //public static bool VerifyPass(string password, string hash)
        //{
        //   // string typedPassword = EncryptPass(password);
        //    return EncryptPass(password) == hash;
        //}
    }
}
