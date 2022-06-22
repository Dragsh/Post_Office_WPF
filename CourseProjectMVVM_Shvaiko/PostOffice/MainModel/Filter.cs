using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PostOffice.MainModel
{
    public static class Filter
    {
        public static readonly DependencyProperty ByProperty = DependencyProperty.RegisterAttached(
            "By",
            typeof(Predicate<object>),
            typeof(Filter),
            new PropertyMetadata(default(Predicate<object>), OnWithChanged));

        public static void SetBy(ItemsControl element, Predicate<object> value)
        {
            element.SetValue(ByProperty, value);
        }//SetBy

        public static Predicate<object> GetBy(ItemsControl element)
        {
            return (Predicate<object>)element.GetValue(ByProperty);

        }//GetBy

        private static void OnWithChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateFilter((ItemsControl)d, (Predicate<object>)e.NewValue);
        }//OnWithChanged

        private static void UpdateFilter(ItemsControl itemsControl, Predicate<object> filter)
        {
            if (itemsControl.Items.CanFilter)
            {
                itemsControl.Items.Filter = filter;
            }//if
        }//UpdateFilter


    }//Filter
}//PostOffice.MainModel
