using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PostOffice.Model;

namespace PostOffice.ViewModel
{
    public class AddPublicationViewModel: INotifyPropertyChanged
    {

        private Publication _publication;

        public Publication Publication
        {
            get => _publication;
            set
            {
                _publication = value;
                OnPropertyChanged("Publication");
            }//set
        }//Publication

        //конструктор
        public AddPublicationViewModel(Publication publication)
        {
            _publication = publication;
        }//AddPublicationViewModel





        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged

    }//AddPublicationViewModel
}//PostOffice.ViewModel

