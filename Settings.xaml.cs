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
        private const string PressAKey = "-- Press a key --";
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
            ResetButtonNames();
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
            refreshKeyButton.Content = PressAKey;
            ChangingKey = "Refresh";
        }

        private void ResetButtonNames()
        {
            /* Reset key buttons */
            refreshKeyButton.Content = IntermediateSettingStorage.RefreshKey.ToString();
            upKeyButton.Content = IntermediateSettingStorage.UpKey.ToString();
            downKeyButton.Content = IntermediateSettingStorage.DownKey.ToString();
            leftKeyButton.Content = IntermediateSettingStorage.LeftKey.ToString();
            rightKeyButton.Content = IntermediateSettingStorage.RightKey.ToString();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (ChangingKey != null)
            {
                if (ChangingKey == "Refresh")
                {
                    Properties.Settings.Default.RefreshKey = (int)e.Key;
                }
                else if (ChangingKey == "Up")
                {
                    Properties.Settings.Default.UpKey = (int)e.Key;
                }
                else if (ChangingKey == "Down")
                {
                    Properties.Settings.Default.DownKey = (int)e.Key;
                }
                else if (ChangingKey == "Left")
                {
                    Properties.Settings.Default.LeftKey = (int)e.Key;
                }
                else if (ChangingKey == "Right")
                {
                    Properties.Settings.Default.RightKey = (int)e.Key;
                }
                ChangingKey = null;
                IntermediateSettingStorage.SetKeyBindings();
                ResetButtonNames();
            }
        }

        private void upKeyButton_Click(object sender, RoutedEventArgs e)
        {
            upKeyButton.Content = PressAKey;
            ChangingKey = "Up";
        }

        private void downKeyButton_Click(object sender, RoutedEventArgs e)
        {
            downKeyButton.Content = PressAKey;
            ChangingKey = "Down";
        }

        private void leftKeyButton_Click(object sender, RoutedEventArgs e)
        {
            leftKeyButton.Content = PressAKey;
            ChangingKey = "Left";
        }

        private void rightKeyButton_Click(object sender, RoutedEventArgs e)
        {
            rightKeyButton.Content = PressAKey;
            ChangingKey = "Right";
        }
    }
}
