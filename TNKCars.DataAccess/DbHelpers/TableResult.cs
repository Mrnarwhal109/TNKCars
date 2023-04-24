using Npgsql;

namespace TNKCars.DataAccess.DbHelpers
{
    internal class TableResult
    {
        public List<List<object>> Data { get; set; }

        public TableResult()
        {
            Data = new List<List<object>>();
        }
       
        public static async Task<TableResult> FromReader(NpgsqlDataReader reader)
        {
            TableResult result = new TableResult();
            int fieldCount = reader.FieldCount;

            while (await reader.ReadAsync())
            {
                var currentRow = new List<object>();

                for (int i = 0; i < fieldCount; i++)
                {
                    object cell = await reader.GetFieldValueAsync<object>(i);
                    currentRow.Add(cell);
                }

                result.Data.Add(currentRow);
            }

            return result;
        }

    }
}
