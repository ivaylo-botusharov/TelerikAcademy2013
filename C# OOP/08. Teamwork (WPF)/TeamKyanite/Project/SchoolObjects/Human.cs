﻿namespace TeamKyanite.SchoolObjects
{
    using System;

    public abstract class Human : ICommentable, IUser
    {
        // Fields
        
        private string name;
        private string gender;
        private int? age;
        private string comment;
        private Account account;
        private bool queuedForDeletion = false;

        // Constructors
        public Human(string name, string gender, int? age, string comment)
        {
            this.Name = name;
            this.Gender = gender;
            this.Comment = comment;
            this.Age = age;
        }

        public Human(string name) : this(name, null, null, null)
        {            
        }

        public Human() : this(null, null, null, null)
        {
        }
        
        public virtual Account Account
        {
            get
            {
                return this.account;
            }
            set
            {
                this.account = value;
            }
        }

        // Properties
        public int Id { get; set; }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public int? Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
           public bool QueuedForDeletion
        {
            get { return this.queuedForDeletion; }
            set { this.queuedForDeletion = value; }
        }
    }
}
