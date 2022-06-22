using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.Model
{
    public class Publication: INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string _publicationTitle;
        private int _publicationIndex;
        private double _price;
        private int _amount;

        public Publication()
        {
            Subscriptions = new HashSet<Subscription>();
        }//Publications

        //идентификатор
        public int Id { get; set; }

        //название издания
        public string PublicationTitle
        {
            get => _publicationTitle;
            set
            {
                _publicationTitle = value;
                OnPropertyChanged("PublicationTitle");
            }//set
        }//Title

        //индекс издания
        public int PublicationIndex
        {
            get => _publicationIndex;
            set
            {
                if (IsPublicationIndexValid(value) && _publicationIndex != value) _publicationIndex = value;
                OnPropertyChanged("PublicationIndex");
            }//set
        }//PublicationIndex

        // Validates the Surname property, updating the errors collection as needed.
        public bool IsPublicationIndexValid(int value)
        {
            bool isValid = true;
            if (value.ToString().Contains(" ") || value.ToString().Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                      char.IsSymbol(x.ToString(), 0)))
            {
                AddError("PublicationIndex", PUBLICATIONINDEX_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("PublicationIndex", PUBLICATIONINDEX_ERROR);

            return isValid;
        }//IsSurnameValid


        //цена месячной подписки на издание
        public double Price 
        { 
            get => _price;
            set
            {
                if (IsPriceValid(value) && _price != value) _price = value;
                OnPropertyChanged("Price");
            }//set
        }//Price

        public bool IsPriceValid(double value)
        {
            bool isValid = true;
            if (value.ToString(CultureInfo.InvariantCulture).Contains(" ") || value == 0 || value.ToString(CultureInfo.InvariantCulture).Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                                                                                                                  char.IsSymbol(x.ToString(), 0)
                                                                                                                                                  || char.IsLetter(x.ToString(),0)))
            {
                AddError("Price", PRICE_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("Price", PRICE_ERROR);

            return isValid;
        }//IsSurnameValid


        //количество публикаций в отделении
        public int Amount
        {
            get => _amount;
            set
            {
                if (IsAmountValid(value) && _amount != value) _amount = value;
                OnPropertyChanged("Amount");
            }//set
        }//Amount

        public bool IsAmountValid(int value)
        {
            bool isValid = true;
            if (value.ToString().Contains(" ") || value.ToString().Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                                            char.IsSymbol(x.ToString(), 0)
                                                                            || char.IsLetter(x.ToString(),0)))
            {
                AddError("Amount", AMOUNT_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("Amount", AMOUNT_ERROR);

            if (value == 0) AddError("Amount", AMOUNT_WARNING, true);
            else RemoveError("Amount", AMOUNT_WARNING);

            return isValid;
        }//IsSurnameValid

        //навигационное свойство
        // "virtual"- для работы  "lazy loading" 
        // В этом случае нам не потребуется использовать какие-то дополнительные методы, как Include или Load
        public virtual PublicationType PublicationType { get; set; }

        // связнное свойство для связи один-ко-многим с подписками
        public virtual ICollection<Subscription> Subscriptions { get; set; }

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

        private const string PUBLICATIONINDEX_ERROR = "Индекс издания не должен содержать пробелы и знаки препинания";
        private const string PRICE_ERROR = "Стоимость подписки не может быть отрицательным, равняться нулю, содержать буквы или другие символы";
        private const string AMOUNT_ERROR = "Количество изданий не может быть отрицательным, содержать буквы или другие символы";
        private const string AMOUNT_WARNING = "Количество изданий не может равняться нулю";

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


    }//Publication
}//PostOffice.Model
