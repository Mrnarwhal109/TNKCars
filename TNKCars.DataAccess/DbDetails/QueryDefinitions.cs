using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbDetails
{
    internal static class QueryDefinitions
    {
        internal static readonly string GetAllJoinedCars = @"
            SELECT c.id, c.title, c.price, c.series_year, c.horsepower, c.added_at,
            m.id, m.title, m.founded_year, m.added_at,
            e.id, e.title, e.cylinder_count, e.displacement, e.added_at,
            t.id, t.title, t.gear_count, t.is_automatic, t.added_at
            FROM cars c
            INNER JOIN car_manufacturers cm
            ON cm.car_id = c.id
            INNER JOIN manufacturers m
            ON cm.manufacturer_id = m.id
            INNER JOIN car_engines ce
            ON ce.car_id = c.id
            INNER JOIN engines e
            ON ce.engine_id = e.id
            INNER JOIN car_transmissions ct
            ON ct.car_id = c.id
            INNER JOIN transmissions t
            ON ct.transmission_id = t.id;
        ";

        internal static readonly string GetAllCars = @"
            SELECT c.id, c.title, c.price, c.series_year, c.horsepower, c.added_at
            FROM cars c;
        ";

        internal static readonly string GetAllEngines = @"
            SELECT e.id, e.title, e.cylinder_count, e.displacement, e.added_at
            FROM engines e;
        ";

        internal static readonly string GetAllTransmissions = @"
            SELECT t.id, t.title, t.gear_count, t.is_automatic, t.added_at
            FROM transmissions t;
        ";

        internal static readonly string GetAllManufacturers = @"
            SELCT m.id, m.title, m.founded_year, m.added_at
            FROM manufacturers m;
        ";

        internal static readonly string GetJoinedCarWithId = @"
            SELECT c.id, c.title, c.price, c.series_year, c.horsepower, c.added_at,
            m.id, m.title, m.founded_year, m.added_at,
            e.id, e.title, e.cylinder_count, e.displacement, e.added_at,
            t.id, t.title, t.gear_count, t.is_automatic, t.added_at
            FROM cars c
            INNER JOIN car_manufacturers cm
            ON cm.car_id = c.id
            INNER JOIN manufacturers m
            ON cm.manufacturer_id = m.id
            INNER JOIN car_engines ce
            ON ce.car_id = c.id
            INNER JOIN engines e
            ON ce.engine_id = e.id
            INNER JOIN car_transmissions ct
            ON ct.car_id = c.id
            INNER JOIN transmissions t
            ON ct.transmission_id = t.id
            WHERE c.id = @ID;
        ";

        internal static readonly string GetCarWithId = @"
            SELECT c.id, c.title, c.price, c.series_year, c.horsepower, c.added_at
            FROM cars c
            WHERE c.Id = @ID;
        ";

        internal static readonly string GetEngineWithId = @"
            SELECT e.id, e.title, e.cylinder_count, e.displacement, e.added_at
            FROM engines e
            WHERE e.id = @ID;
        ";

        internal static readonly string GetTransmissionWithId = @"
            SELECT t.id, t.title, t.gear_count, t.is_automatic, t.added_at
            FROM transmissions t
            WHERE t.id = @ID;
        ";

        internal static readonly string GetManufacturerWithId = @"
            SELCT m.id, m.title, m.founded_year, m.added_at
            FROM manufacturers m
            WHERE m.id = @ID;
        ";

        internal static readonly string InsertCar = @"
            INSERT INTO cars(title, price, series_year, horsepower)
            VALUES(@TITLE, @PRICE, @SERIES_YEAR, @HORSEPOWER);
        ";

        internal static readonly string InsertEngine = @"
            INSERT INTO engines(title, cylinder_count, displacement)
            VALUES(@TITLE, @CYL_COUNT, @DISPLACEMENT);
        ";

        internal static readonly string InsertTransmission = @"
            INSERT INTO transmissions(title, gear_count, is_automatic)
            VALUES(@TITLE, @GEAR_COUNT, @IS_AUTOMATIC);
        ";

        internal static readonly string InsertManufacturer = @"
            INSERT INTO manufacturers(id, title, founded_year)
            VALUES(@TITLE, @FOUNDED_YEAR);
        ";

        internal static readonly string UpdateEngineWithId = @"
            UPDATE engines 
            SET title = @TITLE, cylinder_count = @CYLINDER_COUNT, displacement = @DISPLACEMENT
            WHERE id = @ID;
        ";

        internal static readonly string UpdateTransmissionWithId = @"
            UPDATE transmissions 
            SET title = @TITLE, gear_count = @GEAR_COUNT, is_automatic = @IS_AUTOMATIC
            WHERE id = @ID;
        ";

        internal static readonly string UpdateManufacturerWithId = @"
            UPDATE manufacturers 
            SET title = @TITLE, founded_year = @FOUNDED_YEAR
            WHERE id = @ID;
        ";

        internal static readonly string DeleteEngineWithId = @"
            DELETE FROM engines
            WHERE id = @ID;
        ";

        internal static readonly string DeleteTransmissionWithId = @"
            DELETE FROM transmissions
            WHERE id = @ID;
        ";

        internal static readonly string DeleteManufacturerWithId = @"
            DELETE FROM manufacturers
            WHERE id = @ID;
        ";

    }
}
