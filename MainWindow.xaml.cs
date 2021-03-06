﻿using System;
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

namespace Jackie4Chuan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        IFullBoard currentBoard;
        Int32 threadNumber = 0;
        Int32 pageNumber = 0;

        public void Start()
        {
            IntermediateSettingStorage.SetKeyBindings();
            Controller.FillBoards();
            currentBoard = Controller.GetBoard(Properties.Settings.Default.DefaultBoard, 1);
            boardSelect.ItemsSource = Controller.GetBoardNames();
            boardSelect.Text = currentBoard.Board.ToString();
            pageNo.ItemsSource = Controller.CountUpTo(currentBoard.Board.Pages);
            pageNo.SelectedIndex = pageNumber;
            Update();
        }

        /// <summary>
        /// Clears the posts on screen
        /// </summary>
        private void ClearPosts()
        {
            postStackPanel.Children.RemoveRange(0, postStackPanel.Children.Count);
        }

        private void SpawnOp(FChan.Library.Post OP)
        {
            Jackie4Chuan.OP opControl = new Jackie4Chuan.OP(OP);
            postStackPanel.Children.Add(opControl);
        } 

        private void Update()
        {
            ClearPosts();
            pageNo.ItemsSource = Controller.CountUpTo(currentBoard.Board.Pages);

            boardHeader.Content = currentBoard.Board.ToString();
            FChan.Library.Post currentOp = currentBoard.Threads[threadNumber].Posts[0];

            SpawnOp(currentOp);

            if (currentBoard.Threads[threadNumber].Posts.Count != 0)
            {
                for (int i = 1; i < currentBoard.Threads[threadNumber].Posts.Count; i++)
                {
                    RegularPost thisPost = new RegularPost(
                        currentBoard.Threads[threadNumber].Posts[i]);
                    postStackPanel.Children.Add(thisPost);
                }
            }
        }
        private void boardSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBoard = Controller.GetFullBoard((FChan.Library.Board)boardSelect.SelectedItem, 1);
            threadNumber = 0;
            Update();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        private void RefreshBoard()
        {
            currentBoard = Controller.GetBoard(currentBoard.Board.BoardName, 1);
            threadNumber = 0;
            Update();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshBoard();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            this.IsEnabled = false;
            settings.Owner = this;
            settings.Show();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == IntermediateSettingStorage.UpKey && threadNumber > 0)
            {
                threadNumber--;
                Update();
            }
            else if (e.Key == IntermediateSettingStorage.DownKey && threadNumber < currentBoard.Threads.Count - 1)
            {
                threadNumber++;
                Update();
            }
            else if (e.Key == IntermediateSettingStorage.LeftKey)
            {
                TryPreviousPage();
            }
            else if (e.Key == IntermediateSettingStorage.RightKey)
            {
                TryNextPage();
            }
            else if (e.Key == IntermediateSettingStorage.RefreshKey)
            {
                RefreshBoard();
            }
        }

        private void TryNextBoard()
        {
            if (boardSelect.SelectedIndex < boardSelect.Items.Count - 1)
            {
                boardSelect.SelectedIndex++;
            }
        }

        private void TryLastBoard()
        {
            if (boardSelect.SelectedIndex > 0)
            {
                boardSelect.SelectedIndex--;
            }
        }

        private void TryNextPage()
        {
            if (pageNo.SelectedIndex < pageNo.Items.Count)
            {
                pageNo.SelectedIndex++;
            }
        }

        private void TryPreviousPage()
        {
            if (pageNo.SelectedIndex > 0)
            {
                pageNo.SelectedIndex--;
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadUp();
        }
        /// <summary>
        /// Handles user wanting to go up a thread
        /// </summary>
        private void ThreadUp()
        {
            if (threadNumber > 0)
            {
                threadNumber--;
                Update();
            }
        }

        /// <summary>
        /// Handles user wanting to go down a thread
        /// </summary>
        private void ThreadDown()
        {
            if (threadNumber < currentBoard.Threads.Count - 1)
            {
                threadNumber++;
                Update();
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadDown();
        }


        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                ThreadUp();
            }
            else if (e.Delta < 0)
            {
                ThreadDown();
            }
        }

        private void pageNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBoard = Controller.GetBoard(currentBoard.Board.BoardName, (int)pageNo.SelectedItem);
            threadNumber = 0;
            Update();
        }
    }
}
