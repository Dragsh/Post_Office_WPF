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

namespace PostOffice.View
{
    /// <summary>
    /// Логика взаимодействия для ChangePostmanWindow.xaml
    /// </summary>
    public partial class ChangePostmanWindow : Window
    {
        
        public ChangePostmanWindow(Sector sector, Queries queries)
        {
            InitializeComponent();
            DataContext = sector;
            CbxPostman.ItemsSource = queries.GetPostmans();
        }//ChangePostmanWindow()

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = true;
            Close();

        }//BtnSave_Click

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();

        }//BtnCancel_Click



    }//ChangePostmanWindow : Window
}//PostOffice.View
