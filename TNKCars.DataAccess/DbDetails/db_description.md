A description of our database, including tables, attributes, primary keys, 
foreign keys, foreign key constraints, FDs, whether in 3NF, and one or two rows of sample data for 
each table.

The TNKCars database serves to retain details of vehicles for a business's records. 
The database consists of four main data tables and three connecting tables.
The three connecting tables serve the purpose of associating manufacturers, engines, and transmissions to cars.
This database is in Third Normal Form (3NF).

The cars table contains details unique to a car, and it is the focal point for relationships.
Its primary key is 'id', which is an INT SERIAL.
In PostgreSQL, SERIAL creates a sequence behind a column such that the default value of the column is unique and increments by one for each entry added.
The 'added_at' attribute is a TIMESTAMP type set to default to the current time. With these configurations, 'id' and 'added_at' don't have to be specified
during row insertion. The text 'title' attribute refers to a car's model or title. Note that the title refers to the model name and not the car's ownership title documents.
The name 'model' is used too often around data models and we chose to not name an attribute 'model'.
The double precision 'price' attribute refers to a car's MSRP. The integer 'series_year' attribute refers to the named series year of the car that would be advertised.
The PostgreSQL's real type is a 4-byte float. The real 'horsepower' attribute refers to a car's horsepower. 
Note that horsepower is in the right place because it is not determined by the engine. 
Horsepower at the output of the engine is different that the transferred wheel horsepower, and therefore it belongs in the cars table.
Note that the series year and the title together cannot uniquely determine a car's attributes. Certain cars are made as special edition series one-offs.
An example of a row in the cars table is { id = 1, title = "Enzo", price = 630000, series_year = 2003, horsepower = 700 }.


The manufacturers table defines car manufacturers and attributes unique to them. 
Its primary key is 'id', which is another int serial sequence.
The text 'title' attribute refers to a manufacturers's known title. 
The text 'founded_year' attribute refers to the manufacturer's founded year.
The timestamp 'added_at' attribute is set to default to the current time. 
An example of a row in the manufacturers table is { id = 2, title = 'Lamborghini', founded_year = 1963 }.

The engines table defines car engines and attributes unique to them. 
Its primary key is 'id', which is another int serial sequence.
The text 'title' attribute refers to an engine model's title. 
The int 'cylinder_count' attribute refers to how many cylinders the engine has.
The double precision 'displacement' attribute refers to how many liters of volume the cylinders displace when they move.
The timestamp 'added_at' attribute is set to default to the current time. 
An example of a row in the engines table is { id = 5, title = 'TQ-FRT Mk II', cylinder_count = 6, displacement = 3.8 }.

The transmissions table defines car transmissions and attributes unique to them. 
Its primary key is 'id', which is another int serial sequence.
The text 'title' attribute refers to a transmission model's title. 
The int 'gear_count' attribute refers to how many gearings the transmission has.
The boolean 'is_automatic' field is true when the transmission is automatic and false when the transmission is manual.
The timestamp 'added_at' attribute is set to default to the current time. 
An example of a row in the transmissions table is { id = 4, title = 'F9-MTXS', gear_count = 5, is_automatic = True }.

The remaining tables serve to link manufacturers, engines, and transmissions to cars.

The car_manufacturers table links the manufacturers table to the cars table using their primary keys. 
The int 'car_id' attribute represents the car's id. The int 'manufacturer_id' attribute represents the manufacturer's id.
The defined primary key of car_manufacturers is (car_id, manufacturer_id).
A foreign key constraint on 'car_manufacturers.car_id' that references 'cars.id' is put in place.
This foreign key makes it so that a car_manufacturers entry cannot exist if its car_id value is not contained in the cars table's primary id values.
This foreign key is given ON DELETE CASCADE, which means that when a row in the cars table is deleted, all rows in car_manufacturers that have that car's
primary key as their car_id will be deleted automatically.
A foreign key constraint on 'car_manufacturers.manufacturer_id' that references 'manufacturer.id' is put in place.
This foreign key makes it so that a car_manufacturers entry cannot exist if its manufacturer_id value is not contained in the manufacturers table's primary id values.
This foreign key is given ON DELETE CASCADE, which means that when a row in the manufacturers table is deleted, all rows in car_manufacturers that have that manufacturer's
primary key as their manufacturer_id will be deleted automatically.
An example of a row in the car_manufacturers table is { car_id = 1, manufacturer_id = 1 }.


The car_engines table links the engines table to the cars table using their primary keys. 
The int 'car_id' attribute represents the car's id. The int 'engine_id' attribute represents the engine's id.
The defined primary key of car_engines is (car_id, engine_id).
A foreign key constraint on 'car_engines.car_id' that references 'cars.id' is put in place.
This foreign key makes it so that a car_engines entry cannot exist if its car_id value is not contained in the cars table's primary id values.
This foreign key is given ON DELETE CASCADE, which means that when a row in the cars table is deleted, all rows in car_engines that have that car's
primary key as their car_id will be deleted automatically.
A foreign key constraint on 'car_engines.engine_id' that references 'engine.id' is put in place.
This foreign key makes it so that a car_engines entry cannot exist if its engine_id value is not contained in the engines table's primary id values.
This foreign key is given ON DELETE CASCADE, which means that when a row in the engines table is deleted, all rows in car_engines that have that engine's
primary key as their engine_id will be deleted automatically.
An example of a row in the car_engines table is { car_id = 2, engine_id = 2 }.


The car_transmissions table links the transmissions table to the cars table using their primary keys. 
The int 'car_id' attribute represents the car's id. The int 'transmission_id' attribute represents the transmission's id.
The defined primary key of car_transmissions is (car_id, transmission_id).
A foreign key constraint on 'car_transmissions.car_id' that references 'cars.id' is put in place.
This foreign key makes it so that a car_transmissions entry cannot exist if its car_id value is not contained in the cars table's primary id values.
This foreign key is given ON DELETE CASCADE, which means that when a row in the cars table is deleted, all rows in car_transmissions that have that car's
primary key as their car_id will be deleted automatically.
A foreign key constraint on 'car_transmissions.transmission_id' that references 'transmission.id' is put in place.
This foreign key makes it so that a car_transmissions entry cannot exist if its transmission_id value is not contained in the transmissions table's primary id values.
This foreign key is given ON DELETE CASCADE, which means that when a row in the transmissions table is deleted, all rows in car_transmissions that have that transmission's
primary key as their transmission_id will be deleted automatically.
An example of a row in the car_transmissions table is { car_id = 3, transmission_id = 3 }.

Functional Dependencies

cars.id -> { cars.id, cars.title, cars.price, cars.series_year, cars.horsepower, cars.added_at }

manufacturers.id -> { manufacturers.id, manufacturers.title, manufacturers.founded_year, manufacturers.added_at }

engines.id -> { engines.id, engines.title, engines.cylinder_count, engines.displacement, engines.added_at }

transmissions.id -> { transmissions.id, transmissions.title, transmissions.gear_count, transmissions.is_automatic, transmissions.added_at }

(car_manufacturers.car_id, car_manufacturers.manufacturer_id) -> { car_manufacturers.car_id, car_manufacturers.manufacturer_id }

(car_engines.car_id, car_engines.engine_id) -> { car_engines.car_id, car_engines.engine_id }

(car_transmissions.car_id, car_transmissions.transmission_id) -> { car_transmissions.car_id, car_transmissions.transmission_id }
