using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace BlankLineRemover
{  
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {   if (textBoxFilePath.Text.Trim() != string.Empty)
            {
                if(checkBoxCopy.IsChecked == true)
                {
                    File.Copy(textBoxFilePath.Text.Trim(), textBoxFilePath.Text.Trim() + " BackUp.txt");
                }
                IEnumerable <string> lines = File.ReadAllLines(textBoxFilePath.Text.Trim()).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(textBoxFilePath.Text.Trim(), lines);
            }
        }       
        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Text|*.txt";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxFilePath.Text = (file.FileName == string.Empty) ? "" : file.FileName;
                //if (file.FileName != string.Empty)
                //{
                //    textBoxFilePath.Text = file.FileName;
                //}
            }
        }
    }
}
