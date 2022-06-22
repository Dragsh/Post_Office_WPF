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
using System.Windows.Shapes;
using PostOffice.Controller;
using PostOffice.Model;
using PostOffice.ViewModel;

namespace PostOffice.View
{
    /// <summary>
    /// Логика взаимодействия для AddSubscriptionWindow.xaml
    /// </summary>
    public partial class AddSubscriptionWindow : Window
    {
        private Queries _queries;
        public AddSubscriptionViewModel AddSubscriptionViewModel { get; }
        public AddSubscriptionWindow(Subscriber subscriber, Subscription subscription, Queries queries)
        {
            InitializeComponent();
            AddSubscriptionViewModel = new AddSubscriptionViewModel(subscriber, subscription);
            DataContext = AddSubscriptionViewModel;
            _queries = queries;
            CbxPublication.ItemsSource = _queries.GetPublications();
        }//AddSubscriptionWindow()




        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddSubscriptionViewModel.Subscription.Publication == null || AddSubscriptionViewModel.Subscription.Duration == 0)
                    throw new Exception($"Добавте данные в поля!");

                DialogResult = true;
                Close();
                if (AddSubscriptionViewModel.Subscription.Publication.Amount == 0) return;
                QuittanceWindow quittanceWindow = new QuittanceWindow(AddSubscriptionViewModel.Subscription);
                quittanceWindow.ShowDialog();

            }//try
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message,
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }//catch
            
        }//BtnSave_Click

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();

        }//BtnCancel_Click





    }//AddSubscriptionWindow : Window
}//PostOffice.View
