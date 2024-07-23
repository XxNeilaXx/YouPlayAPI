CREATE SCHEMA IF NOT EXISTS postgres;
GRANT USAGE ON SCHEMA public TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO postgres;

CREATE USER migrator WITH PASSWORD 'LetMeIn@1234';

CREATE SCHEMA IF NOT EXISTS YouPlay;
GRANT USAGE ON SCHEMA public TO migrator;
GRANT USAGE ON SCHEMA YouPlay TO migrator;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA YouPlay TO migrator;