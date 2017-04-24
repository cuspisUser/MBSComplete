
--Izmjena tablice
alter table MT_InventuraStavka
add TS date  null
GO

alter table MT_InventuraStavka
add CijenaPDV decimal(10,2)
go


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <20.1.2017>
-- Description:	<Dohvat stavki za inventuru>
-- =============================================
create PROCEDURE spInventuraDohvatStavki
	
AS
BEGIN	
	SELECT 
		stav.ID, 
		stav.ID_Inventura, 
		stav.ID_Proizvod, 
		pro.NAZIVPROIZVOD, 
		jed.NAZIVJEDINICAMJERE, 
		stav.CijenaPDV,
		stav.KolicinaZaliha, 		 			
		stav.StvarnaKolicina
	FROM MT_InventuraStavka stav 
		left join MT_Inventura inventura on inventura.ID = stav.ID_Inventura
		left join PROIZVOD pro on pro.IDPROIZVOD = stav.ID_Proizvod            
		left join JEDINICAMJERE jed on pro.IDJEDINICAMJERE = jed.IDJEDINICAMJERE 
		inner join MT_Skladista sklad on sklad.ID = inventura.IDSKladiste	
	where KolicinaZaliha <> 0 --uklanja one koji su 0
	order by pro.NAZIVPROIZVOD
END
GO


--db - 23.1.2017
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Davor Bursać
-- Create date: 2017-01-23
-- Description:	Procedura za report crpInventuraManjak 
-- =============================================
create procedure spInventuraManjak
(    
	  @IdInventure int, 
	  @datum date	  
)
as 
begin
	select distinct 
		inv.ID as IDInventure,
		inv.IDSKladiste as IDSkladista,
		sklad.Naziv as NazivSkladista,
		PROIZVOD.IDPROIZVOD AS SifraProizvoda,
		PROIZVOD.NAZIVPROIZVOD as NazivProizvoda,
		cast(ISNULL(abs(invStav.KolicinaZaliha - invStav.StvarnaKolicina), 0) as decimal(10,2)) as Razlika,		

		(Select Top 1 Stanje From MT_SkladisteStavke Where TS <= @datum And ID_Proizvod = invStav.ID_Proizvod And ID_Skladista =  inv.IDSkladiste  Order by TS desc, RedniBrojDan desc) as KolicinaX,
		--(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  order by ID desc) as Stanje,
		(Select Top 1 Saldo From MT_SkladisteStavke Where TS <= @datum  And ID_Proizvod = invStav.ID_Proizvod And ID_Skladista =  inv.IDSkladiste  Order by TS desc, RedniBrojDan desc)  as Saldo,
		(cast (nullif((Select Top 1 ss.Saldo From MT_SkladisteStavke ss  Where ss.ID_Proizvod = invStav.ID_Proizvod And ss.ID_Skladista =  inv.IDSkladiste  Order by ss.TS desc, ss.RedniBrojDan desc), 0) / nullif((Select Top 1 ss.Stanje From MT_SkladisteStavke ss Where ss.ID_Proizvod = invStav.ID_Proizvod And ss.ID_Skladista =  inv.IDSkladiste  Order by ss.TS desc, ss.RedniBrojDan desc), 0) as decimal(10,3) )  )as Cijena
		
	from MT_InventuraStavka invStav
		left join MT_Inventura inv on inv.ID = invStav.ID_Inventura --> INVENTURA - INVENTURA STAVKA		
		inner join MT_Skladista sklad on sklad.ID = inv.IDSKladiste --> SKLADIŠTA - INVENTURA 
		INNER JOIN dbo.PROIZVOD ON invStav.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD --> PROIZVOD - SKLADIŠTE STAVKA 
	where 
		invStav.ID_Inventura = @idInventure
		and invStav.TS <= @datum
		and PROIZVOD.idGrupa is NOT NULL 
		and (invStav.KolicinaZaliha - invStav.StvarnaKolicina) > 0
	group by inv.id, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, invStav.KolicinaZaliha, invStav.StvarnaKolicina, inv.IDSKladiste, sklad.Naziv, invStav.ID_Proizvod
