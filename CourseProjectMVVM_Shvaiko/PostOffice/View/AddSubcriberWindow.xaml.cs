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
using Microsoft.Win32;
using PostOffice.Controller;
using PostOffice.Interface;
using PostOffice.Model;
using PostOffice.ViewModel;

namespace PostOffice.View
{
    /// <summary>
    /// Логика взаимодействия для AddSubcriberWindow.xaml
    /// </summary>
    public partial class AddSubcriberWindow : Window
    {
        
        private  Queries _queries;
        public AddSubscriberViewModel AddSubscriberViewModel{ get; }
        public AddSubcriberWindow(Subscriber subscriber, Address address, Queries queries)
        {

            InitializeComponent();
            AddSubscriberViewModel = new AddSubscriberViewModel(queries, address, subscriber, new DefaultDialogServise());
            DataContext = AddSubscriberViewModel;
            _queries = queries;
            CbxSector.ItemsSource = _queries.GetSectors();
            CbxStreet.ItemsSource = _queries.GetStreets();
            
        }//InitializeComponent();

        
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddSubscriberViewModel.Subscriber.Surname == null || AddSubscriberViewModel.Subscriber.Name == null || AddSubscriberViewModel.Subscriber.Patronymic == null)
                    throw new Exception($"Добавте данные в поля!");
                if (AddSubscriberViewModel.Subscriber.Address == null)
                    throw new Exception($"Добавте адрес в базу данных!");
                
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

        #region Валидация
        //проверка на ввод только цифр
        private void txb_PreviewTextInput(object sender, TextCompositionEventArgs e)
            => e.Handled = !char.IsDigit(e.Text, 0);

        //ввод вещественных чисел
        private void txbDouble_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int temp) && e.Text != ".";
        }//txbDouble_PreviewTextInput

        //ввод только букв и тире
        private void txbChar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0) && e.Text != "-";
        }//txbDouble_PreviewTextInput

        //ввод только букв и цифр
        private void txbCharInt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = char.IsPunctuation(e.Text, 0);
        }//txbDouble_PreviewTextInput

        //только буквы
        private void txbChar_PreviewTextInputOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }//txbDouble_PreviewTextInput

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }//TextBox_PreviewKeyDown

        // обработчик события валидации - выводит сообщение об ошибке
        private void TextBox_Input_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show($"{e.Error.ErrorContent}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        } // Input_Error

        #endregion




        
    }//AddSubcriberWindow : Window
}//PostOffice.View
