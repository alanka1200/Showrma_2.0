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
using Showrma.Model;
using System.Text.RegularExpressions;

namespace Showrma.Pages
{
    /// <summary>
    /// Interaction logic for AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        Service contextService;
        public AddEditPage(Service service)
        {
            InitializeComponent();
            contextService = service;
            DataContext = contextService;
            contextService.Discount *= 100;
            contextService.DurationInSeconds /= 60;
            
            TbDiscount.Text = contextService.Discount.ToString();
        }

        private void BtAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                contextService.MainImagePath = File.ReadAllBytes(openFileDialog.FileName);
                DataContext = null;
                DataContext = contextService;
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string error = "";
                if (TbCost.Text.Length > 0 && TbDiscount.Text.Length > 0 && TbTime.Text.Length > 0 && TbTitle.Text.Length > 0
                    && ImMainImage != null && int.Parse(TbTime.Text) < 240 && int.Parse(TbTime.Text) > 0)
                {
                    contextService.Discount /= 100;
                    contextService.DurationInSeconds *= 60;
                    if (contextService.Id == 0)
                    {
                        if (App.DB.Service.FirstOrDefault(x => x.Title == contextService.Title) == null)
                        {
                            App.DB.Service.Add(contextService);
                        }
                        else
                        {
                            MessageBox.Show("Блюдо с тамким назваием уже существует");
                            return;

                        }
                    }
                    App.DB.SaveChanges();
                    NavigationService.Navigate(new HomePage());
                }
                else
                {
                    if (TbTitle.Text.Length == 0)
                    {
                        error += "Заполните название блюда";
                    }
                    if (TbDiscount.Text.Length == 0)
                    {
                        error += "Заполните скидку";
                    }

                    if ((TbTime.Text.Length == 0 || int.Parse(TbTime.Text) > 241))
                    {
                        error += "Заполните корректное время";
                    }
                    if (int.Parse(TbTime.Text) < 10)
                    {
                        error += "Заполните корректное время";
                    }
                    if (TbCost.Text.Length == 0 && int.Parse(TbCost.Text) < 100)
                    {
                        error += "Заполните цену услуги";
                    }
                    if (ImMainImage == null)
                    {
                        error += "Загрузите картинку";
                    }
                    if (error != "")
                    {
                        MessageBox.Show($"{error}");
                        return;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }


        private void TbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            contextService.Discount /= 100;
            contextService.DurationInSeconds *= 60;
            NavigationService.Navigate(new HomePage());
        }

        private void TbDiscount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9,]") == false)
            {
                e.Handled = true;
            }
        }
        private void TbCost_OnPreviewTextInputTbPhone_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9,]") == false)
            {
                e.Handled = true;
            }
        }

        private void TbTime_OnPreviewTextInputTbPhone_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9,]") == false)
            {
                e.Handled = true;
            }
        }
    }
}

