namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic.CompilerServices;
    using Microsoft.VisualBasic;
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

    public class GKSTAVKADataAdapter : IDataAdapter, IGKSTAVKADataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmGKSTAVKASelect1;
        private ReadWriteCommand cmGKSTAVKASelect10;
        private ReadWriteCommand cmGKSTAVKASelect13;
        private ReadWriteCommand cmGKSTAVKASelect2;
        private ReadWriteCommand cmGKSTAVKASelect3;
        private ReadWriteCommand cmGKSTAVKASelect4;
        private ReadWriteCommand cmGKSTAVKASelect5;
        private ReadWriteCommand cmGKSTAVKASelect6;
        private ReadWriteCommand cmGKSTAVKASelect7;
        private ReadWriteCommand cmGKSTAVKASelect8;
        private ReadWriteCommand cmGKSTAVKASelect9;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private IDataReader GKSTAVKASelect1;
        private IDataReader GKSTAVKASelect10;
        private IDataReader GKSTAVKASelect13;
        private IDataReader GKSTAVKASelect2;
        private IDataReader GKSTAVKASelect3;
        private IDataReader GKSTAVKASelect4;
        private IDataReader GKSTAVKASelect5;
        private IDataReader GKSTAVKASelect6;
        private IDataReader GKSTAVKASelect7;
        private IDataReader GKSTAVKASelect8;
        private IDataReader GKSTAVKASelect9;
        private GKSTAVKADataSet GKSTAVKASet;
        private StatementType Gx_mode;
        private object m__BROJDOKUMENTAOriginal;
        private object m__BROJSTAVKEOriginal;
        private object m__DATUMDOKUMENTAOriginal;
        private object m__DATUMPRIJAVEOriginal;
        private object m__dugujeOriginal;
        private object m__GKDATUMVALUTEOriginal;
        private object m__GKGODIDGODINEOriginal;
        private object m__IDDOKUMENTOriginal;
        private object m__IDKONTOOriginal;
        private object m__IDMJESTOTROSKAOriginal;
        private object m__IDORGJEDOriginal;
        private object m__IDPARTNEROriginal;
        private object m__OPISOriginal;
        private object m__ORIGINALNIDOKUMENTOriginal;
        private object m__POTRAZUJEOriginal;
        private object m__statusgkOriginal;
        private object m__ZATVORENIIZNOSOriginal;
        private readonly string m_SelectString185 = "TM1.[IDGKSTAVKA], TM1.[DATUMPRIJAVE], TM1.[DATUMDOKUMENTA], TM1.[BROJDOKUMENTA], TM1.[BROJSTAVKE], T2.[NAZIVDOKUMENT], T3.[NAZIVMJESTOTROSKA], T4.[NAZIVORGJED], T5.[NAZIVKONTO], T6.[NAZIVAKTIVNOST], TM1.[OPIS], TM1.[duguje], TM1.[POTRAZUJE], T7.[NAZIVPARTNER], TM1.[ZATVORENIIZNOS], TM1.[GKDATUMVALUTE], TM1.[statusgk], TM1.[ORIGINALNIDOKUMENT], TM1.[IDDOKUMENT], TM1.[IDMJESTOTROSKA], TM1.[IDORGJED], TM1.[IDKONTO], T5.[IDAKTIVNOST], TM1.[IDPARTNER], TM1.[GKGODIDGODINE] AS GKGODIDGODINE";
        private string m_WhereString;
        private short RcdFound185;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private GKSTAVKADataSet.GKSTAVKARow rowGKSTAVKA;
        private string scmdbuf;
        private StatementType sMode185;

        public event GKSTAVKAUpdateEventHandler GKSTAVKAUpdated;

        public event GKSTAVKAUpdateEventHandler GKSTAVKAUpdating;

        private void AddRowGkstavka()
        {
            this.GKSTAVKASet.GKSTAVKA.AddGKSTAVKARow(this.rowGKSTAVKA);
        }

        private void AfterConfirmGkstavka()
        {
            this.OnGKSTAVKAUpdating(new GKSTAVKAEventArgs(this.rowGKSTAVKA, this.Gx_mode));
        }

        private void CheckDeleteErrorsGkstavka()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [GK1IDGKSTAVKA], [GK2IDGKSTAVKA] FROM [ZATVARANJA] WITH (NOLOCK) WHERE [GK2IDGKSTAVKA] = @IDGKSTAVKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGKSTAVKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDGKSTAVKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new ZATVARANJAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ZATVARANJA" }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [GK1IDGKSTAVKA], [GK2IDGKSTAVKA] FROM [ZATVARANJA] WITH (NOLOCK) WHERE [GK1IDGKSTAVKA] = @IDGKSTAVKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGKSTAVKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDGKSTAVKA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new ZATVARANJAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ZATVARANJA" }));
            }
            reader2.Close();
        }

        private void CheckExtendedTableGkstavka()
        {
            if (this.rowGKSTAVKA.DATUMDOKUMENTA.Year != mipsed.application.framework.Application.ActiveYear)
            {
                throw new PogresanDatum("Greška u datumu");
            }
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVDOKUMENT] FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDDOKUMENT] = @IDDOKUMENT ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new DOKUMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOKUMENT") }));
            }
            this.rowGKSTAVKA["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0))));
            reader2.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVMJESTOTROSKA] FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA"]));
            IDataReader reader4 = command4.FetchData();
            if (!command4.HasMoreRows)
            {
                reader4.Close();
                throw new MJESTOTROSKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            this.rowGKSTAVKA["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0))));
            reader4.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [NAZIVORGJED] FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @IDORGJED ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED"]));
            IDataReader reader5 = command5.FetchData();
            if (!command5.HasMoreRows)
            {
                reader5.Close();
                throw new ORGJEDForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
            }
            this.rowGKSTAVKA["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0))));
            reader5.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVKONTO], [IDAKTIVNOST] FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @IDKONTO ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO"]))));
            IDataReader reader3 = command3.FetchData();
            if (!command3.HasMoreRows)
            {
                reader3.Close();
                throw new KONTOForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            this.rowGKSTAVKA["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0))));
            this.rowGKSTAVKA["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader3, 1));
            reader3.Close();
            if (!this.rowGKSTAVKA.IsIDAKTIVNOSTNull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVAKTIVNOST] FROM [AKTIVNOST] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDAKTIVNOST"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new AKTIVNOSTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("AKTIVNOST") }));
                }
                this.rowGKSTAVKA["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
                reader.Close();
            }
            else
            {
                this.rowGKSTAVKA["NAZIVAKTIVNOST"] = "";
            }
            if (this.rowGKSTAVKA.IDKONTO.Length < Application.Analitika())
            {
                Interaction.MsgBox("Knjiženje na sintetiku nije dozvoljeno!", MsgBoxStyle.OkOnly, null);
            }
            if ((!this.rowGKSTAVKA.IsdugujeNull() && !this.rowGKSTAVKA.IsPOTRAZUJENull()) && ((decimal.Compare(this.rowGKSTAVKA.duguje, Convert.ToDecimal(0)) > 0) && (decimal.Compare(this.rowGKSTAVKA.POTRAZUJE, Convert.ToDecimal(0)) > 0)))
            {
                Interaction.MsgBox("Istovremeno knjiženje na dugovnu i potražnu stranu nije dozvoljeno!", MsgBoxStyle.OkOnly, null);
            }
            if (!this.rowGKSTAVKA.IsIDPARTNERNull())
            {
                ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT [NAZIVPARTNER] FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
                if (command6.IDbCommand.Parameters.Count == 0)
                {
                    command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                }
                command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER"]));
                IDataReader reader6 = command6.FetchData();
                if (!command6.HasMoreRows && (0 != this.rowGKSTAVKA.IDPARTNER))
                {
                    reader6.Close();
                    throw new PARTNERForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PARTNER") }));
                }
                this.rowGKSTAVKA["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0))));
                reader6.Close();
            }
            else
            {
                this.rowGKSTAVKA["NAZIVPARTNER"] = "";
            }
        }

        private void CheckIntegrityErrorsGkstavka()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGODINE] AS GKGODIDGODINE FROM [GODINE] WITH (NOLOCK) WHERE [IDGODINE] = @GKGODIDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKGODIDGODINE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new GODINEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyGkstavka()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGKSTAVKA], [DATUMPRIJAVE], [DATUMDOKUMENTA], [BROJDOKUMENTA], [BROJSTAVKE], [OPIS], [duguje], [POTRAZUJE], [ZATVORENIIZNOS], [GKDATUMVALUTE], [statusgk], [ORIGINALNIDOKUMENT], [IDDOKUMENT], [IDMJESTOTROSKA], [IDORGJED], [IDKONTO], [IDPARTNER], [GKGODIDGODINE] AS GKGODIDGODINE FROM [GKSTAVKA] WITH (UPDLOCK) WHERE [IDGKSTAVKA] = @IDGKSTAVKA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGKSTAVKA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDGKSTAVKA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new GKSTAVKADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("GKSTAVKA") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMPRIJAVEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 1)))) || ((!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMDOKUMENTAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2))) || !this.m__BROJDOKUMENTAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))) || (!this.m__BROJSTAVKEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__dugujeOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6)))) || ((!this.m__POTRAZUJEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7))) || !this.m__ZATVORENIIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8)))) || (!DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__GKDATUMVALUTEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 9))) || !this.m__statusgkOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ORIGINALNIDOKUMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || (!this.m__IDDOKUMENTOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 12))) || ((!this.m__IDMJESTOTROSKAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 13))) || !this.m__IDORGJEDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 14)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IDKONTOOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15))))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__IDPARTNEROriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x10)))) || !this.m__GKGODIDGODINEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0x11))))
                {
                    reader.Close();
                    throw new GKSTAVKADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("GKSTAVKA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowGkstavka()
        {
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyGkstavka();
            this.OnDeleteControlsGkstavka();
            this.AfterConfirmGkstavka();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [GKSTAVKA]  WHERE [IDGKSTAVKA] = @IDGKSTAVKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGKSTAVKA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDGKSTAVKA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsGkstavka();
            }
            this.OnGKSTAVKAUpdated(new GKSTAVKAEventArgs(this.rowGKSTAVKA, StatementType.Delete));
            this.rowGKSTAVKA.Delete();
            this.sMode185 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode185;
        }

        public virtual int Fill(GKSTAVKADataSet dataSet)
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
                    this.GKSTAVKASet = dataSet;
                    this.LoadChildGkstavka(0, -1);
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
            this.GKSTAVKASet = (GKSTAVKADataSet) dataSet;
            if (this.GKSTAVKASet != null)
            {
                return this.Fill(this.GKSTAVKASet);
            }
            this.GKSTAVKASet = new GKSTAVKADataSet();
            this.Fill(this.GKSTAVKASet);
            dataSet.Merge(this.GKSTAVKASet);
            return 0;
        }

        public virtual int Fill(GKSTAVKADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDGKSTAVKA"]));
        }

        public virtual int Fill(GKSTAVKADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDGKSTAVKA"]));
        }

        public virtual int Fill(GKSTAVKADataSet dataSet, int iDGKSTAVKA)
        {
            if (!this.FillByIDGKSTAVKA(dataSet, iDGKSTAVKA))
            {
                throw new GKSTAVKANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GKSTAVKA") }));
            }
            return 0;
        }

        public virtual int FillByBROJSTAVKE(GKSTAVKADataSet dataSet, int bROJSTAVKE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.BROJSTAVKE = bROJSTAVKE;
            try
            {
                this.LoadByBROJSTAVKE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByGKGODIDGODINE(GKSTAVKADataSet dataSet, short gKGODIDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.GKGODIDGODINE = gKGODIDGODINE;
            try
            {
                this.LoadByGKGODIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDDOKUMENT(GKSTAVKADataSet dataSet, int iDDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDDOKUMENT = iDDOKUMENT;
            try
            {
                this.LoadByIDDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDDOKUMENTBROJDOKUMENTA(GKSTAVKADataSet dataSet, int iDDOKUMENT, int bROJDOKUMENTA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDDOKUMENT = iDDOKUMENT;
            this.rowGKSTAVKA.BROJDOKUMENTA = bROJDOKUMENTA;
            try
            {
                this.LoadByIDDOKUMENTBROJDOKUMENTA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(GKSTAVKADataSet dataSet, int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDDOKUMENT = iDDOKUMENT;
            this.rowGKSTAVKA.BROJDOKUMENTA = bROJDOKUMENTA;
            this.rowGKSTAVKA.GKGODIDGODINE = gKGODIDGODINE;
            try
            {
                this.LoadByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDGKSTAVKA(GKSTAVKADataSet dataSet, int iDGKSTAVKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDGKSTAVKA = iDGKSTAVKA;
            try
            {
                this.LoadByIDGKSTAVKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound185 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDKONTO(GKSTAVKADataSet dataSet, string iDKONTO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDKONTO = iDKONTO;
            try
            {
                this.LoadByIDKONTO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDMJESTOTROSKA(GKSTAVKADataSet dataSet, int iDMJESTOTROSKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDMJESTOTROSKA = iDMJESTOTROSKA;
            try
            {
                this.LoadByIDMJESTOTROSKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDORGJED(GKSTAVKADataSet dataSet, int iDORGJED)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDORGJED = iDORGJED;
            try
            {
                this.LoadByIDORGJED(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDPARTNER(GKSTAVKADataSet dataSet, int iDPARTNER)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDPARTNER = iDPARTNER;
            try
            {
                this.LoadByIDPARTNER(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(GKSTAVKADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            try
            {
                this.LoadChildGkstavka(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByBROJSTAVKE(GKSTAVKADataSet dataSet, int bROJSTAVKE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.BROJSTAVKE = bROJSTAVKE;
            try
            {
                this.LoadByBROJSTAVKE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByGKGODIDGODINE(GKSTAVKADataSet dataSet, short gKGODIDGODINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.GKGODIDGODINE = gKGODIDGODINE;
            try
            {
                this.LoadByGKGODIDGODINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDDOKUMENT(GKSTAVKADataSet dataSet, int iDDOKUMENT, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDDOKUMENT = iDDOKUMENT;
            try
            {
                this.LoadByIDDOKUMENT(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDDOKUMENTBROJDOKUMENTA(GKSTAVKADataSet dataSet, int iDDOKUMENT, int bROJDOKUMENTA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDDOKUMENT = iDDOKUMENT;
            this.rowGKSTAVKA.BROJDOKUMENTA = bROJDOKUMENTA;
            try
            {
                this.LoadByIDDOKUMENTBROJDOKUMENTA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(GKSTAVKADataSet dataSet, int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDDOKUMENT = iDDOKUMENT;
            this.rowGKSTAVKA.BROJDOKUMENTA = bROJDOKUMENTA;
            this.rowGKSTAVKA.GKGODIDGODINE = gKGODIDGODINE;
            try
            {
                this.LoadByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDKONTO(GKSTAVKADataSet dataSet, string iDKONTO, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDKONTO = iDKONTO;
            try
            {
                this.LoadByIDKONTO(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDMJESTOTROSKA(GKSTAVKADataSet dataSet, int iDMJESTOTROSKA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDMJESTOTROSKA = iDMJESTOTROSKA;
            try
            {
                this.LoadByIDMJESTOTROSKA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDORGJED(GKSTAVKADataSet dataSet, int iDORGJED, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDORGJED = iDORGJED;
            try
            {
                this.LoadByIDORGJED(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDPARTNER(GKSTAVKADataSet dataSet, int iDPARTNER, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GKSTAVKASet = dataSet;
            this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA.NewGKSTAVKARow();
            this.rowGKSTAVKA.IDPARTNER = iDPARTNER;
            try
            {
                this.LoadByIDPARTNER(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGKSTAVKA], [DATUMPRIJAVE], [DATUMDOKUMENTA], [BROJDOKUMENTA], [BROJSTAVKE], [OPIS], [duguje], [POTRAZUJE], [ZATVORENIIZNOS], [GKDATUMVALUTE], [statusgk], [ORIGINALNIDOKUMENT], [IDDOKUMENT], [IDMJESTOTROSKA], [IDORGJED], [IDKONTO], [IDPARTNER], [GKGODIDGODINE] AS GKGODIDGODINE FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDGKSTAVKA] = @IDGKSTAVKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGKSTAVKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDGKSTAVKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound185 = 1;
                this.rowGKSTAVKA["IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowGKSTAVKA["DATUMPRIJAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 1));
                this.rowGKSTAVKA["DATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 2));
                this.rowGKSTAVKA["BROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
                this.rowGKSTAVKA["BROJSTAVKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4));
                this.rowGKSTAVKA["OPIS"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))));
                this.rowGKSTAVKA["duguje"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6));
                this.rowGKSTAVKA["POTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7));
                this.rowGKSTAVKA["ZATVORENIIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 8));
                this.rowGKSTAVKA["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 9));
                this.rowGKSTAVKA["statusgk"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 10));
                this.rowGKSTAVKA["ORIGINALNIDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowGKSTAVKA["IDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 12));
                this.rowGKSTAVKA["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 13));
                this.rowGKSTAVKA["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 14));
                this.rowGKSTAVKA["IDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15))));
                this.rowGKSTAVKA["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0x10));
                this.rowGKSTAVKA["GKGODIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0x11));
                this.sMode185 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadGkstavka();
                this.Gx_mode = this.sMode185;
            }
            else
            {
                this.RcdFound185 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDGKSTAVKA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect10 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) ", false);
            this.GKSTAVKASelect10 = this.cmGKSTAVKASelect10.FetchData();
            if (this.GKSTAVKASelect10.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect10.GetInt32(0);
            }
            this.GKSTAVKASelect10.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByBROJSTAVKE(int bROJSTAVKE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [BROJSTAVKE] = @BROJSTAVKE ", false);
            if (this.cmGKSTAVKASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
            }
            this.cmGKSTAVKASelect4.SetParameter(0, bROJSTAVKE);
            this.GKSTAVKASelect4 = this.cmGKSTAVKASelect4.FetchData();
            if (this.GKSTAVKASelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect4.GetInt32(0);
            }
            this.GKSTAVKASelect4.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByGKGODIDGODINE(short gKGODIDGODINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect8 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [GKGODIDGODINE] = @GKGODIDGODINE ", false);
            if (this.cmGKSTAVKASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            this.cmGKSTAVKASelect8.SetParameter(0, gKGODIDGODINE);
            this.GKSTAVKASelect8 = this.cmGKSTAVKASelect8.FetchData();
            if (this.GKSTAVKASelect8.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect8.GetInt32(0);
            }
            this.GKSTAVKASelect8.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDDOKUMENT(int iDDOKUMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect7 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDDOKUMENT] = @IDDOKUMENT ", false);
            if (this.cmGKSTAVKASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmGKSTAVKASelect7.SetParameter(0, iDDOKUMENT);
            this.GKSTAVKASelect7 = this.cmGKSTAVKASelect7.FetchData();
            if (this.GKSTAVKASelect7.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect7.GetInt32(0);
            }
            this.GKSTAVKASelect7.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDDOKUMENTBROJDOKUMENTA(int iDDOKUMENT, int bROJDOKUMENTA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect6 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [BROJDOKUMENTA] = @BROJDOKUMENTA and [IDDOKUMENT] = @IDDOKUMENT ", false);
            if (this.cmGKSTAVKASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                this.cmGKSTAVKASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmGKSTAVKASelect6.SetParameter(0, bROJDOKUMENTA);
            this.cmGKSTAVKASelect6.SetParameter(1, iDDOKUMENT);
            this.GKSTAVKASelect6 = this.cmGKSTAVKASelect6.FetchData();
            if (this.GKSTAVKASelect6.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect6.GetInt32(0);
            }
            this.GKSTAVKASelect6.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect5 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [BROJDOKUMENTA] = @BROJDOKUMENTA and [IDDOKUMENT] = @IDDOKUMENT and [GKGODIDGODINE] = @GKGODIDGODINE ", false);
            if (this.cmGKSTAVKASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                this.cmGKSTAVKASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                this.cmGKSTAVKASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            this.cmGKSTAVKASelect5.SetParameter(0, bROJDOKUMENTA);
            this.cmGKSTAVKASelect5.SetParameter(1, iDDOKUMENT);
            this.cmGKSTAVKASelect5.SetParameter(2, gKGODIDGODINE);
            this.GKSTAVKASelect5 = this.cmGKSTAVKASelect5.FetchData();
            if (this.GKSTAVKASelect5.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect5.GetInt32(0);
            }
            this.GKSTAVKASelect5.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDKONTO(string iDKONTO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect9 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDKONTO] = @IDKONTO ", false);
            if (this.cmGKSTAVKASelect9.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            this.cmGKSTAVKASelect9.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(iDKONTO)));
            this.GKSTAVKASelect9 = this.cmGKSTAVKASelect9.FetchData();
            if (this.GKSTAVKASelect9.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect9.GetInt32(0);
            }
            this.GKSTAVKASelect9.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDMJESTOTROSKA(int iDMJESTOTROSKA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (this.cmGKSTAVKASelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            this.cmGKSTAVKASelect3.SetParameter(0, iDMJESTOTROSKA);
            this.GKSTAVKASelect3 = this.cmGKSTAVKASelect3.FetchData();
            if (this.GKSTAVKASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect3.GetInt32(0);
            }
            this.GKSTAVKASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDORGJED(int iDORGJED)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDORGJED] = @IDORGJED ", false);
            if (this.cmGKSTAVKASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            this.cmGKSTAVKASelect2.SetParameter(0, iDORGJED);
            this.GKSTAVKASelect2 = this.cmGKSTAVKASelect2.FetchData();
            if (this.GKSTAVKASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect2.GetInt32(0);
            }
            this.GKSTAVKASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDPARTNER(int iDPARTNER)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGKSTAVKASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
            if (this.cmGKSTAVKASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmGKSTAVKASelect1.SetParameter(0, iDPARTNER);
            this.GKSTAVKASelect1 = this.cmGKSTAVKASelect1.FetchData();
            if (this.GKSTAVKASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GKSTAVKASelect1.GetInt32(0);
            }
            this.GKSTAVKASelect1.Close();
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

        public virtual int GetRecordCountByBROJSTAVKE(int bROJSTAVKE)
        {
            int internalRecordCountByBROJSTAVKE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByBROJSTAVKE = this.GetInternalRecordCountByBROJSTAVKE(bROJSTAVKE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByBROJSTAVKE;
        }

        public virtual int GetRecordCountByGKGODIDGODINE(short gKGODIDGODINE)
        {
            int internalRecordCountByGKGODIDGODINE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByGKGODIDGODINE = this.GetInternalRecordCountByGKGODIDGODINE(gKGODIDGODINE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByGKGODIDGODINE;
        }

        public virtual int GetRecordCountByIDDOKUMENT(int iDDOKUMENT)
        {
            int internalRecordCountByIDDOKUMENT;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDDOKUMENT = this.GetInternalRecordCountByIDDOKUMENT(iDDOKUMENT);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDDOKUMENT;
        }

        public virtual int GetRecordCountByIDDOKUMENTBROJDOKUMENTA(int iDDOKUMENT, int bROJDOKUMENTA)
        {
            int internalRecordCountByIDDOKUMENTBROJDOKUMENTA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDDOKUMENTBROJDOKUMENTA = this.GetInternalRecordCountByIDDOKUMENTBROJDOKUMENTA(iDDOKUMENT, bROJDOKUMENTA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDDOKUMENTBROJDOKUMENTA;
        }

        public virtual int GetRecordCountByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE)
        {
            int num2 = 0;
            try
            {
                this.InitializeMembers();
                num2 = this.GetInternalRecordCountByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(iDDOKUMENT, bROJDOKUMENTA, gKGODIDGODINE);
            }
            finally
            {
                this.Cleanup();
            }
            return num2;
        }

        public virtual int GetRecordCountByIDKONTO(string iDKONTO)
        {
            int internalRecordCountByIDKONTO;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDKONTO = this.GetInternalRecordCountByIDKONTO(iDKONTO);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDKONTO;
        }

        public virtual int GetRecordCountByIDMJESTOTROSKA(int iDMJESTOTROSKA)
        {
            int internalRecordCountByIDMJESTOTROSKA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDMJESTOTROSKA = this.GetInternalRecordCountByIDMJESTOTROSKA(iDMJESTOTROSKA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDMJESTOTROSKA;
        }

        public virtual int GetRecordCountByIDORGJED(int iDORGJED)
        {
            int internalRecordCountByIDORGJED;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDORGJED = this.GetInternalRecordCountByIDORGJED(iDORGJED);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDORGJED;
        }

        public virtual int GetRecordCountByIDPARTNER(int iDPARTNER)
        {
            int internalRecordCountByIDPARTNER;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDPARTNER = this.GetInternalRecordCountByIDPARTNER(iDPARTNER);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDPARTNER;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound185 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__DATUMPRIJAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJSTAVKEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__dugujeOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POTRAZUJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZATVORENIIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__GKDATUMVALUTEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__statusgkOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ORIGINALNIDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDORGJEDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDKONTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDPARTNEROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__GKGODIDGODINEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.GKSTAVKASet = new GKSTAVKADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertGkstavka()
        {
            this.CheckOptimisticConcurrencyGkstavka();
            this.CheckExtendedTableGkstavka();
            this.AfterConfirmGkstavka();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [GKSTAVKA] ([DATUMPRIJAVE], [DATUMDOKUMENTA], [BROJDOKUMENTA], [BROJSTAVKE], [OPIS], [duguje], [POTRAZUJE], [ZATVORENIIZNOS], [GKDATUMVALUTE], [statusgk], [ORIGINALNIDOKUMENT], [IDDOKUMENT], [IDMJESTOTROSKA], [IDORGJED], [IDKONTO], [IDPARTNER], [GKGODIDGODINE]) VALUES (@DATUMPRIJAVE, @DATUMDOKUMENTA, @BROJDOKUMENTA, @BROJSTAVKE, @OPIS, @duguje, @POTRAZUJE, @ZATVORENIIZNOS, @GKDATUMVALUTE, @statusgk, @ORIGINALNIDOKUMENT, @IDDOKUMENT, @IDMJESTOTROSKA, @IDORGJED, @IDKONTO, @IDPARTNER, @GKGODIDGODINE); SELECT SCOPE_IDENTITY()", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMPRIJAVE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMDOKUMENTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPIS", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@duguje", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTRAZUJE", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZATVORENIIZNOS", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKDATUMVALUTE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@statusgk", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORIGINALNIDOKUMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameterDateObject(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMPRIJAVE"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMDOKUMENTA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJDOKUMENTA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJSTAVKE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["OPIS"]))));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["duguje"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["POTRAZUJE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ZATVORENIIZNOS"]));
            command.SetParameterDateObject(8, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKDATUMVALUTE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["statusgk"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ORIGINALNIDOKUMENT"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO"]))));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKGODIDGODINE"]));
            IDataReader reader = command.FetchData();
            if (!command.ForeignKeyError && !command.DupKey)
            {
                this.rowGKSTAVKA.IDGKSTAVKA = Convert.ToInt32(reader.GetDecimal(0));
                reader.Close();
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsGkstavka();
            }
            this.OnGKSTAVKAUpdated(new GKSTAVKAEventArgs(this.rowGKSTAVKA, StatementType.Insert));
        }

        private void InsertGkstavkaShema()
        {
            //this.CheckOptimisticConcurrencyGkstavka();
            //this.CheckExtendedTableGkstavka();
            this.AfterConfirmGkstavka();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [GKSTAVKA] ([DATUMPRIJAVE], [DATUMDOKUMENTA], [BROJDOKUMENTA], [BROJSTAVKE], [OPIS], [duguje], [POTRAZUJE], [ZATVORENIIZNOS], [GKDATUMVALUTE], [statusgk], [ORIGINALNIDOKUMENT], [IDDOKUMENT], [IDMJESTOTROSKA], [IDORGJED], [IDKONTO], [IDPARTNER], [GKGODIDGODINE]) VALUES (@DATUMPRIJAVE, @DATUMDOKUMENTA, @BROJDOKUMENTA, @BROJSTAVKE, @OPIS, @duguje, @POTRAZUJE, @ZATVORENIIZNOS, @GKDATUMVALUTE, @statusgk, @ORIGINALNIDOKUMENT, @IDDOKUMENT, @IDMJESTOTROSKA, @IDORGJED, @IDKONTO, @IDPARTNER, @GKGODIDGODINE); SELECT SCOPE_IDENTITY()", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMPRIJAVE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMDOKUMENTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPIS", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@duguje", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTRAZUJE", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZATVORENIIZNOS", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKDATUMVALUTE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@statusgk", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORIGINALNIDOKUMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameterDateObject(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMPRIJAVE"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMDOKUMENTA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJDOKUMENTA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJSTAVKE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["OPIS"]))));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["duguje"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["POTRAZUJE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ZATVORENIIZNOS"]));
            command.SetParameterDateObject(8, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKDATUMVALUTE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["statusgk"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ORIGINALNIDOKUMENT"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO"]))));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKGODIDGODINE"]));
            IDataReader reader = command.FetchData();
            if (!command.ForeignKeyError && !command.DupKey)
            {
                this.rowGKSTAVKA.IDGKSTAVKA = Convert.ToInt32(reader.GetDecimal(0));
                reader.Close();
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsGkstavka();
            }
            this.OnGKSTAVKAUpdated(new GKSTAVKAEventArgs(this.rowGKSTAVKA, StatementType.Insert));
        }


        private void LoadByBROJSTAVKE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByBROJSTAVKE(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByGKGODIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByGKGODIDGODINE(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByIDDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByIDDOKUMENT(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByIDDOKUMENTBROJDOKUMENTA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByIDDOKUMENTBROJDOKUMENTA(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByIDGKSTAVKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByIDGKSTAVKA(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByIDKONTO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByIDKONTO(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByIDMJESTOTROSKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByIDMJESTOTROSKA(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByIDORGJED(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByIDORGJED(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadByIDPARTNER(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanByIDPARTNER(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadChildGkstavka(int startRow, int maxRows)
        {
            this.CreateNewRowGkstavka();
            bool enforceConstraints = this.GKSTAVKASet.EnforceConstraints;
            this.GKSTAVKASet.GKSTAVKA.BeginLoadData();
            this.ScanStartGkstavka(startRow, maxRows);
            this.GKSTAVKASet.GKSTAVKA.EndLoadData();
            this.GKSTAVKASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataGkstavka(int maxRows)
        {
            int num = 0;
            if (this.RcdFound185 != 0)
            {
                this.ScanLoadGkstavka();
                while ((this.RcdFound185 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowGkstavka();
                    this.CreateNewRowGkstavka();
                    this.ScanNextGkstavka();
                }
            }
            if (num > 0)
            {
                this.RcdFound185 = 1;
            }
            this.ScanEndGkstavka();
            if (this.GKSTAVKASet.GKSTAVKA.Count > 0)
            {
                this.rowGKSTAVKA = this.GKSTAVKASet.GKSTAVKA[this.GKSTAVKASet.GKSTAVKA.Count - 1];
            }
        }

        private void LoadGkstavka()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVDOKUMENT] FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDDOKUMENT] = @IDDOKUMENT ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowGKSTAVKA["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0))));
            }
            reader2.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVMJESTOTROSKA] FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                this.rowGKSTAVKA["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0))));
            }
            reader4.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [NAZIVORGJED] FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @IDORGJED ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                this.rowGKSTAVKA["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0))));
            }
            reader5.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVKONTO], [IDAKTIVNOST] FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @IDKONTO ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO"]))));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                this.rowGKSTAVKA["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0))));
                this.rowGKSTAVKA["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader3, 1));
            }
            reader3.Close();
            if (!this.rowGKSTAVKA.IsIDAKTIVNOSTNull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVAKTIVNOST] FROM [AKTIVNOST] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDAKTIVNOST"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowGKSTAVKA["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
                }
                reader.Close();
            }
            else
            {
                this.rowGKSTAVKA["NAZIVAKTIVNOST"] = "";
            }
            if (!this.rowGKSTAVKA.IsIDPARTNERNull())
            {
                ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT [NAZIVPARTNER] FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
                if (command6.IDbCommand.Parameters.Count == 0)
                {
                    command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                }
                command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER"]));
                IDataReader reader6 = command6.FetchData();
                if (command6.HasMoreRows)
                {
                    this.rowGKSTAVKA["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0))));
                }
                reader6.Close();
            }
            else
            {
                this.rowGKSTAVKA["NAZIVPARTNER"] = "";
            }
        }

        private void LoadRowGkstavka()
        {
            this.AddRowGkstavka();
        }

        private void OnDeleteControlsGkstavka()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVDOKUMENT] FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDDOKUMENT] = @IDDOKUMENT ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowGKSTAVKA["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0))));
            }
            reader2.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT [NAZIVMJESTOTROSKA] FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                this.rowGKSTAVKA["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader4, 0))));
            }
            reader4.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT [NAZIVORGJED] FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @IDORGJED ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                this.rowGKSTAVKA["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader5, 0))));
            }
            reader5.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT [NAZIVKONTO], [IDAKTIVNOST] FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @IDKONTO ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO"]))));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                this.rowGKSTAVKA["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader3, 0))));
                this.rowGKSTAVKA["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader3, 1));
            }
            reader3.Close();
            if (!this.rowGKSTAVKA.IsIDAKTIVNOSTNull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVAKTIVNOST] FROM [AKTIVNOST] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDAKTIVNOST"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowGKSTAVKA["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
                }
                reader.Close();
            }
            else
            {
                this.rowGKSTAVKA["NAZIVAKTIVNOST"] = "";
            }
            if (!this.rowGKSTAVKA.IsIDPARTNERNull())
            {
                ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT [NAZIVPARTNER] FROM [PARTNER] WITH (NOLOCK) WHERE [IDPARTNER] = @IDPARTNER ", false);
                if (command6.IDbCommand.Parameters.Count == 0)
                {
                    command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                }
                command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER"]));
                IDataReader reader6 = command6.FetchData();
                if (command6.HasMoreRows)
                {
                    this.rowGKSTAVKA["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader6, 0))));
                }
                reader6.Close();
            }
            else
            {
                this.rowGKSTAVKA["NAZIVPARTNER"] = "";
            }
        }

        private void OnGKSTAVKAUpdated(GKSTAVKAEventArgs e)
        {
            if (this.GKSTAVKAUpdated != null)
            {
                GKSTAVKAUpdateEventHandler gKSTAVKAUpdatedEvent = this.GKSTAVKAUpdated;
                if (gKSTAVKAUpdatedEvent != null)
                {
                    gKSTAVKAUpdatedEvent(this, e);
                }
            }
        }

        private void OnGKSTAVKAUpdating(GKSTAVKAEventArgs e)
        {
            if (this.GKSTAVKAUpdating != null)
            {
                GKSTAVKAUpdateEventHandler gKSTAVKAUpdatingEvent = this.GKSTAVKAUpdating;
                if (gKSTAVKAUpdatingEvent != null)
                {
                    gKSTAVKAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowGkstavka()
        {
            this.Gx_mode = Mode.FromRowState(this.rowGKSTAVKA.RowState);
            if (this.rowGKSTAVKA.RowState != DataRowState.Deleted)
            {
                this.rowGKSTAVKA["DATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMDOKUMENTA"])));
                this.rowGKSTAVKA["DATUMPRIJAVE"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMPRIJAVE"])));
                this.rowGKSTAVKA["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKDATUMVALUTE"])));
            }
            if (this.rowGKSTAVKA.RowState != DataRowState.Added)
            {
                this.m__DATUMPRIJAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMPRIJAVE", DataRowVersion.Original]);
                this.m__DATUMDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMDOKUMENTA", DataRowVersion.Original]);
                this.m__BROJDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJDOKUMENTA", DataRowVersion.Original]);
                this.m__BROJSTAVKEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJSTAVKE", DataRowVersion.Original]);
                this.m__OPISOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["OPIS", DataRowVersion.Original]);
                this.m__dugujeOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["duguje", DataRowVersion.Original]);
                this.m__POTRAZUJEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["POTRAZUJE", DataRowVersion.Original]);
                this.m__ZATVORENIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ZATVORENIIZNOS", DataRowVersion.Original]);
                this.m__GKDATUMVALUTEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKDATUMVALUTE", DataRowVersion.Original]);
                this.m__statusgkOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["statusgk", DataRowVersion.Original]);
                this.m__ORIGINALNIDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ORIGINALNIDOKUMENT", DataRowVersion.Original]);
                this.m__IDDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT", DataRowVersion.Original]);
                this.m__IDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA", DataRowVersion.Original]);
                this.m__IDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED", DataRowVersion.Original]);
                this.m__IDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO", DataRowVersion.Original]);
                this.m__IDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER", DataRowVersion.Original]);
                this.m__GKGODIDGODINEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKGODIDGODINE", DataRowVersion.Original]);
            }
            else
            {
                this.m__DATUMPRIJAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMPRIJAVE"]);
                this.m__DATUMDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMDOKUMENTA"]);
                this.m__BROJDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJDOKUMENTA"]);
                this.m__BROJSTAVKEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJSTAVKE"]);
                this.m__OPISOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["OPIS"]);
                this.m__dugujeOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["duguje"]);
                this.m__POTRAZUJEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["POTRAZUJE"]);
                this.m__ZATVORENIIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ZATVORENIIZNOS"]);
                this.m__GKDATUMVALUTEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKDATUMVALUTE"]);
                this.m__statusgkOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["statusgk"]);
                this.m__ORIGINALNIDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ORIGINALNIDOKUMENT"]);
                this.m__IDDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]);
                this.m__IDMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA"]);
                this.m__IDORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED"]);
                this.m__IDKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO"]);
                this.m__IDPARTNEROriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER"]);
                this.m__GKGODIDGODINEOriginal = RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKGODIDGODINE"]);
            }
            this._Gxremove = this.rowGKSTAVKA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowGKSTAVKA = (GKSTAVKADataSet.GKSTAVKARow) DataSetUtil.CloneOriginalDataRow(this.rowGKSTAVKA);
            }
        }

        private void ScanByBROJSTAVKE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[BROJSTAVKE] = @BROJSTAVKE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJSTAVKE"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByGKGODIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[GKGODIDGODINE] = @GKGODIDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKGODIDGODINE"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByIDDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDDOKUMENT] = @IDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByIDDOKUMENTBROJDOKUMENTA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[BROJDOKUMENTA] = @BROJDOKUMENTA and TM1.[IDDOKUMENT] = @IDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJDOKUMENTA"]));
            this.cmGKSTAVKASelect13.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[BROJDOKUMENTA] = @BROJDOKUMENTA and TM1.[IDDOKUMENT] = @IDDOKUMENT and TM1.[GKGODIDGODINE] = @GKGODIDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJDOKUMENTA"]));
            this.cmGKSTAVKASelect13.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            this.cmGKSTAVKASelect13.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKGODIDGODINE"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByIDGKSTAVKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDGKSTAVKA] = @IDGKSTAVKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGKSTAVKA", DbType.Int32));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDGKSTAVKA"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByIDKONTO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDKONTO] = @IDKONTO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO"]))));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByIDMJESTOTROSKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDMJESTOTROSKA] = @IDMJESTOTROSKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByIDORGJED(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDORGJED] = @IDORGJED";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanByIDPARTNER(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDPARTNER] = @IDPARTNER";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGKSTAVKASelect13.IDbCommand.Parameters.Count == 0)
            {
                this.cmGKSTAVKASelect13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
            }
            this.cmGKSTAVKASelect13.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER"]));
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        private void ScanEndGkstavka()
        {
            this.GKSTAVKASelect13.Close();
        }

        private void ScanLoadGkstavka()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmGKSTAVKASelect13.HasMoreRows)
            {
                this.RcdFound185 = 1;
                this.rowGKSTAVKA["IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 0));
                this.rowGKSTAVKA["DATUMPRIJAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.GKSTAVKASelect13, 1));
                this.rowGKSTAVKA["DATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.GKSTAVKASelect13, 2));
                this.rowGKSTAVKA["BROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 3));
                this.rowGKSTAVKA["BROJSTAVKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 4));
                this.rowGKSTAVKA["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 5))));
                this.rowGKSTAVKA["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 6))));
                this.rowGKSTAVKA["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 7))));
                this.rowGKSTAVKA["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 8))));
                this.rowGKSTAVKA["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 9))));
                this.rowGKSTAVKA["OPIS"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 10))));
                this.rowGKSTAVKA["duguje"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.GKSTAVKASelect13, 11));
                this.rowGKSTAVKA["POTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.GKSTAVKASelect13, 12));
                this.rowGKSTAVKA["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 13))));
                this.rowGKSTAVKA["ZATVORENIIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.GKSTAVKASelect13, 14));
                this.rowGKSTAVKA["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.GKSTAVKASelect13, 15));
                this.rowGKSTAVKA["statusgk"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.GKSTAVKASelect13, 0x10));
                this.rowGKSTAVKA["ORIGINALNIDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 0x11));
                this.rowGKSTAVKA["IDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 0x12));
                this.rowGKSTAVKA["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 0x13));
                this.rowGKSTAVKA["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 20));
                this.rowGKSTAVKA["IDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 0x15))));
                this.rowGKSTAVKA["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 0x16));
                this.rowGKSTAVKA["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 0x17));
                this.rowGKSTAVKA["GKGODIDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.GKSTAVKASelect13, 0x18));
                this.rowGKSTAVKA["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 5))));
                this.rowGKSTAVKA["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 6))));
                this.rowGKSTAVKA["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 7))));
                this.rowGKSTAVKA["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 8))));
                this.rowGKSTAVKA["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GKSTAVKASelect13, 0x16));
                this.rowGKSTAVKA["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 9))));
                this.rowGKSTAVKA["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GKSTAVKASelect13, 13))));
            }
        }

        private void ScanNextGkstavka()
        {
            this.cmGKSTAVKASelect13.HasMoreRows = this.GKSTAVKASelect13.Read();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
        }

        private void ScanStartGkstavka(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString185 + "  FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString185, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGKSTAVKA] ) AS DK_PAGENUM   FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString185 + " FROM (((((([GKSTAVKA] TM1 WITH (NOLOCK) INNER JOIN [DOKUMENT] T2 WITH (NOLOCK) ON T2.[IDDOKUMENT] = TM1.[IDDOKUMENT]) INNER JOIN [MJESTOTROSKA] T3 WITH (NOLOCK) ON T3.[IDMJESTOTROSKA] = TM1.[IDMJESTOTROSKA]) INNER JOIN [ORGJED] T4 WITH (NOLOCK) ON T4.[IDORGJED] = TM1.[IDORGJED]) INNER JOIN [KONTO] T5 WITH (NOLOCK) ON T5.[IDKONTO] = TM1.[IDKONTO]) INNER JOIN [AKTIVNOST] T6 WITH (NOLOCK) ON T6.[IDAKTIVNOST] = T5.[IDAKTIVNOST]) LEFT JOIN [PARTNER] T7 WITH (NOLOCK) ON T7.[IDPARTNER] = TM1.[IDPARTNER])" + this.m_WhereString + " ORDER BY TM1.[IDGKSTAVKA] ";
            }
            this.cmGKSTAVKASelect13 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.GKSTAVKASelect13 = this.cmGKSTAVKASelect13.FetchData();
            this.RcdFound185 = 0;
            this.ScanLoadGkstavka();
            this.LoadDataGkstavka(maxRows);
        }

        public virtual int UpdateKonto(DataSet dataSet)
        {
            this.InitializeMembers();
            this.GKSTAVKASet = (GKSTAVKADataSet)dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.GKSTAVKASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.GKSTAVKASet.GKSTAVKA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        GKSTAVKADataSet.GKSTAVKARow current = (GKSTAVKADataSet.GKSTAVKARow)enumerator.Current;
                        this.rowGKSTAVKA = current;

                        InsertGkstavkaShema();

                        //if (Helpers.IsRowChanged(this.rowGKSTAVKA))
                        //{
                        //    this.ReadRowGkstavka();
                        //    if (this.rowGKSTAVKA.RowState == DataRowState.Added)
                        //    {
                                
                        //    }
                        //    else
                        //    {
                        //        if (this._Gxremove)
                        //        {
                        //            this.Delete();
                        //            continue;
                        //        }
                        //        this.UpdateGkstavka();
                        //    }
                        //}
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


        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.GKSTAVKASet = (GKSTAVKADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.GKSTAVKASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.GKSTAVKASet.GKSTAVKA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        GKSTAVKADataSet.GKSTAVKARow current = (GKSTAVKADataSet.GKSTAVKARow) enumerator.Current;
                        this.rowGKSTAVKA = current;
                        if (Helpers.IsRowChanged(this.rowGKSTAVKA))
                        {
                            this.ReadRowGkstavka();
                            if (this.rowGKSTAVKA.RowState == DataRowState.Added)
                            {
                                this.InsertGkstavka();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateGkstavka();
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

        private void UpdateGkstavka()
        {
            this.CheckOptimisticConcurrencyGkstavka();
            this.CheckExtendedTableGkstavka();
            this.AfterConfirmGkstavka();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [GKSTAVKA] SET [DATUMPRIJAVE]=@DATUMPRIJAVE, [DATUMDOKUMENTA]=@DATUMDOKUMENTA, [BROJDOKUMENTA]=@BROJDOKUMENTA, [BROJSTAVKE]=@BROJSTAVKE, [OPIS]=@OPIS, [duguje]=@duguje, [POTRAZUJE]=@POTRAZUJE, [ZATVORENIIZNOS]=@ZATVORENIIZNOS, [GKDATUMVALUTE]=@GKDATUMVALUTE, [statusgk]=@statusgk, [ORIGINALNIDOKUMENT]=@ORIGINALNIDOKUMENT, [IDDOKUMENT]=@IDDOKUMENT, [IDMJESTOTROSKA]=@IDMJESTOTROSKA, [IDORGJED]=@IDORGJED, [IDKONTO]=@IDKONTO, [IDPARTNER]=@IDPARTNER, [GKGODIDGODINE]=@GKGODIDGODINE  WHERE [IDGKSTAVKA] = @IDGKSTAVKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMPRIJAVE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMDOKUMENTA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJSTAVKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPIS", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@duguje", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTRAZUJE", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZATVORENIIZNOS", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKDATUMVALUTE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@statusgk", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORIGINALNIDOKUMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GKGODIDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGKSTAVKA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameterDateObject(0, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMPRIJAVE"]));
            command.SetParameterDateObject(1, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["DATUMDOKUMENTA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJDOKUMENTA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["BROJSTAVKE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["OPIS"]))));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["duguje"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["POTRAZUJE"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ZATVORENIIZNOS"]));
            command.SetParameterDateObject(8, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKDATUMVALUTE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["statusgk"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["ORIGINALNIDOKUMENT"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDDOKUMENT"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDMJESTOTROSKA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDORGJED"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDKONTO"]))));
            command.SetParameter(15, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDPARTNER"]));
            command.SetParameter(0x10, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["GKGODIDGODINE"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowGKSTAVKA["IDGKSTAVKA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsGkstavka();
            }
            this.OnGKSTAVKAUpdated(new GKSTAVKAEventArgs(this.rowGKSTAVKA, StatementType.Update));
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
        public class AKTIVNOSTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public AKTIVNOSTForeignKeyNotFoundException()
            {
            }

            public AKTIVNOSTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected AKTIVNOSTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AKTIVNOSTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
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
        public class GKSTAVKADataChangedException : DataChangedException
        {
            public GKSTAVKADataChangedException()
            {
            }

            public GKSTAVKADataChangedException(string message) : base(message)
            {
            }

            protected GKSTAVKADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GKSTAVKADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GKSTAVKADataLockedException : DataLockedException
        {
            public GKSTAVKADataLockedException()
            {
            }

            public GKSTAVKADataLockedException(string message) : base(message)
            {
            }

            protected GKSTAVKADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GKSTAVKADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class GKSTAVKAEventArgs : EventArgs
        {
            private GKSTAVKADataSet.GKSTAVKARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public GKSTAVKAEventArgs(GKSTAVKADataSet.GKSTAVKARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public GKSTAVKADataSet.GKSTAVKARow Row
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
        public class GKSTAVKANotFoundException : DataNotFoundException
        {
            public GKSTAVKANotFoundException()
            {
            }

            public GKSTAVKANotFoundException(string message) : base(message)
            {
            }

            protected GKSTAVKANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GKSTAVKANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void GKSTAVKAUpdateEventHandler(object sender, GKSTAVKADataAdapter.GKSTAVKAEventArgs e);

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
        public class kontonijeanaliticki : UserException
        {
            public kontonijeanaliticki()
            {
            }

            public kontonijeanaliticki(string message) : base(message)
            {
            }

            protected kontonijeanaliticki(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public kontonijeanaliticki(string message, System.Exception inner) : base(message, inner)
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
        public class nemadugujeipotrazuje : UserException
        {
            public nemadugujeipotrazuje()
            {
            }

            public nemadugujeipotrazuje(string message) : base(message)
            {
            }

            protected nemadugujeipotrazuje(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public nemadugujeipotrazuje(string message, System.Exception inner) : base(message, inner)
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
        public class ZATVARANJAInvalidDeleteException : InvalidDeleteException
        {
            public ZATVARANJAInvalidDeleteException()
            {
            }

            public ZATVARANJAInvalidDeleteException(string message) : base(message)
            {
            }

            protected ZATVARANJAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZATVARANJAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

