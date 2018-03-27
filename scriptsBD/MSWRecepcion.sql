Use RecepcionMSW
GO
create table Persona(
	Id_Persona int not null identity,
	Nombre nvarchar(100) not null,
	TelefonoFijo nvarchar(100) null,
	TelefonoCelular nvarchar(100)not null,
	Correo nvarchar(100)not null,
	Empresa nvarchar(100)null,
	Dependencia nvarchar(100)null,
	primary key(Id_persona),
);
GO
create table LLamada_Catalogo(
	Id_Lcatalogo int not null identity,
	Tipo_Llamada nvarchar(100) not null,
	Descripcion nvarchar(100) null,

	primary key(Id_Lcatalogo)
);
create table Atendio_Catalogo(
	Id_Acatalogo int not null identity,
	Estado_Llamada nvarchar(100) not null,
	Descripcion nvarchar(100) null,

	primary key(Id_Acatalogo)
);
create table Realizo_Recibio_Llamada_Catalogo(
	Id_RRLcatalogo int not null identity,
	Tipo_Llamada_Estado nvarchar(100) not null,
	Descripcion nvarchar(100) null,

	primary key(Id_RRLcatalogo)
);
create table Registro_Llamadas(
	Id_Rllamadas int not null identity,
	Id_Lcatalogo int not null,
	Id_Persona int not null,
	Id_RRLcatalogo int not null,
	Id_Acatalogo int not null,
	Fecha datetime not null,
	Usuario nvarchar(100) not null,
	Notas nvarchar(250)  null,
	NumSerieCampeon nvarchar(30) null,
	NumSerieSmart nvarchar(30) null,
	
	primary key(Id_Rllamadas),
	foreign key(Id_Lcatalogo) references Llamada_Catalogo(Id_Lcatalogo),
	foreign key(Id_Persona) references Persona(Id_Persona),
	foreign key(Id_RRLcatalogo) references Realizo_Recibio_Llamada_Catalogo(Id_RRLcatalogo),
	foreign key(Id_Acatalogo) references Atendio_Catalogo(Id_Acatalogo)
);



