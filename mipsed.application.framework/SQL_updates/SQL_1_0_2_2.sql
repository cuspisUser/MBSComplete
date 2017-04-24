/****** Object:  StoredProcedure [dbo].[spDopunaPRRAS]    Script Date: 07.10.2016 13:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[spDopunaObveze]
(
	@datumod As nvarchar(10),
	@datumdo As nvarchar(10),
	@datumZatvaranja As nvarchar(10),
	@godina As smallint
)
AS 	
	Begin
	--obveze
			Select 'A003' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '2%' And GKSTAVKA.DATUMDOKUMENTA Between @datumod And @datumdo and statusgk = 1

		union

		Select 'A005' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '231%' And GKSTAVKA.DATUMDOKUMENTA Between @datumod And @datumdo and statusgk = 1

		Union

		Select 'A006' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '232%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A007' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '234%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A008' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '235%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A009' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '236%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A010' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '237%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A011' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '238%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A012' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '239%' And GKSTAVKA.DATUMDOKUMENTA Between @datumod And @datumdo and statusgk = 1

		Union

		Select 'A013' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '24%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A015' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where (GKSTAVKA.IDKONTO like '251%' Or GKSTAVKA.IDKONTO Like '253%') And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A016' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '254%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A017' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '256%' And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A018' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where (GKSTAVKA.IDKONTO like '262%' Or GKSTAVKA.IDKONTO like '263%' Or GKSTAVKA.IDKONTO like '2643%' Or GKSTAVKA.IDKONTO 
		like '2644%' Or GKSTAVKA.IDKONTO like '2645%' Or GKSTAVKA.IDKONTO like '2653%' Or GKSTAVKA.IDKONTO like '2654' Or GKSTAVKA.IDKONTO like '267%') And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo  and statusgk = 1

		Union

		Select 'A019' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where (GKSTAVKA.IDKONTO like '261%' Or GKSTAVKA.IDKONTO like '2646%' Or GKSTAVKA.IDKONTO like '2647%' Or GKSTAVKA.IDKONTO like '2648%' 
		Or GKSTAVKA.IDKONTO like '2655%' Or GKSTAVKA.IDKONTO like '2656%') And GKSTAVKA.DATUMDOKUMENTA between @datumOd And @datumDo and statusgk = 1

		Union

		Select 'A023' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '231%' And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A024' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '232%' And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A025' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '234%' And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A026' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '235%' And DATUMDOKUMENTA  <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A027' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '236%' And DATUMDOKUMENTA  <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A028' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '237%' And DATUMDOKUMENTA  <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A029' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '238%' And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A030' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '239%' And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A031' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '24%' And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A033' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where (GKSTAVKA.IDKONTO like '251%' Or GKSTAVKA.IDKONTO like '253%') And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A034' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '254%' And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A035' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO like '256%' And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A036' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where (GKSTAVKA.IDKONTO like '262%' Or GKSTAVKA.IDKONTO like '263%' Or GKSTAVKA.IDKONTO like '2643%' Or GKSTAVKA.IDKONTO like '2644%' Or GKSTAVKA.IDKONTO like '2645%' 
		Or GKSTAVKA.IDKONTO like '2653%' Or GKSTAVKA.IDKONTO like '2654' Or GKSTAVKA.IDKONTO like '267%') And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

		Select 'A037' As Naziv, cast(round(ISNull(Sum(duguje),0),0)as int) As Iznos From GKSTAVKA 
		Where (GKSTAVKA.IDKONTO like '261%' Or GKSTAVKA.IDKONTO like '2646%' Or GKSTAVKA.IDKONTO like '2647%' Or GKSTAVKA.IDKONTO like '2648%' Or GKSTAVKA.IDKONTO like '2655%' 
		Or GKSTAVKA.IDKONTO like '2656%') And datumdokumenta <= @datumdo And GKGODIDGODINE = @godina and statusgk = 1

		Union

--		Select 'A041' As Naziv, 
-- (SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'2%'
--And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

---
--(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
-- Where GKSTAVKA.IDKONTO like '2%'
--And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) )as Iznos

--		Union

--		Select 'A042' As Naziv, 
--ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '2%'
--And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
-- -
--(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '2%'
--And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ) as iznos

--		Union

--		Select 'A043' As Naziv, 
--ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '2%'
--And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
-- -
--(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '2%'
--And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ) as iznos

--		Union

--		Select 'A044' As Naziv, 
--ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '2%'
--And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
-- -
--(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '2%'
--And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ) as iznos

--		Union

		Select 'A047' As Naziv, 
 cast(round((SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'231%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '231%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos

		Union

		Select 'A048' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '231%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '231%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A049' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '231%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '231%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A050' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '231%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '231%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos


		Union

		Select 'A052' As Naziv, 
 cast(round((SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'232%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '232%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos 

		Union

		Select 'A053' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '232%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '232%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A054' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '232%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '232%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A055' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '232%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '232%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A057' As Naziv, 
 cast(round((SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'234%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '234%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos 


		Union

		Select 'A058' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '234%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '234%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos


		Union

		Select 'A059' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '234%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '234%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos


		Union

		Select 'A060' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '234%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '234%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A062' As Naziv, 
 cast(round((SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'235%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '235%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos 

		Union

		Select 'A063' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '235%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '235%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A064' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '235%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '235%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A065' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '235%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '235%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos


		Union

		Select 'A067' As Naziv, 
cast(round( (SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'236%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '236%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos 


		Union

		Select 'A068' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '236%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '236%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A069' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '236%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '236%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A070' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '236%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '236%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos

		Union
		Select 'A072' As Naziv, 
 cast(round((SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'237%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '237%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos 

		Union

		Select 'A073' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '237%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '237%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A074' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '237%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '237%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A075' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '237%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '237%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A077' As Naziv, 
cast(round( (SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'238%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '238%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos 

		Union

		Select 'A078' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '238%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '238%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A079' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '238%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '238%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos

		Union


		Select 'A080' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '238%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '238%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A082' As Naziv, 
cast(round( (SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'239%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '239%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos 


		Union

		Select 'A083' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '239%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '239%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A084' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '239%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '239%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos

		Union

		
		Select 'A085' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '239%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '239%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos

UNION

		Select 'A087' As Naziv, 
cast(round( (SELECT Distinct( abs((Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where idkonto like'24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1   and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -60, @datumdo ) And  @datumdo )

-
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA
 Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1  and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -60, @datumdo) And  @datumdo) )) ),0)as int)as iznos 

		Union

		Select 'A088' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -180, @datumdo) And DATEADD(DAY, -61, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -180, @datumdo) And  DATEADD(DAY, -61, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A089' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE Between DATEADD(DAY, -360, @datumdo) And DATEADD(DAY, -181, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  Between DATEADD(DAY, -360, @datumdo) And  DATEADD(DAY, -181, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A090' As Naziv, 
cast(round(ABS ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE <= DATEADD(DAY, -361, @datumdo)))
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and statusgk = 1 and GKSTAVKA.GKDATUMVALUTE  <= DATEADD(DAY, -361, @datumdo) )) ),0)as int) as iznos

		Union

		Select 'A092' As Naziv, 
cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '251%' or idkonto like '253%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '251%' or idkonto like '253%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) ))),0)as int) as iznos

		Union

		Select 'A093' As Naziv, 
cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '254%' 
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '254%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) ))),0)as int) as iznos

		Union

		Select 'A094' As Naziv, 
cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '256%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '256%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) ))),0)as int) as iznos
		
		Union

		Select 'A095' As Naziv, 
cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where (GKSTAVKA.IDKONTO like '262%' Or GKSTAVKA.IDKONTO like '263%' Or GKSTAVKA.IDKONTO like '2643%' Or GKSTAVKA.IDKONTO like '2644%' Or GKSTAVKA.IDKONTO like '2645%' 
		Or GKSTAVKA.IDKONTO like '2653%' Or GKSTAVKA.IDKONTO like '2654' Or GKSTAVKA.IDKONTO like '267%')
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where (GKSTAVKA.IDKONTO like '262%' Or GKSTAVKA.IDKONTO like '263%' Or GKSTAVKA.IDKONTO like '2643%' Or GKSTAVKA.IDKONTO like '2644%' Or GKSTAVKA.IDKONTO like '2645%' 
		Or GKSTAVKA.IDKONTO like '2653%' Or GKSTAVKA.IDKONTO like '2654' Or GKSTAVKA.IDKONTO like '267%')
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) ))),0)as int) as iznos

		Union

		Select 'A096' As Naziv, 
cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where (GKSTAVKA.IDKONTO like '2646%' Or GKSTAVKA.IDKONTO like '2647%' Or GKSTAVKA.IDKONTO like '2648%' Or GKSTAVKA.IDKONTO like '2655%') 
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where (GKSTAVKA.IDKONTO like '2646%' Or GKSTAVKA.IDKONTO like '2647%' Or GKSTAVKA.IDKONTO like '2648%' Or GKSTAVKA.IDKONTO like '2655%') 
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and statusgk = 1 and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) ))),0)as int) as iznos

Union

Select 'A099' As Naziv,
 cast(round((Select ISNull (Sum(potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like'23%'
 And GKSTAVKA.DATUMDOKUMENTA <= @datumDo And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) )
 -
(select  (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDo) ))),0)as int) as iznos

Union

Select 'A100' As Naziv,
 cast(round((Select ISNull (Sum(potrazuje - duguje), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like'24%'
 And GKSTAVKA.DATUMDOKUMENTA <= @datumDo And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) )
 -
(select  (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDo) ))),0)as int) as iznos

Union

Select 'A101' As Naziv,
cast(round( (Select ISNull (Sum(potrazuje - duguje), 0) From GKSTAVKA Where (GKSTAVKA.IDKONTO like '251%' Or GKSTAVKA.IDKONTO like '253%' Or GKSTAVKA.IDKONTO like '254%' Or GKSTAVKA.IDKONTO like '256%' Or GKSTAVKA.IDKONTO like '262%' 
Or GKSTAVKA.IDKONTO like '263%' Or GKSTAVKA.IDKONTO like '2643%' Or GKSTAVKA.IDKONTO like '2644%' Or GKSTAVKA.IDKONTO like '2645%' Or GKSTAVKA.IDKONTO like '2653%' 
Or GKSTAVKA.IDKONTO like '2654' Or GKSTAVKA.IDKONTO like '267%' Or GKSTAVKA.IDKONTO like '261%' Or GKSTAVKA.IDKONTO like '2646%' Or GKSTAVKA.IDKONTO like '2647%' 
Or GKSTAVKA.IDKONTO like '2648%' Or GKSTAVKA.IDKONTO like '2655%' Or GKSTAVKA.IDKONTO like '2656%')
 And GKSTAVKA.DATUMDOKUMENTA <= @datumDo And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) )
 -
(select  (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where (GKSTAVKA.IDKONTO like '251%' Or GKSTAVKA.IDKONTO like '253%' Or GKSTAVKA.IDKONTO like '254%' Or GKSTAVKA.IDKONTO like '256%' Or GKSTAVKA.IDKONTO like '262%' 
Or GKSTAVKA.IDKONTO like '263%' Or GKSTAVKA.IDKONTO like '2643%' Or GKSTAVKA.IDKONTO like '2644%' Or GKSTAVKA.IDKONTO like '2645%' Or GKSTAVKA.IDKONTO like '2653%' 
Or GKSTAVKA.IDKONTO like '2654' Or GKSTAVKA.IDKONTO like '267%' Or GKSTAVKA.IDKONTO like '261%' Or GKSTAVKA.IDKONTO like '2646%' Or GKSTAVKA.IDKONTO like '2647%' 
Or GKSTAVKA.IDKONTO like '2648%' Or GKSTAVKA.IDKONTO like '2655%' Or GKSTAVKA.IDKONTO like '2656%')
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1)  and POTRAZUJE > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA Where (GKSTAVKA.IDKONTO like '251%' Or GKSTAVKA.IDKONTO like '253%' Or GKSTAVKA.IDKONTO like '254%' Or GKSTAVKA.IDKONTO like '256%' Or GKSTAVKA.IDKONTO like '262%' 
Or GKSTAVKA.IDKONTO like '263%' Or GKSTAVKA.IDKONTO like '2643%' Or GKSTAVKA.IDKONTO like '2644%' Or GKSTAVKA.IDKONTO like '2645%' Or GKSTAVKA.IDKONTO like '2653%' 
Or GKSTAVKA.IDKONTO like '2654' Or GKSTAVKA.IDKONTO like '267%' Or GKSTAVKA.IDKONTO like '261%' Or GKSTAVKA.IDKONTO like '2646%' Or GKSTAVKA.IDKONTO like '2647%' 
Or GKSTAVKA.IDKONTO like '2648%' Or GKSTAVKA.IDKONTO like '2655%' Or GKSTAVKA.IDKONTO like '2656%')
And GKGODIDGODINE = (Select IDGODINE From GODINE Where GODINEAKTIVNA = 1) and DUGUJE > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDo) ))),0)as int) as iznos
    End
RETURN
GO




/****** Object:  StoredProcedure [dbo].[spDopunaPRRAS]    Script Date: 07.10.2016 13:29:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[spDopunaPRRAS]
(
	@datumod As nvarchar(10),
	@datumdo As nvarchar(10),
	@datumZatvaranja As nvarchar(10),
	@godina As smallint
)
AS 	
	Begin


--bilanca

		Select 'A247' As Naziv,cast(round(abs( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) )) ),0)as int)

Union

		Select 'A2471' As Naziv, cast(round(abs(( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and iddokument = 1 and brojdokumenta = 1  and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and iddokument = 1 and brojdokumenta = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

		Union

		Select 'A248' As Naziv,cast(round( ABS((Select ISNull (Sum(duguje  - POTRAZUJE ), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 And GKSTAVKA.DATUMDOKUMENTA <= @datumDO )) 
 -
((SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDO )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDO) ))) ,0)as int)

Union

		Select 'A2481' As Naziv,cast(round(ABS( (Select ISNull (Sum(duguje  - POTRAZUJE ), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And statusgk = 1 and GKSTAVKA.DATUMDOKUMENTA <= @datumod ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1  and iddokument = 1 and brojdokumenta = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '13%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1  and iddokument = 1 and brojdokumenta = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

Union

		Select 'A249' As Naziv,cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) )) ),0)as int)

Union

		Select 'A2491' As Naziv,cast(round(ABS( ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

Union

		Select 'A250' As Naziv,cast(round(ABS( (Select Sum(duguje  - POTRAZUJE ) From GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 And GKSTAVKA.DATUMDOKUMENTA <= @datumDO ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDO )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDO) ))) ),0)as int)

Union

		Select 'A2501' As Naziv,cast(round( ABS((Select ISNull (Sum(duguje  - POTRAZUJE ), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And statusgk = 1 and iddokument = 1 and BROJDOKUMENTA = 1 and GKSTAVKA.DATUMDOKUMENTA <= @datumod )) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '16%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ,0)as int)

Union
		
		Select 'A251' As Naziv,cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) )) ),0)as int)

Union

		Select 'A2511' As Naziv,cast(round( ABS(( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

Union

		Select 'A252' As Naziv, cast(round(ABS((Select isnull (Sum(duguje  - POTRAZUJE ),0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 And GKSTAVKA.DATUMDOKUMENTA <= @datumDO ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDO )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDO) ))) ),0)as int)

Union

		Select 'A2521' As Naziv,cast(round(ABS( (Select ISNull (Sum(duguje  - POTRAZUJE ), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @GODINA And statusgk = 1  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and BROJDOKUMENTA = 1 and GKSTAVKA.DATUMDOKUMENTA <= @datumod ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @GODINA and statusgk = 1  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '17%'
 And GKGODIDGODINE = @GODINA and statusgk = 1  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  and POTRAZUJE  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

 Union
 				
		Select 'A253' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
Where GKSTAVKA.IDKONTO Like '13213%'   And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2531' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A254' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13323%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2541' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13323%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A255' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13333%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2551' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13333%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A256' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13343%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2561' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13343%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A257' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13413%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2571' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13413%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A258' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13533%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2581' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13533%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A259' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13543%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2591' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13543%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A260' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13553%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2601' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13553%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A261' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13633%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2611' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13633%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A262' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13643%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2621' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13643%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A263' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13723%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2631' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13723%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A264' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13733%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2641' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13733%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A265' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13743%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2651' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13743%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A266' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13753%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2661' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13753%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A267' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13763%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2671' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13763%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A268' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13773%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2681' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13773%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union

 		Select 'A269' As Naziv, 

		cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and POTRAZUJE   > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) )) ),0)as int)

  		Union

		Select 'A2691' As Naziv,cast(round( ABS(( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

		Union

		select 'A270' As Naziv,
cast(round(ABS((Select Sum(potrazuje  - duguje ) From GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 And GKSTAVKA.DATUMDOKUMENTA <= @datumDO ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDO )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDO) ))) ),0)as int)

		Union

		Select 'A2701' As Naziv,cast(round(ABS((Select ISNull (Sum(potrazuje  - duguje ), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And statusgk = 1 and iddokument = 1 and BROJDOKUMENTA = 1 and GKSTAVKA.DATUMDOKUMENTA <= @datumod ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '23%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)
		Union

Select 'A271' As Naziv, 

		cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and POTRAZUJE   > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @godina  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) )) ),0)as int)

  		Union

		Select 'A2711' As Naziv, cast(round(ABS(( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

		Union

		select 'A272' As Naziv,cast(round(ABS(
(Select Sum(potrazuje  - duguje ) From GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 And GKSTAVKA.DATUMDOKUMENTA <= @datumDO ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDO )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDO) ))) ),0)as int)

		Union

		Select 'A2721' As Naziv,cast(round(ABS((Select ISNull (Sum(potrazuje  - duguje ), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And statusgk = 1 and iddokument = 1 and BROJDOKUMENTA = 1 and GKSTAVKA.DATUMDOKUMENTA <= @datumod ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '24%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)


		Union
						

Select 'A273' As Naziv, 

		cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @godina  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and POTRAZUJE   > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) )) ),0)as int)

  		Union

		Select 'A2731' As Naziv,cast(round( ABS(( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

		Union

		select 'A274' As Naziv,
cast(round(ABS((Select isnull(Sum(potrazuje  - duguje ),0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 And GKSTAVKA.DATUMDOKUMENTA <= @datumDO ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDO )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDO) ))) ),0)as int)

		Union

		Select 'A2741' As Naziv,cast(round(ABS((Select ISNull (Sum(potrazuje  - duguje ), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And statusgk = 1 and iddokument = 1 and BROJDOKUMENTA = 1 and GKSTAVKA.DATUMDOKUMENTA <= @datumod ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '25%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)


		Union


Select 'A275' As Naziv, 

		cast(round(ABS( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @godina  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and POTRAZUJE   > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumdo )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @godina And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumdo) )) ),0)as int)

  		Union

		Select 'A2751' As Naziv,cast(round(ABS( ( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) ))) ),0)as int)

		Union

		select 'A276' As Naziv,
cast(round(ABS((Select Sum(potrazuje  - duguje ) From GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 And GKSTAVKA.DATUMDOKUMENTA <= @datumDO ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1 and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumDO )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1 and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE  <= @datumDO) ))) ),0)as int)

		Union

		Select 'A2761' As Naziv,cast(round(ABS((Select ISNull (Sum(potrazuje  - duguje ), 0) From GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And statusgk = 1 and iddokument = 1 and BROJDOKUMENTA = 1 and GKSTAVKA.DATUMDOKUMENTA <= @datumod ) -
( (SELECT Distinct( (Select ISNULL(SUM(dbo.GKSTAVKA.potrazuje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @GODINA  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and potrazuje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod )
 -
(Select ISNULL(SUM(dbo.GKSTAVKA.duguje - gkstavka.zatvoreniiznos), 0) From dbo.GKSTAVKA Where GKSTAVKA.IDKONTO like '26%'
 And GKGODIDGODINE = @GODINA And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and statusgk = 1  and iddokument = 1 and brojdokumenta = 1  and duguje  > 0 and GKSTAVKA.GKDATUMVALUTE <= @datumod) )))) ,0)as int)

		Union


		Select 'A277' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '23951%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2771' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '23951%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				
		Select 'A278' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26223%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2781' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26223%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
		Select 'A279' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26224%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2791' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26224%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A280' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26233%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2801' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26233%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union

				Select 'A281' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26243%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2811' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26243%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union

				Select 'A282' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26244%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2821' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26244%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union

				Select 'A283' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26314%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2831' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26314%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union

		Select 'A284' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26433%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2841' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26433%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumOd AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

				Select 'A285' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26434%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2851' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26434%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A286' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26443%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2861' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26443%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union
				Select 'A287' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26453%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2871' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union
				Select 'A288' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2881' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A289' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26463%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2891' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26463%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A290' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26464%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2901' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26464%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union

				Select 'A291' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26473%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2911' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26473%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A292' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26483%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2921' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26483%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A293' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26484%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2931' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26484%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union

				Select 'A294' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26534%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2941' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26534%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A295' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26544%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2951' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26544%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A296' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26554%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod    And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2961' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26554%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union
				Select 'A297' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26564%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A2971' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26564%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		
		Union

		--prras

		Select 'A640' As Naziv, cast(round(ISNull(Sum (abs(duguje - potrazuje)), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '11%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod And GKSTAVKA.DATUMDOKUMENTA  <= @datumOd AND GKGODIDGODINE = @GODINA and statusgk = 1		
		Union


		Select 'A6401' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '11%'and iddokument = 1 and brojdokumenta = 1  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumOd AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A641' As Naziv, cast(round(ISNull(Sum(duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '11%' and duguje> 0  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6411' As Naziv, cast(round(ISNull(Sum(duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '11%' and duguje> 0  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 and brojdokumenta = 1    AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A642' As Naziv, cast(round(ISNull(Sum(potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '11%' and potrazuje> 0  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6421' As Naziv, cast(round(ISNull(Sum(potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '11%' and potrazuje> 0  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 and brojdokumenta = 1  AND GKGODIDGODINE = @GODINA and statusgk = 1

	
		Union

		Select 'A649' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '61315%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6491' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '61315%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A650' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '61451%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6501' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '61451%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A651' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '61453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6511' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '61453%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A652' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63311%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6521' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63311%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A653' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63312%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6531' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63312%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A654' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63313%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6541' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63313%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A655' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63314%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6551' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63314%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A656' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63321%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6561' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63321%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A657' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63322%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6571' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63322%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A658' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6581' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A659' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63324%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6591' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63324%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union
		
		Select 'A660' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63414%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6601' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63414%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A661' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63415%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6611' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63415%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A662' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63416%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6621' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63416%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A663' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63424%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6631' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63424%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A664' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63425%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6641' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63425%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A665' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63426%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6651' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '63426%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A666' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64191%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6661' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64191%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A667' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64371%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6671' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64371%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A668' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64372%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6681' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64372%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A669' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64373%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6691' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64373%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A670' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64374%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6701' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64374%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A671' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64375%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6711' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64375%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A672' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64376%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6721' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64376%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A673' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64377%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6731' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '64377%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A674' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '65264%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6741' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '65264%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And BROJDOKUMENTA = 1  AND IDDOKUMENT = 1 and datumdokumenta <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A675' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '65265%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6751' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '65265%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A677' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '31214%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6771' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '31214%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And BROJDOKUMENTA = 1  AND IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A678' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '31215%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6781' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '31215%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A679' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32121%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6791' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32121%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A680' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32361%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6801' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '32361%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A681' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32371%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6811' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32371%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A682' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32372%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6821' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32372%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A683' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32377%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6831' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32377%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A684' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32911%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6841' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '32911%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A685' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '32923%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6851' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '32923%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A686' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34111%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6861' As Naziv,ISNull(Sum(duguje - potrazuje), 0)  As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34111%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A687' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '34112%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6871' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34112%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A688' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34121%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6881' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34121%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A689' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '34122%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6891' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '34122%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A690' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34131%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6901' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34131%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A691' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34132%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6911' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34132%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A692' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34191%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6921' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '34191%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A693' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34191%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6931' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34191%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A694' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '34213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6941' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A695' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34214%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6951' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34214%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A696' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34215%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6961' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34215%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A697' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34216%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6971' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34216%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A698' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34222%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6981' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34222%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A699' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34223%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A6991' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34223%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A700' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34224%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7001' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34224%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A701' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34233%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7011' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34233%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A702' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34234%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7021' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34234%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A703' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34235%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7031' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34235%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A704' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34236%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7041' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34236%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A705' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34237%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7051' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34237%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A706' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34238%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7061' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34238%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A707' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34273%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7071' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34273%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A708' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34274%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7081' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34274%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A709' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34275%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7091' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34275%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A710' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34281%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7101' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34281%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A711' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34282%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7111' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34282%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A712' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34283%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7121' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34283%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A713' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA   
		Where GKSTAVKA.IDKONTO Like '34284%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7131' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34284%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A714' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34285%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7141' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34285%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A715' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34286%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7151' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34286%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A716' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34287%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7161' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34287%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A717' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34341%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7171' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '34341%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A718' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '35231%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7181' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '35231%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A719' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '35232%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7191' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '35232%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A720' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36313%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7201' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36313%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A721' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36314%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7211' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36314%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A722' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36315%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7221' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36315%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A723' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36316%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7231' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36316%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A724' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36317%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7241' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36317%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A725' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36318%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7251' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36318%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A726' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36319%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7261' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36319%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A727' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7271' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A728' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36324%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7281' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36324%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A729' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36325%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7291' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36325%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A730' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36326%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7301' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36326%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A731' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36327%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7311' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36327%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A732' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36328%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7321' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36328%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A733' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36329%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7331' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36329%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A734' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7341' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A735' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7351' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A736' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36714%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7361' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36714%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A737' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36811%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7371' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36811%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A738' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36812%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7381' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36812%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A739' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36813%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7391' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36813%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A740' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36814%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7401' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36814%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A741' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36815%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7411' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36815%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A742' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36816%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7421' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36816%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A743' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36817%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7431' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36817%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A744' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36818%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7441' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36818%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A745' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36819%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7451' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36819%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A746' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36821%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7461' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36821%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A747' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36822%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7471' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36822%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A748' As Naziv,ISNull(Sum(duguje - potrazuje), 0)  As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '36823%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7481' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36823%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A749' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36824%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7491' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36824%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A750' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36825%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7501' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36825%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A751' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36826%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7511' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36826%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A752' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36827%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7521' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36827%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A753' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36828%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7531' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36828%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A754' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36829%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7541' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '36829%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A755' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37131%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7551' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37131%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A756' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37132%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7561' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37132%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A757' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37139%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7571' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37139%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A758' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37141%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7581' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37141%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A759' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37143%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7591' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37143%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A760' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37144%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7601' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37144%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A761' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37149%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7611' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37149%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A762' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37211%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7621' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37211%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A763' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37212%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7631' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37212%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A764' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7641' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A765' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37214%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7651' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37214%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A766' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37215%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7661' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37215%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A767' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37216%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7671' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37216%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A768' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37217%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7681' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37217%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A769' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37218%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7691' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37218%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A770' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37219%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7701' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37219%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A771' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37221%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7711' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37221%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A772' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37222%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7721' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37222%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A773' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37223%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7731' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37223%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A774' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37224%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7741' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37224%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A775' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37229%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7751' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '37229%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A776' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38117%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7761' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38117%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A777' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38612%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7771' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38612%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A778' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38613%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7781' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38613%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A779' As Naziv,ISNull(Sum(duguje - potrazuje), 0)  As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '38614%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7791' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38614%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A780' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38615%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7801' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38615%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A781' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38622%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7811' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38622%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A782' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38623%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7821' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38623%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A783' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38624%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7831' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38624%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A784' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38625%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7841' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38625%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A785' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38631%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7851' As Naziv,ISNull(Sum(duguje - potrazuje), 0)  As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '38631%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A786' as naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38632%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7861' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '38632%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A788' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81212%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7881' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81212%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A789' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7891' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A790' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81322%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7901' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81322%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A791' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7911' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81323%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A792' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81332%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7921' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81332%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A793' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81333%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7931' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81333%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A794' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81342%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7941' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81342%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A795' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81343%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7951' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81343%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A796' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81411%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA
		 and statusgk = 1
		Union

		Select 'A7961' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81411%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A797' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81412%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7971' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81412%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A798' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81413%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7981' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81413%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A799' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81532%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A7991' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81532%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A800' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81533%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8001' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81533%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A801' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81542%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8011' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81542%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A802' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81543%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8021' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81543%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A803' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81552%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8031' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81552%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A804' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81553%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8041' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81553%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A805' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81631%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8051' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81631%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A806' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81632%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8061' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81632%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A807' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81633%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8071' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81633%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A808' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81641%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8081' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81641%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A809' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81642%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8091' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81642%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A810' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81643%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8101' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81643%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A811' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8111' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A812' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8121' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A813' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81721%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8131' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81721%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A814' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81722%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8141' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81722%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1
 
		Union

		Select 'A815' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81723%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8151' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81723%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A816' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81731%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8161' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81731%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A817' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81732%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8171' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81732%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A818' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81733%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8181' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81733%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A819' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81741%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8191' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81741%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A820' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81742%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8201' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81742%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A821' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81743%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8211' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81743%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A822' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81751%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8221' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81751%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A823' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81752%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8231' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81752%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A824' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81753%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8241' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81753%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A825' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81761%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8251' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81761%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A826' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81762%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8261' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81762%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A827' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81763%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8271' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81763%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1
 
		 Union

		Select 'A828' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81771%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8281' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81771%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A829' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81772%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8291' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81772%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A830' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81773%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8301' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '81773%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A831' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '82412%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8311' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '82412%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A832' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84132%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8321' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84132%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A833' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84142%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8331' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84142%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A834' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84152%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8341' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84152%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A835' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84152%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8351' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84152%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A836' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84221%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8361' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84221%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A837' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84222%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8371' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84222%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A838' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84223%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8381' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84223%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A839' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84232%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8391' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84232%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A840' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84242%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8401' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84242%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A841' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84243%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8411' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84243%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A842' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84312%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8421' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84312%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A843' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84431%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8431' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84431%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A844' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84432%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8441' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84432%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A845' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84433%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8451' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84433%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A846' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84442%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8461' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84442%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A847' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84452%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8471' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84452%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A848' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84453%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8481' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A849' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84461%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8491' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84461%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A850' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84462%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8501' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84462%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A851' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84463%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8511' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84463%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A852' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84472%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8521' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84472%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A853' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84482%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8531' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84482%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A854' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84483%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8541' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84483%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A855' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84532%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8551' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84532%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A856' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84542%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8561' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84542%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A857' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84552%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8571' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84552%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A858' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8581' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A859' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8591' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A860' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84721%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8601' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84721%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A861' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84722%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8611' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84722%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A862' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84731%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8621' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84731%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A863' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84732%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8631' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84732%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A864' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84741%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8641' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84741%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A865' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84742%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8651' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84742%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A866' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84751%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8661' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84751%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A867' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84752%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8671' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84752%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A868' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84761%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8681' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84761%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A869' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84762%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8691' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84762%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A870' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84771%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8701' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84771%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A871' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84772%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8711' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '84772%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A872' as naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '85412%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8721' As Naziv, cast(round(ISNull(Sum(potrazuje - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '85412%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A874' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51212%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8741' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51212%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A875' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '51213%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8751' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51213%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A876' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51322%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8761' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51322%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A877' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8771' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A878' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51332%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8781' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '51332%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A879' As Naziv,cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51333%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8791' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51333%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A880' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51342%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8801' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51342%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A881' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51343%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8811' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51343%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A882' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51411%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8821' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51411%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A883' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51412%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8831' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51412%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A884' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51413%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8841' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51413%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A885' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51532%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8851' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51532%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A886' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51533%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8861' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51533%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A887' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '51542%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8871' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51542%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A888' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51543%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8881' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51543%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A889' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51552%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8891' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51552%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A890' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51553%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8901' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51553%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A891' As Naziv,cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51631%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8911' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51631%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A892' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51632%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8921' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51632%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A893' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51633%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8931' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51633%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A894' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51641%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8941' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51641%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A895' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51642%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8951' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51642%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A896' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51643%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8961' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51643%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A897' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8971' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A898' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8981' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A899' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51721%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A8991' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51721%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A900' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51722%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9001' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51722%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A901' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51723%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9011' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51723%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A902' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51731%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9021' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51731%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A903' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51732%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9031' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '51732%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A904' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51733%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9041' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '51733%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A905' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51741%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9051' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51741%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A906' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51742%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9061' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51742%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A907' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51743%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9071' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '51743%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A908' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51751%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9081' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51751%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A909' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51752%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9091' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51752%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A910' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51753%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9101' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51753%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A911' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51761%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9111' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51761%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A912' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51762%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9121' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51762%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A913' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51763%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9131' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51763%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A914' As Naziv,cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51771%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9141' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51771%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A915' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '51772%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9151' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51772%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1
  
		Union

		Select 'A916' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51773%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9161' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '51773%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A917' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54132%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9171' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54132%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A918' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54142%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9181' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54142%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A919' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54152%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9191' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54152%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A920' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54162%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9201' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54162%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A921' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54221%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9211' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '54221%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A922' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54222%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9221' As Naziv,cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54222%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A923' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54223%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9231' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54223%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A924' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54232%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9241' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54232%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A925' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54242%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9251' As Naziv,cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54242%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A926' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54243%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9261' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54243%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A927' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54312%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9271' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54312%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A928' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54431%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9281' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54431%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A929' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54432%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9291' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54432%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A930' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54433%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9301' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54433%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A931' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54442%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9311' As Naziv,cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54442%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A932' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54452%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9321' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54452%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A933' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9331' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A934' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54461%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9341' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54461%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A935' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54462%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9351' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54462%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A936' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54463%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9361' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54463%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A937' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54472%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9371' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54472%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A938' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54482%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9381' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54482%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A939' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54483%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9391' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54483%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A940' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54532%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9401' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54532%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A941' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54542%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9411' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54542%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A942' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54552%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9421' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54552%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A943' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54711%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9431' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54711%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A944' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54712%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9441' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54712%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A945' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54721%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9451' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54721%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A946' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54722%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9461' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54722%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A947' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54731%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9471' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54731%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A948' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54732%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9481' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54732%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A949' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54741%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9491' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54741%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A950' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54742%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9501' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54742%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A951' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54751%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9511' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54751%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A952' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54752%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9521' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54752%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A953' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54761%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9531' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54761%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A954' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54762%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9541' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54762%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A955' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54771%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9551' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54771%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A956' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '54772%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9561' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '54772%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A957' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '55312%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9571' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '55312%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A959' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9591' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13213%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A960' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9601' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13323%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A961' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13333%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9611' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13333%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A962' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13343%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9621' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13343%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A963' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13413%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9631' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13413%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A964' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13533%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9641' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13533%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A965' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13543%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9651' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13543%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A966' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13553%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9661' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13553%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A967' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13633%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9671' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13633%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A968' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13643%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9681' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13643%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A969' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '13723%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9691' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13723%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A970' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13733%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9701' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13733%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A971' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13743%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9711' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13743%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A972' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13753%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9721' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '1353%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A973' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13763%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9731' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13763%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A974' As Naziv, cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13773%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9741' As Naziv, 	cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '13773%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A975' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '23951%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9751' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '23951%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A976' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26223%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9761' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26223%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A977' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26224%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9771' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26224%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A978' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26233%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9781' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26233%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A979' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26243%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9791' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26243%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A980' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26244%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9801' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26244%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A981' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26314%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9811' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26314%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A982' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26433%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9821' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26433%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A983' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA  
		Where GKSTAVKA.IDKONTO Like '26434%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9831' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26434%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A984' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26443%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9841' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26443%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A985' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9851' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26453%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A986' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26454%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9861' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26454%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A987' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26463%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9871' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26463%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A988' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26464%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9881' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26464%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A989' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26473%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9891' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26473%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A990' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26483%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9901' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26483%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A991' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26484%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9911' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26484%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A992' As Naziv,	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26534%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9921' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26534%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A993' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26544%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9931' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26544%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A994' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26554%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9941' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26554%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A995' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26564%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A9951' As Naziv, 	cast(round(ISNull(Sum(POTRAZUJE - duguje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '26564%' And GKSTAVKA.DATUMDOKUMENTA  >= @datumod   And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1
			
				Union

		Select 'A598' As Naziv, 	cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '5443%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.DATUMDOKUMENTA  <= @datumdo AND GKGODIDGODINE = @GODINA and statusgk = 1

		Union

		Select 'A5981' As Naziv, 	cast(round(ISNull(Sum(duguje - potrazuje), 0),0)as int) As Iznos From GKSTAVKA 
		Where GKSTAVKA.IDKONTO Like '5443%'  And GKSTAVKA.DATUMDOKUMENTA  >= @datumod  And GKSTAVKA.BROJDOKUMENTA = 1  AND GKSTAVKA.IDDOKUMENT = 1 AND GKGODIDGODINE = @GODINA and statusgk = 1
    End
RETURN


