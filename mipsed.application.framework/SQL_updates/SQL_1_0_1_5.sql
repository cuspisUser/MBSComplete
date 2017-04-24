Alter Table MT_Izdatnica Add Zaduzen bit NOT NULL Default 1
Alter table MT_SkladisteStavke Add RedniBrojDan smallint NOT NULL Default 1
Alter table MT_SkladisteStavke Alter Column TS date

/****** Object:  StoredProcedure [dbo].[spSkladisteRowsToUpdate]    Script Date: 6.9.2016. 12:59:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spSkladisteRowsToUpdate]
(
	@Datum datetime,
	@Proizvod int,
	@Skladiste int
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
Case When MT_SkladisteStavke.ID_PrimkaStavke is NOT NULL 
Then MT_Primka.DatumNastajanja
When MT_SkladisteStavke.ID_IzdatnicaStavke is NOT NULL
Then MT_Izdatnica.DatumNastajanja
When MT_SkladisteStavke.ID_MeduskladisnicaStavke is NOT NULL
Then MT_Meduskladisnica.Datum End As DatumDokumenta,
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
Order by DatumDokumenta, RedniBrojDan
End