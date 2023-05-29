using Microsoft.Win32;
using Showrma.Model;
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

namespace Showrma.Pages
{
    /// <summary>
    /// Interaction logic for AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        Employee contextEmployee;
        public AddEmployeePage(Employee employee)
        {
            InitializeComponent();
            if (employee.Id != 0)
            {
                TBFirstName.IsEnabled = false;
            }

            contextEmployee = employee;
            DataContext = contextEmployee;
            CBPost.ItemsSource = App.DB.Role.ToList();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextEmployee.Name) == true)
            {
                errorMessage += "Введите имя считайте меня по частям \n";
            }
            if (string.IsNullOrWhiteSpace(contextEmployee.Login) == true)
            {  
                errorMessage += "Введите логин\n";
            }
            if (string.IsNullOrWhiteSpace(contextEmployee.Password) == true)
            {
                errorMessage += "Введите пароль\n";
            }

            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if (contextEmployee.Id == 0)
            {
                App.DB.Employee.Add(contextEmployee);
                MessageBox.Show($"Новый сотрудник " +
                $"{contextEmployee.Name.ToCharArray()[0]}. " + " был успешно добавлен");
            }
            else
            {
                MessageBox.Show($"Cотрудник " + $"{contextEmployee.Name.ToCharArray()[0]}. " + " был сохранен");
            }
            App.DB.SaveChanges();

            NavigationService.Navigate(new EmployeePage());
        }

        private void BEditImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextEmployee.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextEmployee;
            }
        }
    }
}

