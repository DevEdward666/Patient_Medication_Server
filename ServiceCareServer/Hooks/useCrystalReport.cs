using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WEB_API.Hooks
{
    public class useCrystalReport
    {
        public DataTable dtByteArray(string table_name,string column_name, byte[] column_value)
        {
            var table = new DataTable(table_name);
            DataColumn colByteArray = new DataColumn(column_name);
            colByteArray.DataType = System.Type.GetType("System.Byte[]");
            table.Columns.Add(colByteArray);
            var myNewRow = table.NewRow();
            myNewRow[column_name] = column_value;
            table.Rows.Add(myNewRow);
            return table;
        }
    }
}