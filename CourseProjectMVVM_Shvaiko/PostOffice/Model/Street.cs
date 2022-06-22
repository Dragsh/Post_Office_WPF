using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.Model
{
    public class Street:INotifyPropertyChanged
    {
        private string _streetTitle;
        public Street()
        {
            Addreses = new HashSet<Address>();
        }//Streets

        //идентификатор
        public int Id { get; set; }

        //название улицы
        public string StreetTitle 
        {   get=>_streetTitle;
            set
            {
                _streetTitle = value;
                OnPropertyChanged("StreetTitle");
            }//set
        }//StreetTitle

        //навигационное свойство
        public virtual District District { get; set; }

        // связные свойства для связи один-ко-многим с адресами
        public virtual ICollection<Address> Addreses { get; set; }

        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged



    }//Street
}//PostOffice.Model
