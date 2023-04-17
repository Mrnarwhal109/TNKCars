using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNKCars.DataAccess.DbDetails;

namespace TNKCars.DataAccess.DbHelpers
{
    public static class DAOCars
    {
        async internal static Task<TableResult> GetAllJoinedCarData(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(connection);
            var dbResult = await command.ReaderResult(QueryDefinitions.GetAllJoinedCarData);
            return dbResult;
        }

        async public static Task<List<Car>> GetAllCars(NpgsqlConnection connection)
        {
            var tableRows = await GetAllJoinedCarData(connection);
            var converted = await DatabaseConversion.JoinedCarDataToCars(tableRows);
            return converted;
        }

        //async public static void RemoveCar(NpgsqlConnection connection, string id)
        //{
        //    var RemoveCar = QueryDefinitions.RemoveCarData(id);
        //    var command = await CustomDbCommand.CreateAsync(connection);
        //    var dbResult = await command.ReaderResult(RemoveCar);
        //}
    }
}
