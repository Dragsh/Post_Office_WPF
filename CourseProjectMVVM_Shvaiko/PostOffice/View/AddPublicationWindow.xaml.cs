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
    /// Логика взаимодействия для AddPublicationWindow.xaml
    /// </summary>
    public partial class AddPublicationWindow : Window
    {
        private Queries _queries;
        public AddPublicationViewModel AddPublicationViewModel { get; }
        public AddPublicationWindow(Publication publication, Queries queries)
        {
            InitializeComponent();
            _queries = queries;
            AddPublicationViewModel = new AddPublicationViewModel(publication);
            DataContext = AddPublicationViewModel;
            CbxPublicationType.ItemsSource = queries.GetPublicationTypes();
        }//AddPublicationWindow()

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (AddPublicationViewModel.Publication.PublicationTitle == null || AddPublicationViewModel.Publication.PublicationType == null
                                                                                 || AddPublicationViewModel.Publication.Amount == 0
                                                                                 || AddPublicationViewModel.Publication.Price == 0)
                    throw new Exception($"Добавте данные в поля!");
               
                DialogResult = true;
                Close();
               
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


    }//AddPublicationWindow : Window
}//PostOffice.View
