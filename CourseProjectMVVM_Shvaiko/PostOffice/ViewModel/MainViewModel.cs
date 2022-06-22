using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PostOffice.Command;
using PostOffice.Controller;
using PostOffice.Model;
using PostOffice.MainModel;
using PostOffice.View;


namespace PostOffice.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        //Почтовое отделение
        private  PostOfficeModel _postOffice;

        // имя файла-журнала выполненных операций
        private string _logFileName = @"..\..\LogInfo.log";

        #region классы
        //классы
        private Subscriber _selectedSubscriber;
        private Postman _selectedPostman;
        private Publication _selectedPublication;
        private Sector _selectedSector;

        //выбранный участок
        public Sector SelectedSector
        {
            get => _selectedSector;
            set
            {
                _selectedSector = value;
                OnPropertyChanged("SelectedSector");
            }//set

        }//SelectedSector

        //Выбранный подписчик
        public Subscriber SelectedSubscriber
        {
            get => _selectedSubscriber;
            set
            {
                _selectedSubscriber = value;
                OnPropertyChanged("SelectedSubscriber");
            }//set
        }//SelectedSubscriber

        //Выбранный почтальон
        public Postman SelectedPostman
        {
            get => _selectedPostman;
            set
            {
                _selectedPostman = value;
                OnPropertyChanged("SelectedPostman");
            }//set
        }//SelectedSubscriber

        //выбранное издание
        public Publication SelectedPublication
        {
            get => _selectedPublication;
            set
            {
                _selectedPublication = value;
                OnPropertyChanged("SelectedPublication");
            }//set

        }//SelectedPublication


        #endregion

        #region Коллекции

        //коллекции
        private IEnumerable<Subscriber> _subscribers;
        private IEnumerable<Postman> _postmans;
        private IEnumerable<Publication> _publications;
        private IEnumerable<Sector> _sectors;
        private IEnumerable _subscriptionsNewsPapper;
        private IEnumerable _avgPublicationDurationOfPostOffice;
        private IEnumerable _sectorsInfoReport;

        //Подписчики коллекция
        public IEnumerable<Subscriber> Subscribers
        {
            get => _subscribers;
            set
            {
                _subscribers = value;
                OnPropertyChanged("Subscribers");
            }//set
        }//Subscribers

        //Почтальоны коллекция
        public IEnumerable<Postman> Postmans
        {
            get => _postmans;
            set
            {
                _postmans = value;
                OnPropertyChanged("Postmans");
            }//set
        }//Postmans

        //Издания коллекция
        public IEnumerable<Publication> Publications
        {
            get => _publications;
            set
            {
                _publications = value;
                OnPropertyChanged("Publications");
            }//set

        }//Publications

        //Участки коллекция
        public IEnumerable<Sector> Sectors
        {
            get => _sectors;
            set
            {
                _sectors = value;
                OnPropertyChanged("Sectors");
            }//set

        }//Sectors

        //коллекция подписок клиента на газеты
        public IEnumerable SubscriptionsNewsPapper
        {
            get => _subscriptionsNewsPapper;
            set
            {
                _subscriptionsNewsPapper = value;
                OnPropertyChanged("SubscriptionsNewsPapper");

            }//set

        }//SubscriptionsNewsPapper

        //коллекция средней продолжительности подписок на каждое издание
        public IEnumerable AvgPublicationDurationOfPostOffice
        {
            get => _avgPublicationDurationOfPostOffice;
            set
            {
                _avgPublicationDurationOfPostOffice = value;
                OnPropertyChanged("AvgPublicationDurationOfPostOffice");

            }//set

        }//SubscriptionsNewsPapper

        //коллекция-отчёт по выбранному участку
        public IEnumerable SectorsInfoReport
        {
            get => _sectorsInfoReport;
            set
            {
                _sectorsInfoReport = value;
                OnPropertyChanged("SectorsInfoReport");

            }//set

        }//SubscriptionsNewsPapper
        
        #endregion

        #region дополнительные поля для статусбара

        
        //количество подписок на участке
        private int _subscriptionQuantitysBySector;
        //количество различных изданий
        private int _distinctPublicationsQuantBySector;

        //количество всех экземпляров изданий в отделении
        private int _countTotalPublications;

        //обшее количество экземпляров всех газет
        private int _countTotalPubTypeNewsPappers;

        //обшее количество экземпляров всех журнал
        private int _countTotalPubTypeMagazines;

        //количество наименований газет
        private int _countNewspappresByTitle;

        //количество наименований журналов
        private int _countMagazinesByTitle;

        //Кол-во подписчиков
        private int _countSubscrobers;

        //Кол-во почтальонов
        private int _countPostmans;

        //Кол-во участков
        private int _sectorsCount;

        //количество газет и количество журналов, выписанных на текущий момент подписчиками.
        private int _countSubscribersNewspappers;
        private int _countSubscribersMagazines;

        //участок с максимальным количеством подписок
        private int _maxSubsBySector;

        
        //количество подписок на участке
        public int DistinctPublicationsQuantBySector
        {
            get => _distinctPublicationsQuantBySector;
            set
            {
                _distinctPublicationsQuantBySector = value;
                OnPropertyChanged("DistinctPublicationsQuantBySector");
            }//set

        }//SubscriptionQuantitysBySector

        //количество различных изданий на участке
        public int SubscriptionQuantitysBySector
        {
            get => _subscriptionQuantitysBySector;
            set
            {
                _subscriptionQuantitysBySector = value;
                OnPropertyChanged("SubscriptionQuantitysBySector");
            }//set

        }//SubscriptionQuantitysBySector

        //количество всех экземпляров изданий в отделении
        public int CountTotalPubTypeNewsPappers
        {
            get => _countTotalPubTypeNewsPappers;
            set
            {
                _countTotalPubTypeNewsPappers = value;
                OnPropertyChanged("CountTotalPubTypeNewsPappers");
            }//set
        }//CountTotalPublications

        //обшее количество экземпляров всех газет
        public int CountTotalPublications
        {
            get => _countTotalPublications;
            set
            {
                _countTotalPublications = value;
                OnPropertyChanged("CountTotalPublications");
            }//set

        }//CountTotalPublications

        //обшее количество экземпляров всех журналов
        public int CountTotalPubTypeMagazines
        {
            get => _countTotalPubTypeMagazines;
            set
            {
                _countTotalPubTypeMagazines = value;
                OnPropertyChanged("CountTotalPubTypeMagazines");
            }//set

        }//CountTotalPubTypeMagazines

        //количество наименований газет
        public int CountNewspappresByTitle
        {
            get => _countNewspappresByTitle;
            set
            {
                _countNewspappresByTitle = value;
                OnPropertyChanged("CountNewspappresByTitle");
            }//set

        }//CountNewspappresByTitle

        //количество наименований журналов
        public int CountMagazinesByTitle
        {
            get => _countMagazinesByTitle;
            set
            {
                _countMagazinesByTitle = value;
                OnPropertyChanged("CountMagazinesByTitle");
            }//set

        }//CountTotalMagazinesByTitle

        //Кол-во подписчиков
        public int CountSubscrobers
        {
            get => _countSubscrobers;
            set
            {
                _countSubscrobers = value;
                OnPropertyChanged("CountSubscrobers");
            }//set

        }//CountTotalMagazinesByTitle

        //Кол-во почтальонов
        public int CountPostmans
        {
            get => _countPostmans;
            set
            {
                _countPostmans = value;
                OnPropertyChanged("CountPostmans");
            }//set

        }//CountPostmans

        //Кол-во участков
        public int SectorsCount
        {
            get => _sectorsCount;
            set
            {
                _sectorsCount = value;
                OnPropertyChanged("SectorsCount");
            }//set

        }//CountPostmans

        //количество газет и количество журналов, выписанных на текущий момент подписчиками.
        public int CountSubscribersNewspappers
        {
            get => _countSubscribersNewspappers;
            set
            {
                _countSubscribersNewspappers = value;
                OnPropertyChanged("CountSubscribersNewspappers");
            }//set

        }//CountSubscribersNewspappers

        public int CountSubscribersMagazines
        {
            get => _countSubscribersMagazines;
            set
            {
                _countSubscribersMagazines = value;
                OnPropertyChanged("CountSubscribersMagazines");
            }//set

        }//CountSubscribersNewspappers

        //участок с максимальным количеством подписок
        public int MaxSubsBySector
        {
            get => _maxSubsBySector;
            set
            {
                _maxSubsBySector = value;
                OnPropertyChanged("MaxSubsBySector");
            }//set

        }//CountSubscribersNewspappers
        #endregion

        #region Поля для поиска

        private string _filterText;
        private Predicate<object> _filter;

        private ObservableCollection<Subscriber> _subscribersObservableCollection;
        public ObservableCollection<Subscriber> SubscribersObservableCollection 
        { 
            get=> _subscribersObservableCollection;
            set
            {
                _subscribersObservableCollection = value;
                OnPropertyChanged();
            }//set

        }//SubscribersObservableCollection



        #endregion

        #region Поле-коллекция для корректного вывода подписок клиента

        private ObservableCollection<Subscription> _subscribtionsOfSubscriberCollection;
        
        public ObservableCollection<Subscription> SubscribtionsOfSubscriberCollection
        {
            get => _subscribtionsOfSubscriberCollection;
            set
            {
                _subscribtionsOfSubscriberCollection = value;
                OnPropertyChanged("SubscribtionsOfSubscriberCollection");

            }//set
        }//SubscribtionsOfSubscriberCollection

        #endregion

        //конструктор
        public MainViewModel()
        {
            _postOffice = new PostOfficeModel();
            Subscribers = _postOffice.Queries.GetSabcriber();
            Postmans = _postOffice.Queries.GetPostmans();
            Publications = _postOffice.Queries.GetPublications();
            Sectors = _postOffice.Queries.GetSectors();
            _postOffice.LessPermissible += LessPermissibleEventArgs.Observer;
            SubscribersObservableCollection = _postOffice.GetSubscribers();
            SubscribtionsOfSubscriberCollection = new ObservableCollection<Subscription>();
            FilterText = "";
            StsMainUpdate();
        }//AppViewModel

        #region Команды обработки подписчиков

        // команда добавления подписчика
        private RelayCommand _addSubscriber;
        public RelayCommand AddSubscriber
        {
            get
            {
                return _addSubscriber ??
                       (_addSubscriber = new RelayCommand((o) =>
                       {
                           AddSubcriberWindow addSubcriberWindow = new AddSubcriberWindow(new Subscriber(), new Address(), _postOffice.Queries);
                           if (addSubcriberWindow.ShowDialog() == true)
                           {
                               _postOffice.Queries.AddSubscriber(addSubcriberWindow.AddSubscriberViewModel.Subscriber);
                               SubscribersObservableCollection = _postOffice.GetSubscribers();
                               StsMainUpdate();
                               File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Добавлен подписчик - {addSubcriberWindow.AddSubscriberViewModel.Subscriber.FullNameShort}\r\n");
                           }//if
                       }));
            }//get
        }//AddSubscriber

        // команда редактирования подписчика
        private RelayCommand _redactSubscriber;
        public RelayCommand RedactSubscriber
        {
            get
            {
                return _redactSubscriber ??
                       (_redactSubscriber = new RelayCommand((selectedItem) =>
                       {
                           if (selectedItem == null) return;

                           if (selectedItem is Subscriber subscriber)
                           {
                               Address address = new Address
                               {
                                   Sector = subscriber.Address.Sector,
                                   Street = subscriber.Address.Street,
                                   House = subscriber.Address.House,
                                   Apartment = subscriber.Address.Apartment

                               };
                               Subscriber vm = new Subscriber
                               {
                                   Id = subscriber.Id,
                                   Surname = subscriber.Surname,
                                   Name = subscriber.Name,
                                   Patronymic = subscriber.Patronymic,
                                   Address = subscriber.Address,
                                   PhotoPath = subscriber.PhotoPath

                               };


                               AddSubcriberWindow addSubcriberWindow = new AddSubcriberWindow(vm, address, _postOffice.Queries);
                               if (addSubcriberWindow.ShowDialog() == true)
                               {
                                   _postOffice.Queries.RedactSubscriber(addSubcriberWindow.AddSubscriberViewModel.Subscriber);
                                   File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Внесены изменения в подписчика - {addSubcriberWindow.AddSubscriberViewModel.Subscriber.FullNameShort}\r\n");
                               }//if
                           }//if

                       }));
            }//get
        }//AddSubscriber
        

        #endregion

        #region Команды обработки почтальонов

        
        private RelayCommand _addPostman;
        public RelayCommand AddPostman
        {
            get
            {
                return _addPostman ??
                       (_addPostman = new RelayCommand(o =>
                       {
                           AddPostmanWindow addPostmanWindow = new AddPostmanWindow(new Postman());
                           if (addPostmanWindow.ShowDialog() == true)
                           {
                               _postOffice.Queries.AddPostman(addPostmanWindow.AddPostmanWiewModel.Postman);
                               StsMainUpdate();
                               File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Добавлен почтальон - {addPostmanWindow.AddPostmanWiewModel.Postman.FullNameShort}\r\n");
                           }//if
                       }));
            }//get
        }//AddPostman

        //редактировать почтальона
        private RelayCommand _redactPostman;

        public RelayCommand RedactPostman
        {
            get
            {
                return _redactPostman ??
                       (_redactPostman = new RelayCommand(o =>
                       {
                           if (o == null) return;
                           if (o is Postman postman)
                           {

                               Postman vm = new Postman
                               {
                                   Id = postman.Id,
                                   Surname = postman.Surname,
                                   Name = postman.Name,
                                   Patronymic = postman.Patronymic,
                                   Passport = postman.Passport

                               };
                               
                               AddPostmanWindow addPostmanWindow = new AddPostmanWindow(vm);
                               if (addPostmanWindow.ShowDialog() == true)
                               {
                                   _postOffice.Queries.RedactPostman(addPostmanWindow.AddPostmanWiewModel.Postman);
                                   File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Внесены изменения в почтальона - {addPostmanWindow.AddPostmanWiewModel.Postman.FullNameShort}\r\n");
                               } //if
                           }//if
                       }));
            }//get

        }//RedactPostman

        //удалить почтальона
        private RelayCommand _delPostman;

        public RelayCommand DelPostman
        {
            get
            {
                return _delPostman ??
                       (_delPostman = new RelayCommand(selectedItem =>
                       {
                           if(selectedItem == null)return;
                           if (selectedItem is Postman postman)
                           {
                               try
                               {
                                   if (postman.SectorsCount != 0)
                                       throw new Exception("Перед удалением назначте новых почтальонов на участки!");
                                   _postOffice.Queries.DelPostman(postman);
                                   StsMainUpdate();
                                   File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Удалён почтальон - {postman.FullNameShort}\r\n");
                               }//try
                               catch (Exception e)
                               {
                                   MessageBox.Show(e.Message,
                                       "Внимание!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                               }//catch

                           }//if

                       }));
            }//get

        }//DelPostman


        #endregion

        #region Команды обработки изданий

        private RelayCommand _addPublication;

        public RelayCommand AddPublication
        {
            get
            {
                return _addPublication ??
                       (_addPublication = new RelayCommand(o =>
                       {
                           AddPublicationWindow addPublicationWindow = new AddPublicationWindow(new Publication(), _postOffice.Queries);
                           if (addPublicationWindow.ShowDialog() == true)
                           {
                               _postOffice.Queries.AddPublication(addPublicationWindow.AddPublicationViewModel.Publication);
                               StsMainUpdate();
                               File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Добавленно издание - \"{addPublicationWindow.AddPublicationViewModel.Publication.PublicationTitle}\"\r\n");
                           }//if
                       }));
            }//get

        }//AddPublication

        private RelayCommand _editPublication;

        public RelayCommand EditPublication
        {
            get
            {
                return _editPublication ??
                       (_editPublication = new RelayCommand(selectedItem =>
                       {
                           if(selectedItem == null) return;
                           if (selectedItem is Publication publication)
                           {
                               Publication vm = new Publication
                               {
                                   Id = publication.Id,
                                   PublicationTitle = publication.PublicationTitle,
                                   PublicationIndex = publication.PublicationIndex,
                                   PublicationType = publication.PublicationType,
                                   Price = publication.Price,
                                   Amount = publication.Amount
                               };

                               AddPublicationWindow addPublicationWindow = new AddPublicationWindow(vm, _postOffice.Queries);
                               if (addPublicationWindow.ShowDialog() == true)
                               {
                                   _postOffice.Queries.RedactPublication(addPublicationWindow.AddPublicationViewModel.Publication);
                                   StsMainUpdate();
                                   File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Внесены изменения в издание - \"{addPublicationWindow.AddPublicationViewModel.Publication.PublicationTitle}\"\r\n");
                               }//if
                           }//if
                       }));
            }//get

        }//EditPublication

        #endregion

        #region Обработка подписок

        private RelayCommand _addSubscription;
        public RelayCommand AddSubscription
        {
            get
            {
                return _addSubscription ??
                       (_addSubscription = new RelayCommand((o) =>
                       {
                           if (o == null) return;
                           if (o is Subscriber subscriber)
                           {
                               AddSubscriptionWindow addSubscriptionWindow = new AddSubscriptionWindow(subscriber, new Subscription(), _postOffice.Queries);
                               if (addSubscriptionWindow.ShowDialog() == true)
                               {
                                   _postOffice.AddSubscription(addSubscriptionWindow.AddSubscriptionViewModel.Subscription);
                                   //для обновления количества подписных изданий подписчика в листбоксе
                                   subscriber.QuantitySubs = subscriber.Subscriptions.Count;
                                   SubscribtionsOfSubscriberCollection = _postOffice.GetSubscriptionsOfSubscriber(subscriber);
                                   StsMainUpdate();
                               }//if
                           }//if
                       }));
            }//get
        }//AddSubscriber


        #endregion

        #region Участки

        //команда смены почтальона на участке
        private RelayCommand _changePostmanOfSector;

        public RelayCommand ChangePostmanOfSector
        {
            get
            {
                return _changePostmanOfSector ??
                       (_changePostmanOfSector = new RelayCommand(selectedItem =>
                       {
                           if (selectedItem == null) return;
                           if (selectedItem is Sector sector)
                           {
                               Sector vm = new Sector()
                               {
                                   Id = sector.Id,
                                   Postman = sector.Postman,
                                   NumSector = sector.NumSector
                               };

                               ChangePostmanWindow changePostmanWindow = new ChangePostmanWindow(vm, _postOffice.Queries);
                               if (changePostmanWindow.ShowDialog() == true)
                               {
                                   _postOffice.Queries.RedactSector((Sector)changePostmanWindow.DataContext);
                                   //для обновления количества обслуживаемых участков почтальоном в гриде
                                   sector.Postman.SectorsQuantity = sector.Postman.SectorsCount;
                                   File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Переназначен почтальон на участке - {sector.NumSector}\r\n");
                               }//if
                           }//if
                       }));
            }//get


        }//ChangePostmanOfSector

        #endregion

        #region Дополнительные команды-запросы

        //поиск подписчика в списке
       // private RelayCommand _findSubscriber;

      /*  public RelayCommand FindSubscriber
        {
            get
            {
                return _findSubscriber ??
                       (_findSubscriber = new RelayCommand(o =>
                           {
                               Subscribers = _postOffice.Queries.GetSabcriber()
                                   .ToList().FindAll(x => x != null && x.Surname.ToLower()
                                       .Contains(TxbSurnameNpFilter.Trim().ToLower()));
                           }));
            }//get
            
        }//FindSubscriber*/

        //команда вывода всех подписок  на газеты выбранного подписчика
        private RelayCommand _getNewspappersSubscriber;
        public RelayCommand GetNewsppapersSubscriber
        {
            get
            {
                return _getNewspappersSubscriber ??
                    (_getNewspappersSubscriber = new RelayCommand(selectedItem =>
                    {
                        if (selectedItem == null) return;
                        if (selectedItem is Subscriber subscriber)
                        {
                            SubscriptionsNewsPapper = _postOffice.Queries.GetNewspaperOfSubscriber(subscriber);
                            SubscribtionsOfSubscriberCollection = _postOffice.GetSubscriptionsOfSubscriber(subscriber);
                        }//if
                    }));
            }//get

        }//GetNewspapersSubscriber

        //средний срок подписки каждого вида издания
        private RelayCommand _avgPublicationDuration;
        public RelayCommand AvgPublicationDuration
        {
            get
            {
                return _avgPublicationDuration ??
                       (_avgPublicationDuration = new RelayCommand(o =>
                       {
                           AvgPublicationDurationOfPostOffice = _postOffice.Queries.AvgPublicationDurationSubs();

                       }));
            }//get

        }//GetNewspapersSubscriber

        //команда вывода отчёта в датагрид по выбранному участку
        private RelayCommand _sectorsInfoReportCommand;
        public RelayCommand SectorsInfoReportCommand
        {
            get
            {
                return _sectorsInfoReportCommand ??
                       (_sectorsInfoReportCommand = new RelayCommand(selectedItem =>
                       {
                           if (selectedItem == null) return;
                           if (selectedItem is Sector sector)
                           {
                               SectorsInfoReport = _postOffice.Queries.GetSectorReport(sector);
                               SubscriptionQuantitysBySector = _postOffice.Queries.CountSubscriptionsBySector(sector);
                               DistinctPublicationsQuantBySector =
                                   _postOffice.Queries.GetDistinctPublicationsBySector(sector);
                           }//if

                       }));
            }//get

        }//GetNewspapersSubscriber

        #endregion

        #region Поиск подписчика

        public string FilterText
        {
            get => _filterText;
            set
            {
                if (value == _filterText) return;
                _filterText = value;
                OnPropertyChanged();
                Filter = string.IsNullOrEmpty(_filterText) ? (Predicate<object>)null : IsMatch;
            }//set
        }//FilterText

        public Predicate<object> Filter
        {
            get => _filter;
            private set
            {
                _filter = value;
                OnPropertyChanged();
            }//set

        }//Filter

        private bool IsMatch(object item)
        {
            return IsMatch((Subscriber)item, _filterText);
        }//IsMatch

        private static bool IsMatch(Subscriber item, string filterText)
        {
            if (string.IsNullOrEmpty(filterText))
            {
                return true;
            }

            var surname = item.Surname;
            if (string.IsNullOrEmpty(surname))
            {
                return false;
            }//if

            if (filterText.Length == 1)
            {
                return surname.StartsWith(filterText, StringComparison.OrdinalIgnoreCase);
            }//if

            return surname.IndexOf(filterText, 0, StringComparison.OrdinalIgnoreCase) >= 0;
        }//IsMatch
        
        #endregion

        //команда окрыть журнал
        private RelayCommand _openJournalCommand;
        public RelayCommand OpenJournalCommand
        {
            get
            {
                return _openJournalCommand ??
                       (_openJournalCommand = new RelayCommand(o =>
                       {
                           LogWindow logWindow = new LogWindow(_logFileName);
                           logWindow.ShowDialog();
                           
                       }));
            }//get
        }//AddPostman

        //команда о прогамме
        private RelayCommand _aboutAppCommand;
        public RelayCommand AboutAppCommand
        {
            get
            {
                return _aboutAppCommand ??
                       (_aboutAppCommand = new RelayCommand(o =>
                       {
                           AboutWindow aboutWindow = new AboutWindow();
                           aboutWindow.ShowDialog();

                       }));
            }//get
        }//AddPostman

        //выход из приложения
        private RelayCommand _exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                return _exitCommand ??
                       (_exitCommand = new RelayCommand(o =>
                       {
                           Application.Current.Shutdown();
                       }));
            }//get
        }//AddPostman

        //обновление статус бара
        private void StsMainUpdate()
        {
            CountTotalPublications = _postOffice.Queries.CountTotalPublications();
            CountTotalPubTypeMagazines = _postOffice.Queries.CountTotalJornals();
            CountTotalPubTypeNewsPappers = _postOffice.Queries.CountTotalNewspapers();
            CountNewspappresByTitle = _postOffice.Queries.CountNewspapers();
            CountMagazinesByTitle = _postOffice.Queries.CountJornals();
            CountSubscrobers = _postOffice.Queries.CountSubscribers();
            CountPostmans = _postOffice.Queries.CountPostmans();
            SectorsCount = _postOffice.Queries.CountSectors();
            CountSubscribersNewspappers = _postOffice.Queries.CountSubsNewspapers();
            CountSubscribersMagazines = _postOffice.Queries.CountSubsJornals();
            MaxSubsBySector = _postOffice.Queries.MaxSubscribtionsInOfSector();
        }//stsMainUpdate()



        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged

    }//AppViewModel
}//PostOffice.ViewModel
