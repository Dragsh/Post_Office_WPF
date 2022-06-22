using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.Model
{
    public class Address: INotifyPropertyChanged, INotifyDataErrorInfo // "public"- для работы  "lazy loading" 
    {

        private string _house;
        private int? _apartment;
        private Sector _sector;
        public Address()
        {
            Subscribers = new HashSet<Subscriber>();
        }//Addreses

        //идентификатор
        public int Id { get; set; }

        //номер дома(может быть с буквой)
        public string House 
        { get =>_house;
            set
            {
                if (IsHouseValid(value) && _house != value) _house = value;
                OnPropertyChanged("House");
                OnPropertyChanged($"FullAddress");
            }//set
        }//House

        // Validates the Surname property, updating the errors collection as needed.
        public bool IsHouseValid(string value)
        {
            bool isValid = true;
            if (value.Contains(" ") || value.Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                      char.IsSymbol(x.ToString(), 0)))
            {
                AddError("House", HOUSE_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("House", HOUSE_ERROR);

            return isValid;
        }//IsSurnameValid


        //номер квартиры(квартира может быть null)
        public int? Apartment
        {
            get => _apartment;
            set
            {
                if (IsApartmentValid(value) && _apartment != value) _apartment = value;
                _apartment = value;
                OnPropertyChanged("Apartment");
                OnPropertyChanged($"FullAddress");
              
            }//set
        }//Apartment

        public bool IsApartmentValid(int? value)
        {
            bool isValid = true;
            if (value.ToString().Contains(" ") || value.ToString().Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                      char.IsSymbol(x.ToString(), 0) || 
                                                      char.IsLetter(x.ToString(),0)))
            {
                AddError("Apartment", APARTMENT_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("Apartment", APARTMENT_ERROR);

            return isValid;
        }//IsSurnameValid




        public string FullAddress
        {
            get
            {
                if (_apartment != null)
                    return Street.StreetTitle + ", д." + _house + ", кв." + _apartment;
                return Street.StreetTitle + ", д." + _house;
            }//get
        }// FullAddress


        //навигационные свойства
        // "virtual"- для работы  "lazy loading" 
        // В этом случае нам не потребуется использовать какие-то дополнительные методы, как Include или Load
        public virtual Sector Sector 
        { 
            get => _sector;
            set
            {
                _sector = value;
                OnPropertyChanged("Sector");
            }//set

        }//Sector

        public virtual Street Street { get; set; }

        // связнное свойство для связи один-ко-многим с подписчиками
        public virtual ICollection<Subscriber> Subscribers { get; set; }

        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged

        //реализация INotifyDataErrorInfo
        #region INotifyDataErrorInfo Members 

        private Dictionary<string, List<string>> _errors =
            new Dictionary<string, List<string>>();
        private const string HOUSE_ERROR = "Номер дома не должен содержать пробелы и знаки препинания";
        private const string APARTMENT_ERROR = "Номер квартиры может быть только положительным числом";
        


        // Adds the specified error to the errors collection if it is not 
        // already present, inserting it in the first position if isWarning is 
        // false. Raises the ErrorsChanged event if the collection changes. 
        public void AddError(string propertyName, string error, bool isWarning)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(error))
            {
                if (isWarning) _errors[propertyName].Add(error);
                else _errors[propertyName].Insert(0, error);
                RaiseErrorsChanged(propertyName);
            }//AddError

        }//AddError

        // Removes the specified error from the errors collection if it is
        // present. Raises the ErrorsChanged event if the collection changes.
        public void RemoveError(string propertyName, string error)
        {
            if (_errors.ContainsKey(propertyName) &&
                _errors[propertyName].Contains(error))
            {
                _errors[propertyName].Remove(error);
                if (_errors[propertyName].Count == 0) _errors.Remove(propertyName);
                RaiseErrorsChanged(propertyName);
            }//if
        }//RemoveError

        public void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }//RaiseErrorsChanged

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) ||
                !_errors.ContainsKey(propertyName)) return null;
            return _errors[propertyName];
        }//GetErrors

        public bool HasErrors => _errors.Count > 0;

        #endregion
    }//Address
}//PostOffice.Model
