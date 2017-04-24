--db - 31.01.2017
alter table dbo.mt_inventura	
add Zakljucano bit

--brane - 31.01.2017
update doprinos set mindoprinos = '2940.82' where iddoprinos in (1,2,4,5,6,7,11,990)
update doprinos set maxdoprinos = '46434.00' where iddoprinos in (1,2,3,8,9,10,12,987,988,989)

/****** Object:  StoredProcedure [dbo].[S_FIN_PROMET_PO_PARTNERIMA_2]    Script Date: 31.1.2017. 10:47:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <31.01.2017>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[S_FIN_PROMET_PO_PARTNERIMA_2]
(
		 @ODPARTNERA  INT = NULL,
		 @DOPARTNERA INT = NULL,
		 @MT INT = NULL,
		 @ORG INT= NULL,
		 @IDAKTIVNOST INT = NULL,
		@RAZDOBLJEOD DATETIME,
		@RAZDOBLJEDO DATETIME,
		@dodatniuvjet varchar(2) = NULL,
		@POCETNIKONTO varchar(15) = null,
		@ZAVRSNIKONTO varchar(15) = null

)
AS
	IF @ORG = -1  SET @ORG = NULL
	IF @MT = -1  SET @MT = NULL
	IF @POCETNIKONTO = ' '  SET @POCETNIKONTO = NULL
	IF @ZAVRSNIKONTO = ' '  SET @ZAVRSNIKONTO = NULL
	IF @IDAKTIVNOST = -1  SET @IDAKTIVNOST = NULL
	IF @ODPARTNERA = -1  SET @ODPARTNERA = NULL
	IF @DOPARTNERA = -1  SET @DOPARTNERA = NULL
	
	
--- SORTIRANJE PO NAZIVU
if @dodatniuvjet = 'N'
	BEGIN

SELECT     GKSTAVKA.IDPARTNER, SUM(GKSTAVKA.duguje) AS duguje, SUM(GKSTAVKA.POTRAZUJE) AS potrazuje, PARTNER.NAZIVPARTNER AS naziv, 
                      KONTO.IDAKTIVNOST AS aktivnost,  ISNULL(PARTNER.partnermjesto, ' ') AS partnermjesto
FROM         GKSTAVKA INNER JOIN
                      PARTNER ON GKSTAVKA.IDPARTNER = PARTNER.IDPARTNER INNER JOIN
                      KONTO ON GKSTAVKA.IDKONTO = KONTO.IDKONTO
WHERE (gkstavka.IDkonto between COALESCE(@POCETNIKONTO,DBO.konto.idkonto) and COALESCE(@ZAVRSNIKONTO,DBO.konto.idkonto)) and GKSTAVKA.IDPARTNER BETWEEN COALESCE(@ODPARTNERA,PARTNER.IDPARTNER)  AND COALESCE(@DOPARTNERA,PARTNER.IDPARTNER) AND  (DBO.GKSTAVKA.IDORGJED= COALESCE(@ORG,DBO.GKSTAVKA.IDORGJED)) AND (DBO.GKSTAVKA.IDMJESTOTROSKA= COALESCE(@MT,DBO.GKSTAVKA.IDMJESTOTROSKA)) AND (KONTO.IDAKTIVNOST = COALESCE (@IDAKTIVNOST, KONTO.IDAKTIVNOST)) AND  (DATUMDOKUMENTA between @RAZDOBLJEOD AND @RAZDOBLJEDO)
-- Branimir 20.01.17. kako bi isključili konta glavne knjige
and konto.idaktivnost >1


GROUP BY GKSTAVKA.IDPARTNER, KONTO.IDAKTIVNOST, PARTNER.partnermjesto, PARTNER.NAZIVPARTNER
ORDER BY PARTNER.NAZIVPARTNER

END ELSE
	BEGIN

	SELECT     GKSTAVKA.IDPARTNER, SUM(GKSTAVKA.duguje) AS duguje, SUM(GKSTAVKA.POTRAZUJE) AS potrazuje, PARTNER.NAZIVPARTNER AS naziv, 
                      KONTO.IDAKTIVNOST AS aktivnost,  ISNULL(PARTNER.partnermjesto, ' ') AS partnermjesto
FROM         GKSTAVKA INNER JOIN
                      PARTNER ON GKSTAVKA.IDPARTNER = PARTNER.IDPARTNER INNER JOIN
                      KONTO ON GKSTAVKA.IDKONTO = KONTO.IDKONTO
WHERE  (gkstavka.IDkonto between COALESCE(@POCETNIKONTO,DBO.konto.idkonto) and COALESCE(@ZAVRSNIKONTO,DBO.konto.idkonto))  and GKSTAVKA.IDPARTNER BETWEEN COALESCE(@ODPARTNERA,PARTNER.IDPARTNER)  AND COALESCE(@DOPARTNERA,PARTNER.IDPARTNER) AND  (DBO.GKSTAVKA.IDORGJED= COALESCE(@ORG,DBO.GKSTAVKA.IDORGJED)) AND (DBO.GKSTAVKA.IDMJESTOTROSKA= COALESCE(@MT,DBO.GKSTAVKA.IDMJESTOTROSKA)) AND (KONTO.IDAKTIVNOST = COALESCE (@IDAKTIVNOST, KONTO.IDAKTIVNOST)) AND  (DATUMDOKUMENTA between @RAZDOBLJEOD AND @RAZDOBLJEDO)
-- Branimir 20.01.17. kako bi isključili konta glavne knjige
and konto.idaktivnost >1

GROUP BY GKSTAVKA.IDPARTNER, KONTO.IDAKTIVNOST, PARTNER.partnermjesto, PARTNER.NAZIVPARTNER
ORDER BY GKSTAVKA.IDPARTNER
END
RETURN
go


/****** Object:  StoredProcedure [dbo].[spStanjeSkladista]    Script Date: 1.2.2017. 10:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2016-11-04
-- Description:	Procedura za report crpStanjeSkladistaGrupe (main report spStanjeSkladista)
-- =============================================

ALTER PROCEDURE [dbo].[spStanjeSkladista]
(    
	  @idSkladista int ,
	  @datum date,
	  @order nvarchar (50)
)
as
begin	
select derived1.* from 
(
select  distinct TOP (100) PERCENT 
	dbo.MT_Skladista.ID AS ID_Skladiste, 
	dbo.MT_Skladista.Naziv AS Skladiste, 
	dbo.PROIZVOD.idGrupa AS GrupaProizvod, 
	dbo.PROIZVOD.IDPROIZVOD, 
	dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
	CAST(0 AS Decimal(18, 4)) AS BasePrice, 	 
	
	(Select Top 1 Stanje From MT_SkladisteStavke Where TS <= @datum And ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  Order by TS desc, RedniBrojDan desc) as KolicinaX, 	

	--OVO SU SIGURNO ZADNJE STANJE I SALDO ZA OVE PROIZVODE!!!
	(Select Top 1 Saldo  From MT_SkladisteStavke Where ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  Order by TS desc, RedniBrojDan desc)  as Saldo,	
	(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  order by TS desc, RedniBrojDan desc) as Stanje,		
	
	--CIJENA = SALDO / STANJE ZA JEDAN (1) PROIZVOD
	(nullif((Select Top 1 Saldo  From MT_SkladisteStavke Where ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  Order by ID desc, RedniBrojDan desc), 0) / nullif((SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  order by ID desc), 0))as CijenaPDV,
	
	CAST(NULL AS datetime) AS Datum, 
	dbo.PROIZVOD.idGrupa
	
FROM dbo.MT_SkladisteStavke
	LEFT OUTER JOIN dbo.MT_PrimkaStavke ON dbo.MT_SkladisteStavke.ID_PrimkaStavke = dbo.MT_PrimkaStavke.ID 
	LEFT OUTER JOIN dbo.MT_IzdatnicaStavka ON dbo.MT_SkladisteStavke.ID_IzdatnicaStavke = dbo.MT_IzdatnicaStavka.ID 
	INNER JOIN dbo.MT_Skladista ON dbo.MT_SkladisteStavke.ID_Skladista = dbo.MT_Skladista.ID 
	INNER JOIN dbo.JEDINICAMJERE ON dbo.MT_PrimkaStavke.ID_JedinicaMjere = dbo.JEDINICAMJERE.IDJEDINICAMJERE 
	INNER JOIN dbo.PROIZVOD ON dbo.MT_SkladisteStavke.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD
	
WHERE MT_SkladisteStavke.ID_Skladista = @idSkladista
	and PROIZVOD.idGrupa is NOT NULL 
	and MT_SkladisteStavke.Kolicina > 0 
	and MT_SkladisteStavke.TS <=  @datum 
group by  MT_SkladisteStavke.ID, MT_Skladista.id, MT_Skladista.Naziv, PROIZVOD.idGrupa, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, JEDINICAMJERE.NAZIVJEDINICAMJERE, MT_SkladisteStavke.Saldo, JEDINICAMJERE.IDJEDINICAMJERE, MT_Skladista.TS, MT_SkladisteStavke.Kolicina, MT_SkladisteStavke.Stanje

) 
as derived1

order by  
		case 
			when @order = 'PROIZVOD.IDPROIZVOD' then cast(derived1.IDPROIZVOD as nvarchar(50))
			when @order = 'PROIZVOD.NAZIVPROIZVOD' then cast(derived1.Proizvod as nvarchar(50))
			else cast(derived1.Stanje as nvarchar(50))
		end
end



/****** Object:  StoredProcedure [dbo].[spInventurnaLista]    Script Date: 1.2.2017. 10:34:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Davor Bursać
-- Create date: 2017-01-16
-- Description:	Procedura za report crpInventurnaLista 
-- =============================================
ALTER PROCEDURE [dbo].[spInventurnaLista]
(    
	  @idSkladista int,
	  @datum date,
	  @order nvarchar (50),
	  @PrikazKolicina bit
)
as
begin	
	if(@PrikazKolicina <> 0)
		begin
			select derived1.* from 
			(
			select  distinct TOP (100) PERCENT 
				dbo.MT_Skladista.ID AS ID_Skladiste, 
				dbo.MT_Skladista.Naziv AS Skladiste, 
				dbo.PROIZVOD.idGrupa AS GrupaProizvod, 
				dbo.PROIZVOD.IDPROIZVOD  As idproizvod, 
				dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
				CAST(0 AS Decimal(18, 4)) AS BasePrice, 	 
			
				(Select Top 1 Stanje From MT_SkladisteStavke Where TS <= @datum And mt_skladistestavke.ID_Proizvod = proizvod.IDProizvod And ID_Skladista =  @idSkladista  Order by TS desc, RedniBrojDan desc) as KolicinaX,
				(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  Order by TS desc, RedniBrojDan desc) as Stanje,
				(Select Top 1 Saldo From MT_SkladisteStavke Where TS <= @datum  And ID_Proizvod = PROIZVOD.IDProizvod And ID_Skladista =  @idSkladista  Order by TS desc, RedniBrojDan desc) as Saldo,				
				CAST(NULL AS datetime) AS Datum, 
				dbo.PROIZVOD.idGrupa
	
			FROM dbo.MT_SkladisteStavke
				LEFT OUTER JOIN dbo.MT_PrimkaStavke ON dbo.MT_SkladisteStavke.ID_PrimkaStavke = dbo.MT_PrimkaStavke.ID 
				LEFT OUTER JOIN dbo.MT_IzdatnicaStavka ON dbo.MT_SkladisteStavke.ID_IzdatnicaStavke = dbo.MT_IzdatnicaStavka.ID 
				INNER JOIN dbo.MT_Skladista ON dbo.MT_SkladisteStavke.ID_Skladista = dbo.MT_Skladista.ID 
				INNER JOIN dbo.JEDINICAMJERE ON dbo.MT_PrimkaStavke.ID_JedinicaMjere = dbo.JEDINICAMJERE.IDJEDINICAMJERE 
				INNER JOIN dbo.PROIZVOD ON dbo.MT_SkladisteStavke.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD
	
			WHERE MT_SkladisteStavke.ID_Skladista = @idSkladista
				and PROIZVOD.idGrupa is NOT NULL 
				and MT_SkladisteStavke.Kolicina > 0 
				and MT_SkladisteStavke.TS <=  @datum 
			group by  MT_SkladisteStavke.ID, MT_Skladista.id, MT_Skladista.Naziv, PROIZVOD.idGrupa, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, JEDINICAMJERE.NAZIVJEDINICAMJERE, MT_SkladisteStavke.Saldo, JEDINICAMJERE.IDJEDINICAMJERE, MT_Skladista.TS, MT_SkladisteStavke.Kolicina

			) 
			as derived1

			order by  
					case 
						when @order = 'PROIZVOD.IDPROIZVOD' then cast(derived1.IDPROIZVOD as nvarchar(50))
						when @order = 'PROIZVOD.NAZIVPROIZVOD' then cast(derived1.Proizvod as nvarchar(50))
						else cast(derived1.KolicinaX as nvarchar(50))
					end
		end
	else --ovaj je za IF gore
		begin
			select derived1.* from 
			(
			select  distinct TOP (100) PERCENT 
				dbo.MT_Skladista.ID AS ID_Skladiste, 
				dbo.MT_Skladista.Naziv AS Skladiste, 
				dbo.PROIZVOD.idGrupa AS GrupaProizvod, 
				dbo.PROIZVOD.IDPROIZVOD, 
				dbo.PROIZVOD.NAZIVPROIZVOD AS Proizvod, 
				CAST(0 AS Decimal(18, 4)) AS BasePrice,
					 
				'' as KolicinaX,
				(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  order by ID desc) as Stanje,
				(SELECT top 1 Saldo FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  order by ID desc) as Saldo,	
				CAST(NULL AS datetime) AS Datum, 
				dbo.PROIZVOD.idGrupa
	
			FROM dbo.MT_SkladisteStavke
				LEFT OUTER JOIN dbo.MT_PrimkaStavke ON dbo.MT_SkladisteStavke.ID_PrimkaStavke = dbo.MT_PrimkaStavke.ID 
				LEFT OUTER JOIN dbo.MT_IzdatnicaStavka ON dbo.MT_SkladisteStavke.ID_IzdatnicaStavke = dbo.MT_IzdatnicaStavka.ID 
				INNER JOIN dbo.MT_Skladista ON dbo.MT_SkladisteStavke.ID_Skladista = dbo.MT_Skladista.ID 
				INNER JOIN dbo.JEDINICAMJERE ON dbo.MT_PrimkaStavke.ID_JedinicaMjere = dbo.JEDINICAMJERE.IDJEDINICAMJERE 
				INNER JOIN dbo.PROIZVOD ON dbo.MT_SkladisteStavke.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD
	
			WHERE MT_SkladisteStavke.ID_Skladista = @idSkladista
				and PROIZVOD.idGrupa is NOT NULL 
				and MT_SkladisteStavke.Kolicina > 0 
				and MT_SkladisteStavke.TS <=  @datum 
			group by  MT_SkladisteStavke.ID, MT_Skladista.id, MT_Skladista.Naziv, PROIZVOD.idGrupa, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, JEDINICAMJERE.NAZIVJEDINICAMJERE, MT_SkladisteStavke.Saldo, JEDINICAMJERE.IDJEDINICAMJERE, MT_Skladista.TS, MT_SkladisteStavke.Kolicina

			) 
			as derived1

			order by  
					case 
						when @order = 'PROIZVOD.IDPROIZVOD' then cast(derived1.IDPROIZVOD as nvarchar(50))
						when @order = 'PROIZVOD.NAZIVPROIZVOD' then cast(derived1.Proizvod as nvarchar(50))
						else cast(derived1.KolicinaX as nvarchar(50))
					end
		end
end
GO

--db 02.02.2017
/****** Object:  StoredProcedure [dbo].[spDohvatiPrimke]    Script Date: 2.2.2017. 13:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <28.1.2017>
-- Description:	<Dohvat svih primki za tekuću godinu>
-- =============================================
ALTER PROCEDURE [dbo].[spDohvatiPrimke]
(
	@godina int 
)
AS
BEGIN
	Select distinct CONVERT(bit, 0) AS Ozn, 
		MT_Primka.ID, 
		(MT_Primka.SifraPrimke + '       ' +  MT_Primka.Opis) As Opis,
		MT_Primka.SifraPrimke, 
		MT_Primka.DatumNastajanja, 
		PARTNER.NAZIVPARTNER, 
		MT_Primka.BrojUlaznogDokumenta, 
		MT_Skladista.Naziv As Skladiste, 
		isnull(cast(sum(MT_PrimkaStavke.Kolicina * MT_PrimkaStavke.Cijena) as decimal(10,2)), 0)       as NetoPrimke,
		isnull(cast(sum(MT_PrimkaStavke.Kolicina * MT_PrimkaStavke.CijenaPDV) as decimal(10,2)), 0)       as BrutoPrimke,
		isnull(cast(((sum(MT_PrimkaStavke.Kolicina * MT_PrimkaStavke.CijenaPDV)) - (sum(MT_PrimkaStavke.Kolicina * MT_PrimkaStavke.Cijena))) as decimal(10,2)), 0)     as PDVPrimke,		 
		MT_Primka.Preneseno, 
		MT_Primka.ID_Skladista 
From MT_Primka 
	Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER                                     
	Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID
	left outer join MT_PrimkaStavke on MT_PrimkaStavke.ID_Primke = MT_Primka.ID -- 02.02.2017 - left outer join iz razloga kad se kreira Primka, nema nijednoe zapisane stavke, i bilo koji drugi JOIN onda ne prikazuje praznu primku
where YEAR(DatumNastajanja) = @godina 
group by MT_Primka.ID, MT_Primka.SifraPrimke, MT_Primka.Opis, MT_Primka.DatumNastajanja, PARTNER.NAZIVPARTNER, MT_Primka.BrojUlaznogDokumenta, MT_Skladista.Naziv, MT_Primka.BrutoPrimke, MT_Primka.PDVPrimke, MT_Primka.Preneseno, MT_Primka.ID_Skladista
Order by MT_Primka.ID, MT_Primka.SifraPrimke
END
GO