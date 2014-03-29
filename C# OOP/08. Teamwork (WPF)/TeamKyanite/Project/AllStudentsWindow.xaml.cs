﻿using System;
using System.Linq;
using System.Windows;
using TeamKyanite.SchoolObjects;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TeamKyanite
{
    /// <summary>
    /// Interaction logic for SchoolAllStudents.xaml
    /// </summary>
    public partial class AllStudentsWindow : Window
    {
        private SchoolDatabaseContext context = new SchoolDatabaseContext();
        public AllStudentsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource studentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentViewSource")));
            context.Students.Load();
            studentViewSource.Source = context.Students.Local;
         }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var student in context.Students.Local.ToList())
            {
                if (student.QueuedForDeletion == true)
                {
                    context.Students.Remove(student);
                }
            }

            context.SaveChanges();            
            this.studentDataGrid.Items.Refresh();
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this.context.Dispose();
        }
    }
}