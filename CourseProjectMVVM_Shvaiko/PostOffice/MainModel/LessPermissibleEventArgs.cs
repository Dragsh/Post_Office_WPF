using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PostOffice.MainModel
{
    public class LessPermissibleEventArgs:EventArgs
    {
        // точное время события
        public DateTime DateTimeEvent { get; set; }

        //  кол-во издания
        public int Qunatity { get; set; }

        //Название издания
        public string Title { get; set; }

        // конструкторы
        public LessPermissibleEventArgs() : this(default, default, default) { }

        public LessPermissibleEventArgs(DateTime dateTimeEvent, int quantity, string title)
        {
            DateTimeEvent = dateTimeEvent;
            Qunatity = quantity;
            Title = title;
        } // MorePermissibleEventArgs

        // обработчик события
        public static void Observer(object senser, LessPermissibleEventArgs e)
        {
            MessageBox.Show($"Количество издания \"{e.Title}\" в отделении осталось меньше порогового лимита в {PostOfficeModel.MinPublicationQuantity} шт.! Остаток: {e.Qunatity} шт.",
                "Внимание!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            using (StreamWriter sw = new StreamWriter(@"..\..\LogInfo.log", true, Encoding.UTF8))
            {
                sw.WriteLine($"{e.DateTimeEvent} - Количествово издания \"{e.Title}\" в отделении осталось: {e.Qunatity} шт.!");
            } // using
        } // Observer



    }//LessPermissibleEventArgs
}//PostOffice.MainModel
