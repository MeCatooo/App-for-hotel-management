--drop database if exists Hotel;
create database Hotel;
go
use Hotel;

drop table if exists Pracownicy
drop table if exists Goscie;
drop table if exists Dodatkowe_Oplaty;
drop table if exists Dodatkowe_Uslugi;
drop table if exists Historia_Rezerwacji
drop table if exists Pokoje
drop table if exists Typ_Pokoju



create table Pracownicy (ID_Pracownika int IDentity(1,1),
Imie varchar(50) not null,
Nazwisko varchar(30) not null,
Nr_Telefonu char(9) not null,
Email varchar(50) not null,
Zatrudniny_Od date not null,
constraint PK_Pracownicy Primary key (ID_Pracownika),
constraint CHK_Poprawny_Telefon_Pracownika CHECK (Nr_Telefonu like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'));



create table Goscie(ID_Goscia  int IDentity(1,1),
Imie varchar(50) not null,
Nazwisko varchar(50) not null,
Nr_Telefonu char(9) not null,
Pesel char(11) unique not null,
constraint PK_Goscie Primary key (ID_goscia),
constraint CHK_Poprawny_Telefon_Goscia check (Nr_Telefonu like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
constraint CHK_Poprwany_Pesel CHECK (Pesel like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'));


create table Dodatkowe_Oplaty(ID_Oplaty int IDentity(1,1),
ID_Goscia int not null,
ID_Uslugi int not null,
Data_Wykonania date not null,
constraint PK_Oplaty Primary key (ID_Oplaty));



create table Dodatkowe_Uslugi(ID_uslugi int IDentity(1,1),
Nazwa_Uslugi varchar(60) not null,
Cena money not null,
constraint PK_Uslugi Primary key (ID_Uslugi));



create table Historia_Rezerwacji(ID_Rezerwacja int IDentity(1,1),
ID_Pokoju int not null,
ID_Goscia int not null,
Obslugiwany_przez int not null,
Rezerwacja_Od date not null,
Rezerwacja_Do date not null,
constraint PK_ID_Rezerwacji primary key(ID_Rezerwacja),
constraint Rezerwacje_Data check (Rezerwacja_Do>Rezerwacja_Od));



create table Pokoje (ID_Pokoju int IDentity(1,1),
Nr_Pokoju int unique not null,
Typ_Pokoju int not null,
constraint PK_Pokoje primary key (ID_Pokoju));



create table Typ_Pokoju( ID_Typu_Pokoju int IDentity(1,1),
Liczba_osob int not null, 
Cena_Doba money not null,
Opis text,
constraint PK_Typ_Pokoju primary key (ID_Typu_Pokoju));



Alter table Historia_Rezerwacji add constraint FK_Pokoje foreign key (ID_Pokoju) references Pokoje(ID_pokoju);
Alter table Historia_Rezerwacji add constraint FK_Goscie foreign key (ID_Goscia) references Goscie(ID_goscia);
Alter table Historia_Rezerwacji add constraint FK_Pracownicy foreign key (Obslugiwany_przez) references Pracownicy(ID_Pracownika);
Alter table Pokoje add constraint FK_Typ_Pokoju foreign key (Typ_Pokoju) references  Typ_pokoju (ID_Typu_Pokoju);
Alter table Dodatkowe_Oplaty add constraint FK_Oplaty foreign key (ID_goscia) references Goscie (ID_Goscia);
Alter table Dodatkowe_oplaty add constraint FK_uslugi foreign key (ID_Uslugi) references Dodatkowe_uslugi(ID_uslugi);
