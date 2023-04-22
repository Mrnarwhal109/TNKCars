using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    internal static class ComboBoxDataHelpers
    {
        internal static async Task FillComboBoxWithManufacturers(NpgsqlConnection connection, ComboBox cmbManufacturer)
        {
            List<DataAccess.Manufacturer> manufacturers = await DAOCars.GetAllManufacturers(connection);

            cmbManufacturer.ItemsSource = manufacturers;
        }

        internal static async Task FillComboBoxWithEngines(NpgsqlConnection connection, ComboBox cmbEngine)
        {
            List<DataAccess.Engine> engines = await DAOCars.GetAllEngines(connection);

            cmbEngine.ItemsSource = engines;
        }

        internal static async Task FillComboBoxWithTransmissions(NpgsqlConnection connection, ComboBox cmbTransmission)
        {
            List<DataAccess.Transmission> transmissions = await DAOCars.GetAllTransmissions(connection);

            cmbTransmission.ItemsSource = transmissions;
        }
    }
}
