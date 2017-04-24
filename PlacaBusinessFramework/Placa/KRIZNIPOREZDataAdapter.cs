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

    public class KRIZNIPOREZDataAdapter : IDataAdapter, IKRIZNIPOREZDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmKRIZNIPOREZSelect1;
        private ReadWriteCommand cmKRIZNIPOREZSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader KRIZNIPOREZSelect1;
        private IDataReader KRIZNIPOREZSelect4;
        private KRIZNIPOREZDataSet KRIZNIPOREZSet;
        private object m__KRIZNIDOOriginal;
        private object m__KRIZNIODOriginal;
        private object m__KRIZNISTOPAOriginal;
        private object m__MOKRIZNIOriginal;
        private object m__MZKRIZNIOriginal;
        private object m__NAZIVKRIZNIPOREZOriginal;
        private object m__OPISPLACANJAKRIZNIOriginal;
        private object m__POKRIZNIOriginal;
        private object m__PRIMATELJKRIZNI1Original;
        private object m__PRIMATELJKRIZNI2Original;
        private object m__PRIMATELJKRIZNI3Original;
        private object m__PZKRIZNIOriginal;
        private object m__SIFRAOPISAPLACANJAKRIZNIOriginal;
        private object m__VBDIKRIZNIOriginal;
        private object m__ZRNKRIZNIOriginal;
        private readonly string m_SelectString136 = "TM1.[IDKRIZNIPOREZ], TM1.[NAZIVKRIZNIPOREZ], TM1.[KRIZNISTOPA], TM1.[KRIZNIOD], TM1.[KRIZNIDO], TM1.[MOKRIZNI], TM1.[POKRIZNI], TM1.[MZKRIZNI], TM1.[PZKRIZNI], TM1.[PRIMATELJKRIZNI1], TM1.[PRIMATELJKRIZNI2], TM1.[PRIMATELJKRIZNI3], TM1.[SIFRAOPISAPLACANJAKRIZNI], TM1.[OPISPLACANJAKRIZNI], TM1.[VBDIKRIZNI], TM1.[ZRNKRIZNI]";
        private string m_WhereString;
        private short RcdFound136;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private KRIZNIPOREZDataSet.KRIZNIPOREZRow rowKRIZNIPOREZ;
        private string scmdbuf;
        private StatementType sMode136;

        public event KRIZNIPOREZUpdateEventHandler KRIZNIPOREZUpdated;

        public event KRIZNIPOREZUpdateEventHandler KRIZNIPOREZUpdating;

        private void AddRowKrizniporez()
        {
            this.KRIZNIPOREZSet.KRIZNIPOREZ.AddKRIZNIPOREZRow(this.rowKRIZNIPOREZ);
        }

        private void AfterConfirmKrizniporez()
        {
            this.OnKRIZNIPOREZUpdating(new KRIZNIPOREZEventArgs(this.rowKRIZNIPOREZ, this.Gx_mode));
        }

        private void CheckDeleteErrorsKrizniporez()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [IDKRIZNIPOREZ] FROM [DDOBRACUNRadniciDDKrizniPorez] WITH (NOLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDOBRACUNRadniciDDKrizniPorezInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "DDKrizniPorez" }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDOBRACUN], [IDRADNIK], [IDKRIZNIPOREZ] FROM [OBRACUNOBRACUNLevel1ObracunKrizni] WITH (NOLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new OBRACUNOBRACUNLevel1ObracunKrizniInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ObracunKrizni111" }));
            }
            reader2.Close();
        }

        private void CheckOptimisticConcurrencyKrizniporez()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKRIZNIPOREZ], [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [KRIZNIOD], [KRIZNIDO], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI] FROM [KRIZNIPOREZ] WITH (UPDLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new KRIZNIPOREZDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("KRIZNIPOREZ") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVKRIZNIPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!this.m__KRIZNISTOPAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__KRIZNIODOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3)))) || (!this.m__KRIZNIDOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOKRIZNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POKRIZNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZKRIZNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZKRIZNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJKRIZNI1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJKRIZNI2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJKRIZNI3Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJAKRIZNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJAKRIZNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIKRIZNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 14)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZRNKRIZNIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15))))))
                {
                    reader.Close();
                    throw new KRIZNIPOREZDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("KRIZNIPOREZ") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowKrizniporez()
        {
            this.rowKRIZNIPOREZ = this.KRIZNIPOREZSet.KRIZNIPOREZ.NewKRIZNIPOREZRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyKrizniporez();
            this.AfterConfirmKrizniporez();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [KRIZNIPOREZ]  WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsKrizniporez();
            }
            this.OnKRIZNIPOREZUpdated(new KRIZNIPOREZEventArgs(this.rowKRIZNIPOREZ, StatementType.Delete));
            this.rowKRIZNIPOREZ.Delete();
            this.sMode136 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode136;
        }


        public virtual int Fill(KRIZNIPOREZDataSet dataSet)
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
                    this.KRIZNIPOREZSet = dataSet;
                    this.LoadChildKrizniporez(0, -1);
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
            this.KRIZNIPOREZSet = (KRIZNIPOREZDataSet) dataSet;
            if (this.KRIZNIPOREZSet != null)
            {
                return this.Fill(this.KRIZNIPOREZSet);
            }
            this.KRIZNIPOREZSet = new KRIZNIPOREZDataSet();
            this.Fill(this.KRIZNIPOREZSet);
            dataSet.Merge(this.KRIZNIPOREZSet);
            return 0;
        }

        public virtual int Fill(KRIZNIPOREZDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKRIZNIPOREZ"]));
        }

        public virtual int Fill(KRIZNIPOREZDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKRIZNIPOREZ"]));
        }

        public virtual int Fill(KRIZNIPOREZDataSet dataSet, int iDKRIZNIPOREZ)
        {
            if (!this.FillByIDKRIZNIPOREZ(dataSet, iDKRIZNIPOREZ))
            {
                throw new KRIZNIPOREZNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KRIZNIPOREZ") }));
            }
            return 0;
        }

        public virtual bool FillByIDKRIZNIPOREZ(KRIZNIPOREZDataSet dataSet, int iDKRIZNIPOREZ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KRIZNIPOREZSet = dataSet;
            this.rowKRIZNIPOREZ = this.KRIZNIPOREZSet.KRIZNIPOREZ.NewKRIZNIPOREZRow();
            this.rowKRIZNIPOREZ.IDKRIZNIPOREZ = iDKRIZNIPOREZ;
            try
            {
                this.LoadByIDKRIZNIPOREZ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound136 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(KRIZNIPOREZDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KRIZNIPOREZSet = dataSet;
            try
            {
                this.LoadChildKrizniporez(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKRIZNIPOREZ], [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [KRIZNIOD], [KRIZNIDO], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI] FROM [KRIZNIPOREZ] WITH (NOLOCK) WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound136 = 1;
                this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowKRIZNIPOREZ["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowKRIZNIPOREZ["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowKRIZNIPOREZ["KRIZNIOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3));
                this.rowKRIZNIPOREZ["KRIZNIDO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4));
                this.rowKRIZNIPOREZ["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowKRIZNIPOREZ["POKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowKRIZNIPOREZ["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowKRIZNIPOREZ["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowKRIZNIPOREZ["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowKRIZNIPOREZ["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowKRIZNIPOREZ["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowKRIZNIPOREZ["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowKRIZNIPOREZ["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13));
                this.rowKRIZNIPOREZ["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 14));
                this.rowKRIZNIPOREZ["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15));
                this.sMode136 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode136;
            }
            else
            {
                this.RcdFound136 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDKRIZNIPOREZ";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKRIZNIPOREZSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [KRIZNIPOREZ] WITH (NOLOCK) ", false);
            this.KRIZNIPOREZSelect1 = this.cmKRIZNIPOREZSelect1.FetchData();
            if (this.KRIZNIPOREZSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.KRIZNIPOREZSelect1.GetInt32(0);
            }
            this.KRIZNIPOREZSelect1.Close();
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
            this.RcdFound136 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVKRIZNIPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KRIZNISTOPAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KRIZNIODOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KRIZNIDOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJKRIZNI1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJKRIZNI2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJKRIZNI3Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZRNKRIZNIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.KRIZNIPOREZSet = new KRIZNIPOREZDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertKrizniporez()
        {
            this.CheckOptimisticConcurrencyKrizniporez();
            this.AfterConfirmKrizniporez();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [KRIZNIPOREZ] ([IDKRIZNIPOREZ], [NAZIVKRIZNIPOREZ], [KRIZNISTOPA], [KRIZNIOD], [KRIZNIDO], [MOKRIZNI], [POKRIZNI], [MZKRIZNI], [PZKRIZNI], [PRIMATELJKRIZNI1], [PRIMATELJKRIZNI2], [PRIMATELJKRIZNI3], [SIFRAOPISAPLACANJAKRIZNI], [OPISPLACANJAKRIZNI], [VBDIKRIZNI], [ZRNKRIZNI]) VALUES (@IDKRIZNIPOREZ, @NAZIVKRIZNIPOREZ, @KRIZNISTOPA, @KRIZNIOD, @KRIZNIDO, @MOKRIZNI, @POKRIZNI, @MZKRIZNI, @PZKRIZNI, @PRIMATELJKRIZNI1, @PRIMATELJKRIZNI2, @PRIMATELJKRIZNI3, @SIFRAOPISAPLACANJAKRIZNI, @OPISPLACANJAKRIZNI, @VBDIKRIZNI, @ZRNKRIZNI)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKRIZNIPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNISTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNIOD", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNIDO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POKRIZNI", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZKRIZNI", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKRIZNI", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKRIZNI", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKRIZNI", DbType.String, 10));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["NAZIVKRIZNIPOREZ"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNISTOPA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNIOD"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNIDO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["MOKRIZNI"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["POKRIZNI"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["MZKRIZNI"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PZKRIZNI"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI1"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI2"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI3"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["SIFRAOPISAPLACANJAKRIZNI"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["OPISPLACANJAKRIZNI"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["VBDIKRIZNI"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["ZRNKRIZNI"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new KRIZNIPOREZDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnKRIZNIPOREZUpdated(new KRIZNIPOREZEventArgs(this.rowKRIZNIPOREZ, StatementType.Insert));
        }

        private void LoadByIDKRIZNIPOREZ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.KRIZNIPOREZSet.EnforceConstraints;
            this.KRIZNIPOREZSet.KRIZNIPOREZ.BeginLoadData();
            this.ScanByIDKRIZNIPOREZ(startRow, maxRows);
            this.KRIZNIPOREZSet.KRIZNIPOREZ.EndLoadData();
            this.KRIZNIPOREZSet.EnforceConstraints = enforceConstraints;
            if (this.KRIZNIPOREZSet.KRIZNIPOREZ.Count > 0)
            {
                this.rowKRIZNIPOREZ = this.KRIZNIPOREZSet.KRIZNIPOREZ[this.KRIZNIPOREZSet.KRIZNIPOREZ.Count - 1];
            }
        }

        private void LoadChildKrizniporez(int startRow, int maxRows)
        {
            this.CreateNewRowKrizniporez();
            bool enforceConstraints = this.KRIZNIPOREZSet.EnforceConstraints;
            this.KRIZNIPOREZSet.KRIZNIPOREZ.BeginLoadData();
            this.ScanStartKrizniporez(startRow, maxRows);
            this.KRIZNIPOREZSet.KRIZNIPOREZ.EndLoadData();
            this.KRIZNIPOREZSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataKrizniporez(int maxRows)
        {
            int num = 0;
            if (this.RcdFound136 != 0)
            {
                this.ScanLoadKrizniporez();
                while ((this.RcdFound136 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowKrizniporez();
                    this.CreateNewRowKrizniporez();
                    this.ScanNextKrizniporez();
                }
            }
            if (num > 0)
            {
                this.RcdFound136 = 1;
            }
            this.ScanEndKrizniporez();
            if (this.KRIZNIPOREZSet.KRIZNIPOREZ.Count > 0)
            {
                this.rowKRIZNIPOREZ = this.KRIZNIPOREZSet.KRIZNIPOREZ[this.KRIZNIPOREZSet.KRIZNIPOREZ.Count - 1];
            }
        }

        private void LoadRowKrizniporez()
        {
            this.AddRowKrizniporez();
        }

        private void OnKRIZNIPOREZUpdated(KRIZNIPOREZEventArgs e)
        {
            if (this.KRIZNIPOREZUpdated != null)
            {
                KRIZNIPOREZUpdateEventHandler kRIZNIPOREZUpdatedEvent = this.KRIZNIPOREZUpdated;
                if (kRIZNIPOREZUpdatedEvent != null)
                {
                    kRIZNIPOREZUpdatedEvent(this, e);
                }
            }
        }

        private void OnKRIZNIPOREZUpdating(KRIZNIPOREZEventArgs e)
        {
            if (this.KRIZNIPOREZUpdating != null)
            {
                KRIZNIPOREZUpdateEventHandler kRIZNIPOREZUpdatingEvent = this.KRIZNIPOREZUpdating;
                if (kRIZNIPOREZUpdatingEvent != null)
                {
                    kRIZNIPOREZUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowKrizniporez()
        {
            this.Gx_mode = Mode.FromRowState(this.rowKRIZNIPOREZ.RowState);
            if (this.rowKRIZNIPOREZ.RowState != DataRowState.Added)
            {
                this.m__NAZIVKRIZNIPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["NAZIVKRIZNIPOREZ", DataRowVersion.Original]);
                this.m__KRIZNISTOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNISTOPA", DataRowVersion.Original]);
                this.m__KRIZNIODOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNIOD", DataRowVersion.Original]);
                this.m__KRIZNIDOOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNIDO", DataRowVersion.Original]);
                this.m__MOKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["MOKRIZNI", DataRowVersion.Original]);
                this.m__POKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["POKRIZNI", DataRowVersion.Original]);
                this.m__MZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["MZKRIZNI", DataRowVersion.Original]);
                this.m__PZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PZKRIZNI", DataRowVersion.Original]);
                this.m__PRIMATELJKRIZNI1Original = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI1", DataRowVersion.Original]);
                this.m__PRIMATELJKRIZNI2Original = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI2", DataRowVersion.Original]);
                this.m__PRIMATELJKRIZNI3Original = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI3", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["SIFRAOPISAPLACANJAKRIZNI", DataRowVersion.Original]);
                this.m__OPISPLACANJAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["OPISPLACANJAKRIZNI", DataRowVersion.Original]);
                this.m__VBDIKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["VBDIKRIZNI", DataRowVersion.Original]);
                this.m__ZRNKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["ZRNKRIZNI", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVKRIZNIPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["NAZIVKRIZNIPOREZ"]);
                this.m__KRIZNISTOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNISTOPA"]);
                this.m__KRIZNIODOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNIOD"]);
                this.m__KRIZNIDOOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNIDO"]);
                this.m__MOKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["MOKRIZNI"]);
                this.m__POKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["POKRIZNI"]);
                this.m__MZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["MZKRIZNI"]);
                this.m__PZKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PZKRIZNI"]);
                this.m__PRIMATELJKRIZNI1Original = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI1"]);
                this.m__PRIMATELJKRIZNI2Original = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI2"]);
                this.m__PRIMATELJKRIZNI3Original = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI3"]);
                this.m__SIFRAOPISAPLACANJAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["SIFRAOPISAPLACANJAKRIZNI"]);
                this.m__OPISPLACANJAKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["OPISPLACANJAKRIZNI"]);
                this.m__VBDIKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["VBDIKRIZNI"]);
                this.m__ZRNKRIZNIOriginal = RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["ZRNKRIZNI"]);
            }
            this._Gxremove = this.rowKRIZNIPOREZ.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowKRIZNIPOREZ = (KRIZNIPOREZDataSet.KRIZNIPOREZRow) DataSetUtil.CloneOriginalDataRow(this.rowKRIZNIPOREZ);
            }
        }

        private void ScanByIDKRIZNIPOREZ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDKRIZNIPOREZ] = @IDKRIZNIPOREZ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString136 + "  FROM [KRIZNIPOREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKRIZNIPOREZ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString136, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKRIZNIPOREZ] ) AS DK_PAGENUM   FROM [KRIZNIPOREZ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString136 + " FROM [KRIZNIPOREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKRIZNIPOREZ] ";
            }
            this.cmKRIZNIPOREZSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmKRIZNIPOREZSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmKRIZNIPOREZSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            this.cmKRIZNIPOREZSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"]));
            this.KRIZNIPOREZSelect4 = this.cmKRIZNIPOREZSelect4.FetchData();
            this.RcdFound136 = 0;
            this.ScanLoadKrizniporez();
            this.LoadDataKrizniporez(maxRows);
        }

        private void ScanEndKrizniporez()
        {
            this.KRIZNIPOREZSelect4.Close();
        }

        private void ScanLoadKrizniporez()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmKRIZNIPOREZSelect4.HasMoreRows)
            {
                this.RcdFound136 = 1;
                this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KRIZNIPOREZSelect4, 0));
                this.rowKRIZNIPOREZ["NAZIVKRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 1));
                this.rowKRIZNIPOREZ["KRIZNISTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.KRIZNIPOREZSelect4, 2));
                this.rowKRIZNIPOREZ["KRIZNIOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.KRIZNIPOREZSelect4, 3));
                this.rowKRIZNIPOREZ["KRIZNIDO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.KRIZNIPOREZSelect4, 4));
                this.rowKRIZNIPOREZ["MOKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 5));
                this.rowKRIZNIPOREZ["POKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 6));
                this.rowKRIZNIPOREZ["MZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 7));
                this.rowKRIZNIPOREZ["PZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 8));
                this.rowKRIZNIPOREZ["PRIMATELJKRIZNI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 9));
                this.rowKRIZNIPOREZ["PRIMATELJKRIZNI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 10));
                this.rowKRIZNIPOREZ["PRIMATELJKRIZNI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 11));
                this.rowKRIZNIPOREZ["SIFRAOPISAPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 12));
                this.rowKRIZNIPOREZ["OPISPLACANJAKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 13));
                this.rowKRIZNIPOREZ["VBDIKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 14));
                this.rowKRIZNIPOREZ["ZRNKRIZNI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KRIZNIPOREZSelect4, 15));
            }
        }

        private void ScanNextKrizniporez()
        {
            this.cmKRIZNIPOREZSelect4.HasMoreRows = this.KRIZNIPOREZSelect4.Read();
            this.RcdFound136 = 0;
            this.ScanLoadKrizniporez();
        }

        private void ScanStartKrizniporez(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString136 + "  FROM [KRIZNIPOREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKRIZNIPOREZ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString136, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKRIZNIPOREZ] ) AS DK_PAGENUM   FROM [KRIZNIPOREZ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString136 + " FROM [KRIZNIPOREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKRIZNIPOREZ] ";
            }
            this.cmKRIZNIPOREZSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.KRIZNIPOREZSelect4 = this.cmKRIZNIPOREZSelect4.FetchData();
            this.RcdFound136 = 0;
            this.ScanLoadKrizniporez();
            this.LoadDataKrizniporez(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.KRIZNIPOREZSet = (KRIZNIPOREZDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.KRIZNIPOREZSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.KRIZNIPOREZSet.KRIZNIPOREZ.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        KRIZNIPOREZDataSet.KRIZNIPOREZRow current = (KRIZNIPOREZDataSet.KRIZNIPOREZRow) enumerator.Current;
                        this.rowKRIZNIPOREZ = current;
                        if (Helpers.IsRowChanged(this.rowKRIZNIPOREZ))
                        {
                            this.ReadRowKrizniporez();
                            if (this.rowKRIZNIPOREZ.RowState == DataRowState.Added)
                            {
                                this.InsertKrizniporez();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateKrizniporez();
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

        private void UpdateKrizniporez()
        {
            this.CheckOptimisticConcurrencyKrizniporez();
            this.AfterConfirmKrizniporez();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [KRIZNIPOREZ] SET [NAZIVKRIZNIPOREZ]=@NAZIVKRIZNIPOREZ, [KRIZNISTOPA]=@KRIZNISTOPA, [KRIZNIOD]=@KRIZNIOD, [KRIZNIDO]=@KRIZNIDO, [MOKRIZNI]=@MOKRIZNI, [POKRIZNI]=@POKRIZNI, [MZKRIZNI]=@MZKRIZNI, [PZKRIZNI]=@PZKRIZNI, [PRIMATELJKRIZNI1]=@PRIMATELJKRIZNI1, [PRIMATELJKRIZNI2]=@PRIMATELJKRIZNI2, [PRIMATELJKRIZNI3]=@PRIMATELJKRIZNI3, [SIFRAOPISAPLACANJAKRIZNI]=@SIFRAOPISAPLACANJAKRIZNI, [OPISPLACANJAKRIZNI]=@OPISPLACANJAKRIZNI, [VBDIKRIZNI]=@VBDIKRIZNI, [ZRNKRIZNI]=@ZRNKRIZNI  WHERE [IDKRIZNIPOREZ] = @IDKRIZNIPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKRIZNIPOREZ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNISTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNIOD", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KRIZNIDO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POKRIZNI", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZKRIZNI", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKRIZNI3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAKRIZNI", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAKRIZNI", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKRIZNI", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKRIZNI", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKRIZNIPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["NAZIVKRIZNIPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNISTOPA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNIOD"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["KRIZNIDO"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["MOKRIZNI"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["POKRIZNI"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["MZKRIZNI"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PZKRIZNI"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI1"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI2"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["PRIMATELJKRIZNI3"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["SIFRAOPISAPLACANJAKRIZNI"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["OPISPLACANJAKRIZNI"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["VBDIKRIZNI"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["ZRNKRIZNI"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowKRIZNIPOREZ["IDKRIZNIPOREZ"]));
            command.ExecuteStmt();
            new krizniporezupdateredundancy(ref this.dsDefault).execute(this.rowKRIZNIPOREZ.IDKRIZNIPOREZ);
            this.OnKRIZNIPOREZUpdated(new KRIZNIPOREZEventArgs(this.rowKRIZNIPOREZ, StatementType.Update));
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
        public class DDOBRACUNRadniciDDKrizniPorezInvalidDeleteException : InvalidDeleteException
        {
            public DDOBRACUNRadniciDDKrizniPorezInvalidDeleteException()
            {
            }

            public DDOBRACUNRadniciDDKrizniPorezInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciDDKrizniPorezInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciDDKrizniPorezInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KRIZNIPOREZDataChangedException : DataChangedException
        {
            public KRIZNIPOREZDataChangedException()
            {
            }

            public KRIZNIPOREZDataChangedException(string message) : base(message)
            {
            }

            protected KRIZNIPOREZDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KRIZNIPOREZDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KRIZNIPOREZDataLockedException : DataLockedException
        {
            public KRIZNIPOREZDataLockedException()
            {
            }

            public KRIZNIPOREZDataLockedException(string message) : base(message)
            {
            }

            protected KRIZNIPOREZDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KRIZNIPOREZDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KRIZNIPOREZDuplicateKeyException : DuplicateKeyException
        {
            public KRIZNIPOREZDuplicateKeyException()
            {
            }

            public KRIZNIPOREZDuplicateKeyException(string message) : base(message)
            {
            }

            protected KRIZNIPOREZDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KRIZNIPOREZDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class KRIZNIPOREZEventArgs : EventArgs
        {
            private KRIZNIPOREZDataSet.KRIZNIPOREZRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public KRIZNIPOREZEventArgs(KRIZNIPOREZDataSet.KRIZNIPOREZRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public KRIZNIPOREZDataSet.KRIZNIPOREZRow Row
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
        public class KRIZNIPOREZNotFoundException : DataNotFoundException
        {
            public KRIZNIPOREZNotFoundException()
            {
            }

            public KRIZNIPOREZNotFoundException(string message) : base(message)
            {
            }

            protected KRIZNIPOREZNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KRIZNIPOREZNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void KRIZNIPOREZUpdateEventHandler(object sender, KRIZNIPOREZDataAdapter.KRIZNIPOREZEventArgs e);

        [Serializable]
        public class OBRACUNOBRACUNLevel1ObracunKrizniInvalidDeleteException : InvalidDeleteException
        {
            public OBRACUNOBRACUNLevel1ObracunKrizniInvalidDeleteException()
            {
            }

            public OBRACUNOBRACUNLevel1ObracunKrizniInvalidDeleteException(string message) : base(message)
            {
            }

            protected OBRACUNOBRACUNLevel1ObracunKrizniInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNOBRACUNLevel1ObracunKrizniInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

