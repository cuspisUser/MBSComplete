namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic.CompilerServices;
    using mipsed.application.framework;
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

    public class IRADataAdapter : IDataAdapter, IIRADataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmIRASelect1;
        private ReadWriteCommand cmIRASelect2;
        private ReadWriteCommand cmIRASelect3;
        private ReadWriteCommand cmIRASelect4;
        private ReadWriteCommand cmIRASelect5;
        private ReadWriteCommand cmIRASelect6;
        private ReadWriteCommand cmIRASelect9;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader IRASelect1;
        private IDataReader IRASelect2;
        private IDataReader IRASelect3;
        private IDataReader IRASelect4;
        private IDataReader IRASelect5;
        private IDataReader IRASelect6;
        private IDataReader IRASelect9;
        private IRADataSet IRASet;
        private object m__IDTIPIRAOriginal;
        private object m__IRADATUMOriginal;
        private object m__IRANAPOMENAOriginal;
        private object m__IRAPARTNERIDPARTNEROriginal;
        private object m__IRAUKUPNOOriginal;
        private object m__IRAVALUTAOriginal;
        private object m__IZVOZOriginal;
        private object m__MEDJTRANSOriginal;
        private object m__NEPODLEZEOriginal;
        private object m__NEPODLEZE_USLUGAOriginal;
        private object m__NULAOriginal;
        private object m__OSN10Original;
        private object m__OSN22Original;
        private object m__OSN23Original;
        private object m__OSN25Original;
        private object m__OSTALOOriginal;
        private object m__PDV10Original;
        private object m__PDV22Original;
        private object m__PDV23Original;
        private object m__PDV25Original;
        private object m__PDV05Original;
        private object m__OSN05Original;
        private object m__TUZEMSTVOOriginal;
        private readonly string m_SelectString187 = "TM1.[IRABROJ], TM1.[NEPODLEZE], TM1.[NEPODLEZE_USLUGA], TM1.[IZVOZ], TM1.[MEDJTRANS], TM1.[TUZEMSTVO], TM1.[OSTALO], TM1.[NULA], TM1.[OSN10], TM1.[OSN22], TM1.[OSN23], TM1.[OSN25], TM1.[OSN05], TM1.[PDV10], TM1.[PDV22], TM1.[PDV23], TM1.[PDV25], TM1.[PDV05], TM1.[IRADATUM], TM1.[IRAVALUTA], TM1.[IRANAPOMENA], TM1.[IRAUKUPNO], TM1.[IDTIPIRA], TM1.[IRAGODIDGODINE] AS IRAGODIDGODINE, TM1.[IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, TM1.[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER";
        private string m_WhereString;
        private short RcdFound187;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IRADataSet.IRARow rowIRA;
        private string scmdbuf;
        private StatementType sMode187;

        public event IRAUpdateEventHandler IRAUpdated;

        public event IRAUpdateEventHandler IRAUpdating;

        private void AddRowIra()
        {
            this.IRASet.IRA.AddIRARow(this.rowIRA);
        }

        private void AfterConfirmIra()
        {
            this.OnIRAUpdating(new IRAEventArgs(this.rowIRA, this.Gx_mode));
        }

        private void CheckExtendedTableIra()
        {
            if (this.rowIRA.IRADATUM.Year != mipsed.application.framework.Application.ActiveYear)
            {
                throw new PogresanDatum("Greška u datumu");
            }
        }

        private void CheckIntegrityErrorsIra()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDGODINE] AS IRAGODIDGODINE FROM [GODINE] WITH (NOLOCK) WHERE [IDGODINE] = @IRAGODIDGODINE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new GODINEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOKUMENT] AS IRADOKIDDOKUMENT FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDDOKUMENT] = @IRADOKIDDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOKUMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOKUMENT") }));
            }
            reader.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDPARTNER] AS IRAPARTNERIDPARTNER FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @IRAPARTNERIDPARTNER ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAPARTNERIDPARTNER", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAPARTNERIDPARTNER"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new PARTNERForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PARTNER") }));
            }
            reader3.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [IDTIPIRA] FROM [TIPIRA] WITH (NOLOCK) WHERE [IDTIPIRA] = @IDTIPIRA ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IDTIPIRA"]));
            IDataReader reader4 = command4.FetchData();
            if (!command4.HasMoreRows)
            {
                reader4.Close();
                throw new TIPIRAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPIRA") }));
            }
            reader4.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyIra()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IRABROJ], [NEPODLEZE], [NEPODLEZE_USLUGA], [IZVOZ], [MEDJTRANS], [TUZEMSTVO], [OSTALO], [NULA], [OSN10], [OSN22], [OSN23], [OSN25], [OSN05], " +
                "[PDV10], [PDV22], [PDV23], [PDV25], [PDV05], [IRADATUM], [IRAVALUTA], [IRANAPOMENA], [IRAUKUPNO], [IDTIPIRA], [IRAGODIDGODINE] AS IRAGODIDGODINE, [IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, " +
                "[IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] WITH (UPDLOCK) WHERE [IRAGODIDGODINE] = @IRAGODIDGODINE AND [IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT AND [IRABROJ] = @IRABROJ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRABROJ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowIRA["IRABROJ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new IRADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("IRA") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || 
                    !this.m__NEPODLEZEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1))) ||
                    !this.m__NEPODLEZE_USLUGAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2)))) || 
                    ((!this.m__IZVOZOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3))) || 
                    !this.m__MEDJTRANSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || 
                    (!this.m__TUZEMSTVOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))) || 
                    !this.m__OSTALOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || 
                    !this.m__NULAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7)))) || 
                    ((!this.m__OSN10Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8))) ||
                    !this.m__OSN22Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9)))) ||
                    !this.m__OSN23Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10))) ||
                    !this.m__OSN25Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11))) ||
                    !this.m__OSN05Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12))) ||
                    !this.m__PDV10Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13)))))
                {
                    this._Condition = true;
                }
                if ((this._Condition ||
                    !this.m__PDV22Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14)))) ||
                    !this.m__PDV23Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 15))) ||
                    !this.m__PDV25Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 16))) ||
                    !this.m__PDV05Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 17))) ||
                    ((!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__IRADATUMOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 18))) || 
                    !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__IRAVALUTAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 19)))) || 
                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IRANAPOMENAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 20)))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__IRAUKUPNOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 21)))) || 
                    (!this.m__IDTIPIRAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 22))) || 
                    !this.m__IRAPARTNERIDPARTNEROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 25)))))
                {
                    reader.Close();
                    throw new IRADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("IRA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowIra()
        {
            this.rowIRA = this.IRASet.IRA.NewIRARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyIra();
            this.AfterConfirmIra();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [IRA]  WHERE [IRAGODIDGODINE] = @IRAGODIDGODINE AND [IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT AND [IRABROJ] = @IRABROJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRABROJ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowIRA["IRABROJ"]));
            command.ExecuteStmt();
            this.OnIRAUpdated(new IRAEventArgs(this.rowIRA, StatementType.Delete));
            this.rowIRA.Delete();
            this.sMode187 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode187;
        }

        public virtual int Fill(IRADataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, short.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.IRASet = dataSet;
                    this.LoadChildIra(0, -1);
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
            this.IRASet = (IRADataSet) dataSet;
            if (this.IRASet != null)
            {
                return this.Fill(this.IRASet);
            }
            this.IRASet = new IRADataSet();
            this.Fill(this.IRASet);
            dataSet.Merge(this.IRASet);
            return 0;
        }

        public virtual int Fill(IRADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["IRAGODIDGODINE"]), Conversions.ToInteger(dataRecord["IRADOKIDDOKUMENT"]), Conversions.ToInteger(dataRecord["IRABROJ"]));
        }

        public virtual int Fill(IRADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["IRAGODIDGODINE"]), Conversions.ToInteger(dataRecord["IRADOKIDDOKUMENT"]), Conversions.ToInteger(dataRecord["IRABROJ"]));
        }

        public virtual int Fill(IRADataSet dataSet, short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int iRABROJ)
        {
            if (!this.FillByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(dataSet, iRAGODIDGODINE, iRADOKIDDOKUMENT, iRABROJ))
            {
                throw new IRANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("IRA") }));
            }
            return 0;
        }

        public virtual int FillByIDTIPIRA(IRADataSet dataSet, int iDTIPIRA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IDTIPIRA = iDTIPIRA;
            try
            {
                this.LoadByIDTIPIRA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIRADOKIDDOKUMENT(IRADataSet dataSet, int iRADOKIDDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRADOKIDDOKUMENT = iRADOKIDDOKUMENT;
            try
            {
                this.LoadByIRADOKIDDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIRAGODIDGODINE(IRADataSet dataSet, short iRAGODIDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRAGODIDGODINE = iRAGODIDGODINE;
            try
            {
                this.LoadByIRAGODIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIRAGODIDGODINEIRADOKIDDOKUMENT(IRADataSet dataSet, short iRAGODIDGODINE, int iRADOKIDDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRAGODIDGODINE = iRAGODIDGODINE;
            this.rowIRA.IRADOKIDDOKUMENT = iRADOKIDDOKUMENT;
            try
            {
                this.LoadByIRAGODIDGODINEIRADOKIDDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(IRADataSet dataSet, short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int iRABROJ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRAGODIDGODINE = iRAGODIDGODINE;
            this.rowIRA.IRADOKIDDOKUMENT = iRADOKIDDOKUMENT;
            this.rowIRA.IRABROJ = iRABROJ;
            try
            {
                this.LoadByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound187 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIRAPARTNERIDPARTNER(IRADataSet dataSet, int iRAPARTNERIDPARTNER)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRAPARTNERIDPARTNER = iRAPARTNERIDPARTNER;
            try
            {
                this.LoadByIRAPARTNERIDPARTNER(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(IRADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            try
            {
                this.LoadChildIra(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDTIPIRA(IRADataSet dataSet, int iDTIPIRA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IDTIPIRA = iDTIPIRA;
            try
            {
                this.LoadByIDTIPIRA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIRADOKIDDOKUMENT(IRADataSet dataSet, int iRADOKIDDOKUMENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRADOKIDDOKUMENT = iRADOKIDDOKUMENT;
            try
            {
                this.LoadByIRADOKIDDOKUMENT(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIRAGODIDGODINE(IRADataSet dataSet, short iRAGODIDGODINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRAGODIDGODINE = iRAGODIDGODINE;
            try
            {
                this.LoadByIRAGODIDGODINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIRAGODIDGODINEIRADOKIDDOKUMENT(IRADataSet dataSet, short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRAGODIDGODINE = iRAGODIDGODINE;
            this.rowIRA.IRADOKIDDOKUMENT = iRADOKIDDOKUMENT;
            try
            {
                this.LoadByIRAGODIDGODINEIRADOKIDDOKUMENT(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIRAPARTNERIDPARTNER(IRADataSet dataSet, int iRAPARTNERIDPARTNER, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRASet = dataSet;
            this.rowIRA = this.IRASet.IRA.NewIRARow();
            this.rowIRA.IRAPARTNERIDPARTNER = iRAPARTNERIDPARTNER;
            try
            {
                this.LoadByIRAPARTNERIDPARTNER(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IRABROJ], [NEPODLEZE], [IZVOZ], [MEDJTRANS], [TUZEMSTVO], [OSTALO], [NULA], [OSN10], [OSN22], [OSN23], [OSN25], [PDV10], [PDV22], [PDV23], [PDV25], [IRADATUM], [IRAVALUTA], [IRANAPOMENA], [IRAUKUPNO], [IDTIPIRA], [IRAGODIDGODINE] AS IRAGODIDGODINE, [IRADOKIDDOKUMENT] AS IRADOKIDDOKUMENT, [IRAPARTNERIDPARTNER] AS IRAPARTNERIDPARTNER FROM [IRA] WITH (NOLOCK) WHERE [IRAGODIDGODINE] = @IRAGODIDGODINE AND [IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT AND [IRABROJ] = @IRABROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRABROJ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowIRA["IRABROJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound187 = 1;
                this.rowIRA["IRABROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowIRA["NEPODLEZE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowIRA["IZVOZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowIRA["MEDJTRANS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3));
                this.rowIRA["TUZEMSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4));
                this.rowIRA["OSTALO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5));
                this.rowIRA["NULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6));
                this.rowIRA["OSN10"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7));
                this.rowIRA["OSN22"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8));
                this.rowIRA["OSN23"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9));
                this.rowIRA["OSN25"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10));
                this.rowIRA["PDV10"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11));
                this.rowIRA["PDV22"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12));
                this.rowIRA["PDV23"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13));
                this.rowIRA["PDV25"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14));
                this.rowIRA["IRADATUM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 15));
                this.rowIRA["IRAVALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 16));
                this.rowIRA["IRANAPOMENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 17));
                this.rowIRA["IRAUKUPNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 18));
                this.rowIRA["IDTIPIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 19));
                this.rowIRA["IRAGODIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 20));
                this.rowIRA["IRADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 21));
                this.rowIRA["IRAPARTNERIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 22));
                this.sMode187 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode187;
            }
            else
            {
                this.RcdFound187 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "IRAGODIDGODINE";
                parameter.DbType = DbType.Int16;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "IRADOKIDDOKUMENT";
                parameter2.DbType = DbType.Int32;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "IRABROJ";
                parameter3.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect6 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IRA] WITH (NOLOCK) ", false);
            this.IRASelect6 = this.cmIRASelect6.FetchData();
            if (this.IRASelect6.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IRASelect6.GetInt32(0);
            }
            this.IRASelect6.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDTIPIRA(int iDTIPIRA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IRA] WITH (NOLOCK) WHERE [IDTIPIRA] = @IDTIPIRA ", false);
            if (this.cmIRASelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            this.cmIRASelect3.SetParameter(0, iDTIPIRA);
            this.IRASelect3 = this.cmIRASelect3.FetchData();
            if (this.IRASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IRASelect3.GetInt32(0);
            }
            this.IRASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIRADOKIDDOKUMENT(int iRADOKIDDOKUMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect5 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IRA] WITH (NOLOCK) WHERE [IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT ", false);
            if (this.cmIRASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmIRASelect5.SetParameter(0, iRADOKIDDOKUMENT);
            this.IRASelect5 = this.cmIRASelect5.FetchData();
            if (this.IRASelect5.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IRASelect5.GetInt32(0);
            }
            this.IRASelect5.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIRAGODIDGODINE(short iRAGODIDGODINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IRA] WITH (NOLOCK) WHERE [IRAGODIDGODINE] = @IRAGODIDGODINE ", false);
            if (this.cmIRASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
            }
            this.cmIRASelect2.SetParameter(0, iRAGODIDGODINE);
            this.IRASelect2 = this.cmIRASelect2.FetchData();
            if (this.IRASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IRASelect2.GetInt32(0);
            }
            this.IRASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIRAGODIDGODINEIRADOKIDDOKUMENT(short iRAGODIDGODINE, int iRADOKIDDOKUMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IRA] WITH (NOLOCK) WHERE [IRAGODIDGODINE] = @IRAGODIDGODINE and [IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT ", false);
            if (this.cmIRASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                this.cmIRASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmIRASelect1.SetParameter(0, iRAGODIDGODINE);
            this.cmIRASelect1.SetParameter(1, iRADOKIDDOKUMENT);
            this.IRASelect1 = this.cmIRASelect1.FetchData();
            if (this.IRASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IRASelect1.GetInt32(0);
            }
            this.IRASelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIRAPARTNERIDPARTNER(int iRAPARTNERIDPARTNER)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRASelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IRA] WITH (NOLOCK) WHERE [IRAPARTNERIDPARTNER] = @IRAPARTNERIDPARTNER ", false);
            if (this.cmIRASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAPARTNERIDPARTNER", DbType.Int32));
            }
            this.cmIRASelect4.SetParameter(0, iRAPARTNERIDPARTNER);
            this.IRASelect4 = this.cmIRASelect4.FetchData();
            if (this.IRASelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IRASelect4.GetInt32(0);
            }
            this.IRASelect4.Close();
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

        public virtual int GetRecordCountByIDTIPIRA(int iDTIPIRA)
        {
            int internalRecordCountByIDTIPIRA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDTIPIRA = this.GetInternalRecordCountByIDTIPIRA(iDTIPIRA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDTIPIRA;
        }

        public virtual int GetRecordCountByIRADOKIDDOKUMENT(int iRADOKIDDOKUMENT)
        {
            int internalRecordCountByIRADOKIDDOKUMENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIRADOKIDDOKUMENT = this.GetInternalRecordCountByIRADOKIDDOKUMENT(iRADOKIDDOKUMENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIRADOKIDDOKUMENT;
        }

        public virtual int GetRecordCountByIRAGODIDGODINE(short iRAGODIDGODINE)
        {
            int internalRecordCountByIRAGODIDGODINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIRAGODIDGODINE = this.GetInternalRecordCountByIRAGODIDGODINE(iRAGODIDGODINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIRAGODIDGODINE;
        }

        public virtual int GetRecordCountByIRAGODIDGODINEIRADOKIDDOKUMENT(short iRAGODIDGODINE, int iRADOKIDDOKUMENT)
        {
            int internalRecordCountByIRAGODIDGODINEIRADOKIDDOKUMENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIRAGODIDGODINEIRADOKIDDOKUMENT = this.GetInternalRecordCountByIRAGODIDGODINEIRADOKIDDOKUMENT(iRAGODIDGODINE, iRADOKIDDOKUMENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIRAGODIDGODINEIRADOKIDDOKUMENT;
        }

        public virtual int GetRecordCountByIRAPARTNERIDPARTNER(int iRAPARTNERIDPARTNER)
        {
            int internalRecordCountByIRAPARTNERIDPARTNER;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIRAPARTNERIDPARTNER = this.GetInternalRecordCountByIRAPARTNERIDPARTNER(iRAPARTNERIDPARTNER);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIRAPARTNERIDPARTNER;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound187 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NEPODLEZEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NEPODLEZE_USLUGAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZVOZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MEDJTRANSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__TUZEMSTVOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSTALOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NULAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSN10Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSN22Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSN23Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSN25Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSN05Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV10Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV22Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV23Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV25Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV05Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__IRADATUMOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IRAVALUTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IRANAPOMENAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IRAUKUPNOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDTIPIRAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IRAPARTNERIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.IRASet = new IRADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertIra()
        {
            this.CheckOptimisticConcurrencyIra();
            this.CheckExtendedTableIra();
            this.AfterConfirmIra();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [IRA] ([IRABROJ], [NEPODLEZE], [IZVOZ], [MEDJTRANS], [TUZEMSTVO], [OSTALO], [NULA], " + 
            "[OSN10], [OSN22], [OSN23], [OSN25], [PDV10], [PDV22], [PDV23], [PDV25], [IRADATUM], [IRAVALUTA], [IRANAPOMENA], [IRAUKUPNO], [IDTIPIRA], [IRAGODIDGODINE], " +
            "[IRADOKIDDOKUMENT], [IRAPARTNERIDPARTNER], [OSN05], [PDV05], [NEPODLEZE_USLUGA]) VALUES (@IRABROJ, @NEPODLEZE, @IZVOZ, @MEDJTRANS, @TUZEMSTVO, @OSTALO, @NULA, @OSN10, @OSN22, " +
            "@OSN23, @OSN25, @PDV10, @PDV22, @PDV23, @PDV25, @IRADATUM, @IRAVALUTA, @IRANAPOMENA, @IRAUKUPNO, @IDTIPIRA, @IRAGODIDGODINE, @IRADOKIDDOKUMENT, @IRAPARTNERIDPARTNER, @OSN05, @PDV05, @NEPODLEZE_USLUGA)", false);
            // 
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRABROJ", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NEPODLEZE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZVOZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MEDJTRANS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TUZEMSTVO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSTALO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NULA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN10", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN22", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN23", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN25", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV10", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV22", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV23", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV25", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADATUM", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAVALUTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRANAPOMENA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAUKUPNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAPARTNERIDPARTNER", DbType.Int32));
                //hrvoje
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN05", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV05", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NEPODLEZE_USLUGA", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRABROJ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRA["NEPODLEZE"]));
            
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowIRA["IZVOZ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowIRA["MEDJTRANS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowIRA["TUZEMSTVO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowIRA["OSTALO"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowIRA["NULA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN10"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN22"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN23"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN25"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV10"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV22"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV23"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV25"]));
            command.SetParameterDateObject(15, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADATUM"]));
            command.SetParameterDateObject(16, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAVALUTA"]));
            command.SetParameter(17, RuntimeHelpers.GetObjectValue(this.rowIRA["IRANAPOMENA"]));
            command.SetParameter(18, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAUKUPNO"]));
            command.SetParameter(19, RuntimeHelpers.GetObjectValue(this.rowIRA["IDTIPIRA"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
            command.SetParameter(21, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
            command.SetParameter(22, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAPARTNERIDPARTNER"]));
            //hrvoje
            command.SetParameter(23, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN05"]));
            command.SetParameter(24, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV05"]));
            command.SetParameter(25, RuntimeHelpers.GetObjectValue(this.rowIRA["NEPODLEZE_USLUGA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new IRADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsIra();
            }
            this.OnIRAUpdated(new IRAEventArgs(this.rowIRA, StatementType.Insert));
        }

        private void LoadByIDTIPIRA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IRASet.EnforceConstraints;
            this.IRASet.IRA.BeginLoadData();
            this.ScanByIDTIPIRA(startRow, maxRows);
            this.IRASet.IRA.EndLoadData();
            this.IRASet.EnforceConstraints = enforceConstraints;
            if (this.IRASet.IRA.Count > 0)
            {
                this.rowIRA = this.IRASet.IRA[this.IRASet.IRA.Count - 1];
            }
        }

        private void LoadByIRADOKIDDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IRASet.EnforceConstraints;
            this.IRASet.IRA.BeginLoadData();
            this.ScanByIRADOKIDDOKUMENT(startRow, maxRows);
            this.IRASet.IRA.EndLoadData();
            this.IRASet.EnforceConstraints = enforceConstraints;
            if (this.IRASet.IRA.Count > 0)
            {
                this.rowIRA = this.IRASet.IRA[this.IRASet.IRA.Count - 1];
            }
        }

        private void LoadByIRAGODIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IRASet.EnforceConstraints;
            this.IRASet.IRA.BeginLoadData();
            this.ScanByIRAGODIDGODINE(startRow, maxRows);
            this.IRASet.IRA.EndLoadData();
            this.IRASet.EnforceConstraints = enforceConstraints;
            if (this.IRASet.IRA.Count > 0)
            {
                this.rowIRA = this.IRASet.IRA[this.IRASet.IRA.Count - 1];
            }
        }

        private void LoadByIRAGODIDGODINEIRADOKIDDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IRASet.EnforceConstraints;
            this.IRASet.IRA.BeginLoadData();
            this.ScanByIRAGODIDGODINEIRADOKIDDOKUMENT(startRow, maxRows);
            this.IRASet.IRA.EndLoadData();
            this.IRASet.EnforceConstraints = enforceConstraints;
            if (this.IRASet.IRA.Count > 0)
            {
                this.rowIRA = this.IRASet.IRA[this.IRASet.IRA.Count - 1];
            }
        }

        private void LoadByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IRASet.EnforceConstraints;
            this.IRASet.IRA.BeginLoadData();
            this.ScanByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(startRow, maxRows);
            this.IRASet.IRA.EndLoadData();
            this.IRASet.EnforceConstraints = enforceConstraints;
            if (this.IRASet.IRA.Count > 0)
            {
                this.rowIRA = this.IRASet.IRA[this.IRASet.IRA.Count - 1];
            }
        }

        private void LoadByIRAPARTNERIDPARTNER(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IRASet.EnforceConstraints;
            this.IRASet.IRA.BeginLoadData();
            this.ScanByIRAPARTNERIDPARTNER(startRow, maxRows);
            this.IRASet.IRA.EndLoadData();
            this.IRASet.EnforceConstraints = enforceConstraints;
            if (this.IRASet.IRA.Count > 0)
            {
                this.rowIRA = this.IRASet.IRA[this.IRASet.IRA.Count - 1];
            }
        }

        private void LoadChildIra(int startRow, int maxRows)
        {
            this.CreateNewRowIra();
            bool enforceConstraints = this.IRASet.EnforceConstraints;
            this.IRASet.IRA.BeginLoadData();
            this.ScanStartIra(startRow, maxRows);
            this.IRASet.IRA.EndLoadData();
            this.IRASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataIra(int maxRows)
        {
            int num = 0;
            if (this.RcdFound187 != 0)
            {
                this.ScanLoadIra();
                while ((this.RcdFound187 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowIra();
                    this.CreateNewRowIra();
                    this.ScanNextIra();
                }
            }
            if (num > 0)
            {
                this.RcdFound187 = 1;
            }
            this.ScanEndIra();
            if (this.IRASet.IRA.Count > 0)
            {
                this.rowIRA = this.IRASet.IRA[this.IRASet.IRA.Count - 1];
            }
        }

        private void LoadRowIra()
        {
            this.AddRowIra();
        }

        private void OnIRAUpdated(IRAEventArgs e)
        {
            if (this.IRAUpdated != null)
            {
                IRAUpdateEventHandler iRAUpdatedEvent = this.IRAUpdated;
                if (iRAUpdatedEvent != null)
                {
                    iRAUpdatedEvent(this, e);
                }
            }
        }

        private void OnIRAUpdating(IRAEventArgs e)
        {
            if (this.IRAUpdating != null)
            {
                IRAUpdateEventHandler iRAUpdatingEvent = this.IRAUpdating;
                if (iRAUpdatingEvent != null)
                {
                    iRAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowIra()
        {
            this.Gx_mode = Mode.FromRowState(this.rowIRA.RowState);
            if (this.rowIRA.RowState != DataRowState.Deleted)
            {
                this.rowIRA["IRADATUM"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowIRA["IRADATUM"])));
                this.rowIRA["IRAVALUTA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowIRA["IRAVALUTA"])));
            }
            if (this.rowIRA.RowState != DataRowState.Added)
            {
                this.m__NEPODLEZEOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["NEPODLEZE", DataRowVersion.Original]);
                this.m__NEPODLEZE_USLUGAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["NEPODLEZE_USLUGA", DataRowVersion.Original]);
                this.m__IZVOZOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IZVOZ", DataRowVersion.Original]);
                this.m__MEDJTRANSOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["MEDJTRANS", DataRowVersion.Original]);
                this.m__TUZEMSTVOOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["TUZEMSTVO", DataRowVersion.Original]);
                this.m__OSTALOOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["OSTALO", DataRowVersion.Original]);
                this.m__NULAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["NULA", DataRowVersion.Original]);
                this.m__OSN10Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN10", DataRowVersion.Original]);
                this.m__OSN22Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN22", DataRowVersion.Original]);
                this.m__OSN23Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN23", DataRowVersion.Original]);
                this.m__OSN25Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN25", DataRowVersion.Original]);
                this.m__OSN05Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN05", DataRowVersion.Original]);
                this.m__PDV10Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV10", DataRowVersion.Original]);
                this.m__PDV22Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV22", DataRowVersion.Original]);
                this.m__PDV23Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV23", DataRowVersion.Original]);
                this.m__PDV25Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV25", DataRowVersion.Original]);
                this.m__PDV05Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV05", DataRowVersion.Original]);
                this.m__IRADATUMOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRADATUM", DataRowVersion.Original]);
                this.m__IRAVALUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRAVALUTA", DataRowVersion.Original]);
                this.m__IRANAPOMENAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRANAPOMENA", DataRowVersion.Original]);
                this.m__IRAUKUPNOOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRAUKUPNO", DataRowVersion.Original]);
                this.m__IDTIPIRAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IDTIPIRA", DataRowVersion.Original]);
                this.m__IRAPARTNERIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRAPARTNERIDPARTNER", DataRowVersion.Original]);
            }
            else
            {
                this.m__NEPODLEZEOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["NEPODLEZE"]);
                this.m__NEPODLEZE_USLUGAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["NEPODLEZE_USLUGA"]);
                this.m__IZVOZOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IZVOZ"]);
                this.m__MEDJTRANSOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["MEDJTRANS"]);
                this.m__TUZEMSTVOOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["TUZEMSTVO"]);
                this.m__OSTALOOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["OSTALO"]);
                this.m__NULAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["NULA"]);
                this.m__OSN10Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN10"]);
                this.m__OSN22Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN22"]);
                this.m__OSN23Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN23"]);
                this.m__OSN25Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN25"]);
                this.m__OSN05Original = RuntimeHelpers.GetObjectValue(this.rowIRA["OSN05"]);
                this.m__PDV10Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV10"]);
                this.m__PDV22Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV22"]);
                this.m__PDV23Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV23"]);
                this.m__PDV25Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV25"]);
                this.m__PDV05Original = RuntimeHelpers.GetObjectValue(this.rowIRA["PDV05"]);
                this.m__IRADATUMOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRADATUM"]);
                this.m__IRAVALUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRAVALUTA"]);
                this.m__IRANAPOMENAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRANAPOMENA"]);
                this.m__IRAUKUPNOOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRAUKUPNO"]);
                this.m__IDTIPIRAOriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IDTIPIRA"]);
                this.m__IRAPARTNERIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowIRA["IRAPARTNERIDPARTNER"]);
            }
            this._Gxremove = this.rowIRA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowIRA = (IRADataSet.IRARow) DataSetUtil.CloneOriginalDataRow(this.rowIRA);
            }
        }

        private void ScanByIDTIPIRA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPIRA] = @IDTIPIRA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString187 + "  FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString187, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ) AS DK_PAGENUM   FROM [IRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString187 + " FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ";
            }
            this.cmIRASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIRASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            this.cmIRASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IDTIPIRA"]));
            this.IRASelect9 = this.cmIRASelect9.FetchData();
            this.RcdFound187 = 0;
            this.ScanLoadIra();
            this.LoadDataIra(maxRows);
        }

        private void ScanByIRADOKIDDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString187 + "  FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString187, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ) AS DK_PAGENUM   FROM [IRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString187 + " FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ";
            }
            this.cmIRASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIRASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmIRASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
            this.IRASelect9 = this.cmIRASelect9.FetchData();
            this.RcdFound187 = 0;
            this.ScanLoadIra();
            this.LoadDataIra(maxRows);
        }

        private void ScanByIRAGODIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IRAGODIDGODINE] = @IRAGODIDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString187 + "  FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString187, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ) AS DK_PAGENUM   FROM [IRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString187 + " FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ";
            }
            this.cmIRASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIRASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
            }
            this.cmIRASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
            this.IRASelect9 = this.cmIRASelect9.FetchData();
            this.RcdFound187 = 0;
            this.ScanLoadIra();
            this.LoadDataIra(maxRows);
        }

        private void ScanByIRAGODIDGODINEIRADOKIDDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IRAGODIDGODINE] = @IRAGODIDGODINE and TM1.[IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString187 + "  FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString187, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ) AS DK_PAGENUM   FROM [IRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString187 + " FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ";
            }
            this.cmIRASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIRASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmIRASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
            this.cmIRASelect9.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
            this.IRASelect9 = this.cmIRASelect9.FetchData();
            this.RcdFound187 = 0;
            this.ScanLoadIra();
            this.LoadDataIra(maxRows);
        }

        private void ScanByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IRAGODIDGODINE] = @IRAGODIDGODINE and TM1.[IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT and TM1.[IRABROJ] = @IRABROJ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString187 + "  FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString187, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ) AS DK_PAGENUM   FROM [IRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString187 + " FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ";
            }
            this.cmIRASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIRASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRABROJ", DbType.Int32));
            }
            this.cmIRASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
            this.cmIRASelect9.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
            this.cmIRASelect9.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowIRA["IRABROJ"]));
            this.IRASelect9 = this.cmIRASelect9.FetchData();
            this.RcdFound187 = 0;
            this.ScanLoadIra();
            this.LoadDataIra(maxRows);
        }

        private void ScanByIRAPARTNERIDPARTNER(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IRAPARTNERIDPARTNER] = @IRAPARTNERIDPARTNER";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString187 + "  FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString187, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ) AS DK_PAGENUM   FROM [IRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString187 + " FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ";
            }
            this.cmIRASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIRASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAPARTNERIDPARTNER", DbType.Int32));
            }
            this.cmIRASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAPARTNERIDPARTNER"]));
            this.IRASelect9 = this.cmIRASelect9.FetchData();
            this.RcdFound187 = 0;
            this.ScanLoadIra();
            this.LoadDataIra(maxRows);
        }

        private void ScanEndIra()
        {
            this.IRASelect9.Close();
        }

        private void ScanLoadIra()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmIRASelect9.HasMoreRows)
            {
                this.RcdFound187 = 1;
                this.rowIRA["IRABROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.IRASelect9, 0));
                this.rowIRA["NEPODLEZE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 1));
                this.rowIRA["NEPODLEZE_USLUGA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 2));
                this.rowIRA["IZVOZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 3));
                this.rowIRA["MEDJTRANS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 4));
                this.rowIRA["TUZEMSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 5));
                this.rowIRA["OSTALO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 6));
                this.rowIRA["NULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 7));
                this.rowIRA["OSN10"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 8));
                this.rowIRA["OSN22"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 9));
                this.rowIRA["OSN23"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 10));
                this.rowIRA["OSN25"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 11));
                this.rowIRA["OSN05"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 12));
                this.rowIRA["PDV10"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 13));
                this.rowIRA["PDV22"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 14));
                this.rowIRA["PDV23"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 15));
                this.rowIRA["PDV25"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 16));
                this.rowIRA["PDV05"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 17));
                this.rowIRA["IRADATUM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.IRASelect9, 18));
                this.rowIRA["IRAVALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.IRASelect9, 19));
                this.rowIRA["IRANAPOMENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.IRASelect9, 20));
                this.rowIRA["IRAUKUPNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.IRASelect9, 21));
                this.rowIRA["IDTIPIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.IRASelect9, 22));
                this.rowIRA["IRAGODIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.IRASelect9, 23));
                this.rowIRA["IRADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.IRASelect9, 24));
                this.rowIRA["IRAPARTNERIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.IRASelect9, 25));
            }
        }

        private void ScanNextIra()
        {
            this.cmIRASelect9.HasMoreRows = this.IRASelect9.Read();
            this.RcdFound187 = 0;
            this.ScanLoadIra();
        }

        private void ScanStartIra(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString187 + "  FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString187, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ) AS DK_PAGENUM   FROM [IRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString187 + " FROM [IRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IRAGODIDGODINE], TM1.[IRADOKIDDOKUMENT], TM1.[IRABROJ] ";
            }
            this.cmIRASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.IRASelect9 = this.cmIRASelect9.FetchData();
            this.RcdFound187 = 0;
            this.ScanLoadIra();
            this.LoadDataIra(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.IRASet = (IRADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.IRASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.IRASet.IRA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        IRADataSet.IRARow current = (IRADataSet.IRARow) enumerator.Current;
                        this.rowIRA = current;
                        if (Helpers.IsRowChanged(this.rowIRA))
                        {
                            this.ReadRowIra();
                            if (this.rowIRA.RowState == DataRowState.Added)
                            {
                                this.InsertIra();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateIra();
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

        private void UpdateIra()
        {
            this.CheckOptimisticConcurrencyIra();
            this.CheckExtendedTableIra();
            this.AfterConfirmIra();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [IRA] SET [NEPODLEZE]=@NEPODLEZE, [NEPODLEZE_USLUGA]=@NEPODLEZE_USLUGA, [IZVOZ]=@IZVOZ, [MEDJTRANS]=@MEDJTRANS, " +
            "[TUZEMSTVO]=@TUZEMSTVO, [OSTALO]=@OSTALO, [NULA]=@NULA, [OSN10]=@OSN10, [OSN22]=@OSN22, [OSN23]=@OSN23, [OSN25]=@OSN25, [PDV10]=@PDV10, " + 
            "[PDV22]=@PDV22, [PDV23]=@PDV23, [PDV25]=@PDV25, [IRADATUM]=@IRADATUM, [IRAVALUTA]=@IRAVALUTA, [IRANAPOMENA]=@IRANAPOMENA, [IRAUKUPNO]=@IRAUKUPNO, " +
            "[IDTIPIRA]=@IDTIPIRA, [IRAPARTNERIDPARTNER]=@IRAPARTNERIDPARTNER, [OSN05]=@OSN05, [PDV05]=@PDV05  WHERE [IRAGODIDGODINE] = @IRAGODIDGODINE AND [IRADOKIDDOKUMENT] = @IRADOKIDDOKUMENT AND [IRABROJ] = @IRABROJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NEPODLEZE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NEPODLEZE_USLUGA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZVOZ", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MEDJTRANS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TUZEMSTVO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSTALO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NULA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN10", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN22", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN23", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN25", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV10", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV22", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV23", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV25", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADATUM", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAVALUTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRANAPOMENA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAUKUPNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAPARTNERIDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRABROJ", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSN05", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV05", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRA["NEPODLEZE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRA["NEPODLEZE_USLUGA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowIRA["IZVOZ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowIRA["MEDJTRANS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowIRA["TUZEMSTVO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowIRA["OSTALO"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowIRA["NULA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN10"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN22"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN23"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN25"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV10"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV22"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV23"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV25"]));
            command.SetParameterDateObject(15, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADATUM"]));
            command.SetParameterDateObject(16, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAVALUTA"]));
            command.SetParameter(17, RuntimeHelpers.GetObjectValue(this.rowIRA["IRANAPOMENA"]));
            command.SetParameter(18, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAUKUPNO"]));
            command.SetParameter(19, RuntimeHelpers.GetObjectValue(this.rowIRA["IDTIPIRA"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAPARTNERIDPARTNER"]));
            command.SetParameter(21, RuntimeHelpers.GetObjectValue(this.rowIRA["IRAGODIDGODINE"]));
            command.SetParameter(22, RuntimeHelpers.GetObjectValue(this.rowIRA["IRADOKIDDOKUMENT"]));
            command.SetParameter(23, RuntimeHelpers.GetObjectValue(this.rowIRA["IRABROJ"]));
            command.SetParameter(24, RuntimeHelpers.GetObjectValue(this.rowIRA["OSN05"]));
            command.SetParameter(25, RuntimeHelpers.GetObjectValue(this.rowIRA["PDV05"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsIra();
            }
            this.OnIRAUpdated(new IRAEventArgs(this.rowIRA, StatementType.Update));
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
        public class IRADataChangedException : DataChangedException
        {
            public IRADataChangedException()
            {
            }

            public IRADataChangedException(string message) : base(message)
            {
            }

            protected IRADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IRADataLockedException : DataLockedException
        {
            public IRADataLockedException()
            {
            }

            public IRADataLockedException(string message) : base(message)
            {
            }

            protected IRADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IRADuplicateKeyException : DuplicateKeyException
        {
            public IRADuplicateKeyException()
            {
            }

            public IRADuplicateKeyException(string message) : base(message)
            {
            }

            protected IRADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class IRAEventArgs : EventArgs
        {
            private IRADataSet.IRARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public IRAEventArgs(IRADataSet.IRARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public IRADataSet.IRARow Row
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
        public class IRANotFoundException : DataNotFoundException
        {
            public IRANotFoundException()
            {
            }

            public IRANotFoundException(string message) : base(message)
            {
            }

            protected IRANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void IRAUpdateEventHandler(object sender, IRADataAdapter.IRAEventArgs e);

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
        public class PogresanDatum : UserException
        {
            public PogresanDatum()
            {
            }

            public PogresanDatum(string message) : base(message)
            {
            }

            protected PogresanDatum(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PogresanDatum(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPIRAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public TIPIRAForeignKeyNotFoundException()
            {
            }

            public TIPIRAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected TIPIRAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIRAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

