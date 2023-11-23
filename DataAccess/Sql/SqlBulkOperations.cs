using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace DataAccess.Sql
{
    public class SqlBulkOperations
    {
        public void BulkSaveList<T>(IList<T> items, string connectionString, int connectionTimeout)
        {
            DataTable dataTable = ToDataTable(items);
            InsertToDatabase(dataTable, connectionString, connectionTimeout);
        }

        private DataTable ToDataTable<T>(IList<T> items)
        {

            var tableName = typeof(T).Name;
            DataTable dataTable = new DataTable(Pluralize(tableName));
            dataTable.TableName = tableName;
            PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                dataTable.Columns.Add(propertyInfo.Name);
            }

            var values = new object[propertyInfos.Length];
            foreach (T item in items)
            {
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    var value = propertyInfos[i].GetValue(item, null);
                    values[i] = value ?? DBNull.Value;
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private void InsertToDatabase(DataTable items, string connectionString, int connectionTimeout)
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connectionString))
            {
                sqlBulkCopy.DestinationTableName = items.TableName;
                sqlBulkCopy.BulkCopyTimeout = connectionTimeout;

                foreach (DataColumn dataColumn in items.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(dataColumn.ColumnName, dataColumn.ColumnName);
                }

                sqlBulkCopy.WriteToServer(items);
            }
        }

        public string Pluralize(string tableName)
        {
            if (tableName.EndsWith("y"))
            {
                return tableName.Remove(tableName.Length - 1) + "ies";
            }
            else if (tableName.EndsWith("s") || tableName.EndsWith("x") || tableName.EndsWith("z") || tableName.EndsWith("ch") || tableName.EndsWith("sh"))
            {
                return tableName + "es";
            }
            else
            {
                return tableName + "s";
            }
        }
    }
}
