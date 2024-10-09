CREATE TABLE users(
	id SERIAL PRIMARY KEY,
	email VARCHAR(100) UNIQUE,
	password VARCHAR(60)
);

INSERT INTO users(email, password) VALUES
('Buy milk'), ('Finish homework');

SELECT * FROM users;

ALTER TABLE users
ADD COLUMN secret text