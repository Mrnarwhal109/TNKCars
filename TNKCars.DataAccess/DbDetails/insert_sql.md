-- The file to have SQL statements to populate tables

INSERT INTO manufacturers (id, title, founded_year)
VALUES (1, 'Ferrari', 1947);

INSERT INTO cars (id, title, price, series_year, horsepower)
VALUES (1, 'Enzo', 630000, 2013, 700);

INSERT INTO engines (id, title, cylinder_count, displacement)
VALUES (1, 'E-XV12', 12, 6.0);

INSERT INTO transmissions (id, title, gear_count, is_automatic)
VALUES (1, 'E-7 Drivetrain', 7, false);

INSERT INTO car_manufacturers (manufacturer_id, car_id)
VALUES (1, 1);

INSERT INTO car_engines (engine_id, car_id)
VALUES (1, 1);

INSERT INTO car_transmissions (transmission_id, car_id)
VALUES (1, 1);


INSERT INTO manufacturers (id, title, founded_year)
VALUES (2, 'Lamborghini', 1963);

INSERT INTO cars (id, title, price, series_year, horsepower)
VALUES (2, 'Gallardo', 500000, 2015, 900);

INSERT INTO engines (id, title, cylinder_count, displacement)
VALUES (2, 'LS12', 12, 6.2);

INSERT INTO transmissions (id, title, gear_count, is_automatic)
VALUES (2, 'R17 Gear Drive', 7, false);

INSERT INTO car_manufacturers (manufacturer_id, car_id)
VALUES (2, 2);

INSERT INTO car_engines (engine_id, car_id)
VALUES (2, 2);

INSERT INTO car_transmissions (transmission_id, car_id)
VALUES (2, 2);


INSERT INTO manufacturers (id, title, founded_year)
VALUES (3, 'Ford', 1903);

INSERT INTO cars (id, title, price, series_year, horsepower)
VALUES (3, 'Focus', 15000, 2013, 140);

INSERT INTO engines (id, title, cylinder_count, displacement)
VALUES (3, 'Focus II 1.8T', 4, 1.8);

INSERT INTO transmissions (id, title, gear_count, is_automatic)
VALUES (3, 'F9-MTX', 5, true);

INSERT INTO car_manufacturers (manufacturer_id, car_id)
VALUES (3, 3);

INSERT INTO car_engines (engine_id, car_id)
VALUES (3, 3);

INSERT INTO car_transmissions (transmission_id, car_id)
VALUES (3, 3);


INSERT INTO cars (id, title, price, series_year, horsepower)
VALUES (4, 'Fiesta', 20000, 2017, 148);

INSERT INTO engines (id, title, cylinder_count, displacement)
VALUES (4, 'Fiesta IL3', 3, 1.8);

INSERT INTO transmissions (id, title, gear_count, is_automatic)
VALUES (4, 'F9-MTXS', 5, true);

INSERT INTO car_manufacturers (manufacturer_id, car_id)
VALUES (3, 4);

INSERT INTO car_engines (engine_id, car_id)
VALUES (4, 4);

INSERT INTO car_transmissions (transmission_id, car_id)
VALUES (4, 4);


INSERT INTO manufacturers (id, title, founded_year)
VALUES (5, 'Nissan', 1933);

INSERT INTO cars (id, title, price, series_year, horsepower)
VALUES (5, 'Frontier', 25000, 2010, 270);

INSERT INTO engines (id, title, cylinder_count, displacement)
VALUES (5, 'TQ-FRT Mk II', 6, 3.8);

INSERT INTO transmissions (id, title, gear_count, is_automatic)
VALUES (5, 'FRT-X', 6, true);

INSERT INTO car_manufacturers (manufacturer_id, car_id)
VALUES (5, 5);

INSERT INTO car_engines (engine_id, car_id)
VALUES (5, 5);

INSERT INTO car_transmissions (transmission_id, car_id)
VALUES (5, 5);

-- Fix serials/sequences after manual inserts

SELECT pg_get_serial_sequence('"public"."cars"', 'id');

ALTER SEQUENCE "cars_id_seq" RESTART WITH 10;

SELECT pg_get_serial_sequence('"public"."manufacturers"', 'id');

ALTER SEQUENCE "manufacturers_id_seq" RESTART WITH 10;

SELECT pg_get_serial_sequence('"public"."engines"', 'id');

ALTER SEQUENCE "engines_id_seq" RESTART WITH 10;

SELECT pg_get_serial_sequence('"public"."transmissions"', 'id');

ALTER SEQUENCE "transmissions_id_seq" RESTART WITH 10;