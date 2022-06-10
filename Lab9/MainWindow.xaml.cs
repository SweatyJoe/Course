using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileContent = string.Empty;
        private string filePath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            goChangeContentButton.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            OpenFileDialog openDialog = new OpenFileDialog();


            openDialog.InitialDirectory = "C:\\";
            openDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;
            if (openDialog.ShowDialog() == true)
            {
                filePath = openDialog.FileName;
                var fileStream = openDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            if (filePath != "") goChangeContentButton.Visibility = Visibility.Visible;
            else MessageBox.Show("Не выбран файл");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ContentWindow cw = new ContentWindow(fileContent, filePath);
            cw.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("Выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.Yes)
            {
                //
            }
        }
    }
}