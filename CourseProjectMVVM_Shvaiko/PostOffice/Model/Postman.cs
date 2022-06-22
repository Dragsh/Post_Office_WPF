using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.Model
{
    public class Postman: INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string _passport;
        private string _surname;
        private string _name;
        private string _patronymic;
        private int _sectorsQuantity;

        public Postman()
        {
            Sectors = new HashSet<Sector>();
        }//Postmans

        //идентификатор
        public int Id { get; set; }

        //серия и номер паспорта
        public string Passport 
        {  
            get => _passport;
            set
            {
                if (IsPassportValid(value) && _passport != value) _passport = value;
                OnPropertyChanged("Passport");
            }//set

        }//Passport

        public bool IsPassportValid(string value)
        {
            bool isValid = true;
            if (value.Contains(" ") || value.Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                      char.IsSymbol(x.ToString(), 0)))
            {
                AddError("Passport", PASSPORT_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("Passport", PASSPORT_ERROR);

            return isValid;
        }//IsSurnameValid




        //ФИО
        public string Surname
        {
            get => _surname;
            set
            {
                if (IsSurnameValid(value) && _surname != value) _surname = value;
                OnPropertyChanged("Surname");
                OnPropertyChanged($"FullName");
                OnPropertyChanged($"FullNameShort");
            }//set
        }//Surname

        // Validates the Surname property, updating the errors collection as needed.
        public bool IsSurnameValid(string value)
        {
            bool isValid = true;
            if (value.Contains(" ") || value.Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                      char.IsSymbol(x.ToString(), 0) ||
                                                      char.IsDigit(x.ToString(), 0)))
            {
                AddError("Surname", Surname_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("Surname", Surname_ERROR);

            return isValid;
        }//IsSurnameValid

        public string Name
        {
            get => _name;
            set
            {
                if (IsNameValid(value) && _name != value) _name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged($"FullName");
                OnPropertyChanged($"FullNameShort");
            }//set
        }//Name

        public bool IsNameValid(string value)
        {
            bool isValid = true;
            if (value.Contains(" ") || value.Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                      char.IsSymbol(x.ToString(), 0) ||
                                                      char.IsDigit(x.ToString(), 0)))
            {
                AddError("Name", NAME_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("Name", NAME_ERROR);

            return isValid;
        }//IsNameValid


        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (IsPatronymicValid(value) && _patronymic != value) _patronymic = value;
                OnPropertyChanged("Patronymic");
                OnPropertyChanged($"FullName");
                OnPropertyChanged($"FullNameShort");
            }//set
        }//Patronymic

        public bool IsPatronymicValid(string value)
        {
            bool isValid = true;
            if (value.Contains(" ") || value.Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                      char.IsSymbol(x.ToString(), 0) ||
                                                      char.IsDigit(x.ToString(), 0)))
            {
                AddError("Patronymic", PATRONYMIC_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("Patronymic", PATRONYMIC_ERROR);

            return isValid;
        }//IsNameValid


        public string FullName => _surname + " " + _name + " " + _patronymic;
        public string FullNameShort => _surname + " " + _name[0] + ". " + _patronymic[0] + ".";

        public int SectorsCount => Sectors.Count;

        public int SectorsQuantity
        {
            get => _sectorsQuantity;
            set
            {
                _sectorsQuantity = value;
                OnPropertyChanged("SectorsQuantity");
                OnPropertyChanged($"SectorsCount");
            }//set

        }//SectorsQuantity

        // связные свойства для связи один-ко-многим c участками
        public virtual ICollection<Sector> Sectors { get; set; }

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

        private const string NAME_ERROR = "Имя не должно содержать пробелы и знаки препинания";
        private const string PATRONYMIC_ERROR = "Отчество не должно содержать пробелы и знаки препинания";
        private const string Surname_ERROR = "Фамилия не должна содержать пробелы и знаки препинания";
        private const string PASSPORT_ERROR = "Паспорт не должен содержать пробелы, знаки препинания и другие символы";

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



    }//Postman
}//PostOffice.Model
