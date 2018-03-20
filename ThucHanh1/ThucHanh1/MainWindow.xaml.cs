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

namespace ThucHanh1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnBP.Click += (sender, args) =>
            {
                tblXuat.Text = ComputeMu(tblNhap.Text, 2).ToString();
            };
            btnLP.Click += (sender, args) =>
            {
                tblXuat.Text = ComputeMu(tblNhap.Text, 3).ToString();
            };
            btnGT.Click += (sender, args) =>
            {
                var result = ComputeGT(Convert.ToDouble(tblNhap.Text));
                if (result > Double.MaxValue)
                {
                    MessageBox.Show("Số quá lớn không tính được", "warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tblXuat.Text = "";
                }
                else
                {
                    tblXuat.Text = ComputeGT(Convert.ToDouble(tblNhap.Text)).ToString();
                }
            };
            btnExit.Click += (sender, e) =>
            {
                MessageBoxResult result = MessageBox.Show("bạn muốn thoát khỏi chương trình không", "Thoát", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    this.Close();
            };

        }
        private double ComputeMu(string toParse, int number)
        {

            Double.TryParse(toParse, out double tmp);
            double result = 1;
            for (int i = 0; i < number; i++)
            {
                result *= tmp;
            }
            return result;
        }
        private double ComputeGT(double number)
        {
            double result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }


        private void TblNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Double.TryParse(tblNhap.Text, out double tmp))
            {
                MessageBoxResult result = MessageBox.Show("Phải Nhập số", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                if (result == MessageBoxResult.OK)
                    tblNhap.Text = "";
            }
        }

        private void tblNhap_TextInput(object sender, TextCompositionEventArgs e)
        {
            return;
        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Enter)
            {
                Double.TryParse(tblNhap.Text, out double tmp);
                tblXuat.Text = (tmp * tmp).ToString();
            }

        }
    }
}
