using System;
using System.Collections.Generic;
using System.IO;
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

namespace PostOffice.View
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        private string _fileName;

        public LogWindow()
        {
            InitializeComponent();
        }//LogWindow()

        public LogWindow(string fileName)
        {
            InitializeComponent();
            _fileName = fileName;
        }//LogWindow()

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TbLog.Text = File.ReadAllText(_fileName);
            TbLog.SelectionStart = 0;
            TbLog.SelectionLength = 5;
        }//Window_Loaded

    }//LogWindow : Window
}//PostOffice.View
