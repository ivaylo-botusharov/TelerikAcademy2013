﻿namespace TeamKyanite.SchoolObjects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Class used for describing the features of a single school student
    /// Implements the ICommentable interface so that optional comments could be added for every student
    /// </summary>
    public class Student : Human, ICommentable
    {
        // Fields
        private int? classNumber;
        private SchoolClass schoolclass;
        
        // Constructors
        public Student(string name, int? classNumber, string gender, int? age, string comment)
        {
            this.Name = name;
            this.ClassNumber = classNumber;
            this.Gender = gender;
            this.Comment = comment;
            this.Account = new Account(this);
            this.Age = age;
        }

        public Student(string name, int? classNumber, string gender, int? age)
            : this(name, classNumber, gender, age, null)
        {
        }

        public Student(string name, string gender, int? age)
            : this(name, null, gender, age)
        {
        }
        public Student()
        {

        }

        // Properties
        public int StudentId { get; set; }
        

        public virtual SchoolClass SchoolClass
        {
            get { return this.schoolclass; }
            set { this.schoolclass = value; }
        }

        public int? ClassNumber
        {
            get { return this.classNumber; }
            set { this.classNumber = value; }
        }

     

        // Methods
        public override string ToString()
        {
            return string.Format("Class ID: {0, -2:00}, Student Name: {1}, Gender: {2} Comment: {3}", this.ClassNumber, this.Name, this.Gender, this.Comment);
        }

    }
}
