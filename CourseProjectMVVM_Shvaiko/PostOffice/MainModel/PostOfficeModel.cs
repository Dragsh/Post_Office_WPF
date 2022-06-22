using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PostOffice.Controller;
using PostOffice.Model;

namespace PostOffice.MainModel
{
    // делегат, описывающий обработчик события "Количество издания стало меньше допустимого значения"
    public delegate void LessPermissibleEventHandler(object sender, LessPermissibleEventArgs e);
    public class PostOfficeModel
    {

        // событие
        public event LessPermissibleEventHandler LessPermissible;

        // имя файла-журнала выполненных операций
        private string _logFileName = @"..\..\LogInfo.log";

        //минимальное количество публикации
        public static int MinPublicationQuantity = 5;

        // адресс почты
        public string AddressPostOffice { get; set; }

        // название почты
        public string TitlePostOffice { get; set; }

        //ссылка на контроллер
        public Queries Queries;

        public PostOfficeModel()
        {
            AddressPostOffice = "ул. Сталина, 2";
            TitlePostOffice = "Почта \"Экспресс\"";
            Queries = new Queries();

        }//PostOffice

        #region Подписки
        public void AddSubscription(Subscription subscription)
        {
            try
            {
                if (subscription.Publication.Amount == 0) throw new Exception($"В отделении закончились экземпляры издания \"{subscription.Publication.PublicationTitle}\"! Пополните склад!");
                Queries.AddSubscribtion(subscription);
                Queries.RedactAmountPublication(subscription.Publication.Id);
                if (subscription.Publication.Amount <= MinPublicationQuantity)
                    LessPermissible?.Invoke(this, new LessPermissibleEventArgs(DateTime.Now, subscription.Publication.Amount,
                        subscription.Publication.PublicationTitle));
                File.AppendAllText(_logFileName, $"{DateTime.Now:d} {DateTime.Now:T} - Оформленна подписка клиентом {subscription.Subscriber.FullNameShort} на издание {subscription.Publication.PublicationTitle}\r\n");
            }//try
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message,
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                DateTime now = DateTime.Now;
                File.AppendAllText(_logFileName, $"{now:d} {now:T} - {exeption.Message}\r\n");

            }//catch


        }//AddSubscribtion()

        //вывести подписчиков для поиска
        public ObservableCollection<Subscriber> GetSubscribers()
        {
            ObservableCollection<Subscriber> collection = new ObservableCollection<Subscriber>();
            foreach (var item in Queries.GetSabcriber())
            {
                collection.Add(item);
            }//foreach

            return collection;

        }//GetSubscribers

        //вывести подписки клиента
        public ObservableCollection<Subscription> GetSubscriptionsOfSubscriber(Subscriber subscriber)
        {
            ObservableCollection<Subscription> collection = new ObservableCollection<Subscription>();
            foreach (var item in subscriber.Subscriptions)
            {
                collection.Add(item);
            }//foreach

            return collection;

        }//GetSubscribers

        #endregion








    }//PostOffice
}//PostOffice.MainModel
