# Commandline tools to handle DB / Object Model correspondance

## MariaDB SQL commands
create database dbnfl;

create user nfl@localhost identified by 'password';

grant all privileges on dbnfl.* to nfl@localhost;

flush privileges;


## Nugget Package Console commands

### List DbContexts of the project

Get-DbContext

### Generate SQL DDL Script for the whole database

Script-DbContext -Output Nfl-ddl.sql

Script-DbContext -Context NFLDbContext -Output Nfl-ddl.sql

Script-DbContext -Context ApiNFL.Repository.NFLDbContext  -Output Nfl-ddl.sql 