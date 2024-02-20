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
    /// Interaction logic for Search_form.xaml
    /// </summary>
    public partial class Search_form : Window
    {
        SqlConnection con;
        SqlCommand cmd;
        public Search_form()
        {
            InitializeComponent();
        }

        private void Clk_back(object sender, RoutedEventArgs e)
        {
            Form_After_Login fal = new Form_After_Login();
            fal.ShowDialog();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text != null)
            {
                string query;
                String con_string = "Data Source=.;Initial Catalog=Project_BCS_04;Integrated Security=True";
                con = new SqlConnection(con_string);
                try
                {
                    con.Open(); 
                    String name = txt1.Text;
                    if (cmb1.Text.Equals("Batter"))
                    {

                        query = "select * from (Select Batters.[International ID], Players.Name,Batters.[Tournament Average],Batters.[Tournament Strikerate], Batters.best,"
+"\nBatters.[Best Against], Teams.[[Team Name]]] from Players"
+"\nleft outer join Batters"
+"\non  Players.[National Id]=Batters.[National Id]"
+"left outer join Teams"
+"\non Players.[Team Id]=Teams.[Team Id]) Players where Players.Name='"+name+"'";
                     
                    }
                    else if(cmb1.Text.Equals("Bowler"))
                    {
                        query="select * from (Select Bowlers.[International ID], Players.Name, Bowlers.[Tournament Average],Bowlers.best"
+"\n,Bowlers.[Tournament Strikerate], Teams.[[Team Name]]]"
+"\nfrom Players"
+"\nleft outer Join Bowlers"
+"\non Players.[National Id]=Bowlers.[National ID]"
+"\nleft outer Join Teams"
+"\non Players.[Team Id]=Teams.[Team Id]) Players where Players.Name='"+name+"'";
                    }
                    else if (cmb1.Text.Equals("All Rounder"))
                    {
                        query = "select * from (select All_Rounders.[International ID],Players.Name,All_Rounders.[Batting Average],"
+"\nAll_Rounders.[Bowling Average],All_Rounders.[Batting best],All_Rounders.[Bowling best], Teams.[[Team Name]]]"
+"\nfrom All_Rounders"
+"\ninner join Players"
+"\non All_Rounders.[National ID]=Players.[National Id]"
+"\ninner join Teams"
+"\non All_Rounders.Team=Teams.[Team Id]) Players where Players.Name='"+name+"'";
                    }
                    else
                    {
                         query = "select * from (select Players.Name,Batters.[Tournament Average],Bowlers.Wickets,All_Rounders.[Boaling Strikerate]" +
    "\nfrom Players" +
    "\nleft outer join Batters" +
    "\non Players.[National Id]=Batters.[National Id]" +
    "\nleft outer join Bowlers" +
    "\non Players.[National Id]=Bowlers.[National ID]" +
    "\n left outer join All_Rounders"
    + "\non Players.[National Id]=All_Rounders.[National ID]) Players where Players.Name='" + name + "'";
                        
                    }
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grdview1.ItemsSource = dt.DefaultView;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
             
        }
    }
}
