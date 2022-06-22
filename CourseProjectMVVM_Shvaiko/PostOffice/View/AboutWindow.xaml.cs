using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace PostOffice.View
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        
        public AboutWindow()
        {
            InitializeComponent();
            TxbAssembly.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            TxbProduction.Text = Assembly.GetExecutingAssembly().GetName().FullName;
        }//AboutWindow()
    }//AboutWindow : Window
}//PostOffice.View
