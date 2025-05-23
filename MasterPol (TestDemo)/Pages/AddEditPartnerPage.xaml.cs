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
    /// Логика взаимодействия для AddEditPartnerPage.xaml
    /// </summary>
    public partial class AddEditPartnerPage : Page
    {
        private Partner _currentPartner = new Partner();

        public AddEditPartnerPage(Partner selectedPartner)
        {
            InitializeComponent();

            TypeCB.ItemsSource = Entities.GetContext().PartnerType.Select(p => p.partner_type_name).ToList();

            if (selectedPartner != null)
            {
                _currentPartner = selectedPartner;
                TypeCB.SelectedItem = Entities.GetContext().PartnerType.Where(p => p.partner_type_id == _currentPartner.partner_type).FirstOrDefault().partner_type_name;
            }

            DataContext = _currentPartner;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text) || TypeCB.SelectedItem == null ||
                string.IsNullOrWhiteSpace(AddressTB.Text) || string.IsNullOrWhiteSpace(FIOTB.Text)
                || string.IsNullOrWhiteSpace(PhoneTB.Text) || string.IsNullOrWhiteSpace(EmailTB.Text))

            {
                MessageBox.Show("Все поля, кроме рейтинга являются обязательными для заполнения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(RatingTB.Text, out int rating) || rating < 0)
            {
                MessageBox.Show("Рейтинг должен быть целым неотрицательным числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else
            {
                if (_currentPartner.partner_id == 0)
                {
                    _currentPartner.partner_type = Entities.GetContext().PartnerType.FirstOrDefault(p => p.partner_type_name == TypeCB.Text).partner_type_id;
                    Entities.GetContext().Partner.Add(_currentPartner);
                }

                try
                {
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService?.Navigate(new PartnersPage());
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