end
go


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Davor Bursać
-- Create date: 2017-01-24
-- Description:	Procedura za report crpInventuraVishak 
-- =============================================
create procedure spInventuraVishak

(    
	  @IdInventure int, 
	  @datum date
	  --@order nvarchar (50)
)
as 
begin
	select distinct 
		inv.ID as IDInventure,
		inv.IDSKladiste as IDSkladista,
		sklad.Naziv as NazivSkladista,
		PROIZVOD.IDPROIZVOD AS SifraProizvoda,
		PROIZVOD.NAZIVPROIZVOD as NazivProizvoda,
		cast(ISNULL(abs(invStav.KolicinaZaliha - invStav.StvarnaKolicina), 0) as decimal(10,2)) as Razlika,		

		(Select Top 1 Stanje From MT_SkladisteStavke Where TS <= @datum And ID_Proizvod = invStav.ID_Proizvod And ID_Skladista =  inv.IDSkladiste  Order by TS desc, RedniBrojDan desc) as KolicinaX,
		--(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD and MT_SkladisteStavke.TS <= @datum  order by ID desc) as Stanje,
		(Select Top 1 Saldo From MT_SkladisteStavke Where TS <= @datum  And ID_Proizvod = invStav.ID_Proizvod And ID_Skladista =  inv.IDSkladiste  Order by TS desc, RedniBrojDan desc)  as Saldo,
		(cast (nullif((Select Top 1 ss.Saldo From MT_SkladisteStavke ss  Where ss.ID_Proizvod = invStav.ID_Proizvod And ss.ID_Skladista =  inv.IDSkladiste  Order by ss.TS desc, ss.RedniBrojDan desc), 0) / nullif((Select Top 1 ss.Stanje From MT_SkladisteStavke ss Where ss.ID_Proizvod = invStav.ID_Proizvod And ss.ID_Skladista =  inv.IDSkladiste  Order by ss.TS desc, ss.RedniBrojDan desc), 0) as decimal(10,3) )  )as Cijena
		
	from MT_InventuraStavka invStav
		left join MT_Inventura inv on inv.ID = invStav.ID_Inventura --> INVENTURA - INVENTURA STAVKA		
		inner join MT_Skladista sklad on sklad.ID = inv.IDSKladiste --> SKLADIŠTA - INVENTURA 
		INNER JOIN dbo.PROIZVOD ON invStav.ID_Proizvod = dbo.PROIZVOD.IDPROIZVOD --> PROIZVOD - SKLADIŠTE STAVKA 
	where 
		invStav.ID_Inventura = @idInventure
		and invStav.TS <= @datum
		and PROIZVOD.idGrupa is NOT NULL 
		and (invStav.KolicinaZaliha - invStav.StvarnaKolicina) < 0
	group by inv.id, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD, invStav.KolicinaZaliha, invStav.StvarnaKolicina, inv.IDSKladiste, sklad.Naziv, invStav.ID_Proizvod
end
go


