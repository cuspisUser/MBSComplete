/****** Object:  Table [dbo].[DefiniranjeObveze]    Script Date: 22.4.2016. 11:32:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DefiniranjeObveze](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[idKorisnik] [int] NOT NULL,
	[Naziv] [nvarchar](100) NOT NULL,
	[TS] [datetime] NOT NULL,
 CONSTRAINT [PK_DefiniranjeObveze] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[DefiniranjePotrazivanja]    Script Date: 22.4.2016. 11:32:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DefiniranjePotrazivanja](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[idKorisnik] [int] NOT NULL,
	[Naziv] [nvarchar](100) NOT NULL,
	[TS] [datetime] NOT NULL,
 CONSTRAINT [PK_DefiniranjePotrazivanja] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[DefiniranjeObvezaStavke]    Script Date: 21.4.2016. 12:37:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DefiniranjeObvezaStavke](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[idDefiniranjeObveza] [int] NOT NULL,
	[idKonto] [nvarchar](14) NOT NULL,
 CONSTRAINT [PK_DefiniranjeObvezaStavke] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DefiniranjeObvezaStavke]  WITH CHECK ADD  CONSTRAINT [FK_DefiniranjeObvezaStavke_DefiniranjeObveze] FOREIGN KEY([idDefiniranjeObveza])
REFERENCES [dbo].[DefiniranjeObveze] ([ID])
GO

ALTER TABLE [dbo].[DefiniranjeObvezaStavke] CHECK CONSTRAINT [FK_DefiniranjeObvezaStavke_DefiniranjeObveze]
GO

ALTER TABLE [dbo].[DefiniranjeObvezaStavke]  WITH CHECK ADD  CONSTRAINT [FK_DefiniranjeObvezaStavke_KONTO] FOREIGN KEY([idKonto])
REFERENCES [dbo].[KONTO] ([IDKONTO])
GO

ALTER TABLE [dbo].[DefiniranjeObvezaStavke] CHECK CONSTRAINT [FK_DefiniranjeObvezaStavke_KONTO]
GO


/****** Object:  Table [dbo].[DefiniranjePotrazivanjaStavke]    Script Date: 21.4.2016. 12:37:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DefiniranjePotrazivanjaStavke](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[idDefiniranjePotrazivanja] [int] NOT NULL,
	[idKonto] [nvarchar](14) NOT NULL,
 CONSTRAINT [PK_DefiniranjePotrazivanjaStavke] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DefiniranjePotrazivanjaStavke]  WITH CHECK ADD  CONSTRAINT [FK_DefiniranjePotrazivanjaStavke_DefiniranjePotrazivanja] FOREIGN KEY([idDefiniranjePotrazivanja])
REFERENCES [dbo].[DefiniranjePotrazivanja] ([ID])
GO

ALTER TABLE [dbo].[DefiniranjePotrazivanjaStavke] CHECK CONSTRAINT [FK_DefiniranjePotrazivanjaStavke_DefiniranjePotrazivanja]
GO

ALTER TABLE [dbo].[DefiniranjePotrazivanjaStavke]  WITH CHECK ADD  CONSTRAINT [FK_DefiniranjePotrazivanjaStavke_KONTO] FOREIGN KEY([idKonto])
REFERENCES [dbo].[KONTO] ([IDKONTO])
GO

ALTER TABLE [dbo].[DefiniranjePotrazivanjaStavke] CHECK CONSTRAINT [FK_DefiniranjePotrazivanjaStavke_KONTO]
GO


--insert obveza
GO
SET IDENTITY_INSERT [dbo].[DefiniranjeObveze] ON 

GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (1, 1, N'Za lijekove', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (2, 1, N'Za sanitetski materijal, krv i krvne derivate i sl.', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (3, 1, N'Za živežne namirnice', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (4, 1, N'Za energiju', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (5, 1, N'Za ostale materijale i reprodukcijski materijal', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (6, 1, N'Za proizvodne i neproizvodne usluge', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (7, 1, N'Za opremu (osnovna sredstva)', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (8, 1, N'Obveze prema zaposlenicima', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (9, 1, N'Obveze za usluge drugih zdravstvenih ustanova', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (10, 1, N'Obveze prema komitentnim bankama za kredite', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (11, 1, N'Ostale nespomenute obveze', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjeObveze] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (12, 1, N'Obveze prema HZZO za manje izvršeni rad', CAST(N'2016-04-21 00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[DefiniranjeObveze] OFF
GO


--insert potrazivanja
GO
SET IDENTITY_INSERT [dbo].[DefiniranjePotrazivanja] ON 

GO
INSERT [dbo].[DefiniranjePotrazivanja] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (1, 1, N'Potraživanja od HZZO po osnovi pružanja zdravstvene zaštite', CAST(N'2016-04-02 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjePotrazivanja] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (2, 1, N'Potraživanja od HZZO-a temeljem ugovora za usluge izvan ugovorenog', CAST(N'2016-04-22 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjePotrazivanja] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (3, 1, N'Potraživanja od dopunskog zdravstvenog osiguranja', CAST(N'2016-04-22 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjePotrazivanja] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (4, 1, N'Potraživanja od HZZOzzr', CAST(N'2016-04-22 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjePotrazivanja] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (5, 1, N'Potraživanja od drugih zdravstvenih ustanova', CAST(N'2016-04-12 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DefiniranjePotrazivanja] ([ID], [idKorisnik], [Naziv], [TS]) VALUES (6, 1, N'Ostala potraživanja', CAST(N'2016-04-22 00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[DefiniranjePotrazivanja] OFF
GO


/****** Object:  StoredProcedure [dbo].[spObvezeNaDan]    Script Date: 26.4.2016. 9:41:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spObvezeNaDan]
(
@datum datetime
)
AS
BEGIN

Select Naziv,
(Select ISNull(Sum(Potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjeObvezaStavke Where idDefiniranjeObveza = DefiniranjeObveze.ID)
And IDDOKUMENT = 2 And GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.DATUMDOKUMENTA <= @datum) UkupneObveze,
(Select ISNull(Sum(Potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjeObvezaStavke Where idDefiniranjeObveza = DefiniranjeObveze.ID)
And IDDOKUMENT = 2 And GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.GKDATUMVALUTE <= @datum) UkupneObvezeDospjele,
(Select ISNull(Sum(Potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjeObvezaStavke Where idDefiniranjeObveza = DefiniranjeObveze.ID)
And IDDOKUMENT = 2 And GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -90, @datum) And  @datum) Dospjelo90,
(Select ISNull(Sum(Potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjeObvezaStavke Where idDefiniranjeObveza = DefiniranjeObveze.ID)
And IDDOKUMENT = 2 And GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -120, @datum) And DATEADD(DAY, -91, @datum)) Dospjelo90do120,
(Select ISNull(Sum(Potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjeObvezaStavke Where idDefiniranjeObveza = DefiniranjeObveze.ID)
And IDDOKUMENT = 2 And GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -150, @datum) And DATEADD(DAY, -121, @datum)) Dospjelo120do150,
(Select ISNull(Sum(Potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjeObvezaStavke Where idDefiniranjeObveza = DefiniranjeObveze.ID)
And IDDOKUMENT = 2 And GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datum) And DATEADD(DAY, -151, @datum)) Dospjelo150do180,
(Select ISNull(Sum(Potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjeObvezaStavke Where idDefiniranjeObveza = DefiniranjeObveze.ID)
And IDDOKUMENT = 2 And GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -365, @datum) And DATEADD(DAY, -181, @datum)) Dospjelo180do365,
(Select ISNull(Sum(Potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjeObvezaStavke Where idDefiniranjeObveza = DefiniranjeObveze.ID)
And IDDOKUMENT = 2 And GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -366, @datum)) DospjeloPreko365,
(Select KORISNIK1NAZIV From KORISNIK) As Korisnik, 
(Select KORISNIK1ADRESA + ', ' + KORISNIK1MJESTO From KORISNIK) As KorisnikAdresa,
(Select KORISNIKOIB From KORISNIK) As KorisnikOIB
From DefiniranjeObveze

END
GO


/****** Object:  StoredProcedure [dbo].[spPotrazivanjaNaDan]    Script Date: 26.4.2016. 9:41:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPotrazivanjaNaDan]
(
@datum datetime
)
AS
BEGIN

Select Naziv,
(Select ISNull(Sum(duguje - Potrazuje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjePotrazivanjaStavke Where idDefiniranjePotrazivanja = DefiniranjePotrazivanja.ID)
And IDDOKUMENT = 3 And GKSTAVKA.IDKONTO like '1%' And GKSTAVKA.DATUMDOKUMENTA <= @datum) UkupnaPotrazivanja,
(Select ISNull(Sum(duguje - Potrazuje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjePotrazivanjaStavke Where idDefiniranjePotrazivanja = DefiniranjePotrazivanja.ID)
And IDDOKUMENT = 3 And GKSTAVKA.IDKONTO like '1%' And GKSTAVKA.GKDATUMVALUTE <= @datum) UkupnoDospjelaPotrazivanja,
(Select ISNull(Sum(duguje - Potrazuje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjePotrazivanjaStavke Where idDefiniranjePotrazivanja = DefiniranjePotrazivanja.ID)
And IDDOKUMENT = 3 And GKSTAVKA.IDKONTO like '1%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -90, @datum) And  @datum)  Dospjelo90,
(Select ISNull(Sum(duguje - Potrazuje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjePotrazivanjaStavke Where idDefiniranjePotrazivanja = DefiniranjePotrazivanja.ID)
And IDDOKUMENT = 3 And GKSTAVKA.IDKONTO like '1%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -120, @datum) And DATEADD(DAY, -91, @datum)) Dospjelo90do120,
(Select ISNull(Sum(duguje - Potrazuje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjePotrazivanjaStavke Where idDefiniranjePotrazivanja = DefiniranjePotrazivanja.ID)
And IDDOKUMENT = 3 And GKSTAVKA.IDKONTO like '1%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -150, @datum) And DATEADD(DAY, -121, @datum)) Dospjelo120do150,
(Select ISNull(Sum(duguje - Potrazuje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjePotrazivanjaStavke Where idDefiniranjePotrazivanja = DefiniranjePotrazivanja.ID)
And IDDOKUMENT = 3 And GKSTAVKA.IDKONTO like '1%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datum) And DATEADD(DAY, -151, @datum)) Dospjelo150do180,
(Select ISNull(Sum(duguje - Potrazuje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjePotrazivanjaStavke Where idDefiniranjePotrazivanja = DefiniranjePotrazivanja.ID)
And IDDOKUMENT = 3 And GKSTAVKA.IDKONTO like '1%' And GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -365, @datum) And DATEADD(DAY, -181, @datum)) Dospjelo180do365,
(Select ISNull(Sum(duguje - Potrazuje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO IN (Select idKonto From DefiniranjePotrazivanjaStavke Where idDefiniranjePotrazivanja = DefiniranjePotrazivanja.ID)
And IDDOKUMENT = 3 And GKSTAVKA.IDKONTO like '1%' And GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -366, @datum)) DospjeloPreko365,
(Select KORISNIK1NAZIV From KORISNIK) As Korisnik, 
(Select KORISNIK1ADRESA + ', ' + KORISNIK1MJESTO From KORISNIK) As KorisnikAdresa,
(Select KORISNIKOIB From KORISNIK) As KorisnikOIB
From DefiniranjePotrazivanja

END
GO


GO
Begin
Alter table URA Add OsnovicaPPO money NOT NULL Default 0
Alter table URA Add MozePPO money NOT NULL Default 0
Alter table URA Add NeMozePPO money NOT NULL Default 0
End


/****** Object:  StoredProcedure [dbo].[S_FIN_URA_PLACANJE]    Script Date: 26.4.2016. 14:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[S_FIN_URA_PLACANJE]
	(
		@iddokument int = null,
		@od int = null,
		@doo int = null,
		@dat1 datetime,
		@dat2 datetime
	)
AS
SELECT     TOP 100 PERCENT ISNULL(dbo.VW_FIN_URA_UKUPNO.ZATVARANJE_IZNOS,0) AS ZATVARANJE_IZNOS, dbo.VW_FIN_URA_UKUPNO.ZATVARANJE_DATUM, 
                      dbo.URA.URABROJ, dbo.URA.IDTIPURA, dbo.URA.URABROJRACUNADOBAVLJACA, dbo.URA.URAPARTNERIDPARTNER, dbo.URA.URANAPOMENA, 
                      dbo.URA.URAVALUTA, dbo.URA.URAUKUPNO,  dbo.URA.URADATUM, 
                       dbo.URA.URAGODIDGODINE, dbo.PARTNER.NAZIVPARTNER, 
                      dbo.PARTNER.MB, dbo.URA.URADOKIDDOKUMENT,PARTNER.PARTNEROIB,
CASE (SELECT COUNT(BROJDOKUMENTA) FROM GKSTAVKA WHERE IDDOKUMENT = @IDDOKUMENT AND BROJDOKUMENTA = DBO.URA.URABROJ AND GKGODIDGODINE =URA.URAGODIDGODINE) WHEN 0 THEN '---------' ELSE 'Kontirano' END AS Status,
dbo.ura.uramodel,dbo.ura.urapozivnabroj,OSNOVICA0,OSNOVICA5,OSNOVICA10,OSNOVICA22,OSNOVICA23,OSNOVICA25,PDV5DA,PDV5NE,PDV10DA,PDV10NE,PDV22DA,PDV22NE,PDV23DA,PDV23NE,PDV25DA,PDV25NE,OSNOVICA5NE,
OSNOVICA10NE,OSNOVICA22NE,OSNOVICA23NE,OSNOVICA25NE,R2, OsnovicaPPO, MozePPO, NeMozePPO

FROM dbo.URA LEFT OUTER  JOIN
	dbo.VW_FIN_URA_UKUPNO ON dbo.URA.URADOKIDDOKUMENT = dbo.VW_FIN_URA_UKUPNO.IDDOKUMENT AND 
	dbo.URA.URABROJ = dbo.VW_FIN_URA_UKUPNO.URA_BROJ AND dbo.URA.uragodidgodine = dbo.VW_FIN_URA_UKUPNO.GKGODIDGODINE INNER JOIN
dbo.PARTNER ON dbo.URA.URAPARTNERIDPARTNER = dbo.PARTNER.IDPARTNER
Where  
dbo.ura.URADOKIDDOKUMENT = coalesce(@iddokument,dbo.ura.URADOKIDDOKUMENT) 
and (dbo.ura.URADATUM between @dat1 and @dat2) 
and (ura.URABROJ  between coalesce(@od,ura.URABROJ) and coalesce(@doo,ura.URABROJ)) 
RETURN


Go
Begin
Insert Into URAVRSTAIZNOSA (IDURAVRSTAIZNOSA, URAVRSTAIZNOSANAZIV) Values((Select Max(IDURAVRSTAIZNOSA) + 1 From URAVRSTAIZNOSA Where (IDURAVRSTAIZNOSA < 1000)), 'Osnovica - PPO')
Insert Into URAVRSTAIZNOSA (IDURAVRSTAIZNOSA, URAVRSTAIZNOSANAZIV) Values((Select Max(IDURAVRSTAIZNOSA) + 1 From URAVRSTAIZNOSA Where (IDURAVRSTAIZNOSA < 1000)), 'PDV - PPO odbija se')
Insert Into URAVRSTAIZNOSA (IDURAVRSTAIZNOSA, URAVRSTAIZNOSANAZIV) Values((Select Max(IDURAVRSTAIZNOSA) + 1 From URAVRSTAIZNOSA Where (IDURAVRSTAIZNOSA < 1000)), 'PDV - PPO ne odbija se')
End


/****** Object:  StoredProcedure [dbo].[sp_KarticeReprodukcijskogMaterijala]    Script Date: 27.4.2016. 13:07:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Hrvoje Zeko>
-- Create date: <Create Date,2015-05-15>
-- Description:	<Description, procedura za kartice artikala u materijalnom>
-- =============================================
CREATE PROCEDURE [dbo].[sp_KarticeReprodukcijskogMaterijala]
	
	@ID INT,
	@Skladiste INT = NULL
	
AS
BEGIN

if @Skladiste IS NOT NULL
BEGIN
	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Primka.DatumNastajanja As Datum,
	(Case When MT_Primka.Opis IS NULL 
	Then 'Primka M'
	Else MT_Primka.Opis
	End) As Dokument,
	MT_Primka.SifraPrimke As Broj, Partner.NAZIVPARTNER As Partner, MT_Primka.BrojUlaznogDokumenta, MT_Primka.DatumDokumentaDobavljaca,
	MT_PrimkaStavke.Kolicina As KolicinaUlaz, CAST(0 as decimal(18,2)) As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_PrimkaStavke.Cijena, 
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
				 Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
				 Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER
				 Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_PrimkaStavke.ID = MT_SkladisteStavke.ID_PrimkaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_Primka.ID_Skladista = @Skladiste
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Izdatnica.DatumNastajanja As Datum,
	'Izdatnica M' As Dokument, MT_Izdatnica.Sifra As Broj, '' As Partner, '' As BrojUlaznogDokumenta, NULL As DatumDokumentaDobavljaca,
	CAST(0 as decimal(18,2)) As KolicinaUlaz, MT_IzdatnicaStavka.Kolicina As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_IzdatnicaStavka.NabavnaCijena As Cijena,	
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_IzdatnicaStavka On PROIZVOD.IDPROIZVOD = MT_IzdatnicaStavka.ID_Proizvoda 
				 Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
				 Inner Join MT_Skladista On MT_Izdatnica.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_IzdatnicaStavka.ID = MT_SkladisteStavke.ID_IzdatnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_Izdatnica.ID_Skladista = @Skladiste
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Meduskladisnica.Datum As Datum,
	'Međuskladisnica M' As Dokument, MT_Meduskladisnica.Sifra As Broj, '' As Partner, '' As BrojUlaznogDokumenta, NULL As DatumDokumentaDobavljaca,
	(Case When MT_SkladisteStavke.Kolicina > 0
	Then MT_SkladisteStavke.Kolicina
	Else CAST(0 as decimal(18,2))
	End) As KolicinaUlaz, 
	(Case When MT_SkladisteStavke.Kolicina < 0
	Then MT_SkladisteStavke.Kolicina * -1
	Else CAST(0 as decimal(18,2))
	End) As KolicinaIzlaz, MT_SkladisteStavke.Stanje, 
	(Case When MT_SkladisteStavke.Kolicina < 0
	Then MT_MeduskladisnicaStavka.IzlaznaCijena
	Else MT_MeduskladisnicaStavka.UlaznaCijena
	End) As Cijena,
	(Case When MT_SkladisteStavke.Kolicina < 0
	Then
	(Select MT_Skladista.Naziv From MT_Skladista Where ID = MT_Meduskladisnica.ID_IzlaznoSkladiste)
	Else 
	(Select MT_Skladista.Naziv From MT_Skladista Where ID = MT_Meduskladisnica.ID_UlaznoSkladiste)
	End) As Skladiste, MT_SkladisteStavke.Saldo
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_MeduskladisnicaStavka On PROIZVOD.IDPROIZVOD = MT_MeduskladisnicaStavka.ID_Proizvoda 
				 Inner Join MT_Meduskladisnica On MT_MeduskladisnicaStavka.ID_Meduskladisnice = MT_Meduskladisnica.ID
				 Inner Join MT_SkladisteStavke On MT_MeduskladisnicaStavka.ID = MT_SkladisteStavke.ID_MeduskladisnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_SkladisteStavke.ID_Skladista  = @Skladiste
				 Order by Datum
END
else
BEGIN

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Primka.DatumNastajanja As Datum,
	(Case When MT_Primka.Opis IS NULL 
	Then 'Primka M'
	Else MT_Primka.Opis
	End) As Dokument,
	MT_Primka.SifraPrimke As Broj, Partner.NAZIVPARTNER As Partner, MT_Primka.BrojUlaznogDokumenta, MT_Primka.DatumDokumentaDobavljaca,
	MT_PrimkaStavke.Kolicina As KolicinaUlaz, CAST(0 as decimal(18,2)) As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_PrimkaStavke.Cijena, 
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
				 Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
				 Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER
				 Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_PrimkaStavke.ID = MT_SkladisteStavke.ID_PrimkaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID
	             
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Izdatnica.DatumNastajanja As Datum,
	'Izdatnica M' As Dokument, MT_Izdatnica.Sifra As Broj, '' As Partner, '' As BrojUlaznogDokumenta, NULL As DatumDokumentaDobavljaca,
	 CAST(0 as decimal(18,2)) As KolicinaUlaz, MT_IzdatnicaStavka.Kolicina As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_IzdatnicaStavka.NabavnaCijena As Cijena, 
	 MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_IzdatnicaStavka On PROIZVOD.IDPROIZVOD = MT_IzdatnicaStavka.ID_Proizvoda 
				 Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
				 Inner Join MT_Skladista On MT_Izdatnica.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_IzdatnicaStavka.ID = MT_SkladisteStavke.ID_IzdatnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID
	             
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Meduskladisnica.Datum As Datum,
	'Međuskladisnica M' As Dokument, MT_Meduskladisnica.Sifra As Broj, '' As Partner, '' As BrojUlaznogDokumenta, NULL As DatumDokumentaDobavljaca,
	(Case When MT_SkladisteStavke.Kolicina > 0
	Then MT_SkladisteStavke.Kolicina
	Else CAST(0 as decimal(18,2))
	End) As KolicinaUlaz, 
	(Case When MT_SkladisteStavke.Kolicina < 0
	Then MT_SkladisteStavke.Kolicina * -1
	Else CAST(0 as decimal(18,2))
	End) As KolicinaIzlaz, MT_SkladisteStavke.Stanje, 
	(Case When MT_SkladisteStavke.Kolicina < 0
	Then MT_MeduskladisnicaStavka.IzlaznaCijena
	Else MT_MeduskladisnicaStavka.UlaznaCijena
	End) As Cijena,
	(Case When MT_SkladisteStavke.Kolicina < 0
	Then
	(Select MT_Skladista.Naziv From MT_Skladista Where ID = MT_Meduskladisnica.ID_IzlaznoSkladiste)
	Else 
	(Select MT_Skladista.Naziv From MT_Skladista Where ID = MT_Meduskladisnica.ID_UlaznoSkladiste)
	End) As Skladiste, MT_SkladisteStavke.Saldo
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_MeduskladisnicaStavka On PROIZVOD.IDPROIZVOD = MT_MeduskladisnicaStavka.ID_Proizvoda 
				 Inner Join MT_Meduskladisnica On MT_MeduskladisnicaStavka.ID_Meduskladisnice = MT_Meduskladisnica.ID
				 Inner Join MT_SkladisteStavke On MT_MeduskladisnicaStavka.ID = MT_SkladisteStavke.ID_MeduskladisnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID
				 Order by Datum
END	
END
GO

/****** Object:  Table [dbo].[MT_GrupeProizvoda]    Script Date: 27.4.2016. 14:17:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MT_GrupeProizvoda](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](100) NOT NULL,
	[TS] [datetime] NOT NULL,
 CONSTRAINT [PK_MT_GrupeProizvoda] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

GO
Begin
Alter table Proizvod Add idGrupa int NULL
End


/****** Object:  View [dbo].[v_StanjeSkladista]    Script Date: 4.5.2016. 15:27:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[v_StanjeSkladista]
AS
SELECT DISTINCT 
                         dbo.MT_Skladista.ID AS ID_Skladiste, dbo.MT_Skladista.Naziv AS Skladiste, dbo.PROIZVOD.IDPROIZVOD AS Sifra, dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
                         CAST(0 AS Decimal(18, 2)) AS BasePrice, CAST(0 AS Decimal(18, 2)) AS Kolicina, dbo.JEDINICAMJERE.NAZIVJEDINICAMJERE, CAST(0 AS Decimal(18, 2)) AS Saldo, 
                         dbo.JEDINICAMJERE.IDJEDINICAMJERE
FROM            dbo.MT_SkladisteStavke LEFT OUTER JOIN
                         dbo.MT_PrimkaStavke ON dbo.MT_SkladisteStavke.ID_PrimkaStavke = dbo.MT_PrimkaStavke.ID LEFT OUTER JOIN
                         dbo.MT_MeduskladisnicaStavka ON dbo.MT_SkladisteStavke.ID_MeduskladisnicaStavke = dbo.MT_MeduskladisnicaStavka.ID LEFT OUTER JOIN
                         dbo.MT_IzdatnicaStavka ON dbo.MT_SkladisteStavke.ID_IzdatnicaStavke = dbo.MT_IzdatnicaStavka.ID INNER JOIN
                         dbo.PROIZVOD ON dbo.MT_PrimkaStavke.ID_Proizvoda = dbo.PROIZVOD.IDPROIZVOD OR dbo.MT_IzdatnicaStavka.ID_Proizvoda = dbo.PROIZVOD.IDPROIZVOD OR 
                         dbo.MT_MeduskladisnicaStavka.ID_Proizvoda = dbo.PROIZVOD.IDPROIZVOD INNER JOIN
                         dbo.MT_Skladista ON dbo.MT_SkladisteStavke.ID_Skladista = dbo.MT_Skladista.ID INNER JOIN
                         dbo.JEDINICAMJERE ON dbo.MT_PrimkaStavke.ID_JedinicaMjere = dbo.JEDINICAMJERE.IDJEDINICAMJERE

GO