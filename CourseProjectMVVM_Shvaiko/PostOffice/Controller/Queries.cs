using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostOffice.Configuration;
using PostOffice.Model;

namespace PostOffice.Controller
{
    public class Queries
    {
        public DbPostOfficeContext _db;

        public Queries()
        {
            Database.SetInitializer(new InitDbPostOffce());
            _db = new DbPostOfficeContext();
            _db.Database.Initialize(false);

        }//Queries()

        #region Подписчики

        //вывод подписчиков из базы
        public IEnumerable<Subscriber> GetSabcriber()
        {
            _db.Subscribers.Load();
            return _db.Subscribers.Local.ToBindingList();
        }//GetSabcriber

        
        //Какие газеты выписывает гражданин с указанной фамилией, именем, отчеством?
        public IEnumerable GetNewspaperOfSubscriber(Subscriber subscriber) =>
                               _db.Subscriptions.Where(s => s.Subscriber.Id == subscriber.Id &&
                                        s.Publication.PublicationType.Id == 1).Select(x => new {

                                            x.Publication.PublicationTitle,
                                            x.Publication.PublicationType.Title,
                                            x.Publication.PublicationIndex
                                            
                                        }).ToList();//GetNewspaperOfSubscriber

      
        //добавить подписчика
        public void AddSubscriber(Subscriber subscriber)
        {
            _db.Subscribers.Add(subscriber);
            _db.SaveChanges();
            
        }//AddSubscriber

        //редактировать подписчика
        public void RedactSubscriber(Subscriber subscriber)
        {
            var sub = _db.Subscribers
                .FirstOrDefault(s => s.Id == subscriber.Id);

            if (sub != null)
            {
                
                sub.Address = subscriber.Address;
                sub.Surname = subscriber.Surname;
                sub.Name = subscriber.Name;
                sub.Patronymic = subscriber.Patronymic;
                sub.PhotoPath = subscriber.PhotoPath;
            }//if
            _db.Entry(sub).State = EntityState.Modified;
            _db.SaveChanges();

        }//RedactPublication

        #endregion

        #region Подписки

        //добавить подписку
        public void AddSubscribtion(Subscription subscription)
        {
            _db.Subscriptions.Add(subscription);
            _db.SaveChanges();

        }//AddSubscriber

        // 6.	Каков средний срок подписки по каждому изданию?
        public IEnumerable AvgPublicationDurationSubs() =>
            (from pubTitle in _db.Subscriptions
                group pubTitle by pubTitle.Publication
                into groupPublication
                select new
                {
                    groupPublication.Key.PublicationTitle,
                    groupPublication.Key.PublicationType.Title,
                    groupPublication.Key.PublicationIndex,
                    AvgDuration = groupPublication.Average(x => x.Duration)

                }).ToList();


        #endregion

        #region Участки

        //редактировать участок
        public void RedactSector(Sector sector)
        {
            var sec = _db.Sectors.FirstOrDefault(s => s.Id == sector.Id);
            if (sec != null)
            {
                
                sec.NumSector = sector.NumSector;
                sec.Postman = sector.Postman;
            }//if
            _db.Entry(sec).State = EntityState.Modified;
            _db.SaveChanges();

        }//RedactSector

        //вывод секторов в комбобокс
        public IEnumerable<Sector> GetSectors()
        {
            _db.Sectors.Load();
            return _db.Sectors.Local.ToBindingList();

        }//GetSector()

        //отчёт
        //Требуется формирование отчета о доставке почтой газет и журналов.
        //Отчет должен быть упорядочен по участкам.
        //Для каждого участка указывается фамилия и инициалы почтальона,
        //обслуживающего участок, и перечень доставляемых изданий
        //(индекс и название издания, адрес доставки, срок подписки).
        //По каждому изданию указывается средний срок подписки и количество экземпляров,
        //а по участку – количество различных подписных изданий

        //получить инфо по участку для отчёта
        public IEnumerable GetSectorReport(Sector sector)
        {
            var result = _db.Subscriptions
                .Where(s => s.Subscriber.Address.Sector.Id == sector.Id).GroupBy(x => x.Publication)
                .Select(s => new
                {
                    s.Key.PublicationTitle,
                    s.Key.PublicationType.Title,
                    s.Key.PublicationIndex,
                    AvgDuration = s.Average(x => x.Duration),
                    CountTitle = s.Count()
                    
                }).ToList();
            
            return result;
        }// GetReport

        //количество подписок на участке
        public int CountSubscriptionsBySector(Sector sector) => _db.Subscriptions
            .Count(x => x.Subscriber.Address.Sector.Id == sector.Id);

        //количество различных подписных изданий на участке 
        public int GetDistinctPublicationsBySector(Sector sector) => _db.Subscriptions
            .Where(x => x.Subscriber.Address.Sector.Id == sector.Id)
            .GroupBy(x => x.Publication.PublicationTitle).Count();
        
