﻿using System;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Lab4
{
    public class PasswordEncrypter
    {
        public static string HashByMD5(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Util.ToStringByteArray(hash);
        }

        public static string HashBySHA256(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Util.ToStringByteArray(hash);
            }
        }

        public static string HashByArgon2(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 1;
            argon2.Iterations = 1;
            argon2.MemorySize = 1024 * 4;

            return Util.ToStringByteArray(argon2.GetBytes(16));
        }
    }
}