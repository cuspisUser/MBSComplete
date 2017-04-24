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

    public class testDataAdapter : IDataAdapter, ItestDataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove19;
        private bool _Gxremove23;
        private bool _Gxremove27;
        private ReadWriteCommand cmtestLevel1Select2;
        private ReadWriteCommand cmtestLevel2Select2;
        private ReadWriteCommand cmtestLevel3Select2;
        private ReadWriteCommand cmtestSelect1;
        private ReadWriteCommand cmtestSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__kontodopOriginal;
        private object m__kontoelementOriginal;
        private object m__kontoostaloOriginal;
        private object m__mtOriginal;
        private object m__nazivtestOriginal;
        private object m__ojOriginal;
        private object m__stranadopOriginal;
        private object m__stranaelementOriginal;
        private object m__stranaostaloOriginal;
        private readonly string m_SelectString142 = "TM1.[idtest], TM1.[nazivtest], TM1.[oj], TM1.[mt]";
        private string m_SubSelTopString143;
        private string m_SubSelTopString144;
        private string m_SubSelTopString145;
        private string m_WhereString;
        private short RcdFound142;
        private short RcdFound143;
        private short RcdFound144;
        private short RcdFound145;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private testDataSet.testRow rowtest;
        private testDataSet.testLevel1Row rowtestLevel1;
        private testDataSet.testLevel2Row rowtestLevel2;
        private testDataSet.testLevel3Row rowtestLevel3;
        private string scmdbuf;
        private StatementType sMode142;
        private StatementType sMode143;
        private StatementType sMode144;
        private StatementType sMode145;
        private IDataReader testLevel1Select2;
        private IDataReader testLevel2Select2;
        private IDataReader testLevel3Select2;
        private IDataReader testSelect1;
        private IDataReader testSelect4;
        private testDataSet testSet;

        public event testLevel1UpdateEventHandler testLevel1Updated;

        public event testLevel1UpdateEventHandler testLevel1Updating;

        public event testLevel2UpdateEventHandler testLevel2Updated;

        public event testLevel2UpdateEventHandler testLevel2Updating;

        public event testLevel3UpdateEventHandler testLevel3Updated;

        public event testLevel3UpdateEventHandler testLevel3Updating;

        public event testUpdateEventHandler testUpdated;

        public event testUpdateEventHandler testUpdating;

        private void AddRowTest()
        {
            this.testSet.test.AddtestRow(this.rowtest);
        }

        private void AddRowTestlevel1()
        {
            this.testSet.testLevel1.AddtestLevel1Row(this.rowtestLevel1);
        }

        private void AddRowTestlevel2()
        {
            this.testSet.testLevel2.AddtestLevel2Row(this.rowtestLevel2);
        }

        private void AddRowTestlevel3()
        {
            this.testSet.testLevel3.AddtestLevel3Row(this.rowtestLevel3);
        }

        private void AfterConfirmTest()
        {
            this.OntestUpdating(new testEventArgs(this.rowtest, this.Gx_mode));
        }

        private void AfterConfirmTestlevel1()
        {
            this.OntestLevel1Updating(new testLevel1EventArgs(this.rowtestLevel1, this.Gx_mode));
        }

        private void AfterConfirmTestlevel2()
        {
            this.OntestLevel2Updating(new testLevel2EventArgs(this.rowtestLevel2, this.Gx_mode));
        }

        private void AfterConfirmTestlevel3()
        {
            this.OntestLevel3Updating(new testLevel3EventArgs(this.rowtestLevel3, this.Gx_mode));
        }

        private void CheckExtendedTableTestlevel3()
        {
            if ((((string.Compare(this.rowtestLevel3.idostalo.TrimEnd(new char[] { ' ' }), "Bruto plaća".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0) && (string.Compare(this.rowtestLevel3.idostalo.TrimEnd(new char[] { ' ' }), "Neto plaća".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0)) && ((string.Compare(this.rowtestLevel3.idostalo.TrimEnd(new char[] { ' ' }), "Porez".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0) && (string.Compare(this.rowtestLevel3.idostalo.TrimEnd(new char[] { ' ' }), "Prirez".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0))) && (string.Compare(this.rowtestLevel3.idostalo.TrimEnd(new char[] { ' ' }), "Posebni".TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0))
            {
                throw new idostaloOutOfRangeException("Field idostalo is out of range");
            }
        }

        private void CheckIntegrityErrorsTestlevel1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOPRINOS] FROM [DOPRINOS] WITH (NOLOCK) WHERE [IDDOPRINOS] = @IDDOPRINOS ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["IDDOPRINOS"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOPRINOSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOPRINOS") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsTestlevel2()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDELEMENT] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyTest()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [idtest], [nazivtest], [oj], [mt] FROM [test] WITH (UPDLOCK) WHERE [idtest] = @idtest ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtest["idtest"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new testDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("test") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__nazivtestOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || (!this.m__ojOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))) || !this.m__mtOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))))
                {
                    reader.Close();
                    throw new testDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("test") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyTestlevel1()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [idtest], [kontodop], [stranadop], [IDDOPRINOS] FROM [testLevel1] WITH (UPDLOCK) WHERE [idtest] = @idtest AND [IDDOPRINOS] = @IDDOPRINOS ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["idtest"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["IDDOPRINOS"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new testLevel1DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("testLevel1") }));
                }
                if ((!command.HasMoreRows || !this.m__kontodopOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1)))) || !this.m__stranadopOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new testLevel1DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("testLevel1") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyTestlevel2()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [idtest], [kontoelement], [stranaelement], [IDELEMENT] FROM [testLevel2] WITH (UPDLOCK) WHERE [idtest] = @idtest AND [IDELEMENT] = @IDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["idtest"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["IDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new testLevel2DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("testLevel2") }));
                }
                if ((!command.HasMoreRows || !this.m__kontoelementOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1)))) || !this.m__stranaelementOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new testLevel2DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("testLevel2") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyTestlevel3()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [idtest], [idostalo], [kontoostalo], [stranaostalo] FROM [testLevel3] WITH (UPDLOCK) WHERE [idtest] = @idtest AND [idostalo] = @idostalo ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idostalo", DbType.String, 50));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idtest"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idostalo"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new testLevel3DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("testLevel3") }));
                }
                if ((!command.HasMoreRows || !this.m__kontoostaloOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2)))) || !this.m__stranaostaloOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3))))
                {
                    reader.Close();
                    throw new testLevel3DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("testLevel3") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowTest()
        {
            this.rowtest = this.testSet.test.NewtestRow();
        }

        private void CreateNewRowTestlevel1()
        {
            this.rowtestLevel1 = this.testSet.testLevel1.NewtestLevel1Row();
        }

        private void CreateNewRowTestlevel2()
        {
            this.rowtestLevel2 = this.testSet.testLevel2.NewtestLevel2Row();
        }

        private void CreateNewRowTestlevel3()
        {
            this.rowtestLevel3 = this.testSet.testLevel3.NewtestLevel3Row();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTest();
            this.ProcessNestedLevelTestlevel3();
            this.ProcessNestedLevelTestlevel2();
            this.ProcessNestedLevelTestlevel1();
            this.AfterConfirmTest();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [test]  WHERE [idtest] = @idtest", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtest["idtest"]));
            command.ExecuteStmt();
            this.OntestUpdated(new testEventArgs(this.rowtest, StatementType.Delete));
            this.rowtest.Delete();
            this.sMode142 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode142;
        }

        private void DeleteTestlevel1()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTestlevel1();
            this.AfterConfirmTestlevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [testLevel1]  WHERE [idtest] = @idtest AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["idtest"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["IDDOPRINOS"]));
            command.ExecuteStmt();
            this.OntestLevel1Updated(new testLevel1EventArgs(this.rowtestLevel1, StatementType.Delete));
            this.rowtestLevel1.Delete();
            this.sMode143 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode143;
        }

        private void DeleteTestlevel2()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTestlevel2();
            this.AfterConfirmTestlevel2();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [testLevel2]  WHERE [idtest] = @idtest AND [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["idtest"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["IDELEMENT"]));
            command.ExecuteStmt();
            this.OntestLevel2Updated(new testLevel2EventArgs(this.rowtestLevel2, StatementType.Delete));
            this.rowtestLevel2.Delete();
            this.sMode144 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode144;
        }

        private void DeleteTestlevel3()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTestlevel3();
            this.AfterConfirmTestlevel3();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [testLevel3]  WHERE [idtest] = @idtest AND [idostalo] = @idostalo", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idostalo", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idtest"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idostalo"]));
            command.ExecuteStmt();
            this.OntestLevel3Updated(new testLevel3EventArgs(this.rowtestLevel3, StatementType.Delete));
            this.rowtestLevel3.Delete();
            this.sMode145 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode145;
        }

        public virtual int Fill(testDataSet dataSet)
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
                    this.testSet = dataSet;
                    this.LoadChildTest(0, -1);
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
            this.testSet = (testDataSet) dataSet;
            if (this.testSet != null)
            {
                return this.Fill(this.testSet);
            }
            this.testSet = new testDataSet();
            this.Fill(this.testSet);
            dataSet.Merge(this.testSet);
            return 0;
        }

        public virtual int Fill(testDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["idtest"]));
        }

        public virtual int Fill(testDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["idtest"]));
        }

        public virtual int Fill(testDataSet dataSet, int idtest)
        {
            if (!this.FillByidtest(dataSet, idtest))
            {
                throw new testNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("test") }));
            }
            return 0;
        }

        public virtual bool FillByidtest(testDataSet dataSet, int idtest)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.testSet = dataSet;
            this.rowtest = this.testSet.test.NewtestRow();
            this.rowtest.idtest = idtest;
            try
            {
                this.LoadByidtest(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound142 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(testDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.testSet = dataSet;
            try
            {
                this.LoadChildTest(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [idtest], [nazivtest], [oj], [mt] FROM [test] WITH (NOLOCK) WHERE [idtest] = @idtest ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtest["idtest"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound142 = 1;
                this.rowtest["idtest"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowtest["nazivtest"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowtest["oj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.rowtest["mt"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
                this.sMode142 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode142;
            }
            else
            {
                this.RcdFound142 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "idtest";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmtestSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [test] WITH (NOLOCK) ", false);
            this.testSelect1 = this.cmtestSelect1.FetchData();
            if (this.testSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.testSelect1.GetInt32(0);
            }
            this.testSelect1.Close();
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
            this.RcdFound142 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__kontoostaloOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__stranaostaloOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove27 = false;
            this.RcdFound145 = 0;
            this.m_SubSelTopString145 = "";
            this.m__kontoelementOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__stranaelementOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove23 = false;
            this.RcdFound144 = 0;
            this.m_SubSelTopString144 = "";
            this.m__kontodopOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__stranadopOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove19 = false;
            this.RcdFound143 = 0;
            this.m_SubSelTopString143 = "";
            this.m__nazivtestOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ojOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__mtOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.testSet = new testDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertTest()
        {
            this.CheckOptimisticConcurrencyTest();
            this.AfterConfirmTest();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [test] ([idtest], [nazivtest], [oj], [mt]) VALUES (@idtest, @nazivtest, @oj, @mt)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@nazivtest", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@oj", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mt", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtest["idtest"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtest["nazivtest"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowtest["oj"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowtest["mt"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new testDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OntestUpdated(new testEventArgs(this.rowtest, StatementType.Insert));
            this.ProcessLevelTest();
        }

        private void InsertTestlevel1()
        {
            this.CheckOptimisticConcurrencyTestlevel1();
            this.AfterConfirmTestlevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [testLevel1] ([idtest], [kontodop], [stranadop], [IDDOPRINOS]) VALUES (@idtest, @kontodop, @stranadop, @IDDOPRINOS)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@kontodop", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@stranadop", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["idtest"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["kontodop"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["stranadop"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["IDDOPRINOS"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new testLevel1DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsTestlevel1();
            }
            this.OntestLevel1Updated(new testLevel1EventArgs(this.rowtestLevel1, StatementType.Insert));
        }

        private void InsertTestlevel2()
        {
            this.CheckOptimisticConcurrencyTestlevel2();
            this.AfterConfirmTestlevel2();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [testLevel2] ([idtest], [kontoelement], [stranaelement], [IDELEMENT]) VALUES (@idtest, @kontoelement, @stranaelement, @IDELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@kontoelement", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@stranaelement", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["idtest"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["kontoelement"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["stranaelement"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["IDELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new testLevel2DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsTestlevel2();
            }
            this.OntestLevel2Updated(new testLevel2EventArgs(this.rowtestLevel2, StatementType.Insert));
        }

        private void InsertTestlevel3()
        {
            this.CheckOptimisticConcurrencyTestlevel3();
            this.CheckExtendedTableTestlevel3();
            this.AfterConfirmTestlevel3();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [testLevel3] ([idtest], [idostalo], [kontoostalo], [stranaostalo]) VALUES (@idtest, @idostalo, @kontoostalo, @stranaostalo)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idostalo", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@kontoostalo", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@stranaostalo", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idtest"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idostalo"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["kontoostalo"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["stranaostalo"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new testLevel3DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OntestLevel3Updated(new testLevel3EventArgs(this.rowtestLevel3, StatementType.Insert));
        }

        private void LoadByidtest(int startRow, int maxRows)
        {
            bool enforceConstraints = this.testSet.EnforceConstraints;
            this.testSet.testLevel3.BeginLoadData();
            this.testSet.testLevel2.BeginLoadData();
            this.testSet.testLevel1.BeginLoadData();
            this.testSet.test.BeginLoadData();
            this.ScanByidtest(startRow, maxRows);
            this.testSet.testLevel3.EndLoadData();
            this.testSet.testLevel2.EndLoadData();
            this.testSet.testLevel1.EndLoadData();
            this.testSet.test.EndLoadData();
            this.testSet.EnforceConstraints = enforceConstraints;
            if (this.testSet.test.Count > 0)
            {
                this.rowtest = this.testSet.test[this.testSet.test.Count - 1];
            }
        }

        private void LoadChildTest(int startRow, int maxRows)
        {
            this.CreateNewRowTest();
            bool enforceConstraints = this.testSet.EnforceConstraints;
            this.testSet.testLevel3.BeginLoadData();
            this.testSet.testLevel2.BeginLoadData();
            this.testSet.testLevel1.BeginLoadData();
            this.testSet.test.BeginLoadData();
            this.ScanStartTest(startRow, maxRows);
            this.testSet.testLevel3.EndLoadData();
            this.testSet.testLevel2.EndLoadData();
            this.testSet.testLevel1.EndLoadData();
            this.testSet.test.EndLoadData();
            this.testSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildTestlevel1()
        {
            this.CreateNewRowTestlevel1();
            this.ScanStartTestlevel1();
        }

        private void LoadChildTestlevel2()
        {
            this.CreateNewRowTestlevel2();
            this.ScanStartTestlevel2();
        }

        private void LoadChildTestlevel3()
        {
            this.CreateNewRowTestlevel3();
            this.ScanStartTestlevel3();
        }

        private void LoadDataTest(int maxRows)
        {
            int num = 0;
            if (this.RcdFound142 != 0)
            {
                this.ScanLoadTest();
                while ((this.RcdFound142 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowTest();
                    this.CreateNewRowTest();
                    this.ScanNextTest();
                }
            }
            if (num > 0)
            {
                this.RcdFound142 = 1;
            }
            this.ScanEndTest();
            if (this.testSet.test.Count > 0)
            {
                this.rowtest = this.testSet.test[this.testSet.test.Count - 1];
            }
        }

        private void LoadDataTestlevel1()
        {
            while (this.RcdFound143 != 0)
            {
                this.LoadRowTestlevel1();
                this.CreateNewRowTestlevel1();
                this.ScanNextTestlevel1();
            }
            this.ScanEndTestlevel1();
        }

        private void LoadDataTestlevel2()
        {
            while (this.RcdFound144 != 0)
            {
                this.LoadRowTestlevel2();
                this.CreateNewRowTestlevel2();
                this.ScanNextTestlevel2();
            }
            this.ScanEndTestlevel2();
        }

        private void LoadDataTestlevel3()
        {
            while (this.RcdFound145 != 0)
            {
                this.LoadRowTestlevel3();
                this.CreateNewRowTestlevel3();
                this.ScanNextTestlevel3();
            }
            this.ScanEndTestlevel3();
        }

        private void LoadRowTest()
        {
            this.AddRowTest();
        }

        private void LoadRowTestlevel1()
        {
            this.AddRowTestlevel1();
        }

        private void LoadRowTestlevel2()
        {
            this.AddRowTestlevel2();
        }

        private void LoadRowTestlevel3()
        {
            this.AddRowTestlevel3();
        }

        private void OntestLevel1Updated(testLevel1EventArgs e)
        {
            if (this.testLevel1Updated != null)
            {
                testLevel1UpdateEventHandler handler = this.testLevel1Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OntestLevel1Updating(testLevel1EventArgs e)
        {
            if (this.testLevel1Updating != null)
            {
                testLevel1UpdateEventHandler handler = this.testLevel1Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OntestLevel2Updated(testLevel2EventArgs e)
        {
            if (this.testLevel2Updated != null)
            {
                testLevel2UpdateEventHandler handler = this.testLevel2Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OntestLevel2Updating(testLevel2EventArgs e)
        {
            if (this.testLevel2Updating != null)
            {
                testLevel2UpdateEventHandler handler = this.testLevel2Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OntestLevel3Updated(testLevel3EventArgs e)
        {
            if (this.testLevel3Updated != null)
            {
                testLevel3UpdateEventHandler handler = this.testLevel3Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OntestLevel3Updating(testLevel3EventArgs e)
        {
            if (this.testLevel3Updating != null)
            {
                testLevel3UpdateEventHandler handler = this.testLevel3Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OntestUpdated(testEventArgs e)
        {
            if (this.testUpdated != null)
            {
                testUpdateEventHandler testUpdatedEvent = this.testUpdated;
                if (testUpdatedEvent != null)
                {
                    testUpdatedEvent(this, e);
                }
            }
        }

        private void OntestUpdating(testEventArgs e)
        {
            if (this.testUpdating != null)
            {
                testUpdateEventHandler testUpdatingEvent = this.testUpdating;
                if (testUpdatingEvent != null)
                {
                    testUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelTest()
        {
            this.sMode142 = this.Gx_mode;
            this.ProcessNestedLevelTestlevel1();
            this.ProcessNestedLevelTestlevel2();
            this.ProcessNestedLevelTestlevel3();
            this.Gx_mode = this.sMode142;
        }

        private void ProcessNestedLevelTestlevel1()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.testSet.testLevel1.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowtestLevel1 = (testDataSet.testLevel1Row) current;
                    if (Helpers.IsRowChanged(this.rowtestLevel1))
                    {
                        bool flag = false;
                        if (this.rowtestLevel1.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowtestLevel1.idtest == this.rowtest.idtest;
                        }
                        else
                        {
                            flag = this.rowtestLevel1["idtest", DataRowVersion.Original].Equals(this.rowtest.idtest);
                        }
                        if (flag)
                        {
                            this.ReadRowTestlevel1();
                            if (this.rowtestLevel1.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertTestlevel1();
                            }
                            else
                            {
                                if (this._Gxremove19)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteTestlevel1();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateTestlevel1();
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

        private void ProcessNestedLevelTestlevel2()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.testSet.testLevel2.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowtestLevel2 = (testDataSet.testLevel2Row) current;
                    if (Helpers.IsRowChanged(this.rowtestLevel2))
                    {
                        bool flag = false;
                        if (this.rowtestLevel2.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowtestLevel2.idtest == this.rowtest.idtest;
                        }
                        else
                        {
                            flag = this.rowtestLevel2["idtest", DataRowVersion.Original].Equals(this.rowtest.idtest);
                        }
                        if (flag)
                        {
                            this.ReadRowTestlevel2();
                            if (this.rowtestLevel2.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertTestlevel2();
                            }
                            else
                            {
                                if (this._Gxremove23)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteTestlevel2();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateTestlevel2();
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

        private void ProcessNestedLevelTestlevel3()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.testSet.testLevel3.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowtestLevel3 = (testDataSet.testLevel3Row) current;
                    if (Helpers.IsRowChanged(this.rowtestLevel3))
                    {
                        bool flag = false;
                        if (this.rowtestLevel3.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowtestLevel3.idtest == this.rowtest.idtest;
                        }
                        else
                        {
                            flag = this.rowtestLevel3["idtest", DataRowVersion.Original].Equals(this.rowtest.idtest);
                        }
                        if (flag)
                        {
                            this.ReadRowTestlevel3();
                            if (this.rowtestLevel3.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertTestlevel3();
                            }
                            else
                            {
                                if (this._Gxremove27)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteTestlevel3();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateTestlevel3();
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

        private void ReadRowTest()
        {
            this.Gx_mode = Mode.FromRowState(this.rowtest.RowState);
            if (this.rowtest.RowState != DataRowState.Added)
            {
                this.m__nazivtestOriginal = RuntimeHelpers.GetObjectValue(this.rowtest["nazivtest", DataRowVersion.Original]);
                this.m__ojOriginal = RuntimeHelpers.GetObjectValue(this.rowtest["oj", DataRowVersion.Original]);
                this.m__mtOriginal = RuntimeHelpers.GetObjectValue(this.rowtest["mt", DataRowVersion.Original]);
            }
            else
            {
                this.m__nazivtestOriginal = RuntimeHelpers.GetObjectValue(this.rowtest["nazivtest"]);
                this.m__ojOriginal = RuntimeHelpers.GetObjectValue(this.rowtest["oj"]);
                this.m__mtOriginal = RuntimeHelpers.GetObjectValue(this.rowtest["mt"]);
            }
            this._Gxremove = this.rowtest.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowtest = (testDataSet.testRow) DataSetUtil.CloneOriginalDataRow(this.rowtest);
            }
        }

        private void ReadRowTestlevel1()
        {
            this.Gx_mode = Mode.FromRowState(this.rowtestLevel1.RowState);
            if (this.rowtestLevel1.RowState != DataRowState.Added)
            {
                this.m__kontodopOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel1["kontodop", DataRowVersion.Original]);
                this.m__stranadopOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel1["stranadop", DataRowVersion.Original]);
            }
            else
            {
                this.m__kontodopOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel1["kontodop"]);
                this.m__stranadopOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel1["stranadop"]);
            }
            this._Gxremove19 = this.rowtestLevel1.RowState == DataRowState.Deleted;
            if (this._Gxremove19)
            {
                this.rowtestLevel1 = (testDataSet.testLevel1Row) DataSetUtil.CloneOriginalDataRow(this.rowtestLevel1);
            }
        }

        private void ReadRowTestlevel2()
        {
            this.Gx_mode = Mode.FromRowState(this.rowtestLevel2.RowState);
            if (this.rowtestLevel2.RowState != DataRowState.Added)
            {
                this.m__kontoelementOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel2["kontoelement", DataRowVersion.Original]);
                this.m__stranaelementOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel2["stranaelement", DataRowVersion.Original]);
            }
            else
            {
                this.m__kontoelementOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel2["kontoelement"]);
                this.m__stranaelementOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel2["stranaelement"]);
            }
            this._Gxremove23 = this.rowtestLevel2.RowState == DataRowState.Deleted;
            if (this._Gxremove23)
            {
                this.rowtestLevel2 = (testDataSet.testLevel2Row) DataSetUtil.CloneOriginalDataRow(this.rowtestLevel2);
            }
        }

        private void ReadRowTestlevel3()
        {
            this.Gx_mode = Mode.FromRowState(this.rowtestLevel3.RowState);
            if (this.rowtestLevel3.RowState != DataRowState.Added)
            {
                this.m__kontoostaloOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel3["kontoostalo", DataRowVersion.Original]);
                this.m__stranaostaloOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel3["stranaostalo", DataRowVersion.Original]);
            }
            else
            {
                this.m__kontoostaloOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel3["kontoostalo"]);
                this.m__stranaostaloOriginal = RuntimeHelpers.GetObjectValue(this.rowtestLevel3["stranaostalo"]);
            }
            this._Gxremove27 = this.rowtestLevel3.RowState == DataRowState.Deleted;
            if (this._Gxremove27)
            {
                this.rowtestLevel3 = (testDataSet.testLevel3Row) DataSetUtil.CloneOriginalDataRow(this.rowtestLevel3);
            }
        }

        private void ScanByidtest(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[idtest] = @idtest";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString142 + "  FROM [test] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[idtest]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString142, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[idtest] ) AS DK_PAGENUM   FROM [test] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString142 + " FROM [test] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[idtest] ";
            }
            this.cmtestSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmtestSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmtestSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
            }
            this.cmtestSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtest["idtest"]));
            this.testSelect4 = this.cmtestSelect4.FetchData();
            this.RcdFound142 = 0;
            this.ScanLoadTest();
            this.LoadDataTest(maxRows);
            if (this.RcdFound142 > 0)
            {
                this.SubLvlScanStartTestlevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersidtestTest(this.cmtestLevel1Select2);
                this.SubLvlFetchTestlevel1();
                this.SubLoadDataTestlevel1();
                this.SubLvlScanStartTestlevel2(this.m_WhereString, startRow, maxRows);
                this.SetParametersidtestTest(this.cmtestLevel2Select2);
                this.SubLvlFetchTestlevel2();
                this.SubLoadDataTestlevel2();
                this.SubLvlScanStartTestlevel3(this.m_WhereString, startRow, maxRows);
                this.SetParametersidtestTest(this.cmtestLevel3Select2);
                this.SubLvlFetchTestlevel3();
                this.SubLoadDataTestlevel3();
            }
        }

        private void ScanEndTest()
        {
            this.testSelect4.Close();
        }

        private void ScanEndTestlevel1()
        {
            this.testLevel1Select2.Close();
        }

        private void ScanEndTestlevel2()
        {
            this.testLevel2Select2.Close();
        }

        private void ScanEndTestlevel3()
        {
            this.testLevel3Select2.Close();
        }

        private void ScanLoadTest()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmtestSelect4.HasMoreRows)
            {
                this.RcdFound142 = 1;
                this.rowtest["idtest"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testSelect4, 0));
                this.rowtest["nazivtest"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.testSelect4, 1));
                this.rowtest["oj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testSelect4, 2));
                this.rowtest["mt"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testSelect4, 3));
            }
        }

        private void ScanLoadTestlevel1()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmtestLevel1Select2.HasMoreRows)
            {
                this.RcdFound143 = 1;
                this.rowtestLevel1["idtest"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel1Select2, 0));
                this.rowtestLevel1["kontodop"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel1Select2, 1));
                this.rowtestLevel1["stranadop"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel1Select2, 2));
                this.rowtestLevel1["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel1Select2, 3));
            }
        }

        private void ScanLoadTestlevel2()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmtestLevel2Select2.HasMoreRows)
            {
                this.RcdFound144 = 1;
                this.rowtestLevel2["idtest"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel2Select2, 0));
                this.rowtestLevel2["kontoelement"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel2Select2, 1));
                this.rowtestLevel2["stranaelement"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel2Select2, 2));
                this.rowtestLevel2["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel2Select2, 3));
            }
        }

        private void ScanLoadTestlevel3()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmtestLevel3Select2.HasMoreRows)
            {
                this.RcdFound145 = 1;
                this.rowtestLevel3["idtest"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel3Select2, 0));
                this.rowtestLevel3["idostalo"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.testLevel3Select2, 1));
                this.rowtestLevel3["kontoostalo"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel3Select2, 2));
                this.rowtestLevel3["stranaostalo"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.testLevel3Select2, 3));
            }
        }

        private void ScanNextTest()
        {
            this.cmtestSelect4.HasMoreRows = this.testSelect4.Read();
            this.RcdFound142 = 0;
            this.ScanLoadTest();
        }

        private void ScanNextTestlevel1()
        {
            this.cmtestLevel1Select2.HasMoreRows = this.testLevel1Select2.Read();
            this.RcdFound143 = 0;
            this.ScanLoadTestlevel1();
        }

        private void ScanNextTestlevel2()
        {
            this.cmtestLevel2Select2.HasMoreRows = this.testLevel2Select2.Read();
            this.RcdFound144 = 0;
            this.ScanLoadTestlevel2();
        }

        private void ScanNextTestlevel3()
        {
            this.cmtestLevel3Select2.HasMoreRows = this.testLevel3Select2.Read();
            this.RcdFound145 = 0;
            this.ScanLoadTestlevel3();
        }

        private void ScanStartTest(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString142 + "  FROM [test] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[idtest]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString142, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[idtest] ) AS DK_PAGENUM   FROM [test] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString142 + " FROM [test] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[idtest] ";
            }
            this.cmtestSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.testSelect4 = this.cmtestSelect4.FetchData();
            this.RcdFound142 = 0;
            this.ScanLoadTest();
            this.LoadDataTest(maxRows);
            if (this.RcdFound142 > 0)
            {
                this.SubLvlScanStartTestlevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersTestTest(this.cmtestLevel1Select2);
                this.SubLvlFetchTestlevel1();
                this.SubLoadDataTestlevel1();
                this.SubLvlScanStartTestlevel2(this.m_WhereString, startRow, maxRows);
                this.SetParametersTestTest(this.cmtestLevel2Select2);
                this.SubLvlFetchTestlevel2();
                this.SubLoadDataTestlevel2();
                this.SubLvlScanStartTestlevel3(this.m_WhereString, startRow, maxRows);
                this.SetParametersTestTest(this.cmtestLevel3Select2);
                this.SubLvlFetchTestlevel3();
                this.SubLoadDataTestlevel3();
            }
        }

        private void ScanStartTestlevel1()
        {
            this.cmtestLevel1Select2 = this.connDefault.GetCommand("SELECT [idtest], [kontodop], [stranadop], [IDDOPRINOS] FROM [testLevel1] WITH (NOLOCK) WHERE [idtest] = @idtest ORDER BY [idtest], [IDDOPRINOS] ", false);
            if (this.cmtestLevel1Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmtestLevel1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
            }
            this.cmtestLevel1Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["idtest"]));
            this.testLevel1Select2 = this.cmtestLevel1Select2.FetchData();
            this.RcdFound143 = 0;
            this.ScanLoadTestlevel1();
        }

        private void ScanStartTestlevel2()
        {
            this.cmtestLevel2Select2 = this.connDefault.GetCommand("SELECT [idtest], [kontoelement], [stranaelement], [IDELEMENT] FROM [testLevel2] WITH (NOLOCK) WHERE [idtest] = @idtest ORDER BY [idtest], [IDELEMENT] ", false);
            if (this.cmtestLevel2Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmtestLevel2Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
            }
            this.cmtestLevel2Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["idtest"]));
            this.testLevel2Select2 = this.cmtestLevel2Select2.FetchData();
            this.RcdFound144 = 0;
            this.ScanLoadTestlevel2();
        }

        private void ScanStartTestlevel3()
        {
            this.cmtestLevel3Select2 = this.connDefault.GetCommand("SELECT [idtest], [idostalo], [kontoostalo], [stranaostalo] FROM [testLevel3] WITH (NOLOCK) WHERE [idtest] = @idtest ORDER BY [idtest], [idostalo] ", false);
            if (this.cmtestLevel3Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmtestLevel3Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
            }
            this.cmtestLevel3Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idtest"]));
            this.testLevel3Select2 = this.cmtestLevel3Select2.FetchData();
            this.RcdFound145 = 0;
            this.ScanLoadTestlevel3();
        }

        private void SetParametersidtestTest(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtest["idtest"]));
        }

        private void SetParametersTestTest(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextTestlevel1()
        {
            this.cmtestLevel1Select2.HasMoreRows = this.testLevel1Select2.Read();
            this.RcdFound143 = 0;
            if (this.cmtestLevel1Select2.HasMoreRows)
            {
                this.RcdFound143 = 1;
            }
        }

        private void SkipNextTestlevel2()
        {
            this.cmtestLevel2Select2.HasMoreRows = this.testLevel2Select2.Read();
            this.RcdFound144 = 0;
            if (this.cmtestLevel2Select2.HasMoreRows)
            {
                this.RcdFound144 = 1;
            }
        }

        private void SkipNextTestlevel3()
        {
            this.cmtestLevel3Select2.HasMoreRows = this.testLevel3Select2.Read();
            this.RcdFound145 = 0;
            if (this.cmtestLevel3Select2.HasMoreRows)
            {
                this.RcdFound145 = 1;
            }
        }

        private void SubLoadDataTestlevel1()
        {
            while (this.RcdFound143 != 0)
            {
                this.LoadRowTestlevel1();
                this.CreateNewRowTestlevel1();
                this.ScanNextTestlevel1();
            }
            this.ScanEndTestlevel1();
        }

        private void SubLoadDataTestlevel2()
        {
            while (this.RcdFound144 != 0)
            {
                this.LoadRowTestlevel2();
                this.CreateNewRowTestlevel2();
                this.ScanNextTestlevel2();
            }
            this.ScanEndTestlevel2();
        }

        private void SubLoadDataTestlevel3()
        {
            while (this.RcdFound145 != 0)
            {
                this.LoadRowTestlevel3();
                this.CreateNewRowTestlevel3();
                this.ScanNextTestlevel3();
            }
            this.ScanEndTestlevel3();
        }

        private void SubLvlFetchTestlevel1()
        {
            this.CreateNewRowTestlevel1();
            this.testLevel1Select2 = this.cmtestLevel1Select2.FetchData();
            this.RcdFound143 = 0;
            this.ScanLoadTestlevel1();
        }

        private void SubLvlFetchTestlevel2()
        {
            this.CreateNewRowTestlevel2();
            this.testLevel2Select2 = this.cmtestLevel2Select2.FetchData();
            this.RcdFound144 = 0;
            this.ScanLoadTestlevel2();
        }

        private void SubLvlFetchTestlevel3()
        {
            this.CreateNewRowTestlevel3();
            this.testLevel3Select2 = this.cmtestLevel3Select2.FetchData();
            this.RcdFound145 = 0;
            this.ScanLoadTestlevel3();
        }

        private void SubLvlScanStartTestlevel1(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString143 = "(SELECT TOP " + maxRows.ToString() + " TM1.[idtest]  FROM [test]  TM1 " + this.m_WhereString + " ORDER BY TM1.[idtest] )";
                    this.scmdbuf = "SELECT T1.[idtest], T1.[kontodop], T1.[stranadop], T1.[IDDOPRINOS] FROM ([testLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString143 + "  TMX ON TMX.[idtest] = T1.[idtest]) ORDER BY T1.[idtest], T1.[IDDOPRINOS]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[idtest], ROW_NUMBER() OVER  (  ORDER BY TM1.[idtest]  ) AS DK_PAGENUM   FROM [test]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString143 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[idtest], T1.[kontodop], T1.[stranadop], T1.[IDDOPRINOS] FROM ([testLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString143 + "  TMX ON TMX.[idtest] = T1.[idtest]) ORDER BY T1.[idtest], T1.[IDDOPRINOS]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString143 = "[test]";
                this.scmdbuf = "SELECT T1.[idtest], T1.[kontodop], T1.[stranadop], T1.[IDDOPRINOS] FROM ([testLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString143 + "  TM1 WITH (NOLOCK) ON TM1.[idtest] = T1.[idtest])" + this.m_WhereString + " ORDER BY T1.[idtest], T1.[IDDOPRINOS] ";
            }
            this.cmtestLevel1Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartTestlevel2(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString144 = "(SELECT TOP " + maxRows.ToString() + " TM1.[idtest]  FROM [test]  TM1 " + this.m_WhereString + " ORDER BY TM1.[idtest] )";
                    this.scmdbuf = "SELECT T1.[idtest], T1.[kontoelement], T1.[stranaelement], T1.[IDELEMENT] FROM ([testLevel2] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString144 + "  TMX ON TMX.[idtest] = T1.[idtest]) ORDER BY T1.[idtest], T1.[IDELEMENT]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[idtest], ROW_NUMBER() OVER  (  ORDER BY TM1.[idtest]  ) AS DK_PAGENUM   FROM [test]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString144 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[idtest], T1.[kontoelement], T1.[stranaelement], T1.[IDELEMENT] FROM ([testLevel2] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString144 + "  TMX ON TMX.[idtest] = T1.[idtest]) ORDER BY T1.[idtest], T1.[IDELEMENT]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString144 = "[test]";
                this.scmdbuf = "SELECT T1.[idtest], T1.[kontoelement], T1.[stranaelement], T1.[IDELEMENT] FROM ([testLevel2] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString144 + "  TM1 WITH (NOLOCK) ON TM1.[idtest] = T1.[idtest])" + this.m_WhereString + " ORDER BY T1.[idtest], T1.[IDELEMENT] ";
            }
            this.cmtestLevel2Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartTestlevel3(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString145 = "(SELECT TOP " + maxRows.ToString() + " TM1.[idtest]  FROM [test]  TM1 " + this.m_WhereString + " ORDER BY TM1.[idtest] )";
                    this.scmdbuf = "SELECT T1.[idtest], T1.[idostalo], T1.[kontoostalo], T1.[stranaostalo] FROM ([testLevel3] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString145 + "  TMX ON TMX.[idtest] = T1.[idtest]) ORDER BY T1.[idtest], T1.[idostalo]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[idtest], ROW_NUMBER() OVER  (  ORDER BY TM1.[idtest]  ) AS DK_PAGENUM   FROM [test]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString145 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[idtest], T1.[idostalo], T1.[kontoostalo], T1.[stranaostalo] FROM ([testLevel3] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString145 + "  TMX ON TMX.[idtest] = T1.[idtest]) ORDER BY T1.[idtest], T1.[idostalo]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString145 = "[test]";
                this.scmdbuf = "SELECT T1.[idtest], T1.[idostalo], T1.[kontoostalo], T1.[stranaostalo] FROM ([testLevel3] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString145 + "  TM1 WITH (NOLOCK) ON TM1.[idtest] = T1.[idtest])" + this.m_WhereString + " ORDER BY T1.[idtest], T1.[idostalo] ";
            }
            this.cmtestLevel3Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.testSet = (testDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.testSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.testSet.test.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        testDataSet.testRow current = (testDataSet.testRow) enumerator.Current;
                        this.rowtest = current;
                        if (Helpers.IsRowChanged(this.rowtest))
                        {
                            this.ReadRowTest();
                            if (this.rowtest.RowState == DataRowState.Added)
                            {
                                this.InsertTest();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateTest();
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

        private void UpdateTest()
        {
            this.CheckOptimisticConcurrencyTest();
            this.AfterConfirmTest();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [test] SET [nazivtest]=@nazivtest, [oj]=@oj, [mt]=@mt  WHERE [idtest] = @idtest", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@nazivtest", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@oj", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mt", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtest["nazivtest"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtest["oj"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowtest["mt"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowtest["idtest"]));
            command.ExecuteStmt();
            this.OntestUpdated(new testEventArgs(this.rowtest, StatementType.Update));
            this.ProcessLevelTest();
        }

        private void UpdateTestlevel1()
        {
            this.CheckOptimisticConcurrencyTestlevel1();
            this.AfterConfirmTestlevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [testLevel1] SET [kontodop]=@kontodop, [stranadop]=@stranadop  WHERE [idtest] = @idtest AND [IDDOPRINOS] = @IDDOPRINOS", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@kontodop", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@stranadop", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["kontodop"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["stranadop"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["idtest"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowtestLevel1["IDDOPRINOS"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsTestlevel1();
            }
            this.OntestLevel1Updated(new testLevel1EventArgs(this.rowtestLevel1, StatementType.Update));
        }

        private void UpdateTestlevel2()
        {
            this.CheckOptimisticConcurrencyTestlevel2();
            this.AfterConfirmTestlevel2();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [testLevel2] SET [kontoelement]=@kontoelement, [stranaelement]=@stranaelement  WHERE [idtest] = @idtest AND [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@kontoelement", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@stranaelement", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["kontoelement"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["stranaelement"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["idtest"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowtestLevel2["IDELEMENT"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsTestlevel2();
            }
            this.OntestLevel2Updated(new testLevel2EventArgs(this.rowtestLevel2, StatementType.Update));
        }

        private void UpdateTestlevel3()
        {
            this.CheckOptimisticConcurrencyTestlevel3();
            this.CheckExtendedTableTestlevel3();
            this.AfterConfirmTestlevel3();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [testLevel3] SET [kontoostalo]=@kontoostalo, [stranaostalo]=@stranaostalo  WHERE [idtest] = @idtest AND [idostalo] = @idostalo", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@kontoostalo", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@stranaostalo", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idtest", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idostalo", DbType.String, 50));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["kontoostalo"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["stranaostalo"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idtest"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowtestLevel3["idostalo"]));
            command.ExecuteStmt();
            this.OntestLevel3Updated(new testLevel3EventArgs(this.rowtestLevel3, StatementType.Update));
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
        public class DOPRINOSForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DOPRINOSForeignKeyNotFoundException()
            {
            }

            public DOPRINOSForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DOPRINOSForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOPRINOSForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

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
        public class idostaloOutOfRangeException : UserException
        {
            public idostaloOutOfRangeException()
            {
            }

            public idostaloOutOfRangeException(string message) : base(message)
            {
            }

            protected idostaloOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public idostaloOutOfRangeException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testDataChangedException : DataChangedException
        {
            public testDataChangedException()
            {
            }

            public testDataChangedException(string message) : base(message)
            {
            }

            protected testDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testDataLockedException : DataLockedException
        {
            public testDataLockedException()
            {
            }

            public testDataLockedException(string message) : base(message)
            {
            }

            protected testDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testDuplicateKeyException : DuplicateKeyException
        {
            public testDuplicateKeyException()
            {
            }

            public testDuplicateKeyException(string message) : base(message)
            {
            }

            protected testDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class testEventArgs : EventArgs
        {
            private testDataSet.testRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public testEventArgs(testDataSet.testRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public testDataSet.testRow Row
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
        public class testLevel1DataChangedException : DataChangedException
        {
            public testLevel1DataChangedException()
            {
            }

            public testLevel1DataChangedException(string message) : base(message)
            {
            }

            protected testLevel1DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel1DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testLevel1DataLockedException : DataLockedException
        {
            public testLevel1DataLockedException()
            {
            }

            public testLevel1DataLockedException(string message) : base(message)
            {
            }

            protected testLevel1DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel1DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testLevel1DuplicateKeyException : DuplicateKeyException
        {
            public testLevel1DuplicateKeyException()
            {
            }

            public testLevel1DuplicateKeyException(string message) : base(message)
            {
            }

            protected testLevel1DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel1DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class testLevel1EventArgs : EventArgs
        {
            private testDataSet.testLevel1Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public testLevel1EventArgs(testDataSet.testLevel1Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public testDataSet.testLevel1Row Row
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

        public delegate void testLevel1UpdateEventHandler(object sender, testDataAdapter.testLevel1EventArgs e);

        [Serializable]
        public class testLevel2DataChangedException : DataChangedException
        {
            public testLevel2DataChangedException()
            {
            }

            public testLevel2DataChangedException(string message) : base(message)
            {
            }

            protected testLevel2DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel2DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testLevel2DataLockedException : DataLockedException
        {
            public testLevel2DataLockedException()
            {
            }

            public testLevel2DataLockedException(string message) : base(message)
            {
            }

            protected testLevel2DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel2DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testLevel2DuplicateKeyException : DuplicateKeyException
        {
            public testLevel2DuplicateKeyException()
            {
            }

            public testLevel2DuplicateKeyException(string message) : base(message)
            {
            }

            protected testLevel2DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel2DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class testLevel2EventArgs : EventArgs
        {
            private testDataSet.testLevel2Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public testLevel2EventArgs(testDataSet.testLevel2Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public testDataSet.testLevel2Row Row
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

        public delegate void testLevel2UpdateEventHandler(object sender, testDataAdapter.testLevel2EventArgs e);

        [Serializable]
        public class testLevel3DataChangedException : DataChangedException
        {
            public testLevel3DataChangedException()
            {
            }

            public testLevel3DataChangedException(string message) : base(message)
            {
            }

            protected testLevel3DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel3DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testLevel3DataLockedException : DataLockedException
        {
            public testLevel3DataLockedException()
            {
            }

            public testLevel3DataLockedException(string message) : base(message)
            {
            }

            protected testLevel3DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel3DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class testLevel3DuplicateKeyException : DuplicateKeyException
        {
            public testLevel3DuplicateKeyException()
            {
            }

            public testLevel3DuplicateKeyException(string message) : base(message)
            {
            }

            protected testLevel3DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testLevel3DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class testLevel3EventArgs : EventArgs
        {
            private testDataSet.testLevel3Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public testLevel3EventArgs(testDataSet.testLevel3Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public testDataSet.testLevel3Row Row
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

        public delegate void testLevel3UpdateEventHandler(object sender, testDataAdapter.testLevel3EventArgs e);

        [Serializable]
        public class testNotFoundException : DataNotFoundException
        {
            public testNotFoundException()
            {
            }

            public testNotFoundException(string message) : base(message)
            {
            }

            protected testNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public testNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void testUpdateEventHandler(object sender, testDataAdapter.testEventArgs e);
    }
}

