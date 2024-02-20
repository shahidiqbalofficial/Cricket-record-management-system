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
    /// Interaction logic for Login_Form.xaml
    /// </summary>
    public partial class Login_Form : Window
    {
        SqlCommand cmd;
        SqlConnection con;
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String co = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(co);
            try
            {
                con.Open();
               
                String query = "";
                SqlCommand cmd = new SqlCommand("Select * from Register_Viewers where email=@email", con);
                cmd.Parameters.AddWithValue("@email", txtbox1.Text.ToString());
                SqlDataReader sr =  cmd.ExecuteReader();
                
                if (sr.Read())
                {
                     
                    if (sr["Password"].ToString().Equals(passbox1.Password.ToString(),StringComparison.InvariantCulture))
                    {

                        Form_After_Login fal = new Form_After_Login();
                        fal.label1.Content=sr["Name"];
                        fal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        txtbox1.Clear();
                        passbox1.Clear();
                        MessageBox.Show("Invalid username or Password.");
                    }
                }
                else
                {
                    txtbox1.Clear();
                    passbox1.Clear();
                    MessageBox.Show("Invalid user name");
                }

                 

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }    
        
        }
    }
}
