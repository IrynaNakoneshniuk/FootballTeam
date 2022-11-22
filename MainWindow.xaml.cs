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
using ModelLibrary;
namespace FootballTeam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Team> Team;
        public MainWindow()
        {
            try
            {
                Team = new List<Team>();
                InitializeComponent();
                using (FootBallDB bd = new FootBallDB())
                {
                    var teams_tmp = bd.Team.ToList();
                    foreach (Team team in teams_tmp)
                    {
                        Team.Add(team);
                    }
                }
                this.bgData.ItemsSource = Team;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void addTeamButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FootBallDB bd = new FootBallDB())
                {
                    Team team = new Team();
                    team.Name = textBoxName.Text;
                    team.Sity = textBoxSity.Text;
                    team.AmountField = Convert.ToInt32(textBoxAmountField.Text);
                    team.AmountWin = Convert.ToInt32(textBoxAmountWin.Text);
                    team.AmountDraw = Convert.ToInt32(textBoxAmountDraw.Text);
                    bd.Add(team);
                    bd.SaveChanges();
                    Team.Add(team);
                }
                this.bgData.ItemsSource = null;
                this.bgData.ItemsSource = Team;
                textBoxName.Clear();
                textBoxSity.Clear();
                textBoxAmountField.Clear();
                textBoxAmountWin.Clear();
                textBoxAmountDraw.Clear();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}
