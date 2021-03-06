USE [RecepcionMSW]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Atendio_Catalogo]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atendio_Catalogo](
	[Id_Acatalogo] [int] IDENTITY(1,1) NOT NULL,
	[Estado_Llamada] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Acatalogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LLamada_Catalogo]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LLamada_Catalogo](
	[Id_Lcatalogo] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Llamada] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Lcatalogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Numeros_Serie]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Numeros_Serie](
	[Id_NSerie] [int] IDENTITY(1,1) NOT NULL,
	[Id_Persona] [int] NOT NULL,
	[NumSerieCampeon] [nvarchar](30) NULL,
	[NumSerieSmart] [nvarchar](30) NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_NSerie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id_Persona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[TelefonoFijo] [nvarchar](100) NULL,
	[TelefonoCelular] [nvarchar](100) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[Empresa] [nvarchar](100) NULL,
	[Dependencia] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Realizo_Recibio_Llamada_Catalogo]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Realizo_Recibio_Llamada_Catalogo](
	[Id_RRLcatalogo] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Llamada_Estado] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_RRLcatalogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro_Llamadas]    Script Date: 14/03/2018 12:31:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro_Llamadas](
	[Id_Rllamadas] [int] IDENTITY(1,1) NOT NULL,
	[Id_Lcatalogo] [int] NOT NULL,
	[Id_Persona] [int] NOT NULL,
	[Id_RRLcatalogo] [int] NOT NULL,
	[Id_Acatalogo] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario] [nvarchar](100) NOT NULL,
	[Notas] [nvarchar](250) NULL,
	[NumSerieCampeon] [nvarchar](30) NULL,
	[NumSerieSmart] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Rllamadas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201802191913186_AutomaticMigration', N'RecepecionMSW.Migrations.Configuration', 0x1F8B0800000000000400DD5C5B6FE3B6127E3F40FF83A0A7F620B57239BBD813D85BA44ED2137473C13ABBA76F0B5AA21D6125CA95A83441D15FD687FEA4F317CE50A22EBCE9622BB6532CB0B0C8E137C3E1901C0E87F9DF9F7F8D7F780A03EB11C7891F91897D343AB42D4CDCC8F3C97262A774F1FD3BFB87F7DFFC637CE1854FD6E782EE84D1414B924CEC074A57A78E93B80F3844C928F4DD384AA2051DB951E8202F728E0F0FFFED1C1D3918206CC0B2ACF1C794503FC4D9077C4E23E2E2154D51701D7938487839D4CC3254EB0685385921174FEC8F1848B10B625CCFFE3BCAE96DEB2CF011C832C3C1C2B61021114514484E3F257846E3882C672B2840C1FDF30A03DD020509E63D38ADC8BB76E6F09875C6A91A16506E9AD028EC097874C2B5E3C8CDD7D2B15D6A0FF477017AA6CFACD7990E27F69587B3A28F51000A90199E4E8398114FECEB92C559B2BAC17454341CE5909731C0FD16C55F4775C403AB73BB83D29A8E4787ECDF81354D039AC67842704A63141C5877E93CF0DD9FF1F37DF41593C9C9D17C71F2EECD5BE49DBCFD173E7953EF29F415E8840228BA8BA3158E4136BC28FB6F5B8ED8CE911B96CD6A6D72AD802DC1C4B0AD6BF4F40193257D802973FCCEB62EFD27EC1525DCB83E111FE61134A2710A9F376910A07980CB7AA79127FBBF81EBF19BB78370BD418FFE321B7A893F4C9C18E6D5471C64B5C983BFCAA79730DE5F38D9651C85EC5BB4AFBCF6CB2C4A639775263292DCA37889A928DDD8A98CB7934933A8E1CDBA40DD7FD36692AAE6AD25651D5A6726142CB63D1B0A795F966F678B3B5BAD60F032D3621A693238DD763592DA1F580255653E475DCD8740B7FECEABE14588FC6080E5B00317F045167E1CE2B2973F46607C88F496F90E2509AC06DE7F50F2D0203AFC1C40F41976D3188C744651B87A716E770F11C137693867B6BF3D5E830DCDFD6FD1257269145F10D66A63BC0F91FB354AE905F1CE11C59FA85B00B2CF7B3FEC0E30883867AE8B93E4128C197BD3085CED02F08AD093E3DE706C89DAB53B320D901FEAFD116931FD5290563E899E42F14B0C643ADFA449D40FD1D227DD442D48CDA2E614ADA272B2BEA232B06E92724AB3A01941AB9C39D560DE5E3642C3BB7B19ECFEFB7B9B6DDEA6B5A0A6C619AC90F8274C700CCB98778728C531A946A0CBBAB10B67211B3EC6F4C5F7A68CD36714A443B35A6B36648BC0F0B32183DDFFD9908909C58FBEC7BC920E87A08218E03BD1EBCF57ED734E926CDBD341E8E6B6996F670D304D97B324895C3F9B059AF0170F5E88F2830F67B54732F2DEC8D110E81818BACFB63C2881BED9B251DD92731C608AAD33370F0F4E51E2224F552374C8EB2158B1A36A04ABA222A270FF547882A5E3983542EC1094C04CF50955A7854F5C7F8582562D492D3B6E61ACEF250FB9E61C0EC984316CD54417E6FA200813A0E4230D4A9B86C64ECDE29A0DD1E0B59AC6BCCD85ADC65D894D6CC5265B7C67835D72FFED450CB359635B30CE66957411C018D0DB8581F2B34A5703900F2EFB66A0D289C960A0DCA5DA8A818A1ADB81818A2A7975069A1F51BB8EBF745EDD37F3140FCADBDFD61BD5B503DB14F4B167A699FB9ED086420B1CABE6793E6795F8896A0E6720273F9F25DCD5954D8481CF3015433695BFABF5439D6610D9889A002B436B01E557810A9032A17A0857C4F21AA5E35E440FD822EED608CBD77E09B666032A76FD4AB44668BE38958DB3D3E9A3EC59690D8A91773A2CD4703406212F5E62C73B28C514975515D3C517EEE30DD73AC607A341412D9EAB4149456706D752619AED5AD239647D5CB28DB424B94F062D159D195C4BDC46DB95A4710A7AB8051BA948DCC2079A6C45A4A3DC6DCABAB193E74AF182B16348AA1A5FA3D5CA27CB5A92152FB1667986D5F4FB59FFC4A330C770DC44937F544A5B72A2518C9658AA05D620E9A51F27F41C5134472CCE33F542854CBBB71A96FF82657DFB5407B1D8070A6AF69BB7D05DE00BBBADEA8E70944BE863C87C9A2C90AEB1007D738BA5BDA100C59AD8FD340AD290985D2C73EBFC06AFDE3E2F5111C68E24BFE24229FA521C5D51F99D86469D16830D53E9C3AC3F54660893C20B0FB4AE7293576A46298254751453E06A67436772667A0E97EC29F61FAD568497995B3C3DA50EC08B7A62D4321C14B05A5D77543109A58E29D6744794324DEA9052550F29EBF9248290F58AB5F00C1AD55374E7A06690D4D1D5DAEEC89A5C923AB4A67A0D6C8DCC725D77544DBA491D5853DD1DBBCA3D9197D13DDEBD8CE7970DB6AFFC90BBD9FE65C07899357198EDAF76975F07AA15F7C4E2B7F50A182FDF4B7B329EF436B0A73CBAB1993D1930CCAB8F700F2E2E3E8D97F7664CE1725B58E09B2EF7CD78FDACF6456D4339EAC92425F7F2C8271DEDC6FC98D5FEA8463977E524B655A81136F7E784E270C40846B35F8369E063B6941704D788F80B9CD03CA1C33E3E3C3A965EE5ECCF0B192749BC40734C353D9311C76C0BB959E411C5EE038AD54C890D5E9154A04A10FA8A78F86962FF9EB53ACDE219EC57567C605D259F88FF6B0A15F7718AAD3FD4CCCF61B2EA3BBCE32805FDE3553C90E8AEF2AB5FBEE44D0FACDB18A6D3A97528297A9DE1179F4DF492266FBA81346B3FA678BDB34D78A5A0459566CBFA8F12E63E1DE4414221E5B7217AFAAEAF68DA47071B216A1E160C8537880A4D0F07D6C1323E1AF0E093668F06FA7556FF88601DD18C0F087CD21F4C7E3ED07D192A5AEE701FD21C99B6B124657A6E4DBFDE281773D77B9392A5BDD1445733B17BC00D9A6DBD998BF2CAB29807DB3A3549CA8361EFD2EE5F3C33795F92912BA77DB739C8DB4C3B6EB856FA5B651BEF417E9C26DF67F739C5DBB635530C78CF1333FB650EEF99B1F16D7EF7F9C1DB3636538078CF8DAD5716F09ED9DAAEF6CF1D5B5AE72D74E739BD6A7A92E12E4717456ECBD9CD43EE70FC9F476004B947993FB5D427893525B8B630AC48CC4CCDD969326365E2287C158A66B6FDFACA37FCC6CE729A66B6869CCE26DE7CFD6FE4CD699A791B322577916DACCD55D46580B7AC634D4954AF29BB58E8494B327B9BCFDA7831FF9A928907518A307B0CB7CBAF27777810950C39757AE40AAB17C5B077D6FE4623ECDF89BFAC20D85F6C24D81576CD92E68A2CA262F396242A48A408CD35A6C8832DF52CA6FE02B914AA59003A7B2B9E05F5D835C81C7B57E436A5AB94429771380F84801773029AF86709D1A2CCE3DB15FB4A86E80288E9B3C0FD2DF931F503AF94FB521313324030EF82877BD9585216F65D3E97483711E908C4D5573A45F7385C050096DC92197AC4EBC806E6F7012F91FB5C45004D20ED0321AA7D7CEEA3658CC2846354EDE1136CD80B9FDEFF1FC7706ACEAA540000, N'6.2.0-61023')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a9ede6d8-137f-4146-bf5f-ecfc55fd2eec', N'AppAdmin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'841f3d5c-4988-49e1-9bbb-883d52bc1eba', N'AppUser')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'19627d33-269c-4ef9-9541-11238c8d8f70', N'841f3d5c-4988-49e1-9bbb-883d52bc1eba')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1f789c7c-e4d0-4533-9ffc-7c3662491b27', N'841f3d5c-4988-49e1-9bbb-883d52bc1eba')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'27a8920a-12d3-41b9-bcfa-0fb9208706b9', N'841f3d5c-4988-49e1-9bbb-883d52bc1eba')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4f8336a7-85d3-4df0-95c0-ebfe244be119', N'841f3d5c-4988-49e1-9bbb-883d52bc1eba')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'87c4e5b7-6304-4141-9d58-caae0648a8b3', N'841f3d5c-4988-49e1-9bbb-883d52bc1eba')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8a356022-6d9a-44a3-8a5c-059c12d12362', N'841f3d5c-4988-49e1-9bbb-883d52bc1eba')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9bb87876-e119-4213-b2cf-fefc39771956', N'841f3d5c-4988-49e1-9bbb-883d52bc1eba')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aece810d-81ae-40fd-9a3f-9ef0fab8ddc5', N'841f3d5c-4988-49e1-9bbb-883d52bc1eba')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'513da60f-e9df-49ce-8d84-e30b3cd4f140', N'a9ede6d8-137f-4146-bf5f-ecfc55fd2eec')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5ea76945-f8ed-47b1-8b54-d51463a3a78e', N'a9ede6d8-137f-4146-bf5f-ecfc55fd2eec')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7036eca8-d848-451c-8328-08bfc5c23199', N'a9ede6d8-137f-4146-bf5f-ecfc55fd2eec')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'84b4fc40-fab5-485d-b214-b35ec0e038e0', N'a9ede6d8-137f-4146-bf5f-ecfc55fd2eec')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a7ec93be-178f-4d69-bdc7-e207e7d7c6ea', N'a9ede6d8-137f-4146-bf5f-ecfc55fd2eec')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'19627d33-269c-4ef9-9541-11238c8d8f70', N'CarlosPizanoA@gmail.com', 0, N'AHR2EGYPTNGLh8gLU2F1x6i3z065WGq5ZN5cGdUn0Ygfzj5vXgtNROr7PN4HsmU6Uw==', N'a8b70b9a-9080-4603-95f1-c34eadfe294c', NULL, 0, 0, NULL, 0, 0, N'CarlosPizanoA')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1f789c7c-e4d0-4533-9ffc-7c3662491b27', N'CarlosPizanoAa@gmail.com', 0, N'ANby4QraLl/tL2auGP7+d1l/SH58AgSzfLkubGBo50Q+MX8KOTBxKD6FBw7f2TgmNA==', N'6d159df9-9022-4661-8649-3a5bea84e22c', NULL, 0, 0, NULL, 0, 0, N'CarlosPizanoAa')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'27a8920a-12d3-41b9-bcfa-0fb9208706b9', N'CarlosPizano@gmail.com', 0, N'AMy6sr33xxWemIanVm5GTBVDBj+lzFvCfJXWILNrMFQLZhrBnrKbTycTV6Y0MDxKZg==', N'3ceb0ff7-641d-42db-96f0-12affda519d1', NULL, 0, 0, NULL, 0, 0, N'CarlosPizano')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4f8336a7-85d3-4df0-95c0-ebfe244be119', N'CarlosPizanoAaq@gmail.com', 0, N'APYfeISmJiUG/QnRfdpqyK8Y3JbdZ/9U6kW8RagbtTLd52pTgA7ba2uHv0cUSaagBQ==', N'cd9f6cfc-9fe2-49a9-be2f-fb591822775f', NULL, 0, 0, NULL, 0, 0, N'CarlosPizanoAaqq')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'513da60f-e9df-49ce-8d84-e30b3cd4f140', N'Carlos@gmail.com', 0, N'AHDTbiwpLP7SRNHo5ZRrL0jn09wIpbJ6kRWbUhcicOYieL+t4ZO1LNAlZx7G6aMT0g==', N'5f930dd3-c92c-4666-832d-8e2eee9252e3', NULL, 0, 0, NULL, 0, 0, N'Carlos')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5ea76945-f8ed-47b1-8b54-d51463a3a78e', N'qwqwqw', 0, N'AOhwpqIesqvj/BGtz65mWq6O8XFggFxd3K44qK/1BDXbLDkYVRQtNnY3nL32XDNblw==', N'2bfc68cc-1768-4cca-83e5-5b5f4f461559', NULL, 0, 0, NULL, 0, 0, N'eqwqqw')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7036eca8-d848-451c-8328-08bfc5c23199', N'Gcontresgeiovani@gmail.com', 0, N'ADwhSpgqKeC+Bh95bexrLZS7+w68TSVGIZ8sFcqF3FqiDofOAXe/SVw3vEMvW3d6OQ==', N'8c4b931a-b32b-4d7f-8a63-784cc6e08a64', NULL, 0, 0, NULL, 0, 0, N'Gcontresgeiovani')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'84b4fc40-fab5-485d-b214-b35ec0e038e0', NULL, 0, N'ADlr409+UHLbbo6QfWEiD/2FfCXxI+XapGanJDnWhFL1fEJOI21Fz9hSmseeGOgUPQ==', N'7f3fa357-1559-4c00-9b5d-758f90508701', NULL, 0, 0, NULL, 0, 0, N'administrador')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'87c4e5b7-6304-4141-9d58-caae0648a8b3', N'Carlos@gmail.coms', 0, N'ADT8b9S9vT0hWSJbHYpqqQn36pzjWthMUJP/sgVDCbrFJRUU6kx4y2N86GSso0OgYA==', N'4c69803e-e3d5-4fef-a688-74e311dbe71b', NULL, 0, 0, NULL, 0, 0, N'Carlos2')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8a356022-6d9a-44a3-8a5c-059c12d12362', N'CarlosPizanodfdf@gmail.com', 0, N'AKHNfFN2XosOjA/yd4Os2mA7zDvZsHY7xSIobIC0DOMtID4UcQx4upX12V9Wa6TiqA==', N'7a2bb789-baf1-4b3c-89b1-e2ea71d3a0a3', NULL, 0, 0, NULL, 0, 0, N'CarlosPizanodfdf')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9bb87876-e119-4213-b2cf-fefc39771956', N'carlos.pizano@msw.com.mx', 0, N'AH9jyTSZ/sYMt3sUfetAdpC3jaOCPejFHOHgOelVga53wBKr7dTjDpSuWOfViQ0OCg==', N'ed97d696-3c85-45ae-be31-a5a80112901e', NULL, 0, 0, NULL, 0, 0, N'carlosp2')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a7ec93be-178f-4d69-bdc7-e207e7d7c6ea', N'ewwec', 0, N'ABprGdQ7eOd4oi7nOO5+2/GYl81A2MVdku7PwC/iZoH3cQG5UTm1ch1xfGcJJ2qu3Q==', N'6a06eaa9-f2cd-4318-aac8-1a59b7a26a66', NULL, 0, 0, NULL, 0, 0, N'xsaxaxasx')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aece810d-81ae-40fd-9a3f-9ef0fab8ddc5', N'cpizano0@ucol.mx', 0, N'AHY6EloGPTqWom8tSkC7FJ/lE+6Q9UogsPo3yVWnCZ2W+QIwCYHyGQ3EZLVorkiJbA==', N'67257d5d-d028-4909-8880-3bd38134419d', NULL, 0, 0, NULL, 0, 0, N'carlosp')
