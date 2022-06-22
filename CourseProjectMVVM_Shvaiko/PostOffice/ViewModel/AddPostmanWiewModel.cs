using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PostOffice.Controller;
using PostOffice.Model;

namespace PostOffice.ViewModel
{
    public class AddPostmanWiewModel:INotifyPropertyChanged
    {
       
        private Postman _postman;

        public Postman Postman
        {
            get => _postman;
            set
            {
                _postman = value;
                OnPropertyChanged("Postman");
            }//set
        }//Subscriber

        public AddPostmanWiewModel(Postman postman)
        {
            _postman = postman;
        }//AddPostmanWiewModel

        

        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged

    }//AddPostmanWiewModel
}//PostOffice.ViewModel
