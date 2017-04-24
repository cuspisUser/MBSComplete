ALTER VIEW [dbo].[v_Primka]
AS

SELECT        dbo.MT_Primka.ID, dbo.MT_Primka.SifraPrimke, dbo.MT_Primka.DatumNastajanja, dbo.MT_Skladista.Naziv AS Skladiste, dbo.PARTNER.IDPARTNER, 
                         dbo.PARTNER.NAZIVPARTNER, dbo.PARTNER.PARTNERMJESTO, dbo.PARTNER.PARTNEROIB, dbo.PARTNER.PARTNERULICA, dbo.MT_Primka.ID_Dokumenta, 
                         dbo.MT_Primka.ID_Narudzbenice, '' AS Dokument, '' AS BrojNarudzbe, dbo.PROIZVOD.IDPROIZVOD, dbo.MT_PrimkaStavke.Cijena, 
                         dbo.MT_PrimkaStavke.CijenaPDV, dbo.MT_PrimkaStavke.Kolicina, dbo.PROIZVOD.NAZIVPROIZVOD, dbo.JEDINICAMJERE.NAZIVJEDINICAMJERE, 
                         dbo.MT_Primka.Opis, dbo.MT_Primka.DatumDokumentaDobavljaca, dbo.MT_Primka.BrojUlaznogDokumenta, 
                         dbo.DOKUMENT.NAZIVDOKUMENT AS VrstaUlaznogDokumenta
FROM            dbo.MT_Primka INNER JOIN
                         dbo.MT_PrimkaStavke ON dbo.MT_Primka.ID = dbo.MT_PrimkaStavke.ID_Primke INNER JOIN
                         dbo.PARTNER ON dbo.MT_Primka.ID_Partnera = dbo.PARTNER.IDPARTNER INNER JOIN
                         dbo.PROIZVOD ON dbo.MT_PrimkaStavke.ID_Proizvoda = dbo.PROIZVOD.IDPROIZVOD INNER JOIN
                         dbo.JEDINICAMJERE ON dbo.PROIZVOD.IDJEDINICAMJERE = dbo.JEDINICAMJERE.IDJEDINICAMJERE INNER JOIN
                         dbo.MT_Skladista ON dbo.MT_Primka.ID_Skladista = dbo.MT_Skladista.ID INNER JOIN
                         dbo.DOKUMENT ON dbo.MT_Primka.ID_Dokumenta = dbo.DOKUMENT.IDDOKUMENT

where Kolicina  <> 0
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[v_Izdatnica]
AS
SELECT        dbo.MT_Izdatnica.ID, dbo.MT_Izdatnica.Sifra, dbo.MT_Izdatnica.DatumNastajanja, dbo.MT_Skladista.Naziv AS Skladiste, dbo.PROIZVOD.IDPROIZVOD, 
                         dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, dbo.JEDINICAMJERE.NAZIVJEDINICAMJERE AS JedinicaMjere, dbo.MT_IzdatnicaStavka.Kolicina, 
                         dbo.MT_IzdatnicaStavka.NabavnaCijena, dbo.MT_Izdatnica.Napomena, dbo.DOKUMENT.NAZIVDOKUMENT AS Dokument
FROM            dbo.MT_Izdatnica INNER JOIN
                         dbo.MT_IzdatnicaStavka ON dbo.MT_Izdatnica.ID = dbo.MT_IzdatnicaStavka.ID_Izdatnice INNER JOIN
                         dbo.PROIZVOD ON dbo.MT_IzdatnicaStavka.ID_Proizvoda = dbo.PROIZVOD.IDPROIZVOD INNER JOIN
                         dbo.JEDINICAMJERE ON dbo.PROIZVOD.IDJEDINICAMJERE = dbo.JEDINICAMJERE.IDJEDINICAMJERE INNER JOIN
                         dbo.MT_Skladista ON dbo.MT_Izdatnica.ID_Skladista = dbo.MT_Skladista.ID INNER JOIN
                         dbo.DOKUMENT ON dbo.MT_Izdatnica.ID_Dokumenta = dbo.DOKUMENT.IDDOKUMENT
						 where Kolicina  <> 0

GO


/****** Object:  StoredProcedure [dbo].[spUlazIzlazGrupaPrimka]    Script Date: 4.8.2016. 10:29:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spUlazIzlazGrupaPrimka]
(
      @datumOd datetime,
	  @dateumDo datetime,
	  @skladiste int = NULL
)
AS 	

		
	IF @skladiste is NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina) From MT_PrimkaStavke
	Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And MT_Primka.DatumNastajanja Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos
	From MT_PrimkaStavke 
	Inner Join PROIZVOD as product On MT_PrimkaStavke.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where MT_Primka.DatumNastajanja Between @datumOd And @dateumDo And product.idGrupa is NOT NULL
    End

	IF @skladiste is NOT NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina) From MT_PrimkaStavke
	Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And MT_Primka.ID_Skladista =  @skladiste And MT_Primka.DatumNastajanja Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos
	From MT_PrimkaStavke 
	Inner Join PROIZVOD as product On MT_PrimkaStavke.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where MT_Primka.DatumNastajanja Between @datumOd And @dateumDo And product.idGrupa is NOT NULL
	And MT_Primka.ID_Skladista =  @skladiste
    End
RETURN

GO


/****** Object:  StoredProcedure [dbo].[spUlazIzlazGrupaIzdatnica]    Script Date: 4.8.2016. 12:10:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[spUlazIzlazGrupaIzdatnica]
(
      @datumOd datetime,
	  @dateumDo datetime,
	  @skladiste int = NULL
)
AS 	

		
    BEGIN

	IF @skladiste is NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And MT_Izdatnica.DatumNastajanja Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos
	From MT_IzdatnicaStavka 
	Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where MT_Izdatnica.DatumNastajanja Between @datumOd And @dateumDo And product.idGrupa is NOT NULL
	End
	IF @skladiste is Not NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And MT_Izdatnica.ID_Skladista =  @skladiste And MT_Izdatnica.DatumNastajanja Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos
	From MT_IzdatnicaStavka 
	Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where MT_Izdatnica.ID_Skladista =  @skladiste
	And MT_Izdatnica.DatumNastajanja Between @datumOd And @dateumDo And product.idGrupa is NOT NULL
	End
    END
RETURN

GO



/****** Object:  StoredProcedure [dbo].[S_FIN_URA_PPO]    Script Date: 03.08.2016 8:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[S_FIN_URA_PPO]
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
and OsnovicaPPO > 0
RETURN