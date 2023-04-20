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
        async public static Task<List<Car>> GetAllCarsWithDetails(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(connection);
            var dbResult = await command.ReaderResult(QueryDefinitions.GetAllJoinedCars);
            var converted = await DatabaseConversion.JoinedCarDataToCars(dbResult);
            return converted;
        }

        async public static Task<List<Car>> GetAllCarsWIthoutDetails(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(connection);
            var dbResult = await command.ReaderResult(QueryDefinitions.GetAllCars);
            var converted = await DatabaseConversion.CarDataToCars(dbResult);
            return converted;
        }

        async public static Task<List<Engine>> GetAllEngines(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(connection);
            var dbResult = await command.ReaderResult(QueryDefinitions.GetAllEngines);
            var converted = await DatabaseConversion.EngineDataToEngines(dbResult);
            return converted;
        }

        async public static Task<List<Transmission>> GetAllTransmissions(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(connection);
            var dbResult = await command.ReaderResult(QueryDefinitions.GetAllTransmissions);
            var converted = await DatabaseConversion.TransmissionDataToTransmissions(dbResult);
            return converted;
        }


    }
}
