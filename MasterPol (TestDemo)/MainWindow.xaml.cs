using MasterPol__TestDemo_.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MasterPol__TestDemo_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) 
                MainFrame.GoBack();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"Мастер Пол - {page.Title}";

            if (page is Pages.PartnersPage)
                BackButton.Visibility = Visibility.Hidden;
            else BackButton.Visibility = Visibility.Visible;

            if (page is Pages.PartnersPage)
                PartnersHistoryButton.Visibility = Visibility.Visible;
            else PartnersHistoryButton.Visibility= Visibility.Hidden;

        }

        private void PartnersHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame?.Navigate(new PartnersHistoryPage());
        }
    }
}
