use Hotel;

--Pracownicy

insert into Pracownicy values ('Bonifacy' , 'Wysocki', '673087017', 'BonifacyWysocki@rhyta.com', '2000-5-28');
insert into Pracownicy values ('S³awomir' , 'Michalski', '792902990', 'SlawomirMichalski@teleworm.us', '2000-3-26');
insert into Pracownicy values ('Patrycja' , 'Zawadzka', '723721874', 'PatrycjaZawadzka@jourrapide.com', '2000-7-8');
insert into Pracownicy values ('Julita' , 'Kowalczyk', '888480335', 'JulitaKowalczyk@dayrep.com', '2000-8-22');
insert into Pracownicy values ('Dawid' , 'Kalinowski', '519646322', 'DawidKalinowski@rhyta.com', '2000-10-18');
insert into Pracownicy values ('Henio' , 'Rutkowski', '511879607', 'HenioRutkowski@rhyta.com', '2000-11-5');

--Goscie

insert into Goscie values ('Marzena', 'Czerwinska', '665068888', '64031689108')
insert into Goscie values ('Krystyna', 'Sobczak', '661355122', '63050495369')
insert into Goscie values ('Kazimiera', 'Kaczmarek', '787971813', '48021754926')
insert into Goscie values ('Felicja', 'Kwiatkowska', '537951508', '57053062709')
insert into Goscie values ('Eustachy', 'WoŸniak', '885054220', '40052850772')
insert into Goscie values ('Judyta', 'Gorska', '516116320', '87031145564')
insert into Goscie values ('Krystyn', 'Pawlak', '609235198', '38062867091')
insert into Goscie values ('Asia', 'Czarnecka', '691542645', '41121613722')
insert into Goscie values ('Czes³awa', 'Zielinska', '884364272', '95062829087')
insert into Goscie values ('Julianna', 'Tomaszewska', '887009078', '53071713540')

--Typy Pokojów

insert into Typ_Pokoju values (4, 200, 'Standardowy');
insert into Typ_Pokoju values (3, 100, 'Ekonomiczny');
insert into Typ_Pokoju values (3, 300, 'Superior');
insert into Typ_Pokoju values (4, 450, 'Deluxe');
insert into Typ_Pokoju values (2, 600, 'Premier');
insert into Typ_Pokoju values (2, 550, 'Executive');

--Pokoje

insert into Pokoje values (101,1);
insert into Pokoje values (102,1);
insert into Pokoje values (103,2);
insert into Pokoje values (104,2);
insert into Pokoje values (105,2);
insert into Pokoje values (106,2);
insert into Pokoje values (201,3);
insert into Pokoje values (202,3);
insert into Pokoje values (203,3);
insert into Pokoje values (204,6);
insert into Pokoje values (205,6);
insert into Pokoje values (301,4);
insert into Pokoje values (302,4);
insert into Pokoje values (303,4);
insert into Pokoje values (304,5);

--Dodatkowe Us³ugi

insert into Dodatkowe_uslugi values ('Parking',50);
insert into Dodatkowe_uslugi values ('Sniadanie',20); --Us³ugi Parking oraz Sejf s¹ jednorazowe na ca³y czas pobytu
insert into Dodatkowe_uslugi values ('Pranie ubran',40);
insert into Dodatkowe_uslugi values ('Sejf',25);
insert into Dodatkowe_uslugi values ('Internet doba',5);

--Dodatkowe Op³aty

insert into Dodatkowe_Oplaty values (4, 1, '2020-12-5');
insert into Dodatkowe_Oplaty values (10, 3, '2020-12-30');
insert into Dodatkowe_Oplaty values (1, 5, '2020-12-3');
insert into Dodatkowe_Oplaty values (9, 4, '2020-12-8');
insert into Dodatkowe_Oplaty values (8, 3, '2020-12-20');
insert into Dodatkowe_Oplaty values (1, 5, '2020-12-5');
insert into Dodatkowe_Oplaty values (2, 2, '2020-12-3');
insert into Dodatkowe_Oplaty values (3, 5, '2020-12-6');
insert into Dodatkowe_Oplaty values (6, 1, '2020-12-7');
insert into Dodatkowe_Oplaty values (3, 2, '2020-12-3');
insert into Dodatkowe_Oplaty values (10, 5, '2020-12-28');
insert into Dodatkowe_Oplaty values (3, 1, '2020-12-2');
insert into Dodatkowe_Oplaty values (8, 4, '2020-12-12');
insert into Dodatkowe_Oplaty values (4, 3, '2020-12-10');
insert into Dodatkowe_Oplaty values (5, 2, '2020-12-11');
insert into Dodatkowe_Oplaty values (10, 1, '2020-12-27');
insert into Dodatkowe_Oplaty values (2, 3, '2020-12-2');
insert into Dodatkowe_Oplaty values (4, 4, '2020-12-5');
insert into Dodatkowe_Oplaty values (7, 2, '2020-12-17');
insert into Dodatkowe_Oplaty values (3, 3, '2020-12-8');
insert into Dodatkowe_Oplaty values (8, 2, '2020-12-24');
insert into Dodatkowe_Oplaty values (1, 4, '2021-01-02');

--Historia Rezerwacji

insert into Historia_Rezerwacji values (15, 1, 1,'2020-12-1','2020-12-7');
insert into Historia_Rezerwacji values (1 , 2, 5,'2020-12-2','2020-12-3');
insert into Historia_Rezerwacji values (4 , 3, 4,'2020-12-2','2020-12-9');
insert into Historia_Rezerwacji values (5 , 4, 3,'2020-12-5','2020-12-10');
insert into Historia_Rezerwacji values (6 , 5, 4,'2020-12-7','2020-12-12');
insert into Historia_Rezerwacji values (9 , 6, 2,'2020-12-7','2020-12-17');
insert into Historia_Rezerwacji values (8 , 7, 3,'2020-12-11','2020-12-18');
insert into Historia_Rezerwacji values (12 , 8, 1,'2020-12-12','2020-12-26');
insert into Historia_Rezerwacji values (15 , 9, 3,'2020-12-8','2020-12-15');
insert into Historia_Rezerwacji values (12 , 10, 4,'2020-12-27','2021-1-11');
insert into Historia_Rezerwacji values (15 , 1, 2, '2021-01-02', '2021-01-16');
