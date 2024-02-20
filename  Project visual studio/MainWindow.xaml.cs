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
using System.Data.SqlClient;
using System.Data;

namespace Semester_4th_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String Con_String = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(Con_String);
            try
            {
                con.Open();
                String query = "Select Batters.[International ID], Players.Name,Batters.[Tournament Average],Batters.[Tournament Strikerate], Batters.best,Batters.[Best Against], Teams.[[Team Name]]] from Batters left outer join Players on Batters.[National ID]=Players.[National Id] left outer join Teams on Batters.[Team]=Teams.[Team Id]";
                SqlCommand cmd = new SqlCommand(query, con);
                 cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt=new DataTable();
                da.Fill(dt);

                Data_Form df = new Data_Form();
                df.grdData.ItemsSource = dt.DefaultView;
                df.label1.Content = "Batters";
                df.ShowDialog();
                this.Close();
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String Con_String = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(Con_String);
            try
            {
                con.Open();
                String Query="Select Bowlers.[International ID], Players.Name,Bowlers.[Tournament Average],Bowlers.[Tournament Strikerate],\n"
+ "Bowlers.best,Bowlers.[Best Against],Teams.[[Team Name]]]\n" +
"from Bowlers\n"+
"left outer join Players\n"+
"on Bowlers.[National ID]=Players.[National Id]\n"+
"left outer join Teams\n"
+"on Bowlers.[Team]=Teams.[Team Id]";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data_Form df = new Data_Form();
                df.grdData.ItemsSource = dt.DefaultView;
                df.label1.Content = "Bowlers";
                df.ShowDialog();
                this.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String Con_String = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(Con_String);
            try
            {
                con.Open();
                String query = "Select All_Rounders.[International ID],Players.Name,Players.Age,All_Rounders.[Batting Average],All_Rounders.[Bowling Average],"
+"\nAll_Rounders.[Batting Strikerate],All_Rounders.[Boaling Strikerate],All_Rounders.[Batting best],All_Rounders.[Batting best]"
+ "\n,Teams.[[Team Name]]]"
+"\nfrom All_Rounders"
+"\nleft outer join Players"
+"\non All_Rounders.[National ID]=Players.[National Id]"
+"\nleft outer join Teams"
+ "\non All_Rounders.Team=Teams.[Team Id]";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data_Form df = new Data_Form();
                df.grdData.ItemsSource = dt.DefaultView;
                df.label1.Content = "All Rounder";
                df.ShowDialog();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Registeration_Form sec = new Registeration_Form();
            sec.ShowDialog();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Login_Form lf = new Login_Form();
            lf.ShowDialog();  
            this.Close();
        }
    }
}
