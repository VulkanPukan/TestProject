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
using System.ServiceModel;

namespace WpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfBank.BankClient client;
        string account;
        public MainWindow()
        {
            InitializeComponent();
            client = new WpfBank.BankClient();
        }

        void LoadCombo()
        {
            comboBox.Items.Clear();
            client.GetAllAccount(account).ToList<string>().ForEach(x=> comboBox.Items.Add(x));
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                account = textBox.Text;
                label.Content = client.GetBalance(account);
                LoadCombo();
            }catch(Exception ex) { }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (client.SendMoney(account, comboBox.SelectedItem.ToString(), Convert.ToDouble(textBox1.Text)))
                {
                    MessageBox.Show("Money send to >" + comboBox.SelectedItem.ToString());
                    textBox1.Background = Brushes.White;
                }
                else textBox1.Background = Brushes.Red;
                textBox1.Text = null;
                label.Content = client.GetBalance(account);
            }
            catch(Exception ex) { }
        }
    }
}
