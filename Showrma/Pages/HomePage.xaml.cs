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
using Showrma.Model;

namespace Showrma.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        IEnumerable<Service> filterProductAll = App.DB.Service.Where(x => x.IsDelete != true).ToList();
        public HomePage()
        {
            InitializeComponent();
            InitializeComponent();
            if (App.Admin == true)
            {
                BtAddServ.Visibility = Visibility.Visible;
                BtServList.Visibility = Visibility.Visible;
            }
            else
            {
                BtAddServ.Visibility = Visibility.Collapsed;
                BtServList.Visibility = Visibility.Collapsed;
            }
            CbDiscount.SelectedIndex = 0;
            CbSort.SelectedIndex = 0;
            Update();
            TbPages.Text = $" {App.DB.Service.Where(x => x.IsDelete != true).Count()} из {App.DB.Service.Count()} ";
        }
        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            var select = (sender as Button).DataContext as Service;
            NavigationService.Navigate(new AddEditPage(select));
        }
        private void DellBt_Click(object sender, RoutedEventArgs e)
        {
            var select = (sender as Button).DataContext as Service;
            if (App.DB.ClientService.FirstOrDefault(x => x.ServiceId == select.Id) != null)
            {
                MessageBox.Show("Удаление услуги невозможно, имеются данные");
                return;
            }
            select.IsDelete = true;
            App.DB.SaveChanges();
            Update();

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        public void Update()
        {
            IEnumerable<Service> filterProduct = App.DB.Service.Where(x => x.IsDelete != true).ToList();
            if (CbSort.SelectedIndex == 1)
                filterProduct = filterProduct.OrderBy(x => x.CostDisc);
            else if (CbDiscount.SelectedIndex == 2)
                filterProduct = filterProduct.OrderByDescending(x => x.CostDisc);
            if (CbDiscount.SelectedIndex > 0)
            {

                if (CbDiscount.SelectedIndex == 1)
                    filterProduct = filterProduct.Where(x => x.Discount >= 0 && x.Discount < 0.05 || x.Discount == null).ToList();
                else if (CbDiscount.SelectedIndex == 2)
                    filterProduct = filterProduct.Where(x => x.Discount >= 0.05 && x.Discount < 0.15).ToList();
                else if (CbDiscount.SelectedIndex == 3)
                    filterProduct = filterProduct.Where(x => x.Discount >= 0.15 && x.Discount < 0.30).ToList();
                else if (CbDiscount.SelectedIndex == 4)
                    filterProduct = filterProduct.Where(x => x.Discount >= 0.30 && x.Discount < 0.70).ToList();
                else if (CbDiscount.SelectedIndex == 5)
                    filterProduct = filterProduct.Where(x => x.Discount >= 0.70 && x.Discount < 1).ToList();


            }

            if (TbSelect.Text.Length > 0)
            {
                filterProduct = filterProduct.Where(x => x.Title.ToLower().Contains(TbSelect.Text.ToLower()));
            }

            LvSecv.ItemsSource = filterProduct.ToList();
            string inpageas = filterProduct.Count().ToString();
            TbPages.Text = $"{inpageas} из {filterProductAll.Count()}";
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void CbDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void BtAddServ_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddEditPage(new Service()));
        }

        private void BrAddClintInServ_Click(object sender, RoutedEventArgs e)
        {

            var select = (sender as Button).DataContext as Service;
            NavigationService.Navigate(new AddSerPage(select));
        }
        private void BtServList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage());
        }




        private void AboutBTN_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutPage());
        }
    }
}
  