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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThucHanh4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> lst;
        private Employee stored;
        public MainWindow()
        {
            InitializeComponent();
            //lst = new List<Employee>();
            lst = Employee.GetSampleData();
            dtEmployee.ItemsSource = lst;

            //create a employee
            btnCreate.Click += (sender, e) =>
            {
                Employee em = new Employee
                {
                    ID = txtID.Text,
                    Name = txtName.Text,
                    BirthDate = (DateTime)datePicker.SelectedDate,
                    Address = txtAddress.Text
                };
                lst.Add(em);
                ResetInputField();
                dtEmployee.Items.Refresh();
            };

            //remove an employee
            btnDelete.Click += (sender, e) =>
            {
                if (dtEmployee.SelectedItem == null)
                {
                    MessageBox.Show("bạn hãy chọn ô cần xóa");
                    return;
                }
                lst.Remove(lst.Find(em => em.ID == ((Employee)dtEmployee.SelectedItem).ID));
                dtEmployee.Items.Refresh();
            };

            dtEmployee.SelectionChanged += (sender, e) =>
            {
                if (dtEmployee.SelectedItem != null)
                {
                    stored = dtEmployee.SelectedItem as Employee;
                    Employee emp = dtEmployee.SelectedItem as Employee;
                    txtID.Text = emp.ID;
                    txtName.Text = emp.Name;
                    txtAddress.Text = emp.Address;
                    datePicker.SelectedDate = emp.BirthDate;
                }
            };

            //update an employee
            btnUpdate.Click += (sender, e) =>
            {
                if (dtEmployee.SelectedItem == null)
                {
                    MessageBox.Show("Hãy chọn nhân viên để cập nhật");
                    return;
                }
                stored.ID = txtID.Text;
                stored.Name = txtName.Text;
                stored.Address = txtAddress.Text;
                stored.BirthDate = (DateTime)datePicker.SelectedDate;
                dtEmployee.Items.Refresh();
            };
           
            //escape the program
            btnExit.Click += (sender, e) =>
            {
                MessageBoxResult result = MessageBox.Show("Chấp nhận thoát", "Exit program", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                    this.Close();
            };
        }

        private void ResetInputField()
        {
            txtAddress.Text = "";
            txtID.Text = "";
            txtName.Text = "";
            datePicker.DisplayDate = DateTime.Today;
        }
    }
}
