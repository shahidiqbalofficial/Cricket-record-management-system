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

namespace Semester_4th_Project
{
    /// <summary>
    /// Interaction logic for Data_Form.xaml
    /// </summary>
    public partial class Data_Form : Window
    {
        public Data_Form()
        {
            InitializeComponent();
        }

        private void clk_back(object sender, RoutedEventArgs e)
        {
            Form_After_Login fal = new Form_After_Login();
            fal.ShowDialog();
            this.Close();
        }
    }
}
