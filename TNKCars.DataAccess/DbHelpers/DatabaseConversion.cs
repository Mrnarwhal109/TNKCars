using System.Collections.Concurrent;

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

        internal async static Task<List<Car>> CarDataToCars(TableResult tableRows)
        {
            List<Car> cars = new List<Car>();
            ConcurrentBag<Car> carsBag = new ConcurrentBag<Car>();
            List<Task> activeWork = new List<Task>();

            foreach (var row in tableRows.Data)
            {
                Task t = Task.Run(
                    async () =>
                    {
                        carsBag.Add(await RowToCar(row));
                    });
                activeWork.Add(t);
            }

            await Task.WhenAll(activeWork);

            return carsBag.ToList();
        }

        internal async static Task<List<Engine>> EngineDataToEngines(TableResult tableRows)
        {
            List<Engine> engines = new List<Engine>();
            ConcurrentBag<Engine> enginesBag = new ConcurrentBag<Engine>();
            List<Task> activeWork = new List<Task>();

            foreach (var row in tableRows.Data)
            {
                Task t = Task.Run(
                    async () =>
                    {
                        enginesBag.Add(await RowToEngine(row));
                    });
                activeWork.Add(t);
            }

            await Task.WhenAll(activeWork);

            return enginesBag.ToList();
        }

        internal async static Task<List<Transmission>> TransmissionDataToTransmissions(TableResult tableRows)
        {
            List<Transmission> transmissions = new List<Transmission>();
            ConcurrentBag<Transmission> transmissionsBag = new ConcurrentBag<Transmission>();
            List<Task> activeWork = new List<Task>();

            foreach (var row in tableRows.Data)
            {
                Task t = Task.Run(
                    async () =>
                    {
                        transmissionsBag.Add(await RowToTransmission(row));
                    });
                activeWork.Add(t);
            }

            await Task.WhenAll(activeWork);

            return transmissionsBag.ToList();
        }

        internal async static Task<List<Manufacturer>> ManufacturerDataToManufacturers(TableResult tableRows)
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            ConcurrentBag<Manufacturer> manufacturersBag = new ConcurrentBag<Manufacturer>();
            List<Task> activeWork = new List<Task>();

            foreach (var row in tableRows.Data)
            {
                Task t = Task.Run(
                    async () =>
                    {
                        manufacturersBag.Add(await RowToManufacturer(row));
                    });
                activeWork.Add(t);
            }

            await Task.WhenAll(activeWork);

            return manufacturersBag.ToList();
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

        /// <summary>
        /// Engine, Transmisison, and Manufacturer will be initialized as null, as there is no joined data.
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        internal static async Task<Car> RowToCar(List<object> dataRow)
        {
            var result = await Task.Run(() =>
            {
                Car car = new Car((int)dataRow[0], (string)dataRow[1], (double)dataRow[2], (int)dataRow[3], (float)dataRow[4], (DateTime)dataRow[5],
                    null, null, null);
                return car;
            });
            return result;
        }

        internal static async Task<Engine> RowToEngine(List<object> dataRow)
        {
            var result = await Task.Run(() =>
            {
                Engine eng = new Engine((int)dataRow[0], (string)dataRow[1], (int)dataRow[2], (double)dataRow[3], (DateTime)dataRow[4]);
                return eng;
            });
            return result;
        }

        internal static async Task<Transmission> RowToTransmission(List<object> dataRow)
        {
            var result = await Task.Run(() =>
            {
                Transmission tran = new Transmission((int)dataRow[0], (string)dataRow[1], (int)dataRow[2], (bool)dataRow[3], (DateTime)dataRow[4]);

                return tran;
            });
            return result;
        }

        internal static async Task<Manufacturer> RowToManufacturer(List<object> dataRow)
        {
            var result = await Task.Run(() =>
            {
                Manufacturer manu = new Manufacturer((int)dataRow[0], (string)dataRow[1], (int)dataRow[2], (DateTime)dataRow[3]);

                return manu;
            });
            return result;
        }
    }
}
