namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
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

    public class KORISNIKDataAdapter : IDataAdapter, IKORISNIKDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove61;
        private ReadWriteCommand cmKORISNIKLevel1Select2;
        private ReadWriteCommand cmKORISNIKSelect1;
        private ReadWriteCommand cmKORISNIKSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader KORISNIKLevel1Select2;
        private IDataReader KORISNIKSelect1;
        private IDataReader KORISNIKSelect4;
        private KORISNIKDataSet KORISNIKSet;
        private object m__ADRESAOVLASTENEOSOBEOriginal;
        private object m__ANALITIKAOriginal;
        private object m__BROJCANAOZNAKAPUOriginal;
        private object m__EMAILOriginal;
        private object m__EMAILPOSILJAOCAOriginal;
        private object m__JMBGKORISNIKOriginal;
        private object m__KONTAKTFAXOriginal;
        private object m__KONTAKTOSOBAOriginal;
        private object m__KONTAKTTELEFONOriginal;
        private object m__KORISNIK1ADRESAOriginal;
        private object m__KORISNIK1HZZOOriginal;
        private object m__KORISNIK1MJESTOOriginal;
        private object m__KORISNIK1NAZIVOriginal;
        private object m__KORISNIK1NAZIVZANALJEPNICEOriginal;
        private object m__KORISNIKOIBOriginal;
        private object m__MBKORISNIKJEDINICAOriginal;
        private object m__MBKORISNIKOriginal;
        private object m__MJESTOZIROOriginal;
        private object m__NADLEZNAPUOriginal;
        private object m__NAZIVPOSILJAOCAOriginal;
        private object m__NAZIVZIROOriginal;
        private object m__OIBOVLASTENEOSOBEOriginal;
        private object m__POREZIPRIREZZAJEDNICKIOriginal;
        private object m__POZIVIZADUZENJAOriginal;
        private object m__PREZIMEIMEOVLASTENEOSOBEOriginal;
        private object m__RKPOriginal;
        private object m__SIFRAIZVORAOriginal;
        private object m__SMTPSERVEROriginal;
        private object m__STAZUKOEFICIJENTUOriginal;
        private object m__OBVEZNIKPDVAOriginal;
        private object m__NeprofitniOriginal;

        #region MBS.Complete
        private object m__PredPorezOriginal;
        #endregion

        //1.1.15
        private object m__StopaZaInvalideOriginal;
        private object m__BrojOsobaOriginal;
        private object m__PDVPoNaplacenomOriginal;
        private object m__EmailPasswordOriginal;
        private object m__EmailPortOriginal;

        private object m__JOPPDPodnositeljIzvjescaIDOriginal;
        private object m__ULICAZIROOriginal;
        private object m__VBDIKORISNIKOriginal;
        private object m__ZIROKORISNIKOriginal;
        //1.1.15
        private readonly string m_SelectString7 = "TM1.[IDKORISNIK], TM1.[KORISNIK1NAZIV], TM1.[KORISNIK1ADRESA], TM1.[KORISNIK1MJESTO], TM1.[KORISNIKOIB], TM1.[MBKORISNIK], TM1.[MBKORISNIKJEDINICA], TM1.[JMBGKORISNIK], TM1.[KONTAKTOSOBA], TM1.[KONTAKTTELEFON], TM1.[KONTAKTFAX], TM1.[EMAIL], TM1.[NADLEZNAPU], TM1.[BROJCANAOZNAKAPU], TM1.[STAZUKOEFICIJENTU], TM1.[RKP], TM1.[PREZIMEIMEOVLASTENEOSOBE], TM1.[ADRESAOVLASTENEOSOBE], TM1.[OIBOVLASTENEOSOBE], TM1.[ANALITIKA], TM1.[KORISNIK1HZZO], TM1.[KORISNIK1NAZIVZANALJEPNICE], TM1.[EMAILPOSILJAOCA], TM1.[NAZIVPOSILJAOCA], TM1.[SMTPSERVER], TM1.[OBVEZNIKPDVA], TM1.[JOPPDPodnositeljIzvjescaID], TM1.[Neprofitni], TM1.[StopaZaInvalide], TM1.[BrojOsoba], TM1.[PDVPoNaplacenom], TM1.[EmailPassword], TM1.[EmailPort], TM1.[PredPorez]";

        private string m_SubSelTopString77;
        private string m_WhereString;
        private short RcdFound7;
        private short RcdFound77;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private KORISNIKDataSet.KORISNIKRow rowKORISNIK;
        private KORISNIKDataSet.KORISNIKLevel1Row rowKORISNIKLevel1;
        private string scmdbuf;
        private StatementType sMode7;
        private StatementType sMode77;

        public event KORISNIKLevel1UpdateEventHandler KORISNIKLevel1Updated;

        public event KORISNIKLevel1UpdateEventHandler KORISNIKLevel1Updating;

        public event KORISNIKUpdateEventHandler KORISNIKUpdated;

        public event KORISNIKUpdateEventHandler KORISNIKUpdating;

        private void AddRowKorisnik()
        {
            this.KORISNIKSet.KORISNIK.AddKORISNIKRow(this.rowKORISNIK);
        }

        private void AddRowKorisniklevel1()
        {
            this.KORISNIKSet.KORISNIKLevel1.AddKORISNIKLevel1Row(this.rowKORISNIKLevel1);
        }

        private void AfterConfirmKorisnik()
        {
            this.OnKORISNIKUpdating(new KORISNIKEventArgs(this.rowKORISNIK, this.Gx_mode));
        }

        private void AfterConfirmKorisniklevel1()
        {
            this.OnKORISNIKLevel1Updating(new KORISNIKLevel1EventArgs(this.rowKORISNIKLevel1, this.Gx_mode));
        }

        private void CheckExtendedTableKorisnik()
        {
            if ((!this.rowKORISNIK.IsMBKORISNIKNull() && !this.rowKORISNIK.IsJMBGKORISNIKNull()) && ((this.rowKORISNIK.MBKORISNIK.Length > 0) && (this.rowKORISNIK.JMBGKORISNIK.Length > 0)))
            {
                throw new greska1("Potrebno je upisati MB ustanove ili JMBG za obrtnike!");
            }
            if ((!this.rowKORISNIK.IsMBKORISNIKNull() && !this.rowKORISNIK.IsJMBGKORISNIKNull()) && ((this.rowKORISNIK.MBKORISNIK.Length == 0) && (this.rowKORISNIK.JMBGKORISNIK.Length == 0)))
            {
                throw new greska2("Potrebno je upisati MB ustanove ili JMBG za obrtnike!");
            }
            if (!StringUtil.RegExMatch(this.rowKORISNIK.EMAIL, @"[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)@[a-zA-Z0-9]([a-zA-Z0-9_\-\.]*)(\.[a-zA-Z]{2,3}(\.[a-zA-Z]{2}){0,2})"))
            {
                throw new EMAILInvalidValue("Invalid E-mail Value");
            }
        }

        private void CheckExtendedTableKorisniklevel1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVIZVORA] FROM [IZVORDOKUMENTA] WITH (NOLOCK) WHERE [SIFRAIZVORA] = @SIFRAIZVORA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["SIFRAIZVORA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new IZVORDOKUMENTAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("IZVORDOKUMENTA") }));
            }
            this.rowKORISNIKLevel1["NAZIVIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyKorisnik()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                //1.1.15
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKORISNIK], [KORISNIK1NAZIV], [KORISNIK1ADRESA], [KORISNIK1MJESTO], [KORISNIKOIB], [MBKORISNIK], [MBKORISNIKJEDINICA], [JMBGKORISNIK], [KONTAKTOSOBA], [KONTAKTTELEFON], [KONTAKTFAX], [EMAIL], [NADLEZNAPU], [BROJCANAOZNAKAPU], [STAZUKOEFICIJENTU], [RKP], [PREZIMEIMEOVLASTENEOSOBE], [ADRESAOVLASTENEOSOBE], [OIBOVLASTENEOSOBE], [ANALITIKA], [KORISNIK1HZZO], [KORISNIK1NAZIVZANALJEPNICE], [EMAILPOSILJAOCA], [NAZIVPOSILJAOCA], [SMTPSERVER], [OBVEZNIKPDVA], [JOPPDPodnositeljIzvjescaID], [StopaZaInvalide], [BrojOsoba], [PDVPoNaplacenom], [EmailPassword], [EmailPort] FROM [KORISNIK] WITH (UPDLOCK) WHERE [IDKORISNIK] = @IDKORISNIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["IDKORISNIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new KORISNIKDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("KORISNIK") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KORISNIK1NAZIVOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KORISNIK1ADRESAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KORISNIK1MJESTOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KORISNIKOIBOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MBKORISNIKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MBKORISNIKJEDINICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || 
                    (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__JMBGKORISNIKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || 
                    ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KONTAKTOSOBAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || 
                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KONTAKTTELEFONOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || 
                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KONTAKTFAXOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__EMAILOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || 
                    ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NADLEZNAPUOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))) || 
                    !this.m__BROJCANAOZNAKAPUOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 13)))) || 
                    (!this.m__STAZUKOEFICIJENTUOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 14))) || 
                    !this.m__RKPOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 15))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PREZIMEIMEOVLASTENEOSOBEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x10)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ADRESAOVLASTENEOSOBEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x11))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OIBOVLASTENEOSOBEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x12)))) || (!this.m__ANALITIKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x13))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KORISNIK1HZZOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 20))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || 
                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__KORISNIK1NAZIVZANALJEPNICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x15)))) || 
                    ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__EMAILPOSILJAOCAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x16))) || 
                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVPOSILJAOCAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x17)))) ||
                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SMTPSERVEROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x18))) ||
                    !m__OBVEZNIKPDVAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 0x19)))))
                {
                    reader.Close();
                    throw new KORISNIKDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("KORISNIK") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyKorisniklevel1()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKORISNIK], [IDZIRO], [POREZIPRIREZZAJEDNICKI], [POZIVIZADUZENJA], [NAZIVZIRO], [ULICAZIRO], [MJESTOZIRO], [VBDIKORISNIK], [ZIROKORISNIK], [SIFRAIZVORA] FROM [KORISNIKLevel1] WITH (UPDLOCK) WHERE [IDKORISNIK] = @IDKORISNIK AND [IDZIRO] = @IDZIRO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDZIRO", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDKORISNIK"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDZIRO"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new KORISNIKLevel1DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("KORISNIKLevel1") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__POREZIPRIREZZAJEDNICKIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2)))) || ((!this.m__POZIVIZADUZENJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVZIROOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ULICAZIROOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MJESTOZIROOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIKORISNIKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZIROKORISNIKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAIZVORAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))))
                {
                    reader.Close();
                    throw new KORISNIKLevel1DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("KORISNIKLevel1") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowKorisnik()
        {
            this.rowKORISNIK = this.KORISNIKSet.KORISNIK.NewKORISNIKRow();
        }

        private void CreateNewRowKorisniklevel1()
        {
            this.rowKORISNIKLevel1 = this.KORISNIKSet.KORISNIKLevel1.NewKORISNIKLevel1Row();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyKorisnik();
            this.ProcessNestedLevelKorisniklevel1();
            this.AfterConfirmKorisnik();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [KORISNIK]  WHERE [IDKORISNIK] = @IDKORISNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["IDKORISNIK"]));
            command.ExecuteStmt();
            this.OnKORISNIKUpdated(new KORISNIKEventArgs(this.rowKORISNIK, StatementType.Delete));
            this.rowKORISNIK.Delete();
            this.sMode7 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode7;
        }

        private void DeleteKorisniklevel1()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyKorisniklevel1();
            this.OnDeleteControlsKorisniklevel1();
            this.AfterConfirmKorisniklevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [KORISNIKLevel1]  WHERE [IDKORISNIK] = @IDKORISNIK AND [IDZIRO] = @IDZIRO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDZIRO", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDKORISNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDZIRO"]));
            command.ExecuteStmt();
            this.OnKORISNIKLevel1Updated(new KORISNIKLevel1EventArgs(this.rowKORISNIKLevel1, StatementType.Delete));
            this.rowKORISNIKLevel1.Delete();
            this.sMode77 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode77;
        }

        public virtual int Fill(KORISNIKDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.KORISNIKSet = dataSet;
                    this.LoadChildKorisnik(0, -1);
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
            this.KORISNIKSet = (KORISNIKDataSet) dataSet;
            if (this.KORISNIKSet != null)
            {
                return this.Fill(this.KORISNIKSet);
            }
            this.KORISNIKSet = new KORISNIKDataSet();
            this.Fill(this.KORISNIKSet);
            dataSet.Merge(this.KORISNIKSet);
            return 0;
        }

        public virtual int Fill(KORISNIKDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKORISNIK"]));
        }

        public virtual int Fill(KORISNIKDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKORISNIK"]));
        }

        public virtual int Fill(KORISNIKDataSet dataSet, int iDKORISNIK)
        {
            if (!this.FillByIDKORISNIK(dataSet, iDKORISNIK))
            {
                throw new KORISNIKNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KORISNIK") }));
            }
            return 0;
        }

        public virtual bool FillByIDKORISNIK(KORISNIKDataSet dataSet, int iDKORISNIK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KORISNIKSet = dataSet;
            this.rowKORISNIK = this.KORISNIKSet.KORISNIK.NewKORISNIKRow();
            this.rowKORISNIK.IDKORISNIK = iDKORISNIK;
            try
            {
                this.LoadByIDKORISNIK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound7 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(KORISNIKDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KORISNIKSet = dataSet;
            try
            {
                this.LoadChildKorisnik(startRow, maxRows);
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
            //1.1.15
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKORISNIK], [KORISNIK1NAZIV], [KORISNIK1ADRESA], [KORISNIK1MJESTO], [KORISNIKOIB], [MBKORISNIK], [MBKORISNIKJEDINICA], [JMBGKORISNIK], [KONTAKTOSOBA], [KONTAKTTELEFON], [KONTAKTFAX], [EMAIL], [NADLEZNAPU], [BROJCANAOZNAKAPU], [STAZUKOEFICIJENTU], [RKP], [PREZIMEIMEOVLASTENEOSOBE], [ADRESAOVLASTENEOSOBE], [OIBOVLASTENEOSOBE], [ANALITIKA], [KORISNIK1HZZO], [KORISNIK1NAZIVZANALJEPNICE], [EMAILPOSILJAOCA], [NAZIVPOSILJAOCA], [SMTPSERVER], [OBVEZNIKPDVA], [StopaZaInvalide], [BrojOsoba], [PDVPoNaplacenom], [EmailPassword], [EmailPort] FROM [KORISNIK] WITH (NOLOCK) WHERE [IDKORISNIK] = @IDKORISNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["IDKORISNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound7 = 1;
                this.rowKORISNIK["IDKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowKORISNIK["KORISNIK1NAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowKORISNIK["KORISNIK1ADRESA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowKORISNIK["KORISNIK1MJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowKORISNIK["KORISNIKOIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowKORISNIK["MBKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowKORISNIK["MBKORISNIKJEDINICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowKORISNIK["JMBGKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowKORISNIK["KONTAKTOSOBA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowKORISNIK["KONTAKTTELEFON"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowKORISNIK["KONTAKTFAX"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowKORISNIK["EMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowKORISNIK["NADLEZNAPU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowKORISNIK["BROJCANAOZNAKAPU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 13));
                this.rowKORISNIK["STAZUKOEFICIJENTU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 14));
                this.rowKORISNIK["RKP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 15));
                this.rowKORISNIK["PREZIMEIMEOVLASTENEOSOBE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x10));
                this.rowKORISNIK["ADRESAOVLASTENEOSOBE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x11));
                this.rowKORISNIK["OIBOVLASTENEOSOBE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x12));
                this.rowKORISNIK["ANALITIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x13));
                this.rowKORISNIK["KORISNIK1HZZO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 20));
                this.rowKORISNIK["KORISNIK1NAZIVZANALJEPNICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x15));
                this.rowKORISNIK["EMAILPOSILJAOCA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x16));
                this.rowKORISNIK["NAZIVPOSILJAOCA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x17));
                this.rowKORISNIK["SMTPSERVER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x18));
                this.rowKORISNIK["OBVEZNIKPDVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 0x19));
                //1.1.15
                this.rowKORISNIK["StopaZaInvalide"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x20));
                this.rowKORISNIK["BrojOsoba"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x21));
                this.rowKORISNIK["PDVPoNaplacenom"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 0x22));
                this.rowKORISNIK["EmailPassword"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x23));
                this.rowKORISNIK["EmailPort"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x24));

                #region MBS.Complete
                this.rowKORISNIK["PredPorez"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0x25));
                #endregion

                this.sMode7 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode7;
            }
            else
            {
                this.RcdFound7 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDKORISNIK";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKORISNIKSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [KORISNIK] WITH (NOLOCK) ", false);
            this.KORISNIKSelect1 = this.cmKORISNIKSelect1.FetchData();
            if (this.KORISNIKSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.KORISNIKSelect1.GetInt32(0);
            }
            this.KORISNIKSelect1.Close();
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

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound7 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__POREZIPRIREZZAJEDNICKIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POZIVIZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAZIVZIROOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ULICAZIROOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MJESTOZIROOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIKORISNIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZIROKORISNIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAIZVORAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove61 = false;
            this._Condition = false;
            this.RcdFound77 = 0;
            this.m_SubSelTopString77 = "";
            this.m__KORISNIK1NAZIVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KORISNIK1ADRESAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KORISNIK1MJESTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KORISNIKOIBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MBKORISNIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MBKORISNIKJEDINICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__JMBGKORISNIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KONTAKTOSOBAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KONTAKTTELEFONOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KONTAKTFAXOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__EMAILOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NADLEZNAPUOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJCANAOZNAKAPUOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__STAZUKOEFICIJENTUOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RKPOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PREZIMEIMEOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ADRESAOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OIBOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ANALITIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KORISNIK1HZZOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KORISNIK1NAZIVZANALJEPNICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__EMAILPOSILJAOCAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAZIVPOSILJAOCAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SMTPSERVEROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OBVEZNIKPDVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            //1.1.15
            this.m__BrojOsobaOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDVPoNaplacenomOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__StopaZaInvalideOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__EmailPasswordOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__EmailPortOriginal = RuntimeHelpers.GetObjectValue(new object());

            #region MBS.Complete
            this.m__PredPorezOriginal = RuntimeHelpers.GetObjectValue(new object());
            #endregion


            this.m__JOPPDPodnositeljIzvjescaIDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.KORISNIKSet = new KORISNIKDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertKorisnik()
        {
            this.CheckOptimisticConcurrencyKorisnik();
            this.CheckExtendedTableKorisnik();
            this.AfterConfirmKorisnik();

            //1.1.15
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [KORISNIK] ([IDKORISNIK], [KORISNIK1NAZIV], [KORISNIK1ADRESA], [KORISNIK1MJESTO], [KORISNIKOIB], [MBKORISNIK], [MBKORISNIKJEDINICA], [JMBGKORISNIK], [KONTAKTOSOBA], [KONTAKTTELEFON], [KONTAKTFAX], [EMAIL], [NADLEZNAPU], [BROJCANAOZNAKAPU], [STAZUKOEFICIJENTU], [RKP], [PREZIMEIMEOVLASTENEOSOBE], [ADRESAOVLASTENEOSOBE], [OIBOVLASTENEOSOBE], [ANALITIKA], [KORISNIK1HZZO], [KORISNIK1NAZIVZANALJEPNICE], [EMAILPOSILJAOCA], [NAZIVPOSILJAOCA], [SMTPSERVER], [OBVEZNIKPDVA], [Neprofitni], [StopaZaInvalide], [BrojOsoba], [PDVPoNaplacenom], [EmailPassword], [EmailPort], [PredPorez]) VALUES (@IDKORISNIK, @KORISNIK1NAZIV, @KORISNIK1ADRESA, @KORISNIK1MJESTO, @KORISNIKOIB, @MBKORISNIK, @MBKORISNIKJEDINICA, @JMBGKORISNIK, @KONTAKTOSOBA, @KONTAKTTELEFON, @KONTAKTFAX, @EMAIL, @NADLEZNAPU, @BROJCANAOZNAKAPU, @STAZUKOEFICIJENTU, @RKP, @PREZIMEIMEOVLASTENEOSOBE, @ADRESAOVLASTENEOSOBE, @OIBOVLASTENEOSOBE, @ANALITIKA, @KORISNIK1HZZO, @KORISNIK1NAZIVZANALJEPNICE, @EMAILPOSILJAOCA, @NAZIVPOSILJAOCA, @SMTPSERVER, @OBVEZNIKPDVA, @Neprofitni, @StopaZaInvalide, @BrojOsoba, @PDVPoNaplacenom, @EmailPassword, @EmailPort, @PredPorez)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1NAZIV", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1ADRESA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1MJESTO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIKOIB", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBKORISNIK", DbType.String, 8));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBKORISNIKJEDINICA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBGKORISNIK", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTAKTOSOBA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTAKTTELEFON", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTAKTFAX", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@EMAIL", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NADLEZNAPU", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJCANAOZNAKAPU", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STAZUKOEFICIJENTU", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RKP", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PREZIMEIMEOVLASTENEOSOBE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ADRESAOVLASTENEOSOBE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OIBOVLASTENEOSOBE", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ANALITIKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1HZZO", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1NAZIVZANALJEPNICE", DbType.String, 0x1a));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@EMAILPOSILJAOCA", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOSILJAOCA", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SMTPSERVER", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBVEZNIKPDVA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Neprofitni", DbType.Boolean));

                //1.1.15
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@StopaZaInvalide", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BrojOsoba", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDVPoNaplacenom", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@EmailPassword", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@EmailPort", DbType.String, 150));

                #region MBS.Copmplete
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PredPorez", DbType.Decimal));
                #endregion

            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["IDKORISNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1NAZIV"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1ADRESA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1MJESTO"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIKOIB"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["MBKORISNIK"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["MBKORISNIKJEDINICA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["JMBGKORISNIK"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTOSOBA"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTTELEFON"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTFAX"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EMAIL"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["NADLEZNAPU"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["BROJCANAOZNAKAPU"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["STAZUKOEFICIJENTU"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["RKP"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PREZIMEIMEOVLASTENEOSOBE"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["ADRESAOVLASTENEOSOBE"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["OIBOVLASTENEOSOBE"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["ANALITIKA"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1HZZO"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1NAZIVZANALJEPNICE"]));
            command.SetParameter(0x16, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EMAILPOSILJAOCA"]));
            command.SetParameter(0x17, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["NAZIVPOSILJAOCA"]));
            command.SetParameter(0x18, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["SMTPSERVER"]));
            command.SetParameter(0x19, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["OBVEZNIKPDVA"]));
            command.SetParameter(26, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["Neprofitni"]));

            //1.1.15
            command.SetParameter(27, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["StopaZaInvalide"]));
            command.SetParameter(28, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["BrojOsoba"]));
            command.SetParameter(29, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PDVPoNaplacenom"]));
            command.SetParameter(30, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EmailPassword"]));
            command.SetParameter(31, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EmailPort"]));

            #region MBS.Copmplete
            command.SetParameter(32, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PredPorez"]));
            #endregion


            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new KORISNIKDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnKORISNIKUpdated(new KORISNIKEventArgs(this.rowKORISNIK, StatementType.Insert));
            this.ProcessLevelKorisnik();
        }

        private void InsertKorisniklevel1()
        {
            this.CheckOptimisticConcurrencyKorisniklevel1();
            this.CheckExtendedTableKorisniklevel1();
            this.AfterConfirmKorisniklevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [KORISNIKLevel1] ([IDKORISNIK], [IDZIRO], [POREZIPRIREZZAJEDNICKI], [POZIVIZADUZENJA], [NAZIVZIRO], [ULICAZIRO], [MJESTOZIRO], [VBDIKORISNIK], [ZIROKORISNIK], [SIFRAIZVORA]) VALUES (@IDKORISNIK, @IDZIRO, @POREZIPRIREZZAJEDNICKI, @POZIVIZADUZENJA, @NAZIVZIRO, @ULICAZIRO, @MJESTOZIRO, @VBDIKORISNIK, @ZIROKORISNIK, @SIFRAIZVORA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDZIRO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZIPRIREZZAJEDNICKI", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POZIVIZADUZENJA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVZIRO", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ULICAZIRO", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESTOZIRO", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKORISNIK", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZIROKORISNIK", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDKORISNIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDZIRO"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["POREZIPRIREZZAJEDNICKI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["POZIVIZADUZENJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["NAZIVZIRO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["ULICAZIRO"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["MJESTOZIRO"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["VBDIKORISNIK"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["ZIROKORISNIK"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["SIFRAIZVORA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new KORISNIKLevel1DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnKORISNIKLevel1Updated(new KORISNIKLevel1EventArgs(this.rowKORISNIKLevel1, StatementType.Insert));
        }

        private void LoadByIDKORISNIK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.KORISNIKSet.EnforceConstraints;
            this.KORISNIKSet.KORISNIKLevel1.BeginLoadData();
            this.KORISNIKSet.KORISNIK.BeginLoadData();
            this.ScanByIDKORISNIK(startRow, maxRows);
            this.KORISNIKSet.KORISNIKLevel1.EndLoadData();
            this.KORISNIKSet.KORISNIK.EndLoadData();
            this.KORISNIKSet.EnforceConstraints = enforceConstraints;
            if (this.KORISNIKSet.KORISNIK.Count > 0)
            {
                this.rowKORISNIK = this.KORISNIKSet.KORISNIK[this.KORISNIKSet.KORISNIK.Count - 1];
            }
        }

        private void LoadChildKorisnik(int startRow, int maxRows)
        {
            this.CreateNewRowKorisnik();
            bool enforceConstraints = this.KORISNIKSet.EnforceConstraints;
            this.KORISNIKSet.KORISNIKLevel1.BeginLoadData();
            this.KORISNIKSet.KORISNIK.BeginLoadData();
            this.ScanStartKorisnik(startRow, maxRows);
            this.KORISNIKSet.KORISNIKLevel1.EndLoadData();
            this.KORISNIKSet.KORISNIK.EndLoadData();
            this.KORISNIKSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildKorisniklevel1()
        {
            this.CreateNewRowKorisniklevel1();
            this.ScanStartKorisniklevel1();
        }

        private void LoadDataKorisnik(int maxRows)
        {
            int num = 0;
            if (this.RcdFound7 != 0)
            {
                this.ScanLoadKorisnik();
                while ((this.RcdFound7 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowKorisnik();
                    this.CreateNewRowKorisnik();
                    this.ScanNextKorisnik();
                }
            }
            if (num > 0)
            {
                this.RcdFound7 = 1;
            }
            this.ScanEndKorisnik();
            if (this.KORISNIKSet.KORISNIK.Count > 0)
            {
                this.rowKORISNIK = this.KORISNIKSet.KORISNIK[this.KORISNIKSet.KORISNIK.Count - 1];
            }
        }

        private void LoadDataKorisniklevel1()
        {
            while (this.RcdFound77 != 0)
            {
                this.LoadRowKorisniklevel1();
                this.CreateNewRowKorisniklevel1();
                this.ScanNextKorisniklevel1();
            }
            this.ScanEndKorisniklevel1();
        }

        private void LoadRowKorisnik()
        {
            this.AddRowKorisnik();
        }

        private void LoadRowKorisniklevel1()
        {
            this.AddRowKorisniklevel1();
        }

        private void OnDeleteControlsKorisniklevel1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVIZVORA] FROM [IZVORDOKUMENTA] WITH (NOLOCK) WHERE [SIFRAIZVORA] = @SIFRAIZVORA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["SIFRAIZVORA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowKORISNIKLevel1["NAZIVIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnKORISNIKLevel1Updated(KORISNIKLevel1EventArgs e)
        {
            if (this.KORISNIKLevel1Updated != null)
            {
                KORISNIKLevel1UpdateEventHandler handler = this.KORISNIKLevel1Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnKORISNIKLevel1Updating(KORISNIKLevel1EventArgs e)
        {
            if (this.KORISNIKLevel1Updating != null)
            {
                KORISNIKLevel1UpdateEventHandler handler = this.KORISNIKLevel1Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnKORISNIKUpdated(KORISNIKEventArgs e)
        {
            if (this.KORISNIKUpdated != null)
            {
                KORISNIKUpdateEventHandler kORISNIKUpdatedEvent = this.KORISNIKUpdated;
                if (kORISNIKUpdatedEvent != null)
                {
                    kORISNIKUpdatedEvent(this, e);
                }
            }
        }

        private void OnKORISNIKUpdating(KORISNIKEventArgs e)
        {
            if (this.KORISNIKUpdating != null)
            {
                KORISNIKUpdateEventHandler kORISNIKUpdatingEvent = this.KORISNIKUpdating;
                if (kORISNIKUpdatingEvent != null)
                {
                    kORISNIKUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelKorisnik()
        {
            this.sMode7 = this.Gx_mode;
            this.ProcessNestedLevelKorisniklevel1();
            this.Gx_mode = this.sMode7;
        }

        private void ProcessNestedLevelKorisniklevel1()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.KORISNIKSet.KORISNIKLevel1.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowKORISNIKLevel1 = (KORISNIKDataSet.KORISNIKLevel1Row) current;
                    if (Helpers.IsRowChanged(this.rowKORISNIKLevel1))
                    {
                        bool flag = false;
                        if (this.rowKORISNIKLevel1.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowKORISNIKLevel1.IDKORISNIK == this.rowKORISNIK.IDKORISNIK;
                        }
                        else
                        {
                            flag = this.rowKORISNIKLevel1["IDKORISNIK", DataRowVersion.Original].Equals(this.rowKORISNIK.IDKORISNIK);
                        }
                        if (flag)
                        {
                            this.ReadRowKorisniklevel1();
                            if (this.rowKORISNIKLevel1.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertKorisniklevel1();
                            }
                            else
                            {
                                if (this._Gxremove61)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteKorisniklevel1();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateKorisniklevel1();
                            }
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

        private void ReadRowKorisnik()
        {
            this.Gx_mode = Mode.FromRowState(this.rowKORISNIK.RowState);
            if (this.rowKORISNIK.RowState != DataRowState.Added)
            {
                this.m__KORISNIK1NAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1NAZIV", DataRowVersion.Original]);
                this.m__KORISNIK1ADRESAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1ADRESA", DataRowVersion.Original]);
                this.m__KORISNIK1MJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1MJESTO", DataRowVersion.Original]);
                this.m__KORISNIKOIBOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIKOIB", DataRowVersion.Original]);
                this.m__MBKORISNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["MBKORISNIK", DataRowVersion.Original]);
                this.m__MBKORISNIKJEDINICAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["MBKORISNIKJEDINICA", DataRowVersion.Original]);
                this.m__JMBGKORISNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["JMBGKORISNIK", DataRowVersion.Original]);
                this.m__KONTAKTOSOBAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTOSOBA", DataRowVersion.Original]);
                this.m__KONTAKTTELEFONOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTTELEFON", DataRowVersion.Original]);
                this.m__KONTAKTFAXOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTFAX", DataRowVersion.Original]);
                this.m__EMAILOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EMAIL", DataRowVersion.Original]);
                this.m__NADLEZNAPUOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["NADLEZNAPU", DataRowVersion.Original]);
                this.m__BROJCANAOZNAKAPUOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["BROJCANAOZNAKAPU", DataRowVersion.Original]);
                this.m__STAZUKOEFICIJENTUOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["STAZUKOEFICIJENTU", DataRowVersion.Original]);
                this.m__RKPOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["RKP", DataRowVersion.Original]);
                this.m__PREZIMEIMEOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PREZIMEIMEOVLASTENEOSOBE", DataRowVersion.Original]);
                this.m__ADRESAOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["ADRESAOVLASTENEOSOBE", DataRowVersion.Original]);
                this.m__OIBOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["OIBOVLASTENEOSOBE", DataRowVersion.Original]);
                this.m__ANALITIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["ANALITIKA", DataRowVersion.Original]);
                this.m__KORISNIK1HZZOOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1HZZO", DataRowVersion.Original]);
                this.m__KORISNIK1NAZIVZANALJEPNICEOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1NAZIVZANALJEPNICE", DataRowVersion.Original]);
                this.m__EMAILPOSILJAOCAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EMAILPOSILJAOCA", DataRowVersion.Original]);
                this.m__NAZIVPOSILJAOCAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["NAZIVPOSILJAOCA", DataRowVersion.Original]);
                this.m__SMTPSERVEROriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["SMTPSERVER", DataRowVersion.Original]);
                this.m__OBVEZNIKPDVAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["OBVEZNIKPDVA", DataRowVersion.Original]);
                this.m__NeprofitniOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["Neprofitni", DataRowVersion.Original]);
                
                //1.1.15
                this.m__StopaZaInvalideOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["StopaZaInvalide", DataRowVersion.Original]);
                this.m__BrojOsobaOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["BrojOsoba", DataRowVersion.Original]);
                this.m__PDVPoNaplacenomOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PDVPoNaplacenom", DataRowVersion.Original]);
                this.m__EmailPasswordOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EmailPassword", DataRowVersion.Original]);
                this.m__EmailPortOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EmailPort", DataRowVersion.Original]);

                #region MBS.Complete
                this.m__PredPorezOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PredPorez", DataRowVersion.Original]);
                #endregion

            }
            else
            {
                this.m__KORISNIK1NAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1NAZIV"]);
                this.m__KORISNIK1ADRESAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1ADRESA"]);
                this.m__KORISNIK1MJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1MJESTO"]);
                this.m__KORISNIKOIBOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIKOIB"]);
                this.m__MBKORISNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["MBKORISNIK"]);
                this.m__MBKORISNIKJEDINICAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["MBKORISNIKJEDINICA"]);
                this.m__JMBGKORISNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["JMBGKORISNIK"]);
                this.m__KONTAKTOSOBAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTOSOBA"]);
                this.m__KONTAKTTELEFONOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTTELEFON"]);
                this.m__KONTAKTFAXOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTFAX"]);
                this.m__EMAILOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EMAIL"]);
                this.m__NADLEZNAPUOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["NADLEZNAPU"]);
                this.m__BROJCANAOZNAKAPUOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["BROJCANAOZNAKAPU"]);
                this.m__STAZUKOEFICIJENTUOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["STAZUKOEFICIJENTU"]);
                this.m__RKPOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["RKP"]);
                this.m__PREZIMEIMEOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PREZIMEIMEOVLASTENEOSOBE"]);
                this.m__ADRESAOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["ADRESAOVLASTENEOSOBE"]);
                this.m__OIBOVLASTENEOSOBEOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["OIBOVLASTENEOSOBE"]);
                this.m__ANALITIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["ANALITIKA"]);
                this.m__KORISNIK1HZZOOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1HZZO"]);
                this.m__KORISNIK1NAZIVZANALJEPNICEOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1NAZIVZANALJEPNICE"]);
                this.m__EMAILPOSILJAOCAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EMAILPOSILJAOCA"]);
                this.m__NAZIVPOSILJAOCAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["NAZIVPOSILJAOCA"]);
                this.m__SMTPSERVEROriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["SMTPSERVER"]);
                this.m__OBVEZNIKPDVAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["OBVEZNIKPDVA"]);
                this.m__NeprofitniOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["Neprofitni"]);

                //1.1.15
                this.m__StopaZaInvalideOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["StopaZaInvalide"]);
                this.m__BrojOsobaOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["BrojOsoba"]);
                this.m__PDVPoNaplacenomOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PDVPoNaplacenom"]);
                this.m__EmailPasswordOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EmailPassword"]);
                this.m__EmailPortOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EmailPort"]);

                #region MBS.Complete
                this.m__PredPorezOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PredPorez"]);
                #endregion

            }
            this._Gxremove = this.rowKORISNIK.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowKORISNIK = (KORISNIKDataSet.KORISNIKRow) DataSetUtil.CloneOriginalDataRow(this.rowKORISNIK);
            }
        }

        private void ReadRowKorisniklevel1()
        {
            this.Gx_mode = Mode.FromRowState(this.rowKORISNIKLevel1.RowState);
            if (this.rowKORISNIKLevel1.RowState != DataRowState.Added)
            {
                this.m__POREZIPRIREZZAJEDNICKIOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["POREZIPRIREZZAJEDNICKI", DataRowVersion.Original]);
                this.m__POZIVIZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["POZIVIZADUZENJA", DataRowVersion.Original]);
                this.m__NAZIVZIROOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["NAZIVZIRO", DataRowVersion.Original]);
                this.m__ULICAZIROOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["ULICAZIRO", DataRowVersion.Original]);
                this.m__MJESTOZIROOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["MJESTOZIRO", DataRowVersion.Original]);
                this.m__VBDIKORISNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["VBDIKORISNIK", DataRowVersion.Original]);
                this.m__ZIROKORISNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["ZIROKORISNIK", DataRowVersion.Original]);
                this.m__SIFRAIZVORAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["SIFRAIZVORA", DataRowVersion.Original]);
            }
            else
            {
                this.m__POREZIPRIREZZAJEDNICKIOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["POREZIPRIREZZAJEDNICKI"]);
                this.m__POZIVIZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["POZIVIZADUZENJA"]);
                this.m__NAZIVZIROOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["NAZIVZIRO"]);
                this.m__ULICAZIROOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["ULICAZIRO"]);
                this.m__MJESTOZIROOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["MJESTOZIRO"]);
                this.m__VBDIKORISNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["VBDIKORISNIK"]);
                this.m__ZIROKORISNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["ZIROKORISNIK"]);
                this.m__SIFRAIZVORAOriginal = RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["SIFRAIZVORA"]);
            }
            this._Gxremove61 = this.rowKORISNIKLevel1.RowState == DataRowState.Deleted;
            if (this._Gxremove61)
            {
                this.rowKORISNIKLevel1 = (KORISNIKDataSet.KORISNIKLevel1Row) DataSetUtil.CloneOriginalDataRow(this.rowKORISNIKLevel1);
            }
        }

        private void ScanByIDKORISNIK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDKORISNIK] = @IDKORISNIK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString7 + "  FROM [KORISNIK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKORISNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString7, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKORISNIK] ) AS DK_PAGENUM   FROM [KORISNIK] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString7 + " FROM [KORISNIK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKORISNIK] ";
            }
            this.cmKORISNIKSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmKORISNIKSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmKORISNIKSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
            }
            this.cmKORISNIKSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["IDKORISNIK"]));
            this.KORISNIKSelect4 = this.cmKORISNIKSelect4.FetchData();
            this.RcdFound7 = 0;
            this.ScanLoadKorisnik();
            this.LoadDataKorisnik(maxRows);
            if (this.RcdFound7 > 0)
            {
                this.SubLvlScanStartKorisniklevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDKORISNIKKorisnik(this.cmKORISNIKLevel1Select2);
                this.SubLvlFetchKorisniklevel1();
                this.SubLoadDataKorisniklevel1();
            }
        }

        private void ScanEndKorisnik()
        {
            this.KORISNIKSelect4.Close();
        }

        private void ScanEndKorisniklevel1()
        {
            this.KORISNIKLevel1Select2.Close();
        }

        private void ScanLoadKorisnik()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmKORISNIKSelect4.HasMoreRows)
            {
                this.RcdFound7 = 1;
                this.rowKORISNIK["IDKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KORISNIKSelect4, 0));
                this.rowKORISNIK["KORISNIK1NAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 1));
                this.rowKORISNIK["KORISNIK1ADRESA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 2));
                this.rowKORISNIK["KORISNIK1MJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 3));
                this.rowKORISNIK["KORISNIKOIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 4));
                this.rowKORISNIK["MBKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 5));
                this.rowKORISNIK["MBKORISNIKJEDINICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 6));
                this.rowKORISNIK["JMBGKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 7));
                this.rowKORISNIK["KONTAKTOSOBA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 8));
                this.rowKORISNIK["KONTAKTTELEFON"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 9));
                this.rowKORISNIK["KONTAKTFAX"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 10));
                this.rowKORISNIK["EMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 11));
                this.rowKORISNIK["NADLEZNAPU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 12));
                this.rowKORISNIK["BROJCANAOZNAKAPU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KORISNIKSelect4, 13));
                this.rowKORISNIK["STAZUKOEFICIJENTU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.KORISNIKSelect4, 14));
                this.rowKORISNIK["RKP"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KORISNIKSelect4, 15));
                this.rowKORISNIK["PREZIMEIMEOVLASTENEOSOBE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 0x10));
                this.rowKORISNIK["ADRESAOVLASTENEOSOBE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 0x11));
                this.rowKORISNIK["OIBOVLASTENEOSOBE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 0x12));
                this.rowKORISNIK["ANALITIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KORISNIKSelect4, 0x13));
                this.rowKORISNIK["KORISNIK1HZZO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 20));
                this.rowKORISNIK["KORISNIK1NAZIVZANALJEPNICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 0x15));
                this.rowKORISNIK["EMAILPOSILJAOCA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 0x16));
                this.rowKORISNIK["NAZIVPOSILJAOCA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 0x17));
                this.rowKORISNIK["SMTPSERVER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 0x18));
                this.rowKORISNIK["OBVEZNIKPDVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.KORISNIKSelect4, 0x19));
                this.rowKORISNIK["JOPPDPodnositeljIzvjescaID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KORISNIKSelect4, 26));
                this.rowKORISNIK["Neprofitni"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.KORISNIKSelect4, 27));

                //1.1.15
                this.rowKORISNIK["StopaZaInvalide"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.KORISNIKSelect4, 28));
                this.rowKORISNIK["BrojOsoba"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.KORISNIKSelect4, 29));
                this.rowKORISNIK["PDVPoNaplacenom"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.KORISNIKSelect4, 30));
                this.rowKORISNIK["EmailPassword"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 31));
                this.rowKORISNIK["EmailPort"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKSelect4, 32));

                #region MBS.Complete
                this.rowKORISNIK["PredPorez"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.KORISNIKSelect4, 33));
                #endregion
            }
        }

        private void ScanLoadKorisniklevel1()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmKORISNIKLevel1Select2.HasMoreRows)
            {
                this.RcdFound77 = 1;
                this.rowKORISNIKLevel1["IDKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KORISNIKLevel1Select2, 0));
                this.rowKORISNIKLevel1["IDZIRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KORISNIKLevel1Select2, 1));
                this.rowKORISNIKLevel1["POREZIPRIREZZAJEDNICKI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.KORISNIKLevel1Select2, 2));
                this.rowKORISNIKLevel1["POZIVIZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.KORISNIKLevel1Select2, 3));
                this.rowKORISNIKLevel1["NAZIVZIRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKLevel1Select2, 4));
                this.rowKORISNIKLevel1["ULICAZIRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKLevel1Select2, 5));
                this.rowKORISNIKLevel1["MJESTOZIRO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKLevel1Select2, 6));
                this.rowKORISNIKLevel1["VBDIKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKLevel1Select2, 7));
                this.rowKORISNIKLevel1["ZIROKORISNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKLevel1Select2, 8));
                this.rowKORISNIKLevel1["NAZIVIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKLevel1Select2, 9));
                this.rowKORISNIKLevel1["SIFRAIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKLevel1Select2, 10));
                this.rowKORISNIKLevel1["NAZIVIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KORISNIKLevel1Select2, 9));
            }
        }

        private void ScanNextKorisnik()
        {
            this.cmKORISNIKSelect4.HasMoreRows = this.KORISNIKSelect4.Read();
            this.RcdFound7 = 0;
            this.ScanLoadKorisnik();
        }

        private void ScanNextKorisniklevel1()
        {
            this.cmKORISNIKLevel1Select2.HasMoreRows = this.KORISNIKLevel1Select2.Read();
            this.RcdFound77 = 0;
            this.ScanLoadKorisniklevel1();
        }

        private void ScanStartKorisnik(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString7 + "  FROM [KORISNIK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKORISNIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString7, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKORISNIK] ) AS DK_PAGENUM   FROM [KORISNIK] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString7 + " FROM [KORISNIK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKORISNIK] ";
            }
            this.cmKORISNIKSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.KORISNIKSelect4 = this.cmKORISNIKSelect4.FetchData();
            this.RcdFound7 = 0;
            this.ScanLoadKorisnik();
            this.LoadDataKorisnik(maxRows);
            if (this.RcdFound7 > 0)
            {
                this.SubLvlScanStartKorisniklevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersKorisnikKorisnik(this.cmKORISNIKLevel1Select2);
                this.SubLvlFetchKorisniklevel1();
                this.SubLoadDataKorisniklevel1();
            }
        }

        private void ScanStartKorisniklevel1()
        {
            this.cmKORISNIKLevel1Select2 = this.connDefault.GetCommand("SELECT T1.[IDKORISNIK], T1.[IDZIRO], T1.[POREZIPRIREZZAJEDNICKI], T1.[POZIVIZADUZENJA], T1.[NAZIVZIRO], T1.[ULICAZIRO], T1.[MJESTOZIRO], T1.[VBDIKORISNIK], T1.[ZIROKORISNIK], T2.[NAZIVIZVORA], T1.[SIFRAIZVORA] FROM ([KORISNIKLevel1] T1 WITH (NOLOCK) INNER JOIN [IZVORDOKUMENTA] T2 WITH (NOLOCK) ON T2.[SIFRAIZVORA] = T1.[SIFRAIZVORA]) WHERE T1.[IDKORISNIK] = @IDKORISNIK ORDER BY T1.[IDKORISNIK], T1.[IDZIRO] ", false);
            if (this.cmKORISNIKLevel1Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmKORISNIKLevel1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
            }
            this.cmKORISNIKLevel1Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDKORISNIK"]));
            this.KORISNIKLevel1Select2 = this.cmKORISNIKLevel1Select2.FetchData();
            this.RcdFound77 = 0;
            this.ScanLoadKorisniklevel1();
        }

        private void SetParametersIDKORISNIKKorisnik(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["IDKORISNIK"]));
        }

        private void SetParametersKorisnikKorisnik(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextKorisniklevel1()
        {
            this.cmKORISNIKLevel1Select2.HasMoreRows = this.KORISNIKLevel1Select2.Read();
            this.RcdFound77 = 0;
            if (this.cmKORISNIKLevel1Select2.HasMoreRows)
            {
                this.RcdFound77 = 1;
            }
        }

        private void SubLoadDataKorisniklevel1()
        {
            while (this.RcdFound77 != 0)
            {
                this.LoadRowKorisniklevel1();
                this.CreateNewRowKorisniklevel1();
                this.ScanNextKorisniklevel1();
            }
            this.ScanEndKorisniklevel1();
        }

        private void SubLvlFetchKorisniklevel1()
        {
            this.CreateNewRowKorisniklevel1();
            this.KORISNIKLevel1Select2 = this.cmKORISNIKLevel1Select2.FetchData();
            this.RcdFound77 = 0;
            this.ScanLoadKorisniklevel1();
        }

        private void SubLvlScanStartKorisniklevel1(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString77 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDKORISNIK]  FROM [KORISNIK]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDKORISNIK] )";
                    this.scmdbuf = "SELECT T1.[IDKORISNIK], T1.[IDZIRO], T1.[POREZIPRIREZZAJEDNICKI], T1.[POZIVIZADUZENJA], T1.[NAZIVZIRO], T1.[ULICAZIRO], T1.[MJESTOZIRO], T1.[VBDIKORISNIK], T1.[ZIROKORISNIK], T3.[NAZIVIZVORA], T1.[SIFRAIZVORA] FROM (([KORISNIKLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString77 + "  TMX ON TMX.[IDKORISNIK] = T1.[IDKORISNIK]) INNER JOIN [IZVORDOKUMENTA] T3 WITH (NOLOCK) ON T3.[SIFRAIZVORA] = T1.[SIFRAIZVORA]) ORDER BY T1.[IDKORISNIK], T1.[IDZIRO]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDKORISNIK], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKORISNIK]  ) AS DK_PAGENUM   FROM [KORISNIK]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString77 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDKORISNIK], T1.[IDZIRO], T1.[POREZIPRIREZZAJEDNICKI], T1.[POZIVIZADUZENJA], T1.[NAZIVZIRO], T1.[ULICAZIRO], T1.[MJESTOZIRO], T1.[VBDIKORISNIK], T1.[ZIROKORISNIK], T3.[NAZIVIZVORA], T1.[SIFRAIZVORA] FROM (([KORISNIKLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString77 + "  TMX ON TMX.[IDKORISNIK] = T1.[IDKORISNIK]) INNER JOIN [IZVORDOKUMENTA] T3 WITH (NOLOCK) ON T3.[SIFRAIZVORA] = T1.[SIFRAIZVORA]) ORDER BY T1.[IDKORISNIK], T1.[IDZIRO]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString77 = "[KORISNIK]";
                this.scmdbuf = "SELECT T1.[IDKORISNIK], T1.[IDZIRO], T1.[POREZIPRIREZZAJEDNICKI], T1.[POZIVIZADUZENJA], T1.[NAZIVZIRO], T1.[ULICAZIRO], T1.[MJESTOZIRO], T1.[VBDIKORISNIK], T1.[ZIROKORISNIK], T3.[NAZIVIZVORA], T1.[SIFRAIZVORA] FROM (([KORISNIKLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString77 + "  TM1 WITH (NOLOCK) ON TM1.[IDKORISNIK] = T1.[IDKORISNIK]) INNER JOIN [IZVORDOKUMENTA] T3 WITH (NOLOCK) ON T3.[SIFRAIZVORA] = T1.[SIFRAIZVORA])" + this.m_WhereString + " ORDER BY T1.[IDKORISNIK], T1.[IDZIRO] ";
            }
            this.cmKORISNIKLevel1Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.KORISNIKSet = (KORISNIKDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.KORISNIKSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.KORISNIKSet.KORISNIK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        KORISNIKDataSet.KORISNIKRow current = (KORISNIKDataSet.KORISNIKRow) enumerator.Current;
                        this.rowKORISNIK = current;
                        if (Helpers.IsRowChanged(this.rowKORISNIK))
                        {
                            this.ReadRowKorisnik();
                            if (this.rowKORISNIK.RowState == DataRowState.Added)
                            {
                                this.InsertKorisnik();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateKorisnik();
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

        private void UpdateKorisnik()
        {
            this.CheckOptimisticConcurrencyKorisnik();
            this.CheckExtendedTableKorisnik();
            this.AfterConfirmKorisnik();

            //1.1.15
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [KORISNIK] SET [KORISNIK1NAZIV]=@KORISNIK1NAZIV, [KORISNIK1ADRESA]=@KORISNIK1ADRESA, [KORISNIK1MJESTO]=@KORISNIK1MJESTO, [KORISNIKOIB]=@KORISNIKOIB, [MBKORISNIK]=@MBKORISNIK, [MBKORISNIKJEDINICA]=@MBKORISNIKJEDINICA, [JMBGKORISNIK]=@JMBGKORISNIK, [KONTAKTOSOBA]=@KONTAKTOSOBA, [KONTAKTTELEFON]=@KONTAKTTELEFON, [KONTAKTFAX]=@KONTAKTFAX, [EMAIL]=@EMAIL, [NADLEZNAPU]=@NADLEZNAPU, [BROJCANAOZNAKAPU]=@BROJCANAOZNAKAPU, [STAZUKOEFICIJENTU]=@STAZUKOEFICIJENTU, [RKP]=@RKP, [PREZIMEIMEOVLASTENEOSOBE]=@PREZIMEIMEOVLASTENEOSOBE, [ADRESAOVLASTENEOSOBE]=@ADRESAOVLASTENEOSOBE, [OIBOVLASTENEOSOBE]=@OIBOVLASTENEOSOBE, [ANALITIKA]=@ANALITIKA, [KORISNIK1HZZO]=@KORISNIK1HZZO, [KORISNIK1NAZIVZANALJEPNICE]=@KORISNIK1NAZIVZANALJEPNICE, [EMAILPOSILJAOCA]=@EMAILPOSILJAOCA, [NAZIVPOSILJAOCA]=@NAZIVPOSILJAOCA, [SMTPSERVER]=@SMTPSERVER, [OBVEZNIKPDVA]=@OBVEZNIKPDVA, [JOPPDPodnositeljIzvjescaID]=@JOPPDPodnositeljIzvjescaID, [Neprofitni] = @Neprofitni, [StopaZaInvalide] = @StopaZaInvalide, [BrojOsoba] = @BrojOsoba, [PDVPoNaplacenom] = @PDVPoNaplacenom, [EmailPassword] = @EmailPassword, [EmailPort] = @EmailPort, [PredPorez] = @PredPorez WHERE [IDKORISNIK] = @IDKORISNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1NAZIV", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1ADRESA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1MJESTO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIKOIB", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBKORISNIK", DbType.String, 8));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBKORISNIKJEDINICA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBGKORISNIK", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTAKTOSOBA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTAKTTELEFON", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KONTAKTFAX", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@EMAIL", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NADLEZNAPU", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJCANAOZNAKAPU", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STAZUKOEFICIJENTU", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RKP", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PREZIMEIMEOVLASTENEOSOBE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ADRESAOVLASTENEOSOBE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OIBOVLASTENEOSOBE", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ANALITIKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1HZZO", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KORISNIK1NAZIVZANALJEPNICE", DbType.String, 0x1a));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@EMAILPOSILJAOCA", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOSILJAOCA", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SMTPSERVER", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OBVEZNIKPDVA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JOPPDPodnositeljIzvjescaID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Neprofitni", DbType.Boolean));

                //1.1.15
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@StopaZaInvalide", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BrojOsoba", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDVPoNaplacenom", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@EmailPassword", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@EmailPort", DbType.String, 150));


                #region MBS.Copmplete
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PredPorez", DbType.Decimal));
                #endregion

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1NAZIV"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1ADRESA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1MJESTO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIKOIB"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["MBKORISNIK"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["MBKORISNIKJEDINICA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["JMBGKORISNIK"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTOSOBA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTTELEFON"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KONTAKTFAX"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EMAIL"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["NADLEZNAPU"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["BROJCANAOZNAKAPU"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["STAZUKOEFICIJENTU"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["RKP"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PREZIMEIMEOVLASTENEOSOBE"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["ADRESAOVLASTENEOSOBE"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["OIBOVLASTENEOSOBE"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["ANALITIKA"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1HZZO"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["KORISNIK1NAZIVZANALJEPNICE"]));
            command.SetParameter(0x15, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EMAILPOSILJAOCA"]));
            command.SetParameter(0x16, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["NAZIVPOSILJAOCA"]));
            command.SetParameter(0x17, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["SMTPSERVER"]));
            command.SetParameter(24, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["OBVEZNIKPDVA"]));
            command.SetParameter(25, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["JOPPDPodnositeljIzvjescaID"]));
            command.SetParameter(26, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["Neprofitni"]));

            //1.1.15
            command.SetParameter(27, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["StopaZaInvalide"]));
            command.SetParameter(28, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["BrojOsoba"]));
            command.SetParameter(29, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PDVPoNaplacenom"]));
            command.SetParameter(30, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EmailPassword"]));
            command.SetParameter(31, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["EmailPort"]));

            #region MBS.Complete
            command.SetParameter(32, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["PredPorez"]));
            #endregion


            command.SetParameter(33, RuntimeHelpers.GetObjectValue(this.rowKORISNIK["IDKORISNIK"]));
            command.ExecuteStmt();
            this.OnKORISNIKUpdated(new KORISNIKEventArgs(this.rowKORISNIK, StatementType.Update));
            this.ProcessLevelKorisnik();
        }

        private void UpdateKorisniklevel1()
        {
            this.CheckOptimisticConcurrencyKorisniklevel1();
            this.CheckExtendedTableKorisniklevel1();
            this.AfterConfirmKorisniklevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [KORISNIKLevel1] SET [POREZIPRIREZZAJEDNICKI]=@POREZIPRIREZZAJEDNICKI, [POZIVIZADUZENJA]=@POZIVIZADUZENJA, [NAZIVZIRO]=@NAZIVZIRO, [ULICAZIRO]=@ULICAZIRO, [MJESTOZIRO]=@MJESTOZIRO, [VBDIKORISNIK]=@VBDIKORISNIK, [ZIROKORISNIK]=@ZIROKORISNIK, [SIFRAIZVORA]=@SIFRAIZVORA  WHERE [IDKORISNIK] = @IDKORISNIK AND [IDZIRO] = @IDZIRO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POREZIPRIREZZAJEDNICKI", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POZIVIZADUZENJA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVZIRO", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ULICAZIRO", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESTOZIRO", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKORISNIK", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZIROKORISNIK", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKORISNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDZIRO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["POREZIPRIREZZAJEDNICKI"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["POZIVIZADUZENJA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["NAZIVZIRO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["ULICAZIRO"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["MJESTOZIRO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["VBDIKORISNIK"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["ZIROKORISNIK"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["SIFRAIZVORA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDKORISNIK"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowKORISNIKLevel1["IDZIRO"]));
            command.ExecuteStmt();
            this.OnKORISNIKLevel1Updated(new KORISNIKLevel1EventArgs(this.rowKORISNIKLevel1, StatementType.Update));
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
        public class EMAILInvalidValue : UserException
        {
            public EMAILInvalidValue()
            {
            }

            public EMAILInvalidValue(string message) : base(message)
            {
            }

            protected EMAILInvalidValue(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EMAILInvalidValue(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class greska1 : UserException
        {
            public greska1()
            {
            }

            public greska1(string message) : base(message)
            {
            }

            protected greska1(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public greska1(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class greska2 : UserException
        {
            public greska2()
            {
            }

            public greska2(string message) : base(message)
            {
            }

            protected greska2(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public greska2(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IZVORDOKUMENTAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public IZVORDOKUMENTAForeignKeyNotFoundException()
            {
            }

            public IZVORDOKUMENTAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected IZVORDOKUMENTAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IZVORDOKUMENTAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KORISNIKDataChangedException : DataChangedException
        {
            public KORISNIKDataChangedException()
            {
            }

            public KORISNIKDataChangedException(string message) : base(message)
            {
            }

            protected KORISNIKDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KORISNIKDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KORISNIKDataLockedException : DataLockedException
        {
            public KORISNIKDataLockedException()
            {
            }

            public KORISNIKDataLockedException(string message) : base(message)
            {
            }

            protected KORISNIKDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KORISNIKDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KORISNIKDuplicateKeyException : DuplicateKeyException
        {
            public KORISNIKDuplicateKeyException()
            {
            }

            public KORISNIKDuplicateKeyException(string message) : base(message)
            {
            }

            protected KORISNIKDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KORISNIKDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class KORISNIKEventArgs : EventArgs
        {
            private KORISNIKDataSet.KORISNIKRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public KORISNIKEventArgs(KORISNIKDataSet.KORISNIKRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public KORISNIKDataSet.KORISNIKRow Row
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
        public class KORISNIKLevel1DataChangedException : DataChangedException
        {
            public KORISNIKLevel1DataChangedException()
            {
            }

            public KORISNIKLevel1DataChangedException(string message) : base(message)
            {
            }

            protected KORISNIKLevel1DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KORISNIKLevel1DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KORISNIKLevel1DataLockedException : DataLockedException
        {
            public KORISNIKLevel1DataLockedException()
            {
            }

            public KORISNIKLevel1DataLockedException(string message) : base(message)
            {
            }

            protected KORISNIKLevel1DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KORISNIKLevel1DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KORISNIKLevel1DuplicateKeyException : DuplicateKeyException
        {
            public KORISNIKLevel1DuplicateKeyException()
            {
            }

            public KORISNIKLevel1DuplicateKeyException(string message) : base(message)
            {
            }

            protected KORISNIKLevel1DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KORISNIKLevel1DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class KORISNIKLevel1EventArgs : EventArgs
        {
            private KORISNIKDataSet.KORISNIKLevel1Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public KORISNIKLevel1EventArgs(KORISNIKDataSet.KORISNIKLevel1Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public KORISNIKDataSet.KORISNIKLevel1Row Row
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

        public delegate void KORISNIKLevel1UpdateEventHandler(object sender, KORISNIKDataAdapter.KORISNIKLevel1EventArgs e);

        [Serializable]
        public class KORISNIKNotFoundException : DataNotFoundException
        {
            public KORISNIKNotFoundException()
            {
            }

            public KORISNIKNotFoundException(string message) : base(message)
            {
            }

            protected KORISNIKNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KORISNIKNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void KORISNIKUpdateEventHandler(object sender, KORISNIKDataAdapter.KORISNIKEventArgs e);
    }
}

