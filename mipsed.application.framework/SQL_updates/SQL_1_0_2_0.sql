Begin
Alter Table MT_Skladista Add Porez bit NOT NULL Default 1
End
GO


/****** Object:  StoredProcedure [dbo].[sp_KarticeReprodukcijskogMaterijala]    Script Date: 20.9.2016. 10:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Hrvoje Zeko>
-- Create date: <Create Date,2015-05-15>
-- Description:	<Description, procedura za kartice artikala u materijalnom>
-- =============================================
ALTER PROCEDURE [dbo].[sp_KarticeReprodukcijskogMaterijala]
	
	@ID INT,
	@Skladiste INT = NULL,
	@DatumOd nvarchar(10),
	@DatumDo nvarchar(10)
	
AS
BEGIN

if @Skladiste IS NOT NULL
BEGIN
	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, Cast(MT_Primka.DatumNastajanja As Date) As Datum,
	(Case When MT_Primka.Opis IS NULL 
	Then 'Primka M'
	Else 'Primka M - ' + MT_Primka.Opis
	End) As Dokument,
	MT_Primka.SifraPrimke As Broj, Partner.NAZIVPARTNER As Partner, MT_Primka.BrojUlaznogDokumenta, MT_Primka.DatumDokumentaDobavljaca,
	MT_PrimkaStavke.Kolicina As KolicinaUlaz, CAST(0 as decimal(18,2)) As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_PrimkaStavke.CijenaPDV As Cijena, 
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan, MT_SkladisteStavke.TS
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
				 Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
				 Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER
				 Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_PrimkaStavke.ID = MT_SkladisteStavke.ID_PrimkaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_Primka.ID_Skladista = @Skladiste And Cast(DatumNastajanja As date) Between @DatumOd And @DatumDo 
				 And MT_SkladisteStavke.TS between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, Cast(MT_Izdatnica.DatumNastajanja As Date) As Datum,
	(Case When MT_Izdatnica.Napomena IS NULL 
	Then 'Izdatnica M'
	Else 'Izdatnica M - ' + MT_Izdatnica.Napomena
	End) As Dokument, MT_Izdatnica.Sifra As Broj, '' As Partner, '' As BrojUlaznogDokumenta, NULL As DatumDokumentaDobavljaca,
	CAST(0 as decimal(18,2)) As KolicinaUlaz, MT_IzdatnicaStavka.Kolicina As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_IzdatnicaStavka.NabavnaCijena As Cijena,	
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan, MT_SkladisteStavke.TS
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_IzdatnicaStavka On PROIZVOD.IDPROIZVOD = MT_IzdatnicaStavka.ID_Proizvoda 
				 Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
				 Inner Join MT_Skladista On MT_Izdatnica.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_IzdatnicaStavka.ID = MT_SkladisteStavke.ID_IzdatnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_Izdatnica.ID_Skladista = @Skladiste And Cast(DatumNastajanja As date) Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, Cast(MT_Meduskladisnica.Datum As Date) As Datum,
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
	End) As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan, MT_SkladisteStavke.TS
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_MeduskladisnicaStavka On PROIZVOD.IDPROIZVOD = MT_MeduskladisnicaStavka.ID_Proizvoda 
				 Inner Join MT_Meduskladisnica On MT_MeduskladisnicaStavka.ID_Meduskladisnice = MT_Meduskladisnica.ID
				 Inner Join MT_SkladisteStavke On MT_MeduskladisnicaStavka.ID = MT_SkladisteStavke.ID_MeduskladisnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_SkladisteStavke.ID_Skladista  = @Skladiste And Datum Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS between  @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
				 Order by Datum, MT_SkladisteStavke.RedniBrojDan
END
else
BEGIN

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, Cast(MT_Primka.DatumNastajanja As Date) As Datum,
	(Case When MT_Primka.Opis IS NULL 
	Then 'Primka M'
	Else 'Primka M - ' + MT_Primka.Opis
	End) As Dokument,
	MT_Primka.SifraPrimke As Broj, Partner.NAZIVPARTNER As Partner, MT_Primka.BrojUlaznogDokumenta, MT_Primka.DatumDokumentaDobavljaca,
	MT_PrimkaStavke.Kolicina As KolicinaUlaz, CAST(0 as decimal(18,2)) As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_PrimkaStavke.CijenaPDV  As Cijena, 
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan, MT_SkladisteStavke.TS
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
				 Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
				 Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER
				 Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_PrimkaStavke.ID = MT_SkladisteStavke.ID_PrimkaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And Cast(DatumNastajanja As date) Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
	             
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, Cast(MT_Izdatnica.DatumNastajanja As Date) As Datum,
	(Case When MT_Izdatnica.Napomena IS NULL 
	Then 'Izdatnica M'
	Else 'Izdatnica M - ' + MT_Izdatnica.Napomena
	End) As Dokument, MT_Izdatnica.Sifra As Broj, '' As Partner, '' As BrojUlaznogDokumenta, NULL As DatumDokumentaDobavljaca,
	 CAST(0 as decimal(18,2)) As KolicinaUlaz, MT_IzdatnicaStavka.Kolicina As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_IzdatnicaStavka.NabavnaCijena As Cijena, 
	 MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan, MT_SkladisteStavke.TS
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_IzdatnicaStavka On PROIZVOD.IDPROIZVOD = MT_IzdatnicaStavka.ID_Proizvoda 
				 Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
				 Inner Join MT_Skladista On MT_Izdatnica.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_IzdatnicaStavka.ID = MT_SkladisteStavke.ID_IzdatnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And Cast(DatumNastajanja As date) Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0 
	             
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, Cast(MT_Meduskladisnica.Datum As Date) As Datum,
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
	End) As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan, MT_SkladisteStavke.TS
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_MeduskladisnicaStavka On PROIZVOD.IDPROIZVOD = MT_MeduskladisnicaStavka.ID_Proizvoda 
				 Inner Join MT_Meduskladisnica On MT_MeduskladisnicaStavka.ID_Meduskladisnice = MT_Meduskladisnica.ID
				 Inner Join MT_SkladisteStavke On MT_MeduskladisnicaStavka.ID = MT_SkladisteStavke.ID_MeduskladisnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And Datum Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
				 Order by Datum, MT_SkladisteStavke.RedniBrojDan
END	
END



/****** Object:  View [dbo].[vStanjeDokumenti]    Script Date: 19.9.2016. 8:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vStanjeDokumenti]
AS
SELECT        'Primka' AS Vrsta, SifraPrimke AS Sifra, DatumNastajanja AS Datum, MT_Skladista.Naziv AS Skladiste, NetoPrimke AS Neto, BrutoPrimke AS Bruto, 
                         PDVPrimke AS PDV, 
						 Case When MT_Skladista.Porez = 1 Then (BrutoPrimke - NetoPrimke) Else 0 End AS PDVNE, 
						 Case When MT_Skladista.Porez = 1 Then (NetoPrimke + PDVPrimke - BrutoPrimke) Else 0 End AS PDVDA, NULL AS UkupanIznos
FROM            MT_Primka INNER JOIN
                         MT_Skladista ON MT_Primka.ID_Skladista = MT_Skladista.ID
UNION
SELECT        'Izdatnica' AS Vrsta, MT_Izdatnica.Sifra, DatumNastajanja AS Datum, MT_Skladista.Naziv AS Skladiste, NULL AS Neto, NULL AS Bruto, NULL AS PDV, NULL 
                         AS PDVNE, NULL AS PDVDA, UkupanIznos
FROM            MT_Izdatnica INNER JOIN
                         MT_Skladista ON MT_Izdatnica.ID_Skladista = MT_Skladista.ID
GO


/****** Object:  View [dbo].[vPrimkaDobavljac]    Script Date: 20.9.2016. 10:00:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vPrimkaDobavljac]
AS
SELECT        'Primka' AS Vrsta, dbo.MT_Primka.SifraPrimke AS Sifra, dbo.MT_Primka.DatumNastajanja AS Datum, dbo.MT_Skladista.Naziv AS Skladiste, 
                         dbo.MT_Primka.NetoPrimke AS Neto, dbo.MT_Primka.BrutoPrimke AS Bruto, dbo.MT_Primka.PDVPrimke AS PDV, 
                         dbo.MT_Primka.BrutoPrimke - dbo.MT_Primka.NetoPrimke AS PDVNE, 
                         dbo.MT_Primka.NetoPrimke + dbo.MT_Primka.PDVPrimke - dbo.MT_Primka.BrutoPrimke AS PDVDA, NULL AS UkupanIznos, dbo.MT_Primka.ID_Partnera, 
                         dbo.PARTNER.NAZIVPARTNER
FROM            dbo.MT_Primka INNER JOIN
                         dbo.MT_Skladista ON dbo.MT_Primka.ID_Skladista = dbo.MT_Skladista.ID INNER JOIN
                         dbo.PARTNER ON dbo.MT_Primka.ID_Partnera = dbo.PARTNER.IDPARTNER

GO