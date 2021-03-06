﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThucHanh5_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee employee;
        private Department department;
        private FilterWindow fwd;
        public MainWindow()
        {
            InitializeComponent();
            //get employees in the database
            //for the Employee
            LoadDatabase();

            //add employee
            btnAdd.Click += (sender, e) =>
           {
               using (var myContext = new MyContext())
               {
                   var n = new Employee
                   {
                       Id = int.Parse(txtId.Text),
                       Name = txtName.Text,
                       BirthDate = dtpDate.SelectedDate ?? DateTime.Now,
                       Address = txtAddress.Text,
                       DepartmentRoomId = cbDepartment.SelectedValue as string
                       
                   };
                   myContext.Employees.Add(n);
                   myContext.SaveChanges();
                   gridNv.ItemsSource = myContext.Employees.ToList();
               };
           };

            //Delete an employee
            btnDelete.Click += (sender, e) =>
            {
                if (IsNullSelected())
                    return;
                using (var context = new MyContext())
                {
                    context.Employees.Remove(context.Employees.Find(((Employee)gridNv.SelectedItem).Id));
                    context.SaveChanges();
                    gridNv.ItemsSource = context.Employees.ToList();
                }
            };
            //check the selected employee in the grid
            gridNv.SelectionChanged += (sender, e) =>
            {
                if (gridNv.SelectedItem != null)
                {
                    employee = gridNv.SelectedItem as Employee;
                    LoadToTxt(employee);
                }
            };
            //update an employee
            btnUpdate.Click += (sender, e) =>
            {
                if (IsNullSelected())
                    return;
                using (var context = new MyContext())
                {
                    var entity = context.Employees.SingleOrDefault(t => t.Id == employee.Id);
                    if (!(entity == null))
                    {
                        entity.Name = txtName.Text;
                        entity.Address = txtAddress.Text;
                        entity.BirthDate = dtpDate.SelectedDate;
                    }
                    context.SaveChanges();
                    gridNv.ItemsSource = context.Employees.ToList();
                }
                gridNv.SelectedItem = null;
                ResetTxt();
            };
            //for the Department
            btnAddDe.Click += (sender, e) =>
            {
                department = new Department();
                department.ShowDialog();
                using (var context = new MyContext())
                {
                    cbDepartment.ItemsSource = context.DepartmentRooms.ToList();
                    cbDepartment.DisplayMemberPath = "Name";
                    cbDepartment.SelectedValuePath = "Id";
                    cbDepartment.SelectedIndex = 0;
                }
            };

            //Exit window
            btnExit.Click += (sender, e) =>
            {
                this.Close();
            };
            //filter button
            btnFilter.Click += (sender, e) =>
            {
                fwd = new FilterWindow();
                fwd.ShowDialog();
            };
        }
        private void LoadDatabase()
        {
            using (var context = new MyContext())
            {
                gridNv.ItemsSource = context.Employees.ToList();
                cbDepartment.ItemsSource = context.DepartmentRooms.ToList();
                cbDepartment.DisplayMemberPath = "Name";
                cbDepartment.SelectedValuePath = "Id";
                cbDepartment.SelectedIndex = 0;
            }
        }
        private void LoadToTxt(Employee e)
        {
            txtId.Text = e.Id.ToString();
            txtName.Text = e.Name;
            dtpDate.SelectedDate = e.BirthDate;
            txtAddress.Text = e.Address;
        }
        private bool IsNullSelected()
        {
            if (gridNv.SelectedItem == null)
            {
                MessageBox.Show("Please Choose Employee to Remove", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            }
            return false;
        }
        private void ResetTxt()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            dtpDate.SelectedDate = DateTime.Now;
        }

        
    }
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DepartmentRoom dr = value as DepartmentRoom;
            return dr == null ? "" : dr.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
