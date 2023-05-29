using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Showrma.Model;
using Showrma.Model;

namespace Showrma.Pages
{
    /// <summary>
    /// Interaction logic for AddSerPage.xaml
    /// </summary>
    public partial class AddSerPage : Page
    {
        Service contextClientServive;
        public AddSerPage(Service clientService)
        {
            InitializeComponent();
            contextClientServive = clientService;
            DataContext = contextClientServive;
            TbTimes.Text = DateTime.Now.ToString("t");
            DbStart.Text = DateTime.Now.ToString();
        }



        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if ( DbStart.SelectedDate != null && DbStart.SelectedDate > DateTime.Now)
            {
                string times = DbStart.Text + " " + TbTimes.Text;

                ClientService clientService1 = new ClientService();
                clientService1.Service = contextClientServive;
                clientService1.StartTime = DateTime.Parse(times);
                App.DB.ClientService.Add(clientService1);


                App.DB.SaveChanges();
                NavigationService.Navigate(new HomePage());
            }
            else
            {
                MessageBox.Show("Выбрать дату и клиента");
                return;
            }
        }
        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }

        private void TbTimes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9:]") == false)
            {
                e.Handled = true;
            }
        }

        private void TbTitle_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TbCost_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9:]") == false)
            {
                e.Handled = true;
            }
        }

        private void TbTime_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9:]") == false)
            {
                e.Handled = true;
            }
        }

        private void TbDiscount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9:]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
