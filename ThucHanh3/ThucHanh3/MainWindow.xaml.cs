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
        public MainWindow()
        {
            InitializeComponent();
            proExaminees = new List<ProExaminee>();
            cupExaminees = new List<CupExaminee>();
            dataGridPE.ItemsSource = proExaminees;
            datagridCE.ItemsSource = cupExaminees;
            windowInput = new InsertWindow();

            btnCreate.Click += (sender, e) =>
            {
                windowInput.ShowDialog();
                if (windowInput.Examinee is ProExaminee)
                {
                    proExaminees.Add(windowInput.Examinee as ProExaminee);
                }
                else
                    cupExaminees.Add(windowInput.Examinee as CupExaminee);
            };
        }
    }
}
