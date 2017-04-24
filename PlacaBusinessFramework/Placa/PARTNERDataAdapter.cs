namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Hlp;
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

    public class PARTNERDataAdapter : IDataAdapter, IPARTNERDataAdapter 
    {
        //prikaz ucenik partner
        public static bool prikaz_ucenika = false;

        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove35;
        private ReadWriteCommand cmPARTNERSelect1;
        private ReadWriteCommand cmPARTNERSelect4;
        private ReadWriteCommand cmPARTNERZADUZENJESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__AKTIVNOOriginal;
        private object m__CIJENAZADUZENJAOriginal;
        private object m__DATUMUGOVORAOriginal;
        private object m__IDPROIZVODOriginal;
        private object m__KOLICINAZADUZENJAOriginal;
        private int m__MaxIDZADUZENJE;
        private object m__MBOriginal;
        private object m__NAZIVPARTNEROriginal;
        private object m__PARTNEREMAILOriginal;
        private object m__PARTNERFAXOriginal;
        private object m__PARTNERMJESTOOriginal;
        private object m__PARTNEROIBOriginal;
        private object m__PARTNERTELEFONOriginal;
        private object m__PARTNERULICAOriginal;
        private object m__PARTNERZIRO1Original;
        private object m__PARTNERZIRO2Original;
        private object m__RABATZADUZENJAOriginal;
        private object m__UGOVORBROJOriginal;
        private decimal m_CIJENAZAFAKTURU;
        private decimal m_IZNOSZADUZENJA;
        private readonly string m_SelectString192 = "TM1.[IDPARTNER], TM1.[NAZIVPARTNER], TM1.[MB], TM1.[PARTNERMJESTO], TM1.[PARTNERULICA], TM1.[PARTNEREMAIL], TM1.[PARTNEROIB], TM1.[PARTNERFAX], TM1.[PARTNERTELEFON], TM1.[PARTNERZIRO1], TM1.[PARTNERZIRO2]";
        private string m_SubSelTopString213;
        private string m_WhereString;
        private IDataReader PARTNERSelect1;
        private IDataReader PARTNERSelect4;
        private PARTNERDataSet PARTNERSet;
        private IDataReader PARTNERZADUZENJESelect2;
        private short RcdFound192;
        private short RcdFound213;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private PARTNERDataSet.PARTNERRow rowPARTNER;
        private PARTNERDataSet.PARTNERZADUZENJERow rowPARTNERZADUZENJE;
        private string scmdbuf;
        private StatementType sMode192;
        private StatementType sMode213;

        public event PARTNERUpdateEventHandler PARTNERUpdated;

        public event PARTNERUpdateEventHandler PARTNERUpdating;

        public event PARTNERZADUZENJEUpdateEventHandler PARTNERZADUZENJEUpdated;

        public event PARTNERZADUZENJEUpdateEventHandler PARTNERZADUZENJEUpdating;

        private void AddRowPartner()
        {
            this.PARTNERSet.PARTNER.AddPARTNERRow(this.rowPARTNER);
        }

        private void AddRowPartnerzaduzenje()
        {
            this.PARTNERSet.PARTNERZADUZENJE.AddPARTNERZADUZENJERow(this.rowPARTNERZADUZENJE);
        }

        private void AfterConfirmPartner()
        {
            this.OnPARTNERUpdating(new PARTNEREventArgs(this.rowPARTNER, this.Gx_mode));
        }

        private void AfterConfirmPartnerzaduzenje()
        {
            if (this.rowPARTNERZADUZENJE.IDZADUZENJE < 0)
            {
                this.m__MaxIDZADUZENJE = 0;
                foreach (PARTNERDataSet.PARTNERZADUZENJERow row in this.rowPARTNER.GetPARTNERZADUZENJERows())
                {
                    if (row.IDZADUZENJE > this.m__MaxIDZADUZENJE)
                    {
                        this.m__MaxIDZADUZENJE = row.IDZADUZENJE;
                    }
                }
                this.rowPARTNERZADUZENJE.IDZADUZENJE = this.m__MaxIDZADUZENJE + 1;
            }
            this.OnPARTNERZADUZENJEUpdating(new PARTNERZADUZENJEEventArgs(this.rowPARTNERZADUZENJE, this.Gx_mode));
        }

        private void CheckDeleteErrorsPartner()
        {
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAURA] FROM [SHEMAURA] WITH (NOLOCK) WHERE [PARTNERSHEMAURAIDPARTNER] = @IDPARTNER ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new SHEMAURAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAURA" }));
            }
            reader4.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [URAGODIDGODINE], [URADOKIDDOKUMENT], [URABROJ] FROM [URA] WITH (NOLOCK) WHERE [urapartnerIDPARTNER] = @IDPARTNER ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new URAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "URA" }));
            }
            reader5.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IRAGODIDGODINE], [IRADOKIDDOKUMENT], [IRABROJ] FROM [IRA] WITH (NOLOCK) WHERE [IRAPARTNERIDPARTNER] = @IDPARTNER ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new IRAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "IRA" }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDRACUN], [RACUNGODINAIDGODINE] FROM [RACUN] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new RACUNInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Raeuni" }));
            }
            reader3.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDGKSTAVKA] FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new GKSTAVKAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "GKSTAVKA" }));
            }
            reader.Close();
        }

        private void CheckExtendedTablePartner()
        {
            this.rowPARTNER.PT = this.rowPARTNER.NAZIVPARTNER + " | " + NumberUtil.ToString((long) this.rowPARTNER.IDPARTNER, "");
        }

        private void CheckExtendedTablePartnerzaduzenje()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPROIZVOD], [CIJENA] FROM [PROIZVOD] WITH (NOLOCK) WHERE [IDPROIZVOD] = @IDPROIZVOD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPROIZVOD"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new PROIZVODForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PROIZVOD") }));
            }
            this.rowPARTNERZADUZENJE["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowPARTNERZADUZENJE["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            reader.Close();
            this.m_IZNOSZADUZENJA = decimal.Multiply(this.rowPARTNERZADUZENJE.CIJENAZADUZENJA, this.rowPARTNERZADUZENJE.KOLICINAZADUZENJA);
            this.rowPARTNERZADUZENJE.IZNOSRABATAZADUZENJE = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSZADUZENJA, this.rowPARTNERZADUZENJE.RABATZADUZENJA), 100M));
            if (!this.rowPARTNERZADUZENJE.IsIZNOSRABATAZADUZENJENull())
            {
                this.m_CIJENAZAFAKTURU = decimal.Subtract(this.m_IZNOSZADUZENJA, this.rowPARTNERZADUZENJE.IZNOSRABATAZADUZENJE);
            }
        }

        private void CheckOptimisticConcurrencyPartner()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPARTNER], [NAZIVPARTNER], [MB], [PARTNERMJESTO], [PARTNERULICA], [PARTNEREMAIL], [PARTNEROIB], [PARTNERFAX], [PARTNERTELEFON], [PARTNERZIRO1], [PARTNERZIRO2] FROM [PARTNER] WITH (UPDLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PARTNERDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PARTNER") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVPARTNEROriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MBOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTNERMJESTOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTNERULICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTNEREMAILOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTNEROIBOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTNERFAXOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTNERTELEFONOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTNERZIRO1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PARTNERZIRO2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    reader.Close();
                    throw new PARTNERDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PARTNER") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyPartnerzaduzenje()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPARTNER], [IDZADUZENJE], [KOLICINAZADUZENJA], [CIJENAZADUZENJA], [RABATZADUZENJA], [UGOVORBROJ], [DATUMUGOVORA], [AKTIVNO], [IDPROIZVOD] FROM [PARTNERZADUZENJE] WITH (UPDLOCK) WHERE [IDPARTNER] = @IDPARTNER AND [IDZADUZENJE] = @IDZADUZENJE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDZADUZENJE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPARTNER"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDZADUZENJE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PARTNERZADUZENJEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PARTNERZADUZENJE") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !this.m__KOLICINAZADUZENJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || ((!this.m__CIJENAZADUZENJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || !this.m__RABATZADUZENJAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__UGOVORBROJOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))) || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMUGOVORAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 6))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__AKTIVNOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 7)))) || !this.m__IDPROIZVODOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 8))))
                {
                    reader.Close();
                    throw new PARTNERZADUZENJEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PARTNERZADUZENJE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowPartner()
        {
            this.rowPARTNER = this.PARTNERSet.PARTNER.NewPARTNERRow();
        }

        private void CreateNewRowPartnerzaduzenje()
        {
            this.rowPARTNERZADUZENJE = this.PARTNERSet.PARTNERZADUZENJE.NewPARTNERZADUZENJERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPartner();
            this.OnDeleteControlsPartner();
            this.ProcessNestedLevelPartnerzaduzenje();
            this.AfterConfirmPartner();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PARTNER]  WHERE [IDPARTNER] = @IDPARTNER", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsPartner();
            }
            this.OnPARTNERUpdated(new PARTNEREventArgs(this.rowPARTNER, StatementType.Delete));
            this.rowPARTNER.Delete();
            this.sMode192 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode192;
        }

        private void DeletePartnerzaduzenje()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPartnerzaduzenje();
            this.OnDeleteControlsPartnerzaduzenje();
            this.AfterConfirmPartnerzaduzenje();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PARTNERZADUZENJE]  WHERE [IDPARTNER] = @IDPARTNER AND [IDZADUZENJE] = @IDZADUZENJE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDZADUZENJE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPARTNER"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDZADUZENJE"]));
            command.ExecuteStmt();
            this.OnPARTNERZADUZENJEUpdated(new PARTNERZADUZENJEEventArgs(this.rowPARTNERZADUZENJE, StatementType.Delete));
            this.rowPARTNERZADUZENJE.Delete();
            this.sMode213 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode213;
        }

        public virtual int Fill(PARTNERDataSet dataSet)
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
                    this.PARTNERSet = dataSet;
                    this.LoadChildPartner(0, -1);
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
            this.PARTNERSet = (PARTNERDataSet) dataSet;
            if (this.PARTNERSet != null)
            {
                return this.Fill(this.PARTNERSet);
            }
            this.PARTNERSet = new PARTNERDataSet();
            this.Fill(this.PARTNERSet);
            dataSet.Merge(this.PARTNERSet);
            return 0;
        }

        public virtual int Fill(PARTNERDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPARTNER"]));
        }

        public virtual int Fill(PARTNERDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPARTNER"]));
        }

        public virtual int Fill(PARTNERDataSet dataSet, int iDPARTNER)
        {
            if (!this.FillByIDPARTNER(dataSet, iDPARTNER))
            {
                throw new PARTNERNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PARTNER") }));
            }
            return 0;
        }

        public virtual bool FillByIDPARTNER(PARTNERDataSet dataSet, int iDPARTNER)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PARTNERSet = dataSet;
            this.rowPARTNER = this.PARTNERSet.PARTNER.NewPARTNERRow();
            this.rowPARTNER.IDPARTNER = iDPARTNER;
            try
            {
                this.LoadByIDPARTNER(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound192 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(PARTNERDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PARTNERSet = dataSet;
            try
            {
                this.LoadChildPartner(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPARTNER], [NAZIVPARTNER], [MB], [PARTNERMJESTO], [PARTNERULICA], [PARTNEREMAIL], [PARTNEROIB], [PARTNERFAX], [PARTNERTELEFON], [PARTNERZIRO1], [PARTNERZIRO2] FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound192 = 1;
                this.rowPARTNER["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowPARTNER["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))));
                this.rowPARTNER["MB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowPARTNER["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowPARTNER["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowPARTNER["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowPARTNER["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowPARTNER["PARTNERFAX"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowPARTNER["PARTNERTELEFON"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowPARTNER["PARTNERZIRO1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowPARTNER["PARTNERZIRO2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.sMode192 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadPartner();
                this.Gx_mode = this.sMode192;
            }
            else
            {
                this.RcdFound192 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDPARTNER";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPARTNERSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PARTNER] WITH (NOLOCK) ", false);
            this.PARTNERSelect1 = this.cmPARTNERSelect1.FetchData();
            if (this.PARTNERSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PARTNERSelect1.GetInt32(0);
            }
            this.PARTNERSelect1.Close();
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
            this.RcdFound192 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_IZNOSZADUZENJA = new decimal();
            this.m_CIJENAZAFAKTURU = new decimal();
            this.m__KOLICINAZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__CIJENAZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RABATZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__UGOVORBROJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMUGOVORAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__AKTIVNOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDPROIZVODOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove35 = false;
            this._Condition = false;
            this.RcdFound213 = 0;
            this.m_SubSelTopString213 = "";
            this.m__MaxIDZADUZENJE = 0;
            this.m__NAZIVPARTNEROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNERMJESTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNERULICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNEREMAILOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNEROIBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNERFAXOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNERTELEFONOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNERZIRO1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNERZIRO2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.PARTNERSet = new PARTNERDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertPartner()
        {
            this.CheckOptimisticConcurrencyPartner();
            this.CheckExtendedTablePartner();
            this.AfterConfirmPartner();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PARTNER] ([IDPARTNER], [NAZIVPARTNER], [MB], [PARTNERMJESTO], [PARTNERULICA], [PARTNEREMAIL], [PARTNEROIB], [PARTNERFAX], [PARTNERTELEFON], [PARTNERZIRO1], [PARTNERZIRO2], [Ucenik]) VALUES (@IDPARTNER, @NAZIVPARTNER, @MB, @PARTNERMJESTO, @PARTNERULICA, @PARTNEREMAIL, @PARTNEROIB, @PARTNERFAX, @PARTNERTELEFON, @PARTNERZIRO1, @PARTNERZIRO2, @Ucenik)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPARTNER", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MB", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERMJESTO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERULICA", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNEREMAIL", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNEROIB", DbType.String, 25));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERFAX", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERTELEFON", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERZIRO1", DbType.String, 0x12));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERZIRO2", DbType.String, 0x12));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Ucenik", DbType.Int32, 0x12));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowPARTNER["NAZIVPARTNER"]))));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPARTNER["MB"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERMJESTO"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERULICA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNEREMAIL"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNEROIB"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERFAX"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERTELEFON"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERZIRO1"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERZIRO2"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(0));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PARTNERDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPARTNERUpdated(new PARTNEREventArgs(this.rowPARTNER, StatementType.Insert));
            this.ProcessLevelPartner();
        }

        private void InsertPartnerzaduzenje()
        {
            this.CheckOptimisticConcurrencyPartnerzaduzenje();
            this.CheckExtendedTablePartnerzaduzenje();
            this.AfterConfirmPartnerzaduzenje();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PARTNERZADUZENJE] ([IDPARTNER], [IDZADUZENJE], [KOLICINAZADUZENJA], [CIJENAZADUZENJA], [RABATZADUZENJA], [UGOVORBROJ], [DATUMUGOVORA], [AKTIVNO], [IDPROIZVOD]) VALUES (@IDPARTNER, @IDZADUZENJE, @KOLICINAZADUZENJA, @CIJENAZADUZENJA, @RABATZADUZENJA, @UGOVORBROJ, @DATUMUGOVORA, @AKTIVNO, @IDPROIZVOD)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDZADUZENJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLICINAZADUZENJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CIJENAZADUZENJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RABATZADUZENJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UGOVORBROJ", DbType.String, 200));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AKTIVNO", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPARTNER"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDZADUZENJE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["KOLICINAZADUZENJA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["CIJENAZADUZENJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["RABATZADUZENJA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["UGOVORBROJ"]));
            command.SetParameterDateObject(6, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["DATUMUGOVORA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["AKTIVNO"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPROIZVOD"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PARTNERZADUZENJEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPARTNERZADUZENJEUpdated(new PARTNERZADUZENJEEventArgs(this.rowPARTNERZADUZENJE, StatementType.Insert));
        }

        private void LoadByIDPARTNER(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PARTNERSet.EnforceConstraints;
            this.PARTNERSet.PARTNERZADUZENJE.BeginLoadData();
            this.PARTNERSet.PARTNER.BeginLoadData();
            this.ScanByIDPARTNER(startRow, maxRows);
            this.PARTNERSet.PARTNERZADUZENJE.EndLoadData();
            this.PARTNERSet.PARTNER.EndLoadData();
            this.PARTNERSet.EnforceConstraints = enforceConstraints;
            if (this.PARTNERSet.PARTNER.Count > 0)
            {
                this.rowPARTNER = this.PARTNERSet.PARTNER[this.PARTNERSet.PARTNER.Count - 1];
            }
        }

        private void LoadChildPartner(int startRow, int maxRows)
        {
            this.CreateNewRowPartner();
            bool enforceConstraints = this.PARTNERSet.EnforceConstraints;
            this.PARTNERSet.PARTNERZADUZENJE.BeginLoadData();
            this.PARTNERSet.PARTNER.BeginLoadData();
            this.ScanStartPartner(startRow, maxRows);
            this.PARTNERSet.PARTNERZADUZENJE.EndLoadData();
            this.PARTNERSet.PARTNER.EndLoadData();
            this.PARTNERSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildPartnerzaduzenje()
        {
            this.CreateNewRowPartnerzaduzenje();
            this.ScanStartPartnerzaduzenje();
        }

        private void LoadDataPartner(int maxRows)
        {
            int num = 0;
            if (this.RcdFound192 != 0)
            {
                this.ScanLoadPartner();
                while ((this.RcdFound192 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowPartner();
                    this.CreateNewRowPartner();
                    this.ScanNextPartner();
                }
            }
            if (num > 0)
            {
                this.RcdFound192 = 1;
            }
            this.ScanEndPartner();
            if (this.PARTNERSet.PARTNER.Count > 0)
            {
                this.rowPARTNER = this.PARTNERSet.PARTNER[this.PARTNERSet.PARTNER.Count - 1];
            }
        }

        private void LoadDataPartnerzaduzenje()
        {
            while (this.RcdFound213 != 0)
            {
                this.LoadRowPartnerzaduzenje();
                this.CreateNewRowPartnerzaduzenje();
                this.ScanNextPartnerzaduzenje();
            }
            this.ScanEndPartnerzaduzenje();
        }

        private void LoadPartner()
        {
            this.rowPARTNER.PT = this.rowPARTNER.NAZIVPARTNER + " | " + NumberUtil.ToString((long) this.rowPARTNER.IDPARTNER, "");
        }

        private void LoadRowPartner()
        {
            this.OnLoadActionsPartner();
            this.AddRowPartner();
        }

        private void LoadRowPartnerzaduzenje()
        {
            this.OnLoadActionsPartnerzaduzenje();
            this.AddRowPartnerzaduzenje();
        }

        private void OnDeleteControlsPartner()
        {
            this.rowPARTNER.PT = this.rowPARTNER.NAZIVPARTNER + " | " + NumberUtil.ToString((long) this.rowPARTNER.IDPARTNER, "");
        }

        private void OnDeleteControlsPartnerzaduzenje()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPROIZVOD], [CIJENA] FROM [PROIZVOD] WITH (NOLOCK) WHERE [IDPROIZVOD] = @IDPROIZVOD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPROIZVOD"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowPARTNERZADUZENJE["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowPARTNERZADUZENJE["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            }
            reader.Close();
            this.m_IZNOSZADUZENJA = decimal.Multiply(this.rowPARTNERZADUZENJE.CIJENAZADUZENJA, this.rowPARTNERZADUZENJE.KOLICINAZADUZENJA);
            this.rowPARTNERZADUZENJE.IZNOSRABATAZADUZENJE = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSZADUZENJA, this.rowPARTNERZADUZENJE.RABATZADUZENJA), 100M));
            if (!this.rowPARTNERZADUZENJE.IsIZNOSRABATAZADUZENJENull())
            {
                this.m_CIJENAZAFAKTURU = decimal.Subtract(this.m_IZNOSZADUZENJA, this.rowPARTNERZADUZENJE.IZNOSRABATAZADUZENJE);
            }
        }

        private void OnLoadActionsPartner()
        {
            this.rowPARTNER.PT = this.rowPARTNER.NAZIVPARTNER + " | " + NumberUtil.ToString((long) this.rowPARTNER.IDPARTNER, "");
        }

        private void OnLoadActionsPartnerzaduzenje()
        {
            this.m_IZNOSZADUZENJA = decimal.Multiply(this.rowPARTNERZADUZENJE.CIJENAZADUZENJA, this.rowPARTNERZADUZENJE.KOLICINAZADUZENJA);
            this.rowPARTNERZADUZENJE.IZNOSRABATAZADUZENJE = DB.RoundUP(decimal.Divide(decimal.Multiply(this.m_IZNOSZADUZENJA, this.rowPARTNERZADUZENJE.RABATZADUZENJA), 100M));
            if (!this.rowPARTNERZADUZENJE.IsIZNOSRABATAZADUZENJENull())
            {
                this.m_CIJENAZAFAKTURU = decimal.Subtract(this.m_IZNOSZADUZENJA, this.rowPARTNERZADUZENJE.IZNOSRABATAZADUZENJE);
            }
        }

        private void OnPARTNERUpdated(PARTNEREventArgs e)
        {
            if (this.PARTNERUpdated != null)
            {
                PARTNERUpdateEventHandler pARTNERUpdatedEvent = this.PARTNERUpdated;
                if (pARTNERUpdatedEvent != null)
                {
                    pARTNERUpdatedEvent(this, e);
                }
            }
        }

        private void OnPARTNERUpdating(PARTNEREventArgs e)
        {
            if (this.PARTNERUpdating != null)
            {
                PARTNERUpdateEventHandler pARTNERUpdatingEvent = this.PARTNERUpdating;
                if (pARTNERUpdatingEvent != null)
                {
                    pARTNERUpdatingEvent(this, e);
                }
            }
        }

        private void OnPARTNERZADUZENJEUpdated(PARTNERZADUZENJEEventArgs e)
        {
            if (this.PARTNERZADUZENJEUpdated != null)
            {
                PARTNERZADUZENJEUpdateEventHandler pARTNERZADUZENJEUpdatedEvent = this.PARTNERZADUZENJEUpdated;
                if (pARTNERZADUZENJEUpdatedEvent != null)
                {
                    pARTNERZADUZENJEUpdatedEvent(this, e);
                }
            }
        }

        private void OnPARTNERZADUZENJEUpdating(PARTNERZADUZENJEEventArgs e)
        {
            if (this.PARTNERZADUZENJEUpdating != null)
            {
                PARTNERZADUZENJEUpdateEventHandler pARTNERZADUZENJEUpdatingEvent = this.PARTNERZADUZENJEUpdating;
                if (pARTNERZADUZENJEUpdatingEvent != null)
                {
                    pARTNERZADUZENJEUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelPartner()
        {
            this.sMode192 = this.Gx_mode;
            this.ProcessNestedLevelPartnerzaduzenje();
            this.Gx_mode = this.sMode192;
        }

        private void ProcessNestedLevelPartnerzaduzenje()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.PARTNERSet.PARTNERZADUZENJE.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowPARTNERZADUZENJE = (PARTNERDataSet.PARTNERZADUZENJERow) current;
                    if (Helpers.IsRowChanged(this.rowPARTNERZADUZENJE))
                    {
                        bool flag = false;
                        if (this.rowPARTNERZADUZENJE.RowState != DataRowState.Deleted)
                        {
                            this.rowPARTNERZADUZENJE["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["DATUMUGOVORA"])));
                        }
                        if (this.rowPARTNERZADUZENJE.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowPARTNERZADUZENJE.IDPARTNER == this.rowPARTNER.IDPARTNER;
                        }
                        else
                        {
                            flag = this.rowPARTNERZADUZENJE["IDPARTNER", DataRowVersion.Original].Equals(this.rowPARTNER.IDPARTNER);
                        }
                        if (flag)
                        {
                            this.ReadRowPartnerzaduzenje();
                            if (this.rowPARTNERZADUZENJE.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertPartnerzaduzenje();
                            }
                            else
                            {
                                if (this._Gxremove35)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeletePartnerzaduzenje();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdatePartnerzaduzenje();
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

        private void ReadRowPartner()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPARTNER.RowState);
            if (this.rowPARTNER.RowState != DataRowState.Added)
            {
                this.m__NAZIVPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["NAZIVPARTNER", DataRowVersion.Original]);
                this.m__MBOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["MB", DataRowVersion.Original]);
                this.m__PARTNERMJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERMJESTO", DataRowVersion.Original]);
                this.m__PARTNERULICAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERULICA", DataRowVersion.Original]);
                this.m__PARTNEREMAILOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNEREMAIL", DataRowVersion.Original]);
                this.m__PARTNEROIBOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNEROIB", DataRowVersion.Original]);
                this.m__PARTNERFAXOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERFAX", DataRowVersion.Original]);
                this.m__PARTNERTELEFONOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERTELEFON", DataRowVersion.Original]);
                this.m__PARTNERZIRO1Original = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERZIRO1", DataRowVersion.Original]);
                this.m__PARTNERZIRO2Original = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERZIRO2", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["NAZIVPARTNER"]);
                this.m__MBOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["MB"]);
                this.m__PARTNERMJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERMJESTO"]);
                this.m__PARTNERULICAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERULICA"]);
                this.m__PARTNEREMAILOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNEREMAIL"]);
                this.m__PARTNEROIBOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNEROIB"]);
                this.m__PARTNERFAXOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERFAX"]);
                this.m__PARTNERTELEFONOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERTELEFON"]);
                this.m__PARTNERZIRO1Original = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERZIRO1"]);
                this.m__PARTNERZIRO2Original = RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERZIRO2"]);
            }
            this._Gxremove = this.rowPARTNER.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPARTNER = (PARTNERDataSet.PARTNERRow) DataSetUtil.CloneOriginalDataRow(this.rowPARTNER);
            }
        }

        private void ReadRowPartnerzaduzenje()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPARTNERZADUZENJE.RowState);
            if (this.rowPARTNERZADUZENJE.RowState != DataRowState.Added)
            {
                this.m__KOLICINAZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["KOLICINAZADUZENJA", DataRowVersion.Original]);
                this.m__CIJENAZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["CIJENAZADUZENJA", DataRowVersion.Original]);
                this.m__RABATZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["RABATZADUZENJA", DataRowVersion.Original]);
                this.m__UGOVORBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["UGOVORBROJ", DataRowVersion.Original]);
                this.m__DATUMUGOVORAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["DATUMUGOVORA", DataRowVersion.Original]);
                this.m__AKTIVNOOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["AKTIVNO", DataRowVersion.Original]);
                this.m__IDPROIZVODOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPROIZVOD", DataRowVersion.Original]);
            }
            else
            {
                this.m__KOLICINAZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["KOLICINAZADUZENJA"]);
                this.m__CIJENAZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["CIJENAZADUZENJA"]);
                this.m__RABATZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["RABATZADUZENJA"]);
                this.m__UGOVORBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["UGOVORBROJ"]);
                this.m__DATUMUGOVORAOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["DATUMUGOVORA"]);
                this.m__AKTIVNOOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["AKTIVNO"]);
                this.m__IDPROIZVODOriginal = RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPROIZVOD"]);
            }
            this._Gxremove35 = this.rowPARTNERZADUZENJE.RowState == DataRowState.Deleted;
            if (this._Gxremove35)
            {
                this.rowPARTNERZADUZENJE = (PARTNERDataSet.PARTNERZADUZENJERow) DataSetUtil.CloneOriginalDataRow(this.rowPARTNERZADUZENJE);
            }
        }

        private void ScanByIDPARTNER(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDPARTNER] = @IDPARTNER";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString192 + "  FROM [PARTNER] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPARTNER]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString192, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPARTNER] ) AS DK_PAGENUM   FROM [PARTNER] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString192 + " FROM [PARTNER] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPARTNER] ";
            }
            this.cmPARTNERSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPARTNERSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmPARTNERSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmPARTNERSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            this.PARTNERSelect4 = this.cmPARTNERSelect4.FetchData();
            this.RcdFound192 = 0;
            this.ScanLoadPartner();
            this.LoadDataPartner(maxRows);
            if (this.RcdFound192 > 0)
            {
                this.SubLvlScanStartPartnerzaduzenje(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDPARTNERPartner(this.cmPARTNERZADUZENJESelect2);
                this.SubLvlFetchPartnerzaduzenje();
                this.SubLoadDataPartnerzaduzenje();
            }
        }

        private void ScanEndPartner()
        {
            this.PARTNERSelect4.Close();
        }

        private void ScanEndPartnerzaduzenje()
        {
            this.PARTNERZADUZENJESelect2.Close();
        }

        private void ScanLoadPartner()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPARTNERSelect4.HasMoreRows)
            {
                this.RcdFound192 = 1;
                this.rowPARTNER["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PARTNERSelect4, 0));
                this.rowPARTNER["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 1))));
                this.rowPARTNER["MB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 2));
                this.rowPARTNER["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 3));
                this.rowPARTNER["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 4));
                this.rowPARTNER["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 5));
                this.rowPARTNER["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 6));
                this.rowPARTNER["PARTNERFAX"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 7));
                this.rowPARTNER["PARTNERTELEFON"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 8));
                this.rowPARTNER["PARTNERZIRO1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 9));
                this.rowPARTNER["PARTNERZIRO2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERSelect4, 10));
            }
        }

        private void ScanLoadPartnerzaduzenje()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPARTNERZADUZENJESelect2.HasMoreRows)
            {
                this.RcdFound213 = 1;
                this.rowPARTNERZADUZENJE["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PARTNERZADUZENJESelect2, 0));
                this.rowPARTNERZADUZENJE["IDZADUZENJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PARTNERZADUZENJESelect2, 1));
                this.rowPARTNERZADUZENJE["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 2));
                this.rowPARTNERZADUZENJE["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 3));
                this.rowPARTNERZADUZENJE["KOLICINAZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 4));
                this.rowPARTNERZADUZENJE["CIJENAZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 5));
                this.rowPARTNERZADUZENJE["RABATZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 6));
                this.rowPARTNERZADUZENJE["UGOVORBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 7));
                this.rowPARTNERZADUZENJE["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.PARTNERZADUZENJESelect2, 8));
                this.rowPARTNERZADUZENJE["AKTIVNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.PARTNERZADUZENJESelect2, 9));
                this.rowPARTNERZADUZENJE["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PARTNERZADUZENJESelect2, 10));
                this.rowPARTNERZADUZENJE["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PARTNERZADUZENJESelect2, 2));
                this.rowPARTNERZADUZENJE["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PARTNERZADUZENJESelect2, 3));
            }
        }

        private void ScanNextPartner()
        {
            this.cmPARTNERSelect4.HasMoreRows = this.PARTNERSelect4.Read();
            this.RcdFound192 = 0;
            this.ScanLoadPartner();
        }

        private void ScanNextPartnerzaduzenje()
        {
            this.cmPARTNERZADUZENJESelect2.HasMoreRows = this.PARTNERZADUZENJESelect2.Read();
            this.RcdFound213 = 0;
            this.ScanLoadPartnerzaduzenje();
        }

        private void ScanStartPartner(int startRow, int maxRows)
        {
            if (prikaz_ucenika)
                this.m_WhereString = " WHERE UCENIK = '1' And (PARTNERZIRO2 <> 'false' OR PARTNERZIRO2 is NULL)";
            else
                this.m_WhereString = " WHERE UCENIK IN (0,2)";


            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString192 + "  FROM [PARTNER] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPARTNER]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString192, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPARTNER] ) AS DK_PAGENUM   FROM [PARTNER] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString192 + " FROM [PARTNER] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPARTNER] ";
            }
            this.cmPARTNERSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.PARTNERSelect4 = this.cmPARTNERSelect4.FetchData();
            this.RcdFound192 = 0;
            this.ScanLoadPartner();
            this.LoadDataPartner(maxRows);
            if (this.RcdFound192 > 0)
            {
                this.SubLvlScanStartPartnerzaduzenje(this.m_WhereString, startRow, maxRows);
                this.SetParametersPartnerPartner(this.cmPARTNERZADUZENJESelect2);
                this.SubLvlFetchPartnerzaduzenje();
                this.SubLoadDataPartnerzaduzenje();
            }
        }

        private void ScanStartPartnerzaduzenje()
        {
            this.cmPARTNERZADUZENJESelect2 = this.connDefault.GetCommand("SELECT T1.[IDPARTNER], T1.[IDZADUZENJE], T2.[NAZIVPROIZVOD], T2.[CIJENA], T1.[KOLICINAZADUZENJA], T1.[CIJENAZADUZENJA], T1.[RABATZADUZENJA], T1.[UGOVORBROJ], T1.[DATUMUGOVORA], T1.[AKTIVNO], T1.[IDPROIZVOD] FROM ([PARTNERZADUZENJE] T1 WITH (NOLOCK) INNER JOIN [PROIZVOD] T2 WITH (NOLOCK) ON T2.[IDPROIZVOD] = T1.[IDPROIZVOD]) WHERE T1.[IDPARTNER] = @IDPARTNER ORDER BY T1.[IDPARTNER], T1.[IDZADUZENJE] ", false);
            if (this.cmPARTNERZADUZENJESelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPARTNERZADUZENJESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmPARTNERZADUZENJESelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPARTNER"]));
            this.PARTNERZADUZENJESelect2 = this.cmPARTNERZADUZENJESelect2.FetchData();
            this.RcdFound213 = 0;
            this.ScanLoadPartnerzaduzenje();
        }

        private void SetParametersIDPARTNERPartner(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
        }

        private void SetParametersPartnerPartner(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextPartnerzaduzenje()
        {
            this.cmPARTNERZADUZENJESelect2.HasMoreRows = this.PARTNERZADUZENJESelect2.Read();
            this.RcdFound213 = 0;
            if (this.cmPARTNERZADUZENJESelect2.HasMoreRows)
            {
                this.RcdFound213 = 1;
            }
        }

        private void SubLoadDataPartnerzaduzenje()
        {
            while (this.RcdFound213 != 0)
            {
                this.LoadRowPartnerzaduzenje();
                this.CreateNewRowPartnerzaduzenje();
                this.ScanNextPartnerzaduzenje();
            }
            this.ScanEndPartnerzaduzenje();
        }

        private void SubLvlFetchPartnerzaduzenje()
        {
            this.CreateNewRowPartnerzaduzenje();
            this.PARTNERZADUZENJESelect2 = this.cmPARTNERZADUZENJESelect2.FetchData();
            this.RcdFound213 = 0;
            this.ScanLoadPartnerzaduzenje();
        }

        private void SubLvlScanStartPartnerzaduzenje(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString213 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDPARTNER]  FROM [PARTNER]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDPARTNER] )";
                    this.scmdbuf = "SELECT T1.[IDPARTNER], T1.[IDZADUZENJE], T3.[NAZIVPROIZVOD], T3.[CIJENA], T1.[KOLICINAZADUZENJA], T1.[CIJENAZADUZENJA], T1.[RABATZADUZENJA], T1.[UGOVORBROJ], T1.[DATUMUGOVORA], T1.[AKTIVNO], T1.[IDPROIZVOD] FROM (([PARTNERZADUZENJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString213 + "  TMX ON TMX.[IDPARTNER] = T1.[IDPARTNER]) INNER JOIN [PROIZVOD] T3 WITH (NOLOCK) ON T3.[IDPROIZVOD] = T1.[IDPROIZVOD]) ORDER BY T1.[IDPARTNER], T1.[IDZADUZENJE]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDPARTNER], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPARTNER]  ) AS DK_PAGENUM   FROM [PARTNER]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString213 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDPARTNER], T1.[IDZADUZENJE], T3.[NAZIVPROIZVOD], T3.[CIJENA], T1.[KOLICINAZADUZENJA], T1.[CIJENAZADUZENJA], T1.[RABATZADUZENJA], T1.[UGOVORBROJ], T1.[DATUMUGOVORA], T1.[AKTIVNO], T1.[IDPROIZVOD] FROM (([PARTNERZADUZENJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString213 + "  TMX ON TMX.[IDPARTNER] = T1.[IDPARTNER]) INNER JOIN [PROIZVOD] T3 WITH (NOLOCK) ON T3.[IDPROIZVOD] = T1.[IDPROIZVOD]) ORDER BY T1.[IDPARTNER], T1.[IDZADUZENJE]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString213 = "[PARTNER]";
                this.scmdbuf = "SELECT T1.[IDPARTNER], T1.[IDZADUZENJE], T3.[NAZIVPROIZVOD], T3.[CIJENA], T1.[KOLICINAZADUZENJA], T1.[CIJENAZADUZENJA], T1.[RABATZADUZENJA], T1.[UGOVORBROJ], T1.[DATUMUGOVORA], T1.[AKTIVNO], T1.[IDPROIZVOD] FROM (([PARTNERZADUZENJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString213 + "  TM1 WITH (NOLOCK) ON TM1.[IDPARTNER] = T1.[IDPARTNER]) INNER JOIN [PROIZVOD] T3 WITH (NOLOCK) ON T3.[IDPROIZVOD] = T1.[IDPROIZVOD])" + this.m_WhereString + " ORDER BY T1.[IDPARTNER], T1.[IDZADUZENJE] ";
            }
            this.cmPARTNERZADUZENJESelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.PARTNERSet = (PARTNERDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.PARTNERSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.PARTNERSet.PARTNER.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        PARTNERDataSet.PARTNERRow current = (PARTNERDataSet.PARTNERRow) enumerator.Current;
                        this.rowPARTNER = current;
                        if (Helpers.IsRowChanged(this.rowPARTNER))
                        {
                            this.ReadRowPartner();
                            if (this.rowPARTNER.RowState == DataRowState.Added)
                            {
                                this.InsertPartner();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdatePartner();
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
               
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdatePartner()
        {
            this.CheckOptimisticConcurrencyPartner();
            this.CheckExtendedTablePartner();
            this.AfterConfirmPartner();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PARTNER] SET [NAZIVPARTNER]=@NAZIVPARTNER, [MB]=@MB, [PARTNERMJESTO]=@PARTNERMJESTO, [PARTNERULICA]=@PARTNERULICA, [PARTNEREMAIL]=@PARTNEREMAIL, [PARTNEROIB]=@PARTNEROIB, [PARTNERFAX]=@PARTNERFAX, [PARTNERTELEFON]=@PARTNERTELEFON, [PARTNERZIRO1]=@PARTNERZIRO1, [PARTNERZIRO2]=@PARTNERZIRO2  WHERE [IDPARTNER] = @IDPARTNER", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPARTNER", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MB", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERMJESTO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERULICA", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNEREMAIL", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNEROIB", DbType.String, 25));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERFAX", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERTELEFON", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERZIRO1", DbType.String, 0x12));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERZIRO2", DbType.String, 0x12));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowPARTNER["NAZIVPARTNER"]))));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPARTNER["MB"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERMJESTO"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERULICA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNEREMAIL"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNEROIB"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERFAX"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERTELEFON"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERZIRO1"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowPARTNER["PARTNERZIRO2"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowPARTNER["IDPARTNER"]));
            command.ExecuteStmt();
            this.OnPARTNERUpdated(new PARTNEREventArgs(this.rowPARTNER, StatementType.Update));
            this.ProcessLevelPartner();
        }

        private void UpdatePartnerzaduzenje()
        {
            this.CheckOptimisticConcurrencyPartnerzaduzenje();
            this.CheckExtendedTablePartnerzaduzenje();
            this.AfterConfirmPartnerzaduzenje();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PARTNERZADUZENJE] SET [KOLICINAZADUZENJA]=@KOLICINAZADUZENJA, [CIJENAZADUZENJA]=@CIJENAZADUZENJA, [RABATZADUZENJA]=@RABATZADUZENJA, [UGOVORBROJ]=@UGOVORBROJ, [DATUMUGOVORA]=@DATUMUGOVORA, [AKTIVNO]=@AKTIVNO, [IDPROIZVOD]=@IDPROIZVOD  WHERE [IDPARTNER] = @IDPARTNER AND [IDZADUZENJE] = @IDZADUZENJE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLICINAZADUZENJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CIJENAZADUZENJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RABATZADUZENJA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UGOVORBROJ", DbType.String, 200));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMUGOVORA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@AKTIVNO", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDZADUZENJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["KOLICINAZADUZENJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["CIJENAZADUZENJA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["RABATZADUZENJA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["UGOVORBROJ"]));
            command.SetParameterDateObject(4, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["DATUMUGOVORA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["AKTIVNO"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPROIZVOD"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDPARTNER"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowPARTNERZADUZENJE["IDZADUZENJE"]));
            command.ExecuteStmt();
            this.OnPARTNERZADUZENJEUpdated(new PARTNERZADUZENJEEventArgs(this.rowPARTNERZADUZENJE, StatementType.Update));
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
        public class GKSTAVKAInvalidDeleteException : InvalidDeleteException
        {
            public GKSTAVKAInvalidDeleteException()
            {
            }

            public GKSTAVKAInvalidDeleteException(string message) : base(message)
            {
            }

            protected GKSTAVKAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GKSTAVKAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IRAInvalidDeleteException : InvalidDeleteException
        {
            public IRAInvalidDeleteException()
            {
            }

            public IRAInvalidDeleteException(string message) : base(message)
            {
            }

            protected IRAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PARTNERDataChangedException : DataChangedException
        {
            public PARTNERDataChangedException()
            {
            }

            public PARTNERDataChangedException(string message) : base(message)
            {
            }

            protected PARTNERDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PARTNERDataLockedException : DataLockedException
        {
            public PARTNERDataLockedException()
            {
            }

            public PARTNERDataLockedException(string message) : base(message)
            {
            }

            protected PARTNERDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PARTNERDuplicateKeyException : DuplicateKeyException
        {
            public PARTNERDuplicateKeyException()
            {
            }

            public PARTNERDuplicateKeyException(string message) : base(message)
            {
            }

            protected PARTNERDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PARTNEREventArgs : EventArgs
        {
            private PARTNERDataSet.PARTNERRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PARTNEREventArgs(PARTNERDataSet.PARTNERRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PARTNERDataSet.PARTNERRow Row
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
        public class PARTNERNotFoundException : DataNotFoundException
        {
            public PARTNERNotFoundException()
            {
            }

            public PARTNERNotFoundException(string message) : base(message)
            {
            }

            protected PARTNERNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void PARTNERUpdateEventHandler(object sender, PARTNERDataAdapter.PARTNEREventArgs e);

        [Serializable]
        public class PARTNERZADUZENJEDataChangedException : DataChangedException
        {
            public PARTNERZADUZENJEDataChangedException()
            {
            }

            public PARTNERZADUZENJEDataChangedException(string message) : base(message)
            {
            }

            protected PARTNERZADUZENJEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERZADUZENJEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PARTNERZADUZENJEDataLockedException : DataLockedException
        {
            public PARTNERZADUZENJEDataLockedException()
            {
            }

            public PARTNERZADUZENJEDataLockedException(string message) : base(message)
            {
            }

            protected PARTNERZADUZENJEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERZADUZENJEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PARTNERZADUZENJEDuplicateKeyException : DuplicateKeyException
        {
            public PARTNERZADUZENJEDuplicateKeyException()
            {
            }

            public PARTNERZADUZENJEDuplicateKeyException(string message) : base(message)
            {
            }

            protected PARTNERZADUZENJEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERZADUZENJEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PARTNERZADUZENJEEventArgs : EventArgs
        {
            private PARTNERDataSet.PARTNERZADUZENJERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PARTNERZADUZENJEEventArgs(PARTNERDataSet.PARTNERZADUZENJERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PARTNERDataSet.PARTNERZADUZENJERow Row
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

        public delegate void PARTNERZADUZENJEUpdateEventHandler(object sender, PARTNERDataAdapter.PARTNERZADUZENJEEventArgs e);

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
        public class RACUNInvalidDeleteException : InvalidDeleteException
        {
            public RACUNInvalidDeleteException()
            {
            }

            public RACUNInvalidDeleteException(string message) : base(message)
            {
            }

            protected RACUNInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAURAInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAURAInvalidDeleteException()
            {
            }

            public SHEMAURAInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAURAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URAInvalidDeleteException : InvalidDeleteException
        {
            public URAInvalidDeleteException()
            {
            }

            public URAInvalidDeleteException(string message) : base(message)
            {
            }

            protected URAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