SET IDENTITY_INSERT [dbo].[Atendio_Catalogo] ON 

INSERT [dbo].[Atendio_Catalogo] ([Id_Acatalogo], [Estado_Llamada], [Descripcion]) VALUES (1, N'Sí', N'')
INSERT [dbo].[Atendio_Catalogo] ([Id_Acatalogo], [Estado_Llamada], [Descripcion]) VALUES (2, N'No', N'')
INSERT [dbo].[Atendio_Catalogo] ([Id_Acatalogo], [Estado_Llamada], [Descripcion]) VALUES (3, N'Pendiente', N'')
SET IDENTITY_INSERT [dbo].[Atendio_Catalogo] OFF
SET IDENTITY_INSERT [dbo].[LLamada_Catalogo] ON 

INSERT [dbo].[LLamada_Catalogo] ([Id_Lcatalogo], [Tipo_Llamada], [Descripcion]) VALUES (1, N'Venta', NULL)
INSERT [dbo].[LLamada_Catalogo] ([Id_Lcatalogo], [Tipo_Llamada], [Descripcion]) VALUES (2, N'Soporte', NULL)
INSERT [dbo].[LLamada_Catalogo] ([Id_Lcatalogo], [Tipo_Llamada], [Descripcion]) VALUES (3, N'Familar', NULL)
SET IDENTITY_INSERT [dbo].[LLamada_Catalogo] OFF
SET IDENTITY_INSERT [dbo].[Numeros_Serie] ON 

