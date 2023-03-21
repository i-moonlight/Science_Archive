CREATE TABLE IF NOT EXISTS users (
  id UUID NOT NULL,
  name VARCHAR NOT NULL,
  email VARCHAR NOT NULL,
  login VARCHAR NOT NULL,
  password VARCHAR NOT NULL,
  password_salt VARCHAR NOT NULL,
  PRIMARY KEY (id)
);

CREATE INDEX IF NOT EXISTS idx_users_login
ON users (login);

CREATE INDEX IF NOT EXISTS idx_users_email
ON users (email);
