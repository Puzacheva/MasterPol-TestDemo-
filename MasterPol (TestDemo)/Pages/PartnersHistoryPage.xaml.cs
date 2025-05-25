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
    /// Логика взаимодействия для PartnersHistoryPage.xaml
    /// </summary>
    public partial class PartnersHistoryPage : Page
    {
        public PartnersHistoryPage()
        {
            InitializeComponent();

            PartnersCB.ItemsSource = Entities.GetContext().Partner.ToList();
        }

        private void PartnersCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedValue = (int) PartnersCB.SelectedValue;
            ProductsHistoryDG.ItemsSource = Entities.GetContext().PartnerProduct.Where(p => p.partner == selectedValue).ToList();
        }
    }
}
