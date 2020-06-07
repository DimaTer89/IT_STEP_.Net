use Dictionary
go

create table Dictionary
(
  id int identity(1,1) not null,
  englishWord nvarchar(max) not null,
  russianWord nvarchar(max) not null,
  picture varbinary(max) null
  primary key(id)
)



insert into Dictionary (englishWord,russianWord,picture) select 'dog',N'собака',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\dog.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'cat',N'кот',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\cat.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'cow',N'корова',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\cow.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'male',N'мужчина',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\male.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'female',N'женщина',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\female.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'cup',N'чашка',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\cup.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'television',N'телевизор',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\television.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'fridge',N'холодильник',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\fridge.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'sofa',N'диван',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\sofa.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'table',N'стол',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\table.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'armchair',N'кресло',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\armchair.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'granny',N'бабушка',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\granny.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'granddad',N'дедушка',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\granddad.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'book',N'книга',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\book.jpg',single_blob) as image
insert into Dictionary (englishWord,russianWord,picture) select 'pencil',N'карандаш',BulkColumn from Openrowset (bulk N'D:\ADO.Net\HomeWorkADO_NET2\HomeWorkADO_NET2\pencil.jpg',single_blob) as image



select * from Dictionary



