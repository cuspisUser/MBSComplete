/****** Object:  StoredProcedure [dbo].[spSkladisteRowsToUpdate2]    Script Date: 8.9.2016. 8:15:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spSkladisteRowsToUpdate2]
(
	@Datum datetime,
	@Proizvod int,
	@Skladiste int,
	@rednibroj int
)
AS
BEGIN
Select MT_SkladisteStavke.ID, 
Case When MT_SkladisteStavke.ID_PrimkaStavke is NOT NULL 
Then 'Pri'
When MT_SkladisteStavke.ID_IzdatnicaStavke is NOT NULL
Then 'Izd'
When MT_SkladisteStavke.ID_MeduskladisnicaStavke is NOT NULL
Then 'Mskl' End As Vrsta,
MT_Izdatnica.Sifra +  Case When MT_Izdatnica.Napomena is NULL Then '' Else ' - ' +  MT_Izdatnica.Napomena End As Izdatnica,
Case When MT_SkladisteStavke.ID_PrimkaStavke is NOT NULL 
Then MT_PrimkaStavke.ID_Porez
Else '' End As Porez,
Case When MT_SkladisteStavke.ID_PrimkaStavke is NOT NULL 
Then MT_SkladisteStavke.ID_PrimkaStavke 
When MT_SkladisteStavke.ID_IzdatnicaStavke is NOT NULL
Then MT_SkladisteStavke.ID_IzdatnicaStavke
When MT_SkladisteStavke.ID_MeduskladisnicaStavke is NOT NULL
Then MT_SkladisteStavke.ID_MeduskladisnicaStavke End As idStavke,
MT_SkladisteStavke.ID_Skladista, 
Case When MT_SkladisteStavke.ID_PrimkaStavke is NOT NULL 
Then MT_PrimkaStavke.CijenaPDV
When MT_SkladisteStavke.ID_IzdatnicaStavke is NOT NULL
Then MT_IzdatnicaStavka.NabavnaCijena
When MT_SkladisteStavke.ID_MeduskladisnicaStavke is NOT NULL
Then MT_MeduskladisnicaStavka.UlaznaCijena End As Cijena,
MT_SkladisteStavke.Kolicina, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.Stanje,
Cast(MT_SkladisteStavke.TS As Date) As DatumDokumenta,
RedniBrojDan
From MT_SkladisteStavke 
Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID 
Left Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID 
Left Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID
Left Join MT_Primka On MT_Primka.ID = MT_PrimkaStavke.ID_Primke
Left Join MT_Izdatnica On MT_Izdatnica.ID = MT_IzdatnicaStavka.ID_Izdatnice
Left Join MT_Meduskladisnica On MT_Meduskladisnica.ID = MT_MeduskladisnicaStavka.ID_Meduskladisnice
Where MT_SkladisteStavke.ID_Skladista = @Skladiste 
And (MT_Primka.DatumNastajanja > = @Datum OR MT_Izdatnica.DatumNastajanja >= @Datum OR MT_Meduskladisnica.Datum >= @Datum)
And (MT_PrimkaStavke.ID_Proizvoda = @Proizvod OR MT_IzdatnicaStavka.ID_Proizvoda = @Proizvod OR MT_MeduskladisnicaStavka.ID_Proizvoda = @Proizvod)
And MT_SkladisteStavke.ID Not In(Select ID From MT_SkladisteStavke Where TS = @Datum And RedniBrojDan < @rednibroj And ID_proizvod = @Proizvod)
Order by DatumDokumenta, RedniBrojDan
End

GO

/****** Object:  StoredProcedure [dbo].[sp_KarticeReprodukcijskogMaterijala]    Script Date: 7.9.2016. 15:44:12 ******/
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
	@DatumOd datetime,
	@DatumDo datetime
	
AS
BEGIN

