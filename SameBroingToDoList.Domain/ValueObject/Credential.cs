using SameBroingToDoList.Shared.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Domain.ValueObject
{
    public record Credential
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Guid VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public Guid PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public Credential(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        public Credential(byte[] passwordHash, byte[] passwordSalt, Guid verificationToken,
            DateTime? verifiedAt, Guid passwordResetToken, DateTime? resetTokenExpires)
            : this(passwordHash, passwordSalt)
        {
            VerificationToken = verificationToken;
            VerifiedAt = verifiedAt;
            PasswordResetToken = passwordResetToken;
            ResetTokenExpires = resetTokenExpires;
        }
        public static Result<Credential> Create(Password password)
        {
            CreatePasswordHash(password.Value, out byte[] passwordHash, out byte[] passwordSalt);

            return new Credential(passwordHash, passwordSalt)
            {
                VerificationToken = Guid.NewGuid(),
            };
        }

        public bool ValidatePassword(string password)
        {
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(PasswordHash);
            }
        }

        private static void CreatePasswordHash(string password,
            out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
