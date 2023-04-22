using Npgsql;
using TNKCars.DataAccess.DbDetails;

namespace TNKCars.DataAccess.DbHelpers
{
    public static class DAOSelect
    {
        async public static Task<List<Car>> GetAllCarsWithDetails(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetAllJoinedCars, connection);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.JoinedCarDataToCars(dbResult);
            return converted;
        }

        async public static Task<List<Car>> GetAllCarsWithoutDetails(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetAllCars, connection);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.CarDataToCars(dbResult);
            return converted;
        }

        async public static Task<List<Engine>> GetAllEngines(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetAllEngines, connection);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.EngineDataToEngines(dbResult);
            return converted;
        }

        async public static Task<List<Transmission>> GetAllTransmissions(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetAllTransmissions, connection);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.TransmissionDataToTransmissions(dbResult);
            return converted;
        }

        async public static Task<List<Manufacturer>> GetAllManufacturers(NpgsqlConnection connection)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetAllManufacturers, connection);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.ManufacturerDataToManufacturers(dbResult);
            return converted;
        }

        async public static Task<Car> GetCarWithDetailsWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetJoinedCarWithId, connection);
            await command.AddParameter("@ID", id);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.JoinedRowToCar(dbResult.Data[0]);
            return converted;
        }

        async public static Task<Car> GetCarWithoutDetailsWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetCarWithId, connection);
            await command.AddParameter("@ID", id);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.RowToCar(dbResult.Data[0]);
            return converted;
        }

        async public static Task<Engine> GetEngineWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetEngineWithId, connection);
            await command.AddParameter("@ID", id);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.RowToEngine(dbResult.Data[0]);
            return converted;
        }

        async public static Task<Transmission> GetTransmissionWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetTransmissionWithId, connection);
            await command.AddParameter("@ID", id);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.RowToTransmission(dbResult.Data[0]);
            return converted;
        }

        async public static Task<Manufacturer> GetManufacturerWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.GetManufacturerWithId, connection);
            await command.AddParameter("@ID", id);
            var dbResult = await command.ReaderResult();
            var converted = await DatabaseConversion.RowToManufacturer(dbResult.Data[0]);
            return converted;
        }
    }
}