if @Skladiste IS NOT NULL
BEGIN
	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Primka.DatumNastajanja As Datum,
	(Case When MT_Primka.Opis IS NULL 
	Then 'Primka M'
	Else 'Primka M - ' + MT_Primka.Opis
	End) As Dokument,
	MT_Primka.SifraPrimke As Broj, Partner.NAZIVPARTNER As Partner, MT_Primka.BrojUlaznogDokumenta, MT_Primka.DatumDokumentaDobavljaca,
	MT_PrimkaStavke.Kolicina As KolicinaUlaz, CAST(0 as decimal(18,2)) As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_PrimkaStavke.CijenaPDV As Cijena, 
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
				 Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
				 Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER
				 Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_PrimkaStavke.ID = MT_SkladisteStavke.ID_PrimkaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_Primka.ID_Skladista = @Skladiste And DatumNastajanja Between @DatumOd And @DatumDo 
				 And MT_SkladisteStavke.TS Between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Izdatnica.DatumNastajanja As Datum,
	(Case When MT_Izdatnica.Napomena IS NULL 
	Then 'Izdatnica M'
	Else 'Izdatnica M - ' + MT_Izdatnica.Napomena
	End) As Dokument, MT_Izdatnica.Sifra As Broj, '' As Partner, '' As BrojUlaznogDokumenta, NULL As DatumDokumentaDobavljaca,
	CAST(0 as decimal(18,2)) As KolicinaUlaz, MT_IzdatnicaStavka.Kolicina As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_IzdatnicaStavka.NabavnaCijena As Cijena,	
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_IzdatnicaStavka On PROIZVOD.IDPROIZVOD = MT_IzdatnicaStavka.ID_Proizvoda 
				 Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
				 Inner Join MT_Skladista On MT_Izdatnica.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_IzdatnicaStavka.ID = MT_SkladisteStavke.ID_IzdatnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_Izdatnica.ID_Skladista = @Skladiste And DatumNastajanja Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS Between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
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
	End) As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_MeduskladisnicaStavka On PROIZVOD.IDPROIZVOD = MT_MeduskladisnicaStavka.ID_Proizvoda 
				 Inner Join MT_Meduskladisnica On MT_MeduskladisnicaStavka.ID_Meduskladisnice = MT_Meduskladisnica.ID
				 Inner Join MT_SkladisteStavke On MT_MeduskladisnicaStavka.ID = MT_SkladisteStavke.ID_MeduskladisnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And MT_SkladisteStavke.ID_Skladista  = @Skladiste And Datum Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS Between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
				 Order by Datum, MT_SkladisteStavke.RedniBrojDan
END
else
BEGIN

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Primka.DatumNastajanja As Datum,
	(Case When MT_Primka.Opis IS NULL 
	Then 'Primka M'
	Else 'Primka M - ' + MT_Primka.Opis
	End) As Dokument,
	MT_Primka.SifraPrimke As Broj, Partner.NAZIVPARTNER As Partner, MT_Primka.BrojUlaznogDokumenta, MT_Primka.DatumDokumentaDobavljaca,
	MT_PrimkaStavke.Kolicina As KolicinaUlaz, CAST(0 as decimal(18,2)) As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_PrimkaStavke.CijenaPDV  As Cijena, 
	MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_PrimkaStavke On PROIZVOD.IDPROIZVOD = MT_PrimkaStavke.ID_Proizvoda 
				 Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
				 Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER
				 Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_PrimkaStavke.ID = MT_SkladisteStavke.ID_PrimkaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And DatumNastajanja Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS Between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
	             
	Union

	Select PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD AS Proizvod, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_Izdatnica.DatumNastajanja As Datum,
	(Case When MT_Izdatnica.Napomena IS NULL 
	Then 'Izdatnica M'
	Else 'Izdatnica M - ' + MT_Izdatnica.Napomena
	End) As Dokument, MT_Izdatnica.Sifra As Broj, '' As Partner, '' As BrojUlaznogDokumenta, NULL As DatumDokumentaDobavljaca,
	 CAST(0 as decimal(18,2)) As KolicinaUlaz, MT_IzdatnicaStavka.Kolicina As KolicinaIzlaz, MT_SkladisteStavke.Stanje, MT_IzdatnicaStavka.NabavnaCijena As Cijena, 
	 MT_Skladista.Naziv As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_IzdatnicaStavka On PROIZVOD.IDPROIZVOD = MT_IzdatnicaStavka.ID_Proizvoda 
				 Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
				 Inner Join MT_Skladista On MT_Izdatnica.ID_Skladista = MT_Skladista.ID
				 Inner Join MT_SkladisteStavke On MT_IzdatnicaStavka.ID = MT_SkladisteStavke.ID_IzdatnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And DatumNastajanja Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS Between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
	             
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
	End) As Skladiste, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.RedniBrojDan
				 From PROIZVOD
				 Inner Join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE
				 Inner Join MT_MeduskladisnicaStavka On PROIZVOD.IDPROIZVOD = MT_MeduskladisnicaStavka.ID_Proizvoda 
				 Inner Join MT_Meduskladisnica On MT_MeduskladisnicaStavka.ID_Meduskladisnice = MT_Meduskladisnica.ID
				 Inner Join MT_SkladisteStavke On MT_MeduskladisnicaStavka.ID = MT_SkladisteStavke.ID_MeduskladisnicaStavke
				 Where PROIZVOD.IDPROIZVOD = @ID And Datum Between @DatumOd And @DatumDo
				 And MT_SkladisteStavke.TS Between @DatumOd And @DatumDo And MT_SkladisteStavke.Kolicina > 0
				 Order by Datum, MT_SkladisteStavke.RedniBrojDan
END	
END