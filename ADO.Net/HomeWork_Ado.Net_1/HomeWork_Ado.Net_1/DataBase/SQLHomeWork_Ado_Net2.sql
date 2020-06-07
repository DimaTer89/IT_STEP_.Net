select Surname,OOPScore,WinFormsScore,ADO_NETScore from Students

select nameGroup,curatorSurname from Groups

select stud.Surname,gr.nameGroup,cast((stud.OOPScore+stud.WinFormsScore+stud.ADO_NETScore)/3.as numeric(4,2)) Average_Ball from Students stud
left join Groups gr on gr.id=stud.idGroup

select count(*) from Students s
left join Groups g on g.id=s.idGroup
where g.id=1 and (s.OOPScore+s.WinFormsScore+s.ADO_NETScore)/3.<=4