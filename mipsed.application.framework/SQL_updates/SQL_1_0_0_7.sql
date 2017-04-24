Begin
Alter Table MT_SkladisteStavke Alter Column Kolicina decimal (16,4)
Alter Table MT_SkladisteStavke Alter Column Stanje decimal (16,4)
Alter Table MT_SkladisteStavke Alter Column Saldo decimal (16,4)
Alter Table MT_IzdatnicaStavka Alter Column NabavnaCijena decimal(16,4)
Alter Table MT_MeduskladisnicaStavka Alter Column IzlaznaCijena decimal(16,4)
Alter Table MT_MeduskladisnicaStavka Alter Column UlaznaCijena decimal(16,4)
End
GO