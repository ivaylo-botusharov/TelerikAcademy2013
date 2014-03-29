﻿using System;
using System.Linq;
using System.Windows;
using TeamKyanite.SchoolObjects;
using System.Data.Entity;

namespace TeamKyanite
{
    /// <summary>
    /// Interaction logic for SchoolClassesWindow.xaml
    /// </summary>
    public partial class SchoolClassesWindow : Window
    {
        private SchoolDatabaseContext context = new SchoolDatabaseContext();
        public SchoolClassesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource schoolClassViewSource = 
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("schoolClassViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // schoolClassViewSource.Source = [generic data source]

            context.SchoolClasses.Load();
            schoolClassViewSource.Source = context.SchoolClasses.Local;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var student in context.Students.ToList())
            {
                if (student.SchoolClass.QueuedForDeletion == true)
                {
                    context.Students.Remove(student);
                }
            }

            foreach (var schoolClass in context.SchoolClasses.Local.ToList())
            {
                if (schoolClass.QueuedForDeletion == true)
                {
                    context.SchoolClasses.Remove(schoolClass);
                }
            }
            context.SaveChanges();
            this.schoolClassDataGrid.Items.Refresh();
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
