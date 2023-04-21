using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // insert
        async public static void InsertCar(NpgsqlConnection connection, string title, int price, int series_year, int horsepower)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.InsertCar, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@PRICE", price);
            await command.AddParameter("@SERIES_YEAR", series_year);
            await command.AddParameter("@HORSEPOWER", horsepower);
            await command.ReaderResult();
        }

        async public static void InsertEngine(NpgsqlConnection connection, string title, int cyl, double displacement)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.InsertEngine, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@CYL_COUNT", cyl);
            await command.AddParameter("@DISPLACEMENT", displacement);
            await command.ReaderResult();
        }

        async public static void InsertTransmission(NpgsqlConnection connection, string title, int gear, bool is_auto)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.InsertTransmission, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@GEAR_COUNT", gear);
            await command.AddParameter("@IS_AUTOMATIC", is_auto);
            await command.ReaderResult();
        }

        async public static void InsertManufacturer(NpgsqlConnection connection, string title, int founded_year)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.InsertManufacturer, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@FOUNDED_YEAR", founded_year);
            await command.ReaderResult();
        }

        // UPDATE
        async public static void UpdateEngineWithId(NpgsqlConnection connection, int id, string title, int cyl, double displacement)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.UpdateEngineWithId, connection);
            await command.AddParameter("@ID", id);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@CYL_COUNT", cyl);
            await command.AddParameter("@DISPLACEMENT", displacement);
            await command.ReaderResult();
        }

        async public static void UpdateTransmissionWithId(NpgsqlConnection connection, int id, string title, int gear, bool is_auto)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.UpdateTransmissionWithId, connection);
            await command.AddParameter("@ID", id);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@GEAR_COUNT", gear);
            await command.AddParameter("@IS_AUTOMATIC", is_auto);
            await command.ReaderResult();
        }

        async public static void UpdateManufacturerWithId(NpgsqlConnection connection, int id, string title, int founded_year)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.UpdateManufacturerWithId, connection);
            await command.AddParameter("@ID", id);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@FOUNDED_YEAR", founded_year);
            await command.ReaderResult();
        }

        async public static void DeleteEngineWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.DeleteEngineWithId, connection);
            await command.AddParameter("@ID", id);
            await command.ReaderResult();
        }

        async public static void DeleteTransmissionWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.DeleteTransmissionWithId, connection);
            await command.AddParameter("@ID", id);
            await command.ReaderResult();
        }

        async public static void DeleteManufacturerWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.DeleteManufacturerWithId, connection);
            await command.AddParameter("@ID", id);
            await command.ReaderResult();
        }
    }
}
