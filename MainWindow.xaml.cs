using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lab14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuLoadText(object sender, RoutedEventArgs e)
        {
            //string filePath = string.Empty;
            string fileContent = string.Empty;

            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.InitialDirectory = "C:\\";
            openDialog.Title = "Открыть файл";
            openDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;
            if (openDialog.ShowDialog() == true)
            {
                //filePath = openDialog.FileName;
                var fileStream = openDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            if (textContent.Text != "")
            {
                if (MessageBox.Show("Заменить текущий текст?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    textContent.Text = fileContent;
            }
            else textContent.Text = fileContent;
            
        }

        private void MenuSaveText(object sender, RoutedEventArgs e)
        {
            string defaultExt = ".txt";
            SaveDialog(defaultExt, textContent.Text);
        }

        private void MenuSaveHTML(object sender, RoutedEventArgs e)
        {
            string content = textContent.Text;
            content = content.Replace("&", "&amp;").Replace(" ", "&nbsp;").Replace("\n", "<BR>").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");

            string defaultExt = ".html";
            SaveDialog(defaultExt, content);
        }

        private void SaveDialog(string defaultExt, string fileContent)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.DefaultExt = defaultExt;
            saveDialog.InitialDirectory = "C:\\";
            saveDialog.Title = "Сохранить как текст";

            if (saveDialog.ShowDialog() == true)
            {
                var fileStream = saveDialog.OpenFile();

                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(fileContent);
                }
            }
        }
    }
}
