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

    public class SHEMAURADataAdapter : IDataAdapter, ISHEMAURADataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove17;
        private ReadWriteCommand cmSHEMAURASelect1;
        private ReadWriteCommand cmSHEMAURASelect2;
        private ReadWriteCommand cmSHEMAURASelect5;
        private ReadWriteCommand cmSHEMAURASHEMAURAKONTIRANJESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVSHEMAURAOriginal;
        private object m__PARTNERSHEMAURAIDPARTNEROriginal;
        private object m__SHEMAURAMTIDMJESTOTROSKAOriginal;
        private object m__SHEMAURAOJIDORGJEDOriginal;
        private readonly string m_SelectString214 = "TM1.[IDSHEMAURA], TM1.[NAZIVSHEMAURA], TM1.[PARTNERSHEMAURAIDPARTNER] AS PARTNERSHEMAURAIDPARTNER";
        private string m_SubSelTopString240;
        private string m_WhereString;
        private short RcdFound214;
        private short RcdFound240;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SHEMAURADataSet.SHEMAURARow rowSHEMAURA;
        private SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow rowSHEMAURASHEMAURAKONTIRANJE;
        private string scmdbuf;
        private IDataReader SHEMAURASelect1;
        private IDataReader SHEMAURASelect2;
        private IDataReader SHEMAURASelect5;
        private SHEMAURADataSet SHEMAURASet;
        private IDataReader SHEMAURASHEMAURAKONTIRANJESelect2;
        private StatementType sMode214;
        private StatementType sMode240;

        public event SHEMAURASHEMAURAKONTIRANJEUpdateEventHandler SHEMAURASHEMAURAKONTIRANJEUpdated;

        public event SHEMAURASHEMAURAKONTIRANJEUpdateEventHandler SHEMAURASHEMAURAKONTIRANJEUpdating;

        public event SHEMAURAUpdateEventHandler SHEMAURAUpdated;

        public event SHEMAURAUpdateEventHandler SHEMAURAUpdating;

        private void AddRowShemaura()
        {
            this.SHEMAURASet.SHEMAURA.AddSHEMAURARow(this.rowSHEMAURA);
        }

        private void AddRowShemaurashemaurakontiranje()
        {
            this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.AddSHEMAURASHEMAURAKONTIRANJERow(this.rowSHEMAURASHEMAURAKONTIRANJE);
        }

        private void AfterConfirmShemaura()
        {
            this.OnSHEMAURAUpdating(new SHEMAURAEventArgs(this.rowSHEMAURA, this.Gx_mode));
        }

        private void AfterConfirmShemaurashemaurakontiranje()
        {
            this.OnSHEMAURASHEMAURAKONTIRANJEUpdating(new SHEMAURASHEMAURAKONTIRANJEEventArgs(this.rowSHEMAURASHEMAURAKONTIRANJE, this.Gx_mode));
        }

        private void CheckIntegrityErrorsShemaura()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPARTNER] AS PARTNERSHEMAURAIDPARTNER FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @PARTNERSHEMAURAIDPARTNER ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERSHEMAURAIDPARTNER", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new PARTNERForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PARTNER") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsShemaurashemaurakontiranje()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO] AS SHEMAURAKONTOIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @SHEMAURAKONTOIDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAKONTOIDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAKONTOIDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [IDSTRANEKNJIZENJA] AS SHEMAURASTRANEIDSTRANEKNJIZENJA FROM [STRANEKNJIZENJA] WITH (NOLOCK) WHERE [IDSTRANEKNJIZENJA] = @SHEMAURASTRANEIDSTRANEKNJIZENJA ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURASTRANEIDSTRANEKNJIZENJA"]));
            IDataReader reader4 = command4.FetchData();
            if (!command4.HasMoreRows)
            {
                reader4.Close();
                throw new STRANEKNJIZENJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
            }
            reader4.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [IDURAVRSTAIZNOSA] FROM [URAVRSTAIZNOSA] WITH (NOLOCK) WHERE [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDURAVRSTAIZNOSA"]));
            IDataReader reader5 = command5.FetchData();
            if (!command5.HasMoreRows)
            {
                reader5.Close();
                throw new URAVRSTAIZNOSAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("URAVRSTAIZNOSA") }));
            }
            reader5.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDMJESTOTROSKA] AS SHEMAURAMTIDMJESTOTROSKA FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @SHEMAURAMTIDMJESTOTROSKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAMTIDMJESTOTROSKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAMTIDMJESTOTROSKA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new MJESTOTROSKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDORGJED] AS SHEMAURAOJIDORGJED FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @SHEMAURAOJIDORGJED ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAOJIDORGJED", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAOJIDORGJED"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new ORGJEDForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
            }
            reader3.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyShemaura()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAURA], [NAZIVSHEMAURA], [PARTNERSHEMAURAIDPARTNER] AS PARTNERSHEMAURAIDPARTNER FROM [SHEMAURA] WITH (UPDLOCK) WHERE [IDSHEMAURA] = @IDSHEMAURA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["IDSHEMAURA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMAURADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMAURA") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSHEMAURAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__PARTNERSHEMAURAIDPARTNEROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new SHEMAURADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMAURA") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyShemaurashemaurakontiranje()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAURA], [IDURAVRSTAIZNOSA], [SHEMAURAKONTOIDKONTO] AS SHEMAURAKONTOIDKONTO, [SHEMAURASTRANEIDSTRANEKNJIZENJA] AS SHEMAURASTRANEIDSTRANEKNJIZENJA, [SHEMAURAMTIDMJESTOTROSKA] AS SHEMAURAMTIDMJESTOTROSKA, [SHEMAURAOJIDORGJED] AS SHEMAURAOJIDORGJED FROM [SHEMAURASHEMAURAKONTIRANJE] WITH (UPDLOCK) WHERE [IDSHEMAURA] = @IDSHEMAURA AND [SHEMAURAKONTOIDKONTO] = @SHEMAURAKONTOIDKONTO AND [SHEMAURASTRANEIDSTRANEKNJIZENJA] = @SHEMAURASTRANEIDSTRANEKNJIZENJA AND [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAKONTOIDKONTO", DbType.String, 14));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDSHEMAURA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAKONTOIDKONTO"]))));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURASTRANEIDSTRANEKNJIZENJA"]));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDURAVRSTAIZNOSA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMAURASHEMAURAKONTIRANJEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMAURASHEMAURAKONTIRANJE") }));
                }
                if ((!command.HasMoreRows || !this.m__SHEMAURAMTIDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4)))) || !this.m__SHEMAURAOJIDORGJEDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 5))))
                {
                    reader.Close();
                    throw new SHEMAURASHEMAURAKONTIRANJEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMAURASHEMAURAKONTIRANJE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowShemaura()
        {
            this.rowSHEMAURA = this.SHEMAURASet.SHEMAURA.NewSHEMAURARow();
        }

        private void CreateNewRowShemaurashemaurakontiranje()
        {
            this.rowSHEMAURASHEMAURAKONTIRANJE = this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.NewSHEMAURASHEMAURAKONTIRANJERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaura();
            this.ProcessNestedLevelShemaurashemaurakontiranje();
            this.AfterConfirmShemaura();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMAURA]  WHERE [IDSHEMAURA] = @IDSHEMAURA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["IDSHEMAURA"]));
            command.ExecuteStmt();
            this.OnSHEMAURAUpdated(new SHEMAURAEventArgs(this.rowSHEMAURA, StatementType.Delete));
            this.rowSHEMAURA.Delete();
            this.sMode214 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode214;
        }

        private void DeleteShemaurashemaurakontiranje()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaurashemaurakontiranje();
            this.AfterConfirmShemaurashemaurakontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMAURASHEMAURAKONTIRANJE]  WHERE [IDSHEMAURA] = @IDSHEMAURA AND [SHEMAURAKONTOIDKONTO] = @SHEMAURAKONTOIDKONTO AND [SHEMAURASTRANEIDSTRANEKNJIZENJA] = @SHEMAURASTRANEIDSTRANEKNJIZENJA AND [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAKONTOIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDSHEMAURA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAKONTOIDKONTO"]))));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURASTRANEIDSTRANEKNJIZENJA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDURAVRSTAIZNOSA"]));
            command.ExecuteStmt();
            this.OnSHEMAURASHEMAURAKONTIRANJEUpdated(new SHEMAURASHEMAURAKONTIRANJEEventArgs(this.rowSHEMAURASHEMAURAKONTIRANJE, StatementType.Delete));
            this.rowSHEMAURASHEMAURAKONTIRANJE.Delete();
            this.sMode240 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode240;
        }

        public virtual int Fill(SHEMAURADataSet dataSet)
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
                    this.SHEMAURASet = dataSet;
                    this.LoadChildShemaura(0, -1);
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
            this.SHEMAURASet = (SHEMAURADataSet) dataSet;
            if (this.SHEMAURASet != null)
            {
                return this.Fill(this.SHEMAURASet);
            }
            this.SHEMAURASet = new SHEMAURADataSet();
            this.Fill(this.SHEMAURASet);
            dataSet.Merge(this.SHEMAURASet);
            return 0;
        }

        public virtual int Fill(SHEMAURADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSHEMAURA"]));
        }

        public virtual int Fill(SHEMAURADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSHEMAURA"]));
        }

        public virtual int Fill(SHEMAURADataSet dataSet, int iDSHEMAURA)
        {
            if (!this.FillByIDSHEMAURA(dataSet, iDSHEMAURA))
            {
                throw new SHEMAURANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SHEMAURA") }));
            }
            return 0;
        }

        public virtual bool FillByIDSHEMAURA(SHEMAURADataSet dataSet, int iDSHEMAURA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAURASet = dataSet;
            this.rowSHEMAURA = this.SHEMAURASet.SHEMAURA.NewSHEMAURARow();
            this.rowSHEMAURA.IDSHEMAURA = iDSHEMAURA;
            try
            {
                this.LoadByIDSHEMAURA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound214 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByPARTNERSHEMAURAIDPARTNER(SHEMAURADataSet dataSet, int pARTNERSHEMAURAIDPARTNER)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAURASet = dataSet;
            this.rowSHEMAURA = this.SHEMAURASet.SHEMAURA.NewSHEMAURARow();
            this.rowSHEMAURA.PARTNERSHEMAURAIDPARTNER = pARTNERSHEMAURAIDPARTNER;
            try
            {
                this.LoadByPARTNERSHEMAURAIDPARTNER(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(SHEMAURADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAURASet = dataSet;
            try
            {
                this.LoadChildShemaura(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByPARTNERSHEMAURAIDPARTNER(SHEMAURADataSet dataSet, int pARTNERSHEMAURAIDPARTNER, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAURASet = dataSet;
            this.rowSHEMAURA = this.SHEMAURASet.SHEMAURA.NewSHEMAURARow();
            this.rowSHEMAURA.PARTNERSHEMAURAIDPARTNER = pARTNERSHEMAURAIDPARTNER;
            try
            {
                this.LoadByPARTNERSHEMAURAIDPARTNER(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAURA], [NAZIVSHEMAURA], [PARTNERSHEMAURAIDPARTNER] AS PARTNERSHEMAURAIDPARTNER FROM [SHEMAURA] WITH (NOLOCK) WHERE [IDSHEMAURA] = @IDSHEMAURA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["IDSHEMAURA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound214 = 1;
                this.rowSHEMAURA["IDSHEMAURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSHEMAURA["NAZIVSHEMAURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.sMode214 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode214;
            }
            else
            {
                this.RcdFound214 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSHEMAURA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAURASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SHEMAURA] WITH (NOLOCK) ", false);
            this.SHEMAURASelect2 = this.cmSHEMAURASelect2.FetchData();
            if (this.SHEMAURASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SHEMAURASelect2.GetInt32(0);
            }
            this.SHEMAURASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByPARTNERSHEMAURAIDPARTNER(int pARTNERSHEMAURAIDPARTNER)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAURASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SHEMAURA] WITH (NOLOCK) WHERE [PARTNERSHEMAURAIDPARTNER] = @PARTNERSHEMAURAIDPARTNER ", false);
            if (this.cmSHEMAURASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAURASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERSHEMAURAIDPARTNER", DbType.Int32));
            }
            this.cmSHEMAURASelect1.SetParameter(0, pARTNERSHEMAURAIDPARTNER);
            this.SHEMAURASelect1 = this.cmSHEMAURASelect1.FetchData();
            if (this.SHEMAURASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SHEMAURASelect1.GetInt32(0);
            }
            this.SHEMAURASelect1.Close();
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

        public virtual int GetRecordCountByPARTNERSHEMAURAIDPARTNER(int pARTNERSHEMAURAIDPARTNER)
        {
            int internalRecordCountByPARTNERSHEMAURAIDPARTNER;
            try
            {
                this.InitializeMembers();
                internalRecordCountByPARTNERSHEMAURAIDPARTNER = this.GetInternalRecordCountByPARTNERSHEMAURAIDPARTNER(pARTNERSHEMAURAIDPARTNER);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByPARTNERSHEMAURAIDPARTNER;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound214 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__SHEMAURAMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SHEMAURAOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove17 = false;
            this.RcdFound240 = 0;
            this.m_SubSelTopString240 = "";
            this.m__NAZIVSHEMAURAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PARTNERSHEMAURAIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.SHEMAURASet = new SHEMAURADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertShemaura()
        {
            this.CheckOptimisticConcurrencyShemaura();
            this.AfterConfirmShemaura();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMAURA] ([IDSHEMAURA], [NAZIVSHEMAURA], [PARTNERSHEMAURAIDPARTNER]) VALUES (@IDSHEMAURA, @NAZIVSHEMAURA, @PARTNERSHEMAURAIDPARTNER)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSHEMAURA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERSHEMAURAIDPARTNER", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["IDSHEMAURA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["NAZIVSHEMAURA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMAURADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaura();
            }
            this.OnSHEMAURAUpdated(new SHEMAURAEventArgs(this.rowSHEMAURA, StatementType.Insert));
            this.ProcessLevelShemaura();
        }

        private void InsertShemaurashemaurakontiranje()
        {
            this.CheckOptimisticConcurrencyShemaurashemaurakontiranje();
            this.AfterConfirmShemaurashemaurakontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMAURASHEMAURAKONTIRANJE] ([IDSHEMAURA], [IDURAVRSTAIZNOSA], [SHEMAURAKONTOIDKONTO], [SHEMAURASTRANEIDSTRANEKNJIZENJA], [SHEMAURAMTIDMJESTOTROSKA], [SHEMAURAOJIDORGJED]) VALUES (@IDSHEMAURA, @IDURAVRSTAIZNOSA, @SHEMAURAKONTOIDKONTO, @SHEMAURASTRANEIDSTRANEKNJIZENJA, @SHEMAURAMTIDMJESTOTROSKA, @SHEMAURAOJIDORGJED)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAKONTOIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAMTIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAOJIDORGJED", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDSHEMAURA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDURAVRSTAIZNOSA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAKONTOIDKONTO"]))));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURASTRANEIDSTRANEKNJIZENJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAMTIDMJESTOTROSKA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAOJIDORGJED"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMAURASHEMAURAKONTIRANJEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaurashemaurakontiranje();
            }
            this.OnSHEMAURASHEMAURAKONTIRANJEUpdated(new SHEMAURASHEMAURAKONTIRANJEEventArgs(this.rowSHEMAURASHEMAURAKONTIRANJE, StatementType.Insert));
        }

        private void LoadByIDSHEMAURA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SHEMAURASet.EnforceConstraints;
            this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.BeginLoadData();
            this.SHEMAURASet.SHEMAURA.BeginLoadData();
            this.ScanByIDSHEMAURA(startRow, maxRows);
            this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.EndLoadData();
            this.SHEMAURASet.SHEMAURA.EndLoadData();
            this.SHEMAURASet.EnforceConstraints = enforceConstraints;
            if (this.SHEMAURASet.SHEMAURA.Count > 0)
            {
                this.rowSHEMAURA = this.SHEMAURASet.SHEMAURA[this.SHEMAURASet.SHEMAURA.Count - 1];
            }
        }

        private void LoadByPARTNERSHEMAURAIDPARTNER(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SHEMAURASet.EnforceConstraints;
            this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.BeginLoadData();
            this.SHEMAURASet.SHEMAURA.BeginLoadData();
            this.ScanByPARTNERSHEMAURAIDPARTNER(startRow, maxRows);
            this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.EndLoadData();
            this.SHEMAURASet.SHEMAURA.EndLoadData();
            this.SHEMAURASet.EnforceConstraints = enforceConstraints;
            if (this.SHEMAURASet.SHEMAURA.Count > 0)
            {
                this.rowSHEMAURA = this.SHEMAURASet.SHEMAURA[this.SHEMAURASet.SHEMAURA.Count - 1];
            }
        }

        private void LoadChildShemaura(int startRow, int maxRows)
        {
            this.CreateNewRowShemaura();
            bool enforceConstraints = this.SHEMAURASet.EnforceConstraints;
            this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.BeginLoadData();
            this.SHEMAURASet.SHEMAURA.BeginLoadData();
            this.ScanStartShemaura(startRow, maxRows);
            this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.EndLoadData();
            this.SHEMAURASet.SHEMAURA.EndLoadData();
            this.SHEMAURASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildShemaurashemaurakontiranje()
        {
            this.CreateNewRowShemaurashemaurakontiranje();
            this.ScanStartShemaurashemaurakontiranje();
        }

        private void LoadDataShemaura(int maxRows)
        {
            int num = 0;
            if (this.RcdFound214 != 0)
            {
                this.ScanLoadShemaura();
                while ((this.RcdFound214 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowShemaura();
                    this.CreateNewRowShemaura();
                    this.ScanNextShemaura();
                }
            }
            if (num > 0)
            {
                this.RcdFound214 = 1;
            }
            this.ScanEndShemaura();
            if (this.SHEMAURASet.SHEMAURA.Count > 0)
            {
                this.rowSHEMAURA = this.SHEMAURASet.SHEMAURA[this.SHEMAURASet.SHEMAURA.Count - 1];
            }
        }

        private void LoadDataShemaurashemaurakontiranje()
        {
            while (this.RcdFound240 != 0)
            {
                this.LoadRowShemaurashemaurakontiranje();
                this.CreateNewRowShemaurashemaurakontiranje();
                this.ScanNextShemaurashemaurakontiranje();
            }
            this.ScanEndShemaurashemaurakontiranje();
        }

        private void LoadRowShemaura()
        {
            this.AddRowShemaura();
        }

        private void LoadRowShemaurashemaurakontiranje()
        {
            this.AddRowShemaurashemaurakontiranje();
        }

        private void OnSHEMAURASHEMAURAKONTIRANJEUpdated(SHEMAURASHEMAURAKONTIRANJEEventArgs e)
        {
            if (this.SHEMAURASHEMAURAKONTIRANJEUpdated != null)
            {
                SHEMAURASHEMAURAKONTIRANJEUpdateEventHandler sHEMAURASHEMAURAKONTIRANJEUpdatedEvent = this.SHEMAURASHEMAURAKONTIRANJEUpdated;
                if (sHEMAURASHEMAURAKONTIRANJEUpdatedEvent != null)
                {
                    sHEMAURASHEMAURAKONTIRANJEUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMAURASHEMAURAKONTIRANJEUpdating(SHEMAURASHEMAURAKONTIRANJEEventArgs e)
        {
            if (this.SHEMAURASHEMAURAKONTIRANJEUpdating != null)
            {
                SHEMAURASHEMAURAKONTIRANJEUpdateEventHandler sHEMAURASHEMAURAKONTIRANJEUpdatingEvent = this.SHEMAURASHEMAURAKONTIRANJEUpdating;
                if (sHEMAURASHEMAURAKONTIRANJEUpdatingEvent != null)
                {
                    sHEMAURASHEMAURAKONTIRANJEUpdatingEvent(this, e);
                }
            }
        }

        private void OnSHEMAURAUpdated(SHEMAURAEventArgs e)
        {
            if (this.SHEMAURAUpdated != null)
            {
                SHEMAURAUpdateEventHandler sHEMAURAUpdatedEvent = this.SHEMAURAUpdated;
                if (sHEMAURAUpdatedEvent != null)
                {
                    sHEMAURAUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMAURAUpdating(SHEMAURAEventArgs e)
        {
            if (this.SHEMAURAUpdating != null)
            {
                SHEMAURAUpdateEventHandler sHEMAURAUpdatingEvent = this.SHEMAURAUpdating;
                if (sHEMAURAUpdatingEvent != null)
                {
                    sHEMAURAUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelShemaura()
        {
            this.sMode214 = this.Gx_mode;
            this.ProcessNestedLevelShemaurashemaurakontiranje();
            this.Gx_mode = this.sMode214;
        }

        private void ProcessNestedLevelShemaurashemaurakontiranje()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SHEMAURASet.SHEMAURASHEMAURAKONTIRANJE.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSHEMAURASHEMAURAKONTIRANJE = (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) current;
                    if (Helpers.IsRowChanged(this.rowSHEMAURASHEMAURAKONTIRANJE))
                    {
                        bool flag = false;
                        if (this.rowSHEMAURASHEMAURAKONTIRANJE.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSHEMAURASHEMAURAKONTIRANJE.IDSHEMAURA == this.rowSHEMAURA.IDSHEMAURA;
                        }
                        else
                        {
                            flag = this.rowSHEMAURASHEMAURAKONTIRANJE["IDSHEMAURA", DataRowVersion.Original].Equals(this.rowSHEMAURA.IDSHEMAURA);
                        }
                        if (flag)
                        {
                            this.ReadRowShemaurashemaurakontiranje();
                            if (this.rowSHEMAURASHEMAURAKONTIRANJE.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertShemaurashemaurakontiranje();
                            }
                            else
                            {
                                if (this._Gxremove17)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteShemaurashemaurakontiranje();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateShemaurashemaurakontiranje();
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

        private void ReadRowShemaura()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMAURA.RowState);
            if (this.rowSHEMAURA.RowState != DataRowState.Added)
            {
                this.m__NAZIVSHEMAURAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["NAZIVSHEMAURA", DataRowVersion.Original]);
                this.m__PARTNERSHEMAURAIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSHEMAURAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["NAZIVSHEMAURA"]);
                this.m__PARTNERSHEMAURAIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER"]);
            }
            this._Gxremove = this.rowSHEMAURA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSHEMAURA = (SHEMAURADataSet.SHEMAURARow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMAURA);
            }
        }

        private void ReadRowShemaurashemaurakontiranje()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMAURASHEMAURAKONTIRANJE.RowState);
            if (this.rowSHEMAURASHEMAURAKONTIRANJE.RowState != DataRowState.Added)
            {
                this.m__SHEMAURAMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAMTIDMJESTOTROSKA", DataRowVersion.Original]);
                this.m__SHEMAURAOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAOJIDORGJED", DataRowVersion.Original]);
            }
            else
            {
                this.m__SHEMAURAMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAMTIDMJESTOTROSKA"]);
                this.m__SHEMAURAOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAOJIDORGJED"]);
            }
            this._Gxremove17 = this.rowSHEMAURASHEMAURAKONTIRANJE.RowState == DataRowState.Deleted;
            if (this._Gxremove17)
            {
                this.rowSHEMAURASHEMAURAKONTIRANJE = (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMAURASHEMAURAKONTIRANJE);
            }
        }

        private void ScanByIDSHEMAURA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSHEMAURA] = @IDSHEMAURA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString214 + "  FROM [SHEMAURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAURA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString214, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAURA] ) AS DK_PAGENUM   FROM [SHEMAURA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString214 + " FROM [SHEMAURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAURA] ";
            }
            this.cmSHEMAURASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSHEMAURASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAURASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
            }
            this.cmSHEMAURASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["IDSHEMAURA"]));
            this.SHEMAURASelect5 = this.cmSHEMAURASelect5.FetchData();
            this.RcdFound214 = 0;
            this.ScanLoadShemaura();
            this.LoadDataShemaura(maxRows);
            if (this.RcdFound214 > 0)
            {
                this.SubLvlScanStartShemaurashemaurakontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSHEMAURAShemaura(this.cmSHEMAURASHEMAURAKONTIRANJESelect2);
                this.SubLvlFetchShemaurashemaurakontiranje();
                this.SubLoadDataShemaurashemaurakontiranje();
            }
        }

        private void ScanByPARTNERSHEMAURAIDPARTNER(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[PARTNERSHEMAURAIDPARTNER] = @PARTNERSHEMAURAIDPARTNER";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString214 + "  FROM [SHEMAURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAURA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString214, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAURA] ) AS DK_PAGENUM   FROM [SHEMAURA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString214 + " FROM [SHEMAURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAURA] ";
            }
            this.cmSHEMAURASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSHEMAURASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAURASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERSHEMAURAIDPARTNER", DbType.Int32));
            }
            this.cmSHEMAURASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER"]));
            this.SHEMAURASelect5 = this.cmSHEMAURASelect5.FetchData();
            this.RcdFound214 = 0;
            this.ScanLoadShemaura();
            this.LoadDataShemaura(maxRows);
            if (this.RcdFound214 > 0)
            {
                this.SubLvlScanStartShemaurashemaurakontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersPARTNERSHEMAURAIDPARTNERShemaura(this.cmSHEMAURASHEMAURAKONTIRANJESelect2);
                this.SubLvlFetchShemaurashemaurakontiranje();
                this.SubLoadDataShemaurashemaurakontiranje();
            }
        }

        private void ScanEndShemaura()
        {
            this.SHEMAURASelect5.Close();
        }

        private void ScanEndShemaurashemaurakontiranje()
        {
            this.SHEMAURASHEMAURAKONTIRANJESelect2.Close();
        }

        private void ScanLoadShemaura()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMAURASelect5.HasMoreRows)
            {
                this.RcdFound214 = 1;
                this.rowSHEMAURA["IDSHEMAURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAURASelect5, 0));
                this.rowSHEMAURA["NAZIVSHEMAURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAURASelect5, 1));
                this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAURASelect5, 2));
            }
        }

        private void ScanLoadShemaurashemaurakontiranje()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMAURASHEMAURAKONTIRANJESelect2.HasMoreRows)
            {
                this.RcdFound240 = 1;
                this.rowSHEMAURASHEMAURAKONTIRANJE["IDSHEMAURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAURASHEMAURAKONTIRANJESelect2, 0));
                this.rowSHEMAURASHEMAURAKONTIRANJE["IDURAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAURASHEMAURAKONTIRANJESelect2, 1));
                this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAURASHEMAURAKONTIRANJESelect2, 2))));
                this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURASTRANEIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAURASHEMAURAKONTIRANJESelect2, 3));
                this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAURASHEMAURAKONTIRANJESelect2, 4));
                this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAOJIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAURASHEMAURAKONTIRANJESelect2, 5));
            }
        }

        private void ScanNextShemaura()
        {
            this.cmSHEMAURASelect5.HasMoreRows = this.SHEMAURASelect5.Read();
            this.RcdFound214 = 0;
            this.ScanLoadShemaura();
        }

        private void ScanNextShemaurashemaurakontiranje()
        {
            this.cmSHEMAURASHEMAURAKONTIRANJESelect2.HasMoreRows = this.SHEMAURASHEMAURAKONTIRANJESelect2.Read();
            this.RcdFound240 = 0;
            this.ScanLoadShemaurashemaurakontiranje();
        }

        private void ScanStartShemaura(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString214 + "  FROM [SHEMAURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAURA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString214, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAURA] ) AS DK_PAGENUM   FROM [SHEMAURA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString214 + " FROM [SHEMAURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAURA] ";
            }
            this.cmSHEMAURASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.SHEMAURASelect5 = this.cmSHEMAURASelect5.FetchData();
            this.RcdFound214 = 0;
            this.ScanLoadShemaura();
            this.LoadDataShemaura(maxRows);
            if (this.RcdFound214 > 0)
            {
                this.SubLvlScanStartShemaurashemaurakontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersShemauraShemaura(this.cmSHEMAURASHEMAURAKONTIRANJESelect2);
                this.SubLvlFetchShemaurashemaurakontiranje();
                this.SubLoadDataShemaurashemaurakontiranje();
            }
        }

        private void ScanStartShemaurashemaurakontiranje()
        {
            this.cmSHEMAURASHEMAURAKONTIRANJESelect2 = this.connDefault.GetCommand("SELECT [IDSHEMAURA], [IDURAVRSTAIZNOSA], [SHEMAURAKONTOIDKONTO] AS SHEMAURAKONTOIDKONTO, [SHEMAURASTRANEIDSTRANEKNJIZENJA] AS SHEMAURASTRANEIDSTRANEKNJIZENJA, [SHEMAURAMTIDMJESTOTROSKA] AS SHEMAURAMTIDMJESTOTROSKA, [SHEMAURAOJIDORGJED] AS SHEMAURAOJIDORGJED FROM [SHEMAURASHEMAURAKONTIRANJE] WITH (NOLOCK) WHERE [IDSHEMAURA] = @IDSHEMAURA ORDER BY [IDSHEMAURA], [SHEMAURAKONTOIDKONTO], [SHEMAURASTRANEIDSTRANEKNJIZENJA], [IDURAVRSTAIZNOSA] ", false);
            if (this.cmSHEMAURASHEMAURAKONTIRANJESelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAURASHEMAURAKONTIRANJESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
            }
            this.cmSHEMAURASHEMAURAKONTIRANJESelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDSHEMAURA"]));
            this.SHEMAURASHEMAURAKONTIRANJESelect2 = this.cmSHEMAURASHEMAURAKONTIRANJESelect2.FetchData();
            this.RcdFound240 = 0;
            this.ScanLoadShemaurashemaurakontiranje();
        }

        private void SetParametersIDSHEMAURAShemaura(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["IDSHEMAURA"]));
        }

        private void SetParametersPARTNERSHEMAURAIDPARTNERShemaura(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERSHEMAURAIDPARTNER", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER"]));
        }

        private void SetParametersShemauraShemaura(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextShemaurashemaurakontiranje()
        {
            this.cmSHEMAURASHEMAURAKONTIRANJESelect2.HasMoreRows = this.SHEMAURASHEMAURAKONTIRANJESelect2.Read();
            this.RcdFound240 = 0;
            if (this.cmSHEMAURASHEMAURAKONTIRANJESelect2.HasMoreRows)
            {
                this.RcdFound240 = 1;
            }
        }

        private void SubLoadDataShemaurashemaurakontiranje()
        {
            while (this.RcdFound240 != 0)
            {
                this.LoadRowShemaurashemaurakontiranje();
                this.CreateNewRowShemaurashemaurakontiranje();
                this.ScanNextShemaurashemaurakontiranje();
            }
            this.ScanEndShemaurashemaurakontiranje();
        }

        private void SubLvlFetchShemaurashemaurakontiranje()
        {
            this.CreateNewRowShemaurashemaurakontiranje();
            this.SHEMAURASHEMAURAKONTIRANJESelect2 = this.cmSHEMAURASHEMAURAKONTIRANJESelect2.FetchData();
            this.RcdFound240 = 0;
            this.ScanLoadShemaurashemaurakontiranje();
        }

        private void SubLvlScanStartShemaurashemaurakontiranje(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString240 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSHEMAURA]  FROM [SHEMAURA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSHEMAURA] )";
                    this.scmdbuf = "SELECT T1.[IDSHEMAURA], T1.[IDURAVRSTAIZNOSA], T1.[SHEMAURAKONTOIDKONTO] AS SHEMAURAKONTOIDKONTO, T1.[SHEMAURASTRANEIDSTRANEKNJIZENJA] AS SHEMAURASTRANEIDSTRANEKNJIZENJA, T1.[SHEMAURAMTIDMJESTOTROSKA] AS SHEMAURAMTIDMJESTOTROSKA, T1.[SHEMAURAOJIDORGJED] AS SHEMAURAOJIDORGJED FROM ([SHEMAURASHEMAURAKONTIRANJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString240 + "  TMX ON TMX.[IDSHEMAURA] = T1.[IDSHEMAURA]) ORDER BY T1.[IDSHEMAURA], T1.[SHEMAURAKONTOIDKONTO], T1.[SHEMAURASTRANEIDSTRANEKNJIZENJA], T1.[IDURAVRSTAIZNOSA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSHEMAURA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAURA]  ) AS DK_PAGENUM   FROM [SHEMAURA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString240 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSHEMAURA], T1.[IDURAVRSTAIZNOSA], T1.[SHEMAURAKONTOIDKONTO] AS SHEMAURAKONTOIDKONTO, T1.[SHEMAURASTRANEIDSTRANEKNJIZENJA] AS SHEMAURASTRANEIDSTRANEKNJIZENJA, T1.[SHEMAURAMTIDMJESTOTROSKA] AS SHEMAURAMTIDMJESTOTROSKA, T1.[SHEMAURAOJIDORGJED] AS SHEMAURAOJIDORGJED FROM ([SHEMAURASHEMAURAKONTIRANJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString240 + "  TMX ON TMX.[IDSHEMAURA] = T1.[IDSHEMAURA]) ORDER BY T1.[IDSHEMAURA], T1.[SHEMAURAKONTOIDKONTO], T1.[SHEMAURASTRANEIDSTRANEKNJIZENJA], T1.[IDURAVRSTAIZNOSA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString240 = "[SHEMAURA]";
                this.scmdbuf = "SELECT T1.[IDSHEMAURA], T1.[IDURAVRSTAIZNOSA], T1.[SHEMAURAKONTOIDKONTO] AS SHEMAURAKONTOIDKONTO, T1.[SHEMAURASTRANEIDSTRANEKNJIZENJA] AS SHEMAURASTRANEIDSTRANEKNJIZENJA, T1.[SHEMAURAMTIDMJESTOTROSKA] AS SHEMAURAMTIDMJESTOTROSKA, T1.[SHEMAURAOJIDORGJED] AS SHEMAURAOJIDORGJED FROM ([SHEMAURASHEMAURAKONTIRANJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString240 + "  TM1 WITH (NOLOCK) ON TM1.[IDSHEMAURA] = T1.[IDSHEMAURA])" + this.m_WhereString + " ORDER BY T1.[IDSHEMAURA], T1.[SHEMAURAKONTOIDKONTO], T1.[SHEMAURASTRANEIDSTRANEKNJIZENJA], T1.[IDURAVRSTAIZNOSA] ";
            }
            this.cmSHEMAURASHEMAURAKONTIRANJESelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.SHEMAURASet = (SHEMAURADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.SHEMAURASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.SHEMAURASet.SHEMAURA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        SHEMAURADataSet.SHEMAURARow current = (SHEMAURADataSet.SHEMAURARow) enumerator.Current;
                        this.rowSHEMAURA = current;
                        if (Helpers.IsRowChanged(this.rowSHEMAURA))
                        {
                            this.ReadRowShemaura();
                            if (this.rowSHEMAURA.RowState == DataRowState.Added)
                            {
                                this.InsertShemaura();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateShemaura();
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

        private void UpdateShemaura()
        {
            this.CheckOptimisticConcurrencyShemaura();
            this.AfterConfirmShemaura();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMAURA] SET [NAZIVSHEMAURA]=@NAZIVSHEMAURA, [PARTNERSHEMAURAIDPARTNER]=@PARTNERSHEMAURAIDPARTNER  WHERE [IDSHEMAURA] = @IDSHEMAURA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSHEMAURA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNERSHEMAURAIDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["NAZIVSHEMAURA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["PARTNERSHEMAURAIDPARTNER"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAURA["IDSHEMAURA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaura();
            }
            this.OnSHEMAURAUpdated(new SHEMAURAEventArgs(this.rowSHEMAURA, StatementType.Update));
            this.ProcessLevelShemaura();
        }

        private void UpdateShemaurashemaurakontiranje()
        {
            this.CheckOptimisticConcurrencyShemaurashemaurakontiranje();
            this.AfterConfirmShemaurashemaurakontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMAURASHEMAURAKONTIRANJE] SET [SHEMAURAMTIDMJESTOTROSKA]=@SHEMAURAMTIDMJESTOTROSKA, [SHEMAURAOJIDORGJED]=@SHEMAURAOJIDORGJED  WHERE [IDSHEMAURA] = @IDSHEMAURA AND [SHEMAURAKONTOIDKONTO] = @SHEMAURAKONTOIDKONTO AND [SHEMAURASTRANEIDSTRANEKNJIZENJA] = @SHEMAURASTRANEIDSTRANEKNJIZENJA AND [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAMTIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAOJIDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAURA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURAKONTOIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAURASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAMTIDMJESTOTROSKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAOJIDORGJED"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDSHEMAURA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURAKONTOIDKONTO"]))));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["SHEMAURASTRANEIDSTRANEKNJIZENJA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowSHEMAURASHEMAURAKONTIRANJE["IDURAVRSTAIZNOSA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaurashemaurakontiranje();
            }
            this.OnSHEMAURASHEMAURAKONTIRANJEUpdated(new SHEMAURASHEMAURAKONTIRANJEEventArgs(this.rowSHEMAURASHEMAURAKONTIRANJE, StatementType.Update));
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
        public class KONTOForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public KONTOForeignKeyNotFoundException()
            {
            }

            public KONTOForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected KONTOForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KONTOForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class MJESTOTROSKAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public MJESTOTROSKAForeignKeyNotFoundException()
            {
            }

            public MJESTOTROSKAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected MJESTOTROSKAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MJESTOTROSKAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ORGJEDForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ORGJEDForeignKeyNotFoundException()
            {
            }

            public ORGJEDForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ORGJEDForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGJEDForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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
        public class SHEMAURADataChangedException : DataChangedException
        {
            public SHEMAURADataChangedException()
            {
            }

            public SHEMAURADataChangedException(string message) : base(message)
            {
            }

            protected SHEMAURADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAURADataLockedException : DataLockedException
        {
            public SHEMAURADataLockedException()
            {
            }

            public SHEMAURADataLockedException(string message) : base(message)
            {
            }

            protected SHEMAURADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAURADuplicateKeyException : DuplicateKeyException
        {
            public SHEMAURADuplicateKeyException()
            {
            }

            public SHEMAURADuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMAURADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMAURAEventArgs : EventArgs
        {
            private SHEMAURADataSet.SHEMAURARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMAURAEventArgs(SHEMAURADataSet.SHEMAURARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMAURADataSet.SHEMAURARow Row
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
        public class SHEMAURANotFoundException : DataNotFoundException
        {
            public SHEMAURANotFoundException()
            {
            }

            public SHEMAURANotFoundException(string message) : base(message)
            {
            }

            protected SHEMAURANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAURASHEMAURAKONTIRANJEDataChangedException : DataChangedException
        {
            public SHEMAURASHEMAURAKONTIRANJEDataChangedException()
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEDataChangedException(string message) : base(message)
            {
            }

            protected SHEMAURASHEMAURAKONTIRANJEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAURASHEMAURAKONTIRANJEDataLockedException : DataLockedException
        {
            public SHEMAURASHEMAURAKONTIRANJEDataLockedException()
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEDataLockedException(string message) : base(message)
            {
            }

            protected SHEMAURASHEMAURAKONTIRANJEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAURASHEMAURAKONTIRANJEDuplicateKeyException : DuplicateKeyException
        {
            public SHEMAURASHEMAURAKONTIRANJEDuplicateKeyException()
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEDuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMAURASHEMAURAKONTIRANJEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMAURASHEMAURAKONTIRANJEEventArgs : EventArgs
        {
            private SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMAURASHEMAURAKONTIRANJEEventArgs(SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow Row
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

        public delegate void SHEMAURASHEMAURAKONTIRANJEUpdateEventHandler(object sender, SHEMAURADataAdapter.SHEMAURASHEMAURAKONTIRANJEEventArgs e);

        public delegate void SHEMAURAUpdateEventHandler(object sender, SHEMAURADataAdapter.SHEMAURAEventArgs e);

        [Serializable]
        public class STRANEKNJIZENJAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public STRANEKNJIZENJAForeignKeyNotFoundException()
            {
            }

            public STRANEKNJIZENJAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected STRANEKNJIZENJAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANEKNJIZENJAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URAVRSTAIZNOSAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public URAVRSTAIZNOSAForeignKeyNotFoundException()
            {
            }

            public URAVRSTAIZNOSAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected URAVRSTAIZNOSAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URAVRSTAIZNOSAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

