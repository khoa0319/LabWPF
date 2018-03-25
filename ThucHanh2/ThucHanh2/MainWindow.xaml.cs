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

namespace ThucHanh2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NhapPS nhapPS;
        private Fraction fractionFirst;
        private Fraction fractionSecond;
        private Fraction result;

        public MainWindow()
        {
            InitializeComponent();
            nhapPS = new NhapPS();
            FractionFirst = new Fraction();
            FractionSecond = new Fraction();

            //close app comppletely
            this.Closing += (handler, e) =>
            {
                this.Visibility = Visibility.Hidden;
                Application.Current.Shutdown();
            };

            btnPS1.Click += (handler, e) =>
            {
                nhapPS.tblMS.Text = "";
                nhapPS.tblTS.Text = "";
                nhapPS.ShowDialog();
                fractionFirst = nhapPS.GetFraction();
                ShowFractionFirst(fractionFirst);
            };

            btnPS2.Click += (handler, e) =>
            {
                nhapPS.tblMS.Text = "";
                nhapPS.tblTS.Text = "";
                nhapPS.ShowDialog();
                fractionSecond = nhapPS.GetFraction();
                ShowFractionSecond(fractionSecond);

            };

            btnExit.Click += (handler, e) => Close();

            btnSum.Click += (sender, e) =>
            {
                ShowResult(Fraction.Sum(fractionFirst, FractionSecond));
            };

            btnProduct.Click += (sender, e) => ShowResult(Fraction.Multiply(fractionFirst, FractionSecond));
            btnSubstract.Click += (sender, e) => ShowResult(Fraction.Subtract(fractionFirst, FractionSecond));
        }

        public Fraction FractionFirst { get => fractionFirst; set => fractionFirst = value; }
        public Fraction FractionSecond { get => fractionSecond; set => fractionSecond = value; }

        public void ShowFractionFirst(Fraction fraction)
        {
            try
            {
                tblTS1.Text = tblMS1.Text = "";
                tblTS1.Text = fraction.Numerator.ToString();
                tblMS1.Text = fraction.Denominator.ToString();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.StackTrace);
            }
        }
        public void ShowFractionSecond(Fraction fraction)
        {
            try
            {
                tblTS2.Text = tblMS2.Text = "";
                tblTS2.Text = fraction.Numerator.ToString();
                tblMS2.Text = fraction.Denominator.ToString();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.StackTrace);
            }
        }

        public void ShowResult(Fraction fraction)
        {
            fraction = Fraction.Minimize(fraction);
            tblTS3.Text = fraction.Numerator.ToString();
            tblMS3.Text = fraction.Denominator.ToString();
        }
    }
}
