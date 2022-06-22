using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.Model
{
    public class PublicationType: INotifyPropertyChanged
    {
        private string _title;
        public PublicationType()
        {
            Publications = new HashSet<Publication>();
        }//PublicationTypes

        //идентификатор
        public int Id { get; set; }

        //название
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }//set
        }//Title

        // связные свойства для связи один-ко-многим с публикациями
        public virtual ICollection<Publication> Publications { get; set; } // "virtual"- для работы  "lazy loading" 
        // В этом случае нам не потребуется использовать какие-то дополнительные методы, как Include или Load

        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged

    }//PublicationType
}//PostOffice.Model
