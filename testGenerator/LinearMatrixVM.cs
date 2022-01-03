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
        Matrix a;
        Matrix x0;
        Matrix b;

        Matrix curr;

        int p; 

        public LinearMatrixVM()
        {
            a = new Matrix(1,1);
            x0 = new Matrix(1,1);
            b = new Matrix(1,1);
            curr = new Matrix(1, 1);

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

        public Matrix A { get { return a; } }
        public Matrix B { get { return b; } }
        public Matrix X0 { get { return x0; } }
        public int P
        {
            get { return p; }
            set { p = value; }
        }


        public override void Next()
        {           
            currentItem = MatrixToInt(curr,p);
            
            OnPropertyChanged(nameof(currentItem));
            OnPropertyChanged(nameof(VisualCurrentItem));
        }

        public override void Reset()
        {
            
            currentItem = MatrixToInt(x0,p);
            OnPropertyChanged(nameof(currentItem));
            OnPropertyChanged(nameof(VisualCurrentItem));
        }

        protected override void CurrentItemToVisualCurrentItem()
        {
            Grid gr = new Grid();

            ColumnDefinition cd = new ColumnDefinition();
            cd.Width = System.Windows.GridLength.Auto;

           

            gr.ColumnDefinitions.Add(new ColumnDefinition());
            gr.ColumnDefinitions.Add(cd);



            DataGrid dg = new DataGrid();
            dg.AutoGenerateColumns = true;

            if ((int)currentItem != 0)
            {
                curr = (a * curr + b)%p;
            }
            else
            {
                curr = x0;
            }
          
            dg.ItemsSource = curr.AsDataView();
            dg.CanUserAddRows = false;
            

            TextBlock tb = new TextBlock();
            tb.Text = currentItem.ToString();
            tb.Margin = new System.Windows.Thickness(20, 20, 20, 20);
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            Grid.SetColumn(dg,1);
            Grid.SetColumn(tb, 0);

            gr.Children.Add(dg);
            gr.Children.Add(tb);
            visualCurrentItem = gr;
        }

        private int MatrixToInt(Matrix m1,int bas)
        {
            int num = 0;
            int t = 0;
            for(int i = 0; i < m1.Rows.Count; i++)
            {
                for(int j = 0; j < m1.Columns.Count; j++)
                {
                    num += (int)Math.Pow(bas,t)*(int)m1.Rows[i][j];
                }
            }
            return num;
        }
    }
}
