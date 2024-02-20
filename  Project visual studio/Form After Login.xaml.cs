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
using System.Data;
namespace Semester_4th_Project
{
    /// <summary>
    /// Interaction logic for Form_After_Login.xaml
    /// </summary>
    public partial class Form_After_Login : Window
    {
        SqlConnection con;
        SqlCommand cmd;
        public Form_After_Login()
        {
            InitializeComponent();
        } 

        private void Button_Coaches(object sender, RoutedEventArgs e)
        {
            String con_string = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(con_string);
            try
            {
                con.Open();
                String query = "select Coaches.Id,Coaches.Name,Coaches.[Coach For],Teams.[[Team Name]]]\n"+
"from Coaches\n"+
"left outer join Teams\n"+
"on Teams.[Team Id]=Coaches.[Team Id]";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data_Form df = new Data_Form();
                df.grdData.ItemsSource = dt.DefaultView;
                df.label1.Content = "Coaches";
                df.ShowDialog();
                this.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search_form sf=new Search_form();
            sf.ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
                DataTable dt = new DataTable();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String Con_String = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(Con_String);
            try
            {
                con.Open();
                String Query = "Select Bowlers.[International ID], Players.Name,Bowlers.[Tournament Average],Bowlers.[Tournament Strikerate],\n"
+ "Bowlers.best,Bowlers.[Best Against],Teams.[[Team Name]]]\n" +
"from Bowlers\n" +
"left outer join Players\n" +
"on Bowlers.[National ID]=Players.[National Id]\n" +
"left outer join Teams\n"
+ "on Bowlers.[Team]=Teams.[Team Id]";
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

        private void Click_allrounder(object sender, RoutedEventArgs e)
        {
            String Con_String = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(Con_String);
            try
            {
                con.Open();
                String query = "Select All_Rounders.[International ID],Players.Name,Players.Age,All_Rounders.[Batting Average],All_Rounders.[Bowling Average],"
+ "\nAll_Rounders.[Batting Strikerate],All_Rounders.[Boaling Strikerate],All_Rounders.[Batting best],All_Rounders.[Batting best]"
+ "\n,Teams.[[Team Name]]]"
+ "\nfrom All_Rounders"
+ "\nleft outer join Players"
+ "\non All_Rounders.[National ID]=Players.[National Id]"
+ "\nleft outer join Teams"
+ "\non All_Rounders.Team=Teams.[Team Id]";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data_Form df = new Data_Form();
                df.grdData.ItemsSource = dt.DefaultView;
                df.label1.Content = "All Rounders";
                df.ShowDialog();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clk_Max_Runs(object sender, RoutedEventArgs e)
        {
            String Con_String = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(Con_String);
            try
            {
                con.Open();
                String query = "select * from (Select  Players.[National Id], Players.Name,Batters.[Tournament Average],Batters.[Tournament Strikerate], Batters.best,"
+"\nBatters.[Best Against],Batters.Run, Teams.[[Team Name]]] from Batters" 
+"\nleft outer join Players"
+"\non  Players.[National Id]=Batters.[National Id]"
+"\nleft outer join Teams"
+"\non Batters.Team=Teams.[Team Id]) Players inner join (select max(Run) as Run from Batters)Batters" 
+"\non Players.Run=Batters.Run";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data_Form df = new Data_Form();
                df.grdData.ItemsSource = dt.DefaultView;
                df.label1.Content = "Player with Maximum Runs";
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
            String Con_String = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            con = new SqlConnection(Con_String);
            try
            {
                con.Open();
                String query = "select * from(Select Bowlers.[International ID],Players.Name,Bowlers.Wickets, Bowlers.[Tournament Average],Bowlers.best"
+"\n,Bowlers.[Tournament Strikerate], Teams.[[Team Name]]]"
+"\nfrom Bowlers"
+"\nleft outer Join Players"
+"\non Players.[National Id]=Bowlers.[National ID]"
+"\nleft outer Join Teams"
+"\non Players.[Team Id]=Teams.[Team Id]) High_Bowler inner join (Select Max(Wickets) as [Total Wickets] from Bowlers) Wic_bow"
+"\non High_Bowler.Wickets=Wic_bow.[Total Wickets]";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data_Form df = new Data_Form();
                df.grdData.ItemsSource = dt.DefaultView;
                df.label1.Content = "Player with Maximum Runs";
                df.ShowDialog();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clk_Allrounder(object sender, RoutedEventArgs e)
        {

            String Con_String = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
            
            con = new SqlConnection(Con_String);
            try
            {
                con.Open();
                String query = "select * from(select All_Rounders.[International ID],Players.Name,"
+"\nAll_Rounders.Wickets,All_Rounders.Runs,All_Rounders.[Batting Average],All_Rounders.[Bowling Average]"
+"\n,Teams.[[Team Name]]]"
+"\nfrom All_Rounders"
+"\ninner Join Players"
+"\non Players.[National Id]=All_Rounders.[National ID]"
+"\ninner join Teams"
+"\non Teams.[Team Id]=All_Rounders.Team) Pro_All inner join ( select Max(Wickets) as Wickets,"
+"\nMax(Runs) as Runs from All_Rounders)All_round"
+"\non Pro_All.Wickets=All_round.Wickets or Pro_All.Runs=All_round.Runs";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data_Form df = new Data_Form();
                df.grdData.ItemsSource = dt.DefaultView;
                df.label1.Content = "Player with Maximum Runs";
                df.ShowDialog();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
