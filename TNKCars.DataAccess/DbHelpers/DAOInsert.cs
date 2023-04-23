using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNKCars.DataAccess.DbDetails;

namespace TNKCars.DataAccess.DbHelpers
{
    public static class DAOInsert
    {
        async public static Task<Car> InsertCar(NpgsqlConnection connection, string title, int price, int series_year, int horsepower)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.InsertCar, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@PRICE", price);
            await command.AddParameter("@SERIES_YEAR", series_year);
            await command.AddParameter("@HORSEPOWER", horsepower);
            await command.NonQueryResult();

            return null;
        }

        async public static Task<int?> InsertEngine(NpgsqlConnection connection, string title, int cyl, double displacement)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.InsertEngine, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@CYL_COUNT", cyl);
            await command.AddParameter("@DISPLACEMENT", displacement);
            var result = await command.ReaderResult();

            if (result == null || result.Data.Count == 0)
            {
                return null;
            }

            var idInserted = (int?)result.Data[0][0];

            if (idInserted < 1)
            {
                idInserted = null;
            }

            return idInserted;
        }

        async public static Task<Engine> InsertRetrieveEngine(NpgsqlConnection connection, string title, int cyl, double displacement)
        {
            var idInserted = await InsertEngine(connection, title, cyl, displacement);

            if (idInserted == null || idInserted < 1) { return null; }

            var engInserted = await DAOSelect.GetEngineWithId(connection, (int)idInserted);

            return engInserted;
        }

        async public static Task<int?> InsertTransmission(NpgsqlConnection connection, string title, int gear, bool is_auto)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.InsertTransmission, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@GEAR_COUNT", gear);
            await command.AddParameter("@IS_AUTOMATIC", is_auto);
            var result = await command.ReaderResult();

            if (result == null || result.Data.Count == 0)
            {
                return null;
            }

            var idInserted = (int?)result.Data[0][0];

            if (idInserted < 1)
            {
                idInserted = null;
            }

            return idInserted;
        }

        async public static Task<Transmission> InsertRetrieveTransmission(NpgsqlConnection connection, string title, int gear, bool is_auto)
        {
            var idInserted = await InsertTransmission(connection, title, gear, is_auto);

            if (idInserted == null || idInserted < 1) { return null; }

            var tranInserted = await DAOSelect.GetTransmissionWithId(connection, (int)idInserted);

            return tranInserted;
        }

        async public static Task<int?> InsertManufacturer(NpgsqlConnection connection, string title, int foundedYear)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.InsertManufacturer, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@FOUNDED_YEAR", foundedYear);
            var result = await command.ReaderResult();

            if (result == null || result.Data.Count == 0)
            {
                return null;
            }

            var idInserted = (int?)result.Data[0][0];

            if (idInserted < 1)
            {
                idInserted = null;
            }

            return idInserted;
        }

        async public static Task<Manufacturer> InsertRetrieveManufacturer(NpgsqlConnection connection, string title, int foundedYear)
        {
            var idInserted = await InsertManufacturer(connection, title, foundedYear);

            if (idInserted == null || idInserted < 1) { return null; }

            var manuInserted = await DAOSelect.GetManufacturerWithId(connection, (int)idInserted);

            return manuInserted;
        }

        async public static Task<Car> AddCarUsingChilds(NpgsqlConnection connection, string title, int price, int series_year, int horsepower, int MANU_ID, int ENG_ID, int TRAN_ID)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.AddCarUsingChilds, connection);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@PRICE", price);
            await command.AddParameter("@SERIES_YEAR", series_year);
            await command.AddParameter("@HORSEPOWER", horsepower);
            await command.AddParameter("@MANU_ID", MANU_ID);
            await command.AddParameter("@ENG_ID", ENG_ID);
            await command.AddParameter("@TRAN_ID", TRAN_ID);
            await command.NonQueryResult();

            return null;
        }
    }
}
