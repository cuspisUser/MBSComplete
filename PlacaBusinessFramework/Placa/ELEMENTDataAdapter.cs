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

    public class ELEMENTDataAdapter : IDataAdapter, IELEMENTDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmELEMENTSelect1;
        private ReadWriteCommand cmELEMENTSelect2;
        private ReadWriteCommand cmELEMENTSelect3;
        private ReadWriteCommand cmELEMENTSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader ELEMENTSelect1;
        private IDataReader ELEMENTSelect2;
        private IDataReader ELEMENTSelect3;
        private IDataReader ELEMENTSelect6;
        private ELEMENTDataSet ELEMENTSet;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDOSNOVAOSIGURANJAOriginal;
        private object m__IDVRSTAELEMENTAOriginal;
        private object m__MOELEMENTOriginal;
        private object m__MZELEMENTOriginal;
        private object m__NAZIVELEMENTOriginal;
        private object m__OPISPLACANJAELEMENTOriginal;
        private object m__POELEMENTOriginal;
        private object m__POSTAVLJAMZPZSVIMVIRMANIMAOriginal;
        private object m__POSTOTAKOriginal;
        private object m__PZELEMENTOriginal;
        private object m__SIFRAOPISAPLACANJAELEMENTOriginal;
        private object m__ZBRAJASATEUFONDSATIOriginal;
        private string m_EL;
        private readonly string m_SelectString53 = "TM1.[IDELEMENT], TM1.[NAZIVELEMENT], T2.[NAZIVVRSTAELEMENT], T3.[NAZIVOSNOVAOSIGURANJA], T3.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[POSTOTAK], TM1.[ZBRAJASATEUFONDSATI], TM1.[MOELEMENT], TM1.[POELEMENT], TM1.[MZELEMENT], TM1.[PZELEMENT], TM1.[SIFRAOPISAPLACANJAELEMENT], TM1.[OPISPLACANJAELEMENT], TM1.[POSTAVLJAMZPZSVIMVIRMANIMA], TM1.[IDVRSTAELEMENTA], TM1.[IDOSNOVAOSIGURANJA]";
        private string m_WhereString;
        private short RcdFound53;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private ELEMENTDataSet.ELEMENTRow rowELEMENT;
        private string scmdbuf;
        private StatementType sMode53;

        public event ELEMENTUpdateEventHandler ELEMENTUpdated;

        public event ELEMENTUpdateEventHandler ELEMENTUpdating;

        private void AddRowElement()
        {
            this.ELEMENTSet.ELEMENT.AddELEMENTRow(this.rowELEMENT);
        }

        private void AfterConfirmElement()
        {
            this.OnELEMENTUpdating(new ELEMENTEventArgs(this.rowELEMENT, this.Gx_mode));
        }

        private void CheckDeleteErrorsElement()
        {
            ReadWriteCommand command9 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLELEMENTIDELEMENT], [KONTOELEMENTIDKONTO], [STRANEELEMENTIDSTRANEKNJIZENJA] FROM [SHEMAPLACASHEMAPLACAELEMENT] WITH (NOLOCK) WHERE [SHEMAPLELEMENTIDELEMENT] = @IDELEMENT ", false);
            if (command9.IDbCommand.Parameters.Count == 0)
            {
                command9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader9 = command9.FetchData();
            if (command9.HasMoreRows)
            {
                reader9.Close();
                throw new SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACAELEMENT" }));
            }
            reader9.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [ELEMENTBOLOVANJEIDELEMENT] FROM [BOLOVANJEFOND] WITH (NOLOCK) WHERE [ELEMENTBOLOVANJEIDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new BOLOVANJEFONDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "BOLOVANJEFOND" }));
            }
            reader.Close();
            ReadWriteCommand command8 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [NETOELEMENTIDELEMENT] FROM [RADNIKNeto] WITH (NOLOCK) WHERE [NETOELEMENTIDELEMENT] = @IDELEMENT ", false);
            if (command8.IDbCommand.Parameters.Count == 0)
            {
                command8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command8.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader8 = command8.FetchData();
            if (command8.HasMoreRows)
            {
                reader8.Close();
                throw new RADNIKNetoInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Neto elementi" }));
            }
            reader8.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [BRUTOELEMENTIDELEMENT] FROM [RADNIKBruto] WITH (NOLOCK) WHERE [BRUTOELEMENTIDELEMENT] = @IDELEMENT ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader7 = command7.FetchData();
            if (command7.HasMoreRows)
            {
                reader7.Close();
                throw new RADNIKBrutoInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level4" }));
            }
            reader7.Close();
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT TOP 1 [RAD1ELEMENTIID], [IDELEMENT] FROM [RAD1MELEMENTIVEZA] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                reader6.Close();
                throw new RAD1MELEMENTIVEZAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RAD1MELEMENTIVEZA" }));
            }
            reader6.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [RAD1GELEMENTIID], [IDELEMENT] FROM [RAD1GELEMENTIVEZA] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new RAD1GELEMENTIVEZAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RAD1GELEMENTIVEZA" }));
            }
            reader5.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [IDELEMENT] FROM [PRPLACEPRPLACEELEMENTI] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new PRPLACEPRPLACEELEMENTIInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "PRPLACEELEMENTI" }));
            }
            reader4.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDGRUPEKOEF], [IDELEMENT] FROM [GRUPEKOEFLevel1] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new GRUPEKOEFLevel1InvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level1" }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDOBRACUN], [IDRADNIK], [IDELEMENT], [ELEMENTRAZDOBLJEOD], [ELEMENTRAZDOBLJEDO] FROM [ObracunElementi] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new ObracunElementiInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Elementi" }));
            }
            reader3.Close();
        }

        private void CheckExtendedTableElement()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDVRSTAELEMENTA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new VRSTAELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTAELEMENT") }));
            }
            this.rowELEMENT["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            reader2.Close();
            if (!this.rowELEMENT.IsNAZIVVRSTAELEMENTNull())
            {
                this.m_EL = this.rowELEMENT.NAZIVELEMENT.Trim() + " | " + this.rowELEMENT.NAZIVVRSTAELEMENT.Trim();
            }
            if (!this.rowELEMENT.IsIDOSNOVAOSIGURANJANull() && (this.rowELEMENT.IDOSNOVAOSIGURANJA.Length != 0))
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA], [RAZDOBLJESESMIJEPREKLAPATI] FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDOSNOVAOSIGURANJA"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows && (string.Compare("".TrimEnd(new char[] { ' ' }), StringUtil.RTrim(this.rowELEMENT.IDOSNOVAOSIGURANJA).TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0))
                {
                    reader.Close();
                    throw new OSNOVAOSIGURANJAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSNOVAOSIGURANJA") }));
                }
                this.rowELEMENT["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowELEMENT["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1));
                reader.Close();
            }
            else
            {
                this.rowELEMENT["NAZIVOSNOVAOSIGURANJA"] = "";
                this.rowELEMENT["RAZDOBLJESESMIJEPREKLAPATI"] = false;
            }
        }

        private void CheckOptimisticConcurrencyElement()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDELEMENT], [NAZIVELEMENT], [POSTOTAK], [ZBRAJASATEUFONDSATI], [MOELEMENT], [POELEMENT], [MZELEMENT], [PZELEMENT], [SIFRAOPISAPLACANJAELEMENT], [OPISPLACANJAELEMENT], [POSTAVLJAMZPZSVIMVIRMANIMA], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] WITH (UPDLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ELEMENTDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVELEMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!this.m__POSTOTAKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__ZBRAJASATEUFONDSATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOELEMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POELEMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZELEMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZELEMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJAELEMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJAELEMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9))) || !this.m__POSTAVLJAMZPZSVIMVIRMANIMAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__IDVRSTAELEMENTAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 11)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IDOSNOVAOSIGURANJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 12))))
                {
                    reader.Close();
                    throw new ELEMENTDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowElement()
        {
            this.rowELEMENT = this.ELEMENTSet.ELEMENT.NewELEMENTRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyElement();
            this.OnDeleteControlsElement();
            this.AfterConfirmElement();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ELEMENT]  WHERE [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsElement();
            }
            this.OnELEMENTUpdated(new ELEMENTEventArgs(this.rowELEMENT, StatementType.Delete));
            this.rowELEMENT.Delete();
            this.sMode53 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode53;
        }

        public virtual int Fill(ELEMENTDataSet dataSet)
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
                    this.ELEMENTSet = dataSet;
                    this.LoadChildElement(0, -1);
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
            this.ELEMENTSet = (ELEMENTDataSet) dataSet;
            if (this.ELEMENTSet != null)
            {
                return this.Fill(this.ELEMENTSet);
            }
            this.ELEMENTSet = new ELEMENTDataSet();
            this.Fill(this.ELEMENTSet);
            dataSet.Merge(this.ELEMENTSet);
            return 0;
        }

        public virtual int Fill(ELEMENTDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDELEMENT"]));
        }

        public virtual int Fill(ELEMENTDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDELEMENT"]));
        }

        public virtual int Fill(ELEMENTDataSet dataSet, int iDELEMENT)
        {
            if (!this.FillByIDELEMENT(dataSet, iDELEMENT))
            {
                throw new ELEMENTNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            return 0;
        }

        public virtual bool FillByIDELEMENT(ELEMENTDataSet dataSet, int iDELEMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ELEMENTSet = dataSet;
            this.rowELEMENT = this.ELEMENTSet.ELEMENT.NewELEMENTRow();
            this.rowELEMENT.IDELEMENT = iDELEMENT;
            try
            {
                this.LoadByIDELEMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound53 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDOSNOVAOSIGURANJA(ELEMENTDataSet dataSet, string iDOSNOVAOSIGURANJA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ELEMENTSet = dataSet;
            this.rowELEMENT = this.ELEMENTSet.ELEMENT.NewELEMENTRow();
            this.rowELEMENT.IDOSNOVAOSIGURANJA = iDOSNOVAOSIGURANJA;
            try
            {
                this.LoadByIDOSNOVAOSIGURANJA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDVRSTAELEMENTA(ELEMENTDataSet dataSet, short iDVRSTAELEMENTA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ELEMENTSet = dataSet;
            this.rowELEMENT = this.ELEMENTSet.ELEMENT.NewELEMENTRow();
            this.rowELEMENT.IDVRSTAELEMENTA = iDVRSTAELEMENTA;
            try
            {
                this.LoadByIDVRSTAELEMENTA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(ELEMENTDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ELEMENTSet = dataSet;
            try
            {
                this.LoadChildElement(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDOSNOVAOSIGURANJA(ELEMENTDataSet dataSet, string iDOSNOVAOSIGURANJA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ELEMENTSet = dataSet;
            this.rowELEMENT = this.ELEMENTSet.ELEMENT.NewELEMENTRow();
            this.rowELEMENT.IDOSNOVAOSIGURANJA = iDOSNOVAOSIGURANJA;
            try
            {
                this.LoadByIDOSNOVAOSIGURANJA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDVRSTAELEMENTA(ELEMENTDataSet dataSet, short iDVRSTAELEMENTA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ELEMENTSet = dataSet;
            this.rowELEMENT = this.ELEMENTSet.ELEMENT.NewELEMENTRow();
            this.rowELEMENT.IDVRSTAELEMENTA = iDVRSTAELEMENTA;
            try
            {
                this.LoadByIDVRSTAELEMENTA(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDELEMENT], [NAZIVELEMENT], [POSTOTAK], [ZBRAJASATEUFONDSATI], [MOELEMENT], [POELEMENT], [MZELEMENT], [PZELEMENT], [SIFRAOPISAPLACANJAELEMENT], [OPISPLACANJAELEMENT], [POSTAVLJAMZPZSVIMVIRMANIMA], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound53 = 1;
                this.rowELEMENT["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowELEMENT["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowELEMENT["POSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowELEMENT["ZBRAJASATEUFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 3));
                this.rowELEMENT["MOELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowELEMENT["POELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowELEMENT["MZELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowELEMENT["PZELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowELEMENT["SIFRAOPISAPLACANJAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowELEMENT["OPISPLACANJAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowELEMENT["POSTAVLJAMZPZSVIMVIRMANIMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 10));
                this.rowELEMENT["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 11));
                this.rowELEMENT["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(reader, 12));
                this.sMode53 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadElement();
                this.Gx_mode = this.sMode53;
            }
            else
            {
                this.RcdFound53 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDELEMENT";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmELEMENTSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ELEMENT] WITH (NOLOCK) ", false);
            this.ELEMENTSelect3 = this.cmELEMENTSelect3.FetchData();
            if (this.ELEMENTSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ELEMENTSelect3.GetInt32(0);
            }
            this.ELEMENTSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDOSNOVAOSIGURANJA(string iDOSNOVAOSIGURANJA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmELEMENTSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ELEMENT] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
            if (this.cmELEMENTSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmELEMENTSelect1.SetParameterString(0, iDOSNOVAOSIGURANJA);
            this.ELEMENTSelect1 = this.cmELEMENTSelect1.FetchData();
            if (this.ELEMENTSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ELEMENTSelect1.GetInt32(0);
            }
            this.ELEMENTSelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDVRSTAELEMENTA(short iDVRSTAELEMENTA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmELEMENTSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
            if (this.cmELEMENTSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            this.cmELEMENTSelect2.SetParameter(0, iDVRSTAELEMENTA);
            this.ELEMENTSelect2 = this.cmELEMENTSelect2.FetchData();
            if (this.ELEMENTSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ELEMENTSelect2.GetInt32(0);
            }
            this.ELEMENTSelect2.Close();
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

        public virtual int GetRecordCountByIDOSNOVAOSIGURANJA(string iDOSNOVAOSIGURANJA)
        {
            int internalRecordCountByIDOSNOVAOSIGURANJA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDOSNOVAOSIGURANJA = this.GetInternalRecordCountByIDOSNOVAOSIGURANJA(iDOSNOVAOSIGURANJA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDOSNOVAOSIGURANJA;
        }

        public virtual int GetRecordCountByIDVRSTAELEMENTA(short iDVRSTAELEMENTA)
        {
            int internalRecordCountByIDVRSTAELEMENTA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDVRSTAELEMENTA = this.GetInternalRecordCountByIDVRSTAELEMENTA(iDVRSTAELEMENTA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDVRSTAELEMENTA;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound53 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_EL = "";
            this.m__NAZIVELEMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POSTOTAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZBRAJASATEUFONDSATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOELEMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POELEMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MZELEMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZELEMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJAELEMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJAELEMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POSTAVLJAMZPZSVIMVIRMANIMAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDVRSTAELEMENTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.ELEMENTSet = new ELEMENTDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertElement()
        {
            this.CheckOptimisticConcurrencyElement();
            this.CheckExtendedTableElement();
            this.AfterConfirmElement();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ELEMENT] ([IDELEMENT], [NAZIVELEMENT], [POSTOTAK], [ZBRAJASATEUFONDSATI], [MOELEMENT], [POELEMENT], [MZELEMENT], [PZELEMENT], [SIFRAOPISAPLACANJAELEMENT], [OPISPLACANJAELEMENT], [POSTAVLJAMZPZSVIMVIRMANIMA], [IDVRSTAELEMENTA], [IDOSNOVAOSIGURANJA]) VALUES (@IDELEMENT, @NAZIVELEMENT, @POSTOTAK, @ZBRAJASATEUFONDSATI, @MOELEMENT, @POELEMENT, @MZELEMENT, @PZELEMENT, @SIFRAOPISAPLACANJAELEMENT, @OPISPLACANJAELEMENT, @POSTAVLJAMZPZSVIMVIRMANIMA, @IDVRSTAELEMENTA, @IDOSNOVAOSIGURANJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVELEMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZBRAJASATEUFONDSATI", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOELEMENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POELEMENT", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZELEMENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZELEMENT", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAELEMENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAELEMENT", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTAVLJAMZPZSVIMVIRMANIMA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowELEMENT["NAZIVELEMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowELEMENT["POSTOTAK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowELEMENT["ZBRAJASATEUFONDSATI"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowELEMENT["MOELEMENT"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowELEMENT["POELEMENT"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowELEMENT["MZELEMENT"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowELEMENT["PZELEMENT"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowELEMENT["SIFRAOPISAPLACANJAELEMENT"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowELEMENT["OPISPLACANJAELEMENT"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowELEMENT["POSTAVLJAMZPZSVIMVIRMANIMA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDVRSTAELEMENTA"]));
            command.SetParameterString(12, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDOSNOVAOSIGURANJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ELEMENTDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnELEMENTUpdated(new ELEMENTEventArgs(this.rowELEMENT, StatementType.Insert));
        }

        private void LoadByIDELEMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ELEMENTSet.EnforceConstraints;
            this.ELEMENTSet.ELEMENT.BeginLoadData();
            this.ScanByIDELEMENT(startRow, maxRows);
            this.ELEMENTSet.ELEMENT.EndLoadData();
            this.ELEMENTSet.EnforceConstraints = enforceConstraints;
            if (this.ELEMENTSet.ELEMENT.Count > 0)
            {
                this.rowELEMENT = this.ELEMENTSet.ELEMENT[this.ELEMENTSet.ELEMENT.Count - 1];
            }
        }

        private void LoadByIDOSNOVAOSIGURANJA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ELEMENTSet.EnforceConstraints;
            this.ELEMENTSet.ELEMENT.BeginLoadData();
            this.ScanByIDOSNOVAOSIGURANJA(startRow, maxRows);
            this.ELEMENTSet.ELEMENT.EndLoadData();
            this.ELEMENTSet.EnforceConstraints = enforceConstraints;
            if (this.ELEMENTSet.ELEMENT.Count > 0)
            {
                this.rowELEMENT = this.ELEMENTSet.ELEMENT[this.ELEMENTSet.ELEMENT.Count - 1];
            }
        }

        private void LoadByIDVRSTAELEMENTA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ELEMENTSet.EnforceConstraints;
            this.ELEMENTSet.ELEMENT.BeginLoadData();
            this.ScanByIDVRSTAELEMENTA(startRow, maxRows);
            this.ELEMENTSet.ELEMENT.EndLoadData();
            this.ELEMENTSet.EnforceConstraints = enforceConstraints;
            if (this.ELEMENTSet.ELEMENT.Count > 0)
            {
                this.rowELEMENT = this.ELEMENTSet.ELEMENT[this.ELEMENTSet.ELEMENT.Count - 1];
            }
        }

        private void LoadChildElement(int startRow, int maxRows)
        {
            this.CreateNewRowElement();
            bool enforceConstraints = this.ELEMENTSet.EnforceConstraints;
            this.ELEMENTSet.ELEMENT.BeginLoadData();
            this.ScanStartElement(startRow, maxRows);
            this.ELEMENTSet.ELEMENT.EndLoadData();
            this.ELEMENTSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataElement(int maxRows)
        {
            int num = 0;
            if (this.RcdFound53 != 0)
            {
                this.ScanLoadElement();
                while ((this.RcdFound53 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowElement();
                    this.CreateNewRowElement();
                    this.ScanNextElement();
                }
            }
            if (num > 0)
            {
                this.RcdFound53 = 1;
            }
            this.ScanEndElement();
            if (this.ELEMENTSet.ELEMENT.Count > 0)
            {
                this.rowELEMENT = this.ELEMENTSet.ELEMENT[this.ELEMENTSet.ELEMENT.Count - 1];
            }
        }

        private void LoadElement()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDVRSTAELEMENTA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowELEMENT["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
            if (!this.rowELEMENT.IsNAZIVVRSTAELEMENTNull())
            {
                this.m_EL = this.rowELEMENT.NAZIVELEMENT.Trim() + " | " + this.rowELEMENT.NAZIVVRSTAELEMENT.Trim();
            }
            if (!this.rowELEMENT.IsIDOSNOVAOSIGURANJANull() && (this.rowELEMENT.IDOSNOVAOSIGURANJA.Length != 0))
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA], [RAZDOBLJESESMIJEPREKLAPATI] FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDOSNOVAOSIGURANJA"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowELEMENT["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                    this.rowELEMENT["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1));
                }
                reader.Close();
            }
            else
            {
                this.rowELEMENT["NAZIVOSNOVAOSIGURANJA"] = "";
                this.rowELEMENT["RAZDOBLJESESMIJEPREKLAPATI"] = false;
            }
        }

        private void LoadRowElement()
        {
            this.OnLoadActionsElement();
            this.AddRowElement();
        }

        private void OnDeleteControlsElement()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDVRSTAELEMENTA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowELEMENT["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
            if (!this.rowELEMENT.IsNAZIVVRSTAELEMENTNull())
            {
                this.m_EL = this.rowELEMENT.NAZIVELEMENT.Trim() + " | " + this.rowELEMENT.NAZIVVRSTAELEMENT.Trim();
            }
            if (!this.rowELEMENT.IsIDOSNOVAOSIGURANJANull() && (this.rowELEMENT.IDOSNOVAOSIGURANJA.Length != 0))
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVOSNOVAOSIGURANJA], [RAZDOBLJESESMIJEPREKLAPATI] FROM [OSNOVAOSIGURANJA] WITH (NOLOCK) WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
                }
                command.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDOSNOVAOSIGURANJA"]));
                IDataReader reader = command.FetchData();
                if (command.HasMoreRows)
                {
                    this.rowELEMENT["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                    this.rowELEMENT["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1));
                }
                reader.Close();
            }
            else
            {
                this.rowELEMENT["NAZIVOSNOVAOSIGURANJA"] = "";
                this.rowELEMENT["RAZDOBLJESESMIJEPREKLAPATI"] = false;
            }
        }

        private void OnELEMENTUpdated(ELEMENTEventArgs e)
        {
            if (this.ELEMENTUpdated != null)
            {
                ELEMENTUpdateEventHandler eLEMENTUpdatedEvent = this.ELEMENTUpdated;
                if (eLEMENTUpdatedEvent != null)
                {
                    eLEMENTUpdatedEvent(this, e);
                }
            }
        }

        private void OnELEMENTUpdating(ELEMENTEventArgs e)
        {
            if (this.ELEMENTUpdating != null)
            {
                ELEMENTUpdateEventHandler eLEMENTUpdatingEvent = this.ELEMENTUpdating;
                if (eLEMENTUpdatingEvent != null)
                {
                    eLEMENTUpdatingEvent(this, e);
                }
            }
        }

        private void OnLoadActionsElement()
        {
            if (!this.rowELEMENT.IsNAZIVVRSTAELEMENTNull())
            {
                this.m_EL = this.rowELEMENT.NAZIVELEMENT.Trim() + " | " + this.rowELEMENT.NAZIVVRSTAELEMENT.Trim();
            }
        }

        private void ReadRowElement()
        {
            this.Gx_mode = Mode.FromRowState(this.rowELEMENT.RowState);
            if (this.rowELEMENT.RowState != DataRowState.Added)
            {
                this.m__NAZIVELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["NAZIVELEMENT", DataRowVersion.Original]);
                this.m__POSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["POSTOTAK", DataRowVersion.Original]);
                this.m__ZBRAJASATEUFONDSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["ZBRAJASATEUFONDSATI", DataRowVersion.Original]);
                this.m__MOELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["MOELEMENT", DataRowVersion.Original]);
                this.m__POELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["POELEMENT", DataRowVersion.Original]);
                this.m__MZELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["MZELEMENT", DataRowVersion.Original]);
                this.m__PZELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["PZELEMENT", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJAELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["SIFRAOPISAPLACANJAELEMENT", DataRowVersion.Original]);
                this.m__OPISPLACANJAELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["OPISPLACANJAELEMENT", DataRowVersion.Original]);
                this.m__POSTAVLJAMZPZSVIMVIRMANIMAOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["POSTAVLJAMZPZSVIMVIRMANIMA", DataRowVersion.Original]);
                this.m__IDVRSTAELEMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDVRSTAELEMENTA", DataRowVersion.Original]);
                this.m__IDOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDOSNOVAOSIGURANJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["NAZIVELEMENT"]);
                this.m__POSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["POSTOTAK"]);
                this.m__ZBRAJASATEUFONDSATIOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["ZBRAJASATEUFONDSATI"]);
                this.m__MOELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["MOELEMENT"]);
                this.m__POELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["POELEMENT"]);
                this.m__MZELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["MZELEMENT"]);
                this.m__PZELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["PZELEMENT"]);
                this.m__SIFRAOPISAPLACANJAELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["SIFRAOPISAPLACANJAELEMENT"]);
                this.m__OPISPLACANJAELEMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["OPISPLACANJAELEMENT"]);
                this.m__POSTAVLJAMZPZSVIMVIRMANIMAOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["POSTAVLJAMZPZSVIMVIRMANIMA"]);
                this.m__IDVRSTAELEMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDVRSTAELEMENTA"]);
                this.m__IDOSNOVAOSIGURANJAOriginal = RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDOSNOVAOSIGURANJA"]);
            }
            this._Gxremove = this.rowELEMENT.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowELEMENT = (ELEMENTDataSet.ELEMENTRow) DataSetUtil.CloneOriginalDataRow(this.rowELEMENT);
            }
        }

        private void ScanByIDELEMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDELEMENT] = @IDELEMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString53 + "  FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString53, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString53 + " FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDELEMENT] ";
            }
            this.cmELEMENTSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmELEMENTSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmELEMENTSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            this.ELEMENTSelect6 = this.cmELEMENTSelect6.FetchData();
            this.RcdFound53 = 0;
            this.ScanLoadElement();
            this.LoadDataElement(maxRows);
        }

        private void ScanByIDOSNOVAOSIGURANJA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString53 + "  FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString53, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString53 + " FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDELEMENT] ";
            }
            this.cmELEMENTSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmELEMENTSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmELEMENTSelect6.SetParameterString(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDOSNOVAOSIGURANJA"]));
            this.ELEMENTSelect6 = this.cmELEMENTSelect6.FetchData();
            this.RcdFound53 = 0;
            this.ScanLoadElement();
            this.LoadDataElement(maxRows);
        }

        private void ScanByIDVRSTAELEMENTA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDVRSTAELEMENTA] = @IDVRSTAELEMENTA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString53 + "  FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString53, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString53 + " FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDELEMENT] ";
            }
            this.cmELEMENTSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmELEMENTSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            this.cmELEMENTSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDVRSTAELEMENTA"]));
            this.ELEMENTSelect6 = this.cmELEMENTSelect6.FetchData();
            this.RcdFound53 = 0;
            this.ScanLoadElement();
            this.LoadDataElement(maxRows);
        }

        private void ScanEndElement()
        {
            this.ELEMENTSelect6.Close();
        }

        private void ScanLoadElement()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmELEMENTSelect6.HasMoreRows)
            {
                this.RcdFound53 = 1;
                this.rowELEMENT["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ELEMENTSelect6, 0));
                this.rowELEMENT["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 1));
                this.rowELEMENT["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 2));
                this.rowELEMENT["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 3));
                this.rowELEMENT["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ELEMENTSelect6, 4));
                this.rowELEMENT["POSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ELEMENTSelect6, 5));
                this.rowELEMENT["ZBRAJASATEUFONDSATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ELEMENTSelect6, 6));
                this.rowELEMENT["MOELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 7));
                this.rowELEMENT["POELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 8));
                this.rowELEMENT["MZELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 9));
                this.rowELEMENT["PZELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 10));
                this.rowELEMENT["SIFRAOPISAPLACANJAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 11));
                this.rowELEMENT["OPISPLACANJAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 12));
                this.rowELEMENT["POSTAVLJAMZPZSVIMVIRMANIMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ELEMENTSelect6, 13));
                this.rowELEMENT["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.ELEMENTSelect6, 14));
                this.rowELEMENT["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetStringNE(this.ELEMENTSelect6, 15));
                this.rowELEMENT["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 2));
                this.rowELEMENT["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ELEMENTSelect6, 3));
                this.rowELEMENT["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.ELEMENTSelect6, 4));
            }
        }

        private void ScanNextElement()
        {
            this.cmELEMENTSelect6.HasMoreRows = this.ELEMENTSelect6.Read();
            this.RcdFound53 = 0;
            this.ScanLoadElement();
        }

        private void ScanStartElement(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString53 + "  FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDELEMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString53, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDELEMENT] ) AS DK_PAGENUM   FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString53 + " FROM (([ELEMENT] TM1 WITH (NOLOCK) INNER JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA])" + this.m_WhereString + " ORDER BY TM1.[IDELEMENT] ";
            }
            this.cmELEMENTSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.ELEMENTSelect6 = this.cmELEMENTSelect6.FetchData();
            this.RcdFound53 = 0;
            this.ScanLoadElement();
            this.LoadDataElement(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.ELEMENTSet = (ELEMENTDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.ELEMENTSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.ELEMENTSet.ELEMENT.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ELEMENTDataSet.ELEMENTRow current = (ELEMENTDataSet.ELEMENTRow) enumerator.Current;
                        this.rowELEMENT = current;
                        if (Helpers.IsRowChanged(this.rowELEMENT))
                        {
                            this.ReadRowElement();
                            if (this.rowELEMENT.RowState == DataRowState.Added)
                            {
                                this.InsertElement();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateElement();
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

        private void UpdateElement()
        {
            this.CheckOptimisticConcurrencyElement();
            this.CheckExtendedTableElement();
            this.AfterConfirmElement();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ELEMENT] SET [NAZIVELEMENT]=@NAZIVELEMENT, [POSTOTAK]=@POSTOTAK, [ZBRAJASATEUFONDSATI]=@ZBRAJASATEUFONDSATI, [MOELEMENT]=@MOELEMENT, [POELEMENT]=@POELEMENT, [MZELEMENT]=@MZELEMENT, [PZELEMENT]=@PZELEMENT, [SIFRAOPISAPLACANJAELEMENT]=@SIFRAOPISAPLACANJAELEMENT, [OPISPLACANJAELEMENT]=@OPISPLACANJAELEMENT, [POSTAVLJAMZPZSVIMVIRMANIMA]=@POSTAVLJAMZPZSVIMVIRMANIMA, [IDVRSTAELEMENTA]=@IDVRSTAELEMENTA, [IDOSNOVAOSIGURANJA]=@IDOSNOVAOSIGURANJA  WHERE [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVELEMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZBRAJASATEUFONDSATI", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOELEMENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POELEMENT", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZELEMENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZELEMENT", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAELEMENT", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAELEMENT", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTAVLJAMZPZSVIMVIRMANIMA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowELEMENT["NAZIVELEMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowELEMENT["POSTOTAK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowELEMENT["ZBRAJASATEUFONDSATI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowELEMENT["MOELEMENT"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowELEMENT["POELEMENT"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowELEMENT["MZELEMENT"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowELEMENT["PZELEMENT"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowELEMENT["SIFRAOPISAPLACANJAELEMENT"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowELEMENT["OPISPLACANJAELEMENT"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowELEMENT["POSTAVLJAMZPZSVIMVIRMANIMA"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDVRSTAELEMENTA"]));
            command.SetParameterString(11, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDOSNOVAOSIGURANJA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowELEMENT["IDELEMENT"]));
            command.ExecuteStmt();
            new elementupdateredundancy(ref this.dsDefault).execute(this.rowELEMENT.IDELEMENT);
            this.OnELEMENTUpdated(new ELEMENTEventArgs(this.rowELEMENT, StatementType.Update));
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
        public class BOLOVANJEFONDInvalidDeleteException : InvalidDeleteException
        {
            public BOLOVANJEFONDInvalidDeleteException()
            {
            }

            public BOLOVANJEFONDInvalidDeleteException(string message) : base(message)
            {
            }

            protected BOLOVANJEFONDInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BOLOVANJEFONDInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ELEMENTDataChangedException : DataChangedException
        {
            public ELEMENTDataChangedException()
            {
            }

            public ELEMENTDataChangedException(string message) : base(message)
            {
            }

            protected ELEMENTDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ELEMENTDataLockedException : DataLockedException
        {
            public ELEMENTDataLockedException()
            {
            }

            public ELEMENTDataLockedException(string message) : base(message)
            {
            }

            protected ELEMENTDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ELEMENTDuplicateKeyException : DuplicateKeyException
        {
            public ELEMENTDuplicateKeyException()
            {
            }

            public ELEMENTDuplicateKeyException(string message) : base(message)
            {
            }

            protected ELEMENTDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ELEMENTEventArgs : EventArgs
        {
            private ELEMENTDataSet.ELEMENTRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ELEMENTEventArgs(ELEMENTDataSet.ELEMENTRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public ELEMENTDataSet.ELEMENTRow Row
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
        public class ELEMENTNotFoundException : DataNotFoundException
        {
            public ELEMENTNotFoundException()
            {
            }

            public ELEMENTNotFoundException(string message) : base(message)
            {
            }

            protected ELEMENTNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void ELEMENTUpdateEventHandler(object sender, ELEMENTDataAdapter.ELEMENTEventArgs e);

        [Serializable]
        public class GRUPEKOEFLevel1InvalidDeleteException : InvalidDeleteException
        {
            public GRUPEKOEFLevel1InvalidDeleteException()
            {
            }

            public GRUPEKOEFLevel1InvalidDeleteException(string message) : base(message)
            {
            }

            protected GRUPEKOEFLevel1InvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFLevel1InvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ObracunElementiInvalidDeleteException : InvalidDeleteException
        {
            public ObracunElementiInvalidDeleteException()
            {
            }

            public ObracunElementiInvalidDeleteException(string message) : base(message)
            {
            }

            protected ObracunElementiInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ObracunElementiInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSNOVAOSIGURANJAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OSNOVAOSIGURANJAForeignKeyNotFoundException()
            {
            }

            public OSNOVAOSIGURANJAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OSNOVAOSIGURANJAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSNOVAOSIGURANJAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIInvalidDeleteException : InvalidDeleteException
        {
            public PRPLACEPRPLACEELEMENTIInvalidDeleteException()
            {
            }

            public PRPLACEPRPLACEELEMENTIInvalidDeleteException(string message) : base(message)
            {
            }

            protected PRPLACEPRPLACEELEMENTIInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEPRPLACEELEMENTIInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1GELEMENTIVEZAInvalidDeleteException : InvalidDeleteException
        {
            public RAD1GELEMENTIVEZAInvalidDeleteException()
            {
            }

            public RAD1GELEMENTIVEZAInvalidDeleteException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIVEZAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIVEZAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1MELEMENTIVEZAInvalidDeleteException : InvalidDeleteException
        {
            public RAD1MELEMENTIVEZAInvalidDeleteException()
            {
            }

            public RAD1MELEMENTIVEZAInvalidDeleteException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIVEZAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIVEZAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKBrutoInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKBrutoInvalidDeleteException()
            {
            }

            public RADNIKBrutoInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKBrutoInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKBrutoInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKNetoInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKNetoInvalidDeleteException()
            {
            }

            public RADNIKNetoInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKNetoInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKNetoInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTAELEMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public VRSTAELEMENTForeignKeyNotFoundException()
            {
            }

            public VRSTAELEMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected VRSTAELEMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAELEMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

