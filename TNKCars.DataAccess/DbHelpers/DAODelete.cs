using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNKCars.DataAccess.DbDetails;

namespace TNKCars.DataAccess.DbHelpers
{
    public static class DAODelete
    {
        async public static Task DeleteEngineWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.DeleteEngineWithId, connection);
            await command.AddParameter("@ID", id);
            await command.NonQueryResult();
        }

        async public static Task DeleteTransmissionWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.DeleteTransmissionWithId, connection);
            await command.AddParameter("@ID", id);
            await command.NonQueryResult();
        }

        async public static Task DeleteManufacturerWithId(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.DeleteManufacturerWithId, connection);
            await command.AddParameter("@ID", id);
            await command.NonQueryResult();
        }

        async public static Task RemoveCarsFromParents(NpgsqlConnection connection, int id)
        {
            var command = await CustomDbCommand.CreateAsync(QueryDefinitions.RemoveCarsFromParents, connection);
            await command.AddParameter("@ID", id);
            await command.NonQueryResult();
        }
    }
}
