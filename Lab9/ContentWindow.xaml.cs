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
using System.Windows.Shapes;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : Window
    {
        private string fileContent = string.Empty;
        private string filePath = string.Empty;
        public ContentWindow(string fileContent, string filePath)
        {
            InitializeComponent();
            this.fileContent = fileContent;
            this.filePath = filePath;
            contentBox.Text = fileContent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool ok = isOk();
            if (ok)
            {
                fileContent = contentBox.Text;
                MessageBox.Show("Изменения сохранены успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        protected static bool isOk()
        {
            if (MessageBox.Show("Точно сохранить? Результат может быть необратим", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return false;
            else
                return true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("Выйти? Не сохранённые изменения будут утеряны!", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow mainW = new MainWindow();
                mainW.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            contentBox.Text = fileContent;
            MessageBox.Show("Изменения загружены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    await writer.WriteLineAsync(fileContent);
                }
                MessageBox.Show("Изменения сохранены в файл успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка записи в файл" + ex.StackTrace);
            }
        }
    }
}
