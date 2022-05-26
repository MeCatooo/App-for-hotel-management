use Hotel;

--Pokoje w których nikt nigdy nie nocowa³

select Nr_Pokoju from Pokoje

except

select p.Nr_Pokoju from Historia_Rezerwacji h left join Pokoje p on h.Id_Pokoju=p.Id_Pokoju;

--Aktualnie wolne pokoje

select Nr_Pokoju from Pokoje

except

select p.Nr_Pokoju from Historia_Rezerwacji h
right join Pokoje p on h.Id_Pokoju=p.Id_Pokoju where Rezerwacja_Do>GETDATE() ;

--Kto gdzie nocowa³ i ile zap³aci³ w ostatnim tygodniu

select g.Imie, (sum(case when o.Data_Wykonania between h.Rezerwacja_oD and h.Rezerwacja_Do then u.cena end) +t.cena_doba*(DATEDIFF(day,h.Rezerwacja_oD,h.Rezerwacja_Do)))  as 'cena za calosc', 
p.Nr_Pokoju as 'Numer Pokoju' from Historia_rezerwacji h 
	inner join Pokoje p on h.Id_pokoju=p.ID_pokoju
	inner join Goscie g on h.ID_goscia=g.ID_Goscia
	inner join Typ_Pokoju t on p.Typ_Pokoju=t.ID_typu_pokoju
	inner join Dodatkowe_Oplaty o on h.Id_goscia=o.Id_goscia
	inner join Dodatkowe_Uslugi u on o.ID_Uslugi=u.Id_Uslugi 
where (h.Rezerwacja_Od between (GETDATE()-7) and GETDATE()) or 
(h.Rezerwacja_Do between (GETDATE() - 7) and GETDATE()) or
(GETDATE() between h.Rezerwacja_Od and Rezerwacja_Do)
group by g.Imie, t.cena_doba, h.Rezerwacja_Do , Rezerwacja_Od, p.Nr_Pokoju, h.ID_Rezerwacja;
