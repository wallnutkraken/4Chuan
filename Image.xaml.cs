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
using System.Windows.Shapes;

namespace Jackie4Chuan
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : Window
    {
        private FullBoard Board { get; set; }
        public Image()
        {
            InitializeComponent();
        }

        internal Image(FChan.Library.Post post)
        {
            InitializeComponent();

            this.Width = (double)post.ImageWidth;
            this.Height = (double)post.ImageHeight;
            this.image.Height = (double)post.ImageHeight;
            this.image.Width = (double)post.ImageWidth;
            string imagename = post.FileName + post.FileExtension;
            ImageSource source = Controller.GetFullImage(post.Board,
                imagename);
            this.image.Source = source;
            this.Title = imagename;
            this.Show();
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void image_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.DefaultExt = Board.Threads[0].Posts[0].FileExtension;
            save.FileName = Board.Threads[0].Posts[0].OriginalFileName;

            bool? result = save.ShowDialog();
            if (result == true)
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.DownloadFile("https://i.4cdn.org/" + Board.Board.BoardName + "/" +
                    Board.Threads[0].Posts[0].FileName + Board.Threads[0].Posts[0].FileExtension, save.FileName);
            }
        }
    }
}