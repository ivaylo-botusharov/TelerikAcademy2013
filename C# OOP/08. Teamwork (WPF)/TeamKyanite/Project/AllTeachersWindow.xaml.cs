﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TeamKyanite.SchoolObjects;

namespace TeamKyanite
{
    /// <summary>
    /// Interaction logic for AllTeachersWindow.xaml
    /// </summary>
    public partial class AllTeachersWindow : Window
    {
        private SchoolDatabaseContext context = new SchoolDatabaseContext();
        public AllTeachersWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource teacherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("TeacherViewSource")));
            context.Teachers.Load();
            teacherViewSource.Source = context.Teachers.Local;

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
            this.TeacherDataGrid.Items.Refresh();
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
