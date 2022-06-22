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
    /// Логика взаимодействия для AddPostmanWindow.xaml
    /// </summary>
    public partial class AddPostmanWindow : Window
    {
        public AddPostmanWiewModel AddPostmanWiewModel { get; }

        public AddPostmanWindow(Postman postman)
        {
            InitializeComponent();
            AddPostmanWiewModel = new AddPostmanWiewModel(postman);
            DataContext = AddPostmanWiewModel;
        }//AddPostmanWindow()

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddPostmanWiewModel.Postman.Surname == null || AddPostmanWiewModel.Postman.Name == null || AddPostmanWiewModel.Postman.Patronymic== null)
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




    }//AddPostmanWindow
}//PostOffice.View
