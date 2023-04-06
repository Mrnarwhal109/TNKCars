using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbHelpers
{
    internal class TableResult
    {
        public List<List<object>> Data { get; set; }

        public TableResult()
        {
            Data = new List<List<object>>();
        }

        // WIP
        public static async Task<TableResult> FromReader(NpgsqlDataReader reader)
        {
            TableResult result = new TableResult();
            int fieldCount = reader.FieldCount;

            while (await reader.ReadAsync())
            {
                var currentRow = new List<object>();

                for (int i = 0; i < fieldCount; i++)
                {
                    await reader.GetFieldValueAsync<object>(i);
                }

                result.Data.Add(currentRow);
            }

            return result;
        }

    }
}
