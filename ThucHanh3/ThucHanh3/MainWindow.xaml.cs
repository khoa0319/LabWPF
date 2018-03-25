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

namespace ThucHanh3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ProExaminee> proExaminees;
        private List<CupExaminee> cupExaminees;
        private InsertWindow windowInput;
        private UpdateWindow windowUpdate;
        public MainWindow()
        {
            InitializeComponent();
            proExaminees = ProExaminee.Getdata();
            cupExaminees = new List<CupExaminee>();

            dataGridPE.ItemsSource = proExaminees; 
            datagridCE.ItemsSource = cupExaminees;

            windowInput = new InsertWindow(); // create InsertWindow           
            //parse data into datagrid
            btnCreate.Click += (sender, e) =>
            {
                windowInput.ShowDialog();
                if (windowInput.Examinee is ProExaminee)
                {
                    ProExaminee pro = windowInput.Examinee as ProExaminee;

                    proExaminees.Add(pro);

                    //refresh value
                    dataGridPE.Items.Refresh();
                }
                else
                {
                    CupExaminee cup = windowInput.Examinee as CupExaminee;
                    cupExaminees.Add(cup);
                    datagridCE.Items.Refresh();
                }
            };

            //close application
            btnExit.Click += (sender, e) =>
            {
                this.Visibility = Visibility.Hidden;
                Application.Current.Shutdown();
            };

            btnUpdate.Click += (sender, e) =>
            {
                if (IsCheckedDataGrid())
                {
                    windowUpdate = new UpdateWindow();
                    if (dataGridPE.SelectedItem != null && datagridCE.SelectedItem == null)
                    {
                        windowUpdate.Examinee = dataGridPE.SelectedItem as ProExaminee;
                        windowUpdate.radChuyen.IsChecked = true;
                        windowUpdate.radSieuCup.IsEnabled = false;
                        windowUpdate.txtDiemCSDL.IsEnabled = false;
                        windowUpdate.ShowDialog();
                    }
                    if (datagridCE.SelectedItem != null && dataGridPE.SelectedItem == null)
                    {
                        windowUpdate.Examinee = datagridCE.SelectedItem as CupExaminee;
                        windowUpdate.radSieuCup.IsChecked = true;
                        windowUpdate.radChuyen.IsEnabled = false;
                        windowUpdate.txtDiemTAnh.IsEnabled = false;
                        windowUpdate.ShowDialog();
                    }
                }
                return;
            };

            //selection changed event
            //dataGridPE.SelectionChanged += (sender, e) =>
            //{
            //    var selectedItem = dataGridPE.SelectedItem as ProExaminee;
            //    MessageBox.Show(selectedItem.Name);
            //};


            //delete Examinee
            btnDelete.Click += (sender, e) =>
            {
                IsCheckedDataGrid();
                if (datagridCE.SelectedItem != null && dataGridPE.SelectedItem == null)
                {
                    cupExaminees.Remove((CupExaminee)datagridCE.SelectedItem);
                    datagridCE.Items.Refresh();
                }
                if (dataGridPE.SelectedItem != null && datagridCE.SelectedItem == null)
                {
                    proExaminees.Remove((ProExaminee)dataGridPE.SelectedItem);
                    dataGridPE.Items.Refresh();
                }
            };
        }       

        
        private bool IsCheckedDataGrid()
        {
            if (datagridCE.SelectedItem == null && dataGridPE.SelectedItem == null)
            {
                MessageBox.Show("bạn phải chọn thí sinh cần xóa");
                return false;
            }
            return true;
        }
    }
}
