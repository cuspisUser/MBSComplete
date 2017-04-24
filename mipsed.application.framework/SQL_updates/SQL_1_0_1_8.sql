Begin
Alter Table MT_Izdatnica Add MjestoTroska int NULL
End
GO

/****** Object:  StoredProcedure [dbo].[spUlazIzlazGrupaIzdatnica]    Script Date: 9.9.2016. 8:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spUlazIzlazGrupaIzdatnica]
(
      @datumOd date,
	  @dateumDo date,
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
	And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos
	From MT_IzdatnicaStavka 
	Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And product.idGrupa is NOT NULL
	End
	IF @skladiste is Not NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And MT_Izdatnica.ID_Skladista =  @skladiste And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos
	From MT_IzdatnicaStavka 
	Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where MT_Izdatnica.ID_Skladista =  @skladiste
	And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And product.idGrupa is NOT NULL
	End
    END
RETURN
GO


/****** Object:  StoredProcedure [dbo].[spUlazIzlazGrupaPrimka]    Script Date: 9.9.2016. 8:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spUlazIzlazGrupaPrimka]
(
      @datumOd date,
	  @dateumDo date,
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
	And Cast(MT_Primka.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos
	From MT_PrimkaStavke 
	Inner Join PROIZVOD as product On MT_PrimkaStavke.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where Cast(MT_Primka.DatumNastajanja As Date) Between @datumOd And @dateumDo And product.idGrupa is NOT NULL
    End

	IF @skladiste is NOT NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina) From MT_PrimkaStavke
	Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Where PROIZVOD.idGrupa = product.idGrupa
	And MT_Primka.ID_Skladista =  @skladiste And Cast(MT_Primka.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos
	From MT_PrimkaStavke 
	Inner Join PROIZVOD as product On MT_PrimkaStavke.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where Cast(MT_Primka.DatumNastajanja As Date) Between @datumOd And @dateumDo And product.idGrupa is NOT NULL
	And MT_Primka.ID_Skladista =  @skladiste
    End
RETURN


/****** Object:  StoredProcedure [dbo].[spMjestoTroskaIspis]    Script Date: 9.9.2016. 14:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spMjestoTroskaIspis]
(
      @datumOd nvarchar(10),
	  @dateumDo nvarchar(10),
	  @skladiste int = NULL, 
	  @mjestoTroska int
)
AS 		
    BEGIN

	IF @skladiste is NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select NAZIVMJESTOTROSKA From MJESTOTROSKA Where IDMJESTOTROSKA = @mjestoTroska) As MjestoTroska,
	(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa And MT_Izdatnica.MjestoTroska = @mjestoTroska
	And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos,
	(Select SUM(MT_IzdatnicaStavka.Kolicina) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa And MT_Izdatnica.MjestoTroska = @mjestoTroska
	And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Kolicina
	From MT_IzdatnicaStavka 
	Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And product.idGrupa is NOT NULL And MT_Izdatnica.MjestoTroska = @mjestoTroska
	End
	IF @skladiste is Not NULL
	Begin
	Select Distinct MT_GrupeProizvoda.Naziv,
	(Select SUM(MT_IzdatnicaStavka.UkupanIznos) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa And MT_Izdatnica.MjestoTroska = @mjestoTroska
	And MT_Izdatnica.ID_Skladista =  @skladiste And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Iznos,
	(Select SUM(MT_IzdatnicaStavka.Kolicina) From MT_IzdatnicaStavka
	Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Where PROIZVOD.idGrupa = product.idGrupa And MT_Izdatnica.MjestoTroska = @mjestoTroska
	And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And idGrupa is NOT NULL) As Kolicina
	From MT_IzdatnicaStavka 
	Inner Join PROIZVOD as product On MT_IzdatnicaStavka.ID_Proizvoda = product.IDPROIZVOD
	Inner Join MT_Izdatnica On MT_IzdatnicaStavka.ID_Izdatnice = MT_Izdatnica.ID
	Inner Join  MT_GrupeProizvoda ON MT_GrupeProizvoda.ID = product.idGrupa
	Where MT_Izdatnica.ID_Skladista =  @skladiste
	And Cast(MT_Izdatnica.DatumNastajanja As Date) Between @datumOd And @dateumDo And product.idGrupa is NOT NULL And MT_Izdatnica.MjestoTroska = @mjestoTroska
	End
    END
RETURN

GO


