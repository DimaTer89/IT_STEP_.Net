use Education_Institution
go 

drop table Groups
go

drop table Students
go


create table Groups
( 
   id int not null identity(1,1),
   nameGroup nvarchar(max) not null,
   curatorSurname nvarchar(max) not null,
   primary key(id),
)

create table Students
(
   id int not null identity(0,1),
   idGroup int not null,
   Surname nvarchar(max) not null,
   OOPScore int not null,
   WinFormsScore int not null,
   ADO_NETScore int not null,
   primary key(id),
   foreign key (idGroup) references Groups(id)
)

delete from Groups

delete  from Students

insert into Groups (nameGroup,curatorSurname) values (N'ИС-15',N'Алымова Т.В.')
insert into Groups (nameGroup,curatorSurname) values (N'ПГС-15',N'Ашурко Н.И.')
insert into Groups (nameGroup,curatorSurname) values (N'СДА-16',N'Александров Д.Ю.')
insert into Groups (nameGroup,curatorSurname) values (N'МИС-17',N'Бойков К.Р.')
insert into Groups (nameGroup,curatorSurname) values (N'АРХ-15',N'Бирилло Н.С.')


insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (1,N'Иванов',9,8,10)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (1,N'Петров',7,7,6)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (2,N'Сидоров',9,8,9)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (2,N'Лосев',9,9,9)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (3,N'Войлошников',10,10,10)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (3,N'Душко',9,8,6)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (4,N'Омельянчук',9,8,8)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (4,N'Емельянчикова',9,8,7)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (5,N'Рыжова',9,8,6)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (5,N'Симанчук',4,4,4)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (2,N'Бодун',6,7,5)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (3,N'Морозов',7,8,9)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (4,N'Кончиц',9,8,10)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (1,N'Дудко',9,8,9)
insert into Students (idGroup,Surname,OOPScore,WinFormsScore,ADO_NETScore) values (5,N'Мандрик',9,7,10)

select * from Groups

select * from Students