/****** Object:  StoredProcedure [dbo].[spGrupaInventuraManjak]    Script Date: 24.1.2017. 14:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--db 25.1.2017
-- =============================================
-- Author:		Davor Bursać
-- Create date: 2017-01-24
-- Description:	Procedura za subreport crpInventuraManjak 
-- =============================================
create procedure [dbo].[spGrupaInventuraManjak]
(
	@idInventure int
)
as 
begin
	select distinct 
	ab.Naziv,
	ab.IDGrupe,
	sum(ab.Kolicina) as KolicinaUkupno,
	sum(ab.CijenaUkupno) as IznosUkupno 
	from (	
		select
			grp.ID as IDGrupe
		,	grp.Naziv as Naziv
			
			--Kolicina
		 , (select isnull(MT_InventuraStavka.StvarnaKolicina,0) 
			from MT_InventuraStavka
				Inner Join PROIZVOD On MT_InventuraStavka.ID_Proizvod = PROIZVOD.IDPROIZVOD		
			Where PROIZVOD.IDPROIZVOD = product.IDPROIZVOD And idGrupa is NOT NULL                        ) as Kolicina
				
			--Cijena
		 , (select sum(MT_InventuraStavka.CijenaPDV * MT_InventuraStavka.StvarnaKolicina)
			from MT_InventuraStavka
				Inner Join PROIZVOD On MT_InventuraStavka.ID_Proizvod = PROIZVOD.IDPROIZVOD		
			Where PROIZVOD.idGrupa = product.idGrupa 
			And idGrupa is NOT NULL  
			and PROIZVOD.IDPROIZVOD = product.IDPROIZVOD 
			group by PROIZVOD.IDPROIZVOD                     ) as CijenaUkupno
		
		from MT_InventuraStavka invStav
			left join MT_Inventura inv on invStav.ID_Inventura = inv.ID  -- inventura -> inventura stavka
			left join PROIZVOD product on invStav.ID_Proizvod = product.IDPROIZVOD -- inventura stavka -> proizvod   
			left join MT_GrupeProizvoda as grp on grp.ID = product.idGrupa  -- proizvod -> grupa
	
		where inv.ID = @idInventure 
			and (invStav.KolicinaZaliha - invStav.StvarnaKolicina) > 0  --> ovo '>' određuje je li manjak i li višak. Ali za manjak mora biti '>'
			and product.idGrupa is not null
	
		group by product.idGrupa, invStav.ID_Proizvod, grp.Naziv, product.IDPROIZVOD, grp.ID /*, inv.IDSKladiste, invstav.KolicinaZaliha, grp.ID, product.IDPROIZVOD*/

	) ab
	group by ab.Naziv, ab.IDGrupe
end


/****** Object:  StoredProcedure [dbo].[spGrupaInventuraManjak]    Script Date: 24.1.2017. 14:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Davor Bursać
-- Create date: 2017-01-24
-- Description:	Procedura za subreport crpInventuraManjak 
-- =============================================
create procedure [dbo].[spGrupaInventuraVishak]
(
	@idInventure int
)
as 
begin
	select distinct 
	ab.Naziv,
	ab.IDGrupe,
	sum(ab.Kolicina) as KolicinaUkupno,
	sum(ab.CijenaUkupno) as IznosUkupno 
	from (	
		select
			grp.ID as IDGrupe
		,	grp.Naziv as Naziv
			
			--Kolicina
		 , (select isnull(MT_InventuraStavka.StvarnaKolicina,0) 
			from MT_InventuraStavka
				Inner Join PROIZVOD On MT_InventuraStavka.ID_Proizvod = PROIZVOD.IDPROIZVOD		
			Where PROIZVOD.IDPROIZVOD = product.IDPROIZVOD And idGrupa is NOT NULL                        ) as Kolicina
				
			--Cijena
		 , (select sum(MT_InventuraStavka.CijenaPDV * MT_InventuraStavka.StvarnaKolicina)
			from MT_InventuraStavka
				Inner Join PROIZVOD On MT_InventuraStavka.ID_Proizvod = PROIZVOD.IDPROIZVOD		
			Where PROIZVOD.idGrupa = product.idGrupa 
			And idGrupa is NOT NULL  
			and PROIZVOD.IDPROIZVOD = product.IDPROIZVOD 
			group by PROIZVOD.IDPROIZVOD                     ) as CijenaUkupno
			
		from MT_InventuraStavka invStav
			left join MT_Inventura inv on invStav.ID_Inventura = inv.ID  -- inventura -> inventura stavka
			left join PROIZVOD product on invStav.ID_Proizvod = product.IDPROIZVOD -- inventura stavka -> proizvod   
			left join MT_GrupeProizvoda as grp on grp.ID = product.idGrupa  -- proizvod -> grupa
	
		where inv.ID = @idInventure 
			and (invStav.KolicinaZaliha - invStav.StvarnaKolicina) < 0  --> ovo '<' određuje je li manjak i li višak. Ali za višak mora biti '<'
			and product.idGrupa is not null
	
		group by product.idGrupa, invStav.ID_Proizvod, grp.Naziv, product.IDPROIZVOD, grp.ID /*, inv.IDSKladiste, invstav.KolicinaZaliha, grp.ID, product.IDPROIZVOD*/

	) ab
	group by ab.Naziv, ab.IDGrupe
