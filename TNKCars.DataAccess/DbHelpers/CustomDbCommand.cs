using Npgsql;

namespace TNKCars.DataAccess.DbHelpers
{
    public class CustomDbCommand
    {
        NpgsqlConnection Connection;
        NpgsqlCommand _command;

        async public static Task<CustomDbCommand> CreateAsync(string query, NpgsqlConnection connection)
        {
            var instance = new CustomDbCommand(query, connection);
            await instance.InitializeAsync();
            return instance;
        }

        private CustomDbCommand(string query, NpgsqlConnection connection)
        {
            Connection = connection;
            _command = new NpgsqlCommand(query, Connection);
        }

        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        public async Task AddParameter(string name, object value)
        {
            await Task.Run(
                () =>
                {
                    var param = new NpgsqlParameter(name, value);
                    _command.Parameters.Add(param);
                });
        }

        internal async Task<TableResult> ReaderResult()
        {
            var reader = await _command.ExecuteReaderAsync();
            var results = await TableResult.FromReader(reader);
            await reader.CloseAsync();
            return results;
        }

        internal async Task<int> NonQueryResult()
        {
            var rowsHit = await _command.ExecuteNonQueryAsync();
            return rowsHit;
        }
    }
}