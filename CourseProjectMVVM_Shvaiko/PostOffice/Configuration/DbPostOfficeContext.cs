using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostOffice.Model;

namespace PostOffice.Configuration
{
    public class DbPostOfficeContext:DbContext
    {
        public DbPostOfficeContext(string connectionString)
            : base(connectionString) { }

        public DbPostOfficeContext() : this("dbContextPostOffice") { }

        // отображние таблиц данных
        //свойства для взаимодействия с талицами в бд
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Address> Addreses { get; set; }
        public virtual DbSet<Postman> Postmans { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<PublicationType> PublicationTypes { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }

        // Реализация FluentAPI
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region настройка сущности District

            //настройка макс. длинны названия района
            modelBuilder.Entity<District>()
                .Property(p => p.DistrictTitle)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            // внешние ключи
            // связь один-ко-многим с улицами
            modelBuilder.Entity<District>()
                .HasMany(e => e.Streets)
                .WithRequired(e => e.District).WillCascadeOnDelete(false);
            
            #endregion

            #region настройка сущности Streets
            
            //настройка макс. длинны названия улицы
            modelBuilder.Entity<Street>()
                .Property(p => p.StreetTitle)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            // внешние ключи
            // связь один-ко-многим с адресами
            modelBuilder.Entity<Street>()
                .HasMany(e => e.Addreses)
                .WithRequired(e => e.Street)
                .WillCascadeOnDelete(false);

            #endregion

            #region настройка сущности Postman
            //ФИО
            modelBuilder.Entity<Postman>()
                .Property(p => p.Surname)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200);

            modelBuilder.Entity<Postman>()
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            modelBuilder.Entity<Postman>()
                .Property(p => p.Patronymic)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200);

            //паспорт
            modelBuilder.Entity<Postman>()
                .Property(p => p.Passport)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);


            // внешние ключи
            // связь один-ко-многим с участками
            modelBuilder.Entity<Postman>()
                .HasMany(e => e.Sectors)
                .WithRequired(e => e.Postman)
                .WillCascadeOnDelete(false);

            #endregion

            #region настройка сущности Addreses

            //номер дома
            modelBuilder.Entity<Address>()
                .Property(p => p.House)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(8);
           
            //номер квартиры
            modelBuilder.Entity<Address>()
                .Property(p => p.Apartment).IsOptional();

            // внешние ключи
            // связь один-ко-многим с подписчиками
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Subscribers)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            #endregion

            #region настройка сущности Sectors

            //номер участка
            modelBuilder.Entity<Sector>()
                .Property(p => p.NumSector).IsRequired();
            
            // внешние ключи
            // связь один-ко-многим с адресом
            modelBuilder.Entity<Sector>()
                .HasMany(e => e.Addreses)
                .WithRequired(e => e.Sector)
                .WillCascadeOnDelete(false);


            #endregion

            #region настройка сущности PublicationTypes

            modelBuilder.Entity<PublicationType>()
                .Property(p => p.Title)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            // внешние ключи
            // связь один-ко-многим с Публикациями

            modelBuilder.Entity<PublicationType>()
                .HasMany(e => e.Publications)
                .WithRequired(e => e.PublicationType).
                 WillCascadeOnDelete(false);

            #endregion

            #region настройка сущности Publications

            //название публикации
            modelBuilder.Entity<Publication>()
                .Property(p => p.PublicationTitle)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200);
            //количество экземпляров публикации
            modelBuilder.Entity<Publication>()
                .Property(p => p.Amount).IsRequired();

            //цена за месяц подписки
            modelBuilder.Entity<Publication>()
                .Property(p => p.Price).IsRequired();

            //индекс издания
            modelBuilder.Entity<Publication>()
                .Property(p => p.PublicationIndex).IsRequired();

           // внешние ключи
            // связь один-ко-многим с подписками
            modelBuilder.Entity<Publication>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Publication)
                .WillCascadeOnDelete(false);

            #endregion

            #region настройка сущности Подписчики

            //ФИО
            modelBuilder.Entity<Subscriber>()
                .Property(p => p.Surname)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200);

            modelBuilder.Entity<Subscriber>()
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            modelBuilder.Entity<Subscriber>()
                .Property(p => p.Patronymic)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200);

            

            modelBuilder.Entity<Subscriber>()
                .Property(p => p.PhotoPath).IsOptional();
            // внешние ключи
            // связь один-ко-многим с подписками
            modelBuilder.Entity<Subscriber>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Subscriber)
                .WillCascadeOnDelete(false);

            #endregion

            #region настройка сущности Подписки

            //дата начала подписки
            modelBuilder.Entity<Subscription>().Property(e => e.StartDate)
                .IsRequired();

            //длительность подписки
            modelBuilder.Entity<Subscription>().Property(e => e.Duration)
                .IsRequired();

            
            #endregion


            // унаследованная обработка
            base.OnModelCreating(modelBuilder);

        }//OnModelCreating


    }//DbPostOfficeContext:DbContext
}//PostOffice.Configuration
