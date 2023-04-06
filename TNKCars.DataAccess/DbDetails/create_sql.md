the file to have SQL statements to create all tables.

CREATE TABLE cars (
	id SERIAL PRIMARY KEY NOT NULL,
	title TEXT,
	price DOUBLE PRECISION NOT NULL DEFAULT 0.0,
	series_year INTEGER,
	horsepower REAL,
	added_at timestamptz NOT NULL
);

CREATE TABLE manufacturers (
	id SERIAL PRIMARY KEY NOT NULL,
	title TEXT,
	founded_year INTEGER,
	added_at timestamptz NOT NULL
);

CREATE TABLE engines (
	id SERIAL PRIMARY KEY NOT NULL,
	title TEXT,
	cylinder_count INTEGER,
	displacement DOUBLE PRECISION,
	added_at timestamptz NOT NULL
);

CREATE TABLE transmissions (
	id SERIAL PRIMARY KEY NOT NULL,
	title TEXT,
	gear_count INTEGER,
	is_automatic BOOLEAN,
	added_at timestamptz NOT NULL
);

CREATE TABLE car_manufacturers (
	car_id INTEGER NOT NULL
        REFERENCES cars (id),
	manufacturer_id INTEGER NOT NULL
		REFERENCES manufacturers (id),
    PRIMARY KEY (car_id, manufacturer_id)
);

CREATE TABLE car_engines (
	car_id INTEGER NOT NULL
        REFERENCES cars (id),
	engine_id INTEGER NOT NULL
		REFERENCES engines (id),
    PRIMARY KEY (car_id, engine_id)
);

CREATE TABLE car_transmissions (
	car_id INTEGER NOT NULL
        REFERENCES cars (id),
	transmission_id INTEGER NOT NULL
		REFERENCES transmissions (id),
    PRIMARY KEY (car_id, transmission_id)
);
