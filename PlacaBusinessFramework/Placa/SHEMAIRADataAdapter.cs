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

    public class SHEMAIRADataAdapter : IDataAdapter, ISHEMAIRADataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove17;
        private ReadWriteCommand cmSHEMAIRASelect1;
        private ReadWriteCommand cmSHEMAIRASelect2;
        private ReadWriteCommand cmSHEMAIRASelect5;
        private ReadWriteCommand cmSHEMAIRASHEMAIRAKONTIRANJESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDIRAVRSTAIZNOSAOriginal;
        private object m__NAZIVSHEMAIRAOriginal;
        private object m__SHEMAIRADOKIDDOKUMENTOriginal;
        private object m__SHEMAIRAMTIDMJESTOTROSKAOriginal;
        private object m__SHEMAIRAOJIDORGJEDOriginal;
        private readonly string m_SelectString220 = "TM1.[IDSHEMAIRA], TM1.[NAZIVSHEMAIRA], TM1.[SHEMAIRADOKIDDOKUMENT] AS SHEMAIRADOKIDDOKUMENT";
        private string m_SubSelTopString223;
        private string m_WhereString;
        private short RcdFound220;
        private short RcdFound223;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SHEMAIRADataSet.SHEMAIRARow rowSHEMAIRA;
        private SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow rowSHEMAIRASHEMAIRAKONTIRANJE;
        private string scmdbuf;
        private IDataReader SHEMAIRASelect1;
        private IDataReader SHEMAIRASelect2;
        private IDataReader SHEMAIRASelect5;
        private SHEMAIRADataSet SHEMAIRASet;
        private IDataReader SHEMAIRASHEMAIRAKONTIRANJESelect2;
        private StatementType sMode220;
        private StatementType sMode223;

        public event SHEMAIRASHEMAIRAKONTIRANJEUpdateEventHandler SHEMAIRASHEMAIRAKONTIRANJEUpdated;

        public event SHEMAIRASHEMAIRAKONTIRANJEUpdateEventHandler SHEMAIRASHEMAIRAKONTIRANJEUpdating;

        public event SHEMAIRAUpdateEventHandler SHEMAIRAUpdated;

        public event SHEMAIRAUpdateEventHandler SHEMAIRAUpdating;

        private void AddRowShemaira()
        {
            this.SHEMAIRASet.SHEMAIRA.AddSHEMAIRARow(this.rowSHEMAIRA);
        }

        private void AddRowShemairashemairakontiranje()
        {
            this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.AddSHEMAIRASHEMAIRAKONTIRANJERow(this.rowSHEMAIRASHEMAIRAKONTIRANJE);
        }

        private void AfterConfirmShemaira()
        {
            this.OnSHEMAIRAUpdating(new SHEMAIRAEventArgs(this.rowSHEMAIRA, this.Gx_mode));
        }

        private void AfterConfirmShemairashemairakontiranje()
        {
            this.OnSHEMAIRASHEMAIRAKONTIRANJEUpdating(new SHEMAIRASHEMAIRAKONTIRANJEEventArgs(this.rowSHEMAIRASHEMAIRAKONTIRANJE, this.Gx_mode));
        }

        private void CheckIntegrityErrorsShemaira()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOKUMENT] AS SHEMAIRADOKIDDOKUMENT FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDDOKUMENT] = @SHEMAIRADOKIDDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRADOKIDDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOKUMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOKUMENT") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckIntegrityErrorsShemairashemairakontiranje()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDKONTO] AS SHEMAIRAKONTOIDKONTO FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @SHEMAIRAKONTOIDKONTO ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAKONTOIDKONTO", DbType.String, 14));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAKONTOIDKONTO"]))));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            reader2.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [IDSTRANEKNJIZENJA] AS SHEMAIRASTRANEIDSTRANEKNJIZENJA FROM [STRANEKNJIZENJA] WITH (NOLOCK) WHERE [IDSTRANEKNJIZENJA] = @SHEMAIRASTRANEIDSTRANEKNJIZENJA ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRASTRANEIDSTRANEKNJIZENJA"]));
            IDataReader reader5 = command5.FetchData();
            if (!command5.HasMoreRows)
            {
                reader5.Close();
                throw new STRANEKNJIZENJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
            }
            reader5.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDIRAVRSTAIZNOSA] FROM [IRAVRSTAIZNOSA] WITH (NOLOCK) WHERE [IDIRAVRSTAIZNOSA] = @IDIRAVRSTAIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDIRAVRSTAIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new IRAVRSTAIZNOSAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("IRAVRSTAIZNOSA") }));
            }
            reader.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDMJESTOTROSKA] AS SHEMAIRAMTIDMJESTOTROSKA FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @SHEMAIRAMTIDMJESTOTROSKA ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAMTIDMJESTOTROSKA", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAMTIDMJESTOTROSKA"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new MJESTOTROSKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            reader3.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [IDORGJED] AS SHEMAIRAOJIDORGJED FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @SHEMAIRAOJIDORGJED ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAOJIDORGJED", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAOJIDORGJED"]));
            IDataReader reader4 = command4.FetchData();
            if (!command4.HasMoreRows)
            {
                reader4.Close();
                throw new ORGJEDForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
            }
            reader4.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyShemaira()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAIRA], [NAZIVSHEMAIRA], [SHEMAIRADOKIDDOKUMENT] AS SHEMAIRADOKIDDOKUMENT FROM [SHEMAIRA] WITH (UPDLOCK) WHERE [IDSHEMAIRA] = @IDSHEMAIRA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["IDSHEMAIRA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMAIRADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMAIRA") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSHEMAIRAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__SHEMAIRADOKIDDOKUMENTOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new SHEMAIRADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMAIRA") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyShemairashemairakontiranje()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAIRA], [IDIRAVRSTAIZNOSA], [SHEMAIRAKONTOIDKONTO] AS SHEMAIRAKONTOIDKONTO, [SHEMAIRASTRANEIDSTRANEKNJIZENJA] AS SHEMAIRASTRANEIDSTRANEKNJIZENJA, [SHEMAIRAMTIDMJESTOTROSKA] AS SHEMAIRAMTIDMJESTOTROSKA, [SHEMAIRAOJIDORGJED] AS SHEMAIRAOJIDORGJED FROM [SHEMAIRASHEMAIRAKONTIRANJE] WITH (UPDLOCK) WHERE [IDSHEMAIRA] = @IDSHEMAIRA AND [SHEMAIRAKONTOIDKONTO] = @SHEMAIRAKONTOIDKONTO AND [SHEMAIRASTRANEIDSTRANEKNJIZENJA] = @SHEMAIRASTRANEIDSTRANEKNJIZENJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAKONTOIDKONTO", DbType.String, 14));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDSHEMAIRA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAKONTOIDKONTO"]))));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRASTRANEIDSTRANEKNJIZENJA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SHEMAIRASHEMAIRAKONTIRANJEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SHEMAIRASHEMAIRAKONTIRANJE") }));
                }
                if ((!command.HasMoreRows || !this.m__IDIRAVRSTAIZNOSAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1)))) || (!this.m__SHEMAIRAMTIDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4))) || !this.m__SHEMAIRAOJIDORGJEDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 5)))))
                {
                    reader.Close();
                    throw new SHEMAIRASHEMAIRAKONTIRANJEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SHEMAIRASHEMAIRAKONTIRANJE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowShemaira()
        {
            this.rowSHEMAIRA = this.SHEMAIRASet.SHEMAIRA.NewSHEMAIRARow();
        }

        private void CreateNewRowShemairashemairakontiranje()
        {
            this.rowSHEMAIRASHEMAIRAKONTIRANJE = this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.NewSHEMAIRASHEMAIRAKONTIRANJERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemaira();
            this.ProcessNestedLevelShemairashemairakontiranje();
            this.AfterConfirmShemaira();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMAIRA]  WHERE [IDSHEMAIRA] = @IDSHEMAIRA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["IDSHEMAIRA"]));
            command.ExecuteStmt();
            this.OnSHEMAIRAUpdated(new SHEMAIRAEventArgs(this.rowSHEMAIRA, StatementType.Delete));
            this.rowSHEMAIRA.Delete();
            this.sMode220 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode220;
        }

        private void DeleteShemairashemairakontiranje()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyShemairashemairakontiranje();
            this.AfterConfirmShemairashemairakontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SHEMAIRASHEMAIRAKONTIRANJE]  WHERE [IDSHEMAIRA] = @IDSHEMAIRA AND [SHEMAIRAKONTOIDKONTO] = @SHEMAIRAKONTOIDKONTO AND [SHEMAIRASTRANEIDSTRANEKNJIZENJA] = @SHEMAIRASTRANEIDSTRANEKNJIZENJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAKONTOIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDSHEMAIRA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAKONTOIDKONTO"]))));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRASTRANEIDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            this.OnSHEMAIRASHEMAIRAKONTIRANJEUpdated(new SHEMAIRASHEMAIRAKONTIRANJEEventArgs(this.rowSHEMAIRASHEMAIRAKONTIRANJE, StatementType.Delete));
            this.rowSHEMAIRASHEMAIRAKONTIRANJE.Delete();
            this.sMode223 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode223;
        }


        public virtual int Fill(SHEMAIRADataSet dataSet)
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
                    this.SHEMAIRASet = dataSet;
                    this.LoadChildShemaira(0, -1);
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
            this.SHEMAIRASet = (SHEMAIRADataSet) dataSet;
            if (this.SHEMAIRASet != null)
            {
                return this.Fill(this.SHEMAIRASet);
            }
            this.SHEMAIRASet = new SHEMAIRADataSet();
            this.Fill(this.SHEMAIRASet);
            dataSet.Merge(this.SHEMAIRASet);
            return 0;
        }

        public virtual int Fill(SHEMAIRADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSHEMAIRA"]));
        }

        public virtual int Fill(SHEMAIRADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSHEMAIRA"]));
        }

        public virtual int Fill(SHEMAIRADataSet dataSet, int iDSHEMAIRA)
        {
            if (!this.FillByIDSHEMAIRA(dataSet, iDSHEMAIRA))
            {
                throw new SHEMAIRANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SHEMAIRA") }));
            }
            return 0;
        }

        public virtual bool FillByIDSHEMAIRA(SHEMAIRADataSet dataSet, int iDSHEMAIRA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAIRASet = dataSet;
            this.rowSHEMAIRA = this.SHEMAIRASet.SHEMAIRA.NewSHEMAIRARow();
            this.rowSHEMAIRA.IDSHEMAIRA = iDSHEMAIRA;
            try
            {
                this.LoadByIDSHEMAIRA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound220 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillBySHEMAIRADOKIDDOKUMENT(SHEMAIRADataSet dataSet, int sHEMAIRADOKIDDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAIRASet = dataSet;
            this.rowSHEMAIRA = this.SHEMAIRASet.SHEMAIRA.NewSHEMAIRARow();
            this.rowSHEMAIRA.SHEMAIRADOKIDDOKUMENT = sHEMAIRADOKIDDOKUMENT;
            try
            {
                this.LoadBySHEMAIRADOKIDDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(SHEMAIRADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAIRASet = dataSet;
            try
            {
                this.LoadChildShemaira(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageBySHEMAIRADOKIDDOKUMENT(SHEMAIRADataSet dataSet, int sHEMAIRADOKIDDOKUMENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SHEMAIRASet = dataSet;
            this.rowSHEMAIRA = this.SHEMAIRASet.SHEMAIRA.NewSHEMAIRARow();
            this.rowSHEMAIRA.SHEMAIRADOKIDDOKUMENT = sHEMAIRADOKIDDOKUMENT;
            try
            {
                this.LoadBySHEMAIRADOKIDDOKUMENT(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSHEMAIRA], [NAZIVSHEMAIRA], [SHEMAIRADOKIDDOKUMENT] AS SHEMAIRADOKIDDOKUMENT FROM [SHEMAIRA] WITH (NOLOCK) WHERE [IDSHEMAIRA] = @IDSHEMAIRA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["IDSHEMAIRA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound220 = 1;
                this.rowSHEMAIRA["IDSHEMAIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSHEMAIRA["NAZIVSHEMAIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.sMode220 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode220;
            }
            else
            {
                this.RcdFound220 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSHEMAIRA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAIRASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SHEMAIRA] WITH (NOLOCK) ", false);
            this.SHEMAIRASelect2 = this.cmSHEMAIRASelect2.FetchData();
            if (this.SHEMAIRASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SHEMAIRASelect2.GetInt32(0);
            }
            this.SHEMAIRASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountBySHEMAIRADOKIDDOKUMENT(int sHEMAIRADOKIDDOKUMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSHEMAIRASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SHEMAIRA] WITH (NOLOCK) WHERE [SHEMAIRADOKIDDOKUMENT] = @SHEMAIRADOKIDDOKUMENT ", false);
            if (this.cmSHEMAIRASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAIRASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmSHEMAIRASelect1.SetParameter(0, sHEMAIRADOKIDDOKUMENT);
            this.SHEMAIRASelect1 = this.cmSHEMAIRASelect1.FetchData();
            if (this.SHEMAIRASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SHEMAIRASelect1.GetInt32(0);
            }
            this.SHEMAIRASelect1.Close();
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

        public virtual int GetRecordCountBySHEMAIRADOKIDDOKUMENT(int sHEMAIRADOKIDDOKUMENT)
        {
            int internalRecordCountBySHEMAIRADOKIDDOKUMENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountBySHEMAIRADOKIDDOKUMENT = this.GetInternalRecordCountBySHEMAIRADOKIDDOKUMENT(sHEMAIRADOKIDDOKUMENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountBySHEMAIRADOKIDDOKUMENT;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound220 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__IDIRAVRSTAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SHEMAIRAMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SHEMAIRAOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove17 = false;
            this.RcdFound223 = 0;
            this.m_SubSelTopString223 = "";
            this.m__NAZIVSHEMAIRAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SHEMAIRADOKIDDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.SHEMAIRASet = new SHEMAIRADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertShemaira()
        {
            this.CheckOptimisticConcurrencyShemaira();
            this.AfterConfirmShemaira();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMAIRA] ([IDSHEMAIRA], [NAZIVSHEMAIRA], [SHEMAIRADOKIDDOKUMENT]) VALUES (@IDSHEMAIRA, @NAZIVSHEMAIRA, @SHEMAIRADOKIDDOKUMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSHEMAIRA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRADOKIDDOKUMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["IDSHEMAIRA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["NAZIVSHEMAIRA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMAIRADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaira();
            }
            this.OnSHEMAIRAUpdated(new SHEMAIRAEventArgs(this.rowSHEMAIRA, StatementType.Insert));
            this.ProcessLevelShemaira();
        }

        private void InsertShemairashemairakontiranje()
        {
            this.CheckOptimisticConcurrencyShemairashemairakontiranje();
            this.AfterConfirmShemairashemairakontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SHEMAIRASHEMAIRAKONTIRANJE] ([IDSHEMAIRA], [IDIRAVRSTAIZNOSA], [SHEMAIRAKONTOIDKONTO], [SHEMAIRASTRANEIDSTRANEKNJIZENJA], [SHEMAIRAMTIDMJESTOTROSKA], [SHEMAIRAOJIDORGJED]) VALUES (@IDSHEMAIRA, @IDIRAVRSTAIZNOSA, @SHEMAIRAKONTOIDKONTO, @SHEMAIRASTRANEIDSTRANEKNJIZENJA, @SHEMAIRAMTIDMJESTOTROSKA, @SHEMAIRAOJIDORGJED)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAKONTOIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAMTIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAOJIDORGJED", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDSHEMAIRA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDIRAVRSTAIZNOSA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAKONTOIDKONTO"]))));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRASTRANEIDSTRANEKNJIZENJA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAMTIDMJESTOTROSKA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAOJIDORGJED"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SHEMAIRASHEMAIRAKONTIRANJEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemairashemairakontiranje();
            }
            this.OnSHEMAIRASHEMAIRAKONTIRANJEUpdated(new SHEMAIRASHEMAIRAKONTIRANJEEventArgs(this.rowSHEMAIRASHEMAIRAKONTIRANJE, StatementType.Insert));
        }

        private void LoadByIDSHEMAIRA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SHEMAIRASet.EnforceConstraints;
            this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.BeginLoadData();
            this.SHEMAIRASet.SHEMAIRA.BeginLoadData();
            this.ScanByIDSHEMAIRA(startRow, maxRows);
            this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.EndLoadData();
            this.SHEMAIRASet.SHEMAIRA.EndLoadData();
            this.SHEMAIRASet.EnforceConstraints = enforceConstraints;
            if (this.SHEMAIRASet.SHEMAIRA.Count > 0)
            {
                this.rowSHEMAIRA = this.SHEMAIRASet.SHEMAIRA[this.SHEMAIRASet.SHEMAIRA.Count - 1];
            }
        }

        private void LoadBySHEMAIRADOKIDDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SHEMAIRASet.EnforceConstraints;
            this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.BeginLoadData();
            this.SHEMAIRASet.SHEMAIRA.BeginLoadData();
            this.ScanBySHEMAIRADOKIDDOKUMENT(startRow, maxRows);
            this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.EndLoadData();
            this.SHEMAIRASet.SHEMAIRA.EndLoadData();
            this.SHEMAIRASet.EnforceConstraints = enforceConstraints;
            if (this.SHEMAIRASet.SHEMAIRA.Count > 0)
            {
                this.rowSHEMAIRA = this.SHEMAIRASet.SHEMAIRA[this.SHEMAIRASet.SHEMAIRA.Count - 1];
            }
        }

        private void LoadChildShemaira(int startRow, int maxRows)
        {
            this.CreateNewRowShemaira();
            bool enforceConstraints = this.SHEMAIRASet.EnforceConstraints;
            this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.BeginLoadData();
            this.SHEMAIRASet.SHEMAIRA.BeginLoadData();
            this.ScanStartShemaira(startRow, maxRows);
            this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.EndLoadData();
            this.SHEMAIRASet.SHEMAIRA.EndLoadData();
            this.SHEMAIRASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildShemairashemairakontiranje()
        {
            this.CreateNewRowShemairashemairakontiranje();
            this.ScanStartShemairashemairakontiranje();
        }

        private void LoadDataShemaira(int maxRows)
        {
            int num = 0;
            if (this.RcdFound220 != 0)
            {
                this.ScanLoadShemaira();
                while ((this.RcdFound220 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowShemaira();
                    this.CreateNewRowShemaira();
                    this.ScanNextShemaira();
                }
            }
            if (num > 0)
            {
                this.RcdFound220 = 1;
            }
            this.ScanEndShemaira();
            if (this.SHEMAIRASet.SHEMAIRA.Count > 0)
            {
                this.rowSHEMAIRA = this.SHEMAIRASet.SHEMAIRA[this.SHEMAIRASet.SHEMAIRA.Count - 1];
            }
        }

        private void LoadDataShemairashemairakontiranje()
        {
            while (this.RcdFound223 != 0)
            {
                this.LoadRowShemairashemairakontiranje();
                this.CreateNewRowShemairashemairakontiranje();
                this.ScanNextShemairashemairakontiranje();
            }
            this.ScanEndShemairashemairakontiranje();
        }

        private void LoadRowShemaira()
        {
            this.AddRowShemaira();
        }

        private void LoadRowShemairashemairakontiranje()
        {
            this.AddRowShemairashemairakontiranje();
        }

        private void OnSHEMAIRASHEMAIRAKONTIRANJEUpdated(SHEMAIRASHEMAIRAKONTIRANJEEventArgs e)
        {
            if (this.SHEMAIRASHEMAIRAKONTIRANJEUpdated != null)
            {
                SHEMAIRASHEMAIRAKONTIRANJEUpdateEventHandler sHEMAIRASHEMAIRAKONTIRANJEUpdatedEvent = this.SHEMAIRASHEMAIRAKONTIRANJEUpdated;
                if (sHEMAIRASHEMAIRAKONTIRANJEUpdatedEvent != null)
                {
                    sHEMAIRASHEMAIRAKONTIRANJEUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMAIRASHEMAIRAKONTIRANJEUpdating(SHEMAIRASHEMAIRAKONTIRANJEEventArgs e)
        {
            if (this.SHEMAIRASHEMAIRAKONTIRANJEUpdating != null)
            {
                SHEMAIRASHEMAIRAKONTIRANJEUpdateEventHandler sHEMAIRASHEMAIRAKONTIRANJEUpdatingEvent = this.SHEMAIRASHEMAIRAKONTIRANJEUpdating;
                if (sHEMAIRASHEMAIRAKONTIRANJEUpdatingEvent != null)
                {
                    sHEMAIRASHEMAIRAKONTIRANJEUpdatingEvent(this, e);
                }
            }
        }

        private void OnSHEMAIRAUpdated(SHEMAIRAEventArgs e)
        {
            if (this.SHEMAIRAUpdated != null)
            {
                SHEMAIRAUpdateEventHandler sHEMAIRAUpdatedEvent = this.SHEMAIRAUpdated;
                if (sHEMAIRAUpdatedEvent != null)
                {
                    sHEMAIRAUpdatedEvent(this, e);
                }
            }
        }

        private void OnSHEMAIRAUpdating(SHEMAIRAEventArgs e)
        {
            if (this.SHEMAIRAUpdating != null)
            {
                SHEMAIRAUpdateEventHandler sHEMAIRAUpdatingEvent = this.SHEMAIRAUpdating;
                if (sHEMAIRAUpdatingEvent != null)
                {
                    sHEMAIRAUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelShemaira()
        {
            this.sMode220 = this.Gx_mode;
            this.ProcessNestedLevelShemairashemairakontiranje();
            this.Gx_mode = this.sMode220;
        }

        private void ProcessNestedLevelShemairashemairakontiranje()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.SHEMAIRASet.SHEMAIRASHEMAIRAKONTIRANJE.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowSHEMAIRASHEMAIRAKONTIRANJE = (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) current;
                    if (Helpers.IsRowChanged(this.rowSHEMAIRASHEMAIRAKONTIRANJE))
                    {
                        bool flag = false;
                        if (this.rowSHEMAIRASHEMAIRAKONTIRANJE.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowSHEMAIRASHEMAIRAKONTIRANJE.IDSHEMAIRA == this.rowSHEMAIRA.IDSHEMAIRA;
                        }
                        else
                        {
                            flag = this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDSHEMAIRA", DataRowVersion.Original].Equals(this.rowSHEMAIRA.IDSHEMAIRA);
                        }
                        if (flag)
                        {
                            this.ReadRowShemairashemairakontiranje();
                            if (this.rowSHEMAIRASHEMAIRAKONTIRANJE.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertShemairashemairakontiranje();
                            }
                            else
                            {
                                if (this._Gxremove17)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteShemairashemairakontiranje();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateShemairashemairakontiranje();
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

        private void ReadRowShemaira()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMAIRA.RowState);
            if (this.rowSHEMAIRA.RowState != DataRowState.Added)
            {
                this.m__NAZIVSHEMAIRAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["NAZIVSHEMAIRA", DataRowVersion.Original]);
                this.m__SHEMAIRADOKIDDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSHEMAIRAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["NAZIVSHEMAIRA"]);
                this.m__SHEMAIRADOKIDDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT"]);
            }
            this._Gxremove = this.rowSHEMAIRA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSHEMAIRA = (SHEMAIRADataSet.SHEMAIRARow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMAIRA);
            }
        }

        private void ReadRowShemairashemairakontiranje()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSHEMAIRASHEMAIRAKONTIRANJE.RowState);
            if (this.rowSHEMAIRASHEMAIRAKONTIRANJE.RowState != DataRowState.Added)
            {
                this.m__IDIRAVRSTAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDIRAVRSTAIZNOSA", DataRowVersion.Original]);
                this.m__SHEMAIRAMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAMTIDMJESTOTROSKA", DataRowVersion.Original]);
                this.m__SHEMAIRAOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAOJIDORGJED", DataRowVersion.Original]);
            }
            else
            {
                this.m__IDIRAVRSTAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDIRAVRSTAIZNOSA"]);
                this.m__SHEMAIRAMTIDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAMTIDMJESTOTROSKA"]);
                this.m__SHEMAIRAOJIDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAOJIDORGJED"]);
            }
            this._Gxremove17 = this.rowSHEMAIRASHEMAIRAKONTIRANJE.RowState == DataRowState.Deleted;
            if (this._Gxremove17)
            {
                this.rowSHEMAIRASHEMAIRAKONTIRANJE = (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) DataSetUtil.CloneOriginalDataRow(this.rowSHEMAIRASHEMAIRAKONTIRANJE);
            }
        }

        private void ScanByIDSHEMAIRA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSHEMAIRA] = @IDSHEMAIRA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString220 + "  FROM [SHEMAIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAIRA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString220, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAIRA] ) AS DK_PAGENUM   FROM [SHEMAIRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString220 + " FROM [SHEMAIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAIRA] ";
            }
            this.cmSHEMAIRASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSHEMAIRASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAIRASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
            }
            this.cmSHEMAIRASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["IDSHEMAIRA"]));
            this.SHEMAIRASelect5 = this.cmSHEMAIRASelect5.FetchData();
            this.RcdFound220 = 0;
            this.ScanLoadShemaira();
            this.LoadDataShemaira(maxRows);
            if (this.RcdFound220 > 0)
            {
                this.SubLvlScanStartShemairashemairakontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDSHEMAIRAShemaira(this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2);
                this.SubLvlFetchShemairashemairakontiranje();
                this.SubLoadDataShemairashemairakontiranje();
            }
        }

        private void ScanBySHEMAIRADOKIDDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[SHEMAIRADOKIDDOKUMENT] = @SHEMAIRADOKIDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString220 + "  FROM [SHEMAIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAIRA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString220, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAIRA] ) AS DK_PAGENUM   FROM [SHEMAIRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString220 + " FROM [SHEMAIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAIRA] ";
            }
            this.cmSHEMAIRASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSHEMAIRASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAIRASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmSHEMAIRASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT"]));
            this.SHEMAIRASelect5 = this.cmSHEMAIRASelect5.FetchData();
            this.RcdFound220 = 0;
            this.ScanLoadShemaira();
            this.LoadDataShemaira(maxRows);
            if (this.RcdFound220 > 0)
            {
                this.SubLvlScanStartShemairashemairakontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersSHEMAIRADOKIDDOKUMENTShemaira(this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2);
                this.SubLvlFetchShemairashemairakontiranje();
                this.SubLoadDataShemairashemairakontiranje();
            }
        }

        private void ScanEndShemaira()
        {
            this.SHEMAIRASelect5.Close();
        }

        private void ScanEndShemairashemairakontiranje()
        {
            this.SHEMAIRASHEMAIRAKONTIRANJESelect2.Close();
        }

        private void ScanLoadShemaira()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMAIRASelect5.HasMoreRows)
            {
                this.RcdFound220 = 1;
                this.rowSHEMAIRA["IDSHEMAIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAIRASelect5, 0));
                this.rowSHEMAIRA["NAZIVSHEMAIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAIRASelect5, 1));
                this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAIRASelect5, 2));
            }
        }

        private void ScanLoadShemairashemairakontiranje()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.HasMoreRows)
            {
                this.RcdFound223 = 1;
                this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDSHEMAIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAIRASHEMAIRAKONTIRANJESelect2, 0));
                this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDIRAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAIRASHEMAIRAKONTIRANJESelect2, 1));
                this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SHEMAIRASHEMAIRAKONTIRANJESelect2, 2))));
                this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRASTRANEIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAIRASHEMAIRAKONTIRANJESelect2, 3));
                this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAIRASHEMAIRAKONTIRANJESelect2, 4));
                this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAOJIDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SHEMAIRASHEMAIRAKONTIRANJESelect2, 5));
            }
        }

        private void ScanNextShemaira()
        {
            this.cmSHEMAIRASelect5.HasMoreRows = this.SHEMAIRASelect5.Read();
            this.RcdFound220 = 0;
            this.ScanLoadShemaira();
        }

        private void ScanNextShemairashemairakontiranje()
        {
            this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.HasMoreRows = this.SHEMAIRASHEMAIRAKONTIRANJESelect2.Read();
            this.RcdFound223 = 0;
            this.ScanLoadShemairashemairakontiranje();
        }

        private void ScanStartShemaira(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString220 + "  FROM [SHEMAIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAIRA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString220, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAIRA] ) AS DK_PAGENUM   FROM [SHEMAIRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString220 + " FROM [SHEMAIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSHEMAIRA] ";
            }
            this.cmSHEMAIRASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.SHEMAIRASelect5 = this.cmSHEMAIRASelect5.FetchData();
            this.RcdFound220 = 0;
            this.ScanLoadShemaira();
            this.LoadDataShemaira(maxRows);
            if (this.RcdFound220 > 0)
            {
                this.SubLvlScanStartShemairashemairakontiranje(this.m_WhereString, startRow, maxRows);
                this.SetParametersShemairaShemaira(this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2);
                this.SubLvlFetchShemairashemairakontiranje();
                this.SubLoadDataShemairashemairakontiranje();
            }
        }

        private void ScanStartShemairashemairakontiranje()
        {
            this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2 = this.connDefault.GetCommand("SELECT [IDSHEMAIRA], [IDIRAVRSTAIZNOSA], [SHEMAIRAKONTOIDKONTO] AS SHEMAIRAKONTOIDKONTO, [SHEMAIRASTRANEIDSTRANEKNJIZENJA] AS SHEMAIRASTRANEIDSTRANEKNJIZENJA, [SHEMAIRAMTIDMJESTOTROSKA] AS SHEMAIRAMTIDMJESTOTROSKA, [SHEMAIRAOJIDORGJED] AS SHEMAIRAOJIDORGJED FROM [SHEMAIRASHEMAIRAKONTIRANJE] WITH (NOLOCK) WHERE [IDSHEMAIRA] = @IDSHEMAIRA ORDER BY [IDSHEMAIRA], [SHEMAIRAKONTOIDKONTO], [SHEMAIRASTRANEIDSTRANEKNJIZENJA] ", false);
            if (this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
            }
            this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDSHEMAIRA"]));
            this.SHEMAIRASHEMAIRAKONTIRANJESelect2 = this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.FetchData();
            this.RcdFound223 = 0;
            this.ScanLoadShemairashemairakontiranje();
        }

        private void SetParametersIDSHEMAIRAShemaira(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["IDSHEMAIRA"]));
        }

        private void SetParametersSHEMAIRADOKIDDOKUMENTShemaira(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRADOKIDDOKUMENT", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT"]));
        }

        private void SetParametersShemairaShemaira(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextShemairashemairakontiranje()
        {
            this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.HasMoreRows = this.SHEMAIRASHEMAIRAKONTIRANJESelect2.Read();
            this.RcdFound223 = 0;
            if (this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.HasMoreRows)
            {
                this.RcdFound223 = 1;
            }
        }

        private void SubLoadDataShemairashemairakontiranje()
        {
            while (this.RcdFound223 != 0)
            {
                this.LoadRowShemairashemairakontiranje();
                this.CreateNewRowShemairashemairakontiranje();
                this.ScanNextShemairashemairakontiranje();
            }
            this.ScanEndShemairashemairakontiranje();
        }

        private void SubLvlFetchShemairashemairakontiranje()
        {
            this.CreateNewRowShemairashemairakontiranje();
            this.SHEMAIRASHEMAIRAKONTIRANJESelect2 = this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2.FetchData();
            this.RcdFound223 = 0;
            this.ScanLoadShemairashemairakontiranje();
        }

        private void SubLvlScanStartShemairashemairakontiranje(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString223 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDSHEMAIRA]  FROM [SHEMAIRA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDSHEMAIRA] )";
                    this.scmdbuf = "SELECT T1.[IDSHEMAIRA], T1.[IDIRAVRSTAIZNOSA], T1.[SHEMAIRAKONTOIDKONTO] AS SHEMAIRAKONTOIDKONTO, T1.[SHEMAIRASTRANEIDSTRANEKNJIZENJA] AS SHEMAIRASTRANEIDSTRANEKNJIZENJA, T1.[SHEMAIRAMTIDMJESTOTROSKA] AS SHEMAIRAMTIDMJESTOTROSKA, T1.[SHEMAIRAOJIDORGJED] AS SHEMAIRAOJIDORGJED FROM ([SHEMAIRASHEMAIRAKONTIRANJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString223 + "  TMX ON TMX.[IDSHEMAIRA] = T1.[IDSHEMAIRA]) ORDER BY T1.[IDSHEMAIRA], T1.[SHEMAIRAKONTOIDKONTO], T1.[SHEMAIRASTRANEIDSTRANEKNJIZENJA]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDSHEMAIRA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSHEMAIRA]  ) AS DK_PAGENUM   FROM [SHEMAIRA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString223 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDSHEMAIRA], T1.[IDIRAVRSTAIZNOSA], T1.[SHEMAIRAKONTOIDKONTO] AS SHEMAIRAKONTOIDKONTO, T1.[SHEMAIRASTRANEIDSTRANEKNJIZENJA] AS SHEMAIRASTRANEIDSTRANEKNJIZENJA, T1.[SHEMAIRAMTIDMJESTOTROSKA] AS SHEMAIRAMTIDMJESTOTROSKA, T1.[SHEMAIRAOJIDORGJED] AS SHEMAIRAOJIDORGJED FROM ([SHEMAIRASHEMAIRAKONTIRANJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString223 + "  TMX ON TMX.[IDSHEMAIRA] = T1.[IDSHEMAIRA]) ORDER BY T1.[IDSHEMAIRA], T1.[SHEMAIRAKONTOIDKONTO], T1.[SHEMAIRASTRANEIDSTRANEKNJIZENJA]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString223 = "[SHEMAIRA]";
                this.scmdbuf = "SELECT T1.[IDSHEMAIRA], T1.[IDIRAVRSTAIZNOSA], T1.[SHEMAIRAKONTOIDKONTO] AS SHEMAIRAKONTOIDKONTO, T1.[SHEMAIRASTRANEIDSTRANEKNJIZENJA] AS SHEMAIRASTRANEIDSTRANEKNJIZENJA, T1.[SHEMAIRAMTIDMJESTOTROSKA] AS SHEMAIRAMTIDMJESTOTROSKA, T1.[SHEMAIRAOJIDORGJED] AS SHEMAIRAOJIDORGJED FROM ([SHEMAIRASHEMAIRAKONTIRANJE] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString223 + "  TM1 WITH (NOLOCK) ON TM1.[IDSHEMAIRA] = T1.[IDSHEMAIRA])" + this.m_WhereString + " ORDER BY T1.[IDSHEMAIRA], T1.[SHEMAIRAKONTOIDKONTO], T1.[SHEMAIRASTRANEIDSTRANEKNJIZENJA] ";
            }
            this.cmSHEMAIRASHEMAIRAKONTIRANJESelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.SHEMAIRASet = (SHEMAIRADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.SHEMAIRASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.SHEMAIRASet.SHEMAIRA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        SHEMAIRADataSet.SHEMAIRARow current = (SHEMAIRADataSet.SHEMAIRARow) enumerator.Current;
                        this.rowSHEMAIRA = current;
                        if (Helpers.IsRowChanged(this.rowSHEMAIRA))
                        {
                            this.ReadRowShemaira();
                            if (this.rowSHEMAIRA.RowState == DataRowState.Added)
                            {
                                this.InsertShemaira();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateShemaira();
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

        private void UpdateShemaira()
        {
            this.CheckOptimisticConcurrencyShemaira();
            this.AfterConfirmShemaira();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMAIRA] SET [NAZIVSHEMAIRA]=@NAZIVSHEMAIRA, [SHEMAIRADOKIDDOKUMENT]=@SHEMAIRADOKIDDOKUMENT  WHERE [IDSHEMAIRA] = @IDSHEMAIRA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSHEMAIRA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["NAZIVSHEMAIRA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["SHEMAIRADOKIDDOKUMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRA["IDSHEMAIRA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemaira();
            }
            this.OnSHEMAIRAUpdated(new SHEMAIRAEventArgs(this.rowSHEMAIRA, StatementType.Update));
            this.ProcessLevelShemaira();
        }

        private void UpdateShemairashemairakontiranje()
        {
            this.CheckOptimisticConcurrencyShemairashemairakontiranje();
            this.AfterConfirmShemairashemairakontiranje();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SHEMAIRASHEMAIRAKONTIRANJE] SET [IDIRAVRSTAIZNOSA]=@IDIRAVRSTAIZNOSA, [SHEMAIRAMTIDMJESTOTROSKA]=@SHEMAIRAMTIDMJESTOTROSKA, [SHEMAIRAOJIDORGJED]=@SHEMAIRAOJIDORGJED  WHERE [IDSHEMAIRA] = @IDSHEMAIRA AND [SHEMAIRAKONTOIDKONTO] = @SHEMAIRAKONTOIDKONTO AND [SHEMAIRASTRANEIDSTRANEKNJIZENJA] = @SHEMAIRASTRANEIDSTRANEKNJIZENJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAMTIDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAOJIDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSHEMAIRA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRAKONTOIDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SHEMAIRASTRANEIDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDIRAVRSTAIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAMTIDMJESTOTROSKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAOJIDORGJED"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["IDSHEMAIRA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRAKONTOIDKONTO"]))));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowSHEMAIRASHEMAIRAKONTIRANJE["SHEMAIRASTRANEIDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsShemairashemairakontiranje();
            }
            this.OnSHEMAIRASHEMAIRAKONTIRANJEUpdated(new SHEMAIRASHEMAIRAKONTIRANJEEventArgs(this.rowSHEMAIRASHEMAIRAKONTIRANJE, StatementType.Update));
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
        public class DOKUMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public DOKUMENTForeignKeyNotFoundException()
            {
            }

            public DOKUMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected DOKUMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOKUMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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
        public class IRAVRSTAIZNOSAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public IRAVRSTAIZNOSAForeignKeyNotFoundException()
            {
            }

            public IRAVRSTAIZNOSAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected IRAVRSTAIZNOSAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAVRSTAIZNOSAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
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
        public class SHEMAIRADataChangedException : DataChangedException
        {
            public SHEMAIRADataChangedException()
            {
            }

            public SHEMAIRADataChangedException(string message) : base(message)
            {
            }

            protected SHEMAIRADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAIRADataLockedException : DataLockedException
        {
            public SHEMAIRADataLockedException()
            {
            }

            public SHEMAIRADataLockedException(string message) : base(message)
            {
            }

            protected SHEMAIRADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAIRADuplicateKeyException : DuplicateKeyException
        {
            public SHEMAIRADuplicateKeyException()
            {
            }

            public SHEMAIRADuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMAIRADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMAIRAEventArgs : EventArgs
        {
            private SHEMAIRADataSet.SHEMAIRARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMAIRAEventArgs(SHEMAIRADataSet.SHEMAIRARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMAIRADataSet.SHEMAIRARow Row
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
        public class SHEMAIRANotFoundException : DataNotFoundException
        {
            public SHEMAIRANotFoundException()
            {
            }

            public SHEMAIRANotFoundException(string message) : base(message)
            {
            }

            protected SHEMAIRANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAIRASHEMAIRAKONTIRANJEDataChangedException : DataChangedException
        {
            public SHEMAIRASHEMAIRAKONTIRANJEDataChangedException()
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEDataChangedException(string message) : base(message)
            {
            }

            protected SHEMAIRASHEMAIRAKONTIRANJEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAIRASHEMAIRAKONTIRANJEDataLockedException : DataLockedException
        {
            public SHEMAIRASHEMAIRAKONTIRANJEDataLockedException()
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEDataLockedException(string message) : base(message)
            {
            }

            protected SHEMAIRASHEMAIRAKONTIRANJEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAIRASHEMAIRAKONTIRANJEDuplicateKeyException : DuplicateKeyException
        {
            public SHEMAIRASHEMAIRAKONTIRANJEDuplicateKeyException()
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEDuplicateKeyException(string message) : base(message)
            {
            }

            protected SHEMAIRASHEMAIRAKONTIRANJEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SHEMAIRASHEMAIRAKONTIRANJEEventArgs : EventArgs
        {
            private SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SHEMAIRASHEMAIRAKONTIRANJEEventArgs(SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow Row
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

        public delegate void SHEMAIRASHEMAIRAKONTIRANJEUpdateEventHandler(object sender, SHEMAIRADataAdapter.SHEMAIRASHEMAIRAKONTIRANJEEventArgs e);

        public delegate void SHEMAIRAUpdateEventHandler(object sender, SHEMAIRADataAdapter.SHEMAIRAEventArgs e);

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
    }
}

