DROP DATABASE IF EXISTS playerinfo;
create database playerinfo;
use playerinfo;

create table players (
    userid integer primary key auto_increment,
    playername varchar(50),
    sport varchar(50),
    dob date
    );

insert into players values(1, "Shyam","tabletennis", "2020-01-01");
insert into players(playername, sport, dob) values("eklavya", "volleyball", "2020-05-22");
