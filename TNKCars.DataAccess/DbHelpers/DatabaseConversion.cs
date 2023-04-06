using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbHelpers
{
    internal static class DatabaseConversion
    {
        internal async static Task<List<Car>> RowsToCars(TableResult tableRows)
        {
            List<Car> cars = new List<Car>();
            List<Task> activeWork = new List<Task>();

            foreach (var row in tableRows.Data)
            {
                activeWork.Add(RowToCar(row));               
            }

            await Task.WhenAll(activeWork);

            return cars;
        }

        internal static async Task<Car> RowToCar(List<object> dataRow)
        {
            var result = await Task.Run(() =>
            {
                Car car = new Car();
                return car;
            });
            return result;
        }
    }
}