end
go


/****** Object:  StoredProcedure [dbo].[spStanjeSkladista]    Script Date: 25.1.2017. 10:31:59 ******/
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
	
	(Select Top 1 Stanje From MT_SkladisteStavke Where TS <= @datum And ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  Order by ID desc, RedniBrojDan desc) as KolicinaX, 	

	--OVO SU SIGURNO ZADNJE STANJE I SALDO ZA OVE PROIZVODE!!!
	(Select Top 1 Saldo  From MT_SkladisteStavke Where ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  Order by ID desc, RedniBrojDan desc)  as Saldo,	
	(SELECT top 1 Stanje FROM MT_SkladisteStavke where ID_Proizvod = PROIZVOD.IDPROIZVOD And ID_Skladista =  @idSkladista  order by ID desc) as Stanje,		
	
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
GO

--db 25.1.2017
/****** Object:  StoredProcedure [dbo].[spInventuraDohvatStavki]    Script Date: 25.1.2017. 11:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <20.1.2017>
-- Description:	<Dohvat stavki za inventuru>
-- =============================================
create PROCEDURE [dbo].[spInventuraDohvatStavki]	
AS
BEGIN	
	SELECT 
		stav.ID, 
		stav.ID_Inventura, 
		stav.ID_Proizvod, 
		pro.NAZIVPROIZVOD, 
		jed.NAZIVJEDINICAMJERE, 
		stav.CijenaPDV,
		stav.KolicinaZaliha, 		 			
		stav.StvarnaKolicina
	FROM MT_InventuraStavka stav 
		left join MT_Inventura inventura on inventura.ID = stav.ID_Inventura
		left join PROIZVOD pro on pro.IDPROIZVOD = stav.ID_Proizvod            
		left join JEDINICAMJERE jed on pro.IDJEDINICAMJERE = jed.IDJEDINICAMJERE 
		inner join MT_Skladista sklad on sklad.ID = inventura.IDSKladiste	
	where KolicinaZaliha <> 0 --uklanja one koji su 0
	order by pro.NAZIVPROIZVOD
END


--služi kao flag koji signalizira da li je inventura prebacena u Primke i PrimkaStavke. ukoliko je, NIJE omogućen EDIT te inventure
alter table MT_Inventura
add Prebaceno bit
go



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <26.1.2017>
-- Description:	<Unos inventure u Primke kao početno stanje>
-- =============================================
create PROCEDURE [dbo].[spInventuraPocetnoPrimka]
(	
		  @SifraPrimke nvarchar(50),
          @DatumNastajanja datetime,
          @ID_Partnera int,
          @ID_Dokumenta int,
          @DatumDokumentaDobavljaca date,
          @ID_Skladista int,
          @ID_Narudzbenice int,
          @NetoPrimke money,
          @PDVPrimke money,
          @BrutoPrimke money,
          @ZavisniTransport money,
          @ZavisniCarina money,
          @ZavisniOstalo money,
          @BrojUlaznogDokumenta nvarchar(50),
          @Preneseno bit,
          @TS datetime,
          @Opis nvarchar(100)
)
AS
BEGIN
	INSERT INTO [dbo].[MT_Primka]
           ([SifraPrimke]
           ,[DatumNastajanja]
           ,[ID_Partnera]
           ,[ID_Dokumenta]
           ,[DatumDokumentaDobavljaca]
           ,[ID_Skladista]
           ,[ID_Narudzbenice]
           ,[NetoPrimke]
           ,[PDVPrimke]
           ,[BrutoPrimke]
           ,[ZavisniTransport]
           ,[ZavisniCarina]
           ,[ZavisniOstalo]
           ,[BrojUlaznogDokumenta]
           ,[Preneseno]
           ,[TS]
           ,[Opis])
     VALUES
		  (@SifraPrimke ,
          @DatumNastajanja ,
          @ID_Partnera ,
          @ID_Dokumenta ,
          @DatumDokumentaDobavljaca ,
          @ID_Skladista ,
          @ID_Narudzbenice ,
          @NetoPrimke ,
          @PDVPrimke ,
          @BrutoPrimke ,
          @ZavisniTransport ,
          @ZavisniCarina ,
          @ZavisniOstalo ,
          @BrojUlaznogDokumenta ,
          @Preneseno ,
          @TS ,
          @Opis)

	select @@IDENTITY
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <26.1.2017>
-- Description:	<<Unos inventure u MT_PrimkaStavke kao početno stanje>>
-- =============================================
CREATE PROCEDURE spInventuraPocetnoPrimkaStavke 
(
		   @ID_Primke int,
           @ID_Proizvoda int,
           @ID_JedinicaMjere int,
           @Cijena money,
           @ID_Porez int,
           @Kolicina decimal(16,4),
           @CijenaPDV money,
           @RedniBroj int,
           @RedniBrojDan int
)
AS
BEGIN
	INSERT INTO [dbo].[MT_PrimkaStavke]
           ([ID_Primke]
           ,[ID_Proizvoda]
           ,[ID_JedinicaMjere]
           ,[Cijena]
           ,[ID_Porez]
           ,[Kolicina]
           ,[CijenaPDV]
           ,[RedniBroj]
           ,[RedniBrojDan])
     VALUES
           (@ID_Primke ,
           @ID_Proizvoda ,
           @ID_JedinicaMjere ,
           @Cijena ,
           @ID_Porez ,
           @Kolicina ,
           @CijenaPDV ,
           @RedniBroj ,
           @RedniBrojDan )
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <28.1.2017>
-- Description:	<Dohvat svih primki za tekuću godinu>
-- =============================================
create PROCEDURE spDohvatiPrimke
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
		cast(sum(MT_PrimkaStavke.Kolicina * MT_PrimkaStavke.Cijena) as decimal(10,2)) as NetoPrimke,
		cast(sum(MT_PrimkaStavke.Kolicina * MT_PrimkaStavke.CijenaPDV) as decimal(10,2))  as BrutoPrimke,
		cast(((sum(MT_PrimkaStavke.Kolicina * MT_PrimkaStavke.CijenaPDV)) - (sum(MT_PrimkaStavke.Kolicina * MT_PrimkaStavke.Cijena))) as decimal(10,2)) as PDVPrimke,		 
		MT_Primka.Preneseno, 
		MT_Primka.ID_Skladista 
From MT_Primka 
	Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER                                     
	Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID
	inner join MT_PrimkaStavke on MT_PrimkaStavke.ID_Primke = MT_Primka.ID 
where YEAR(DatumNastajanja) = @godina 
group by MT_Primka.ID, MT_Primka.SifraPrimke, MT_Primka.Opis, MT_Primka.DatumNastajanja, PARTNER.NAZIVPARTNER, MT_Primka.BrojUlaznogDokumenta, MT_Skladista.Naziv, MT_Primka.BrutoPrimke, MT_Primka.PDVPrimke, MT_Primka.Preneseno, MT_Primka.ID_Skladista
Order by MT_Primka.ID, MT_Primka.SifraPrimke
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <28.1.2017>
-- Description:	<Dohvat svih primka stavki za tekuću godinu>
-- =============================================
CREATE PROCEDURE spDohvatiPrimkaStavke
(
	@godina int 
)
AS
BEGIN
	Select MT_PrimkaStavke.RedniBroj, 
		PROIZVOD.NAZIVPROIZVOD, 
		JEDINICAMJERE.NAZIVJEDINICAMJERE, 
		Kolicina, 
		MT_PrimkaStavke.Cijena As Neto, 
		MT_PrimkaStavke.CIjenaPDV As Bruto,   
		(MT_PrimkaStavke.CijenaPDV - MT_PrimkaStavke.Cijena) as PDV,                                 
	 	cast(Round((Kolicina *  MT_PrimkaStavke.Cijena), 2) as decimal(10,2)) As [Uk.Neto], 
		cast(Round((Kolicina *  MT_PrimkaStavke.CIjenaPDV), 2) as decimal(10,2)) As [Uk.Bruto],		
		cast(((Kolicina *  MT_PrimkaStavke.CIjenaPDV) - (Kolicina *  MT_PrimkaStavke.Cijena)) as decimal(10,2)) As [Uk.PDV],
		FINPOREZ.FINPOREZSTOPA as StopaPDV,                                    
		ID_Primke 
From MT_PrimkaStavke 
	Inner Join PROIZVOD on MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD  
	Inner Join JEDINICAMJERE on MT_PrimkaStavke.ID_JedinicaMjere = JEDINICAMJERE.IDJEDINICAMJERE 
	Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID 
	inner join FINPOREZ on MT_PrimkaStavke.ID_Porez = FINPOREZ.FINPOREZIDPOREZ 
Where YEAR(MT_Primka.DatumNastajanja) = @godina 
Order by NAZIVPROIZVOD

END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <28.1.2017>
-- Description:	<Dohvat svih izdatnica za tekuću godinu>
-- =============================================
create PROCEDURE spDohvatiIzdatnice 
(
	@godina int 
)
AS
BEGIN
	Select 'false' As Ozn,  
		MT_Izdatnica.ID, 
		MT_Izdatnica.Sifra, 
		DOKUMENT.NAZIVDOKUMENT As Dokument, 
		MT_Izdatnica.DatumNastajanja, 
		MT_Skladista.Naziv As Skladiste, 
		ROUND(MT_Izdatnica.UkupanIznos, 2) As UkupanIznos, 
		MT_Izdatnica.Napomena, Zaduzen 
	From MT_Izdatnica 
		Inner Join DOKUMENT On MT_Izdatnica.ID_Dokumenta = DOKUMENT.IDDOKUMENT 
		Inner Join MT_Skladista On MT_Izdatnica.ID_Skladista = MT_Skladista.ID
	Where YEAR(DatumNastajanja) = @godina
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Davor Bursać>
-- Create date: <28.1.2017>
-- Description:	<Dohvat svih izdatnica stavki za tekuću godinu>
-- =============================================
create PROCEDURE spDohvatiIzdatnicaStavke 
(
	@godina int 
)
AS
BEGIN
	Select 
		MT_IzdatnicaStavka.ID_Izdatnice, 
		MT_IzdatnicaStavka.RedniBroj, 
		PROIZVOD.IDPROIZVOD, 
		PROIZVOD.NAZIVPROIZVOD AS Stavka, 
		MT_IzdatnicaStavka.Kolicina, 
		MT_IzdatnicaStavka.NabavnaCijena, 
		ROUND(MT_IzdatnicaStavka.UkupanIznos, 2) As Ukupno 
	From MT_IzdatnicaStavka 
		Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD
		inner join MT_Izdatnica on MT_Izdatnica.ID = MT_IzdatnicaStavka.ID_Izdatnice 
	Where YEAR(DatumNastajanja) = @godina 
	Order by MT_IzdatnicaStavka.RedniBroj, PROIZVOD.NAZIVPROIZVOD
END
GO