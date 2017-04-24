namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Hlp;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;

    public class RACUNDataAdapter : IDataAdapter, IRACUNDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove55;
        private ReadWriteCommand cmRACUNRacunStavkeSelect2;
        private ReadWriteCommand cmRACUNSelect1;
        private ReadWriteCommand cmRACUNSelect2;
        private ReadWriteCommand cmRACUNSelect3;
        private ReadWriteCommand cmRACUNSelect4;
        private ReadWriteCommand cmRACUNSelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__CIJENARACUNOriginal;
        private object m__DATUMOriginal;
        private bool m__FINPOREZIDPOREZIsNull;
        private object m__FINPOREZSTOPARACUNOriginal;

        private object m__CijenaPDVOriginal;

        private object m__IDPARTNEROriginal;
        private object m__IDPROIZVODOriginal;
        private decimal m__IZNOSMINUSRABATPrevious;
        private object m__KOLICINAOriginal;
        private int m__MaxBROJSTAVKE;
        private object m__MODELOriginal;
        private object m__NAPOMENAOriginal;
        private object m__NAZIVPROIZVODRACUNOriginal;
        private decimal m__PDVPrevious;
        private object m__POZIVOriginal;
        private object m__RABATOriginal;
        private object m__RAZDOBLJEDOOriginal;
        private object m__RAZDOBLJEODOriginal;
        private string m__SLOVIMAPrevious;
        private decimal m__SVEUKUPNOPrevious;
        private decimal m__UKUPNOOSNOVICAPrevious;
        private decimal m__UKUPNOPDVPrevious;
        private object m__VALUTAOriginal;
        private object m__ZAPREDUJAMOriginal;

        private object m__VrstaOriginal;
        private object m__UkupanIznosOriginal;

        private int m_FINPOREZIDPOREZ;
        private decimal m_IZNOSMINUSRABAT;
        private decimal m_IZNOSPLUSPDV;
        private decimal m_IZNOSRABATA;
        private decimal m_IZNOSRACUN;
        private decimal m_PDV;
        private readonly string m_SelectString211 = "TM1.[IDRACUN], TM1.[ZAPREDUJAM], T2.[NAZIVPARTNER], T2.[MB], T2.[PARTNERMJESTO], T2.[PARTNERULICA], T2.[PARTNEREMAIL], TM1.[DATUM], TM1.[VALUTA], TM1.[RAZDOBLJEOD], TM1.[RAZDOBLJEDO], TM1.[MODEL], TM1.[POZIV], TM1.[NAPOMENA], T2.[PARTNEROIB], TM1.[IDPARTNER], TM1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE, TM1.[Vrsta], TM1.[UkupanIznos]";
        private string m_SubSelTopString212;
        private decimal m_SVEUKUPNO;
        private decimal m_UkupanIznos;
        private decimal m_UKUPNOOSNOVICA;
        private decimal m_UKUPNOPDV;
        private decimal m_CijenaPDV;
        private string m_WhereString;
        private IDataReader RACUNRacunStavkeSelect2;
        private IDataReader RACUNSelect1;
        private IDataReader RACUNSelect2;
        private IDataReader RACUNSelect3;
        private IDataReader RACUNSelect4;
        private IDataReader RACUNSelect7;
        private RACUNDataSet RACUNSet;
        private short RcdFound211;
        private short RcdFound212;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RACUNDataSet.RACUNRow rowRACUN;
        private RACUNDataSet.RACUNRacunStavkeRow rowRACUNRacunStavke;
        private string scmdbuf;
        private StatementType sMode211;
        private StatementType sMode212;

        public event RACUNRacunStavkeUpdateEventHandler RACUNRacunStavkeUpdated;

        public event RACUNRacunStavkeUpdateEventHandler RACUNRacunStavkeUpdating;

        public event RACUNUpdateEventHandler RACUNUpdated;

        public event RACUNUpdateEventHandler RACUNUpdating;

        private void AddRowRacun()
        {
            this.RACUNSet.RACUN.AddRACUNRow(this.rowRACUN);
        }

        private void AddRowRacunracunstavke()
        {
            this.RACUNSet.RACUNRacunStavke.AddRACUNRacunStavkeRow(this.rowRACUNRacunStavke);
        }

        private void AfterConfirmRacun()
        {
            this.OnRACUNUpdating(new RACUNEventArgs(this.rowRACUN, this.Gx_mode));
        }

        private void AfterConfirmRacunracunstavke()
        {
            if (this.rowRACUNRacunStavke.BROJSTAVKE < 0)
            {
                this.m__MaxBROJSTAVKE = 0;
                foreach (RACUNDataSet.RACUNRacunStavkeRow row in this.rowRACUN.GetRACUNRacunStavkeRows())
                {
                    if (row.BROJSTAVKE > this.m__MaxBROJSTAVKE)
                    {
                        this.m__MaxBROJSTAVKE = row.BROJSTAVKE;
                    }
                }
                this.rowRACUNRacunStavke.BROJSTAVKE = this.m__MaxBROJSTAVKE + 1;
            }
            this.OnRACUNRacunStavkeUpdating(new RACUNRacunStavkeEventArgs(this.rowRACUNRacunStavke, this.Gx_mode));
        }

        private void CheckExtendedTableRacun()
        {
            this.rowRACUN.BROJRACUNA = NumberUtil.ToString((long) this.rowRACUN.RACUNGODINAIDGODINE, "") + "-" + DB.BrojVodeceNule(NumberUtil.ToString((long) this.rowRACUN.IDRACUN, ""), 5, 0, false, "");
            this.GetUKUPNOOSNOVICA(this.rowRACUN.IDRACUN, this.rowRACUN.RACUNGODINAIDGODINE);
            this.m__UKUPNOOSNOVICAPrevious = this.m_UKUPNOOSNOVICA;
            this.m__UKUPNOPDVPrevious = this.m_UKUPNOPDV;
            this.m_SVEUKUPNO = decimal.Add(this.m_UKUPNOOSNOVICA, this.m_UKUPNOPDV);
            this.rowRACUN.SLOVIMA = Razno.Cash2Text(Convert.ToDouble(this.m_SVEUKUPNO));
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPARTNER], [MB], [PARTNERMJESTO], [PARTNERULICA], [PARTNEREMAIL], [PARTNEROIB] FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new PARTNERForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PARTNER") }));
            }
            this.rowRACUN["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
            this.rowRACUN["MB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowRACUN["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
            this.rowRACUN["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
            this.rowRACUN["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
            this.rowRACUN["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            reader.Close();
        }

        private void CheckExtendedTableRacunracunstavke()
        {
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [FINPOREZIDPOREZ], [NAZIVPROIZVOD], [CIJENA], [IDJEDINICAMJERE] FROM [PROIZVOD] WITH (NOLOCK) WHERE [IDPROIZVOD] = @IDPROIZVOD ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDPROIZVOD"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new PROIZVODForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PROIZVOD") }));
            }
            this.m_FINPOREZIDPOREZ = this.dsDefault.Db.GetInt32(reader3, 0, ref this.m__FINPOREZIDPOREZIsNull);
            this.rowRACUNRacunStavke["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 1));
            this.rowRACUNRacunStavke["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader3, 2));
            this.rowRACUNRacunStavke["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader3, 3));
            reader3.Close();
            if (!this.m__FINPOREZIDPOREZIsNull)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [FINPOREZSTOPA], [OSNOVICAUKNIZIIRA] FROM [FINPOREZ] WITH (NOLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, this.m_FINPOREZIDPOREZ);
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new FINPOREZForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("FINPOREZ") }));
                }
                this.rowRACUNRacunStavke["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0));
                this.rowRACUNRacunStavke["OSNOVICAUKNIZIIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                reader.Close();
            }
            else
            {
                this.rowRACUNRacunStavke["FINPOREZSTOPA"] = 0;
                this.rowRACUNRacunStavke["OSNOVICAUKNIZIIRA"] = 0;
            }
            if (!this.rowRACUNRacunStavke.IsIDJEDINICAMJERENull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVJEDINICAMJERE] FROM [JEDINICAMJERE] WITH (NOLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDJEDINICAMJERE"]));
                IDataReader reader2 = command2.FetchData();
                if (!command2.HasMoreRows)
                {
                    reader2.Close();
                    throw new JEDINICAMJEREForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("JEDINICAMJERE") }));
                }
                this.rowRACUNRacunStavke["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                reader2.Close();
            }
            else
            {
                this.rowRACUNRacunStavke["NAZIVJEDINICAMJERE"] = "";
            }
            this.rowRACUNRacunStavke.IZNOSRACUN = DB.RoundUP(decimal.Multiply(this.rowRACUNRacunStavke.CIJENARACUN, this.rowRACUNRacunStavke.KOLICINA));
            if (!this.rowRACUNRacunStavke.IsIZNOSRACUNNull())
            {
                this.rowRACUNRacunStavke.IZNOSRABATA = DB.RoundUP(decimal.Divide(decimal.Multiply(this.rowRACUNRacunStavke.IZNOSRACUN, this.rowRACUNRacunStavke.RABAT), 100M));
            }
            if (!this.rowRACUNRacunStavke.IsIZNOSRACUNNull() && !this.rowRACUNRacunStavke.IsIZNOSRABATANull())
            {
                this.m_IZNOSMINUSRABAT = decimal.Subtract(this.rowRACUNRacunStavke.IZNOSRACUN, this.rowRACUNRacunStavke.IZNOSRABATA);
            }
            this.rowRACUNRacunStavke.PDV = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSMINUSRABAT, this.rowRACUNRacunStavke.FINPOREZSTOPARACUN), 100M));
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_UKUPNOPDV = decimal.Add(this.m__UKUPNOPDVPrevious, this.rowRACUNRacunStavke.PDV);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_UKUPNOPDV = decimal.Subtract(decimal.Add(this.m__UKUPNOPDVPrevious, this.rowRACUNRacunStavke.PDV), this.m__PDVPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_UKUPNOPDV = decimal.Subtract(this.m__UKUPNOPDVPrevious, this.m__PDVPrevious);
            }
            if (!this.rowRACUNRacunStavke.IsPDVNull())
            {
                this.m_IZNOSPLUSPDV = decimal.Add(this.m_IZNOSMINUSRABAT, this.rowRACUNRacunStavke.PDV);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_UKUPNOOSNOVICA = decimal.Add(this.m__UKUPNOOSNOVICAPrevious, this.m_IZNOSMINUSRABAT);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_UKUPNOOSNOVICA = decimal.Subtract(decimal.Add(this.m__UKUPNOOSNOVICAPrevious, this.m_IZNOSMINUSRABAT), this.m__IZNOSMINUSRABATPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_UKUPNOOSNOVICA = decimal.Subtract(this.m__UKUPNOOSNOVICAPrevious, this.m__IZNOSMINUSRABATPrevious);
            }
            this.m_SVEUKUPNO = decimal.Add(this.m_UKUPNOOSNOVICA, this.m_UKUPNOPDV);
            this.rowRACUN.SLOVIMA = Razno.Cash2Text(Convert.ToDouble(this.m_SVEUKUPNO));
        }

        private void CheckIntegrityErrorsRacun()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGODINE] AS RACUNGODINAIDGODINE FROM [GODINE] WITH (NOLOCK) WHERE [IDGODINE] = @RACUNGODINAIDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new GODINEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyRacun()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRACUN], [ZAPREDUJAM], [DATUM], [VALUTA], [RAZDOBLJEOD], [RAZDOBLJEDO], [MODEL], [POZIV], [NAPOMENA], [IDPARTNER], [RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE FROM [RACUN] WITH (UPDLOCK) WHERE [IDRACUN] = @IDRACUN AND [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RACUNDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RACUN") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__ZAPREDUJAMOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1)))) || ((!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2))) || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__VALUTAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 3)))) || (!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__RAZDOBLJEODOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 4))) || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__RAZDOBLJEDOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MODELOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POZIVOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAPOMENAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8)))) || !this.m__IDPARTNEROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 9)))))
                {
                    reader.Close();
                    throw new RACUNDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RACUN") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRacunracunstavke()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRACUN], [RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE, [BROJSTAVKE], [RABAT], [KOLICINA], [NAZIVPROIZVODRACUN], [CIJENARACUN], [FINPOREZSTOPARACUN], [IDPROIZVOD], [CijenaPDV] FROM [RACUNRacunStavke] WITH (UPDLOCK) WHERE [IDRACUN] = @IDRACUN AND [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE AND [BROJSTAVKE] = @BROJSTAVKE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDRACUN"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RACUNGODINAIDGODINE"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["BROJSTAVKE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RACUNRacunStavkeDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RACUNRacunStavke") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__RABATOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3)))) || ((!this.m__KOLICINAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVPROIZVODRACUNOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5)))) || (!this.m__CIJENARACUNOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))) || !this.m__FINPOREZSTOPARACUNOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !this.m__IDPROIZVODOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 8))))
                {
                    reader.Close();
                    throw new RACUNRacunStavkeDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RACUNRacunStavke") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRacun()
        {
            this.rowRACUN = this.RACUNSet.RACUN.NewRACUNRow();
        }

        private void CreateNewRowRacunracunstavke()
        {
            this.rowRACUNRacunStavke = this.RACUNSet.RACUNRacunStavke.NewRACUNRacunStavkeRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRacun();
            this.OnDeleteControlsRacun();
            this.ProcessNestedLevelRacunracunstavke();
            this.AfterConfirmRacun();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RACUN]  WHERE [IDRACUN] = @IDRACUN AND [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
            command.ExecuteStmt();
            this.OnRACUNUpdated(new RACUNEventArgs(this.rowRACUN, StatementType.Delete));
            this.rowRACUN.Delete();
            this.sMode211 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode211;
        }

        private void DeleteRacunracunstavke()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRacunracunstavke();
            this.OnDeleteControlsRacunracunstavke();
            this.AfterConfirmRacunracunstavke();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RACUNRacunStavke]  WHERE [IDRACUN] = @IDRACUN AND [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE AND [BROJSTAVKE] = @BROJSTAVKE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RACUNGODINAIDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["BROJSTAVKE"]));
            command.ExecuteStmt();
            this.OnRACUNRacunStavkeUpdated(new RACUNRacunStavkeEventArgs(this.rowRACUNRacunStavke, StatementType.Delete));
            this.rowRACUNRacunStavke.Delete();
            this.sMode212 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode212;
        }

        public virtual int Fill(RACUNDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), short.Parse(this.fillDataParameters[1].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.RACUNSet = dataSet;
                    this.LoadChildRacun(0, -1);
                    dataSet.AcceptChanges();
                }
                finally
                {
                    this.Cleanup();
                }
            }
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.RACUNSet = (RACUNDataSet) dataSet;
            if (this.RACUNSet != null)
            {
                return this.Fill(this.RACUNSet);
            }
            this.RACUNSet = new RACUNDataSet();
            this.Fill(this.RACUNSet);
            dataSet.Merge(this.RACUNSet);
            return 0;
        }

        public virtual int Fill(RACUNDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRACUN"]), Conversions.ToShort(dataRecord["RACUNGODINAIDGODINE"]));
        }

        public virtual int Fill(RACUNDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRACUN"]), Conversions.ToShort(dataRecord["RACUNGODINAIDGODINE"]));
        }

        public virtual int Fill(RACUNDataSet dataSet, int iDRACUN, short rACUNGODINAIDGODINE)
        {
            if (!this.FillByIDRACUNRACUNGODINAIDGODINE(dataSet, iDRACUN, rACUNGODINAIDGODINE))
            {
                throw new RACUNNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RACUN") }));
            }
            return 0;
        }

        public virtual int FillByIDPARTNER(RACUNDataSet dataSet, int iDPARTNER)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RACUNSet = dataSet;
            this.rowRACUN = this.RACUNSet.RACUN.NewRACUNRow();
            this.rowRACUN.IDPARTNER = iDPARTNER;
            try
            {
                this.LoadByIDPARTNER(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDRACUN(RACUNDataSet dataSet, int iDRACUN)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RACUNSet = dataSet;
            this.rowRACUN = this.RACUNSet.RACUN.NewRACUNRow();
            this.rowRACUN.IDRACUN = iDRACUN;
            try
            {
                this.LoadByIDRACUN(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDRACUNRACUNGODINAIDGODINE(RACUNDataSet dataSet, int iDRACUN, short rACUNGODINAIDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RACUNSet = dataSet;
            this.rowRACUN = this.RACUNSet.RACUN.NewRACUNRow();
            this.rowRACUN.IDRACUN = iDRACUN;
            this.rowRACUN.RACUNGODINAIDGODINE = rACUNGODINAIDGODINE;
            try
            {
                this.LoadByIDRACUNRACUNGODINAIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound211 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByRACUNGODINAIDGODINE(RACUNDataSet dataSet, short rACUNGODINAIDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RACUNSet = dataSet;
            this.rowRACUN = this.RACUNSet.RACUN.NewRACUNRow();
            this.rowRACUN.RACUNGODINAIDGODINE = rACUNGODINAIDGODINE;
            try
            {
                this.LoadByRACUNGODINAIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(RACUNDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RACUNSet = dataSet;
            try
            {
                this.LoadChildRacun(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDPARTNER(RACUNDataSet dataSet, int iDPARTNER, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RACUNSet = dataSet;
            this.rowRACUN = this.RACUNSet.RACUN.NewRACUNRow();
            this.rowRACUN.IDPARTNER = iDPARTNER;
            try
            {
                this.LoadByIDPARTNER(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDRACUN(RACUNDataSet dataSet, int iDRACUN, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RACUNSet = dataSet;
            this.rowRACUN = this.RACUNSet.RACUN.NewRACUNRow();
            this.rowRACUN.IDRACUN = iDRACUN;
            try
            {
                this.LoadByIDRACUN(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByRACUNGODINAIDGODINE(RACUNDataSet dataSet, short rACUNGODINAIDGODINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RACUNSet = dataSet;
            this.rowRACUN = this.RACUNSet.RACUN.NewRACUNRow();
            this.rowRACUN.RACUNGODINAIDGODINE = rACUNGODINAIDGODINE;
            try
            {
                this.LoadByRACUNGODINAIDGODINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            DataTable[] array = new DataTable[dataSet.Tables.Count + 1];
            dataSet.Tables.CopyTo(array, dataSet.Tables.Count);
            return array;
        }

        private void GetByPrimaryKey()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRACUN], [ZAPREDUJAM], [DATUM], [VALUTA], [RAZDOBLJEOD], [RAZDOBLJEDO], [MODEL], [POZIV], [NAPOMENA], [IDPARTNER], [RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE FROM [RACUN] WITH (NOLOCK) WHERE [IDRACUN] = @IDRACUN AND [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound211 = 1;
                this.rowRACUN["IDRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRACUN["ZAPREDUJAM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1));
                this.rowRACUN["DATUM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2));
                this.rowRACUN["VALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 3));
                this.rowRACUN["RAZDOBLJEOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 4));
                this.rowRACUN["RAZDOBLJEDO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 5));
                this.rowRACUN["MODEL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowRACUN["POZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowRACUN["NAPOMENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowRACUN["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 9));
                this.rowRACUN["RACUNGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 10));
                this.sMode211 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadRacun();
                this.Gx_mode = this.sMode211;
            }
            else
            {
                this.RcdFound211 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "IDRACUN";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "RACUNGODINAIDGODINE";
                parameter2.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNSelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RACUN] WITH (NOLOCK) ", false);
            this.RACUNSelect4 = this.cmRACUNSelect4.FetchData();
            if (this.RACUNSelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RACUNSelect4.GetInt32(0);
            }
            this.RACUNSelect4.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDPARTNER(int iDPARTNER)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RACUN] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
            if (this.cmRACUNSelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmRACUNSelect3.SetParameter(0, iDPARTNER);
            this.RACUNSelect3 = this.cmRACUNSelect3.FetchData();
            if (this.RACUNSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RACUNSelect3.GetInt32(0);
            }
            this.RACUNSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDRACUN(int iDRACUN)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RACUN] WITH (NOLOCK) WHERE [IDRACUN] = @IDRACUN ", false);
            if (this.cmRACUNSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
            }
            this.cmRACUNSelect1.SetParameter(0, iDRACUN);
            this.RACUNSelect1 = this.cmRACUNSelect1.FetchData();
            if (this.RACUNSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RACUNSelect1.GetInt32(0);
            }
            this.RACUNSelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByRACUNGODINAIDGODINE(short rACUNGODINAIDGODINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRACUNSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RACUN] WITH (NOLOCK) WHERE [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE ", false);
            if (this.cmRACUNSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            this.cmRACUNSelect2.SetParameter(0, rACUNGODINAIDGODINE);
            this.RACUNSelect2 = this.cmRACUNSelect2.FetchData();
            if (this.RACUNSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RACUNSelect2.GetInt32(0);
            }
            this.RACUNSelect2.Close();
            return this.recordCount;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                this.InitializeMembers();
                internalRecordCount = this.GetInternalRecordCount();
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        public virtual int GetRecordCountByIDPARTNER(int iDPARTNER)
        {
            int internalRecordCountByIDPARTNER;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDPARTNER = this.GetInternalRecordCountByIDPARTNER(iDPARTNER);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDPARTNER;
        }

        public virtual int GetRecordCountByIDRACUN(int iDRACUN)
        {
            int internalRecordCountByIDRACUN;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDRACUN = this.GetInternalRecordCountByIDRACUN(iDRACUN);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDRACUN;
        }

        public virtual int GetRecordCountByRACUNGODINAIDGODINE(short rACUNGODINAIDGODINE)
        {
            int internalRecordCountByRACUNGODINAIDGODINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByRACUNGODINAIDGODINE = this.GetInternalRecordCountByRACUNGODINAIDGODINE(rACUNGODINAIDGODINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByRACUNGODINAIDGODINE;
        }

        private void GetUKUPNOOSNOVICA(int IDRACUN, short RACUNGODINAIDGODINE)
        {
            this.m_UKUPNOOSNOVICA = new decimal();
            this.m_UKUPNOPDV = new decimal();
            this.m_CijenaPDV = new decimal();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRACUN], [RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE, [BROJSTAVKE], [FINPOREZSTOPARACUN], [RABAT], [KOLICINA], [CIJENARACUN], [CijenaPDV] FROM [RACUNRacunStavke] WITH (NOLOCK) WHERE [IDRACUN] = @IDRACUN AND [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE ORDER BY [IDRACUN], [RACUNGODINAIDGODINE] ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            command.SetParameter(0, IDRACUN);
            command.SetParameter(1, RACUNGODINAIDGODINE);
            IDataReader reader = command.FetchData();
            while ((command.HasMoreRows && (reader.GetInt32(0) == IDRACUN)) && (reader.GetInt16(1) == RACUNGODINAIDGODINE))
            {
                this.m_IZNOSRACUN = DB.RoundUP(decimal.Multiply(reader.GetDecimal(6), reader.GetDecimal(5)));
                this.m_IZNOSRABATA = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSRACUN, reader.GetDecimal(4)), 100M));
                this.m_IZNOSMINUSRABAT = decimal.Subtract(this.m_IZNOSRACUN, this.m_IZNOSRABATA);
                this.m_PDV = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSMINUSRABAT, reader.GetDecimal(3)), 100M));
                this.m_UKUPNOOSNOVICA = decimal.Add(this.m_UKUPNOOSNOVICA, this.m_IZNOSMINUSRABAT);
                this.m_UKUPNOPDV = decimal.Add(this.m_UKUPNOPDV, this.m_PDV);
                this.m_CijenaPDV = decimal.Add(m_CijenaPDV, reader.GetDecimal(7));
                command.HasMoreRows = reader.Read();
            }
            reader.Close();
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound211 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_UKUPNOOSNOVICA = new decimal();
            this.m_UKUPNOPDV = new decimal();
            this.m_SVEUKUPNO = new decimal();
            this.m_CijenaPDV = new decimal();
            m_UkupanIznos = new decimal();
            this.m_IZNOSMINUSRABAT = new decimal();
            this.m_IZNOSPLUSPDV = new decimal();
            this.m__PDVPrevious = new decimal();
            this.m__IZNOSMINUSRABATPrevious = new decimal();
            this.m__RABATOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KOLICINAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAZIVPROIZVODRACUNOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__CIJENARACUNOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__FINPOREZSTOPARACUNOriginal = RuntimeHelpers.GetObjectValue(new object());
            m__UkupanIznosOriginal = RuntimeHelpers.GetObjectValue(new object());
            m__VrstaOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__CijenaPDVOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__IDPROIZVODOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove55 = false;
            this.m__UKUPNOPDVPrevious = new decimal();
            this.m__FINPOREZIDPOREZIsNull = false;
            this.m_FINPOREZIDPOREZ = 0;
            this.m__UKUPNOOSNOVICAPrevious = new decimal();
            this._Condition = false;
            this.RcdFound212 = 0;
            this.m_SubSelTopString212 = "";
            this.m__MaxBROJSTAVKE = 0;
            this.m__ZAPREDUJAMOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VALUTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RAZDOBLJEODOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RAZDOBLJEDOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MODELOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POZIVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAPOMENAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDPARTNEROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SLOVIMAPrevious = "";
            this.m__SVEUKUPNOPrevious = new decimal();
            this.m_WhereString = "";
            this.m_IZNOSRACUN = new decimal();
            this.m_IZNOSRABATA = new decimal();
            this.m_PDV = new decimal();
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RACUNSet = new RACUNDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRacun()
        {
            this.CheckOptimisticConcurrencyRacun();
            this.CheckExtendedTableRacun();
            this.AfterConfirmRacun();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RACUN] ([IDRACUN], [ZAPREDUJAM], [DATUM], [VALUTA], [RAZDOBLJEOD], [RAZDOBLJEDO], [MODEL], [POZIV], [NAPOMENA], [IDPARTNER], [RACUNGODINAIDGODINE], [Vrsta], [UkupanIznos]) VALUES (@IDRACUN, @ZAPREDUJAM, @DATUM, @VALUTA, @RAZDOBLJEOD, @RAZDOBLJEDO, @MODEL, @POZIV, @NAPOMENA, @IDPARTNER, @RACUNGODINAIDGODINE, @Vrsta, @UkupanIznos)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAPREDUJAM", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUM", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VALUTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODEL", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POZIV", DbType.String, 22));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAPOMENA", DbType.String, 200));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Vrsta", DbType.String, 3));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UkupanIznos", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUN["ZAPREDUJAM"]));
            command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowRACUN["DATUM"]));
            command.SetParameterDateObject(3, RuntimeHelpers.GetObjectValue(this.rowRACUN["VALUTA"]));
            command.SetParameterDateObject(4, RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEOD"]));
            command.SetParameterDateObject(5, RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEDO"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRACUN["MODEL"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRACUN["POZIV"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRACUN["NAPOMENA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRACUN["Vrsta"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRACUN["UkupanIznos"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RACUNDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRacun();
            }
            this.OnRACUNUpdated(new RACUNEventArgs(this.rowRACUN, StatementType.Insert));
            this.ProcessLevelRacun();
        }

        private void InsertRacunracunstavke()
        {
            this.CheckOptimisticConcurrencyRacunracunstavke();
            this.CheckExtendedTableRacunracunstavke();
            this.AfterConfirmRacunracunstavke();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RACUNRacunStavke] ([IDRACUN], [RACUNGODINAIDGODINE], [BROJSTAVKE], [RABAT], [KOLICINA], [NAZIVPROIZVODRACUN], [CIJENARACUN], [FINPOREZSTOPARACUN], [IDPROIZVOD], [CijenaPDV]) VALUES (@IDRACUN, @RACUNGODINAIDGODINE, @BROJSTAVKE, @RABAT, @KOLICINA, @NAZIVPROIZVODRACUN, @CIJENARACUN, @FINPOREZSTOPARACUN, @IDPROIZVOD, @CijenaPDV)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RABAT", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLICINA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPROIZVODRACUN", DbType.String, 500));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CIJENARACUN", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZSTOPARACUN", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CijenaPDV", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDRACUN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RACUNGODINAIDGODINE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["BROJSTAVKE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RABAT"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["KOLICINA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["NAZIVPROIZVODRACUN"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["CIJENARACUN"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["FINPOREZSTOPARACUN"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDPROIZVOD"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(GetCijenaPDV(rowRACUNRacunStavke["CIJENARACUN"], this.rowRACUNRacunStavke["FINPOREZSTOPARACUN"], this.rowRACUNRacunStavke["RABAT"], this.rowRACUNRacunStavke["KOLICINA"])));

            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RACUNRacunStavkeDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRACUNRacunStavkeUpdated(new RACUNRacunStavkeEventArgs(this.rowRACUNRacunStavke, StatementType.Insert));
        }

        private object GetCijenaPDV(object cijena, object pdv, object rabat, object kolicina)
        {
            decimal cijenaRabat = Convert.ToDecimal(cijena) - (Convert.ToDecimal(cijena) * Convert.ToDecimal(rabat) / 100);

            return Math.Round((cijenaRabat + (cijenaRabat * Convert.ToDecimal(pdv) / 100)) * Convert.ToDecimal(kolicina), 2, MidpointRounding.AwayFromZero);
        }

        private void LoadByIDPARTNER(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RACUNSet.EnforceConstraints;
            this.RACUNSet.RACUNRacunStavke.BeginLoadData();
            this.RACUNSet.RACUN.BeginLoadData();
            this.ScanByIDPARTNER(startRow, maxRows);
            this.RACUNSet.RACUNRacunStavke.EndLoadData();
            this.RACUNSet.RACUN.EndLoadData();
            this.RACUNSet.EnforceConstraints = enforceConstraints;
            if (this.RACUNSet.RACUN.Count > 0)
            {
                this.rowRACUN = this.RACUNSet.RACUN[this.RACUNSet.RACUN.Count - 1];
            }
        }

        private void LoadByIDRACUN(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RACUNSet.EnforceConstraints;
            this.RACUNSet.RACUNRacunStavke.BeginLoadData();
            this.RACUNSet.RACUN.BeginLoadData();
            this.ScanByIDRACUN(startRow, maxRows);
            this.RACUNSet.RACUNRacunStavke.EndLoadData();
            this.RACUNSet.RACUN.EndLoadData();
            this.RACUNSet.EnforceConstraints = enforceConstraints;
            if (this.RACUNSet.RACUN.Count > 0)
            {
                this.rowRACUN = this.RACUNSet.RACUN[this.RACUNSet.RACUN.Count - 1];
            }
        }

        private void LoadByIDRACUNRACUNGODINAIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RACUNSet.EnforceConstraints;
            this.RACUNSet.RACUNRacunStavke.BeginLoadData();
            this.RACUNSet.RACUN.BeginLoadData();
            this.ScanByIDRACUNRACUNGODINAIDGODINE(startRow, maxRows);
            this.RACUNSet.RACUNRacunStavke.EndLoadData();
            this.RACUNSet.RACUN.EndLoadData();
            this.RACUNSet.EnforceConstraints = enforceConstraints;
            if (this.RACUNSet.RACUN.Count > 0)
            {
                this.rowRACUN = this.RACUNSet.RACUN[this.RACUNSet.RACUN.Count - 1];
            }
        }

        private void LoadByRACUNGODINAIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RACUNSet.EnforceConstraints;
            this.RACUNSet.RACUNRacunStavke.BeginLoadData();
            this.RACUNSet.RACUN.BeginLoadData();
            this.ScanByRACUNGODINAIDGODINE(startRow, maxRows);
            this.RACUNSet.RACUNRacunStavke.EndLoadData();
            this.RACUNSet.RACUN.EndLoadData();
            this.RACUNSet.EnforceConstraints = enforceConstraints;
            if (this.RACUNSet.RACUN.Count > 0)
            {
                this.rowRACUN = this.RACUNSet.RACUN[this.RACUNSet.RACUN.Count - 1];
            }
        }

        private void LoadChildRacun(int startRow, int maxRows)
        {
            this.CreateNewRowRacun();
            bool enforceConstraints = this.RACUNSet.EnforceConstraints;
            this.RACUNSet.RACUNRacunStavke.BeginLoadData();
            this.RACUNSet.RACUN.BeginLoadData();
            this.ScanStartRacun(startRow, maxRows);
            this.RACUNSet.RACUNRacunStavke.EndLoadData();
            this.RACUNSet.RACUN.EndLoadData();
            this.RACUNSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildRacunracunstavke()
        {
            this.CreateNewRowRacunracunstavke();
            this.ScanStartRacunracunstavke();
        }

        private void LoadDataRacun(int maxRows)
        {
            int num = 0;
            if (this.RcdFound211 != 0)
            {
                this.ScanLoadRacun();
                while ((this.RcdFound211 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRacun();
                    this.CreateNewRowRacun();
                    this.ScanNextRacun();
                }
            }
            if (num > 0)
            {
                this.RcdFound211 = 1;
            }
            this.ScanEndRacun();
            if (this.RACUNSet.RACUN.Count > 0)
            {
                this.rowRACUN = this.RACUNSet.RACUN[this.RACUNSet.RACUN.Count - 1];
            }
        }

        private void LoadDataRacunracunstavke()
        {
            while (this.RcdFound212 != 0)
            {
                this.LoadRowRacunracunstavke();
                this.CreateNewRowRacunracunstavke();
                this.ScanNextRacunracunstavke();
            }
            this.ScanEndRacunracunstavke();
        }

        private void LoadRacun()
        {
            this.rowRACUN.BROJRACUNA = NumberUtil.ToString((long) this.rowRACUN.RACUNGODINAIDGODINE, "") + "-" + DB.BrojVodeceNule(NumberUtil.ToString((long) this.rowRACUN.IDRACUN, ""), 5, 0, false, "");
            this.GetUKUPNOOSNOVICA(this.rowRACUN.IDRACUN, this.rowRACUN.RACUNGODINAIDGODINE);
            this.m__UKUPNOOSNOVICAPrevious = this.m_UKUPNOOSNOVICA;
            this.m__UKUPNOPDVPrevious = this.m_UKUPNOPDV;
            this.m_SVEUKUPNO = decimal.Add(this.m_UKUPNOOSNOVICA, this.m_UKUPNOPDV);
            this.rowRACUN.SLOVIMA = Razno.Cash2Text(Convert.ToDouble(this.m_SVEUKUPNO));
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPARTNER], [MB], [PARTNERMJESTO], [PARTNERULICA], [PARTNEREMAIL], [PARTNEROIB] FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRACUN["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
                this.rowRACUN["MB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowRACUN["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowRACUN["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowRACUN["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowRACUN["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            }
            reader.Close();
        }

        private void LoadRowRacun()
        {
            this.OnLoadActionsRacun();
            this.AddRowRacun();
        }

        private void LoadRowRacunracunstavke()
        {
            this.OnLoadActionsRacunracunstavke();
            this.AddRowRacunracunstavke();
        }

        private void OnDeleteControlsRacun()
        {
            this.rowRACUN.BROJRACUNA = NumberUtil.ToString((long) this.rowRACUN.RACUNGODINAIDGODINE, "") + "-" + DB.BrojVodeceNule(NumberUtil.ToString((long) this.rowRACUN.IDRACUN, ""), 5, 0, false, "");
            this.GetUKUPNOOSNOVICA(this.rowRACUN.IDRACUN, this.rowRACUN.RACUNGODINAIDGODINE);
            this.m_SVEUKUPNO = decimal.Add(this.m_UKUPNOOSNOVICA, this.m_UKUPNOPDV);
            this.rowRACUN.SLOVIMA = Razno.Cash2Text(Convert.ToDouble(this.m_SVEUKUPNO));
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPARTNER], [MB], [PARTNERMJESTO], [PARTNERULICA], [PARTNEREMAIL], [PARTNEROIB] FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRACUN["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
                this.rowRACUN["MB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowRACUN["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowRACUN["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowRACUN["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowRACUN["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
            }
            reader.Close();
        }

        private void OnDeleteControlsRacunracunstavke()
        {
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [FINPOREZIDPOREZ], [NAZIVPROIZVOD], [CIJENA], [IDJEDINICAMJERE] FROM [PROIZVOD] WITH (NOLOCK) WHERE [IDPROIZVOD] = @IDPROIZVOD ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDPROIZVOD"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                this.m_FINPOREZIDPOREZ = this.dsDefault.Db.GetInt32(reader3, 0, ref this.m__FINPOREZIDPOREZIsNull);
                this.rowRACUNRacunStavke["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 1));
                this.rowRACUNRacunStavke["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader3, 2));
                this.rowRACUNRacunStavke["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader3, 3));
            }
            reader3.Close();
            if (!this.m__FINPOREZIDPOREZIsNull)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [FINPOREZSTOPA], [OSNOVICAUKNIZIIRA] FROM [FINPOREZ] WITH (NOLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, this.m_FINPOREZIDPOREZ);
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowRACUNRacunStavke["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0));
                    this.rowRACUNRacunStavke["OSNOVICAUKNIZIIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                }
                reader.Close();
            }
            else
            {
                this.rowRACUNRacunStavke["FINPOREZSTOPA"] = 0;
                this.rowRACUNRacunStavke["OSNOVICAUKNIZIIRA"] = 0;
            }
            if (!this.rowRACUNRacunStavke.IsIDJEDINICAMJERENull())
            {
                ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVJEDINICAMJERE] FROM [JEDINICAMJERE] WITH (NOLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
                if (command2.IDbCommand.Parameters.Count == 0)
                {
                    command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
                }
                command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDJEDINICAMJERE"]));
                IDataReader reader2 = command2.FetchData();
                if (command2.HasMoreRows)
                {
                    this.rowRACUNRacunStavke["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
                }
                reader2.Close();
            }
            else
            {
                this.rowRACUNRacunStavke["NAZIVJEDINICAMJERE"] = "";
            }
            this.rowRACUNRacunStavke.IZNOSRACUN = DB.RoundUP(decimal.Multiply(this.rowRACUNRacunStavke.CIJENARACUN, this.rowRACUNRacunStavke.KOLICINA));
            if (!this.rowRACUNRacunStavke.IsIZNOSRACUNNull())
            {
                this.rowRACUNRacunStavke.IZNOSRABATA = DB.RoundUP(decimal.Divide(decimal.Multiply(this.rowRACUNRacunStavke.IZNOSRACUN, this.rowRACUNRacunStavke.RABAT), 100M));
            }
            if (!this.rowRACUNRacunStavke.IsIZNOSRACUNNull() && !this.rowRACUNRacunStavke.IsIZNOSRABATANull())
            {
                this.m_IZNOSMINUSRABAT = decimal.Subtract(this.rowRACUNRacunStavke.IZNOSRACUN, this.rowRACUNRacunStavke.IZNOSRABATA);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_UKUPNOOSNOVICA = decimal.Add(this.m__UKUPNOOSNOVICAPrevious, this.m_IZNOSMINUSRABAT);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_UKUPNOOSNOVICA = decimal.Subtract(decimal.Add(this.m__UKUPNOOSNOVICAPrevious, this.m_IZNOSMINUSRABAT), this.m__IZNOSMINUSRABATPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_UKUPNOOSNOVICA = decimal.Subtract(this.m__UKUPNOOSNOVICAPrevious, this.m__IZNOSMINUSRABATPrevious);
            }
            this.rowRACUNRacunStavke.PDV = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSMINUSRABAT, this.rowRACUNRacunStavke.FINPOREZSTOPARACUN), 100M));
            if (!this.rowRACUNRacunStavke.IsPDVNull())
            {
                this.m_IZNOSPLUSPDV = decimal.Add(this.m_IZNOSMINUSRABAT, this.rowRACUNRacunStavke.PDV);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_UKUPNOPDV = decimal.Add(this.m__UKUPNOPDVPrevious, this.rowRACUNRacunStavke.PDV);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_UKUPNOPDV = decimal.Subtract(decimal.Add(this.m__UKUPNOPDVPrevious, this.rowRACUNRacunStavke.PDV), this.m__PDVPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_UKUPNOPDV = decimal.Subtract(this.m__UKUPNOPDVPrevious, this.m__PDVPrevious);
            }
            this.m_SVEUKUPNO = decimal.Add(this.m_UKUPNOOSNOVICA, this.m_UKUPNOPDV);
            this.rowRACUN.SLOVIMA = Razno.Cash2Text(Convert.ToDouble(this.m_SVEUKUPNO));
        }

        private void OnLoadActionsRacun()
        {
            this.rowRACUN.BROJRACUNA = NumberUtil.ToString((long) this.rowRACUN.RACUNGODINAIDGODINE, "") + "-" + DB.BrojVodeceNule(NumberUtil.ToString((long) this.rowRACUN.IDRACUN, ""), 5, 0, false, "");
            this.GetUKUPNOOSNOVICA(this.rowRACUN.IDRACUN, this.rowRACUN.RACUNGODINAIDGODINE);
            this.m__UKUPNOOSNOVICAPrevious = this.m_UKUPNOOSNOVICA;
            this.m__UKUPNOPDVPrevious = this.m_UKUPNOPDV;
            //makuto i priukazuje finalnu cijenu
            //this.m_SVEUKUPNO = decimal.Add(this.m_UKUPNOOSNOVICA, this.m_UKUPNOPDV);
            this.m_SVEUKUPNO = m_CijenaPDV;

            this.rowRACUN.SLOVIMA = Razno.Cash2Text(Convert.ToDouble(this.m_SVEUKUPNO));
        }

        private void OnLoadActionsRacunracunstavke()
        {
            this.rowRACUNRacunStavke.IZNOSRACUN = DB.RoundUP(decimal.Multiply(this.rowRACUNRacunStavke.CIJENARACUN, this.rowRACUNRacunStavke.KOLICINA));
            if (!this.rowRACUNRacunStavke.IsIZNOSRACUNNull())
            {
                this.rowRACUNRacunStavke.IZNOSRABATA = DB.RoundUP(decimal.Divide(decimal.Multiply(this.rowRACUNRacunStavke.IZNOSRACUN, this.rowRACUNRacunStavke.RABAT), 100M));
            }
            if (!this.rowRACUNRacunStavke.IsIZNOSRACUNNull() && !this.rowRACUNRacunStavke.IsIZNOSRABATANull())
            {
                this.m_IZNOSMINUSRABAT = decimal.Subtract(this.rowRACUNRacunStavke.IZNOSRACUN, this.rowRACUNRacunStavke.IZNOSRABATA);
            }
            this.m__IZNOSMINUSRABATPrevious = this.m_IZNOSMINUSRABAT;
            this.rowRACUNRacunStavke.PDV = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSMINUSRABAT, this.rowRACUNRacunStavke.FINPOREZSTOPARACUN), 100M));
            this.m__PDVPrevious = this.rowRACUNRacunStavke.PDV;
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_UKUPNOPDV = decimal.Add(this.m__UKUPNOPDVPrevious, this.rowRACUNRacunStavke.PDV);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_UKUPNOPDV = decimal.Subtract(decimal.Add(this.m__UKUPNOPDVPrevious, this.rowRACUNRacunStavke.PDV), this.m__PDVPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_UKUPNOPDV = decimal.Subtract(this.m__UKUPNOPDVPrevious, this.m__PDVPrevious);
            }
            if (!this.rowRACUNRacunStavke.IsPDVNull())
            {
                this.m_IZNOSPLUSPDV = m_CijenaPDV * -1;
            }
        }

        private void OnRACUNRacunStavkeUpdated(RACUNRacunStavkeEventArgs e)
        {
            if (this.RACUNRacunStavkeUpdated != null)
            {
                RACUNRacunStavkeUpdateEventHandler rACUNRacunStavkeUpdatedEvent = this.RACUNRacunStavkeUpdated;
                if (rACUNRacunStavkeUpdatedEvent != null)
                {
                    rACUNRacunStavkeUpdatedEvent(this, e);
                }
            }
        }

        private void OnRACUNRacunStavkeUpdating(RACUNRacunStavkeEventArgs e)
        {
            if (this.RACUNRacunStavkeUpdating != null)
            {
                RACUNRacunStavkeUpdateEventHandler rACUNRacunStavkeUpdatingEvent = this.RACUNRacunStavkeUpdating;
                if (rACUNRacunStavkeUpdatingEvent != null)
                {
                    rACUNRacunStavkeUpdatingEvent(this, e);
                }
            }
        }

        private void OnRACUNUpdated(RACUNEventArgs e)
        {
            if (this.RACUNUpdated != null)
            {
                RACUNUpdateEventHandler rACUNUpdatedEvent = this.RACUNUpdated;
                if (rACUNUpdatedEvent != null)
                {
                    rACUNUpdatedEvent(this, e);
                }
            }
        }

        private void OnRACUNUpdating(RACUNEventArgs e)
        {
            if (this.RACUNUpdating != null)
            {
                RACUNUpdateEventHandler rACUNUpdatingEvent = this.RACUNUpdating;
                if (rACUNUpdatingEvent != null)
                {
                    rACUNUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelRacun()
        {
            this.sMode211 = this.Gx_mode;
            this.ProcessNestedLevelRacunracunstavke();
            this.Gx_mode = this.sMode211;
        }

        private void ProcessNestedLevelRacunracunstavke()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RACUNSet.RACUNRacunStavke.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRACUNRacunStavke = (RACUNDataSet.RACUNRacunStavkeRow) current;
                    if (Helpers.IsRowChanged(this.rowRACUNRacunStavke))
                    {
                        bool flag = false;
                        if (this.rowRACUNRacunStavke.RowState != DataRowState.Deleted)
                        {
                            flag = (this.rowRACUNRacunStavke.IDRACUN == this.rowRACUN.IDRACUN) && (this.rowRACUNRacunStavke.RACUNGODINAIDGODINE == this.rowRACUN.RACUNGODINAIDGODINE);
                        }
                        else
                        {
                            flag = this.rowRACUNRacunStavke["IDRACUN", DataRowVersion.Original].Equals(this.rowRACUN.IDRACUN) && this.rowRACUNRacunStavke["RACUNGODINAIDGODINE", DataRowVersion.Original].Equals(this.rowRACUN.RACUNGODINAIDGODINE);
                        }
                        if (flag)
                        {
                            this.ReadRowRacunracunstavke();
                            if (this.rowRACUNRacunStavke.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRacunracunstavke();
                            }
                            else if (this._Gxremove55)
                            {
                                this.Gx_mode = StatementType.Delete;
                                this.DeleteRacunracunstavke();
                            }
                            else
                            {
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRacunracunstavke();
                            }
                            this.m__UKUPNOPDVPrevious = this.m_UKUPNOPDV;
                            this.m__UKUPNOOSNOVICAPrevious = this.m_UKUPNOOSNOVICA;
                            this.m__SLOVIMAPrevious = this.rowRACUN.SLOVIMA;
                            this.m__SVEUKUPNOPrevious = this.m_SVEUKUPNO;
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        private void ReadRowRacun()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRACUN.RowState);
            if (this.rowRACUN.RowState != DataRowState.Deleted)
            {
                this.rowRACUN["DATUM"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRACUN["DATUM"])));
                this.rowRACUN["VALUTA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRACUN["VALUTA"])));
                this.rowRACUN["RAZDOBLJEOD"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEOD"])));
                this.rowRACUN["RAZDOBLJEDO"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEDO"])));
            }
            if (this.rowRACUN.RowState != DataRowState.Added)
            {
                this.m__UKUPNOPDVPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRACUN["UKUPNOPDV", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRACUN["UKUPNOPDV", DataRowVersion.Original])));
                this.m__UKUPNOOSNOVICAPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRACUN["UKUPNOOSNOVICA", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRACUN["UKUPNOOSNOVICA", DataRowVersion.Original])));
                this.m__ZAPREDUJAMOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["ZAPREDUJAM", DataRowVersion.Original]);
                this.m__DATUMOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["DATUM", DataRowVersion.Original]);
                this.m__VALUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["VALUTA", DataRowVersion.Original]);
                this.m__RAZDOBLJEODOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEOD", DataRowVersion.Original]);
                this.m__RAZDOBLJEDOOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEDO", DataRowVersion.Original]);
                this.m__MODELOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["MODEL", DataRowVersion.Original]);
                this.m__POZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["POZIV"]);
                this.m__NAPOMENAOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["NAPOMENA", DataRowVersion.Original]);
                this.m__IDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER", DataRowVersion.Original]);
                this.m__VrstaOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["Vrsta", DataRowVersion.Original]);
                this.m__UkupanIznosOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["UkupanIznos", DataRowVersion.Original]);
            }
            else
            {
                this.m__ZAPREDUJAMOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["ZAPREDUJAM"]);
                this.m__DATUMOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["DATUM"]);
                this.m__VALUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["VALUTA"]);
                this.m__RAZDOBLJEODOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEOD"]);
                this.m__RAZDOBLJEDOOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEDO"]);
                this.m__MODELOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["MODEL"]);
                this.m__POZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["POZIV"]);
                this.m__NAPOMENAOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["NAPOMENA"]);
                this.m__IDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER"]);
                this.m__VrstaOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["Vrsta"]);
                this.m__UkupanIznosOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUN["UkupanIznos"]);
            }
            this._Gxremove = this.rowRACUN.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRACUN = (RACUNDataSet.RACUNRow) DataSetUtil.CloneOriginalDataRow(this.rowRACUN);
            }
        }

        private void ReadRowRacunracunstavke()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRACUNRacunStavke.RowState);
            if (this.rowRACUNRacunStavke.RowState != DataRowState.Added)
            {
                this.m__PDVPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRACUNRacunStavke["PDV", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["PDV", DataRowVersion.Original])));
                this.m__IZNOSMINUSRABATPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRACUNRacunStavke["IZNOSMINUSRABAT", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IZNOSMINUSRABAT", DataRowVersion.Original])));
                this.m__RABATOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RABAT", DataRowVersion.Original]);
                this.m__KOLICINAOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["KOLICINA", DataRowVersion.Original]);
                this.m__NAZIVPROIZVODRACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["NAZIVPROIZVODRACUN", DataRowVersion.Original]);
                this.m__CIJENARACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["CIJENARACUN", DataRowVersion.Original]);
                this.m__FINPOREZSTOPARACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["FINPOREZSTOPARACUN", DataRowVersion.Original]);
                this.m__IDPROIZVODOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDPROIZVOD", DataRowVersion.Original]);
                this.m__CijenaPDVOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["CijenaPDV", DataRowVersion.Original]);
            }
            else
            {
                this.m__RABATOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RABAT"]);
                this.m__KOLICINAOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["KOLICINA"]);
                this.m__NAZIVPROIZVODRACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["NAZIVPROIZVODRACUN"]);
                this.m__CIJENARACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["CIJENARACUN"]);
                this.m__FINPOREZSTOPARACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["FINPOREZSTOPARACUN"]);
                this.m__CijenaPDVOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["CijenaPDV"]);
                this.m__IDPROIZVODOriginal = RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDPROIZVOD"]);
            }
            this._Gxremove55 = this.rowRACUNRacunStavke.RowState == DataRowState.Deleted;
            if (this._Gxremove55)
            {
                this.rowRACUNRacunStavke = (RACUNDataSet.RACUNRacunStavkeRow) DataSetUtil.CloneOriginalDataRow(this.rowRACUNRacunStavke);
            }
        }

        private void ScanByIDPARTNER(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDPARTNER] = @IDPARTNER";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString211 + "  FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString211, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ) AS DK_PAGENUM   FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString211 + " FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ";
            }
            this.cmRACUNSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRACUNSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmRACUNSelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER"]));
            this.RACUNSelect7 = this.cmRACUNSelect7.FetchData();
            this.RcdFound211 = 0;
            this.ScanLoadRacun();
            this.LoadDataRacun(maxRows);
            if (this.RcdFound211 > 0)
            {
                this.SubLvlScanStartRacunracunstavke(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDPARTNERRacun(this.cmRACUNRacunStavkeSelect2);
                this.SubLvlFetchRacunracunstavke();
                this.SubLoadDataRacunracunstavke();
            }
        }

        private void ScanByIDRACUN(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRACUN] = @IDRACUN";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString211 + "  FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString211, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ) AS DK_PAGENUM   FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString211 + " FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ";
            }
            this.cmRACUNSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRACUNSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
            }
            this.cmRACUNSelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
            this.RACUNSelect7 = this.cmRACUNSelect7.FetchData();
            this.RcdFound211 = 0;
            this.ScanLoadRacun();
            this.LoadDataRacun(maxRows);
            if (this.RcdFound211 > 0)
            {
                this.SubLvlScanStartRacunracunstavke(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRACUNRacun(this.cmRACUNRacunStavkeSelect2);
                this.SubLvlFetchRacunracunstavke();
                this.SubLoadDataRacunracunstavke();
            }
        }

        private void ScanByIDRACUNRACUNGODINAIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRACUN] = @IDRACUN and TM1.[RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString211 + "  FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString211, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ) AS DK_PAGENUM   FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString211 + " FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ";
            }
            this.cmRACUNSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRACUNSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                this.cmRACUNSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            this.cmRACUNSelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
            this.cmRACUNSelect7.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
            this.RACUNSelect7 = this.cmRACUNSelect7.FetchData();
            this.RcdFound211 = 0;
            this.ScanLoadRacun();
            this.LoadDataRacun(maxRows);
            if (this.RcdFound211 > 0)
            {
                this.SubLvlScanStartRacunracunstavke(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRACUNRACUNGODINAIDGODINERacun(this.cmRACUNRacunStavkeSelect2);
                this.SubLvlFetchRacunracunstavke();
                this.SubLoadDataRacunracunstavke();
            }
        }

        private void ScanByRACUNGODINAIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString211 + "  FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString211, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ) AS DK_PAGENUM   FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString211 + " FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ";
            }
            this.cmRACUNSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRACUNSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            this.cmRACUNSelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
            this.RACUNSelect7 = this.cmRACUNSelect7.FetchData();
            this.RcdFound211 = 0;
            this.ScanLoadRacun();
            this.LoadDataRacun(maxRows);
            if (this.RcdFound211 > 0)
            {
                this.SubLvlScanStartRacunracunstavke(this.m_WhereString, startRow, maxRows);
                this.SetParametersRACUNGODINAIDGODINERacun(this.cmRACUNRacunStavkeSelect2);
                this.SubLvlFetchRacunracunstavke();
                this.SubLoadDataRacunracunstavke();
            }
        }

        private void ScanEndRacun()
        {
            this.RACUNSelect7.Close();
        }

        private void ScanEndRacunracunstavke()
        {
            this.RACUNRacunStavkeSelect2.Close();
        }

        private void ScanLoadRacun()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRACUNSelect7.HasMoreRows)
            {
                this.RcdFound211 = 1;
                this.rowRACUN["IDRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNSelect7, 0));
                this.rowRACUN["ZAPREDUJAM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.RACUNSelect7, 1));
                this.rowRACUN["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 2))));
                this.rowRACUN["MB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 3));
                this.rowRACUN["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 4));
                this.rowRACUN["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 5));
                this.rowRACUN["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 6));
                this.rowRACUN["DATUM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RACUNSelect7, 7));
                this.rowRACUN["VALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RACUNSelect7, 8));
                this.rowRACUN["RAZDOBLJEOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RACUNSelect7, 9));
                this.rowRACUN["RAZDOBLJEDO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.RACUNSelect7, 10));
                this.rowRACUN["MODEL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 11));
                this.rowRACUN["POZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 12));
                this.rowRACUN["NAPOMENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 13));
                this.rowRACUN["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 14));
                this.rowRACUN["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNSelect7, 15));
                this.rowRACUN["RACUNGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RACUNSelect7, 0x10));
                this.rowRACUN["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 2))));
                this.rowRACUN["MB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 3));
                this.rowRACUN["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 4));
                this.rowRACUN["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 5));
                this.rowRACUN["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 6));
                this.rowRACUN["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 14));
                
                this.rowRACUN["Vrsta"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNSelect7, 17));
                this.rowRACUN["UkupanIznos"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNSelect7, 18));
            }
        }

        private void ScanLoadRacunracunstavke()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRACUNRacunStavkeSelect2.HasMoreRows)
            {
                this.RcdFound212 = 1;
                this.m_FINPOREZIDPOREZ = this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 0, ref this.m__FINPOREZIDPOREZIsNull);
                this.rowRACUNRacunStavke["IDRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 1));
                this.rowRACUNRacunStavke["RACUNGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.RACUNRacunStavkeSelect2, 2));
                this.rowRACUNRacunStavke["BROJSTAVKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 3));
                this.rowRACUNRacunStavke["RABAT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 4));
                this.rowRACUNRacunStavke["KOLICINA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 5));
                this.rowRACUNRacunStavke["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNRacunStavkeSelect2, 6));
                this.rowRACUNRacunStavke["NAZIVPROIZVODRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNRacunStavkeSelect2, 7));
                this.rowRACUNRacunStavke["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 8));
                this.rowRACUNRacunStavke["CIJENARACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 9));
                this.rowRACUNRacunStavke["FINPOREZSTOPARACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 10));
                this.rowRACUNRacunStavke["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 11));
                this.rowRACUNRacunStavke["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNRacunStavkeSelect2, 12));
                this.rowRACUNRacunStavke["OSNOVICAUKNIZIIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 13));
                this.rowRACUNRacunStavke["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 14));
                this.rowRACUNRacunStavke["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 15));
                this.m_FINPOREZIDPOREZ = this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 0, ref this.m__FINPOREZIDPOREZIsNull);
                this.rowRACUNRacunStavke["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNRacunStavkeSelect2, 6));
                this.rowRACUNRacunStavke["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 8));
                this.rowRACUNRacunStavke["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 15));
                this.rowRACUNRacunStavke["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 11));
                this.rowRACUNRacunStavke["OSNOVICAUKNIZIIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RACUNRacunStavkeSelect2, 13));
                this.rowRACUNRacunStavke["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RACUNRacunStavkeSelect2, 12));
                this.rowRACUNRacunStavke["CijenaPDV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RACUNRacunStavkeSelect2, 16));
            }
        }

        private void ScanNextRacun()
        {
            this.cmRACUNSelect7.HasMoreRows = this.RACUNSelect7.Read();
            this.RcdFound211 = 0;
            this.ScanLoadRacun();
        }

        private void ScanNextRacunracunstavke()
        {
            this.cmRACUNRacunStavkeSelect2.HasMoreRows = this.RACUNRacunStavkeSelect2.Read();
            this.RcdFound212 = 0;
            this.ScanLoadRacunracunstavke();
        }

        private void ScanStartRacun(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString211 + "  FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString211, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ) AS DK_PAGENUM   FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString211 + " FROM ([RACUN] TM1 WITH (NOLOCK) INNER JOIN [PARTNER] T2 WITH (NOLOCK) ON T2.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] ";
            }
            this.cmRACUNSelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RACUNSelect7 = this.cmRACUNSelect7.FetchData();
            this.RcdFound211 = 0;
            this.ScanLoadRacun();
            this.LoadDataRacun(maxRows);
            if (this.RcdFound211 > 0)
            {
                this.SubLvlScanStartRacunracunstavke(this.m_WhereString, startRow, maxRows);
                this.SetParametersRacunRacun(this.cmRACUNRacunStavkeSelect2);
                this.SubLvlFetchRacunracunstavke();
                this.SubLoadDataRacunracunstavke();
            }
        }

        private void ScanStartRacunracunstavke()
        {
            this.cmRACUNRacunStavkeSelect2 = this.connDefault.GetCommand("SELECT T2.[FINPOREZIDPOREZ], T1.[IDRACUN], T1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE, T1.[BROJSTAVKE], T1.[RABAT], T1.[KOLICINA], T2.[NAZIVPROIZVOD], T1.[NAZIVPROIZVODRACUN], T2.[CIJENA], T1.[CIJENARACUN], T1.[FINPOREZSTOPARACUN], T3.[FINPOREZSTOPA], T4.[NAZIVJEDINICAMJERE], T3.[OSNOVICAUKNIZIIRA], T1.[IDPROIZVOD], T2.[IDJEDINICAMJERE], T1.[CijenaPDV] FROM ((([RACUNRacunStavke] T1 WITH (NOLOCK) INNER JOIN [PROIZVOD] T2 WITH (NOLOCK) ON T2.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T3 WITH (NOLOCK) ON T3.[FINPOREZIDPOREZ] = T2.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T4 WITH (NOLOCK) ON T4.[IDJEDINICAMJERE] = T2.[IDJEDINICAMJERE]) WHERE T1.[IDRACUN] = @IDRACUN and T1.[RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE ORDER BY T1.[IDRACUN], T1.[RACUNGODINAIDGODINE], T1.[BROJSTAVKE] ", false);
            if (this.cmRACUNRacunStavkeSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRACUNRacunStavkeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                this.cmRACUNRacunStavkeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            this.cmRACUNRacunStavkeSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDRACUN"]));
            this.cmRACUNRacunStavkeSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RACUNGODINAIDGODINE"]));
            this.RACUNRacunStavkeSelect2 = this.cmRACUNRacunStavkeSelect2.FetchData();
            this.RcdFound212 = 0;
            this.ScanLoadRacunracunstavke();
        }

        private void SetParametersIDPARTNERRacun(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER"]));
        }

        private void SetParametersIDRACUNRacun(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
        }

        private void SetParametersIDRACUNRACUNGODINAIDGODINERacun(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
            m_Command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
        }

        private void SetParametersRACUNGODINAIDGODINERacun(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
        }

        private void SetParametersRacunRacun(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextRacunracunstavke()
        {
            this.cmRACUNRacunStavkeSelect2.HasMoreRows = this.RACUNRacunStavkeSelect2.Read();
            this.RcdFound212 = 0;
            if (this.cmRACUNRacunStavkeSelect2.HasMoreRows)
            {
                this.RcdFound212 = 1;
            }
        }

        private void SubLoadDataRacunracunstavke()
        {
            while (this.RcdFound212 != 0)
            {
                this.LoadRowRacunracunstavke();
                this.CreateNewRowRacunracunstavke();
                this.ScanNextRacunracunstavke();
            }
            this.ScanEndRacunracunstavke();
        }

        private void SubLvlFetchRacunracunstavke()
        {
            this.CreateNewRowRacunracunstavke();
            this.RACUNRacunStavkeSelect2 = this.cmRACUNRacunStavkeSelect2.FetchData();
            this.RcdFound212 = 0;
            this.ScanLoadRacunracunstavke();
        }

        private void SubLvlScanStartRacunracunstavke(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString212 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDRACUN],TM1.[RACUNGODINAIDGODINE]  FROM [RACUN]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE] )";
                    this.scmdbuf = "SELECT T3.[FINPOREZIDPOREZ], T1.[IDRACUN], T1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE, T1.[BROJSTAVKE], T1.[RABAT], T1.[KOLICINA], T3.[NAZIVPROIZVOD], T1.[NAZIVPROIZVODRACUN], T3.[CIJENA], T1.[CIJENARACUN], T1.[FINPOREZSTOPARACUN], T4.[FINPOREZSTOPA], T5.[NAZIVJEDINICAMJERE], T4.[OSNOVICAUKNIZIIRA], T1.[IDPROIZVOD], T3.[IDJEDINICAMJERE], T1.[CijenaPDV] FROM (((([RACUNRacunStavke] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString212 + "  TMX ON TMX.[IDRACUN] = T1.[IDRACUN] AND TMX.[RACUNGODINAIDGODINE] = T1.[RACUNGODINAIDGODINE]) INNER JOIN [PROIZVOD] T3 WITH (NOLOCK) ON T3.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T4 WITH (NOLOCK) ON T4.[FINPOREZIDPOREZ] = T3.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T5 WITH (NOLOCK) ON T5.[IDJEDINICAMJERE] = T3.[IDJEDINICAMJERE]) ORDER BY T1.[IDRACUN], T1.[RACUNGODINAIDGODINE], T1.[BROJSTAVKE]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDRACUN],TM1.[RACUNGODINAIDGODINE], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRACUN], TM1.[RACUNGODINAIDGODINE]  ) AS DK_PAGENUM   FROM [RACUN]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString212 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T3.[FINPOREZIDPOREZ], T1.[IDRACUN], T1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE, T1.[BROJSTAVKE], T1.[RABAT], T1.[KOLICINA], T3.[NAZIVPROIZVOD], T1.[NAZIVPROIZVODRACUN], T3.[CIJENA], T1.[CIJENARACUN], T1.[FINPOREZSTOPARACUN], T4.[FINPOREZSTOPA], T5.[NAZIVJEDINICAMJERE], T4.[OSNOVICAUKNIZIIRA], T1.[IDPROIZVOD], T3.[IDJEDINICAMJERE], T1.[CijenaPDV] FROM (((([RACUNRacunStavke] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString212 + "  TMX ON TMX.[IDRACUN] = T1.[IDRACUN] AND TMX.[RACUNGODINAIDGODINE] = T1.[RACUNGODINAIDGODINE]) INNER JOIN [PROIZVOD] T3 WITH (NOLOCK) ON T3.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T4 WITH (NOLOCK) ON T4.[FINPOREZIDPOREZ] = T3.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T5 WITH (NOLOCK) ON T5.[IDJEDINICAMJERE] = T3.[IDJEDINICAMJERE]) ORDER BY T1.[IDRACUN], T1.[RACUNGODINAIDGODINE], T1.[BROJSTAVKE]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString212 = "[RACUN]";
                this.scmdbuf = "SELECT T3.[FINPOREZIDPOREZ], T1.[IDRACUN], T1.[RACUNGODINAIDGODINE] AS RACUNGODINAIDGODINE, T1.[BROJSTAVKE], T1.[RABAT], T1.[KOLICINA], T3.[NAZIVPROIZVOD], T1.[NAZIVPROIZVODRACUN], T3.[CIJENA], T1.[CIJENARACUN], T1.[FINPOREZSTOPARACUN], T4.[FINPOREZSTOPA], T5.[NAZIVJEDINICAMJERE], T4.[OSNOVICAUKNIZIIRA], T1.[IDPROIZVOD], T3.[IDJEDINICAMJERE], T1.[CijenaPDV] FROM (((([RACUNRacunStavke] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString212 + "  TM1 WITH (NOLOCK) ON TM1.[IDRACUN] = T1.[IDRACUN] AND TM1.[RACUNGODINAIDGODINE] = T1.[RACUNGODINAIDGODINE]) INNER JOIN [PROIZVOD] T3 WITH (NOLOCK) ON T3.[IDPROIZVOD] = T1.[IDPROIZVOD]) INNER JOIN [FINPOREZ] T4 WITH (NOLOCK) ON T4.[FINPOREZIDPOREZ] = T3.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T5 WITH (NOLOCK) ON T5.[IDJEDINICAMJERE] = T3.[IDJEDINICAMJERE])" + this.m_WhereString + " ORDER BY T1.[IDRACUN], T1.[RACUNGODINAIDGODINE], T1.[BROJSTAVKE] ";
            }
            this.cmRACUNRacunStavkeSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RACUNSet = (RACUNDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RACUNSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RACUNSet.RACUN.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RACUNDataSet.RACUNRow current = (RACUNDataSet.RACUNRow) enumerator.Current;
                        this.rowRACUN = current;
                        if (Helpers.IsRowChanged(this.rowRACUN))
                        {
                            this.ReadRowRacun();
                            if (this.rowRACUN.RowState == DataRowState.Added)
                            {
                                this.InsertRacun();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRacun();
                            }
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                dataSet.AcceptChanges();
                this.connDefault.Commit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //this.connDefault.Rollback();
                
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdateRacun()
        {
            this.CheckOptimisticConcurrencyRacun();
            this.CheckExtendedTableRacun();
            this.AfterConfirmRacun();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RACUN] SET [ZAPREDUJAM]=@ZAPREDUJAM, [DATUM]=@DATUM, [VALUTA]=@VALUTA, [RAZDOBLJEOD]=@RAZDOBLJEOD, [RAZDOBLJEDO]=@RAZDOBLJEDO, [MODEL]=@MODEL, [POZIV]=@POZIV, [NAPOMENA]=@NAPOMENA, [IDPARTNER]=@IDPARTNER  WHERE [IDRACUN] = @IDRACUN AND [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAPREDUJAM", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUM", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VALUTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODEL", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POZIV", DbType.String, 22));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAPOMENA", DbType.String, 200));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUN["ZAPREDUJAM"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowRACUN["DATUM"]));
            command.SetParameterDateObject(2, RuntimeHelpers.GetObjectValue(this.rowRACUN["VALUTA"]));
            command.SetParameterDateObject(3, RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEOD"]));
            command.SetParameterDateObject(4, RuntimeHelpers.GetObjectValue(this.rowRACUN["RAZDOBLJEDO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRACUN["MODEL"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRACUN["POZIV"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRACUN["NAPOMENA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDPARTNER"]));

            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRACUN["IDRACUN"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRACUN["RACUNGODINAIDGODINE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRacun();
            }
            this.OnRACUNUpdated(new RACUNEventArgs(this.rowRACUN, StatementType.Update));
            this.ProcessLevelRacun();

        }

        private void UpdateRacunracunstavke()
        {
            this.CheckOptimisticConcurrencyRacunracunstavke();
            this.CheckExtendedTableRacunracunstavke();
            this.AfterConfirmRacunracunstavke();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RACUNRacunStavke] SET [RABAT]=@RABAT, [KOLICINA]=@KOLICINA, [NAZIVPROIZVODRACUN]=@NAZIVPROIZVODRACUN, [CIJENARACUN]=@CIJENARACUN, [FINPOREZSTOPARACUN]=@FINPOREZSTOPARACUN, [IDPROIZVOD]=@IDPROIZVOD, CijenaPDV=@CijenaPDV  WHERE [IDRACUN] = @IDRACUN AND [RACUNGODINAIDGODINE] = @RACUNGODINAIDGODINE AND [BROJSTAVKE] = @BROJSTAVKE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RABAT", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLICINA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPROIZVODRACUN", DbType.String, 500));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CIJENARACUN", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZSTOPARACUN", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRACUN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RACUNGODINAIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CijenaPDV", DbType.Currency));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RABAT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["KOLICINA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["NAZIVPROIZVODRACUN"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["CIJENARACUN"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["FINPOREZSTOPARACUN"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDPROIZVOD"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["IDRACUN"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["RACUNGODINAIDGODINE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRACUNRacunStavke["BROJSTAVKE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(GetCijenaPDV(rowRACUNRacunStavke["CIJENARACUN"], this.rowRACUNRacunStavke["FINPOREZSTOPARACUN"], this.rowRACUNRacunStavke["RABAT"], this.rowRACUNRacunStavke["KOLICINA"]))); 
            command.ExecuteStmt();
            this.OnRACUNRacunStavkeUpdated(new RACUNRacunStavkeEventArgs(this.rowRACUNRacunStavke, StatementType.Update));
        }

        public System.Data.MissingMappingAction MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        System.Data.MissingMappingAction System.Data.IDataAdapter.MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction System.Data.IDataAdapter.MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        ITableMappingCollection System.Data.IDataAdapter.TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
        }

        ITableMappingCollection TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.daCurrentTransaction;
            }
            set
            {
                this.daCurrentTransaction = value;
            }
        }

        [Serializable]
        public class FINPOREZForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public FINPOREZForeignKeyNotFoundException()
            {
            }

            public FINPOREZForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected FINPOREZForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public FINPOREZForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ForeignKeyNotFoundException()
            {
            }

            public ForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GODINEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public GODINEForeignKeyNotFoundException()
            {
            }

            public GODINEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected GODINEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GODINEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class JEDINICAMJEREForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public JEDINICAMJEREForeignKeyNotFoundException()
            {
            }

            public JEDINICAMJEREForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected JEDINICAMJEREForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public JEDINICAMJEREForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PARTNERForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public PARTNERForeignKeyNotFoundException()
            {
            }

            public PARTNERForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected PARTNERForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PROIZVODForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public PROIZVODForeignKeyNotFoundException()
            {
            }

            public PROIZVODForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected PROIZVODForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PROIZVODForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RACUNDataChangedException : DataChangedException
        {
            public RACUNDataChangedException()
            {
            }

            public RACUNDataChangedException(string message) : base(message)
            {
            }

            protected RACUNDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RACUNDataLockedException : DataLockedException
        {
            public RACUNDataLockedException()
            {
            }

            public RACUNDataLockedException(string message) : base(message)
            {
            }

            protected RACUNDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RACUNDuplicateKeyException : DuplicateKeyException
        {
            public RACUNDuplicateKeyException()
            {
            }

            public RACUNDuplicateKeyException(string message) : base(message)
            {
            }

            protected RACUNDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RACUNEventArgs : EventArgs
        {
            private RACUNDataSet.RACUNRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RACUNEventArgs(RACUNDataSet.RACUNRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RACUNDataSet.RACUNRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        [Serializable]
        public class RACUNNotFoundException : DataNotFoundException
        {
            public RACUNNotFoundException()
            {
            }

            public RACUNNotFoundException(string message) : base(message)
            {
            }

            protected RACUNNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RACUNRacunStavkeDataChangedException : DataChangedException
        {
            public RACUNRacunStavkeDataChangedException()
            {
            }

            public RACUNRacunStavkeDataChangedException(string message) : base(message)
            {
            }

            protected RACUNRacunStavkeDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNRacunStavkeDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RACUNRacunStavkeDataLockedException : DataLockedException
        {
            public RACUNRacunStavkeDataLockedException()
            {
            }

            public RACUNRacunStavkeDataLockedException(string message) : base(message)
            {
            }

            protected RACUNRacunStavkeDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNRacunStavkeDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RACUNRacunStavkeDuplicateKeyException : DuplicateKeyException
        {
            public RACUNRacunStavkeDuplicateKeyException()
            {
            }

            public RACUNRacunStavkeDuplicateKeyException(string message) : base(message)
            {
            }

            protected RACUNRacunStavkeDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNRacunStavkeDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RACUNRacunStavkeEventArgs : EventArgs
        {
            private RACUNDataSet.RACUNRacunStavkeRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RACUNRacunStavkeEventArgs(RACUNDataSet.RACUNRacunStavkeRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RACUNDataSet.RACUNRacunStavkeRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        public delegate void RACUNRacunStavkeUpdateEventHandler(object sender, RACUNDataAdapter.RACUNRacunStavkeEventArgs e);

        public delegate void RACUNUpdateEventHandler(object sender, RACUNDataAdapter.RACUNEventArgs e);
    }
}

