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
    public class AddSubscriptionViewModel: INotifyPropertyChanged
    {
        private Subscriber _subscriber;
        private Subscription _subscription;
        public Subscriber Subscriber
        {
            get => _subscriber;
            set
            {
                _subscriber = value;
                OnPropertyChanged("Subscriber");
            }//set
        }//Subscriber

        public Subscription Subscription
        {
            get => _subscription;
            set
            {
                _subscription = value;
                OnPropertyChanged("Subscription");
            }//set
        }//Subscriber


        //конструктор
        public AddSubscriptionViewModel(Subscriber subscriber, Subscription subscription)
        {
            _subscriber = subscriber;
            _subscription = subscription;
            _subscription.Subscriber = subscriber;
            _subscription.StartDate = DateTime.Now;
            
        }//AddSubscribtionViewModel()

        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged

    }//AddSubscribtionViewModel
}//PostOffice.ViewModel
