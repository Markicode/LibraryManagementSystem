using Database;
using Models;
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
        private const byte VersionId1 = 0x01;
        private const byte DefaultVersionId = VersionId1;
        private sealed record PasswordHasherVersion(HashAlgorithmName Algorithm, int SaltSize, int KeySize, int Iterations);
        private readonly Dictionary<byte, PasswordHasherVersion> versions = new()
        {
            [VersionId1] = new PasswordHasherVersion(HashAlgorithmName.SHA256, SaltSize: 256 / 8, KeySize: 256 / 8, Iterations: 600000),
        };

        public delegate void LoggedInDelegate();
        public event LoggedInDelegate LoggedIn;

        public AuthController() 
        {
            this.defaultUser = new User("default@lms.nl", "12345678", "default");
        }

        public AuthenticationResult AuthenticateUser(string email, string password)
        {
            if (defaultUser.FindUser(email) != null)
            {
                user = defaultUser.FindUser(email);
                if(user.role != "employee")
                {
                    return AuthenticationResult.Failed;
                }
                if (VerifyHashedPassword(user.password, password) == PasswordVerificationResult.Success)
                {
                    if (this.LoggedIn != null)
                    {
                        this.LoggedIn();
                    }
                    return AuthenticationResult.Success;
                }
                return AuthenticationResult.Failed;
            }
            return AuthenticationResult.NotFound;

        }

        public void AddUser(string email, string password)
        {
            User newUser = new User(email, HashPassword(password), "user");
            newUser.Add(newUser);
        }

        public User GetPersonInfo(string email)
        {
            return user = defaultUser.FindUser(email);
        }
            

        public string HashPassword(string password)
        {
            ArgumentNullException.ThrowIfNull(password);
            var version = versions[DefaultVersionId];
            var hashedPasswordByteCount = 1 + version.SaltSize + version.KeySize;
            Span<byte> hashedPasswordBytes = stackalloc byte[hashedPasswordByteCount];

            var saltBytes = hashedPasswordBytes.Slice(start: 1, length: version.SaltSize);
            var keyBytes = hashedPasswordBytes.Slice(start: 1 + version.SaltSize, length: version.KeySize);

            hashedPasswordBytes[0] = DefaultVersionId;
            RandomNumberGenerator.Fill(saltBytes);
            Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, keyBytes, version.Iterations, version.Algorithm);

            return Convert.ToBase64String(hashedPasswordBytes);

        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            ArgumentNullException.ThrowIfNull(hashedPassword);
            ArgumentNullException.ThrowIfNull(providedPassword);

            var hashedPasswordByteCount = ComputeDecodedBase64ByteCount(hashedPassword);
            Span<byte> hashedPasswordBytes = stackalloc byte[hashedPasswordByteCount];

            if (!Convert.TryFromBase64String(hashedPassword, hashedPasswordBytes, out _))
            {
                // This shouldn't happen unless there's a mistake in how we compute the decoded Base64 byte count.
                return PasswordVerificationResult.Failed;
            }

            if (hashedPasswordBytes.Length == 0)
            {
                return PasswordVerificationResult.Failed;
            }

            var versionId = hashedPasswordBytes[0];
            if (!versions.TryGetValue(versionId, out var version))
            {
                // This can only happen if a developer removes a version from the dictionary,
                // or if someone was able to tamper with the hashed password.
                return PasswordVerificationResult.Failed;
            }

            var expectedHashedPasswordLength = 1 + version.SaltSize + version.KeySize;
            if (hashedPasswordBytes.Length != expectedHashedPasswordLength)
            {
                // The hashed password length doesn't match the expected length for the given version.
                // This can only happen if a developer modified an existing used version or if the hashed password was tampered with.
                return PasswordVerificationResult.Failed;
            }

            var saltBytes = hashedPasswordBytes.Slice(start: 1, length: version.SaltSize);
            var expectedKeyBytes = hashedPasswordBytes.Slice(start: 1 + version.SaltSize, length: version.KeySize);

            // Same stackalloc size considerations as above.
            Span<byte> actualKeyBytes = stackalloc byte[version.KeySize];
            Rfc2898DeriveBytes.Pbkdf2(providedPassword, saltBytes, actualKeyBytes, version.Iterations, version.Algorithm);

            // This method prevents leaking timing information when comparing the two byte spans.
            if (!CryptographicOperations.FixedTimeEquals(expectedKeyBytes, actualKeyBytes))
            {
                return PasswordVerificationResult.Failed;
            }

            // It's the responsibility of the caller to rehash the password if needed.
            return versionId != DefaultVersionId
                ? PasswordVerificationResult.SuccessRehashNeeded
                : PasswordVerificationResult.Success;
        }

        private int ComputeDecodedBase64ByteCount(string base64Str)
        {
            // Base64 encodes three bytes by four characters, and there can be up to two padding characters.
            var characterCount = base64Str.Length;
            var paddingCount = 0;

            if (characterCount > 0)
            {
                if (base64Str[characterCount - 1] == '=')
                {
                    paddingCount++;

                    if (characterCount > 1 && base64Str[characterCount - 2] == '=')
                    {
                        paddingCount++;
                    }
                }
            }

            return (characterCount * 3 / 4) - paddingCount;
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