        #endregion

        #region Улицы

        //вывод улиц в комбобокс
        public IEnumerable<Street> GetStreets()
        {
            _db.Streets.Load();
            return _db.Streets.Local.ToBindingList();

        }//GetStreets()

        #endregion

        #region Почтальоны

        public IEnumerable<Postman> GetPostmans()
        {
            _db.Postmans.Load();
            return _db.Postmans.Local.ToBindingList();

        }//GetSector()

        public void AddPostman(Postman postman)
        {
            _db.Postmans.Add(postman);
            _db.SaveChanges();

        }//AddSubscriber

        public void RedactPostman(Postman postman)
        {
            var post = _db.Postmans
                .FirstOrDefault(p => p.Id == postman.Id);

            if (post != null)
            {
                post.Surname = postman.Surname;
                post.Name = postman.Name;
                post.Patronymic = postman.Patronymic;
                post.Passport = postman.Passport;
            }//if
            _db.Entry(post).State = EntityState.Modified;
            _db.SaveChanges();

        }//RedactPublication

        public void DelPostman(Postman postman)
        {
            _db.Postmans.Remove(postman);
            _db.SaveChanges();

        }//DelPostman

        #endregion

        #region Издания
        public IEnumerable<Publication> GetPublications()
        {
            _db.Publications.Load();
            return _db.Publications.Local.ToBindingList();

        }//GetPublications()

        public void AddPublication(Publication publication)
        {
            _db.Publications.Add(publication);
            _db.SaveChanges();

        }//AddPublication

        public void RedactPublication(Publication publication)
        {
            var pub = _db.Publications
                .FirstOrDefault(p => p.Id == publication.Id);

            if (pub != null)
            {
                pub.PublicationTitle = publication.PublicationTitle;
                pub.PublicationIndex = publication.PublicationIndex;
                pub.Amount = publication.Amount;
                pub.Price = publication.Price;
                pub.PublicationType = publication.PublicationType;
            }//if
            _db.Entry(pub).State = EntityState.Modified;
            _db.SaveChanges();

        }//RedactPublication

        //редактировать количество публикации на складе при оформлении подписки
        public void RedactAmountPublication(int id)
        {
            Publication publication = _db.Publications.First(x => x.Id == id);

            publication.Amount = publication.Amount - 1;
            _db.Entry(publication).State = EntityState.Modified;
            _db.SaveChanges();
        }//RedactDurationPublication

        #endregion

        #region Вид издания
        public IEnumerable<PublicationType> GetPublicationTypes()
        {
            _db.PublicationTypes.Load();
            return _db.PublicationTypes.Local.ToBindingList();

        }//GetPublications()


        #endregion

        #region Для статус бара
        //общее количество экземпляров всех изданий в отделении
        public int CountTotalPublications() =>
            _db.Publications
                .Sum(p => p.Amount);

        //обшее количество экземпляров всех газет
        public int CountTotalNewspapers() =>
            _db.Publications.Where(p => p.PublicationType.Id == 1).Sum(p => p.Amount);

        //обшее количество экземпляров всех журналов
        public int CountTotalJornals() =>
          _db.Publications.Where(p => p.PublicationType.Id == 2).Sum(p => p.Amount);

        //Кол-во наименований газет
        public int CountNewspapers() =>
            _db.Publications.Count(p => p.PublicationType.Id == 1);

        //Кол-во наименований журналов
        public int CountJornals() =>
            _db.Publications.Count(p => p.PublicationType.Id == 2);

        //Кол-во подписчиков
        public int CountSubscribers() =>
           _db.Subscribers.Count();

        //Кол-во почтальонов
        public int CountPostmans() =>
            _db.Postmans.Count();

        //количество участков
        public int CountSectors() =>
            _db.Sectors.Count();

        //количество газет и количество журналов, выписанных на текущий момент подписчиками.
        public int CountSubsNewspapers() =>
           _db.Subscriptions.Count(s => s.Publication.PublicationType.Id == 1);

        public int CountSubsJornals() =>
            _db.Subscriptions.Count(s => s.Publication.PublicationType.Id == 2);

        //5.	На каком участке количество экземпляров подписных изданий максимально?
        public int MaxSubscribtionsInOfSector()
        {

            var query = (from sectors in _db.Subscribers
                group sectors by sectors.Address.Sector.NumSector
                into groupSector
                select new
                {
                    Sector = groupSector.Key,
                    CountSubs = groupSector.Sum(x => x.Subscriptions.Count)

                }).ToList();

            var grouped = query.ToLookup(x => x.CountSubs);
            var maxCount = grouped.Max(x => x.Key);
            var sector = query.Where(x => x.CountSubs == maxCount).Select(x => x.Sector).ToList();
            return sector.First();

        }//MaxSubscribtionsInOfSector()




        #endregion

        

    }//Queries
}//PostOffice.Controller
