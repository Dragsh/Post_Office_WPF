using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PostOffice.Model
{
    public class District: INotifyPropertyChanged
    {
        private string _districtTitle;

        public District()
        {
            Streets = new HashSet<Street>();
        }//Districts

        //идентификатор
        public int Id { get; set; }

        //название района
        public string DistrictTitle
        {
            get =>_districtTitle;
            set
            {
                _districtTitle = value;
                OnPropertyChanged("DistrictTitle");
            }//set
        }//DistrictTitle

        // связные свойства для связи один-ко-многим c улицами 
        public virtual ICollection<Street> Streets { get; set; }

        // Событие - реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            // Вызов цепочки обработчиков события при помощи элвис-оператора
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } // OnPropertyChanged
        
    }//District
}//PostOffice.Model
