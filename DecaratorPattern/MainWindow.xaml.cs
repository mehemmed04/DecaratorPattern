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

namespace DecaratorPattern
{
  



    public partial class MainWindow : Window
    {
        public RelayCommand SendMessageCommand { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            SendMessageCommand = new RelayCommand((e) =>
            {

            }, (e) =>
            {
                return TextBox1.Text != string.Empty;
            });

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SmsService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FacebookService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InstagramService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TwitterService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
