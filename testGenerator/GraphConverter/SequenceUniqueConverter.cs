using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using OxyPlot;

namespace testGenerator.GraphConverter
{
    class SequenceUniqueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ulong> data = value as ObservableCollection<ulong>;
            if(data == null) { return null; }
            ObservableCollection<ulong> unique_data = new ObservableCollection<ulong>(data.Distinct());
            return unique_data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
