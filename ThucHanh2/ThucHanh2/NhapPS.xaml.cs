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

namespace ThucHanh2
{
    /// <summary>
    /// Interaction logic for NhapPS.xaml
    /// </summary>
    public partial class NhapPS : Window
    {
        private Fraction fraction;

        public Fraction Fraction { get => fraction; set => fraction = value; }

        public NhapPS()
        {
            InitializeComponent();
            Fraction = new Fraction();
            this.Closing += (handler, e) =>
            {
                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            };
            tblTS.LostFocus += (sender, e) =>
            {
                if (!int.TryParse(tblTS.Text, out int result))
                {
                    MessageBox.Show("you must input an integer");
                    tblTS.Text = "0";
                    if (!tblTS.IsFocused)
                    {
                        tblTS.Focus();
                    }
                }
            };
            tblMS.LostFocus += (sender, e) =>
            {
                if (!int.TryParse(tblMS.Text, out int result) || tblMS.Text.Equals("0"))
                {
                    MessageBox.Show("you must input an integer and is not zero");
                    tblMS.Text = "1";
                    if (!tblMS.IsFocused)
                    {
                        tblMS.Focus();
                    }
                }
            };
        }

        private void BtnEscape_Click(object sender, RoutedEventArgs e)
        {            
            this.Visibility = Visibility.Hidden;
            Fraction = new Fraction();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {            
            Fraction.Numerator = int.Parse(tblTS.Text);
            Fraction.Denominator = int.Parse(tblMS.Text);
            this.Visibility = Visibility.Hidden;
        }

        internal Fraction GetFraction() => new Fraction(fraction.Numerator, fraction.Denominator);
    }
}
