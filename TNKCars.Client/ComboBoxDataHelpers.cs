using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using TNKCars.DataAccess;
using TNKCars.DataAccess.DbHelpers;

namespace TNKCars.Client
{
    internal static class ComboBoxDataHelpers
    {
        internal static async Task FillComboBoxWithManufacturers(NpgsqlConnection connection, ComboBox cmbManufacturer)
        {
            List<DataAccess.Manufacturer> manufacturers = await DAOSelect.GetAllManufacturers(connection);

            await UIHelpers.InvokeOnUIThread(() => cmbManufacturer.ItemsSource = manufacturers);          
        }

        internal static async Task FillComboBoxWithEngines(NpgsqlConnection connection, ComboBox cmbEngine)
        {
            List<DataAccess.Engine> engines = await DAOSelect.GetAllEngines(connection);
            await UIHelpers.InvokeOnUIThread(() => cmbEngine.ItemsSource = engines);
        }

        internal static async Task FillComboBoxWithTransmissions(NpgsqlConnection connection, ComboBox cmbTransmission)
        {
            List<DataAccess.Transmission> transmissions = await DAOSelect.GetAllTransmissions(connection);
            await UIHelpers.InvokeOnUIThread(() => cmbTransmission.ItemsSource = transmissions);
        }
    }
}
