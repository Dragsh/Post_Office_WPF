using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.Model
{
    public class Sector: INotifyPropertyChanged
    {
        private int _numSector;
        private Postman _postman;
        public Sector()
        {
            Addreses = new HashSet<Address>();
        }//Sectors

        //идентификатор
        public int Id { get; set; }

        //номер участка
        public int NumSector 
        {   
            get => _numSector;
            set
            {
                _numSector = value;
                OnPropertyChanged("NumSector");
            }//set
        }//NumSector

        //навигационное свойство
        public virtual Postman Postman
        {
            get => _postman;
            set
            {
                _postman = value;
                OnPropertyChanged("Postman");
            }//set
        }//Postman

        // связнное свойство для связи один-ко-многим с адресами
        public virtual ICollection<Address> Addreses { get; set; }

        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged

    }//Sector
}//PostOffice.Model
