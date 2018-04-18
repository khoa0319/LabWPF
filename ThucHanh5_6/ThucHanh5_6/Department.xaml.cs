using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ThucHanh5_6
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class Department : Window
    {
        private DepartmentRoom dr;
        public Department()
        {
            InitializeComponent();
            using (var context = new MyContext())
            {
                gridDepartment.ItemsSource = context.DepartmentRooms.ToList();
            }
            //add department room
            btnAdd.Click += (sender, e) =>
            {
                using (var context = new MyContext())
                {
                    var room = new DepartmentRoom
                    {
                        Id = txtDId.Text,
                        Name = txtDName.Text,
                        Employees = new List<Employee>()
                    };
                    context.DepartmentRooms.Add(room);
                    context.SaveChanges();
                    gridDepartment.ItemsSource = context.DepartmentRooms.ToList();
                }
            };
            //delete a room
            btnRemove.Click += (sender, e) =>
            {
                if (IsNullSelected())
                    return;
                using (var context = new MyContext())
                {
                    context.DepartmentRooms.Remove(context.DepartmentRooms.Find(((DepartmentRoom)gridDepartment.SelectedItem).Id));
                    context.SaveChanges();
                    gridDepartment.ItemsSource = context.DepartmentRooms.ToList();
                }
            };
            gridDepartment.SelectionChanged += (sender, e) =>
            {
                if (gridDepartment.SelectedItem != null)
                {
                    dr = gridDepartment.SelectedItem as DepartmentRoom;
                    LoadtoTxt(dr);
                }
            };

            btnUpdate.Click += (sender, e) =>
            {
                if (IsNullSelected())
                    return;
                using (var context = new MyContext())
                {
                    var entity = context.DepartmentRooms.SingleOrDefault(t => t.Id == dr.Id);
                    if (!(entity == null))
                    {
                        entity.Name = txtDName.Text;
                        entity.Id = txtDId.Text;
                    }
                    context.SaveChanges();
                    gridDepartment.ItemsSource = context.DepartmentRooms.ToList();
                }
                gridDepartment.SelectedItem = null;
                ResetTxt();
            };

            btnExit.Click += (sender, e) =>
            {

                Close();
            };
        }

        private bool IsNullSelected()
        {
            if (gridDepartment.SelectedItem == null)
            {
                MessageBox.Show("Please Choose a Department to Remove", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            }
            return false;
        }
        private void LoadtoTxt(DepartmentRoom departmentRoom)
        {
            txtDId.Text = departmentRoom.Id;
            txtDName.Text = departmentRoom.Name;
        }
        private void ResetTxt()
        {
            txtDId.Text = "";
            txtDName.Text = "";
        }
    }
}
