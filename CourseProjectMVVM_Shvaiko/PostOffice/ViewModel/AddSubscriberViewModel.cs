using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PostOffice.Command;
using PostOffice.Controller;
using PostOffice.Interface;
using PostOffice.Model;

namespace PostOffice.ViewModel
{
    public class AddSubscriberViewModel: INotifyPropertyChanged
    {
        //контроллер
        private Queries _queries;
        private Subscriber _subscriber;
        private Address _address;
        //диалог выбора фото
        IDialogService _dialogService;
        public Subscriber Subscriber
        {
            get => _subscriber;
            set
            {
                _subscriber = value;
                OnPropertyChanged("Subscriber");
            }//set
        }//Subscriber

        public Address Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }//set
        }//Address

       
        //конструктор
        public AddSubscriberViewModel(Queries queries, Address address, Subscriber subscriber, IDialogService dialogService)
        {
            _queries = queries;
            Subscriber = subscriber;
            Address = address;
            _dialogService = dialogService;
        }//AddSubscriberViewModel

        //команда добавления фото
        private RelayCommand _openPhotoCommand;

        public RelayCommand OpenPhotoCommand
        {
            get
            {
                return _openPhotoCommand ??
                       (_openPhotoCommand = new RelayCommand(o =>
                       {
                           try
                           {
                               if (_dialogService.OpenFileDialog())
                                   Subscriber.PhotoPath = _dialogService.FilePath;
                               
                           }//try
                           catch (Exception e)
                           {

                               _dialogService.ShowMessage(e.Message);
                           }//catch


                       }));
            }//get

        }//OpenPhotoCommand


        // команда добавления адреса в подписчика и базу
        private RelayCommand _getSubscriber;
        public RelayCommand GerSubscriber
        {
            get
            {
                return _getSubscriber ??
                       (_getSubscriber = new RelayCommand((o) =>
                       {
                           try
                           {
                               if(Address.Apartment == null || Address.House == null || Address.Sector ==null || Address.Street == null)
                                   throw new Exception($"Добавьте данные в поля адреса!");
                               //Ищем введённый адрес в базе
                               Address address = _queries._db.Addreses
                                   .FirstOrDefault(x => x.Sector.Id == Address.Sector.Id && x.Street.Id == Address.Street.Id
                                                                                         && x.Apartment == Address.Apartment
                                                                                         && x.House == Address.House);
                               //Если такого адреса нет в базе
                               if (address == null)
                               {
                                   _queries._db.Addreses.Add(Address);
                                   _queries._db.SaveChanges();
                                   Subscriber.Address = _queries._db.Addreses.First(x => x.Sector.Id == Address.Sector.Id
                                                                                         && x.Street.Id == Address.Street.Id
                                                                                         && x.Apartment == Address.Apartment
                                                                                         && x.House == Address.House);
                               }//if
                               else
                               {
                                   Subscriber.Address = address;
                               }//else

                               MessageBox.Show("Адрес добавлен!",
                                   "Иннформация", MessageBoxButton.OK, MessageBoxImage.Information);

                               
                           } //try
                           catch(Exception exeption)
                           {
                               MessageBox.Show(exeption.Message,
                                   "Внимание!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                           }//catch

                           

                       }));
            }//get
        }//AddSubscriber

        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged



    }//AddSubscriberViewModel
}//PostOffice.ViewModel
