using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PostOffice.Converter
{
    public class DateTimeConverter: IValueConverter
    {
        // value      - объект для конвертации - то, что требуется преобразовать
        // targetType - тип, к которому надо преобразовать
        // parameter  - вспомогательный параметр
        // culture    - текущая культура приложения (локализация) 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // return ((DateTime)value).ToString("dd.MM.yyyy");
            return $"{(DateTime)value:d}";
        } // Convert

        // обратную конвертацию из строки в дату не реализуем (сделайте самостоятельно) 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var str = value as string;
                DateTime date = DateTime.Parse(str);
                return date;

            }//if

            return DependencyProperty.UnsetValue;
        } // ConvertBack


    }//DateTimeConverter
}//PostOffice.Converter
