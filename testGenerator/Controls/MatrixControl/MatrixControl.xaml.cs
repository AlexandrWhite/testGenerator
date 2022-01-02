using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testGenerator.Controls.MatrixControl
{
    /// <summary>
    /// Логика взаимодействия для MatrixControl.xaml
    /// </summary>
    public partial class MatrixControl : UserControl
    {
        public MatrixControl()
        {
            InitializeComponent();              
        }



        public DataTable Matrix
        {
            get { return (DataTable)GetValue(MatrixProperty); }
            set { SetValue(MatrixProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Matrix.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MatrixProperty =
            DependencyProperty.Register("Matrix", typeof(DataTable), typeof(MatrixControl), new PropertyMetadata(null));


        private void MatrixDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex().ToString();
        }


        public void AddRow()
        {
            
            DataRow mr = Matrix.NewRow();
            Matrix.Rows.Add(mr);
        }

        public void AddCol()
        {
          
            DataColumn dc = new DataColumn();
            dc.DataType = typeof(int);
            dc.DefaultValue = 0;
            dc.ColumnName = Matrix.Columns.Count.ToString();
            Matrix.Columns.Add(dc);
            MatrixDataGrid.ItemsSource = Matrix.AsDataView();
        }

        public void RemoveRow()
        {
            if (Matrix.Rows.Count > 1)
            {
                Matrix.Rows.Remove(Matrix.Rows[Matrix.Rows.Count - 1]);
            }
        }

        public void RemoveColumn()
        {
            if (Matrix.Columns.Count > 1)
            {                
                Matrix.Columns.Remove(Matrix.Columns[Matrix.Columns.Count - 1]);
                MatrixDataGrid.ItemsSource = Matrix.AsDataView();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            AddRow();
            AddCol();          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RemoveRow();
            RemoveColumn();           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {         
            MatrixDataGrid.ItemsSource = Matrix.AsDataView();
        }
    }
}
