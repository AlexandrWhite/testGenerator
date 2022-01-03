using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using OxyPlot;
using OxyPlot.Series;


namespace testGenerator.GraphConverter
{
    class ColumnGraphConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ulong> data = value as ObservableCollection<ulong>;
            if(data == null) { return null; }
            ObservableCollection<ulong> unique_data = new ObservableCollection<ulong>(data.Distinct());

            List<ColumnItem> items = new List<ColumnItem>();
            
            foreach(ulong element in unique_data)
            {
                items.Add(new ColumnItem(data.Count(item => item == element), unique_data.IndexOf(element))); 
            }

            return items;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