INSERT [dbo].[Numeros_Serie] ([Id_NSerie], [Id_Persona], [NumSerieCampeon], [NumSerieSmart], [Fecha]) VALUES (1, 5, N'qwdwqdq', N'wqdwqdwqd', CAST(N'2018-03-14T12:20:34.553' AS DateTime))
SET IDENTITY_INSERT [dbo].[Numeros_Serie] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (3, N'Pancho', N'sasasa', N'saasas', N'sa', N'asasa', N'sq')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (5, N'Carlos Enrique Pizano Saucedo', N'3114297', N'3121160454', N'carlospizano219@gmail.com', N'Maldonado Software ', N'Independiente')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (12, N'c', N'cwcwq', N'ccwq', N'cwqcwcwq', N'cwqccwq', N'cwcwq')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (13, N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (14, N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (15, N'cwqcwqcwcwqcwqcwqcwcwqcwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwqcwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq', N'cwqcwqcwcwq')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (18, N'chusssyututyuytutuyuty', N'12345', N'12345678', N'chuy@msw.com.mx', N'MSW', NULL)
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (19, N'chusssyututyuytutuyuty', N'12345', N'12345678', N'chuy@msw.com.mx', N'MSW', NULL)
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (21, N'chusssyututyuytutuyuty', N'12345', N'12345678', N'chuy@msw.com.mx', N'MSW', NULL)
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (22, N'chusssyututyuytutuyuty', N'12345', N'12345678', N'chuy@msw.com.mx', N'MSW', NULL)
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1004, N'weew', N'234342', N'234', N'qdwqd@qwqdwq.com', N'cwecwe', N'wc')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1005, N'dwqdwq', N'121', N'1212', N'122@qdwq.com', N'dqwdqwd', N'qdwwqd')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1006, N'wecwe', N'2323', N'2332', N'cwqcwqcwcwq@wqdwq.com', N'cwec', N'wewecew')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1007, N'adrian', N'121', N'12321', N'wec@q.com', N'wecwe', N'wefwe')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1008, N'juan', N'213213', N'123213', N'wqd@asas.com.mx', N'qdwqd', N'qfwqef')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1009, N'fwefwef', N'234234', N'23423', N'dfwf@sad.com', N'wefwef', N'wefwfwef')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1010, N'qwer', N'123', N'213', N'Carlos@gmail.com', N'123', N'213')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1011, N'asd', N'234', N'234', N'Carlos@gmail.com', N'234', N'324')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1012, N'qwz', N'123', N'123', N'Carlos@gmail.com', N'23q4', N'wqr')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1013, N'aaaa', N'123', N'123', N'Carlos@gmail.com', N'1', N'231º123')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1014, N'as', N'123', N'123', N'Carlos@gmail.com', N'21', N'123')
INSERT [dbo].[Persona] ([Id_Persona], [Nombre], [TelefonoFijo], [TelefonoCelular], [Correo], [Empresa], [Dependencia]) VALUES (1015, N'213', N'213', N'213', N'Carlos@gmail.com', N'123', N'123')
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[Realizo_Recibio_Llamada_Catalogo] ON 

