﻿namespace TeamKyanite.SchoolObjects
{
    using System;
    using System.Linq;
    using System.Text;

    public class Teacher : Human, ICommentable
    {
        // Fields
        private Subject subject;
        // Constructors
        public Teacher(string name, string gender, Subject subject, string comment)
        {
            this.Name = name;
            this.Gender = gender;           
            this.Subject = subject;
            this.Comment = comment;
            this.Account = new Account(this);
        }

        public Teacher(string name, string gender, Subject subject) : this(name, gender, subject, null)
        {
            
        }

        public Teacher(string name, Subject subject)
            : this(name, null, subject)
        {
        }

        public Teacher(string name)
            : this(name, null)
        {
        }

        public Teacher() 
        {
        }

        // Properties
        public int TeacherId { get; set; }


        public Subject Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }

        // Methods
        public override string ToString()
        {
            string teacherString = string.Empty;

            StringBuilder sb = new StringBuilder();

            sb.Append("Teacher's Name: ").AppendFormat("{0, -20}", this.Name).
                AppendFormat(", Gender: {0}", this.Gender).AppendFormat(", Subject: {0}", this.Subject).
                Append(", Comment: ").Append(this.Comment);

            teacherString = sb.ToString();
            return teacherString;
        }
    }
}
