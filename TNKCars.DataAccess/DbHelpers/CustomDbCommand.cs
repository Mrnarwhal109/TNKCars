using Npgsql;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbHelpers
{
    public class CustomDbCommand
    {
        NpgsqlConnection Connection;

        async public static Task<CustomDbCommand> CreateAsync(NpgsqlConnection connection)
        {
            var instance = new CustomDbCommand(connection);
            await instance.InitializeAsync();
            return instance;
        }

        private CustomDbCommand(NpgsqlConnection connection)
        {
            Connection = connection;
        }

        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        internal async Task<TableResult> ReaderResult(string query)
        {
            var cmd = new NpgsqlCommand(query, Connection);
            var reader = await cmd.ExecuteReaderAsync();
            var results = await TableResult.FromReader(reader);
            return results;
        }
    }
}