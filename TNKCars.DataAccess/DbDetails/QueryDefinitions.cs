using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess.DbDetails
{
    internal static class QueryDefinitions
    {
        internal static readonly string GetAllJoinedCarData = @"
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
        ";
    }
}
