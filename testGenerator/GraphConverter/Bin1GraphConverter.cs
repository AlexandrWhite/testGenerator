using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using OxyPlot.Series;

namespace testGenerator.GraphConverter
{
    class Bin1GraphConverter : IValueConverter
    {
        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ulong> data = value as ObservableCollection<ulong>;
            List<ColumnItem> items = new List<ColumnItem>();
            List<int> binStr = new List<int>(); 

            for(int i=0;i<data.Count;i++)
            {
                ulong element = data[i];

                if(element == 0) { binStr.Add(0); }

                while (element > 0)
                {
                    binStr.Add((int)(element % 2));
                    element /= 2;
                }
            }

            items.Add(new ColumnItem(binStr.Count(item => item == 1), 1 ));
            items.Add(new ColumnItem(binStr.Count(item => item == 0), 0 ));

            return items;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
