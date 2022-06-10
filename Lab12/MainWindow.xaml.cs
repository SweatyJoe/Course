using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace Lab12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbCommand cmd = new OleDbCommand();
        OleDbConnection cn = new OleDbConnection();
        OleDbDataReader dr;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            dataGrid.Items.Clear();
            try
            {
                string query = "select * from table1";
                //cmd.CommandText = query;
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(query, cn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    
                    dataGrid.Columns.Clear();
                    while (dr.Read())
                    {
                        List<string> list = new List<string>();
                        list.Add(dr.GetString(0));
                        list.Add(dr.GetString(1));
                        list.Add(dr.GetString(2));
                        list.Add(dr.GetString(3));
                        list.Add(dr.GetString(4));
                        dataGrid.Items.Add(list);
                        //dataGrid.Items.Add(dr[0].ToString());
                        //dataGrid.Items.Add(dr[1].ToString());
                        //dataGrid.Items.Add(dr[2].ToString());
                        //dataGrid.Items.Add(dr[3].ToString());
                        //dataGrid.Items.Add(dr[4].ToString());

                        
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\PascalProjects\repos\12\carCeller.accdb";
            cmd.Connection = cn;
            loadData();
        }
    }
}
