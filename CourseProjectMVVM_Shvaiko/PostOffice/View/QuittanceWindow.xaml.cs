using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using PostOffice.Model;

namespace PostOffice.View
{
    /// <summary>
    /// Логика взаимодействия для QuittanceWindow.xaml
    /// </summary>
    public partial class QuittanceWindow : Window
    {
        public QuittanceWindow(Subscription subscription)
        {
            InitializeComponent();
            DataContext = subscription;
        }//QuittanceWindow()

        private void Print_Quittance(object sender, RoutedEventArgs e)
        {
            var dialog = new PrintDialog();
            if (dialog.ShowDialog() == true) // возвращает bool?, поэтому сравнение с true
            {
                dialog.PrintVisual(GridQuittance, "Вывод квитанции на печать");
            }//if

        }//Print_Quittance



    }//QuittanceWindow : Window
}//PostOffice.View
