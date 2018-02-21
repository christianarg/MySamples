using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient httpClient = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    textBlock.Text = Coso().Result;
        //}

        private void Deadlock_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = GetDataWithDefaultAwait().Result;
            //textBlock.Text = await Coso();
        }

        private async void UIThreadException_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = await GetDataWithDefaultAwait().ConfigureAwait(false);
        }

        private async void ActualCorrectWay_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = await GetDataWithDefaultAwait();
        }

        private async Task<string> GetDataWithDefaultAwait()
        {
            return await httpClient.GetStringAsync("https://www.google.es");
        }
    }
}
