using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGenerator
{
    public class Matrix:DataTable
    {
        public Matrix(int rows=0,int cols=0)
        {
            for (int i = 0; i < rows; i++)
            {
                AddRow();
            }

            for (int i = 0; i < cols; i++)
            {
                AddCol();
            }
        }



        public void AddRow()
        {
            DataRow mr = NewRow();
            Rows.Add(mr);
        }

        public void AddCol()
        {           
            DataColumn dc = new DataColumn();
            dc.DataType = typeof(int);
            dc.DefaultValue = 0;
            dc.ColumnName = Columns.Count.ToString();
            Columns.Add(dc);            
        }

        public void RemoveRow()
        {
            if (Rows.Count > 1)
            {
                Rows.Remove(Rows[Rows.Count - 1]);
            }
        }

        public void RemoveColumn()
        {
            if (Columns.Count > 1)
            {
                Columns.Remove(Columns[Columns.Count - 1]);               
            }
        }

        public static Matrix operator + (Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(m1.Rows.Count,m1.Columns.Count);
            for(int i = 0; i < m1.Rows.Count; i++)
            {
                for(int j = 0; j < m1.Columns.Count; j++)
                {
                    res.Rows[i][j] = (int)m1.Rows[i][j] + (int)m2.Rows[i][j]; 
                }
            }
            return res;
        }

        public static Matrix operator * (Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(m1.Rows.Count, m1.Columns.Count);
            for(int i = 0; i < m1.Rows.Count; i++)
            {               
                for(int j = 0; j < m1.Columns.Count; j++)
                {
                    res.Rows[i][j] = 0;
                    for(int k = 0; k < m1.Rows.Count; k++)
                    {
                        res.Rows[i][j] = (int)res.Rows[i][j] + (int)m1.Rows[i][k] * (int)m2.Rows[k][j];
                    }
                }
            }
            return res;
        }

        public static Matrix operator % (Matrix m1,int mod)
        {
            Matrix res = new Matrix(m1.Rows.Count, m1.Columns.Count);
            for (int i = 0; i < m1.Rows.Count; i++)
            {
                for (int j = 0; j < m1.Columns.Count; j++)
                {
                    res.Rows[i][j] = (int)m1.Rows[i][j]%mod;
                }
            }
            return res;
        }
    }
}
