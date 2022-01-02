using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace testGenerator.LinearMatrixGenerator
{
    class LinearMatrixVM : GeneratorVM
    {
        DataTable a;
        DataTable x0;
        DataTable b;

        int p; 

        public LinearMatrixVM()
        {
            a = new DataTable();
            x0 = new DataTable();
            b = new DataTable();

            currentItem = x0;
            p = 2;

            DataColumn dc = new DataColumn();
            dc.DataType = typeof(int);
            dc.DefaultValue = 0;
            dc.ColumnName = a.Columns.Count.ToString();
            a.Columns.Add(dc);

            DataColumn dc1 = new DataColumn();
            dc1.DataType = typeof(int);
            dc1.DefaultValue = 0;
            dc1.ColumnName = b.Columns.Count.ToString();
            b.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn();
            dc2.DataType = typeof(int);
            dc2.DefaultValue = 0;
            dc2.ColumnName = x0.Columns.Count.ToString();
            x0.Columns.Add(dc2);


            a.Rows.Add(a.NewRow());
            b.Rows.Add(b.NewRow());
            x0.Rows.Add(x0.NewRow());


        }

        public DataTable A { get { return a; } }
        public DataTable B { get { return b; } }
        public DataTable X0 { get { return x0; } }
        public int P
        {
            get { return p; }
            set { p = value; }
        }


        public override void Next()
        {           
            currentItem = 10;                    
            OnPropertyChanged(nameof(currentItem));
            OnPropertyChanged(nameof(VisualCurrentItem));
        }

        public override void Reset()
        {
            currentItem = 10;
            OnPropertyChanged(nameof(currentItem));
            OnPropertyChanged(nameof(VisualCurrentItem));
        }

        protected override void CurrentItemToVisualCurrentItem()
        {
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;

            DataGrid dg = new DataGrid();
            dg.AutoGenerateColumns = true;
            dg.ItemsSource = x0.AsDataView();
            dg.CanUserAddRows = false;
            TextBlock tb = new TextBlock();
            tb.Text = "111";
            tb.Margin = new System.Windows.Thickness(20, 20, 20, 20);
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            sp.Children.Add(dg);
            sp.Children.Add(tb);
            visualCurrentItem = sp;
        }
    }
}
