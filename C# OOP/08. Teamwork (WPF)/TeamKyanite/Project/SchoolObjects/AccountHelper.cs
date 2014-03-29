﻿using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;

namespace TeamKyanite.SchoolObjects
{
    public static class AccountHelper
    {
        //generates a string that consists of two lowercase latin letters + four digits
        public static string GenerateUniqueUsername()
        {
            Random rand = new Random();
            var name = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                name.Append((char)('a' + rand.Next(0, 26)));
            }
            name.Append(rand.Next(0, 10000).ToString().PadLeft(4, '0'));
            string nameString = name.ToString();
            using (SchoolDatabaseContext context = new SchoolDatabaseContext())
            {
                //Implement thread lock
                //lock ()
                //{
                if (context.Accounts.Any(t => t.Username == nameString))
                {
                    AccountHelper.GenerateUniqueUsername();
                }
                //}
            }
            return name.ToString();
        }
        //Encrypts a string using SHA2 algorithm
        public static string EncryptPassword(string text)
        {
            var stringBytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed shaManager = new SHA256Managed();
            var hashArray = shaManager.ComputeHash(stringBytes);
            var hashString = new StringBuilder();
            foreach (byte x in hashArray)
            {
                hashString.AppendFormat("{0:x2}", x);
            }
            return hashString.ToString();
        }
        //Checks if there is a user with the given name and password
        public static bool IsLoginDataValid(string enteredUsername, string enteredPasswod)
        {
            using (var context = new SchoolDatabaseContext())
            {
                if (!context.Accounts.Any(t => t.Username == enteredUsername))
                {
                    return false;
                }
                Account acc = context.Accounts.First(t => t.Username == enteredUsername);

                Type accType = acc.GetType().BaseType;
                var propInfo = accType.GetProperty("Password", BindingFlags.Instance | BindingFlags.NonPublic);
                var passwordInDatabse = propInfo.GetValue(acc, null);

                string hashedEnteredPassword = AccountHelper.EncryptPassword(enteredPasswod);
                if (hashedEnteredPassword == passwordInDatabse.ToString())
                {
                    return true;
                }

            }
            return false;
        }
    }
}
