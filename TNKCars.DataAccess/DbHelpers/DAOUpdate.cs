using Npgsql;
using TNKCars.DataAccess.DbDetails;

namespace TNKCars.DataAccess.DbHelpers
{
    public static class DAOUpdate
    {
        async public static Task UpdateEngineWithId(NpgsqlConnection connection, int id, string title, int cyl, double displacement)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.UpdateEngineWithId, connection);
            await command.AddParameter("@ID", id);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@CYLINDER_COUNT", cyl);
            await command.AddParameter("@DISPLACEMENT", displacement);
            await command.NonQueryResult();
        }

        async public static Task UpdateManufacturerWithId(NpgsqlConnection connection, int id, string title, int founded_year)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.UpdateManufacturerWithId, connection);
            await command.AddParameter("@ID", id);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@FOUNDED_YEAR", founded_year);
            await command.NonQueryResult();
        }

        async public static Task UpdateTransmissionWithId(NpgsqlConnection connection, int id, string title, int gear, bool is_auto)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.UpdateTransmissionWithId, connection);
            await command.AddParameter("@ID", id);
            await command.AddParameter("@TITLE", title);
            await command.AddParameter("@GEAR_COUNT", gear);
            await command.AddParameter("@IS_AUTOMATIC", is_auto);
            await command.NonQueryResult();
        }
    }
}
