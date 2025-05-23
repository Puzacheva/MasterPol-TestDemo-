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

namespace MasterPol__TestDemo_.Pages
{
    /// <summary>
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        public PartnersPage()
        {
            InitializeComponent();
            PartnersListView.ItemsSource = Entities.GetContext().Partner.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddEditPartnerPage(null));
        }

        private void PartnersListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PartnersListView.SelectedItem is Partner selectedItem)
            {
                NavigationService?.Navigate(new AddEditPartnerPage(selectedItem));
            }
        }
    }
}
