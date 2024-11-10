using LibraryDatabase;
using LibraryModels;
using MySqlX.XDevAPI;
using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System.Security.Cryptography;

namespace Controllers
{
    public class AuthController
    {
        private User defaultUser;
        public User? user;

        public AuthController() 
        {
            this.defaultUser = new User(-1, "default@lms.nl", "12345678", "default");
        }

        public AuthenticationResult AuthenticateUser(string email, string password)
        {
            if (defaultUser.FindUser(email) != null)
            {
                user = defaultUser.FindUser(email);

                if (VerifyHashedPassword(user.password, password) == PasswordVerificationResult.Success)
                {
                    return AuthenticationResult.Success;
                }
                return AuthenticationResult.Failed;
            }
            return AuthenticationResult.NotFound;

        }

        /*public static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }*/
        public string HashPassword(string password)
        {
            // TODO
            return "";
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            // TODO
            if (hashedPassword == providedPassword)
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;

        }

        public enum PasswordVerificationResult
        {
            Failed = 0,
            Success = 1,
            SuccessRehashNeeded = 2
        }

        public enum AuthenticationResult
        {
            Failed = 0,
            Success = 1,
            NotFound = 2
        }



    }
}
