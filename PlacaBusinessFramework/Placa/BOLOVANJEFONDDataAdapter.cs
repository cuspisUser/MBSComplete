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

    public class BOLOVANJEFONDDataAdapter : IDataAdapter, IBOLOVANJEFONDDataAdapter
    {
        private bool _Gxremove;
        private IDataReader BOLOVANJEFONDSelect1;
        private IDataReader BOLOVANJEFONDSelect4;
        private BOLOVANJEFONDDataSet BOLOVANJEFONDSet;
        private ReadWriteCommand cmBOLOVANJEFONDSelect1;
        private ReadWriteCommand cmBOLOVANJEFONDSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__KOLONAOriginal;
        private readonly string m_SelectString135 = "T2.[NAZIVELEMENT] AS ELEMENTBOLOVANJENAZIVELEMENT, TM1.[KOLONA], TM1.[ELEMENTBOLOVANJEIDELEMENT] AS ELEMENTBOLOVANJEIDELEMENT";
        private string m_WhereString;
        private short RcdFound135;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private BOLOVANJEFONDDataSet.BOLOVANJEFONDRow rowBOLOVANJEFOND;
        private string scmdbuf;
        private StatementType sMode135;

        public event BOLOVANJEFONDUpdateEventHandler BOLOVANJEFONDUpdated;

        public event BOLOVANJEFONDUpdateEventHandler BOLOVANJEFONDUpdating;

        private void AddRowBolovanjefond()
        {
            this.BOLOVANJEFONDSet.BOLOVANJEFOND.AddBOLOVANJEFONDRow(this.rowBOLOVANJEFOND);
        }

        private void AfterConfirmBolovanjefond()
        {
            this.OnBOLOVANJEFONDUpdating(new BOLOVANJEFONDEventArgs(this.rowBOLOVANJEFOND, this.Gx_mode));
        }

        private void CheckExtendedTableBolovanjefond()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS ELEMENTBOLOVANJENAZIVELEMENT FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            this.rowBOLOVANJEFOND["ELEMENTBOLOVANJENAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyBolovanjefond()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [KOLONA], [ELEMENTBOLOVANJEIDELEMENT] AS ELEMENTBOLOVANJEIDELEMENT FROM [BOLOVANJEFOND] WITH (UPDLOCK) WHERE [ELEMENTBOLOVANJEIDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new BOLOVANJEFONDDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("BOLOVANJEFOND") }));
                }
                if (!command.HasMoreRows || !this.m__KOLONAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0))))
                {
                    reader.Close();
                    throw new BOLOVANJEFONDDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("BOLOVANJEFOND") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowBolovanjefond()
        {
            this.rowBOLOVANJEFOND = this.BOLOVANJEFONDSet.BOLOVANJEFOND.NewBOLOVANJEFONDRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyBolovanjefond();
            this.OnDeleteControlsBolovanjefond();
            this.AfterConfirmBolovanjefond();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [BOLOVANJEFOND]  WHERE [ELEMENTBOLOVANJEIDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
            command.ExecuteStmt();
            this.OnBOLOVANJEFONDUpdated(new BOLOVANJEFONDEventArgs(this.rowBOLOVANJEFOND, StatementType.Delete));
            this.rowBOLOVANJEFOND.Delete();
            this.sMode135 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode135;
        }


        public virtual int Fill(BOLOVANJEFONDDataSet dataSet)
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
                    this.BOLOVANJEFONDSet = dataSet;
                    this.LoadChildBolovanjefond(0, -1);
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
            this.BOLOVANJEFONDSet = (BOLOVANJEFONDDataSet) dataSet;
            if (this.BOLOVANJEFONDSet != null)
            {
                return this.Fill(this.BOLOVANJEFONDSet);
            }
            this.BOLOVANJEFONDSet = new BOLOVANJEFONDDataSet();
            this.Fill(this.BOLOVANJEFONDSet);
            dataSet.Merge(this.BOLOVANJEFONDSet);
            return 0;
        }

        public virtual int Fill(BOLOVANJEFONDDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["ELEMENTBOLOVANJEIDELEMENT"]));
        }

        public virtual int Fill(BOLOVANJEFONDDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["ELEMENTBOLOVANJEIDELEMENT"]));
        }

        public virtual int Fill(BOLOVANJEFONDDataSet dataSet, int eLEMENTBOLOVANJEIDELEMENT)
        {
            if (!this.FillByELEMENTBOLOVANJEIDELEMENT(dataSet, eLEMENTBOLOVANJEIDELEMENT))
            {
                throw new BOLOVANJEFONDNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BOLOVANJEFOND") }));
            }
            return 0;
        }

        public virtual bool FillByELEMENTBOLOVANJEIDELEMENT(BOLOVANJEFONDDataSet dataSet, int eLEMENTBOLOVANJEIDELEMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BOLOVANJEFONDSet = dataSet;
            this.rowBOLOVANJEFOND = this.BOLOVANJEFONDSet.BOLOVANJEFOND.NewBOLOVANJEFONDRow();
            this.rowBOLOVANJEFOND.ELEMENTBOLOVANJEIDELEMENT = eLEMENTBOLOVANJEIDELEMENT;
            try
            {
                this.LoadByELEMENTBOLOVANJEIDELEMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound135 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(BOLOVANJEFONDDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BOLOVANJEFONDSet = dataSet;
            try
            {
                this.LoadChildBolovanjefond(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [KOLONA], [ELEMENTBOLOVANJEIDELEMENT] AS ELEMENTBOLOVANJEIDELEMENT FROM [BOLOVANJEFOND] WITH (NOLOCK) WHERE [ELEMENTBOLOVANJEIDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound135 = 1;
                this.rowBOLOVANJEFOND["KOLONA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0));
                this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.sMode135 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadBolovanjefond();
                this.Gx_mode = this.sMode135;
            }
            else
            {
                this.RcdFound135 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "ELEMENTBOLOVANJEIDELEMENT";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBOLOVANJEFONDSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [BOLOVANJEFOND] WITH (NOLOCK) ", false);
            this.BOLOVANJEFONDSelect1 = this.cmBOLOVANJEFONDSelect1.FetchData();
            if (this.BOLOVANJEFONDSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.BOLOVANJEFONDSelect1.GetInt32(0);
            }
            this.BOLOVANJEFONDSelect1.Close();
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
            this.RcdFound135 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__KOLONAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.BOLOVANJEFONDSet = new BOLOVANJEFONDDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertBolovanjefond()
        {
            this.CheckOptimisticConcurrencyBolovanjefond();
            this.CheckExtendedTableBolovanjefond();
            this.AfterConfirmBolovanjefond();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [BOLOVANJEFOND] ([KOLONA], [ELEMENTBOLOVANJEIDELEMENT]) VALUES (@KOLONA, @ELEMENTBOLOVANJEIDELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLONA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["KOLONA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new BOLOVANJEFONDDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnBOLOVANJEFONDUpdated(new BOLOVANJEFONDEventArgs(this.rowBOLOVANJEFOND, StatementType.Insert));
        }

        private void LoadBolovanjefond()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS ELEMENTBOLOVANJENAZIVELEMENT FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowBOLOVANJEFOND["ELEMENTBOLOVANJENAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void LoadByELEMENTBOLOVANJEIDELEMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.BOLOVANJEFONDSet.EnforceConstraints;
            this.BOLOVANJEFONDSet.BOLOVANJEFOND.BeginLoadData();
            this.ScanByELEMENTBOLOVANJEIDELEMENT(startRow, maxRows);
            this.BOLOVANJEFONDSet.BOLOVANJEFOND.EndLoadData();
            this.BOLOVANJEFONDSet.EnforceConstraints = enforceConstraints;
            if (this.BOLOVANJEFONDSet.BOLOVANJEFOND.Count > 0)
            {
                this.rowBOLOVANJEFOND = this.BOLOVANJEFONDSet.BOLOVANJEFOND[this.BOLOVANJEFONDSet.BOLOVANJEFOND.Count - 1];
            }
        }

        private void LoadChildBolovanjefond(int startRow, int maxRows)
        {
            this.CreateNewRowBolovanjefond();
            bool enforceConstraints = this.BOLOVANJEFONDSet.EnforceConstraints;
            this.BOLOVANJEFONDSet.BOLOVANJEFOND.BeginLoadData();
            this.ScanStartBolovanjefond(startRow, maxRows);
            this.BOLOVANJEFONDSet.BOLOVANJEFOND.EndLoadData();
            this.BOLOVANJEFONDSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataBolovanjefond(int maxRows)
        {
            int num = 0;
            if (this.RcdFound135 != 0)
            {
                this.ScanLoadBolovanjefond();
                while ((this.RcdFound135 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowBolovanjefond();
                    this.CreateNewRowBolovanjefond();
                    this.ScanNextBolovanjefond();
                }
            }
            if (num > 0)
            {
                this.RcdFound135 = 1;
            }
            this.ScanEndBolovanjefond();
            if (this.BOLOVANJEFONDSet.BOLOVANJEFOND.Count > 0)
            {
                this.rowBOLOVANJEFOND = this.BOLOVANJEFONDSet.BOLOVANJEFOND[this.BOLOVANJEFONDSet.BOLOVANJEFOND.Count - 1];
            }
        }

        private void LoadRowBolovanjefond()
        {
            this.AddRowBolovanjefond();
        }

        private void OnBOLOVANJEFONDUpdated(BOLOVANJEFONDEventArgs e)
        {
            if (this.BOLOVANJEFONDUpdated != null)
            {
                BOLOVANJEFONDUpdateEventHandler bOLOVANJEFONDUpdatedEvent = this.BOLOVANJEFONDUpdated;
                if (bOLOVANJEFONDUpdatedEvent != null)
                {
                    bOLOVANJEFONDUpdatedEvent(this, e);
                }
            }
        }

        private void OnBOLOVANJEFONDUpdating(BOLOVANJEFONDEventArgs e)
        {
            if (this.BOLOVANJEFONDUpdating != null)
            {
                BOLOVANJEFONDUpdateEventHandler bOLOVANJEFONDUpdatingEvent = this.BOLOVANJEFONDUpdating;
                if (bOLOVANJEFONDUpdatingEvent != null)
                {
                    bOLOVANJEFONDUpdatingEvent(this, e);
                }
            }
        }

        private void OnDeleteControlsBolovanjefond()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] AS ELEMENTBOLOVANJENAZIVELEMENT FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowBOLOVANJEFOND["ELEMENTBOLOVANJENAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void ReadRowBolovanjefond()
        {
            this.Gx_mode = Mode.FromRowState(this.rowBOLOVANJEFOND.RowState);
            if (this.rowBOLOVANJEFOND.RowState != DataRowState.Added)
            {
                this.m__KOLONAOriginal = RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["KOLONA", DataRowVersion.Original]);
            }
            else
            {
                this.m__KOLONAOriginal = RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["KOLONA"]);
            }
            this._Gxremove = this.rowBOLOVANJEFOND.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowBOLOVANJEFOND = (BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) DataSetUtil.CloneOriginalDataRow(this.rowBOLOVANJEFOND);
            }
        }

        private void ScanByELEMENTBOLOVANJEIDELEMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[ELEMENTBOLOVANJEIDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString135 + "  FROM ([BOLOVANJEFOND] TM1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = TM1.[ELEMENTBOLOVANJEIDELEMENT])" + this.m_WhereString + " ORDER BY TM1.[ELEMENTBOLOVANJEIDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString135, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[ELEMENTBOLOVANJEIDELEMENT] ) AS DK_PAGENUM   FROM ([BOLOVANJEFOND] TM1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = TM1.[ELEMENTBOLOVANJEIDELEMENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString135 + " FROM ([BOLOVANJEFOND] TM1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = TM1.[ELEMENTBOLOVANJEIDELEMENT])" + this.m_WhereString + " ORDER BY TM1.[ELEMENTBOLOVANJEIDELEMENT] ";
            }
            this.cmBOLOVANJEFONDSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmBOLOVANJEFONDSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmBOLOVANJEFONDSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            this.cmBOLOVANJEFONDSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
            this.BOLOVANJEFONDSelect4 = this.cmBOLOVANJEFONDSelect4.FetchData();
            this.RcdFound135 = 0;
            this.ScanLoadBolovanjefond();
            this.LoadDataBolovanjefond(maxRows);
        }

        private void ScanEndBolovanjefond()
        {
            this.BOLOVANJEFONDSelect4.Close();
        }

        private void ScanLoadBolovanjefond()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmBOLOVANJEFONDSelect4.HasMoreRows)
            {
                this.RcdFound135 = 1;
                this.rowBOLOVANJEFOND["ELEMENTBOLOVANJENAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BOLOVANJEFONDSelect4, 0));
                this.rowBOLOVANJEFOND["KOLONA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.BOLOVANJEFONDSelect4, 1));
                this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BOLOVANJEFONDSelect4, 2));
                this.rowBOLOVANJEFOND["ELEMENTBOLOVANJENAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BOLOVANJEFONDSelect4, 0));
            }
        }

        private void ScanNextBolovanjefond()
        {
            this.cmBOLOVANJEFONDSelect4.HasMoreRows = this.BOLOVANJEFONDSelect4.Read();
            this.RcdFound135 = 0;
            this.ScanLoadBolovanjefond();
        }

        private void ScanStartBolovanjefond(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString135 + "  FROM ([BOLOVANJEFOND] TM1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = TM1.[ELEMENTBOLOVANJEIDELEMENT])" + this.m_WhereString + " ORDER BY TM1.[ELEMENTBOLOVANJEIDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString135, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[ELEMENTBOLOVANJEIDELEMENT] ) AS DK_PAGENUM   FROM ([BOLOVANJEFOND] TM1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = TM1.[ELEMENTBOLOVANJEIDELEMENT]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString135 + " FROM ([BOLOVANJEFOND] TM1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = TM1.[ELEMENTBOLOVANJEIDELEMENT])" + this.m_WhereString + " ORDER BY TM1.[ELEMENTBOLOVANJEIDELEMENT] ";
            }
            this.cmBOLOVANJEFONDSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.BOLOVANJEFONDSelect4 = this.cmBOLOVANJEFONDSelect4.FetchData();
            this.RcdFound135 = 0;
            this.ScanLoadBolovanjefond();
            this.LoadDataBolovanjefond(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.BOLOVANJEFONDSet = (BOLOVANJEFONDDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.BOLOVANJEFONDSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.BOLOVANJEFONDSet.BOLOVANJEFOND.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        BOLOVANJEFONDDataSet.BOLOVANJEFONDRow current = (BOLOVANJEFONDDataSet.BOLOVANJEFONDRow) enumerator.Current;
                        this.rowBOLOVANJEFOND = current;
                        if (Helpers.IsRowChanged(this.rowBOLOVANJEFOND))
                        {
                            this.ReadRowBolovanjefond();
                            if (this.rowBOLOVANJEFOND.RowState == DataRowState.Added)
                            {
                                this.InsertBolovanjefond();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateBolovanjefond();
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

        private void UpdateBolovanjefond()
        {
            this.CheckOptimisticConcurrencyBolovanjefond();
            this.CheckExtendedTableBolovanjefond();
            this.AfterConfirmBolovanjefond();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [BOLOVANJEFOND] SET [KOLONA]=@KOLONA  WHERE [ELEMENTBOLOVANJEIDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLONA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["KOLONA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBOLOVANJEFOND["ELEMENTBOLOVANJEIDELEMENT"]));
            command.ExecuteStmt();
            this.OnBOLOVANJEFONDUpdated(new BOLOVANJEFONDEventArgs(this.rowBOLOVANJEFOND, StatementType.Update));
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
        public class BOLOVANJEFONDDataChangedException : DataChangedException
        {
            public BOLOVANJEFONDDataChangedException()
            {
            }

            public BOLOVANJEFONDDataChangedException(string message) : base(message)
            {
            }

            protected BOLOVANJEFONDDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BOLOVANJEFONDDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BOLOVANJEFONDDataLockedException : DataLockedException
        {
            public BOLOVANJEFONDDataLockedException()
            {
            }

            public BOLOVANJEFONDDataLockedException(string message) : base(message)
            {
            }

            protected BOLOVANJEFONDDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BOLOVANJEFONDDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BOLOVANJEFONDDuplicateKeyException : DuplicateKeyException
        {
            public BOLOVANJEFONDDuplicateKeyException()
            {
            }

            public BOLOVANJEFONDDuplicateKeyException(string message) : base(message)
            {
            }

            protected BOLOVANJEFONDDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BOLOVANJEFONDDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class BOLOVANJEFONDEventArgs : EventArgs
        {
            private BOLOVANJEFONDDataSet.BOLOVANJEFONDRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public BOLOVANJEFONDEventArgs(BOLOVANJEFONDDataSet.BOLOVANJEFONDRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public BOLOVANJEFONDDataSet.BOLOVANJEFONDRow Row
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
        public class BOLOVANJEFONDNotFoundException : DataNotFoundException
        {
            public BOLOVANJEFONDNotFoundException()
            {
            }

            public BOLOVANJEFONDNotFoundException(string message) : base(message)
            {
            }

            protected BOLOVANJEFONDNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BOLOVANJEFONDNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void BOLOVANJEFONDUpdateEventHandler(object sender, BOLOVANJEFONDDataAdapter.BOLOVANJEFONDEventArgs e);

        [Serializable]
        public class ELEMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ELEMENTForeignKeyNotFoundException()
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ELEMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

