﻿using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Data.Entity.ModelConfiguration;

namespace TeamKyanite.SchoolObjects
{
    public class Account
    {
        [Key()]
        public int AccountId { get; set; }
        private Human holder;
        private string username;
        private string Password { get; set; }
        private bool isPasswordChanged;

        public Account(Human holder): this()
        {
            this.Holder = holder;
        }
        public Account()
        { 
            this.Username = AccountHelper.GenerateUniqueUsername();
            this.Password = AccountHelper.EncryptPassword(this.Username);
            this.IsPasswordChanged = false;
        }

        public virtual Human Holder
        {
            get
            {
                return this.holder;
            }
            private set
            {
                this.holder = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                this.username = value;
            }
        }
        public bool IsPasswordChanged
        {
            get
            {
                return this.isPasswordChanged;
            }
            private set
            {
                this.isPasswordChanged = value;
            }
        }
        private void ChangePassword(string newPassword)
        {
            this.Password = AccountHelper.EncryptPassword(newPassword);
            this.IsPasswordChanged = true;
        }
        public bool AreCredentialsCorrect(string user, string pass)
        {
            if (this.Username == user)
            {
                string encryptedPass = AccountHelper.EncryptPassword(pass);
                if (this.Password == encryptedPass)
                {
                    return true;
                }
            }
            return false;
        }
        public class AccountConfiguration : EntityTypeConfiguration<Account>
        {
            public AccountConfiguration()
            {
                Property(p => p.Password);
            }
        }
    }
}
