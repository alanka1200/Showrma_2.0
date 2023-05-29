using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Showrma.Pages
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        IEnumerable<ClientService> filterProduct = App.DB.ClientService.ToList();
        public CartPage()
        {
            InitializeComponent();
            IEnumerable<ClientService> products = App.DB.ClientService.OrderByDescending(x => x.StartTime).ToList();
            LvSecv.ItemsSource = products.Where(x => x.StartTime < DateTime.Now + TimeSpan.FromDays(2)
                                                     && x.StartTime > DateTime.Now.Date).ToList();
            TbPages.Text = $" {App.DB.ClientService.Where(x => x.StartTime > DateTime.Now).Count()} из {App.DB.ClientService.Count()} ";
        }

        private void BtServList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}