INSERT [dbo].[Realizo_Recibio_Llamada_Catalogo] ([Id_RRLcatalogo], [Tipo_Llamada_Estado], [Descripcion]) VALUES (1, N'Realizada', N'')
INSERT [dbo].[Realizo_Recibio_Llamada_Catalogo] ([Id_RRLcatalogo], [Tipo_Llamada_Estado], [Descripcion]) VALUES (2, N'Recibida', N'')
SET IDENTITY_INSERT [dbo].[Realizo_Recibio_Llamada_Catalogo] OFF
SET IDENTITY_INSERT [dbo].[Registro_Llamadas] ON 

INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (7, 2, 5, 2, 1, CAST(N'2018-02-28T10:05:47.717' AS DateTime), N'Juan Rodolfo Fuentes', N'El cliente solicito como activar su llave de acceso al software Campeon Plus Smart', N'4512PX4512', N'4512SX4512')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (8, 2, 5, 2, 2, CAST(N'2018-02-28T16:47:43.833' AS DateTime), N'weqfdwefdewfwefefewfwe', N'weqfdwefdewfwefefewfweweqfdwefdewfwefefewfweweqfdwefdewfwefefewfweweqfdwefdewfwefefewfwe', N'weqfdwefdewfwefefewfwe', N'weqfdwefdewfwefefewfwe')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (10, 1, 5, 1, 1, CAST(N'2018-03-05T13:12:39.167' AS DateTime), N'xas', N'as', N'as', N'as')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (11, 1, 5, 1, 2, CAST(N'2018-03-05T13:35:58.017' AS DateTime), N'ACSACACSAC', N'SASACSACAS', N'SCSACSAC', N'ASCSACA')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (12, 2, 3, 1, 1, CAST(N'2018-03-09T13:18:58.393' AS DateTime), N'asasasa', N'asasa', N'asasa', N'asas')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (13, 1, 3, 2, 1, CAST(N'2018-03-09T13:18:45.297' AS DateTime), N'as', N'1', N'as', N'as')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1002, 3, 5, 1, 3, CAST(N'2018-03-09T16:16:31.103' AS DateTime), N'as', N'wqxswqdwqsdwqdwqdwqdwqdwqd', N'as', N'as')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1003, 2, 3, 1, 2, CAST(N'2018-03-05T13:43:13.207' AS DateTime), N'as', N'1', N'as', N'asasqq111111')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1004, 1, 3, 1, 1, CAST(N'2018-03-09T17:46:32.130' AS DateTime), N'rgrge', N'egregerge', N'ergreg', N'ergergre')
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1005, 1, 5, 1, 2, CAST(N'2018-03-09T17:47:25.777' AS DateTime), N'qqwdwq', N'dwqdwqdwq', NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1006, 1, 5, 2, 1, CAST(N'2018-03-09T17:50:54.540' AS DateTime), N'asasasas', N'asasasasa', NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1007, 1, 5, 1, 1, CAST(N'2018-03-09T17:51:11.777' AS DateTime), N'asasas', N'asasas', NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1008, 1, 5, 1, 2, CAST(N'2018-03-09T17:51:23.820' AS DateTime), N'sadsad', N'dasdsad', NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1009, 1, 13, 1, 1, CAST(N'2018-03-09T17:52:48.670' AS DateTime), N'qw', N'1', NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1010, 1, 5, 1, 1, CAST(N'2018-03-09T17:55:03.463' AS DateTime), N'wqdwqdwqdwqd', N'wqdwqdqwdq', NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1011, 1, 1007, 1, 1, CAST(N'2018-03-09T17:55:59.380' AS DateTime), N'asasas', N'asasas', NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1012, 1, 18, 1, 3, CAST(N'2018-03-12T09:41:27.913' AS DateTime), N'12121', NULL, NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1013, 1, 3, 1, 1, CAST(N'2018-03-12T09:43:42.260' AS DateTime), N'12', NULL, NULL, NULL)
INSERT [dbo].[Registro_Llamadas] ([Id_Rllamadas], [Id_Lcatalogo], [Id_Persona], [Id_RRLcatalogo], [Id_Acatalogo], [Fecha], [Usuario], [Notas], [NumSerieCampeon], [NumSerieSmart]) VALUES (1014, 1, 5, 1, 1, CAST(N'2018-03-14T12:20:34.553' AS DateTime), N'qwsqsqs', NULL, N'qwdwqdq', N'wqdwqdwqd')
SET IDENTITY_INSERT [dbo].[Registro_Llamadas] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Numeros_Serie]  WITH CHECK ADD FOREIGN KEY([Id_Persona])
REFERENCES [dbo].[Persona] ([Id_Persona])
GO
ALTER TABLE [dbo].[Registro_Llamadas]  WITH CHECK ADD FOREIGN KEY([Id_Acatalogo])
REFERENCES [dbo].[Atendio_Catalogo] ([Id_Acatalogo])
GO
ALTER TABLE [dbo].[Registro_Llamadas]  WITH CHECK ADD FOREIGN KEY([Id_Lcatalogo])
REFERENCES [dbo].[LLamada_Catalogo] ([Id_Lcatalogo])
GO
ALTER TABLE [dbo].[Registro_Llamadas]  WITH CHECK ADD FOREIGN KEY([Id_Persona])
REFERENCES [dbo].[Persona] ([Id_Persona])
GO
ALTER TABLE [dbo].[Registro_Llamadas]  WITH CHECK ADD FOREIGN KEY([Id_RRLcatalogo])
REFERENCES [dbo].[Realizo_Recibio_Llamada_Catalogo] ([Id_RRLcatalogo])
GO
