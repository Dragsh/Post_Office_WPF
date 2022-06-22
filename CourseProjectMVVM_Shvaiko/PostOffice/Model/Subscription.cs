using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.Model
{
    public class Subscription: INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private int _duration;
        
        //идентификатор
        public int Id { get; set; }

        //дата начала подписки
        public DateTime StartDate { get; set; }

        //продолжительность подписки
        public int Duration
        {
            get => _duration;
            set
            {
                if (IsDurationValid(value) && _duration != value) _duration = value;
                _duration = value;
                OnPropertyChanged("Duration");
                OnPropertyChanged($"FullPrice");
            }//set
        }//Duration

        public bool IsDurationValid(int value)
        {
            bool isValid = true;
            if (value.ToString().Contains(" ")  || value.ToString().Any(x => char.IsPunctuation(x.ToString(), 0) ||
                                                      char.IsSymbol(x.ToString(), 0) ||
                                                      char.IsLetter(x.ToString(), 0)))
            {
                AddError("Duration", DURATION_ERROR, false);
                isValid = false;
            }//if
            else RemoveError("Duration", DURATION_ERROR);

            return isValid;
        }//IsNameValid

        public double FullPrice => Duration*Publication.Price;

        //навигационное свойство Publication
        public virtual Publication Publication { get; set; }

        //навигационное свойство Subscriber
        public virtual Subscriber Subscriber { get; set; }



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

        private const string DURATION_ERROR = "Продолжительность издания должна быть положительным числом и не равно нулю";
       


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




    }//Subscribtion
}//PostOffice.Model
