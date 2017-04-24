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

    public class OLAKSICEDataAdapter : IDataAdapter, IOLAKSICEDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmOLAKSICESelect1;
        private ReadWriteCommand cmOLAKSICESelect2;
        private ReadWriteCommand cmOLAKSICESelect3;
        private ReadWriteCommand cmOLAKSICESelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDGRUPEOLAKSICAOriginal;
        private object m__IDTIPOLAKSICEOriginal;
        private object m__NAZIVOLAKSICEOriginal;
        private object m__PRIMATELJOLAKSICA1Original;
        private object m__PRIMATELJOLAKSICA2Original;
        private object m__PRIMATELJOLAKSICA3Original;
        private object m__VBDIOLAKSICAOriginal;
        private object m__ZRNOLAKSICAOriginal;
        private readonly string m_SelectString15 = "TM1.[IDOLAKSICE], TM1.[NAZIVOLAKSICE], T2.[NAZIVGRUPEOLAKSICA], T2.[MAXIMALNIIZNOSGRUPE], T3.[NAZIVTIPOLAKSICE], TM1.[VBDIOLAKSICA], TM1.[ZRNOLAKSICA], TM1.[PRIMATELJOLAKSICA1], TM1.[PRIMATELJOLAKSICA2], TM1.[PRIMATELJOLAKSICA3], TM1.[IDGRUPEOLAKSICA], TM1.[IDTIPOLAKSICE]";
        private string m_WhereString;
        private IDataReader OLAKSICESelect1;
        private IDataReader OLAKSICESelect2;
        private IDataReader OLAKSICESelect3;
        private IDataReader OLAKSICESelect6;
        private OLAKSICEDataSet OLAKSICESet;
        private short RcdFound15;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OLAKSICEDataSet.OLAKSICERow rowOLAKSICE;
        private string scmdbuf;
        private StatementType sMode15;

        public event OLAKSICEUpdateEventHandler OLAKSICEUpdated;

        public event OLAKSICEUpdateEventHandler OLAKSICEUpdating;

        private void AddRowOlaksice()
        {
            this.OLAKSICESet.OLAKSICE.AddOLAKSICERow(this.rowOLAKSICE);
        }

        private void AfterConfirmOlaksice()
        {
            this.OnOLAKSICEUpdating(new OLAKSICEEventArgs(this.rowOLAKSICE, this.Gx_mode));
        }

        private void CheckDeleteErrorsOlaksice()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [ZADOLAKSICEIDOLAKSICE] FROM [RADNIKOlaksica] WITH (NOLOCK) WHERE [ZADOLAKSICEIDOLAKSICE] = @IDOLAKSICE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDOLAKSICE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new RADNIKOlaksicaInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIKOlaksica" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDOBRACUN], [IDRADNIK], [IDOLAKSICE] FROM [ObracunOlaksice] WITH (NOLOCK) WHERE [IDOLAKSICE] = @IDOLAKSICE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDOLAKSICE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new ObracunOlaksiceInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ObracunOlaksice" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableOlaksice()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDGRUPEOLAKSICA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new GRUPEOLAKSICAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GRUPEOLAKSICA") }));
            }
            this.rowOLAKSICE["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowOLAKSICE["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDTIPOLAKSICE"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new TIPOLAKSICEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPOLAKSICE") }));
            }
            this.rowOLAKSICE["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            reader2.Close();
        }

        private void CheckOptimisticConcurrencyOlaksice()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOLAKSICE], [NAZIVOLAKSICE], [VBDIOLAKSICA], [ZRNOLAKSICA], [PRIMATELJOLAKSICA1], [PRIMATELJOLAKSICA2], [PRIMATELJOLAKSICA3], [IDGRUPEOLAKSICA], [IDTIPOLAKSICE] FROM [OLAKSICE] WITH (UPDLOCK) WHERE [IDOLAKSICE] = @IDOLAKSICE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDOLAKSICE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OLAKSICEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OLAKSICE") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVOLAKSICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZRNOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJOLAKSICA1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJOLAKSICA2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJOLAKSICA3Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!this.m__IDGRUPEOLAKSICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 7))) || !this.m__IDTIPOLAKSICEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 8)))))
                {
                    reader.Close();
                    throw new OLAKSICEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OLAKSICE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOlaksice()
        {
            this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE.NewOLAKSICERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOlaksice();
            this.OnDeleteControlsOlaksice();
            this.AfterConfirmOlaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OLAKSICE]  WHERE [IDOLAKSICE] = @IDOLAKSICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDOLAKSICE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOlaksice();
            }
            this.OnOLAKSICEUpdated(new OLAKSICEEventArgs(this.rowOLAKSICE, StatementType.Delete));
            this.rowOLAKSICE.Delete();
            this.sMode15 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode15;
        }

        public virtual int Fill(OLAKSICEDataSet dataSet)
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
                    this.OLAKSICESet = dataSet;
                    this.LoadChildOlaksice(0, -1);
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
            this.OLAKSICESet = (OLAKSICEDataSet) dataSet;
            if (this.OLAKSICESet != null)
            {
                return this.Fill(this.OLAKSICESet);
            }
            this.OLAKSICESet = new OLAKSICEDataSet();
            this.Fill(this.OLAKSICESet);
            dataSet.Merge(this.OLAKSICESet);
            return 0;
        }

        public virtual int Fill(OLAKSICEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOLAKSICE"]));
        }

        public virtual int Fill(OLAKSICEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOLAKSICE"]));
        }

        public virtual int Fill(OLAKSICEDataSet dataSet, int iDOLAKSICE)
        {
            if (!this.FillByIDOLAKSICE(dataSet, iDOLAKSICE))
            {
                throw new OLAKSICENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OLAKSICE") }));
            }
            return 0;
        }

        public virtual int FillByIDGRUPEOLAKSICA(OLAKSICEDataSet dataSet, int iDGRUPEOLAKSICA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OLAKSICESet = dataSet;
            this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE.NewOLAKSICERow();
            this.rowOLAKSICE.IDGRUPEOLAKSICA = iDGRUPEOLAKSICA;
            try
            {
                this.LoadByIDGRUPEOLAKSICA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDOLAKSICE(OLAKSICEDataSet dataSet, int iDOLAKSICE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OLAKSICESet = dataSet;
            this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE.NewOLAKSICERow();
            this.rowOLAKSICE.IDOLAKSICE = iDOLAKSICE;
            try
            {
                this.LoadByIDOLAKSICE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound15 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDTIPOLAKSICE(OLAKSICEDataSet dataSet, int iDTIPOLAKSICE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OLAKSICESet = dataSet;
            this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE.NewOLAKSICERow();
            this.rowOLAKSICE.IDTIPOLAKSICE = iDTIPOLAKSICE;
            try
            {
                this.LoadByIDTIPOLAKSICE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(OLAKSICEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OLAKSICESet = dataSet;
            try
            {
                this.LoadChildOlaksice(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDGRUPEOLAKSICA(OLAKSICEDataSet dataSet, int iDGRUPEOLAKSICA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OLAKSICESet = dataSet;
            this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE.NewOLAKSICERow();
            this.rowOLAKSICE.IDGRUPEOLAKSICA = iDGRUPEOLAKSICA;
            try
            {
                this.LoadByIDGRUPEOLAKSICA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDTIPOLAKSICE(OLAKSICEDataSet dataSet, int iDTIPOLAKSICE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OLAKSICESet = dataSet;
            this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE.NewOLAKSICERow();
            this.rowOLAKSICE.IDTIPOLAKSICE = iDTIPOLAKSICE;
            try
            {
                this.LoadByIDTIPOLAKSICE(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOLAKSICE], [NAZIVOLAKSICE], [VBDIOLAKSICA], [ZRNOLAKSICA], [PRIMATELJOLAKSICA1], [PRIMATELJOLAKSICA2], [PRIMATELJOLAKSICA3], [IDGRUPEOLAKSICA], [IDTIPOLAKSICE] FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDOLAKSICE] = @IDOLAKSICE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDOLAKSICE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound15 = 1;
                this.rowOLAKSICE["IDOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowOLAKSICE["NAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowOLAKSICE["VBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowOLAKSICE["ZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowOLAKSICE["PRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowOLAKSICE["PRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowOLAKSICE["PRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowOLAKSICE["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 7));
                this.rowOLAKSICE["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 8));
                this.sMode15 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadOlaksice();
                this.Gx_mode = this.sMode15;
            }
            else
            {
                this.RcdFound15 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOLAKSICE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICESelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OLAKSICE] WITH (NOLOCK) ", false);
            this.OLAKSICESelect3 = this.cmOLAKSICESelect3.FetchData();
            if (this.OLAKSICESelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OLAKSICESelect3.GetInt32(0);
            }
            this.OLAKSICESelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDGRUPEOLAKSICA(int iDGRUPEOLAKSICA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICESelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
            if (this.cmOLAKSICESelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            this.cmOLAKSICESelect2.SetParameter(0, iDGRUPEOLAKSICA);
            this.OLAKSICESelect2 = this.cmOLAKSICESelect2.FetchData();
            if (this.OLAKSICESelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OLAKSICESelect2.GetInt32(0);
            }
            this.OLAKSICESelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDTIPOLAKSICE(int iDTIPOLAKSICE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOLAKSICESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
            if (this.cmOLAKSICESelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            this.cmOLAKSICESelect1.SetParameter(0, iDTIPOLAKSICE);
            this.OLAKSICESelect1 = this.cmOLAKSICESelect1.FetchData();
            if (this.OLAKSICESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OLAKSICESelect1.GetInt32(0);
            }
            this.OLAKSICESelect1.Close();
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

        public virtual int GetRecordCountByIDGRUPEOLAKSICA(int iDGRUPEOLAKSICA)
        {
            int internalRecordCountByIDGRUPEOLAKSICA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDGRUPEOLAKSICA = this.GetInternalRecordCountByIDGRUPEOLAKSICA(iDGRUPEOLAKSICA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDGRUPEOLAKSICA;
        }

        public virtual int GetRecordCountByIDTIPOLAKSICE(int iDTIPOLAKSICE)
        {
            int internalRecordCountByIDTIPOLAKSICE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDTIPOLAKSICE = this.GetInternalRecordCountByIDTIPOLAKSICE(iDTIPOLAKSICE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDTIPOLAKSICE;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound15 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZRNOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJOLAKSICA1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJOLAKSICA2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJOLAKSICA3Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDGRUPEOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDTIPOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OLAKSICESet = new OLAKSICEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOlaksice()
        {
            this.CheckOptimisticConcurrencyOlaksice();
            this.CheckExtendedTableOlaksice();
            this.AfterConfirmOlaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OLAKSICE] ([IDOLAKSICE], [NAZIVOLAKSICE], [VBDIOLAKSICA], [ZRNOLAKSICA], [PRIMATELJOLAKSICA1], [PRIMATELJOLAKSICA2], [PRIMATELJOLAKSICA3], [IDGRUPEOLAKSICA], [IDTIPOLAKSICE]) VALUES (@IDOLAKSICE, @NAZIVOLAKSICE, @VBDIOLAKSICA, @ZRNOLAKSICA, @PRIMATELJOLAKSICA1, @PRIMATELJOLAKSICA2, @PRIMATELJOLAKSICA3, @IDGRUPEOLAKSICA, @IDTIPOLAKSICE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOLAKSICE", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOLAKSICA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOLAKSICA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDOLAKSICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["NAZIVOLAKSICE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["VBDIOLAKSICA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["ZRNOLAKSICA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA1"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA2"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA3"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDGRUPEOLAKSICA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDTIPOLAKSICE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OLAKSICEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOLAKSICEUpdated(new OLAKSICEEventArgs(this.rowOLAKSICE, StatementType.Insert));
        }

        private void LoadByIDGRUPEOLAKSICA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OLAKSICESet.EnforceConstraints;
            this.OLAKSICESet.OLAKSICE.BeginLoadData();
            this.ScanByIDGRUPEOLAKSICA(startRow, maxRows);
            this.OLAKSICESet.OLAKSICE.EndLoadData();
            this.OLAKSICESet.EnforceConstraints = enforceConstraints;
            if (this.OLAKSICESet.OLAKSICE.Count > 0)
            {
                this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE[this.OLAKSICESet.OLAKSICE.Count - 1];
            }
        }

        private void LoadByIDOLAKSICE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OLAKSICESet.EnforceConstraints;
            this.OLAKSICESet.OLAKSICE.BeginLoadData();
            this.ScanByIDOLAKSICE(startRow, maxRows);
            this.OLAKSICESet.OLAKSICE.EndLoadData();
            this.OLAKSICESet.EnforceConstraints = enforceConstraints;
            if (this.OLAKSICESet.OLAKSICE.Count > 0)
            {
                this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE[this.OLAKSICESet.OLAKSICE.Count - 1];
            }
        }

        private void LoadByIDTIPOLAKSICE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OLAKSICESet.EnforceConstraints;
            this.OLAKSICESet.OLAKSICE.BeginLoadData();
            this.ScanByIDTIPOLAKSICE(startRow, maxRows);
            this.OLAKSICESet.OLAKSICE.EndLoadData();
            this.OLAKSICESet.EnforceConstraints = enforceConstraints;
            if (this.OLAKSICESet.OLAKSICE.Count > 0)
            {
                this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE[this.OLAKSICESet.OLAKSICE.Count - 1];
            }
        }

        private void LoadChildOlaksice(int startRow, int maxRows)
        {
            this.CreateNewRowOlaksice();
            bool enforceConstraints = this.OLAKSICESet.EnforceConstraints;
            this.OLAKSICESet.OLAKSICE.BeginLoadData();
            this.ScanStartOlaksice(startRow, maxRows);
            this.OLAKSICESet.OLAKSICE.EndLoadData();
            this.OLAKSICESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOlaksice(int maxRows)
        {
            int num = 0;
            if (this.RcdFound15 != 0)
            {
                this.ScanLoadOlaksice();
                while ((this.RcdFound15 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOlaksice();
                    this.CreateNewRowOlaksice();
                    this.ScanNextOlaksice();
                }
            }
            if (num > 0)
            {
                this.RcdFound15 = 1;
            }
            this.ScanEndOlaksice();
            if (this.OLAKSICESet.OLAKSICE.Count > 0)
            {
                this.rowOLAKSICE = this.OLAKSICESet.OLAKSICE[this.OLAKSICESet.OLAKSICE.Count - 1];
            }
        }

        private void LoadOlaksice()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDGRUPEOLAKSICA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOLAKSICE["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOLAKSICE["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDTIPOLAKSICE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowOLAKSICE["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
        }

        private void LoadRowOlaksice()
        {
            this.AddRowOlaksice();
        }

        private void OnDeleteControlsOlaksice()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDGRUPEOLAKSICA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOLAKSICE["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowOLAKSICE["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDTIPOLAKSICE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowOLAKSICE["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
        }

        private void OnOLAKSICEUpdated(OLAKSICEEventArgs e)
        {
            if (this.OLAKSICEUpdated != null)
            {
                OLAKSICEUpdateEventHandler oLAKSICEUpdatedEvent = this.OLAKSICEUpdated;
                if (oLAKSICEUpdatedEvent != null)
                {
                    oLAKSICEUpdatedEvent(this, e);
                }
            }
        }

        private void OnOLAKSICEUpdating(OLAKSICEEventArgs e)
        {
            if (this.OLAKSICEUpdating != null)
            {
                OLAKSICEUpdateEventHandler oLAKSICEUpdatingEvent = this.OLAKSICEUpdating;
                if (oLAKSICEUpdatingEvent != null)
                {
                    oLAKSICEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOlaksice()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOLAKSICE.RowState);
            if (this.rowOLAKSICE.RowState != DataRowState.Added)
            {
                this.m__NAZIVOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["NAZIVOLAKSICE", DataRowVersion.Original]);
                this.m__VBDIOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["VBDIOLAKSICA", DataRowVersion.Original]);
                this.m__ZRNOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["ZRNOLAKSICA", DataRowVersion.Original]);
                this.m__PRIMATELJOLAKSICA1Original = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA1", DataRowVersion.Original]);
                this.m__PRIMATELJOLAKSICA2Original = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA2", DataRowVersion.Original]);
                this.m__PRIMATELJOLAKSICA3Original = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA3", DataRowVersion.Original]);
                this.m__IDGRUPEOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDGRUPEOLAKSICA", DataRowVersion.Original]);
                this.m__IDTIPOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDTIPOLAKSICE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["NAZIVOLAKSICE"]);
                this.m__VBDIOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["VBDIOLAKSICA"]);
                this.m__ZRNOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["ZRNOLAKSICA"]);
                this.m__PRIMATELJOLAKSICA1Original = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA1"]);
                this.m__PRIMATELJOLAKSICA2Original = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA2"]);
                this.m__PRIMATELJOLAKSICA3Original = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA3"]);
                this.m__IDGRUPEOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDGRUPEOLAKSICA"]);
                this.m__IDTIPOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDTIPOLAKSICE"]);
            }
            this._Gxremove = this.rowOLAKSICE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOLAKSICE = (OLAKSICEDataSet.OLAKSICERow) DataSetUtil.CloneOriginalDataRow(this.rowOLAKSICE);
            }
        }

        private void ScanByIDGRUPEOLAKSICA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString15 + "  FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY TM1.[IDOLAKSICE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString15, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOLAKSICE] ) AS DK_PAGENUM   FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString15 + " FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY TM1.[IDOLAKSICE] ";
            }
            this.cmOLAKSICESelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOLAKSICESelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            this.cmOLAKSICESelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDGRUPEOLAKSICA"]));
            this.OLAKSICESelect6 = this.cmOLAKSICESelect6.FetchData();
            this.RcdFound15 = 0;
            this.ScanLoadOlaksice();
            this.LoadDataOlaksice(maxRows);
        }

        private void ScanByIDOLAKSICE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOLAKSICE] = @IDOLAKSICE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString15 + "  FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY TM1.[IDOLAKSICE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString15, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOLAKSICE] ) AS DK_PAGENUM   FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString15 + " FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY TM1.[IDOLAKSICE] ";
            }
            this.cmOLAKSICESelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOLAKSICESelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            this.cmOLAKSICESelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDOLAKSICE"]));
            this.OLAKSICESelect6 = this.cmOLAKSICESelect6.FetchData();
            this.RcdFound15 = 0;
            this.ScanLoadOlaksice();
            this.LoadDataOlaksice(maxRows);
        }

        private void ScanByIDTIPOLAKSICE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPOLAKSICE] = @IDTIPOLAKSICE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString15 + "  FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY TM1.[IDOLAKSICE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString15, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOLAKSICE] ) AS DK_PAGENUM   FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString15 + " FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY TM1.[IDOLAKSICE] ";
            }
            this.cmOLAKSICESelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOLAKSICESelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            this.cmOLAKSICESelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDTIPOLAKSICE"]));
            this.OLAKSICESelect6 = this.cmOLAKSICESelect6.FetchData();
            this.RcdFound15 = 0;
            this.ScanLoadOlaksice();
            this.LoadDataOlaksice(maxRows);
        }

        private void ScanEndOlaksice()
        {
            this.OLAKSICESelect6.Close();
        }

        private void ScanLoadOlaksice()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOLAKSICESelect6.HasMoreRows)
            {
                this.RcdFound15 = 1;
                this.rowOLAKSICE["IDOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OLAKSICESelect6, 0));
                this.rowOLAKSICE["NAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 1));
                this.rowOLAKSICE["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 2));
                this.rowOLAKSICE["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OLAKSICESelect6, 3));
                this.rowOLAKSICE["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 4));
                this.rowOLAKSICE["VBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 5));
                this.rowOLAKSICE["ZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 6));
                this.rowOLAKSICE["PRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 7));
                this.rowOLAKSICE["PRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 8));
                this.rowOLAKSICE["PRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 9));
                this.rowOLAKSICE["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OLAKSICESelect6, 10));
                this.rowOLAKSICE["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OLAKSICESelect6, 11));
                this.rowOLAKSICE["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 2));
                this.rowOLAKSICE["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OLAKSICESelect6, 3));
                this.rowOLAKSICE["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OLAKSICESelect6, 4));
            }
        }

        private void ScanNextOlaksice()
        {
            this.cmOLAKSICESelect6.HasMoreRows = this.OLAKSICESelect6.Read();
            this.RcdFound15 = 0;
            this.ScanLoadOlaksice();
        }

        private void ScanStartOlaksice(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString15 + "  FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY TM1.[IDOLAKSICE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString15, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOLAKSICE] ) AS DK_PAGENUM   FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString15 + " FROM (([OLAKSICE] TM1 WITH (NOLOCK) INNER JOIN [GRUPEOLAKSICA] T2 WITH (NOLOCK) ON T2.[IDGRUPEOLAKSICA] = TM1.[IDGRUPEOLAKSICA]) INNER JOIN [TIPOLAKSICE] T3 WITH (NOLOCK) ON T3.[IDTIPOLAKSICE] = TM1.[IDTIPOLAKSICE])" + this.m_WhereString + " ORDER BY TM1.[IDOLAKSICE] ";
            }
            this.cmOLAKSICESelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OLAKSICESelect6 = this.cmOLAKSICESelect6.FetchData();
            this.RcdFound15 = 0;
            this.ScanLoadOlaksice();
            this.LoadDataOlaksice(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OLAKSICESet = (OLAKSICEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OLAKSICESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OLAKSICESet.OLAKSICE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OLAKSICEDataSet.OLAKSICERow current = (OLAKSICEDataSet.OLAKSICERow) enumerator.Current;
                        this.rowOLAKSICE = current;
                        if (Helpers.IsRowChanged(this.rowOLAKSICE))
                        {
                            this.ReadRowOlaksice();
                            if (this.rowOLAKSICE.RowState == DataRowState.Added)
                            {
                                this.InsertOlaksice();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOlaksice();
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

        private void UpdateOlaksice()
        {
            this.CheckOptimisticConcurrencyOlaksice();
            this.CheckExtendedTableOlaksice();
            this.AfterConfirmOlaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OLAKSICE] SET [NAZIVOLAKSICE]=@NAZIVOLAKSICE, [VBDIOLAKSICA]=@VBDIOLAKSICA, [ZRNOLAKSICA]=@ZRNOLAKSICA, [PRIMATELJOLAKSICA1]=@PRIMATELJOLAKSICA1, [PRIMATELJOLAKSICA2]=@PRIMATELJOLAKSICA2, [PRIMATELJOLAKSICA3]=@PRIMATELJOLAKSICA3, [IDGRUPEOLAKSICA]=@IDGRUPEOLAKSICA, [IDTIPOLAKSICE]=@IDTIPOLAKSICE  WHERE [IDOLAKSICE] = @IDOLAKSICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOLAKSICE", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOLAKSICA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOLAKSICA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["NAZIVOLAKSICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["VBDIOLAKSICA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["ZRNOLAKSICA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA1"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA2"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["PRIMATELJOLAKSICA3"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDGRUPEOLAKSICA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDTIPOLAKSICE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOLAKSICE["IDOLAKSICE"]));
            command.ExecuteStmt();
            new olaksiceupdateredundancy(ref this.dsDefault).execute(this.rowOLAKSICE.IDOLAKSICE);
            this.OnOLAKSICEUpdated(new OLAKSICEEventArgs(this.rowOLAKSICE, StatementType.Update));
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
        public class GRUPEOLAKSICAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public GRUPEOLAKSICAForeignKeyNotFoundException()
            {
            }

            public GRUPEOLAKSICAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected GRUPEOLAKSICAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEOLAKSICAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunOlaksiceInvalidDeleteException : InvalidDeleteException
        {
            public ObracunOlaksiceInvalidDeleteException()
            {
            }

            public ObracunOlaksiceInvalidDeleteException(string message) : base(message)
            {
            }

            protected ObracunOlaksiceInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunOlaksiceInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OLAKSICEDataChangedException : DataChangedException
        {
            public OLAKSICEDataChangedException()
            {
            }

            public OLAKSICEDataChangedException(string message) : base(message)
            {
            }

            protected OLAKSICEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OLAKSICEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OLAKSICEDataLockedException : DataLockedException
        {
            public OLAKSICEDataLockedException()
            {
            }

            public OLAKSICEDataLockedException(string message) : base(message)
            {
            }

            protected OLAKSICEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OLAKSICEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OLAKSICEDuplicateKeyException : DuplicateKeyException
        {
            public OLAKSICEDuplicateKeyException()
            {
            }

            public OLAKSICEDuplicateKeyException(string message) : base(message)
            {
            }

            protected OLAKSICEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OLAKSICEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OLAKSICEEventArgs : EventArgs
        {
            private OLAKSICEDataSet.OLAKSICERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OLAKSICEEventArgs(OLAKSICEDataSet.OLAKSICERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OLAKSICEDataSet.OLAKSICERow Row
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
        public class OLAKSICENotFoundException : DataNotFoundException
        {
            public OLAKSICENotFoundException()
            {
            }

            public OLAKSICENotFoundException(string message) : base(message)
            {
            }

            protected OLAKSICENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OLAKSICENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OLAKSICEUpdateEventHandler(object sender, OLAKSICEDataAdapter.OLAKSICEEventArgs e);

        [Serializable]
        public class RADNIKOlaksicaInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKOlaksicaInvalidDeleteException()
            {
            }

            public RADNIKOlaksicaInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKOlaksicaInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKOlaksicaInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPOLAKSICEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public TIPOLAKSICEForeignKeyNotFoundException()
            {
            }

            public TIPOLAKSICEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected TIPOLAKSICEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPOLAKSICEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

