using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostOffice.Model;

namespace PostOffice.Configuration
{
    class InitDbPostOffce: DropCreateDatabaseAlways<DbPostOfficeContext>
    {
        protected override void Seed(DbPostOfficeContext dbPostOfficeContext)
        {
            base.Seed(dbPostOfficeContext);

            #region инициализация таблицы PublicationTypes

            PublicationType[] publicationTypeses =
            {
                new PublicationType{Title = "Газета"},
                new PublicationType{Title = "Журнал"}
            };

            foreach (var publicationType in publicationTypeses) dbPostOfficeContext.PublicationTypes.Add(publicationType);

            #endregion

            #region инициализация таблицы Districts

            District[] districts =
            {
                new District{DistrictTitle = "Будёновский"},
                new District{DistrictTitle = "Ворошиловский"},
                new District{DistrictTitle = "Киевский"},
                new District{DistrictTitle = "Калининский"},
                new District{DistrictTitle = "Куйбышевский"},
                new District{DistrictTitle = "Ленинский"},
                new District{DistrictTitle = "Кировский"},
                new District{DistrictTitle = "Петровский"},
                new District{DistrictTitle = "Пролетарский"},
            };

            foreach (var district in districts) dbPostOfficeContext.Districts.Add(district);

            #endregion

            #region инициализация таблицы Streets

            Street[] streets =
            {
                new Street
                {
                    StreetTitle = "пр.Ильича",
                    District = districts[3]
                },

                new Street
                {
                    StreetTitle = "ул.Артёма",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Краснофлотская",
                    District = districts[3]
                },

                new Street
                {
                    StreetTitle = "ул.Кобозева",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Университетская",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Постышева",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Челюскинцев",
                    District = districts[2]
                },

                new Street
                {
                    StreetTitle = "ул.Фёдора Зайцева",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Щорса",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Ватутина",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Ватутина",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "пр.Гурова",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "пр.Гурова",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Ионова",
                    District = districts[2]
                },

                new Street
                {
                    StreetTitle = "ул.Лагутенко",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "бул.Пушкина",
                    District = districts[1]
                },

                new Street
                {
                    StreetTitle = "ул.Шекспира",
                    District = districts[1]
                },
            };

            foreach (var street in streets) dbPostOfficeContext.Streets.Add(street);

            #endregion

            #region инициализация таблицы Postmans

            Postman[] postmans =
                {
                  new Postman
                  {
                      Surname = "Пуговкин",
                      Name = "Валентин",
                      Patronymic = "Витальевич",
                      Passport = "GH948980"

                  },

                  new Postman
                  {
                      Surname = "Ираклий",
                      Name = "Семён",
                      Patronymic = "Андреевич",
                      Passport = "GH589321"

                  },

                  new Postman
                  {
                      Surname = "Петров",
                      Name = "Андрей",
                      Patronymic = "Викторович",
                      Passport = "ШО857464"

                  },

                  new Postman
                  {
                      Surname = "Андропов",
                      Name = "Виталий",
                      Patronymic = "Иванович",
                      Passport = "123456789"

                  },

                  new Postman
                  {
                      Surname = "Пушилин",
                      Name = "Денис",
                      Patronymic = "Паханович",
                      Passport = "5890789452"

                  },

                  new Postman
                  {
                      Surname = "Терешкин",
                      Name = "Антон",
                      Patronymic = "Владимирович",
                      Passport = "5890789452"

                  },

                  new Postman
                  {
                      Surname = "Бирюков",
                      Name = "Игорь",
                      Patronymic = "Викторович",
                      Passport = "569054985"

                  },

                  new Postman
                  {
                      Surname = "Дедков",
                      Name = "Сергей",
                      Patronymic = "Викторович",
                      Passport = "567885126"

                  },

                  new Postman
                  {
                      Surname = "Дедков",
                      Name = "Сергей",
                      Patronymic = "Викторович",
                      Passport = "567885126"

                  },

                  new Postman
                  {
                      Surname = "Сидоров",
                      Name = "Дмитрий",
                      Patronymic = "Павлович",
                      Passport = "985612358"

                  }

               };

            foreach (var postman in postmans) dbPostOfficeContext.Postmans.Add(postman);

            #endregion

            #region инициализация таблицы Sectors


            Sector[] sectors =
           {

                new Sector
                {
                    NumSector = 283001,
                    Postman = postmans[0]

                },

                new Sector
                {
                    NumSector = 283064,
                    Postman = postmans[0]

                },

                new Sector
                {
                    NumSector = 283010,
                    Postman = postmans[0]
                },

                new Sector
                {
                    NumSector = 283011,
                    Postman = postmans[1]
                },

                new Sector
                {
                    NumSector = 283110,
                    Postman = postmans[1]
                },

                new Sector
                {
                    NumSector = 283111,
                    Postman = postmans[2]
                },

                new Sector
                {
                    NumSector = 283112,
                    Postman = postmans[2]
                },

                new Sector
                {
                    NumSector = 283117,
                    Postman = postmans[3]
                },

                new Sector
                {
                    NumSector = 283012,
                    Postman = postmans[3]
                },

                new Sector
                {
                    NumSector = 283125,
                    Postman = postmans[4]
                },

                new Sector
                {
                    NumSector = 283014,
                    Postman = postmans[4]
                },

                new Sector
                {
                    NumSector = 283015,
                    Postman = postmans[5]
                },

                new Sector
                {
                    NumSector = 283016,
                    Postman = postmans[5]
                },

                new Sector
                {
                    NumSector = 283017,
                    Postman = postmans[6]
                },

                new Sector
                {
                    NumSector = 283018,
                    Postman = postmans[6]
                },

                new Sector
                {
                    NumSector = 283023,
                    Postman = postmans[6]
                },

                new Sector
                {
                    NumSector = 283003,
                    Postman = postmans[0]
                },

                new Sector
                {
                    NumSector = 283030,
                    Postman = postmans[7]
                },

                new Sector
                {
                    NumSector = 283032,
                    Postman = postmans[7]
                },

                new Sector
                {
                    NumSector = 283034,
                    Postman = postmans[7]
                },

                new Sector
                {
                    NumSector = 283037,
                    Postman = postmans[7]
                },

                new Sector
                {
                    NumSector = 283038,
                    Postman = postmans[8]
                },

                new Sector
                {
                    NumSector = 283004,
                    Postman = postmans[8]
                },

                new Sector
                {
                    NumSector = 283044,
                    Postman = postmans[8]
                },

                new Sector
                {
                    NumSector = 283045,
                    Postman = postmans[8]
                },

                new Sector
                {
                    NumSector = 283048,
                    Postman = postmans[9]
                },

                new Sector
                {
                    NumSector = 283049,
                    Postman = postmans[9]
                },

                new Sector
                {
                    NumSector = 283050,
                    Postman = postmans[9]
                },

                new Sector
                {
                    NumSector = 283052,
                    Postman = postmans[9]
                },

                new Sector
                {
                    NumSector = 283054,
                    Postman = postmans[9]
                }

              };

            foreach (var sector in sectors) dbPostOfficeContext.Sectors.Add(sector);

            #endregion

            #region инициализация таблицы Addreses

            Address[] addreses =
                {
                   new Address
                   {
                       House = "28",
                       Apartment = 51,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "30",
                       Apartment = 23,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "28",
                       Apartment = 4,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "28",
                       Apartment = 12,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "28",
                       Apartment = 45,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "28",
                       Apartment = 54,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "28",
                       Apartment = 54,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "28",
                       Apartment = 63,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "28",
                       Apartment = 45,
                       Sector = sectors[16],
                       Street = streets[0]
                   },

                   new Address
                   {
                       House = "108б",
                       Apartment = 45,
                       Sector = sectors[0],
                       Street = streets[1]
                   },

                   new Address
                   {
                       House = "108б",
                       Apartment = 45,
                       Sector = sectors[0],
                       Street = streets[1]
                   },

                   new Address
                   {
                       House = "108б",
                       Apartment = 20,
                       Sector = sectors[0],
                       Street = streets[1]
                   },

                   new Address
                   {
                       House = "108б",
                       Apartment = 54,
                       Sector = sectors[0],
                       Street = streets[1]
                   },

                   new Address
                   {
                       House = "108б",
                       Apartment = 62,
                       Sector = sectors[0],
                       Street = streets[1]
                   },

                   new Address
                   {
                       House = "108б",
                       Apartment = 30,
                       Sector = sectors[0],
                       Street = streets[1]
                   }

               };

            foreach (var address in addreses) dbPostOfficeContext.Addreses.Add(address);

            #endregion

            #region инициализация таблицы Subscribers

            Subscriber[] subscribers =
                {

                   new Subscriber
                   {
                       Surname = "Егоров",
                       Name = "Пётр",
                       Patronymic = "Иванович",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[0],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Егорова",
                       Name = "Валентина",
                       Patronymic = "Павловна",
                       PhotoPath = "../Photos/LitvinaEvelina.png",
                       Address = addreses[0],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Рябошапка",
                       Name = "Виктор",
                       Patronymic = "Гаврилович",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[1],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Беляева",
                       Name = "Антонина",
                       Patronymic = "Ивановна",
                       PhotoPath = "../Photos/TikomirovaUliana.png",
                       Address = addreses[2],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Бурунов",
                       Name = "Владимир",
                       Patronymic = "Петрович",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[3],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Галий",
                       Name = "Дмитрий",
                       Patronymic = "Антонович",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[4],
                      
                   },

                   new Subscriber
                   {
                       Surname = "Софищенко",
                       Name = "Аркадий",
                       Patronymic = "Анатольевич",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[5],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Петров",
                       Name = "Виталий",
                       Patronymic = "Игнатович",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[6],
                      
                   },

                   new Subscriber
                   {
                       Surname = "Ступаков",
                       Name = "Алексей",
                       Patronymic = "Генадьевич",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[7],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Кикабидзе",
                       Name = "Вахтанг",
                       Patronymic = "Илларионович",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[8],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Кикабидзе",
                       Name = "Рашидат",
                       Patronymic = "Усамовна",
                       Address = addreses[8],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Древельков",
                       Name = "Антон",
                       Patronymic = "Степанов",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[9],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Головко",
                       Name = "Агафон",
                       Patronymic = "Эрастович",
                       PhotoPath = "../Photos/ChapkoConstantin.png",
                       Address = addreses[10],
                      
                   },

                   new Subscriber
                   {
                       Surname = "Курбаев",
                       Name = "Виталий",
                       Patronymic = "Игоревич",
                       Address = addreses[11],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Исаев",
                       Name = "Степан",
                       Patronymic = "Викторович",
                       Address = addreses[12],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Минаев",
                       Name = "Виктор",
                       Patronymic = "Викторович",
                       Address = addreses[13],
                       
                   },

                   new Subscriber
                   {
                       Surname = "Минаев",
                       Name = "Виктор",
                       Patronymic = "Викторович",
                       Address = addreses[13],
                    },

                   new Subscriber
                   {
                       Surname = "Платонов",
                       Name = "Эдуард",
                       Patronymic = "Михайлович",
                       Address = addreses[14],

                   }

                };

            foreach (var subscriber in subscribers) dbPostOfficeContext.Subscribers.Add(subscriber);

            #endregion

            #region инициализация таблицы Publications

            Publication[] publications =
                {
                    new Publication
                    {
                        PublicationTitle = "Известия",
                        PublicationIndex = 10076,
                        Price = 60,
                        Amount = 50,
                        PublicationType = publicationTypeses[0]
                    },

                    new Publication
                    {
                        PublicationTitle = "Крестьянка",
                        PublicationIndex = 10112,
                        Price = 120,
                        Amount = 40,
                        PublicationType = publicationTypeses[1]
                    },

                    new Publication
                    {
                        PublicationTitle = "Комсомольская правда",
                        PublicationIndex = 10021,
                        Price = 80,
                        PublicationType = publicationTypeses[0]
                    },

                    new Publication
                    {
                        PublicationTitle = "Выживания в пустошах",
                        PublicationIndex = 10121,
                        Price = 200,
                        Amount = 30,
                        PublicationType = publicationTypeses[1]
                    },

                    new Publication
                    {
                        PublicationTitle = "Наука для всех",
                        PublicationIndex = 10234,
                        Price = 250,
                        Amount = 40,
                        PublicationType = publicationTypeses[1]
                    },

                    new Publication
                    {
                        PublicationTitle = "Желтая пресса",
                        PublicationIndex = 10056,
                        Price = 100,
                        Amount = 50,
                        PublicationType = publicationTypeses[0],
                    },

                    new Publication
                    {
                        PublicationTitle = "Чистая правда",
                        PublicationIndex = 10045,
                        Price = 70,
                        Amount = 20,
                        PublicationType = publicationTypeses[0]
                    },

                    new Publication
                    {
                        PublicationTitle = "Космополитан",
                        PublicationIndex = 10211,
                        Price = 300,
                        Amount = 100,
                        PublicationType = publicationTypeses[1]
                    },

                    new Publication
                    {
                        PublicationTitle = "Популярная механика",
                        PublicationIndex = 10280,
                        Price = 320,
                        Amount = 40,
                        PublicationType = publicationTypeses[1]
                    },

                    new Publication
                    {
                        PublicationTitle = "Старый свет",
                        PublicationIndex = 10067,
                        Price = 100,
                        Amount = 40,
                        PublicationType = publicationTypeses[0]
                    },

                    new Publication
                    {
                        PublicationTitle = "Монголия в цветах",
                        PublicationIndex = 10365,
                        Price = 230,
                        Amount = 40,
                        PublicationType = publicationTypeses[1]
                    },

                    new Publication
                    {
                        PublicationTitle = "Пистолеты и ружья",
                        PublicationIndex = 10255,
                        Price = 400,
                        Amount = 40,
                        PublicationType = publicationTypeses[1]
                    },

                    new Publication
                    {
                        PublicationTitle = "Туманный альбеон",
                        PublicationIndex = 10013,
                        Price = 140,
                        Amount = 40,
                        PublicationType = publicationTypeses[0]
                    }

                };

            foreach (var publication in publications) dbPostOfficeContext.Publications.Add(publication);

            #endregion

            #region инициализация таблицы Subscriptions

            Subscription[] subscriptions =
                {
                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 3,
                       Subscriber = subscribers[0],
                       Publication = publications[0]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 2,
                       Subscriber = subscribers[0],
                       Publication = publications[1],
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 4,
                       Subscriber = subscribers[0],
                       Publication = publications[2],
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 5,
                       Subscriber = subscribers[1],
                       Publication = publications[2],
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 4,
                       Subscriber = subscribers[1],
                       Publication = publications[3],
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 1,
                       Subscriber = subscribers[1],
                       Publication = publications[4],
                       
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 1,
                       Subscriber = subscribers[2],
                       Publication = publications[4]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 2,
                       Subscriber = subscribers[2],
                       Publication = publications[5]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 3,
                       Subscriber = subscribers[2],
                       Publication = publications[6]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 3,
                       Subscriber = subscribers[3],
                       Publication = publications[7]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 4,
                       Subscriber = subscribers[3],
                       Publication = publications[0]
                       
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 4,
                       Subscriber = subscribers[3],
                       Publication = publications[0]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 2,
                       Subscriber = subscribers[4],
                       Publication = publications[8]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 5,
                       Subscriber = subscribers[4],
                       Publication = publications[9]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 5,
                       Subscriber = subscribers[5],
                       Publication = publications[10]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 2,
                       Subscriber = subscribers[5],
                       Publication = publications[11]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 12,
                       Subscriber = subscribers[6],
                       Publication = publications[3]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 12,
                       Subscriber = subscribers[7],
                       Publication = publications[3]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 6,
                       Subscriber = subscribers[7],
                       Publication = publications[12]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 4,
                       Subscriber = subscribers[7],
                       Publication = publications[11]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 4,
                       Subscriber = subscribers[7],
                       Publication = publications[12]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 4,
                       Subscriber = subscribers[8],
                       Publication = publications[4]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 4,
                       Subscriber = subscribers[8],
                       Publication = publications[2]
                       
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 6,
                       Subscriber = subscribers[8],
                       Publication = publications[5]
                       
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 6,
                       Subscriber = subscribers[9],
                       Publication = publications[6]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 6,
                       Subscriber = subscribers[9],
                       Publication = publications[4]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 6,
                       Subscriber = subscribers[10],
                       Publication = publications[3]
                   },

                   new Subscription
                   {
                       StartDate = DateTime.Now,
                       Duration = 6,
                       Subscriber = subscribers[10],
                       Publication = publications[1]
                   }


                };

            foreach (var subscription in subscriptions) dbPostOfficeContext.Subscriptions.Add(subscription);

            #endregion


            dbPostOfficeContext.SaveChanges();

        }//Seed

    }//InitDbPostOffce
}//PostOffice.Configuration
