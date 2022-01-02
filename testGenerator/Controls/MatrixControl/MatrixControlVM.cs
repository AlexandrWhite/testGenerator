using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGenerator.Controls.MatrixControl
{
    class MatrixControlVM : INotifyPropertyChanged
    {
        DataTable mx = new DataTable();

        public MatrixControlVM()
        {
            AddCol();
            AddRow();
        }


        private bool _toggleToRefresh = true;
        public bool toggleToRefresh
        {
            get { return _toggleToRefresh; }
            set
            {
                if (_toggleToRefresh != value)
                {
                    _toggleToRefresh = value;
                    OnPropertyChanged(nameof(toggleToRefresh));
                }
            }
        }


        public DataTable Matrix
        {
            get { return mx; }
        }

        public void AddRow()
        {
            DataRow mr = mx.NewRow();
            mx.Rows.Add(mr);
        }

        public void AddCol()
        {
            toggleToRefresh = false;
            DataColumn dc = new DataColumn();
            dc.DataType = typeof(int);
            dc.DefaultValue = 0;
            dc.ColumnName = mx.Columns.Count.ToString();
            mx.Columns.Add(dc);


            toggleToRefresh = true;
        }

        public void RemoveRow()
        {
            if (mx.Rows.Count > 1)
            {
                mx.Rows.Remove(mx.Rows[mx.Rows.Count - 1]);
            }
        }

        public void RemoveColumn()
        {
            if (mx.Columns.Count > 1)
            {
                toggleToRefresh = false;
                mx.Columns.Remove(mx.Columns[mx.Columns.Count - 1]);
                toggleToRefresh = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
