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



        public Matrix MatrixData
        {
            get { return (Matrix)GetValue(MatrixProperty); }
            set { SetValue(MatrixProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Matrix.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MatrixProperty =
            DependencyProperty.Register("MatrixData", typeof(Matrix), typeof(MatrixControl), new PropertyMetadata(null));


        private void MatrixDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex().ToString();
        }         

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            MatrixData.AddRow();
            MatrixData.AddCol();
            MatrixDataGrid.ItemsSource = MatrixData.AsDataView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MatrixData.RemoveRow();
            MatrixData.RemoveColumn();
            MatrixDataGrid.ItemsSource = MatrixData.AsDataView();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {         
            MatrixDataGrid.ItemsSource = MatrixData.AsDataView();
        }
    }
}
