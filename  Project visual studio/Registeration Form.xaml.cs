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
using System.Data.SqlClient;

namespace Semester_4th_Project
{
    /// <summary>
    /// Interaction logic for Registeration_Form.xaml
    /// </summary>
    public partial class Registeration_Form : Window
    {
        SqlConnection con;
        SqlCommand cmd;
        public Registeration_Form()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String con_string = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(con_string);
            try
            {
                String name = txtname1.Text.ToString() + " " + txtname2.Text.ToString();
                string address = txtaddress.Text;
                string email = emailtxt.Text;
                String password = "";
                if (password1txt.Password.ToString().Equals(password2txt.Password.ToString()))
                {
                    password = password2txt.Password;
                }
                String gender = "";
                if (rd1.IsChecked == true)
                {
                    gender += rd1.Content;
                }
                if (rd2.IsChecked == true)
                {
                    gender += rd2.Content;
                }
                String date = dob.Text;
                string city = cmbcity.Text;
                con.Open();
                String query = "execute  Ins_viewer '" + email + "','" + password + "','" + city + "','" + address + "','" + date + "','" + gender + "','" + name + "'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your information has been Added.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Login_back(object sender, RoutedEventArgs e)
        {
            Login_Form lf = new Login_Form();
            lf.ShowDialog();
            this.Close();
        }
    }
        }
    

