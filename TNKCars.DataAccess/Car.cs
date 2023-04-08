using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess
{
    public class Car
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int SeriesYear { get; set; }

        public float Horsepower { get; set; }

        public DateTime AddedAt { get; set; }

        public Manufacturer CarManufacturer { get; set; }

        public Engine CarEngine { get; set; }

        public Transmission CarTransmission { get; set; }

        public Car(int id, string title, double price, int series_year, float horsepower, DateTime added_at,
            Manufacturer manufacturer, Engine engine, Transmission transmission)
        {
            Id = id;
            Title = title;
            Price = price;                
            SeriesYear = series_year;                                         
            Horsepower = horsepower;
            AddedAt = added_at;
            CarManufacturer = manufacturer;
            CarEngine = engine;
            CarTransmission = transmission;
        }
    }
}
