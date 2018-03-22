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
    /// Interaction logic for InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        private Examinee examinee;
        public InsertWindow()
        {            
            InitializeComponent();
            //nhap Chuyen
            radChuyen.Click += (sender, e) =>
            {
                if ((bool)radChuyen.IsChecked)
                {
                    txtDiemCSDL.Text = "";
                    txtDiemTAnh.IsEnabled = true;
                    txtDiemCSDL.IsEnabled = false;
                }
            };
            //Nhap Sieu Cup
            radSieuCup.Click += (sender, e) =>
            {
                if ((bool)radSieuCup.IsEnabled)
                {
                    txtDiemTAnh.Text = "";
                    txtDiemTAnh.IsEnabled = false;
                    txtDiemCSDL.IsEnabled = true;
                }
            };
            //chon nhap sieu cup hay chuyen
            this.Loaded += (sender, e) =>
            {
                if ((bool)radChuyen.IsChecked)
                {
                    txtDiemTAnh.IsEnabled = true;
                    txtDiemCSDL.IsEnabled = false;
                }
                else
                {
                    txtDiemTAnh.IsEnabled = false;
                    txtDiemCSDL.IsEnabled = true;
                }
            };

            //create object (Examinee) data to parse to mainWindow
            butChapNhan.Click += (sender, e) =>
            {
                int id = int.Parse(txtSoBD.Text);
                string name = txtHoTen.Text;
                double diem1 = double.Parse(txtDiemB1.Text);
                double diem2 = double.Parse(txtDiemB2.Text);
                double diem3 = double.Parse(txtDiemB3.Text);
                double diem4;
                if ((bool)radChuyen.IsChecked)
                {
                    diem4 = double.Parse(txtDiemTAnh.Text);
                    Examinee = new ProExaminee(id, name, diem1, diem2, diem3, diem4);
                }
                else
                {
                    diem4 = double.Parse(txtDiemCSDL.Text);
                    Examinee = new CupExaminee(id, name, diem1, diem2, diem3, diem4);
                }
                this.Visibility = Visibility.Hidden;
            };

        }

        public Examinee Examinee { get => examinee; set => examinee = value; }

    }
}
