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

    public class PROIZVODDataAdapter : IDataAdapter, IPROIZVODDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmPROIZVODSelect1;
        private ReadWriteCommand cmPROIZVODSelect2;
        private ReadWriteCommand cmPROIZVODSelect3;
        private ReadWriteCommand cmPROIZVODSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__CIJENAOriginal;
        private object m__FINPOREZIDPOREZOriginal;
        private object m__IDJEDINICAMJEREOriginal;
        private object m__CijenaPDVOriginal;
        private object m__NAZIVPROIZVODOriginal;
        private readonly string m_SelectString207 = "TM1.[IDPROIZVOD], TM1.[NAZIVPROIZVOD], T2.[FINPOREZSTOPA], TM1.[CIJENA], T3.[NAZIVJEDINICAMJERE], TM1.[FINPOREZIDPOREZ], TM1.[IDJEDINICAMJERE], TM1.[CijenaPDV], MT_GrupeProizvoda.Naziv As Grupa";
        private string m_WhereString;
        private IDataReader PROIZVODSelect1;
        private IDataReader PROIZVODSelect2;
        private IDataReader PROIZVODSelect3;
        private IDataReader PROIZVODSelect6;
        private PROIZVODDataSet PROIZVODSet;
        private short RcdFound207;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private PROIZVODDataSet.PROIZVODRow rowPROIZVOD;
        private string scmdbuf;
        private StatementType sMode207;

        public event PROIZVODUpdateEventHandler PROIZVODUpdated;

        public event PROIZVODUpdateEventHandler PROIZVODUpdating;

        private void AddRowProizvod()
        {
            this.PROIZVODSet.PROIZVOD.AddPROIZVODRow(this.rowPROIZVOD);
        }

        private void AfterConfirmProizvod()
        {
            this.OnPROIZVODUpdating(new PROIZVODEventArgs(this.rowPROIZVOD, this.Gx_mode));
        }

        private void CheckDeleteErrorsProizvod()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDPARTNER], [IDZADUZENJE] FROM [PARTNERZADUZENJE] WITH (NOLOCK) WHERE [IDPROIZVOD] = @IDPROIZVOD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDPROIZVOD"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new PARTNERZADUZENJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Zaduzenja partnera" }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDRACUN], [RACUNGODINAIDGODINE], [BROJSTAVKE] FROM [RACUNRacunStavke] WITH (NOLOCK) WHERE [IDPROIZVOD] = @IDPROIZVOD ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDPROIZVOD"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new RACUNRacunStavkeInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Stavke racuna" }));
            }
            reader2.Close();
        }

        private void CheckExtendedTableProizvod()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [FINPOREZSTOPA] FROM [FINPOREZ] WITH (NOLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["FINPOREZIDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new FINPOREZForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("FINPOREZ") }));
            }
            this.rowPROIZVOD["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0));
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVJEDINICAMJERE] FROM [JEDINICAMJERE] WITH (NOLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDJEDINICAMJERE"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new JEDINICAMJEREForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("JEDINICAMJERE") }));
            }
            this.rowPROIZVOD["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            reader2.Close();
        }

        private void CheckOptimisticConcurrencyProizvod()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPROIZVOD], [NAZIVPROIZVOD], [CIJENA], [FINPOREZIDPOREZ], [IDJEDINICAMJERE], [CijenaPDV] FROM [PROIZVOD] WITH (UPDLOCK) WHERE [IDPROIZVOD] = @IDPROIZVOD ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDPROIZVOD"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PROIZVODDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PROIZVOD") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVPROIZVODOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!this.m__CIJENAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__FINPOREZIDPOREZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))) || !this.m__IDJEDINICAMJEREOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4)))))
                {
                    reader.Close();
                    throw new PROIZVODDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PROIZVOD") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowProizvod()
        {
            this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD.NewPROIZVODRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyProizvod();
            this.OnDeleteControlsProizvod();
            this.AfterConfirmProizvod();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PROIZVOD]  WHERE [IDPROIZVOD] = @IDPROIZVOD", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDPROIZVOD"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsProizvod();
            }
            this.OnPROIZVODUpdated(new PROIZVODEventArgs(this.rowPROIZVOD, StatementType.Delete));
            this.rowPROIZVOD.Delete();
            this.sMode207 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode207;
        }

        public virtual int Fill(PROIZVODDataSet dataSet)
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
                    this.PROIZVODSet = dataSet;
                    this.LoadChildProizvod(0, -1);
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
            this.PROIZVODSet = (PROIZVODDataSet) dataSet;
            if (this.PROIZVODSet != null)
            {
                return this.Fill(this.PROIZVODSet);
            }
            this.PROIZVODSet = new PROIZVODDataSet();
            this.Fill(this.PROIZVODSet);
            dataSet.Merge(this.PROIZVODSet);
            return 0;
        }

        public virtual int Fill(PROIZVODDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPROIZVOD"]));
        }

        public virtual int Fill(PROIZVODDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPROIZVOD"]));
        }

        public virtual int Fill(PROIZVODDataSet dataSet, int iDPROIZVOD)
        {
            if (!this.FillByIDPROIZVOD(dataSet, iDPROIZVOD))
            {
                throw new PROIZVODNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PROIZVOD") }));
            }
            return 0;
        }

        public virtual int FillByFINPOREZIDPOREZ(PROIZVODDataSet dataSet, int fINPOREZIDPOREZ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PROIZVODSet = dataSet;
            this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD.NewPROIZVODRow();
            this.rowPROIZVOD.FINPOREZIDPOREZ = fINPOREZIDPOREZ;
            try
            {
                this.LoadByFINPOREZIDPOREZ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDJEDINICAMJERE(PROIZVODDataSet dataSet, int iDJEDINICAMJERE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PROIZVODSet = dataSet;
            this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD.NewPROIZVODRow();
            this.rowPROIZVOD.IDJEDINICAMJERE = iDJEDINICAMJERE;
            try
            {
                this.LoadByIDJEDINICAMJERE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDPROIZVOD(PROIZVODDataSet dataSet, int iDPROIZVOD)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PROIZVODSet = dataSet;
            this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD.NewPROIZVODRow();
            this.rowPROIZVOD.IDPROIZVOD = iDPROIZVOD;
            try
            {
                this.LoadByIDPROIZVOD(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound207 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(PROIZVODDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PROIZVODSet = dataSet;
            try
            {
                this.LoadChildProizvod(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByFINPOREZIDPOREZ(PROIZVODDataSet dataSet, int fINPOREZIDPOREZ, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PROIZVODSet = dataSet;
            this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD.NewPROIZVODRow();
            this.rowPROIZVOD.FINPOREZIDPOREZ = fINPOREZIDPOREZ;
            try
            {
                this.LoadByFINPOREZIDPOREZ(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDJEDINICAMJERE(PROIZVODDataSet dataSet, int iDJEDINICAMJERE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PROIZVODSet = dataSet;
            this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD.NewPROIZVODRow();
            this.rowPROIZVOD.IDJEDINICAMJERE = iDJEDINICAMJERE;
            try
            {
                this.LoadByIDJEDINICAMJERE(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPROIZVOD], [NAZIVPROIZVOD], [CIJENA], [FINPOREZIDPOREZ], [IDJEDINICAMJERE], [CijenaPDV] FROM [PROIZVOD] WITH (NOLOCK) WHERE [IDPROIZVOD] = @IDPROIZVOD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDPROIZVOD"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound207 = 1;
                this.rowPROIZVOD["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowPROIZVOD["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowPROIZVOD["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowPROIZVOD["FINPOREZIDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
                this.rowPROIZVOD["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4));
                this.rowPROIZVOD["CijenaPDV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5));
                this.Gx_mode = StatementType.Select;
                this.LoadProizvod();
                this.Gx_mode = this.sMode207;
            }
            else
            {
                this.RcdFound207 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDPROIZVOD";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPROIZVODSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PROIZVOD] WITH (NOLOCK) ", false);
            this.PROIZVODSelect3 = this.cmPROIZVODSelect3.FetchData();
            if (this.PROIZVODSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PROIZVODSelect3.GetInt32(0);
            }
            this.PROIZVODSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByFINPOREZIDPOREZ(int fINPOREZIDPOREZ)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPROIZVODSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PROIZVOD] WITH (NOLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
            if (this.cmPROIZVODSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            this.cmPROIZVODSelect2.SetParameter(0, fINPOREZIDPOREZ);
            this.PROIZVODSelect2 = this.cmPROIZVODSelect2.FetchData();
            if (this.PROIZVODSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PROIZVODSelect2.GetInt32(0);
            }
            this.PROIZVODSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDJEDINICAMJERE(int iDJEDINICAMJERE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPROIZVODSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PROIZVOD] WITH (NOLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
            if (this.cmPROIZVODSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            this.cmPROIZVODSelect1.SetParameter(0, iDJEDINICAMJERE);
            this.PROIZVODSelect1 = this.cmPROIZVODSelect1.FetchData();
            if (this.PROIZVODSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PROIZVODSelect1.GetInt32(0);
            }
            this.PROIZVODSelect1.Close();
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

        public virtual int GetRecordCountByFINPOREZIDPOREZ(int fINPOREZIDPOREZ)
        {
            int internalRecordCountByFINPOREZIDPOREZ;
            try
            {
                this.InitializeMembers();
                internalRecordCountByFINPOREZIDPOREZ = this.GetInternalRecordCountByFINPOREZIDPOREZ(fINPOREZIDPOREZ);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByFINPOREZIDPOREZ;
        }

        public virtual int GetRecordCountByIDJEDINICAMJERE(int iDJEDINICAMJERE)
        {
            int internalRecordCountByIDJEDINICAMJERE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDJEDINICAMJERE = this.GetInternalRecordCountByIDJEDINICAMJERE(iDJEDINICAMJERE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDJEDINICAMJERE;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound207 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVPROIZVODOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__CIJENAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__FINPOREZIDPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDJEDINICAMJEREOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__CijenaPDVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.PROIZVODSet = new PROIZVODDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertProizvod()
        {
            this.CheckOptimisticConcurrencyProizvod();
            this.CheckExtendedTableProizvod();
            this.AfterConfirmProizvod();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PROIZVOD] ([IDPROIZVOD], [NAZIVPROIZVOD], [CIJENA], [FINPOREZIDPOREZ], [IDJEDINICAMJERE], [CijenaPDV]) VALUES (@IDPROIZVOD, @NAZIVPROIZVOD, @CIJENA, @FINPOREZIDPOREZ, @IDJEDINICAMJERE, @CijenaPDV)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPROIZVOD", DbType.String, 500));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CIJENA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CijenaPDV", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDPROIZVOD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["NAZIVPROIZVOD"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["CIJENA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["FINPOREZIDPOREZ"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDJEDINICAMJERE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["CijenaPDV"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PROIZVODDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPROIZVODUpdated(new PROIZVODEventArgs(this.rowPROIZVOD, StatementType.Insert));
        }

        private void LoadByFINPOREZIDPOREZ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PROIZVODSet.EnforceConstraints;
            this.PROIZVODSet.PROIZVOD.BeginLoadData();
            this.ScanByFINPOREZIDPOREZ(startRow, maxRows);
            this.PROIZVODSet.PROIZVOD.EndLoadData();
            this.PROIZVODSet.EnforceConstraints = enforceConstraints;
            if (this.PROIZVODSet.PROIZVOD.Count > 0)
            {
                this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD[this.PROIZVODSet.PROIZVOD.Count - 1];
            }
        }

        private void LoadByIDJEDINICAMJERE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PROIZVODSet.EnforceConstraints;
            this.PROIZVODSet.PROIZVOD.BeginLoadData();
            this.ScanByIDJEDINICAMJERE(startRow, maxRows);
            this.PROIZVODSet.PROIZVOD.EndLoadData();
            this.PROIZVODSet.EnforceConstraints = enforceConstraints;
            if (this.PROIZVODSet.PROIZVOD.Count > 0)
            {
                this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD[this.PROIZVODSet.PROIZVOD.Count - 1];
            }
        }

        private void LoadByIDPROIZVOD(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PROIZVODSet.EnforceConstraints;
            this.PROIZVODSet.PROIZVOD.BeginLoadData();
            this.ScanByIDPROIZVOD(startRow, maxRows);
            this.PROIZVODSet.PROIZVOD.EndLoadData();
            this.PROIZVODSet.EnforceConstraints = enforceConstraints;
            if (this.PROIZVODSet.PROIZVOD.Count > 0)
            {
                this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD[this.PROIZVODSet.PROIZVOD.Count - 1];
            }
        }

        private void LoadChildProizvod(int startRow, int maxRows)
        {
            this.CreateNewRowProizvod();
            bool enforceConstraints = this.PROIZVODSet.EnforceConstraints;
            this.PROIZVODSet.PROIZVOD.BeginLoadData();
            this.ScanStartProizvod(startRow, maxRows);
            this.PROIZVODSet.PROIZVOD.EndLoadData();
            this.PROIZVODSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataProizvod(int maxRows)
        {
            int num = 0;
            if (this.RcdFound207 != 0)
            {
                this.ScanLoadProizvod();
                while ((this.RcdFound207 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowProizvod();
                    this.CreateNewRowProizvod();
                    this.ScanNextProizvod();
                }
            }
            if (num > 0)
            {
                this.RcdFound207 = 1;
            }
            this.ScanEndProizvod();
            if (this.PROIZVODSet.PROIZVOD.Count > 0)
            {
                this.rowPROIZVOD = this.PROIZVODSet.PROIZVOD[this.PROIZVODSet.PROIZVOD.Count - 1];
            }
        }

        private void LoadProizvod()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [FINPOREZSTOPA] FROM [FINPOREZ] WITH (NOLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["FINPOREZIDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowPROIZVOD["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVJEDINICAMJERE] FROM [JEDINICAMJERE] WITH (NOLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDJEDINICAMJERE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowPROIZVOD["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
        }

        private void LoadRowProizvod()
        {
            this.AddRowProizvod();
        }

        private void OnDeleteControlsProizvod()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [FINPOREZSTOPA] FROM [FINPOREZ] WITH (NOLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["FINPOREZIDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowPROIZVOD["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVJEDINICAMJERE] FROM [JEDINICAMJERE] WITH (NOLOCK) WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDJEDINICAMJERE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowPROIZVOD["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
        }

        private void OnPROIZVODUpdated(PROIZVODEventArgs e)
        {
            if (this.PROIZVODUpdated != null)
            {
                PROIZVODUpdateEventHandler pROIZVODUpdatedEvent = this.PROIZVODUpdated;
                if (pROIZVODUpdatedEvent != null)
                {
                    pROIZVODUpdatedEvent(this, e);
                }
            }
        }

        private void OnPROIZVODUpdating(PROIZVODEventArgs e)
        {
            if (this.PROIZVODUpdating != null)
            {
                PROIZVODUpdateEventHandler pROIZVODUpdatingEvent = this.PROIZVODUpdating;
                if (pROIZVODUpdatingEvent != null)
                {
                    pROIZVODUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowProizvod()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPROIZVOD.RowState);
            if (this.rowPROIZVOD.RowState != DataRowState.Added)
            {
                this.m__NAZIVPROIZVODOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["NAZIVPROIZVOD", DataRowVersion.Original]);
                this.m__CIJENAOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["CIJENA", DataRowVersion.Original]);
                this.m__FINPOREZIDPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["FINPOREZIDPOREZ", DataRowVersion.Original]);
                this.m__IDJEDINICAMJEREOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDJEDINICAMJERE", DataRowVersion.Original]);
                this.m__CijenaPDVOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["CijenaPDV", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVPROIZVODOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["NAZIVPROIZVOD"]);
                this.m__CIJENAOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["CIJENA"]);
                this.m__FINPOREZIDPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["FINPOREZIDPOREZ"]);
                this.m__IDJEDINICAMJEREOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDJEDINICAMJERE"]);
                this.m__CijenaPDVOriginal = RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["CijenaPDV"]);
            }
            this._Gxremove = this.rowPROIZVOD.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPROIZVOD = (PROIZVODDataSet.PROIZVODRow) DataSetUtil.CloneOriginalDataRow(this.rowPROIZVOD);
            }
        }

        private void ScanByFINPOREZIDPOREZ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[FINPOREZIDPOREZ] = @FINPOREZIDPOREZ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString207 + "  FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE])" + this.m_WhereString + " ORDER BY TM1.[IDPROIZVOD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString207, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPROIZVOD] ) AS DK_PAGENUM   FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString207 + " FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE])" + this.m_WhereString + " ORDER BY TM1.[IDPROIZVOD] ";
            }
            this.cmPROIZVODSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPROIZVODSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            this.cmPROIZVODSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["FINPOREZIDPOREZ"]));
            this.PROIZVODSelect6 = this.cmPROIZVODSelect6.FetchData();
            this.RcdFound207 = 0;
            this.ScanLoadProizvod();
            this.LoadDataProizvod(maxRows);
        }

        private void ScanByIDJEDINICAMJERE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDJEDINICAMJERE] = @IDJEDINICAMJERE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString207 + "  FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE])" + this.m_WhereString + " ORDER BY TM1.[IDPROIZVOD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString207, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPROIZVOD] ) AS DK_PAGENUM   FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString207 + " FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE])" + this.m_WhereString + " ORDER BY TM1.[IDPROIZVOD] ";
            }
            this.cmPROIZVODSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPROIZVODSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            this.cmPROIZVODSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDJEDINICAMJERE"]));
            this.PROIZVODSelect6 = this.cmPROIZVODSelect6.FetchData();
            this.RcdFound207 = 0;
            this.ScanLoadProizvod();
            this.LoadDataProizvod(maxRows);
        }

        private void ScanByIDPROIZVOD(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDPROIZVOD] = @IDPROIZVOD";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString207 + "  FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE])" + this.m_WhereString + " ORDER BY TM1.[IDPROIZVOD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString207, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPROIZVOD] ) AS DK_PAGENUM   FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString207 + " FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE] Left Join MT_GrupeProizvoda On TM1.idGrupa = MT_GrupeProizvoda.ID)" + this.m_WhereString + " ORDER BY TM1.[IDPROIZVOD] ";
            }
            this.cmPROIZVODSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPROIZVODSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            this.cmPROIZVODSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDPROIZVOD"]));
            this.PROIZVODSelect6 = this.cmPROIZVODSelect6.FetchData();
            this.RcdFound207 = 0;
            this.ScanLoadProizvod();
            this.LoadDataProizvod(maxRows);
        }

        private void ScanEndProizvod()
        {
            this.PROIZVODSelect6.Close();
        }

        private void ScanLoadProizvod()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPROIZVODSelect6.HasMoreRows)
            {
                this.RcdFound207 = 1;
                this.rowPROIZVOD["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PROIZVODSelect6, 0));
                this.rowPROIZVOD["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PROIZVODSelect6, 1));
                this.rowPROIZVOD["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PROIZVODSelect6, 2));
                this.rowPROIZVOD["CIJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PROIZVODSelect6, 3));
                this.rowPROIZVOD["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PROIZVODSelect6, 4));
                this.rowPROIZVOD["FINPOREZIDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PROIZVODSelect6, 5));
                this.rowPROIZVOD["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PROIZVODSelect6, 6));
                this.rowPROIZVOD["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PROIZVODSelect6, 2));
                this.rowPROIZVOD["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PROIZVODSelect6, 4));
                this.rowPROIZVOD["CijenaPDV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PROIZVODSelect6, 7));
                this.rowPROIZVOD["Grupa"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PROIZVODSelect6, 8));
            }
        }

        private void ScanNextProizvod()
        {
            this.cmPROIZVODSelect6.HasMoreRows = this.PROIZVODSelect6.Read();
            this.RcdFound207 = 0;
            this.ScanLoadProizvod();
        }

        private void ScanStartProizvod(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString207 + "  FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE])" + this.m_WhereString + " ORDER BY TM1.[IDPROIZVOD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString207, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPROIZVOD] ) AS DK_PAGENUM   FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString207 + " FROM (([PROIZVOD] TM1 WITH (NOLOCK) INNER JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) INNER JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE] Left Join MT_GrupeProizvoda On TM1.idGrupa = MT_GrupeProizvoda.ID)" + this.m_WhereString + " ORDER BY TM1.[IDPROIZVOD] ";
            }
            this.cmPROIZVODSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.PROIZVODSelect6 = this.cmPROIZVODSelect6.FetchData();
            this.RcdFound207 = 0;
            this.ScanLoadProizvod();
            this.LoadDataProizvod(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.PROIZVODSet = (PROIZVODDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.PROIZVODSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.PROIZVODSet.PROIZVOD.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        PROIZVODDataSet.PROIZVODRow current = (PROIZVODDataSet.PROIZVODRow) enumerator.Current;
                        this.rowPROIZVOD = current;
                        if (Helpers.IsRowChanged(this.rowPROIZVOD))
                        {
                            this.ReadRowProizvod();
                            if (this.rowPROIZVOD.RowState == DataRowState.Added)
                            {
                                this.InsertProizvod();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateProizvod();
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

        private void UpdateProizvod()
        {
            this.CheckOptimisticConcurrencyProizvod();
            this.CheckExtendedTableProizvod();
            this.AfterConfirmProizvod();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PROIZVOD] SET [NAZIVPROIZVOD]=@NAZIVPROIZVOD, [CIJENA]=@CIJENA, [FINPOREZIDPOREZ]=@FINPOREZIDPOREZ, [IDJEDINICAMJERE]=@IDJEDINICAMJERE, [CijenaPDV]=@CijenaPDV  WHERE [IDPROIZVOD] = @IDPROIZVOD", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPROIZVOD", DbType.String, 500));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CIJENA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@CijenaPDV", DbType.Currency));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["NAZIVPROIZVOD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["CIJENA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["FINPOREZIDPOREZ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDJEDINICAMJERE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["IDPROIZVOD"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPROIZVOD["CijenaPDV"]));
            command.ExecuteStmt();
            this.OnPROIZVODUpdated(new PROIZVODEventArgs(this.rowPROIZVOD, StatementType.Update));
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
        public class PARTNERZADUZENJEInvalidDeleteException : InvalidDeleteException
        {
            public PARTNERZADUZENJEInvalidDeleteException()
            {
            }

            public PARTNERZADUZENJEInvalidDeleteException(string message) : base(message)
            {
            }

            protected PARTNERZADUZENJEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERZADUZENJEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PROIZVODDataChangedException : DataChangedException
        {
            public PROIZVODDataChangedException()
            {
            }

            public PROIZVODDataChangedException(string message) : base(message)
            {
            }

            protected PROIZVODDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PROIZVODDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PROIZVODDataLockedException : DataLockedException
        {
            public PROIZVODDataLockedException()
            {
            }

            public PROIZVODDataLockedException(string message) : base(message)
            {
            }

            protected PROIZVODDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PROIZVODDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PROIZVODDuplicateKeyException : DuplicateKeyException
        {
            public PROIZVODDuplicateKeyException()
            {
            }

            public PROIZVODDuplicateKeyException(string message) : base(message)
            {
            }

            protected PROIZVODDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PROIZVODDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PROIZVODEventArgs : EventArgs
        {
            private PROIZVODDataSet.PROIZVODRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PROIZVODEventArgs(PROIZVODDataSet.PROIZVODRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PROIZVODDataSet.PROIZVODRow Row
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
        public class PROIZVODNotFoundException : DataNotFoundException
        {
            public PROIZVODNotFoundException()
            {
            }

            public PROIZVODNotFoundException(string message) : base(message)
            {
            }

            protected PROIZVODNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PROIZVODNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void PROIZVODUpdateEventHandler(object sender, PROIZVODDataAdapter.PROIZVODEventArgs e);

        [Serializable]
        public class RACUNRacunStavkeInvalidDeleteException : InvalidDeleteException
        {
            public RACUNRacunStavkeInvalidDeleteException()
            {
            }

            public RACUNRacunStavkeInvalidDeleteException(string message) : base(message)
            {
            }

            protected RACUNRacunStavkeInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNRacunStavkeInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

