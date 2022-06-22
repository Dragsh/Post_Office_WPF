using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace PostOffice.Interface
{
    public class DefaultDialogServise:IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Выбор фото",
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Image-файлы (*.png,*.jpg,*.jpeg )|*.png; *.jpg; *.jpeg |Все файлы (*.*)|*.*",
                FilterIndex = 0
            };
            if (ofd.ShowDialog() != true)
                return false;

            FilePath = ofd.FileName;

            return true;


        }//OpenFileDialog()

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }//ShowMessage

    }//DefaultDialogServise
}// PostOffice.Interface
