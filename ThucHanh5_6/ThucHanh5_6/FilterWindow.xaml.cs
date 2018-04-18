using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
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
    /// Interaction logic for FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        public FilterWindow()
        {
            InitializeComponent();
            LoadDb();
            cbSearch.SelectionChanged += (sender, e) =>
            {
                using (var context = new MyContext())
                {
                    var query = from p in context.Employees
                                where p.DepartmentRoomId == cbSearch.SelectedValue.ToString()
                                select p;

                    dtgridSearch.ItemsSource = query.ToList();
                }

            };
        }
        private void LoadDb()
        {
            using (var context = new MyContext())
            {
                cbSearch.ItemsSource = context.DepartmentRooms.ToList();
                cbSearch.DisplayMemberPath = "Name";
                cbSearch.SelectedValuePath = "Id";
                cbSearch.SelectedIndex = 0;
                dtgridSearch.ItemsSource = context.Employees.ToList();
            }
        }
    }
}
