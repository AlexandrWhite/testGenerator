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
    class Bin2GraphConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ulong> data = value as ObservableCollection<ulong>;
            List<ColumnItem> items = new List<ColumnItem>();
            List<int> binStr = new List<int>();

            for (int i = 0; i < data.Count; i++)
            {
                ulong element = data[i];

                if (element == 0) { binStr.Add(0); }

                while (element > 0)
                {
                    binStr.Add((int)(element % 2));
                    element /= 2;
                }
            }

            

            int cnt00 = 0;
            int cnt01 = 0;
            int cnt10 = 0;
            int cnt11 = 0;

            for(int i = 0; i < binStr.Count()-1; i++)
            {
                Console.WriteLine($"{binStr[i]} {binStr[i+1]}\n");
                if (binStr[i] == 0 && binStr[i+1] == 0) { cnt00++; }
                if (binStr[i] == 0 && binStr[i+1] == 1) { cnt01++; }
                if (binStr[i] == 1 && binStr[i+1] == 0) { cnt10++; }
                if (binStr[i] == 1 && binStr[i+1] == 1) { cnt11++; }
            }

            

            items.Add(new ColumnItem(cnt00, 0));
            items.Add(new ColumnItem(cnt01, 1));
            items.Add(new ColumnItem(cnt10, 2));
            items.Add(new ColumnItem(cnt11, 3));


            return items;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
