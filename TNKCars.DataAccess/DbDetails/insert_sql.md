the file to have SQL statements to populate tables

INSERT INTO manufacturers (id, title, founded_year)
VALUES (1, 'Ferrari', 1947);

INSERT INTO cars (id, title, price, series_year, horsepower)
VALUES (1, 'Enzo', 300000, 2013, 700);

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

INSERT INTO car_manufacturers (manufacturer_id, car_id)
VALUES (2, 2);