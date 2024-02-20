create database Project_BCS_04
use Project_BCS_04
go
--Table For Teams
create table Teams(
[Team Id] varchar(3) primary key,
Name varchar(30),
)
exec sp_rename 'Teams.[[Team Name]]]','Team_Name','Column';
insert into Teams values('PAK','Pakistan')
insert into Teams values('RSA','South Africa')
insert into Teams values('WED','Westindies')
insert into Teams values('AFG','Afghanistan')
insert into Teams values('ENG','England')
insert into Teams values('IRD','Ireland')
insert into Teams values('SCT','Scotland')
insert into Teams values('NAM','Namibia')
insert into Teams values('SRI','Srilanka')
insert into Teams values('BAN','Bangladash')
insert into Teams values('IND','India')
insert into Teams values('NZ','Newzeland')
select * from Teams
--Table For Playes---
create table Players(
[National Id] varchar(7) primary key,
Name varchar(50),
Age int,
[Batting Average] float,
[Batting Strike Rate] float,
[Player Role] varchar(30),
[Batting best] int,
[Bowling best] varchar(10),
[Best Against] varchar(30),
[Bowling Average] float,
[Bowling Strike Rate] float,
[Team Id] varchar(3) foreign key references Teams
)
alter table Players
add [Best Bowling Against] varchar(30)
insert into Players values('LH-222','Babar Azam','27',46.07,128.83,'Batsman',122,null,'South Africa',null,null,'PAK',null)
insert into Players values('KP-151','Fakhar Zaman',31,23.48,131.57,'Batsman',91,null,'Australia',null,null,'PAK',null)
insert into Players values('KP-123','Muhammad Rizwan',29,49.52,125.52,'Wicketkeeper Bat',104,null,'South Africa',null,null,'PAK',null)
insert into Players values('LH-142','Muhammad Hafeez',41,26.46,122.04,'Allrounder',99,'10/4','Newzeland',22.75,20.6,'PAK',null)
insert into Players values('SAL-443','Shoaib Malik',39,31.21,125.64,'Allrounder',75,'2/7','England',24.10,20.3,'PAK',null)
insert into Players values('Mian-323','Shadab Khan',23,16.46,130.68,'Allrounder',42,'4/14','Newzeland',21.65,18.1,'PAK',null)
insert into Players values('CEN-678','Imad Waseem',32,13.3,143.64,'Allrounder',47,'5/14','Srilanka',23.49,22.2,'PAK',null)

select * from Players


--Table For Batters 
create table Batters(
[International ID] varchar(07),
[Tournament Average] float,
best int,
[Best Against] varchar(30),
[Tournament Strikerate] float,
Sixes int,
[National ID] varchar(7) foreign key references Players,
Team varchar(3) foreign key references Teams,
)
 
alter table Batters
add Run int

alter table Batters
drop column Sixes
select * from Batters where [National ID]='MQ_663'

update players set [Best Against]='scotland' where players.[National ID]='SAL-443'
 
--Table For Bowlers
create table Bowlers(
[International ID] varchar(07) primary key,
[Tournament Average] float,
best varchar(10),
[Best Against] varchar(30),
[Tournament Strikerate] float,
[National ID] varchar(7) foreign key references Players,
Team varchar(3) foreign key references Teams,
)
alter table Bowlers
add Wickets int

--Table for All Rounders
create table All_Rounders(
[International ID] varchar(07) primary key,
[Bowling Average] float,
[Boaling Strikerate] float,
[Batting Average] float,
[Batting Strikerate] float,
[Bowling best] varchar(10),
[Batting best] int,
Wickets int,
Runs int,
[National ID] varchar(7) foreign key references Players,
Team varchar(3) foreign key references Teams,
)
--Table For Coaches
create Table Coaches(
Id varchar(9) primary key,
Name varchar(30),
[Coach For] varchar(30),
[Team Id] varchar(3) foreign key references Teams,
)
insert into Players values('CEN-678','Imad Waseem',32,13.3,143.64,'Allrounder',47,'5/14','Srilanka',23.49,22.2,'PAK',null)

Execute insert_Players 'CEN-532','Hassan Ali',28,8.54,145.98,'Bowler',35,'5/23','South Africa',18.53,24.54,'PAK','Sarilanka'
Execute insert_Players 'CEN-533','Hassan Ali',28,8.54,145.98,'Bowler',35,'5/23','South Africa',18.53,24.54,'PAK','Sarilanka'

---------------------------------------Table For Players Trigger-------------------------------------
create table Players_rec(
rec_no int primary key identity(1,1)
rec varchar(2000),
)
create table prlayes_delete_rec(
rec_not int primary key identity(1,1),
Record varchar(200)
)
create table players_update_record(
rec_no int primary key identity(1,1),
rec varchar(2500)
) 
select * from Players_rec
--Table For couche Trigger

create table ins_Couch(
record varchar(2000)
)

--Trigger Table for Batters--
create Table inr_Batters(
Records varchar(1000)
)
----------------------------------Trigger Tabel for Bowlers----------------------------
create Table inr_bowlers(
Records varchar(500)
)
-----------------------------------------Table for Register Viewers -------------------------
 
select *from Register_Viewers

 select * from Players_rec
 delete from Players where [National Id]='CEN-533'