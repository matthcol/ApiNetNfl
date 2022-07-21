CREATE TABLE team (
    id int NOT NULL AUTO_INCREMENT,
    name varchar(50) NOT NULL,
    city varchar(50) NULL,
    conference int NOT NULL,
    creation_date Date NULL,
    trophy_count int NOT NULL,
    CONSTRAINT PK_Teams PRIMARY KEY (id)
);

CREATE TABLE game (
    team_home_id int NOT NULL,
    team_away_id int NOT NULL,
    day int NOT NULL,
    score_home int NOT NULL,
    score_away int NOT NULL,
    CONSTRAINT PK_Matches PRIMARY KEY (team_home_id, team_away_id),
    CONSTRAINT FK_Matches_Teams_TeamAwayId FOREIGN KEY (team_away_id) REFERENCES team(id),
    CONSTRAINT FK_Matches_Teams_TeamHomeId FOREIGN KEY (team_home_id) REFERENCES team (Id)
);

CREATE TABLE player (
    id int NOT NULL AUTO_INCREMENT,
    firstname varchar(50) NULL,
    lastname varchar(50) NOT NULL,
    position int NOT NULL,
    team_id int NULL,
    CONSTRAINT PK_Players PRIMARY KEY (id),
    CONSTRAINT FK_Players_Teams_TeamId FOREIGN KEY (team_id) REFERENCES team (id)
);

CREATE INDEX `IX_Matches_TeamAwayId` ON game(team_away_id);
CREATE INDEX `IX_Matches_TeamHomeId` ON game(team_home_id);

CREATE INDEX `IX_Players_TeamId` ON player(team_id);

