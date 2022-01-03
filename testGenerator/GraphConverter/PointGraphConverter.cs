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
    class PointGraphConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            

            ObservableCollection<ulong> data =  value as ObservableCollection<ulong>;
            ObservableCollection<DataPoint> points = new ObservableCollection<DataPoint>();

            if (data == null) { return null; }

            int size = (data.Count % 2 == 0) ? data.Count : data.Count - 1;

            for(int i = 0; i < size; i+=2)
            {
                points.Add(new DataPoint(data[i],data[i+1]));
            }

            return points;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
