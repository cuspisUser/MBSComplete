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

    public class URADataAdapter : IDataAdapter, IURADataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmURASelect1;
        private ReadWriteCommand cmURASelect2;
        private ReadWriteCommand cmURASelect3;
        private ReadWriteCommand cmURASelect4;
        private ReadWriteCommand cmURASelect5;
        private ReadWriteCommand cmURASelect6;
        private ReadWriteCommand cmURASelect9;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDTIPURAOriginal;

        private object m__OSNOVICA0Original;

        private object m__OSNOVICA5Original;
        private object m__OSNOVICA5NEOriginal;

        private object m__OSNOVICA10NEOriginal;
        private object m__OSNOVICA10Original;

        private object m__OSNOVICA22NEOriginal;
        private object m__OSNOVICA22Original;

        private object m__OSNOVICA23NEOriginal;
        private object m__OSNOVICA23Original;

        private object m__OSNOVICA25NEOriginal;
        private object m__OSNOVICA25Original;

        private object m__PDV5DAOriginal;
        private object m__PDV5NEOriginal;

        private object m__PDV10DAOriginal;
        private object m__PDV10NEOriginal;

        private object m__PDV22DAOriginal;
        private object m__PDV22NEOriginal;

        private object m__PDV23DAOriginal;
        private object m__PDV23NEOriginal;

        private object m__PDV25DAOriginal;
        private object m__PDV25NEOriginal;

        #region MBS.Complete 26.04.2016
        private object m__OsnoviaPPOOriginal;
        private object m__MozePPOOriginal;
        private object m__NeMozePPOOriginal;
        #endregion

        private object m__R2Original;
        private object m__URABROJRACUNADOBAVLJACAOriginal;
        private object m__URADATUMOriginal;
        private object m__URAMODELOriginal;
        private object m__URANAPOMENAOriginal;
        private object m__urapartnerIDPARTNEROriginal;
        private object m__URAPOZIVNABROJOriginal;
        private object m__URAUKUPNOOriginal;
        private object m__URAVALUTAOriginal;
        private readonly string m_SelectString200 = "TM1.[URABROJ], TM1.[OSNOVICA25], TM1.[OSNOVICA25NE], TM1.[OSNOVICA23], TM1.[OSNOVICA23NE], TM1.[OSNOVICA22], TM1.[OSNOVICA22NE], TM1.[OSNOVICA10], " + 
                                                    "TM1.[OSNOVICA10NE], TM1.[OSNOVICA5], TM1.[OSNOVICA5NE], TM1.[OSNOVICA0], TM1.[PDV25DA], TM1.[PDV25NE], TM1.[PDV23DA], TM1.[PDV23NE], TM1.[PDV22DA], " + 
                                                    "TM1.[PDV22NE], TM1.[PDV10DA], TM1.[PDV10NE], TM1.[PDV5DA], TM1.[PDV5NE], TM1.[R2], TM1.[URABROJRACUNADOBAVLJACA], TM1.[URADATUM], TM1.[URAVALUTA], " + 
                                                    "TM1.[URANAPOMENA], TM1.[URAMODEL], TM1.[URAPOZIVNABROJ], TM1.[URAUKUPNO], TM1.[IDTIPURA], TM1.[URAGODIDGODINE] AS URAGODIDGODINE, " + 
                                                    "TM1.[URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, TM1.[urapartnerIDPARTNER] AS urapartnerIDPARTNER, TM1.[OsnovicaPPO], TM1.[MozePPO], TM1.[NeMozePPO]";
        private string m_WhereString;
        private short RcdFound200;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private URADataSet.URARow rowURA;
        private string scmdbuf;
        private StatementType sMode200;
        private IDataReader URASelect1;
        private IDataReader URASelect2;
        private IDataReader URASelect3;
        private IDataReader URASelect4;
        private IDataReader URASelect5;
        private IDataReader URASelect6;
        private IDataReader URASelect9;
        private URADataSet URASet;

        public event URAUpdateEventHandler URAUpdated;

        public event URAUpdateEventHandler URAUpdating;

        private void AddRowUra()
        {
            this.URASet.URA.AddURARow(this.rowURA);
        }

        private void AfterConfirmUra()
        {
            this.OnURAUpdating(new URAEventArgs(this.rowURA, this.Gx_mode));
        }

        private void CheckExtendedTableUra()
        {
            if (this.rowURA.URADATUM.Year != mipsed.application.framework.Application.ActiveYear)
            {
                throw new PogresanDatum("Greška u datumu");
            }
        }

        private void CheckIntegrityErrorsUra()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDGODINE] AS URAGODIDGODINE FROM [GODINE] WITH (NOLOCK) WHERE [IDGODINE] = @URAGODIDGODINE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new GODINEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOKUMENT] AS URADOKIDDOKUMENT FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDDOKUMENT] = @URADOKIDDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new DOKUMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOKUMENT") }));
            }
            reader.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [IDPARTNER] AS urapartnerIDPARTNER FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @urapartnerIDPARTNER ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@urapartnerIDPARTNER", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["urapartnerIDPARTNER"]));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new PARTNERForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PARTNER") }));
            }
            reader3.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [IDTIPURA] FROM [TIPURA] WITH (NOLOCK) WHERE [IDTIPURA] = @IDTIPURA ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["IDTIPURA"]));
            IDataReader reader4 = command4.FetchData();
            if (!command4.HasMoreRows)
            {
                reader4.Close();
                throw new TIPURAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPURA") }));
            }
            reader4.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyUra()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [URABROJ], [OSNOVICA25], [OSNOVICA25NE], [OSNOVICA23], [OSNOVICA23NE], [OSNOVICA22], [OSNOVICA22NE], [OSNOVICA10], [OSNOVICA10NE], [OSNOVICA5], [OSNOVICA5NE], [OSNOVICA0], [PDV25DA], " +
                    "[PDV25NE], [PDV23DA], [PDV23NE], [PDV22DA], [PDV22NE], [PDV10DA], [PDV10NE], [PDV5DA], [PDV5NE], [R2], [URABROJRACUNADOBAVLJACA], [URADATUM], " + 
                    "[URAVALUTA], [URANAPOMENA], [URAMODEL], [URAPOZIVNABROJ], [URAUKUPNO], [IDTIPURA], [URAGODIDGODINE] AS URAGODIDGODINE, [URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, [urapartnerIDPARTNER] AS urapartnerIDPARTNER FROM [URA] WITH (UPDLOCK) WHERE [URAGODIDGODINE] = @URAGODIDGODINE AND [URADOKIDDOKUMENT] = @URADOKIDDOKUMENT AND [URABROJ] = @URABROJ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowURA["URABROJ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new URADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("URA") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows ||
                    !this.m__OSNOVICA25Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1))) ||
                    !this.m__OSNOVICA25NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) ||

                    !this.m__OSNOVICA23Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3)))) || 
                    ((!this.m__OSNOVICA23NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4))) || 

                    !this.m__OSNOVICA22Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5)))) || 
                    (!this.m__OSNOVICA22NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6))) || 
                    !this.m__OSNOVICA10Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition ||
                    !this.m__OSNOVICA10NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8)))) ||
                    
                    !this.m__OSNOVICA5Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9))) ||
                    !this.m__OSNOVICA5NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10))) || 

                    !this.m__OSNOVICA0Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11))) || 

                    !this.m__PDV25DAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12))) ||
                    !this.m__PDV25NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13))) ||

                    !this.m__PDV23DAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14))) || 
                    !this.m__PDV23NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 15))) || 
                    !this.m__PDV22DAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 16))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || 
                    !this.m__PDV22NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 17)))) || 
                    ((!this.m__PDV10DAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 18))) || 
                    !this.m__PDV10NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 19)))) ||

                    (!this.m__PDV5DAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 20))) ||
                    !this.m__PDV5NEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 21)))) || 

                    (!this.m__R2Original.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 22))) || 

                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__URABROJRACUNADOBAVLJACAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 23))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || 
                    !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__URADATUMOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 24)))) || 
                    (!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__URAVALUTAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 25))) || 
                    ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__URANAPOMENAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 26))) || 
                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__URAMODELOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 27)))) || 
                    !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__URAPOZIVNABROJOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 28))))))
                {
                    this._Condition = true;
                }                
                if ((this._Condition || 
                    !this.m__URAUKUPNOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 29)))) || 
                    (!this.m__IDTIPURAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 30))) || 
                    !this.m__urapartnerIDPARTNEROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 33)))))
                {
                    reader.Close();
                    throw new URADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("URA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowUra()
        {
            this.rowURA = this.URASet.URA.NewURARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyUra();
            this.AfterConfirmUra();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [URA]  WHERE [URAGODIDGODINE] = @URAGODIDGODINE AND [URADOKIDDOKUMENT] = @URADOKIDDOKUMENT AND [URABROJ] = @URABROJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowURA["URABROJ"]));
            command.ExecuteStmt();
            this.OnURAUpdated(new URAEventArgs(this.rowURA, StatementType.Delete));
            this.rowURA.Delete();
            this.sMode200 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode200;
        }

        public virtual int Fill(URADataSet dataSet)
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
                    this.URASet = dataSet;
                    this.LoadChildUra(0, -1);
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
            this.URASet = (URADataSet) dataSet;
            if (this.URASet != null)
            {
                return this.Fill(this.URASet);
            }
            this.URASet = new URADataSet();
            this.Fill(this.URASet);
            dataSet.Merge(this.URASet);
            return 0;
        }

        public virtual int Fill(URADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["URAGODIDGODINE"]), Conversions.ToInteger(dataRecord["URADOKIDDOKUMENT"]), Conversions.ToInteger(dataRecord["URABROJ"]));
        }

        public virtual int Fill(URADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["URAGODIDGODINE"]), Conversions.ToInteger(dataRecord["URADOKIDDOKUMENT"]), Conversions.ToInteger(dataRecord["URABROJ"]));
        }

        public virtual int Fill(URADataSet dataSet, short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int uRABROJ)
        {
            if (!this.FillByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(dataSet, uRAGODIDGODINE, uRADOKIDDOKUMENT, uRABROJ))
            {
                throw new URANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("URA") }));
            }
            return 0;
        }

        public virtual int FillByIDTIPURA(URADataSet dataSet, int iDTIPURA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.IDTIPURA = iDTIPURA;
            try
            {
                this.LoadByIDTIPURA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByURADOKIDDOKUMENT(URADataSet dataSet, int uRADOKIDDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.URADOKIDDOKUMENT = uRADOKIDDOKUMENT;
            try
            {
                this.LoadByURADOKIDDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByURAGODIDGODINE(URADataSet dataSet, short uRAGODIDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.URAGODIDGODINE = uRAGODIDGODINE;
            try
            {
                this.LoadByURAGODIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByURAGODIDGODINEURADOKIDDOKUMENT(URADataSet dataSet, short uRAGODIDGODINE, int uRADOKIDDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.URAGODIDGODINE = uRAGODIDGODINE;
            this.rowURA.URADOKIDDOKUMENT = uRADOKIDDOKUMENT;
            try
            {
                this.LoadByURAGODIDGODINEURADOKIDDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(URADataSet dataSet, short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int uRABROJ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.URAGODIDGODINE = uRAGODIDGODINE;
            this.rowURA.URADOKIDDOKUMENT = uRADOKIDDOKUMENT;
            this.rowURA.URABROJ = uRABROJ;
            try
            {
                this.LoadByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound200 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByurapartnerIDPARTNER(URADataSet dataSet, int urapartnerIDPARTNER)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.urapartnerIDPARTNER = urapartnerIDPARTNER;
            try
            {
                this.LoadByurapartnerIDPARTNER(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(URADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            try
            {
                this.LoadChildUra(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDTIPURA(URADataSet dataSet, int iDTIPURA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.IDTIPURA = iDTIPURA;
            try
            {
                this.LoadByIDTIPURA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByURADOKIDDOKUMENT(URADataSet dataSet, int uRADOKIDDOKUMENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.URADOKIDDOKUMENT = uRADOKIDDOKUMENT;
            try
            {
                this.LoadByURADOKIDDOKUMENT(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByURAGODIDGODINE(URADataSet dataSet, short uRAGODIDGODINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.URAGODIDGODINE = uRAGODIDGODINE;
            try
            {
                this.LoadByURAGODIDGODINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByURAGODIDGODINEURADOKIDDOKUMENT(URADataSet dataSet, short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.URAGODIDGODINE = uRAGODIDGODINE;
            this.rowURA.URADOKIDDOKUMENT = uRADOKIDDOKUMENT;
            try
            {
                this.LoadByURAGODIDGODINEURADOKIDDOKUMENT(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByurapartnerIDPARTNER(URADataSet dataSet, int urapartnerIDPARTNER, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URASet = dataSet;
            this.rowURA = this.URASet.URA.NewURARow();
            this.rowURA.urapartnerIDPARTNER = urapartnerIDPARTNER;
            try
            {
                this.LoadByurapartnerIDPARTNER(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [URABROJ], " + 
                " [OSNOVICA25], [OSNOVICA25NE], [OSNOVICA23], [OSNOVICA23NE], [OSNOVICA22], [OSNOVICA22NE], [OSNOVICA10], [OSNOVICA10NE], [OSNOVICA5], [OSNOVICA5NE], [OSNOVICA0], [PDV25DA], " +
                "[PDV25NE], [PDV23DA], [PDV23NE], [PDV22DA], [PDV22NE], [PDV10DA], [PDV10NE], [PDV5DA], [PDV5NE], [R2], [URABROJRACUNADOBAVLJACA], [URADATUM], " + 
                "[URAVALUTA], [URANAPOMENA], [URAMODEL], [URAPOZIVNABROJ], [URAUKUPNO], [IDTIPURA], [URAGODIDGODINE] AS URAGODIDGODINE, [URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, " + 
                "[urapartnerIDPARTNER] AS urapartnerIDPARTNER, OsnovicaPPO, MozePPO, NeMozePPO " + 
                "FROM [URA] WITH (NOLOCK) WHERE [URAGODIDGODINE] = @URAGODIDGODINE AND [URADOKIDDOKUMENT] = @URADOKIDDOKUMENT AND [URABROJ] = @URABROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowURA["URABROJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound200 = 1;
                this.rowURA["URABROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));

                this.rowURA["OSNOVICA25"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowURA["OSNOVICA25NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));

                this.rowURA["OSNOVICA23"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 3));
                this.rowURA["OSNOVICA23NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4));

                this.rowURA["OSNOVICA22"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5));
                this.rowURA["OSNOVICA22NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6));
                
                this.rowURA["OSNOVICA10"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7));
                this.rowURA["OSNOVICA10NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8));

                this.rowURA["OSNOVICA5"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 9));
                this.rowURA["OSNOVICA5NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10));

                this.rowURA["OSNOVICA0"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11));

                this.rowURA["PDV25DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12));
                this.rowURA["PDV25NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13));

                this.rowURA["PDV23DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14));
                this.rowURA["PDV23NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 15));

                this.rowURA["PDV22DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 16));
                this.rowURA["PDV22NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 17));

                this.rowURA["PDV10DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 18));
                this.rowURA["PDV10NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 19));

                this.rowURA["PDV5DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 20));
                this.rowURA["PDV5NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 21));

                this.rowURA["R2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 22));
                this.rowURA["URABROJRACUNADOBAVLJACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 23));
                this.rowURA["URADATUM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 24));
                this.rowURA["URAVALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 25));
                this.rowURA["URANAPOMENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 26));
                this.rowURA["URAMODEL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 27));
                this.rowURA["URAPOZIVNABROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 28));
                this.rowURA["URAUKUPNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 29));
                this.rowURA["IDTIPURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 30));
                this.rowURA["URAGODIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 31));
                this.rowURA["URADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 32));
                this.rowURA["urapartnerIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 33));

                #region MBS.Complete 26.04.2016
                this.rowURA["OsnovicaPPO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 34));
                this.rowURA["MozePPO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 35));
                this.rowURA["NeMozePPO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 36));
                #endregion

                this.sMode200 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode200;
            }
            else
            {
                this.RcdFound200 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "URAGODIDGODINE";
                parameter.DbType = DbType.Int16;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "URADOKIDDOKUMENT";
                parameter2.DbType = DbType.Int32;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "URABROJ";
                parameter3.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect6 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [URA] WITH (NOLOCK) ", false);
            this.URASelect6 = this.cmURASelect6.FetchData();
            if (this.URASelect6.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.URASelect6.GetInt32(0);
            }
            this.URASelect6.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDTIPURA(int iDTIPURA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [URA] WITH (NOLOCK) WHERE [IDTIPURA] = @IDTIPURA ", false);
            if (this.cmURASelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            this.cmURASelect3.SetParameter(0, iDTIPURA);
            this.URASelect3 = this.cmURASelect3.FetchData();
            if (this.URASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.URASelect3.GetInt32(0);
            }
            this.URASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByURADOKIDDOKUMENT(int uRADOKIDDOKUMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect5 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [URA] WITH (NOLOCK) WHERE [URADOKIDDOKUMENT] = @URADOKIDDOKUMENT ", false);
            if (this.cmURASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmURASelect5.SetParameter(0, uRADOKIDDOKUMENT);
            this.URASelect5 = this.cmURASelect5.FetchData();
            if (this.URASelect5.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.URASelect5.GetInt32(0);
            }
            this.URASelect5.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByURAGODIDGODINE(short uRAGODIDGODINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [URA] WITH (NOLOCK) WHERE [URAGODIDGODINE] = @URAGODIDGODINE ", false);
            if (this.cmURASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
            }
            this.cmURASelect2.SetParameter(0, uRAGODIDGODINE);
            this.URASelect2 = this.cmURASelect2.FetchData();
            if (this.URASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.URASelect2.GetInt32(0);
            }
            this.URASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByURAGODIDGODINEURADOKIDDOKUMENT(short uRAGODIDGODINE, int uRADOKIDDOKUMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [URA] WITH (NOLOCK) WHERE [URAGODIDGODINE] = @URAGODIDGODINE and [URADOKIDDOKUMENT] = @URADOKIDDOKUMENT ", false);
            if (this.cmURASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                this.cmURASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmURASelect1.SetParameter(0, uRAGODIDGODINE);
            this.cmURASelect1.SetParameter(1, uRADOKIDDOKUMENT);
            this.URASelect1 = this.cmURASelect1.FetchData();
            if (this.URASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.URASelect1.GetInt32(0);
            }
            this.URASelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByurapartnerIDPARTNER(int urapartnerIDPARTNER)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [URA] WITH (NOLOCK) WHERE [urapartnerIDPARTNER] = @urapartnerIDPARTNER ", false);
            if (this.cmURASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@urapartnerIDPARTNER", DbType.Int32));
            }
            this.cmURASelect4.SetParameter(0, urapartnerIDPARTNER);
            this.URASelect4 = this.cmURASelect4.FetchData();
            if (this.URASelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.URASelect4.GetInt32(0);
            }
            this.URASelect4.Close();
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

        public virtual int GetRecordCountByIDTIPURA(int iDTIPURA)
        {
            int internalRecordCountByIDTIPURA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDTIPURA = this.GetInternalRecordCountByIDTIPURA(iDTIPURA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDTIPURA;
        }

        public virtual int GetRecordCountByURADOKIDDOKUMENT(int uRADOKIDDOKUMENT)
        {
            int internalRecordCountByURADOKIDDOKUMENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountByURADOKIDDOKUMENT = this.GetInternalRecordCountByURADOKIDDOKUMENT(uRADOKIDDOKUMENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByURADOKIDDOKUMENT;
        }

        public virtual int GetRecordCountByURAGODIDGODINE(short uRAGODIDGODINE)
        {
            int internalRecordCountByURAGODIDGODINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByURAGODIDGODINE = this.GetInternalRecordCountByURAGODIDGODINE(uRAGODIDGODINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByURAGODIDGODINE;
        }

        public virtual int GetRecordCountByURAGODIDGODINEURADOKIDDOKUMENT(short uRAGODIDGODINE, int uRADOKIDDOKUMENT)
        {
            int internalRecordCountByURAGODIDGODINEURADOKIDDOKUMENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountByURAGODIDGODINEURADOKIDDOKUMENT = this.GetInternalRecordCountByURAGODIDGODINEURADOKIDDOKUMENT(uRAGODIDGODINE, uRADOKIDDOKUMENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByURAGODIDGODINEURADOKIDDOKUMENT;
        }

        public virtual int GetRecordCountByurapartnerIDPARTNER(int urapartnerIDPARTNER)
        {
            int internalRecordCountByurapartnerIDPARTNER;
            try
            {
                this.InitializeMembers();
                internalRecordCountByurapartnerIDPARTNER = this.GetInternalRecordCountByurapartnerIDPARTNER(urapartnerIDPARTNER);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByurapartnerIDPARTNER;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound200 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;

            this.m__OSNOVICA25Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICA25NEOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__OSNOVICA23Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICA23NEOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__OSNOVICA22Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICA22NEOriginal = RuntimeHelpers.GetObjectValue(new object());
            
            this.m__OSNOVICA10Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICA10NEOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__OSNOVICA5Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICA5NEOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__OSNOVICA0Original = RuntimeHelpers.GetObjectValue(new object());

            this.m__PDV25DAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV25NEOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__PDV22DAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV22NEOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__PDV10DAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV10NEOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__PDV5DAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PDV5NEOriginal = RuntimeHelpers.GetObjectValue(new object());

            #region MBS.Complete 26.04.2016
            this.m__OsnoviaPPOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MozePPOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NeMozePPOOriginal = RuntimeHelpers.GetObjectValue(new object());
            #endregion


            this.m__R2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__URABROJRACUNADOBAVLJACAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__URADATUMOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__URAVALUTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__URANAPOMENAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__URAMODELOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__URAPOZIVNABROJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__URAUKUPNOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDTIPURAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__urapartnerIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.URASet = new URADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertUra()
        {
            this.CheckOptimisticConcurrencyUra();
            this.CheckExtendedTableUra();
            this.AfterConfirmUra();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [URA] ([URABROJ], [OSNOVICA25], [OSNOVICA25NE], [OSNOVICA23], [OSNOVICA23NE], [OSNOVICA22], [OSNOVICA22NE], [OSNOVICA10], [OSNOVICA10NE], [OSNOVICA5], [OSNOVICA5NE], [OSNOVICA0], " +
                "[PDV25DA], [PDV25NE], [PDV23DA], [PDV23NE], [PDV22DA], [PDV22NE], [PDV10DA], [PDV10NE], [PDV5DA], [PDV5NE], [R2], [URABROJRACUNADOBAVLJACA], [URADATUM], [URAVALUTA], [URANAPOMENA], [URAMODEL], [URAPOZIVNABROJ], [URAUKUPNO], [IDTIPURA], [URAGODIDGODINE], " + 
                "[URADOKIDDOKUMENT], [urapartnerIDPARTNER], [OsnovicaPPO], [MozePPO], [NeMozePPO]) " +
                "VALUES (@URABROJ, @OSNOVICA25, @OSNOVICA25NE, @OSNOVICA23, @OSNOVICA23NE, @OSNOVICA22, @OSNOVICA22NE, @OSNOVICA10, @OSNOVICA10NE, @OSNOVICA5, @OSNOVICA5NE, @OSNOVICA0, @PDV25DA, " + 
                "@PDV25NE, @PDV23DA, @PDV23NE, @PDV22DA, @PDV22NE, @PDV10DA, @PDV10NE, @PDV5DA, @PDV5NE, @R2, @URABROJRACUNADOBAVLJACA, @URADATUM, @URAVALUTA, @URANAPOMENA, @URAMODEL, @URAPOZIVNABROJ, " + 
                "@URAUKUPNO, @IDTIPURA, @URAGODIDGODINE, @URADOKIDDOKUMENT, @urapartnerIDPARTNER, @OsnovicaPPO, @MozePPO, @NeMozePPO)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJ", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA25", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA25NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA23", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA23NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA22", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA22NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA10", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA10NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA5", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA5NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA0", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV25DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV25NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV23DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV23NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV22DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV22NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV10DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV10NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV5DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV5NE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@R2", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJRACUNADOBAVLJACA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADATUM", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAVALUTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URANAPOMENA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAMODEL", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAPOZIVNABROJ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAUKUPNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@urapartnerIDPARTNER", DbType.Int32));

                #region MBS.Complete 26.04.2016
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OsnovicaPPO", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MozePPO", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NeMozePPO", DbType.Decimal));
                #endregion
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URABROJ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA25"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA25NE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA23"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA23NE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA22"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA22NE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA10"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA10NE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA5"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA5NE"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA0"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowURA["PDV25DA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowURA["PDV25NE"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowURA["PDV23DA"]));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowURA["PDV23NE"]));
            command.SetParameter(16, RuntimeHelpers.GetObjectValue(this.rowURA["PDV22DA"]));
            command.SetParameter(17, RuntimeHelpers.GetObjectValue(this.rowURA["PDV22NE"]));
            command.SetParameter(18, RuntimeHelpers.GetObjectValue(this.rowURA["PDV10DA"]));
            command.SetParameter(19, RuntimeHelpers.GetObjectValue(this.rowURA["PDV10NE"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowURA["PDV5DA"]));
            command.SetParameter(21, RuntimeHelpers.GetObjectValue(this.rowURA["PDV5NE"]));
            command.SetParameter(22, RuntimeHelpers.GetObjectValue(this.rowURA["R2"]));
            command.SetParameter(23, RuntimeHelpers.GetObjectValue(this.rowURA["URABROJRACUNADOBAVLJACA"]));
            command.SetParameterDateObject(24, RuntimeHelpers.GetObjectValue(this.rowURA["URADATUM"]));
            command.SetParameterDateObject(25, RuntimeHelpers.GetObjectValue(this.rowURA["URAVALUTA"]));
            command.SetParameter(26, RuntimeHelpers.GetObjectValue(this.rowURA["URANAPOMENA"]));
            command.SetParameter(27, RuntimeHelpers.GetObjectValue(this.rowURA["URAMODEL"]));
            command.SetParameter(28, RuntimeHelpers.GetObjectValue(this.rowURA["URAPOZIVNABROJ"]));
            command.SetParameter(29, RuntimeHelpers.GetObjectValue(this.rowURA["URAUKUPNO"]));
            command.SetParameter(30, RuntimeHelpers.GetObjectValue(this.rowURA["IDTIPURA"]));
            command.SetParameter(31, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
            command.SetParameter(32, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
            command.SetParameter(33, RuntimeHelpers.GetObjectValue(this.rowURA["urapartnerIDPARTNER"]));

            #region MBS.Complete
            command.SetParameter(34, RuntimeHelpers.GetObjectValue(this.rowURA["OsnovicaPPO"]));
            command.SetParameter(35, RuntimeHelpers.GetObjectValue(this.rowURA["MozePPO"]));
            command.SetParameter(36, RuntimeHelpers.GetObjectValue(this.rowURA["NeMozePPO"]));
            #endregion

            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new URADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsUra();
            }
            this.OnURAUpdated(new URAEventArgs(this.rowURA, StatementType.Insert));
        }

        private void LoadByIDTIPURA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.URASet.EnforceConstraints;
            this.URASet.URA.BeginLoadData();
            this.ScanByIDTIPURA(startRow, maxRows);
            this.URASet.URA.EndLoadData();
            this.URASet.EnforceConstraints = enforceConstraints;
            if (this.URASet.URA.Count > 0)
            {
                this.rowURA = this.URASet.URA[this.URASet.URA.Count - 1];
            }
        }

        private void LoadByURADOKIDDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.URASet.EnforceConstraints;
            this.URASet.URA.BeginLoadData();
            this.ScanByURADOKIDDOKUMENT(startRow, maxRows);
            this.URASet.URA.EndLoadData();
            this.URASet.EnforceConstraints = enforceConstraints;
            if (this.URASet.URA.Count > 0)
            {
                this.rowURA = this.URASet.URA[this.URASet.URA.Count - 1];
            }
        }

        private void LoadByURAGODIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.URASet.EnforceConstraints;
            this.URASet.URA.BeginLoadData();
            this.ScanByURAGODIDGODINE(startRow, maxRows);
            this.URASet.URA.EndLoadData();
            this.URASet.EnforceConstraints = enforceConstraints;
            if (this.URASet.URA.Count > 0)
            {
                this.rowURA = this.URASet.URA[this.URASet.URA.Count - 1];
            }
        }

        private void LoadByURAGODIDGODINEURADOKIDDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.URASet.EnforceConstraints;
            this.URASet.URA.BeginLoadData();
            this.ScanByURAGODIDGODINEURADOKIDDOKUMENT(startRow, maxRows);
            this.URASet.URA.EndLoadData();
            this.URASet.EnforceConstraints = enforceConstraints;
            if (this.URASet.URA.Count > 0)
            {
                this.rowURA = this.URASet.URA[this.URASet.URA.Count - 1];
            }
        }

        private void LoadByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.URASet.EnforceConstraints;
            this.URASet.URA.BeginLoadData();
            this.ScanByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(startRow, maxRows);
            this.URASet.URA.EndLoadData();
            this.URASet.EnforceConstraints = enforceConstraints;
            if (this.URASet.URA.Count > 0)
            {
                this.rowURA = this.URASet.URA[this.URASet.URA.Count - 1];
            }
        }

        private void LoadByurapartnerIDPARTNER(int startRow, int maxRows)
        {
            bool enforceConstraints = this.URASet.EnforceConstraints;
            this.URASet.URA.BeginLoadData();
            this.ScanByurapartnerIDPARTNER(startRow, maxRows);
            this.URASet.URA.EndLoadData();
            this.URASet.EnforceConstraints = enforceConstraints;
            if (this.URASet.URA.Count > 0)
            {
                this.rowURA = this.URASet.URA[this.URASet.URA.Count - 1];
            }
        }

        private void LoadChildUra(int startRow, int maxRows)
        {
            this.CreateNewRowUra();
            bool enforceConstraints = this.URASet.EnforceConstraints;
            this.URASet.URA.BeginLoadData();
            this.ScanStartUra(startRow, maxRows);
            this.URASet.URA.EndLoadData();
            this.URASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataUra(int maxRows)
        {
            int num = 0;
            if (this.RcdFound200 != 0)
            {
                this.ScanLoadUra();
                while ((this.RcdFound200 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowUra();
                    this.CreateNewRowUra();
                    this.ScanNextUra();
                }
            }
            if (num > 0)
            {
                this.RcdFound200 = 1;
            }
            this.ScanEndUra();
            if (this.URASet.URA.Count > 0)
            {
                this.rowURA = this.URASet.URA[this.URASet.URA.Count - 1];
            }
        }

        private void LoadRowUra()
        {
            this.AddRowUra();
        }

        private void OnURAUpdated(URAEventArgs e)
        {
            if (this.URAUpdated != null)
            {
                URAUpdateEventHandler uRAUpdatedEvent = this.URAUpdated;
                if (uRAUpdatedEvent != null)
                {
                    uRAUpdatedEvent(this, e);
                }
            }
        }

        private void OnURAUpdating(URAEventArgs e)
        {
            if (this.URAUpdating != null)
            {
                URAUpdateEventHandler uRAUpdatingEvent = this.URAUpdating;
                if (uRAUpdatingEvent != null)
                {
                    uRAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowUra()
        {
            this.Gx_mode = Mode.FromRowState(this.rowURA.RowState);
            if (this.rowURA.RowState != DataRowState.Deleted)
            {
                this.rowURA["URADATUM"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowURA["URADATUM"])));
                this.rowURA["URAVALUTA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowURA["URAVALUTA"])));
            }
            if (this.rowURA.RowState != DataRowState.Added)
            {
                this.m__OSNOVICA25Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA25", DataRowVersion.Original]);
                this.m__OSNOVICA25NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA25NE", DataRowVersion.Original]);
                
                this.m__OSNOVICA23Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA23", DataRowVersion.Original]);
                this.m__OSNOVICA23NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA23NE", DataRowVersion.Original]);
                
                this.m__OSNOVICA22Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA22", DataRowVersion.Original]);
                this.m__OSNOVICA22NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA22NE", DataRowVersion.Original]);

                this.m__OSNOVICA10Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA10", DataRowVersion.Original]);
                this.m__OSNOVICA10NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA10NE", DataRowVersion.Original]);

                this.m__OSNOVICA5Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA5", DataRowVersion.Original]);
                this.m__OSNOVICA5NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA5NE", DataRowVersion.Original]);

                this.m__OSNOVICA0Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA0", DataRowVersion.Original]);

                this.m__PDV25DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV25DA", DataRowVersion.Original]);
                this.m__PDV25NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV25NE", DataRowVersion.Original]);

                this.m__PDV23DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV23DA", DataRowVersion.Original]);
                this.m__PDV23NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV23NE", DataRowVersion.Original]);
                
                this.m__PDV22DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV22DA", DataRowVersion.Original]);
                this.m__PDV22NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV22NE", DataRowVersion.Original]);
                
                this.m__PDV10DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV10DA", DataRowVersion.Original]);
                this.m__PDV10NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV10NE", DataRowVersion.Original]);

                this.m__PDV5DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV5DA", DataRowVersion.Original]);
                this.m__PDV5NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV5NE", DataRowVersion.Original]);

                this.m__R2Original = RuntimeHelpers.GetObjectValue(this.rowURA["R2", DataRowVersion.Original]);
                this.m__URABROJRACUNADOBAVLJACAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URABROJRACUNADOBAVLJACA", DataRowVersion.Original]);
                this.m__URADATUMOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URADATUM", DataRowVersion.Original]);
                this.m__URAVALUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URAVALUTA", DataRowVersion.Original]);
                this.m__URANAPOMENAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URANAPOMENA", DataRowVersion.Original]);
                this.m__URAMODELOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URAMODEL", DataRowVersion.Original]);
                this.m__URAPOZIVNABROJOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URAPOZIVNABROJ", DataRowVersion.Original]);
                this.m__URAUKUPNOOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URAUKUPNO", DataRowVersion.Original]);
                this.m__IDTIPURAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["IDTIPURA", DataRowVersion.Original]);
                this.m__urapartnerIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowURA["urapartnerIDPARTNER", DataRowVersion.Original]);

                #region MBS.Complete 26.04.2016
                this.m__OsnoviaPPOOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OsnovicaPPO", DataRowVersion.Original]);
                this.m__MozePPOOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["MozePPO", DataRowVersion.Original]);
                this.m__NeMozePPOOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["NeMozePPO", DataRowVersion.Original]);
                #endregion

            }
            else
            {
                this.m__OSNOVICA25Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA25"]);
                this.m__OSNOVICA25NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA25NE"]);

                this.m__OSNOVICA23Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA23"]);
                this.m__OSNOVICA23NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA23NE"]);

                this.m__OSNOVICA22Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA22"]);
                this.m__OSNOVICA22NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA22NE"]);

                this.m__OSNOVICA10Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA10"]);
                this.m__OSNOVICA10NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA10NE"]);

                this.m__OSNOVICA5Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA5"]);
                this.m__OSNOVICA5NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA5NE"]);

                this.m__OSNOVICA0Original = RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA0"]);

                this.m__PDV25DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV25DA"]);
                this.m__PDV25NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV25NE"]);

                this.m__PDV23DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV23DA"]);
                this.m__PDV23NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV23NE"]);

                this.m__PDV22DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV22DA"]);
                this.m__PDV22NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV22NE"]);

                this.m__PDV10DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV10DA"]);
                this.m__PDV10NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV10NE"]);

                this.m__PDV5DAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV5DA"]);
                this.m__PDV5NEOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["PDV5NE"]);

                this.m__R2Original = RuntimeHelpers.GetObjectValue(this.rowURA["R2"]);
                this.m__URABROJRACUNADOBAVLJACAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URABROJRACUNADOBAVLJACA"]);
                this.m__URADATUMOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URADATUM"]);
                this.m__URAVALUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URAVALUTA"]);
                this.m__URANAPOMENAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URANAPOMENA"]);
                this.m__URAMODELOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URAMODEL"]);
                this.m__URAPOZIVNABROJOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URAPOZIVNABROJ"]);
                this.m__URAUKUPNOOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["URAUKUPNO"]);
                this.m__IDTIPURAOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["IDTIPURA"]);
                this.m__urapartnerIDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowURA["urapartnerIDPARTNER"]);

                #region MBS.Complete 26.04.2016
                this.m__OsnoviaPPOOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["OsnovicaPPO"]);
                this.m__MozePPOOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["MozePPO"]);
                this.m__NeMozePPOOriginal = RuntimeHelpers.GetObjectValue(this.rowURA["NeMozePPO"]);
                #endregion

            }
            this._Gxremove = this.rowURA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowURA = (URADataSet.URARow) DataSetUtil.CloneOriginalDataRow(this.rowURA);
            }
        }

        private void ScanByIDTIPURA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPURA] = @IDTIPURA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString200 + "  FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString200, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ) AS DK_PAGENUM   FROM [URA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString200 + " FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ";
            }
            this.cmURASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmURASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            this.cmURASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["IDTIPURA"]));
            this.URASelect9 = this.cmURASelect9.FetchData();
            this.RcdFound200 = 0;
            this.ScanLoadUra();
            this.LoadDataUra(maxRows);
        }

        private void ScanByURADOKIDDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[URADOKIDDOKUMENT] = @URADOKIDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString200 + "  FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString200, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ) AS DK_PAGENUM   FROM [URA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString200 + " FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ";
            }
            this.cmURASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmURASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmURASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
            this.URASelect9 = this.cmURASelect9.FetchData();
            this.RcdFound200 = 0;
            this.ScanLoadUra();
            this.LoadDataUra(maxRows);
        }

        private void ScanByURAGODIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[URAGODIDGODINE] = @URAGODIDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString200 + "  FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString200, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ) AS DK_PAGENUM   FROM [URA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString200 + " FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ";
            }
            this.cmURASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmURASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
            }
            this.cmURASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
            this.URASelect9 = this.cmURASelect9.FetchData();
            this.RcdFound200 = 0;
            this.ScanLoadUra();
            this.LoadDataUra(maxRows);
        }

        private void ScanByURAGODIDGODINEURADOKIDDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[URAGODIDGODINE] = @URAGODIDGODINE and TM1.[URADOKIDDOKUMENT] = @URADOKIDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString200 + "  FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString200, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ) AS DK_PAGENUM   FROM [URA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString200 + " FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ";
            }
            this.cmURASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmURASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmURASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
            this.cmURASelect9.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
            this.URASelect9 = this.cmURASelect9.FetchData();
            this.RcdFound200 = 0;
            this.ScanLoadUra();
            this.LoadDataUra(maxRows);
        }

        private void ScanByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[URAGODIDGODINE] = @URAGODIDGODINE and TM1.[URADOKIDDOKUMENT] = @URADOKIDDOKUMENT and TM1.[URABROJ] = @URABROJ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString200 + "  FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString200, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ) AS DK_PAGENUM   FROM [URA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString200 + " FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ";
            }
            this.cmURASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmURASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJ", DbType.Int32));
            }
            this.cmURASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
            this.cmURASelect9.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
            this.cmURASelect9.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowURA["URABROJ"]));
            this.URASelect9 = this.cmURASelect9.FetchData();
            this.RcdFound200 = 0;
            this.ScanLoadUra();
            this.LoadDataUra(maxRows);
        }

        private void ScanByurapartnerIDPARTNER(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[urapartnerIDPARTNER] = @urapartnerIDPARTNER";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString200 + "  FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString200, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ) AS DK_PAGENUM   FROM [URA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString200 + " FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ";
            }
            this.cmURASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmURASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@urapartnerIDPARTNER", DbType.Int32));
            }
            this.cmURASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["urapartnerIDPARTNER"]));
            this.URASelect9 = this.cmURASelect9.FetchData();
            this.RcdFound200 = 0;
            this.ScanLoadUra();
            this.LoadDataUra(maxRows);
        }

        private void ScanEndUra()
        {
            this.URASelect9.Close();
        }

        private void ScanLoadUra()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmURASelect9.HasMoreRows)
            {
                this.RcdFound200 = 1;
                this.rowURA["URABROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.URASelect9, 0));
                this.rowURA["OSNOVICA25"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 1));
                this.rowURA["OSNOVICA25NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 2));
                this.rowURA["OSNOVICA23"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 3));
                this.rowURA["OSNOVICA23NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 4));
                this.rowURA["OSNOVICA22"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 5));
                this.rowURA["OSNOVICA22NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 6));
                this.rowURA["OSNOVICA10"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 7));
                this.rowURA["OSNOVICA10NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 8));
                this.rowURA["OSNOVICA5"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 9));
                this.rowURA["OSNOVICA5NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 10));
                this.rowURA["OSNOVICA0"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 11));
                this.rowURA["PDV25DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 12));
                this.rowURA["PDV25NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 13));
                this.rowURA["PDV23DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 14));
                this.rowURA["PDV23NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 15));
                this.rowURA["PDV22DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 16));
                this.rowURA["PDV22NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 17));
                this.rowURA["PDV10DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 18));
                this.rowURA["PDV10NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 19));
                this.rowURA["PDV5DA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 20));
                this.rowURA["PDV5NE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 21));
                this.rowURA["R2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.URASelect9, 22));
                this.rowURA["URABROJRACUNADOBAVLJACA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.URASelect9, 23));
                this.rowURA["URADATUM"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.URASelect9, 24));
                this.rowURA["URAVALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.URASelect9, 25));
                this.rowURA["URANAPOMENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.URASelect9, 26));
                this.rowURA["URAMODEL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.URASelect9, 27));
                this.rowURA["URAPOZIVNABROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.URASelect9, 28));
                this.rowURA["URAUKUPNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 29));
                this.rowURA["IDTIPURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.URASelect9, 30));
                this.rowURA["URAGODIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.URASelect9, 31));
                this.rowURA["URADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.URASelect9, 32));
                this.rowURA["urapartnerIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.URASelect9, 33));

                #region MBS.Complete 26.04.2016
                this.rowURA["OsnovicaPPO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 34));
                this.rowURA["MozePPO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 35));
                this.rowURA["NeMozePPO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.URASelect9, 36));
                #endregion
            }
        }

        private void ScanNextUra()
        {
            this.cmURASelect9.HasMoreRows = this.URASelect9.Read();
            this.RcdFound200 = 0;
            this.ScanLoadUra();
        }

        private void ScanStartUra(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString200 + "  FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString200, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ) AS DK_PAGENUM   FROM [URA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString200 + " FROM [URA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ";
            }
            this.cmURASelect9 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.URASelect9 = this.cmURASelect9.FetchData();
            this.RcdFound200 = 0;
            this.ScanLoadUra();
            this.LoadDataUra(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.URASet = (URADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.URASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.URASet.URA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        URADataSet.URARow current = (URADataSet.URARow) enumerator.Current;
                        this.rowURA = current;
                        if (Helpers.IsRowChanged(this.rowURA))
                        {
                            this.ReadRowUra();
                            if (this.rowURA.RowState == DataRowState.Added)
                            {
                                this.InsertUra();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateUra();
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

        private void UpdateUra()
        {
            this.CheckOptimisticConcurrencyUra();
            this.CheckExtendedTableUra();
            this.AfterConfirmUra();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [URA] SET [OSNOVICA25]=@OSNOVICA25, [OSNOVICA25NE]=@OSNOVICA25NE, [OSNOVICA23]=@OSNOVICA23, [OSNOVICA23NE]=@OSNOVICA23NE, [OSNOVICA22]=@OSNOVICA22, " +
                "[OSNOVICA22NE]=@OSNOVICA22NE, [OSNOVICA10]=@OSNOVICA10, [OSNOVICA10NE]=@OSNOVICA10NE, [OSNOVICA5]=@OSNOVICA5, [OSNOVICA5NE]=@OSNOVICA5NE, [OSNOVICA0]=@OSNOVICA0, " +
                "[PDV25DA]=@PDV25DA, [PDV25NE]=@PDV25NE, [PDV23DA]=@PDV23DA, [PDV23NE]=@PDV23NE, [PDV22DA]=@PDV22DA, [PDV22NE]=@PDV22NE, [PDV10DA]=@PDV10DA, [PDV10NE]=@PDV10NE, [PDV5DA]=@PDV5DA, [PDV5NE]=@PDV5NE, [R2]=@R2, " + 
                "[URABROJRACUNADOBAVLJACA]=@URABROJRACUNADOBAVLJACA, [URADATUM]=@URADATUM, [URAVALUTA]=@URAVALUTA, [URANAPOMENA]=@URANAPOMENA, [URAMODEL]=@URAMODEL, [URAPOZIVNABROJ]=@URAPOZIVNABROJ, [URAUKUPNO]=@URAUKUPNO, " + 
                "[IDTIPURA]=@IDTIPURA, [urapartnerIDPARTNER]=@urapartnerIDPARTNER, OsnovicaPPO=@OsnovicaPPO, MozePPO=@MozePPO, NeMozePPO=@NeMozePPO " + 
                "WHERE [URAGODIDGODINE] = @URAGODIDGODINE AND [URADOKIDDOKUMENT] = @URADOKIDDOKUMENT AND [URABROJ] = @URABROJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA25", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA25NE", DbType.Currency));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA23", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA23NE", DbType.Currency));
                
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA22", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA22NE", DbType.Currency));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA10", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA10NE", DbType.Currency));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA5", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA5NE", DbType.Currency));
                
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICA0", DbType.Currency));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV25DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV25NE", DbType.Currency));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV23DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV23NE", DbType.Currency));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV22DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV22NE", DbType.Currency));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV10DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV10NE", DbType.Currency));
                
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV5DA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PDV5NE", DbType.Currency));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@R2", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJRACUNADOBAVLJACA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADATUM", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAVALUTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URANAPOMENA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAMODEL", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAPOZIVNABROJ", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAUKUPNO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@urapartnerIDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJ", DbType.Int32));

                #region MBS.Complete 26.04.2016
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OsnovicaPPO", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MozePPO", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NeMozePPO", DbType.Decimal));
                #endregion
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA25"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA25NE"]));
            
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA23"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA23NE"]));
            
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA22"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA22NE"]));

            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA10"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA10NE"]));

            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA5"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA5NE"]));

            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowURA["OSNOVICA0"]));

            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowURA["PDV25DA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowURA["PDV25NE"]));

            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowURA["PDV23DA"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowURA["PDV23NE"]));
            
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowURA["PDV22DA"]));
            command.SetParameter(16, RuntimeHelpers.GetObjectValue(this.rowURA["PDV22NE"]));

            command.SetParameter(17, RuntimeHelpers.GetObjectValue(this.rowURA["PDV10DA"]));
            command.SetParameter(18, RuntimeHelpers.GetObjectValue(this.rowURA["PDV10NE"]));

            command.SetParameter(19, RuntimeHelpers.GetObjectValue(this.rowURA["PDV5DA"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowURA["PDV5NE"]));
            
            command.SetParameter(21, RuntimeHelpers.GetObjectValue(this.rowURA["R2"]));
            command.SetParameter(22, RuntimeHelpers.GetObjectValue(this.rowURA["URABROJRACUNADOBAVLJACA"]));
            command.SetParameterDateObject(23, RuntimeHelpers.GetObjectValue(this.rowURA["URADATUM"]));
            command.SetParameterDateObject(24, RuntimeHelpers.GetObjectValue(this.rowURA["URAVALUTA"]));
            command.SetParameter(25, RuntimeHelpers.GetObjectValue(this.rowURA["URANAPOMENA"]));
            command.SetParameter(26, RuntimeHelpers.GetObjectValue(this.rowURA["URAMODEL"]));
            command.SetParameter(27, RuntimeHelpers.GetObjectValue(this.rowURA["URAPOZIVNABROJ"]));
            command.SetParameter(28, RuntimeHelpers.GetObjectValue(this.rowURA["URAUKUPNO"]));
            command.SetParameter(29, RuntimeHelpers.GetObjectValue(this.rowURA["IDTIPURA"]));
            command.SetParameter(30, RuntimeHelpers.GetObjectValue(this.rowURA["urapartnerIDPARTNER"]));
            command.SetParameter(31, RuntimeHelpers.GetObjectValue(this.rowURA["URAGODIDGODINE"]));
            command.SetParameter(32, RuntimeHelpers.GetObjectValue(this.rowURA["URADOKIDDOKUMENT"]));
            command.SetParameter(33, RuntimeHelpers.GetObjectValue(this.rowURA["URABROJ"]));

            #region MBS.Complete 26.04.2016
            command.SetParameter(34, RuntimeHelpers.GetObjectValue(this.rowURA["OsnovicaPPO"]));
            command.SetParameter(35, RuntimeHelpers.GetObjectValue(this.rowURA["MozePPO"]));
            command.SetParameter(36, RuntimeHelpers.GetObjectValue(this.rowURA["NeMozePPO"]));
            #endregion

            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsUra();
            }
            this.OnURAUpdated(new URAEventArgs(this.rowURA, StatementType.Update));
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
        public class TIPURAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public TIPURAForeignKeyNotFoundException()
            {
            }

            public TIPURAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected TIPURAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPURAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URADataChangedException : DataChangedException
        {
            public URADataChangedException()
            {
            }

            public URADataChangedException(string message) : base(message)
            {
            }

            protected URADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URADataLockedException : DataLockedException
        {
            public URADataLockedException()
            {
            }

            public URADataLockedException(string message) : base(message)
            {
            }

            protected URADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URADuplicateKeyException : DuplicateKeyException
        {
            public URADuplicateKeyException()
            {
            }

            public URADuplicateKeyException(string message) : base(message)
            {
            }

            protected URADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class URAEventArgs : EventArgs
        {
            private URADataSet.URARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public URAEventArgs(URADataSet.URARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public URADataSet.URARow Row
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
        public class URANotFoundException : DataNotFoundException
        {
            public URANotFoundException()
            {
            }

            public URANotFoundException(string message) : base(message)
            {
            }

            protected URANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void URAUpdateEventHandler(object sender, URADataAdapter.URAEventArgs e);
    }
}

