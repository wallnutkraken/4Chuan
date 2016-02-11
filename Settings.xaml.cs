using FChan.Library;
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

namespace Jackie4Chuan
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private string ChangingKey = null;
        public Settings()
        {
            InitializeComponent();

            List<Board> boards = Controller.GetBoardNames();
            startingBoardComboBox.ItemsSource = boards;
            for (int i = 0; i < boards.Count; i++)
            {
                if (boards[i].BoardName == Properties.Settings.Default.DefaultBoard)
                {
                    startingBoardComboBox.SelectedIndex = i;
                }
            }
            refreshKeyButton.Content = IntermediateSettingStorage.RefreshKey.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Board startupBoard = (Board)startingBoardComboBox.SelectedItem;
            Properties.Settings.Default.DefaultBoard = startupBoard.BoardName;

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.IsEnabled = true;
        }

        private void refreshKeyButton_Click(object sender, RoutedEventArgs e)
        {
            refreshKeyButton.Content = "-- Press a key --";
            ChangingKey = "Refresh";
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (ChangingKey != null)
            {
                if (ChangingKey == "Refresh")
                {
                    Properties.Settings.Default.RefreshKey = (int)e.Key;
                }
                ChangingKey = null;
                IntermediateSettingStorage.SetKeyBindings();
                refreshKeyButton.Content = IntermediateSettingStorage.RefreshKey.ToString();
            }
        }
    }
}
