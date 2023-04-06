using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbHelpers
{
    public static class DAOCars
    {
        async public static Task<List<Car>> GetAllCars(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(connection);
            var dbResult = await command.ReaderResult("DEMO QUERY");
            var carResult = new List<Car>();
            return carResult;
        }
    }
}
