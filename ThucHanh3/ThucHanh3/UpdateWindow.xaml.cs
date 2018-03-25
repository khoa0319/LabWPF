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

namespace ThucHanh3
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private Examinee examinee;
        //private Examinee subExaminee;
        public UpdateWindow()
        {
            InitializeComponent();

            //load examinee data
            this.Loaded += (sender, e) =>
            {
                GetBinding();
            };

            //accept handler
            butChapNhan.Click += (sender, e) =>
            {
                this.Close();
            };

            //escape handler
            butThoat.Click += (sender, e) =>
            {
                this.Close();
            };
        }

        public Examinee Examinee { get => examinee; set => examinee = value; }

        private void GetBinding()
        {
            //binding ID
            
            Binding bindingID = new Binding
            {
                Source = examinee,
                Path = new PropertyPath("ID"),
                Mode = BindingMode.TwoWay
            };
            txtSoBD.SetBinding(TextBox.TextProperty, bindingID);

            //binding Name
            Binding bindingName = new Binding
            {
                Source = examinee,
                Path = new PropertyPath("Name"),
                Mode = BindingMode.TwoWay
            };
            txtHoTen.SetBinding(TextBox.TextProperty, bindingName);

            //Binding sub1
            Binding bindingSub1 = new Binding
            {
                Source = examinee,
                Path = new PropertyPath("Subject1"),
                Mode = BindingMode.TwoWay
            };
            txtDiemB1.SetBinding(TextBox.TextProperty, bindingSub1);

            //binding sub2
            Binding bindingSub2 = new Binding
            {
                Source = examinee,
                Path = new PropertyPath("Subject2"),
                Mode = BindingMode.TwoWay
            };
            txtDiemB2.SetBinding(TextBox.TextProperty, bindingSub2);

            //binding sub3
            Binding bindingSub3 = new Binding
            {
                Source = examinee,
                Path = new PropertyPath("Subject3"),
                Mode = BindingMode.TwoWay
            };
            txtDiemB3.SetBinding(TextBox.TextProperty, bindingSub3);

            //Biding additional properties
            if (examinee is ProExaminee)
            {
                Binding bindingSub4 = new Binding
                {
                    Source = examinee as ProExaminee,
                    Path = new PropertyPath("English"),
                    Mode = BindingMode.TwoWay
                };
                txtDiemTAnh.SetBinding(TextBox.TextProperty, bindingSub4);
            }
            if (examinee is CupExaminee)
            {
                Binding bindingSub4 = new Binding
                {
                    Source = examinee as CupExaminee,
                    Path = new PropertyPath("Database"),
                    Mode = BindingMode.TwoWay
                };
                txtDiemCSDL.SetBinding(TextBox.TextProperty, bindingSub4);
            }

        }
    }
}
