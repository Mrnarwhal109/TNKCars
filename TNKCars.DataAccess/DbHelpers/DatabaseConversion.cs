using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbHelpers
{
    internal static class DatabaseConversion
    {
        internal async static Task<List<Car>> JoinedCarDataToCars(TableResult tableRows)
        {
            List<Car> cars = new List<Car>();
            ConcurrentBag<Car> carsBag = new ConcurrentBag<Car>();
            List<Task> activeWork = new List<Task>();

            foreach (var row in tableRows.Data)
            {
                Task t = Task.Run(
                    async () =>
                    {
                        carsBag.Add(await JoinedRowToCar(row));
                    });
                activeWork.Add(t);
            }

            await Task.WhenAll(activeWork);

            return carsBag.ToList();
        }

        internal static async Task<Car> JoinedRowToCar(List<object> dataRow)
        {
            var result = await Task.Run(() =>
            {
                Manufacturer manu = new Manufacturer((int)dataRow[6], (string)dataRow[7], (int)dataRow[8], (DateTime)dataRow[9]);

                Engine eng = new Engine((int)dataRow[10], (string)dataRow[11], (int)dataRow[12], (double)dataRow[13], (DateTime)dataRow[14]);

                Transmission tran = new Transmission((int)dataRow[15], (string)dataRow[16], (int)dataRow[17], (bool)dataRow[18], (DateTime)dataRow[19]);

                Car car = new Car((int)dataRow[0], (string)dataRow[1], (double)dataRow[2], (int)dataRow[3], (float)dataRow[4], (DateTime)dataRow[5], 
                    manu, eng, tran);
                return car;
            });
            return result;
        }
    }
}
