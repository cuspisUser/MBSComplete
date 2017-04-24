Begin
Alter Table MT_IzdatnicaStavka Add RedniBrojDan int NOT NULL Default 1
End
GO

Begin
Alter Table MT_PrimkaStavke Add RedniBrojDan int NOT NULL Default 1
End
GO


Begin
Alter Table KORISNIK Add Materijalno bit NOT NULL Default 1
End
GO


/****** Object:  StoredProcedure [dbo].[spSkladisteDeleteAndRecalculate]    Script Date: 14.9.2016. 13:58:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spSkladisteDeleteAndRecalculate]
(
	@Datum nvarchar(10),
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
Case When MT_SkladisteStavke.ID_PrimkaStavke is NOT NULL Then
(Select FINPOREZSTOPA From FINPOREZ Where FINPOREZIDPOREZ = MT_PrimkaStavke.ID_Porez)
Else NULL End Stopa,
MT_SkladisteStavke.Kolicina, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.Stanje,
MT_SkladisteStavke.TS As DatumDokumenta, MT_SkladisteStavke.RedniBrojDan
From MT_SkladisteStavke 
Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID 
Left Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID 
Left Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID
Left Join MT_Primka On MT_Primka.ID = MT_PrimkaStavke.ID_Primke
Left Join MT_Izdatnica On MT_Izdatnica.ID = MT_IzdatnicaStavka.ID_Izdatnice
Left Join MT_Meduskladisnica On MT_Meduskladisnica.ID = MT_MeduskladisnicaStavka.ID_Meduskladisnice
Where MT_SkladisteStavke.ID_Skladista = @Skladiste And MT_SkladisteStavke.ID_Proizvod = @Proizvod
And (MT_SkladisteStavke.TS > @Datum Or (MT_SkladisteStavke.TS = @Datum And MT_SkladisteStavke.RedniBrojDan >= @rednibroj))

Order by DatumDokumenta, MT_SkladisteStavke.RedniBrojDan
End

GO



/****** Object:  StoredProcedure [dbo].[spSkladisteRowsToUpdate2]    Script Date: 14.9.2016. 15:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spSkladisteRowsToUpdate2]
(
	@Datum nvarchar(10),
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
Case When MT_SkladisteStavke.ID_PrimkaStavke is NOT NULL Then
(Select FINPOREZSTOPA From FINPOREZ Where FINPOREZIDPOREZ = MT_PrimkaStavke.ID_Porez)
Else NULL End Stopa,
MT_SkladisteStavke.Kolicina, MT_SkladisteStavke.Saldo, MT_SkladisteStavke.Stanje,
Cast(MT_SkladisteStavke.TS As Date) As DatumDokumenta, MT_SkladisteStavke.RedniBrojDan
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
Order by DatumDokumenta, MT_SkladisteStavke.RedniBrojDan
End


/****** Object:  View [dbo].[v_Izdatnica]    Script Date: 15.9.2016. 14:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[v_Izdatnica]
AS
SELECT        dbo.MT_Izdatnica.ID, dbo.MT_Izdatnica.Sifra, dbo.MT_Izdatnica.DatumNastajanja, dbo.MT_Skladista.Naziv AS Skladiste, dbo.PROIZVOD.IDPROIZVOD, 
                         dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, dbo.JEDINICAMJERE.NAZIVJEDINICAMJERE AS JedinicaMjere, dbo.MT_IzdatnicaStavka.Kolicina, 
                         dbo.MT_IzdatnicaStavka.NabavnaCijena, dbo.MT_Izdatnica.Napomena, dbo.DOKUMENT.NAZIVDOKUMENT AS Dokument, dbo.MT_Izdatnica.MjestoTroska, 
                         dbo.MJESTOTROSKA.NAZIVMJESTOTROSKA
FROM            dbo.MT_Izdatnica INNER JOIN
                         dbo.MT_IzdatnicaStavka ON dbo.MT_Izdatnica.ID = dbo.MT_IzdatnicaStavka.ID_Izdatnice INNER JOIN
                         dbo.PROIZVOD ON dbo.MT_IzdatnicaStavka.ID_Proizvoda = dbo.PROIZVOD.IDPROIZVOD INNER JOIN
                         dbo.JEDINICAMJERE ON dbo.PROIZVOD.IDJEDINICAMJERE = dbo.JEDINICAMJERE.IDJEDINICAMJERE INNER JOIN
                         dbo.MT_Skladista ON dbo.MT_Izdatnica.ID_Skladista = dbo.MT_Skladista.ID INNER JOIN
                         dbo.DOKUMENT ON dbo.MT_Izdatnica.ID_Dokumenta = dbo.DOKUMENT.IDDOKUMENT LEFT OUTER JOIN
                         dbo.MJESTOTROSKA ON dbo.MT_Izdatnica.MjestoTroska = dbo.MJESTOTROSKA.IDMJESTOTROSKA
WHERE        (dbo.MT_IzdatnicaStavka.Kolicina <> 0)

GO