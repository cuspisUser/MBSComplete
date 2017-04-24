namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic;
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

    public class RSMADataAdapter : IDataAdapter, IRSMADataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private bool _Gxremove51;
        private ReadWriteCommand cmRSMA1Select2;
        private ReadWriteCommand cmRSMASelect1;
        private ReadWriteCommand cmRSMASelect2;
        private ReadWriteCommand cmRSMASelect3;
        private ReadWriteCommand cmRSMASelect4;
        private ReadWriteCommand cmRSMASelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__ADRESAOriginal;
        private object m__BOriginal;
        private object m__BROJOSIGURANIKAOriginal;
        private object m__DOOOriginal;
        private object m__godinaisplatersmOriginal;
        private object m__godinaobracunarsmOriginal;
        private object m__IDOBRACUNOriginal;
        private object m__IDRSVRSTEOBRACUNAOriginal;
        private object m__IDRSVRSTEOBVEZNIKAOriginal;
        private decimal m__IZNOSISPLACENEPLACEPrevious;
        private object m__IZNOSISPLACENEPLACERSMBOriginal;
        private decimal m__IZNOSISPLACENEPLACERSMBPrevious;
        private decimal m__IZNOSOBRACUNANEPLACEPrevious;
        private object m__IZNOSOBRACUNANEPLACERSMBOriginal;
        private decimal m__IZNOSOBRACUNANEPLACERSMBPrevious;
        private decimal m__IZNOSOSNOVICEZADOPRINOSEPrevious;
        private object m__IZNOSOSNOVICEZADOPRINOSERSMBOriginal;
        private decimal m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious;
        private object m__MBGOBVEZNIKAOriginal;
        private object m__MBGOSIGURANIKAOriginal;
        private object m__MBOBVEZNIKAOriginal;
        private decimal m__MIO1Previous;
        private object m__MIO1RSMBOriginal;
        private decimal m__MIO1RSMBPrevious;
        private decimal m__MIO2Previous;
        private object m__MIO2RSMBOriginal;
        private decimal m__MIO2RSMBPrevious;
        private object m__mjesecisplatersmOriginal;
        private object m__mjesecoBRACUNArsmOriginal;
        private object m__NAZIVOBVEZNIKAOriginal;
        private object m__ODOriginal;
        private object m__OOOriginal;
        private object m__PREZIMEIIMEOriginal;
        private object m__REDNIBROJOriginal;
        private object m__SIFRAGRADARADAOriginal;
        private decimal m_IZNOSISPLACENEPLACE;
        private decimal m_IZNOSOBRACUNANEPLACE;
        private decimal m_IZNOSOSNOVICEZADOPRINOSE;
        private decimal m_MIO1;
        private decimal m_MIO2;
        private readonly string m_SelectString27 = "TM1.[IDENTIFIKATOROBRASCA], TM1.[MBOBVEZNIKA], TM1.[MBGOBVEZNIKA], TM1.[NAZIVOBVEZNIKA], TM1.[ADRESA], T2.[NAZIVRSVRSTEOBVEZNIKA], T3.[NAZIVRSVRSTEOBRACUNA], TM1.[mjesecoBRACUNArsm], TM1.[godinaobracunarsm], TM1.[BROJOSIGURANIKA], TM1.[mjesecisplatersm], TM1.[godinaisplatersm], TM1.[IDRSVRSTEOBVEZNIKA], TM1.[IDRSVRSTEOBRACUNA], TM1.[IDOBRACUN]";
        private string m_SubSelTopString28;
        private string m_WhereString;
        private short RcdFound27;
        private short RcdFound28;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RSMADataSet.RSMARow rowRSMA;
        private RSMADataSet.RSMA1Row rowRSMA1;
        private IDataReader RSMA1Select2;
        private IDataReader RSMASelect1;
        private IDataReader RSMASelect2;
        private IDataReader RSMASelect3;
        private IDataReader RSMASelect4;
        private IDataReader RSMASelect7;
        private RSMADataSet RSMASet;
        private string scmdbuf;
        private StatementType sMode27;
        private StatementType sMode28;

        public event RSMA1UpdateEventHandler RSMA1Updated;

        public event RSMA1UpdateEventHandler RSMA1Updating;

        public event RSMAUpdateEventHandler RSMAUpdated;

        public event RSMAUpdateEventHandler RSMAUpdating;

        private void AddRowRsma()
        {
            this.RSMASet.RSMA.AddRSMARow(this.rowRSMA);
        }

        private void AddRowRsma1()
        {
            this.RSMASet.RSMA1.AddRSMA1Row(this.rowRSMA1);
        }

        private void AfterConfirmRsma()
        {
            this.OnRSMAUpdating(new RSMAEventArgs(this.rowRSMA, this.Gx_mode));
        }

        private void AfterConfirmRsma1()
        {
            this.OnRSMA1Updating(new RSMA1EventArgs(this.rowRSMA1, this.Gx_mode));
        }

        private void CheckExtendedTableRsma()
        {
            this.GetIZNOSOBRACUNANEPLACE(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__IZNOSOBRACUNANEPLACEPrevious = this.m_IZNOSOBRACUNANEPLACE;
            this.m__IZNOSOSNOVICEZADOPRINOSEPrevious = this.m_IZNOSOSNOVICEZADOPRINOSE;
            this.GetMIO1(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__MIO1Previous = this.m_MIO1;
            this.m__MIO2Previous = this.m_MIO2;
            this.GetIZNOSISPLACENEPLACE(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__IZNOSISPLACENEPLACEPrevious = this.m_IZNOSISPLACENEPLACE;
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVRSVRSTEOBVEZNIKA] FROM [RSVRSTEOBVEZNIKA] WITH (NOLOCK) WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new RSVRSTEOBVEZNIKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RSVRSTEOBVEZNIKA") }));
            }
            this.rowRSMA["NAZIVRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVRSVRSTEOBRACUNA] FROM [RSVRSTEOBRACUNA] WITH (NOLOCK) WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new RSVRSTEOBRACUNAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RSVRSTEOBRACUNA") }));
            }
            this.rowRSMA["NAZIVRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckExtendedTableRsma1()
        {
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_IZNOSOBRACUNANEPLACE = decimal.Add(this.m__IZNOSOBRACUNANEPLACEPrevious, this.rowRSMA1.IZNOSOBRACUNANEPLACERSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_IZNOSOBRACUNANEPLACE = decimal.Subtract(decimal.Add(this.m__IZNOSOBRACUNANEPLACEPrevious, this.rowRSMA1.IZNOSOBRACUNANEPLACERSMB), this.m__IZNOSOBRACUNANEPLACERSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_IZNOSOBRACUNANEPLACE = decimal.Subtract(this.m__IZNOSOBRACUNANEPLACEPrevious, this.m__IZNOSOBRACUNANEPLACERSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Add(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.rowRSMA1.IZNOSOSNOVICEZADOPRINOSERSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Subtract(decimal.Add(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.rowRSMA1.IZNOSOSNOVICEZADOPRINOSERSMB), this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Subtract(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_MIO1 = decimal.Add(this.m__MIO1Previous, this.rowRSMA1.MIO1RSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_MIO1 = decimal.Subtract(decimal.Add(this.m__MIO1Previous, this.rowRSMA1.MIO1RSMB), this.m__MIO1RSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_MIO1 = decimal.Subtract(this.m__MIO1Previous, this.m__MIO1RSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_MIO2 = decimal.Add(this.m__MIO2Previous, this.rowRSMA1.MIO2RSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_MIO2 = decimal.Subtract(decimal.Add(this.m__MIO2Previous, this.rowRSMA1.MIO2RSMB), this.m__MIO2RSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_MIO2 = decimal.Subtract(this.m__MIO2Previous, this.m__MIO2RSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_IZNOSISPLACENEPLACE = decimal.Add(this.m__IZNOSISPLACENEPLACEPrevious, this.rowRSMA1.IZNOSISPLACENEPLACERSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_IZNOSISPLACENEPLACE = decimal.Subtract(decimal.Add(this.m__IZNOSISPLACENEPLACEPrevious, this.rowRSMA1.IZNOSISPLACENEPLACERSMB), this.m__IZNOSISPLACENEPLACERSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_IZNOSISPLACENEPLACE = decimal.Subtract(this.m__IZNOSISPLACENEPLACEPrevious, this.m__IZNOSISPLACENEPLACERSMBPrevious);
            }
        }

        private void CheckIntegrityErrorsRsma()
        {
            if (!this.rowRSMA.IsIDOBRACUNNull())
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBRACUN] FROM [OBRACUN] WITH (NOLOCK) WHERE [IDOBRACUN] = @IDOBRACUN ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDOBRACUN"]));
                IDataReader reader = command.FetchData();
                if (!command.HasMoreRows && (string.Compare("".TrimEnd(new char[] { ' ' }), StringUtil.RTrim(this.rowRSMA.IDOBRACUN).TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) != 0))
                {
                    reader.Close();
                    throw new OBRACUNForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OBRACUN") }));
                }
                reader.Close();
            }
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyRsma()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDENTIFIKATOROBRASCA], [MBOBVEZNIKA], [MBGOBVEZNIKA], [NAZIVOBVEZNIKA], [ADRESA], [mjesecoBRACUNArsm], [godinaobracunarsm], [BROJOSIGURANIKA], [mjesecisplatersm], [godinaisplatersm], [IDRSVRSTEOBVEZNIKA], [IDRSVRSTEOBRACUNA], [IDOBRACUN] FROM [RSMA] WITH (UPDLOCK) WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDENTIFIKATOROBRASCA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RSMADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RSMA") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MBOBVEZNIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MBGOBVEZNIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVOBVEZNIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ADRESAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__mjesecoBRACUNArsmOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__godinaobracunarsmOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__BROJOSIGURANIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__mjesecisplatersmOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__godinaisplatersmOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IDRSVRSTEOBVEZNIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IDRSVRSTEOBRACUNAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IDOBRACUNOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))))
                {
                    reader.Close();
                    throw new RSMADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RSMA") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyRsma1()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDENTIFIKATOROBRASCA], [ID], [REDNIBROJ], [PREZIMEIIME], [MBGOSIGURANIKA], [SIFRAGRADARADA], [OO], [B], [OD], [DOO], [IZNOSOBRACUNANEPLACERSMB], [IZNOSOSNOVICEZADOPRINOSERSMB], [MIO1RSMB], [MIO2RSMB], [IZNOSISPLACENEPLACERSMB] FROM [RSMA1] WITH (UPDLOCK) WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA AND [ID] = @ID ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ID", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IDENTIFIKATOROBRASCA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSMA1["ID"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RSMA1DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RSMA1") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__REDNIBROJOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PREZIMEIIMEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MBGOSIGURANIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAGRADARADAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__BOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ODOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DOOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || (!this.m__IZNOSOBRACUNANEPLACERSMBOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 10))) || !this.m__IZNOSOSNOVICEZADOPRINOSERSMBOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 11))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !this.m__MIO1RSMBOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 12)))) || (!this.m__MIO2RSMBOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 13))) || !this.m__IZNOSISPLACENEPLACERSMBOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 14)))))
                {
                    reader.Close();
                    throw new RSMA1DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RSMA1") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRsma()
        {
            this.rowRSMA = this.RSMASet.RSMA.NewRSMARow();
        }

        private void CreateNewRowRsma1()
        {
            this.rowRSMA1 = this.RSMASet.RSMA1.NewRSMA1Row();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRsma();
            this.OnDeleteControlsRsma();
            this.ProcessNestedLevelRsma1();
            this.AfterConfirmRsma();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RSMA]  WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDENTIFIKATOROBRASCA"]));
            command.ExecuteStmt();
            this.OnRSMAUpdated(new RSMAEventArgs(this.rowRSMA, StatementType.Delete));
            this.rowRSMA.Delete();
            this.sMode27 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode27;
        }

        private void DeleteRsma1()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRsma1();
            this.OnDeleteControlsRsma1();
            this.AfterConfirmRsma1();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RSMA1]  WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA AND [ID] = @ID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ID", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IDENTIFIKATOROBRASCA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSMA1["ID"]));
            command.ExecuteStmt();
            this.OnRSMA1Updated(new RSMA1EventArgs(this.rowRSMA1, StatementType.Delete));
            this.rowRSMA1.Delete();
            this.sMode28 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode28;
        }


        public virtual int Fill(RSMADataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, this.fillDataParameters[0].Value.ToString());
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.RSMASet = dataSet;
                    this.LoadChildRsma(0, -1);
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
            this.RSMASet = (RSMADataSet) dataSet;
            if (this.RSMASet != null)
            {
                return this.Fill(this.RSMASet);
            }
            this.RSMASet = new RSMADataSet();
            this.Fill(this.RSMASet);
            dataSet.Merge(this.RSMASet);
            return 0;
        }

        public virtual int Fill(RSMADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDENTIFIKATOROBRASCA"]));
        }

        public virtual int Fill(RSMADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDENTIFIKATOROBRASCA"]));
        }

        public virtual int Fill(RSMADataSet dataSet, string iDENTIFIKATOROBRASCA)
        {
            if (!this.FillByIDENTIFIKATOROBRASCA(dataSet, iDENTIFIKATOROBRASCA))
            {
                throw new RSMANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RSMA") }));
            }
            return 0;
        }

        public virtual bool FillByIDENTIFIKATOROBRASCA(RSMADataSet dataSet, string iDENTIFIKATOROBRASCA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSMASet = dataSet;
            this.rowRSMA = this.RSMASet.RSMA.NewRSMARow();
            this.rowRSMA.IDENTIFIKATOROBRASCA = iDENTIFIKATOROBRASCA;
            try
            {
                this.LoadByIDENTIFIKATOROBRASCA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound27 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDOBRACUN(RSMADataSet dataSet, string iDOBRACUN)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSMASet = dataSet;
            this.rowRSMA = this.RSMASet.RSMA.NewRSMARow();
            this.rowRSMA.IDOBRACUN = iDOBRACUN;
            try
            {
                this.LoadByIDOBRACUN(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDRSVRSTEOBRACUNA(RSMADataSet dataSet, string iDRSVRSTEOBRACUNA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSMASet = dataSet;
            this.rowRSMA = this.RSMASet.RSMA.NewRSMARow();
            this.rowRSMA.IDRSVRSTEOBRACUNA = iDRSVRSTEOBRACUNA;
            try
            {
                this.LoadByIDRSVRSTEOBRACUNA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByIDRSVRSTEOBVEZNIKA(RSMADataSet dataSet, string iDRSVRSTEOBVEZNIKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSMASet = dataSet;
            this.rowRSMA = this.RSMASet.RSMA.NewRSMARow();
            this.rowRSMA.IDRSVRSTEOBVEZNIKA = iDRSVRSTEOBVEZNIKA;
            try
            {
                this.LoadByIDRSVRSTEOBVEZNIKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(RSMADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSMASet = dataSet;
            try
            {
                this.LoadChildRsma(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDOBRACUN(RSMADataSet dataSet, string iDOBRACUN, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSMASet = dataSet;
            this.rowRSMA = this.RSMASet.RSMA.NewRSMARow();
            this.rowRSMA.IDOBRACUN = iDOBRACUN;
            try
            {
                this.LoadByIDOBRACUN(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDRSVRSTEOBRACUNA(RSMADataSet dataSet, string iDRSVRSTEOBRACUNA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSMASet = dataSet;
            this.rowRSMA = this.RSMASet.RSMA.NewRSMARow();
            this.rowRSMA.IDRSVRSTEOBRACUNA = iDRSVRSTEOBRACUNA;
            try
            {
                this.LoadByIDRSVRSTEOBRACUNA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDRSVRSTEOBVEZNIKA(RSMADataSet dataSet, string iDRSVRSTEOBVEZNIKA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSMASet = dataSet;
            this.rowRSMA = this.RSMASet.RSMA.NewRSMARow();
            this.rowRSMA.IDRSVRSTEOBVEZNIKA = iDRSVRSTEOBVEZNIKA;
            try
            {
                this.LoadByIDRSVRSTEOBVEZNIKA(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDENTIFIKATOROBRASCA], [MBOBVEZNIKA], [MBGOBVEZNIKA], [NAZIVOBVEZNIKA], [ADRESA], [mjesecoBRACUNArsm], [godinaobracunarsm], [BROJOSIGURANIKA], [mjesecisplatersm], [godinaisplatersm], [IDRSVRSTEOBVEZNIKA], [IDRSVRSTEOBRACUNA], [IDOBRACUN] FROM [RSMA] WITH (NOLOCK) WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDENTIFIKATOROBRASCA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound27 = 1;
                this.rowRSMA["IDENTIFIKATOROBRASCA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowRSMA["MBOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowRSMA["MBGOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowRSMA["NAZIVOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowRSMA["ADRESA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowRSMA["mjesecoBRACUNArsm"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowRSMA["godinaobracunarsm"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowRSMA["BROJOSIGURANIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowRSMA["mjesecisplatersm"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowRSMA["godinaisplatersm"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowRSMA["IDRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowRSMA["IDRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowRSMA["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.sMode27 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadRsma();
                this.Gx_mode = this.sMode27;
            }
            else
            {
                this.RcdFound27 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDENTIFIKATOROBRASCA";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMASelect4 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RSMA] WITH (NOLOCK) ", false);
            this.RSMASelect4 = this.cmRSMASelect4.FetchData();
            if (this.RSMASelect4.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RSMASelect4.GetInt32(0);
            }
            this.RSMASelect4.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDOBRACUN(string iDOBRACUN)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RSMA] WITH (NOLOCK) WHERE [IDOBRACUN] = @IDOBRACUN ", false);
            if (this.cmRSMASelect3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            this.cmRSMASelect3.SetParameter(0, iDOBRACUN);
            this.RSMASelect3 = this.cmRSMASelect3.FetchData();
            if (this.RSMASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RSMASelect3.GetInt32(0);
            }
            this.RSMASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDRSVRSTEOBRACUNA(string iDRSVRSTEOBRACUNA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RSMA] WITH (NOLOCK) WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ", false);
            if (this.cmRSMASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            this.cmRSMASelect1.SetParameter(0, iDRSVRSTEOBRACUNA);
            this.RSMASelect1 = this.cmRSMASelect1.FetchData();
            if (this.RSMASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RSMASelect1.GetInt32(0);
            }
            this.RSMASelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDRSVRSTEOBVEZNIKA(string iDRSVRSTEOBVEZNIKA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSMASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RSMA] WITH (NOLOCK) WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA ", false);
            if (this.cmRSMASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            this.cmRSMASelect2.SetParameter(0, iDRSVRSTEOBVEZNIKA);
            this.RSMASelect2 = this.cmRSMASelect2.FetchData();
            if (this.RSMASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RSMASelect2.GetInt32(0);
            }
            this.RSMASelect2.Close();
            return this.recordCount;
        }

        private void GetIZNOSISPLACENEPLACE(string IDENTIFIKATOROBRASCA)
        {
            this.m_IZNOSISPLACENEPLACE = new decimal();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDENTIFIKATOROBRASCA], [ID], [IZNOSISPLACENEPLACERSMB] FROM [RSMA1] WITH (NOLOCK) WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA ORDER BY [IDENTIFIKATOROBRASCA] ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            command.SetParameter(0, IDENTIFIKATOROBRASCA);
            IDataReader reader = command.FetchData();
            while (command.HasMoreRows && (string.Compare(reader.GetString(0).TrimEnd(new char[] { ' ' }), IDENTIFIKATOROBRASCA.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0))
            {
                this.m_IZNOSISPLACENEPLACE = decimal.Add(this.m_IZNOSISPLACENEPLACE, reader.GetDecimal(2));
                command.HasMoreRows = reader.Read();
            }
            reader.Close();
        }

        private void GetIZNOSOBRACUNANEPLACE(string IDENTIFIKATOROBRASCA)
        {
            this.m_IZNOSOBRACUNANEPLACE = new decimal();
            this.m_IZNOSOSNOVICEZADOPRINOSE = new decimal();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDENTIFIKATOROBRASCA], [ID], [IZNOSOSNOVICEZADOPRINOSERSMB], [IZNOSOBRACUNANEPLACERSMB] FROM [RSMA1] WITH (NOLOCK) WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA ORDER BY [IDENTIFIKATOROBRASCA] ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            command.SetParameter(0, IDENTIFIKATOROBRASCA);
            IDataReader reader = command.FetchData();
            while (command.HasMoreRows && (string.Compare(reader.GetString(0).TrimEnd(new char[] { ' ' }), IDENTIFIKATOROBRASCA.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0))
            {
                this.m_IZNOSOBRACUNANEPLACE = decimal.Add(this.m_IZNOSOBRACUNANEPLACE, reader.GetDecimal(3));
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Add(this.m_IZNOSOSNOVICEZADOPRINOSE, reader.GetDecimal(2));
                command.HasMoreRows = reader.Read();
            }
            reader.Close();
        }

        private void GetMIO1(string IDENTIFIKATOROBRASCA)
        {
            this.m_MIO1 = new decimal();
            this.m_MIO2 = new decimal();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDENTIFIKATOROBRASCA], [ID], [MIO2RSMB], [MIO1RSMB] FROM [RSMA1] WITH (NOLOCK) WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA ORDER BY [IDENTIFIKATOROBRASCA] ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            command.SetParameter(0, IDENTIFIKATOROBRASCA);
            IDataReader reader = command.FetchData();
            while (command.HasMoreRows && (string.Compare(reader.GetString(0).TrimEnd(new char[] { ' ' }), IDENTIFIKATOROBRASCA.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0))
            {
                this.m_MIO1 = decimal.Add(this.m_MIO1, reader.GetDecimal(3));
                this.m_MIO2 = decimal.Add(this.m_MIO2, reader.GetDecimal(2));
                command.HasMoreRows = reader.Read();
            }
            reader.Close();
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

        public virtual int GetRecordCountByIDOBRACUN(string iDOBRACUN)
        {
            int internalRecordCountByIDOBRACUN;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDOBRACUN = this.GetInternalRecordCountByIDOBRACUN(iDOBRACUN);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDOBRACUN;
        }

        public virtual int GetRecordCountByIDRSVRSTEOBRACUNA(string iDRSVRSTEOBRACUNA)
        {
            int internalRecordCountByIDRSVRSTEOBRACUNA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDRSVRSTEOBRACUNA = this.GetInternalRecordCountByIDRSVRSTEOBRACUNA(iDRSVRSTEOBRACUNA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDRSVRSTEOBRACUNA;
        }

        public virtual int GetRecordCountByIDRSVRSTEOBVEZNIKA(string iDRSVRSTEOBVEZNIKA)
        {
            int internalRecordCountByIDRSVRSTEOBVEZNIKA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDRSVRSTEOBVEZNIKA = this.GetInternalRecordCountByIDRSVRSTEOBVEZNIKA(iDRSVRSTEOBVEZNIKA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDRSVRSTEOBVEZNIKA;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound27 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_IZNOSOBRACUNANEPLACE = new decimal();
            this.m_IZNOSOSNOVICEZADOPRINOSE = new decimal();
            this.m_MIO1 = new decimal();
            this.m_MIO2 = new decimal();
            this.m_IZNOSISPLACENEPLACE = new decimal();
            this.m__IZNOSISPLACENEPLACERSMBPrevious = new decimal();
            this.m__MIO2RSMBPrevious = new decimal();
            this.m__MIO1RSMBPrevious = new decimal();
            this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious = new decimal();
            this.m__IZNOSOBRACUNANEPLACERSMBPrevious = new decimal();
            this.m__REDNIBROJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PREZIMEIIMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MBGOSIGURANIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAGRADARADAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DOOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZNOSOBRACUNANEPLACERSMBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZNOSOSNOVICEZADOPRINOSERSMBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MIO1RSMBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MIO2RSMBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZNOSISPLACENEPLACERSMBOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove51 = false;
            this.m__IZNOSOSNOVICEZADOPRINOSEPrevious = new decimal();
            this.m__MIO2Previous = new decimal();
            this.m__IZNOSOBRACUNANEPLACEPrevious = new decimal();
            this.m__MIO1Previous = new decimal();
            this.m__IZNOSISPLACENEPLACEPrevious = new decimal();
            this._Condition = false;
            this.RcdFound28 = 0;
            this.m_SubSelTopString28 = "";
            this.m__MBOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MBGOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAZIVOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ADRESAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__mjesecoBRACUNArsmOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__godinaobracunarsmOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJOSIGURANIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__mjesecisplatersmOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__godinaisplatersmOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDRSVRSTEOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDRSVRSTEOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDOBRACUNOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RSMASet = new RSMADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRsma()
        {
            this.CheckOptimisticConcurrencyRsma();
            this.CheckExtendedTableRsma();
            this.AfterConfirmRsma();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RSMA] ([IDENTIFIKATOROBRASCA], [MBOBVEZNIKA], [MBGOBVEZNIKA], [NAZIVOBVEZNIKA], [ADRESA], [mjesecoBRACUNArsm], [godinaobracunarsm], [BROJOSIGURANIKA], [mjesecisplatersm], [godinaisplatersm], [IDRSVRSTEOBVEZNIKA], [IDRSVRSTEOBRACUNA], [IDOBRACUN]) VALUES (@IDENTIFIKATOROBRASCA, @MBOBVEZNIKA, @MBGOBVEZNIKA, @NAZIVOBVEZNIKA, @ADRESA, @mjesecoBRACUNArsm, @godinaobracunarsm, @BROJOSIGURANIKA, @mjesecisplatersm, @godinaisplatersm, @IDRSVRSTEOBVEZNIKA, @IDRSVRSTEOBRACUNA, @IDOBRACUN)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBOBVEZNIKA", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBGOBVEZNIKA", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOBVEZNIKA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ADRESA", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesecoBRACUNArsm", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godinaobracunarsm", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJOSIGURANIKA", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesecisplatersm", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godinaisplatersm", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDENTIFIKATOROBRASCA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSMA["MBOBVEZNIKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRSMA["MBGOBVEZNIKA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRSMA["NAZIVOBVEZNIKA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRSMA["ADRESA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRSMA["mjesecoBRACUNArsm"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRSMA["godinaobracunarsm"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRSMA["BROJOSIGURANIKA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRSMA["mjesecisplatersm"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRSMA["godinaisplatersm"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDOBRACUN"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RSMADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRsma();
            }
            this.OnRSMAUpdated(new RSMAEventArgs(this.rowRSMA, StatementType.Insert));
            this.ProcessLevelRsma();
        }

        private void InsertRsma1()
        {
            this.CheckOptimisticConcurrencyRsma1();
            this.CheckExtendedTableRsma1();
            this.AfterConfirmRsma1();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RSMA1] ([IDENTIFIKATOROBRASCA], [ID], [REDNIBROJ], [PREZIMEIIME], [MBGOSIGURANIKA], [SIFRAGRADARADA], [OO], [B], [OD], [DOO], [IZNOSOBRACUNANEPLACERSMB], [IZNOSOSNOVICEZADOPRINOSERSMB], [MIO1RSMB], [MIO2RSMB], [IZNOSISPLACENEPLACERSMB]) VALUES (@IDENTIFIKATOROBRASCA, @ID, @REDNIBROJ, @PREZIMEIIME, @MBGOSIGURANIKA, @SIFRAGRADARADA, @OO, @B, @OD, @DOO, @IZNOSOBRACUNANEPLACERSMB, @IZNOSOSNOVICEZADOPRINOSERSMB, @MIO1RSMB, @MIO2RSMB, @IZNOSISPLACENEPLACERSMB)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@REDNIBROJ", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PREZIMEIIME", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBGOSIGURANIKA", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAGRADARADA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@B", DbType.String, 1));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OD", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSOBRACUNANEPLACERSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSOSNOVICEZADOPRINOSERSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MIO1RSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MIO2RSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSISPLACENEPLACERSMB", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IDENTIFIKATOROBRASCA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSMA1["ID"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRSMA1["REDNIBROJ"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRSMA1["PREZIMEIIME"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRSMA1["MBGOSIGURANIKA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRSMA1["SIFRAGRADARADA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRSMA1["OO"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRSMA1["B"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRSMA1["OD"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRSMA1["DOO"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOBRACUNANEPLACERSMB"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOSNOVICEZADOPRINOSERSMB"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO1RSMB"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO2RSMB"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSISPLACENEPLACERSMB"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RSMA1DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRSMA1Updated(new RSMA1EventArgs(this.rowRSMA1, StatementType.Insert));
        }

        private void LoadByIDENTIFIKATOROBRASCA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RSMASet.EnforceConstraints;
            this.RSMASet.RSMA1.BeginLoadData();
            this.RSMASet.RSMA.BeginLoadData();
            this.ScanByIDENTIFIKATOROBRASCA(startRow, maxRows);
            this.RSMASet.RSMA1.EndLoadData();
            this.RSMASet.RSMA.EndLoadData();
            this.RSMASet.EnforceConstraints = enforceConstraints;
            if (this.RSMASet.RSMA.Count > 0)
            {
                this.rowRSMA = this.RSMASet.RSMA[this.RSMASet.RSMA.Count - 1];
            }
        }

        private void LoadByIDOBRACUN(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RSMASet.EnforceConstraints;
            this.RSMASet.RSMA1.BeginLoadData();
            this.RSMASet.RSMA.BeginLoadData();
            this.ScanByIDOBRACUN(startRow, maxRows);
            this.RSMASet.RSMA1.EndLoadData();
            this.RSMASet.RSMA.EndLoadData();
            this.RSMASet.EnforceConstraints = enforceConstraints;
            if (this.RSMASet.RSMA.Count > 0)
            {
                this.rowRSMA = this.RSMASet.RSMA[this.RSMASet.RSMA.Count - 1];
            }
        }

        private void LoadByIDRSVRSTEOBRACUNA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RSMASet.EnforceConstraints;
            this.RSMASet.RSMA1.BeginLoadData();
            this.RSMASet.RSMA.BeginLoadData();
            this.ScanByIDRSVRSTEOBRACUNA(startRow, maxRows);
            this.RSMASet.RSMA1.EndLoadData();
            this.RSMASet.RSMA.EndLoadData();
            this.RSMASet.EnforceConstraints = enforceConstraints;
            if (this.RSMASet.RSMA.Count > 0)
            {
                this.rowRSMA = this.RSMASet.RSMA[this.RSMASet.RSMA.Count - 1];
            }
        }

        private void LoadByIDRSVRSTEOBVEZNIKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RSMASet.EnforceConstraints;
            this.RSMASet.RSMA1.BeginLoadData();
            this.RSMASet.RSMA.BeginLoadData();
            this.ScanByIDRSVRSTEOBVEZNIKA(startRow, maxRows);
            this.RSMASet.RSMA1.EndLoadData();
            this.RSMASet.RSMA.EndLoadData();
            this.RSMASet.EnforceConstraints = enforceConstraints;
            if (this.RSMASet.RSMA.Count > 0)
            {
                this.rowRSMA = this.RSMASet.RSMA[this.RSMASet.RSMA.Count - 1];
            }
        }

        private void LoadChildRsma(int startRow, int maxRows)
        {
            this.CreateNewRowRsma();
            bool enforceConstraints = this.RSMASet.EnforceConstraints;
            this.RSMASet.RSMA1.BeginLoadData();
            this.RSMASet.RSMA.BeginLoadData();
            this.ScanStartRsma(startRow, maxRows);
            this.RSMASet.RSMA1.EndLoadData();
            this.RSMASet.RSMA.EndLoadData();
            this.RSMASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildRsma1()
        {
            this.CreateNewRowRsma1();
            this.ScanStartRsma1();
        }

        private void LoadDataRsma(int maxRows)
        {
            int num = 0;
            if (this.RcdFound27 != 0)
            {
                this.ScanLoadRsma();
                while ((this.RcdFound27 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRsma();
                    this.CreateNewRowRsma();
                    this.ScanNextRsma();
                }
            }
            if (num > 0)
            {
                this.RcdFound27 = 1;
            }
            this.ScanEndRsma();
            if (this.RSMASet.RSMA.Count > 0)
            {
                this.rowRSMA = this.RSMASet.RSMA[this.RSMASet.RSMA.Count - 1];
            }
        }

        private void LoadDataRsma1()
        {
            while (this.RcdFound28 != 0)
            {
                this.LoadRowRsma1();
                this.CreateNewRowRsma1();
                this.ScanNextRsma1();
            }
            this.ScanEndRsma1();
        }

        private void LoadRowRsma()
        {
            this.OnLoadActionsRsma();
            this.AddRowRsma();
        }

        private void LoadRowRsma1()
        {
            this.OnLoadActionsRsma1();
            this.AddRowRsma1();
        }

        private void LoadRsma()
        {
            this.GetIZNOSOBRACUNANEPLACE(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__IZNOSOBRACUNANEPLACEPrevious = this.m_IZNOSOBRACUNANEPLACE;
            this.m__IZNOSOSNOVICEZADOPRINOSEPrevious = this.m_IZNOSOSNOVICEZADOPRINOSE;
            this.GetMIO1(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__MIO1Previous = this.m_MIO1;
            this.m__MIO2Previous = this.m_MIO2;
            this.GetIZNOSISPLACENEPLACE(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__IZNOSISPLACENEPLACEPrevious = this.m_IZNOSISPLACENEPLACE;
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVRSVRSTEOBVEZNIKA] FROM [RSVRSTEOBVEZNIKA] WITH (NOLOCK) WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowRSMA["NAZIVRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVRSVRSTEOBRACUNA] FROM [RSVRSTEOBRACUNA] WITH (NOLOCK) WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRSMA["NAZIVRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsRsma()
        {
            this.GetIZNOSOBRACUNANEPLACE(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.GetMIO1(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.GetIZNOSISPLACENEPLACE(this.rowRSMA.IDENTIFIKATOROBRASCA);
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [NAZIVRSVRSTEOBVEZNIKA] FROM [RSVRSTEOBVEZNIKA] WITH (NOLOCK) WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                this.rowRSMA["NAZIVRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader2, 0));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVRSVRSTEOBRACUNA] FROM [RSVRSTEOBRACUNA] WITH (NOLOCK) WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowRSMA["NAZIVRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsRsma1()
        {
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_IZNOSOBRACUNANEPLACE = decimal.Add(this.m__IZNOSOBRACUNANEPLACEPrevious, this.rowRSMA1.IZNOSOBRACUNANEPLACERSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_IZNOSOBRACUNANEPLACE = decimal.Subtract(decimal.Add(this.m__IZNOSOBRACUNANEPLACEPrevious, this.rowRSMA1.IZNOSOBRACUNANEPLACERSMB), this.m__IZNOSOBRACUNANEPLACERSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_IZNOSOBRACUNANEPLACE = decimal.Subtract(this.m__IZNOSOBRACUNANEPLACEPrevious, this.m__IZNOSOBRACUNANEPLACERSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Add(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.rowRSMA1.IZNOSOSNOVICEZADOPRINOSERSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Subtract(decimal.Add(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.rowRSMA1.IZNOSOSNOVICEZADOPRINOSERSMB), this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Subtract(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_MIO1 = decimal.Add(this.m__MIO1Previous, this.rowRSMA1.MIO1RSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_MIO1 = decimal.Subtract(decimal.Add(this.m__MIO1Previous, this.rowRSMA1.MIO1RSMB), this.m__MIO1RSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_MIO1 = decimal.Subtract(this.m__MIO1Previous, this.m__MIO1RSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_MIO2 = decimal.Add(this.m__MIO2Previous, this.rowRSMA1.MIO2RSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_MIO2 = decimal.Subtract(decimal.Add(this.m__MIO2Previous, this.rowRSMA1.MIO2RSMB), this.m__MIO2RSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_MIO2 = decimal.Subtract(this.m__MIO2Previous, this.m__MIO2RSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_IZNOSISPLACENEPLACE = decimal.Add(this.m__IZNOSISPLACENEPLACEPrevious, this.rowRSMA1.IZNOSISPLACENEPLACERSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_IZNOSISPLACENEPLACE = decimal.Subtract(decimal.Add(this.m__IZNOSISPLACENEPLACEPrevious, this.rowRSMA1.IZNOSISPLACENEPLACERSMB), this.m__IZNOSISPLACENEPLACERSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_IZNOSISPLACENEPLACE = decimal.Subtract(this.m__IZNOSISPLACENEPLACEPrevious, this.m__IZNOSISPLACENEPLACERSMBPrevious);
            }
        }

        private void OnLoadActionsRsma()
        {
            this.GetIZNOSOBRACUNANEPLACE(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__IZNOSOBRACUNANEPLACEPrevious = this.m_IZNOSOBRACUNANEPLACE;
            this.m__IZNOSOSNOVICEZADOPRINOSEPrevious = this.m_IZNOSOSNOVICEZADOPRINOSE;
            this.GetMIO1(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__MIO1Previous = this.m_MIO1;
            this.m__MIO2Previous = this.m_MIO2;
            this.GetIZNOSISPLACENEPLACE(this.rowRSMA.IDENTIFIKATOROBRASCA);
            this.m__IZNOSISPLACENEPLACEPrevious = this.m_IZNOSISPLACENEPLACE;
        }

        private void OnLoadActionsRsma1()
        {
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Add(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.rowRSMA1.IZNOSOSNOVICEZADOPRINOSERSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Subtract(decimal.Add(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.rowRSMA1.IZNOSOSNOVICEZADOPRINOSERSMB), this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_IZNOSOSNOVICEZADOPRINOSE = decimal.Subtract(this.m__IZNOSOSNOVICEZADOPRINOSEPrevious, this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious);
            }
            if (this.Gx_mode == StatementType.Insert)
            {
                this.m_MIO2 = decimal.Add(this.m__MIO2Previous, this.rowRSMA1.MIO2RSMB);
            }
            else if (this.Gx_mode == StatementType.Update)
            {
                this.m_MIO2 = decimal.Subtract(decimal.Add(this.m__MIO2Previous, this.rowRSMA1.MIO2RSMB), this.m__MIO2RSMBPrevious);
            }
            else if (this.Gx_mode == StatementType.Delete)
            {
                this.m_MIO2 = decimal.Subtract(this.m__MIO2Previous, this.m__MIO2RSMBPrevious);
            }
        }

        private void OnRSMA1Updated(RSMA1EventArgs e)
        {
            if (this.RSMA1Updated != null)
            {
                RSMA1UpdateEventHandler handler = this.RSMA1Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRSMA1Updating(RSMA1EventArgs e)
        {
            if (this.RSMA1Updating != null)
            {
                RSMA1UpdateEventHandler handler = this.RSMA1Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRSMAUpdated(RSMAEventArgs e)
        {
            if (this.RSMAUpdated != null)
            {
                RSMAUpdateEventHandler rSMAUpdatedEvent = this.RSMAUpdated;
                if (rSMAUpdatedEvent != null)
                {
                    rSMAUpdatedEvent(this, e);
                }
            }
        }

        private void OnRSMAUpdating(RSMAEventArgs e)
        {
            if (this.RSMAUpdating != null)
            {
                RSMAUpdateEventHandler rSMAUpdatingEvent = this.RSMAUpdating;
                if (rSMAUpdatingEvent != null)
                {
                    rSMAUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelRsma()
        {
            this.sMode27 = this.Gx_mode;
            this.ProcessNestedLevelRsma1();
            this.Gx_mode = this.sMode27;
        }

        private void ProcessNestedLevelRsma1()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.RSMASet.RSMA1.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowRSMA1 = (RSMADataSet.RSMA1Row) current;
                    if (Helpers.IsRowChanged(this.rowRSMA1))
                    {
                        bool flag = false;
                        if (this.rowRSMA1.RowState != DataRowState.Deleted)
                        {
                            flag = string.Compare(this.rowRSMA1.IDENTIFIKATOROBRASCA.TrimEnd(new char[] { ' ' }), this.rowRSMA.IDENTIFIKATOROBRASCA.TrimEnd(new char[] { ' ' }), false, CultureInfo.CurrentCulture) == 0;
                        }
                        else
                        {
                            flag = this.rowRSMA1["IDENTIFIKATOROBRASCA", DataRowVersion.Original].Equals(this.rowRSMA.IDENTIFIKATOROBRASCA);
                        }
                        if (flag)
                        {
                            this.ReadRowRsma1();
                            if (this.rowRSMA1.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertRsma1();
                            }
                            else if (this._Gxremove51)
                            {
                                this.Gx_mode = StatementType.Delete;
                                this.DeleteRsma1();
                            }
                            else
                            {
                                this.Gx_mode = StatementType.Update;
                                this.UpdateRsma1();
                            }
                            this.m__IZNOSISPLACENEPLACEPrevious = this.m_IZNOSISPLACENEPLACE;
                            this.m__MIO2Previous = this.m_MIO2;
                            this.m__MIO1Previous = this.m_MIO1;
                            this.m__IZNOSOSNOVICEZADOPRINOSEPrevious = this.m_IZNOSOSNOVICEZADOPRINOSE;
                            this.m__IZNOSOBRACUNANEPLACEPrevious = this.m_IZNOSOBRACUNANEPLACE;
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

        private void ReadRowRsma()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRSMA.RowState);
            if (this.rowRSMA.RowState != DataRowState.Added)
            {
                this.m__IZNOSISPLACENEPLACEPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA["IZNOSISPLACENEPLACE", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IZNOSISPLACENEPLACE", DataRowVersion.Original])));
                this.m__MIO2Previous = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA["MIO2", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA["MIO2", DataRowVersion.Original])));
                this.m__MIO1Previous = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA["MIO1", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA["MIO1", DataRowVersion.Original])));
                this.m__IZNOSOSNOVICEZADOPRINOSEPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA["IZNOSOSNOVICEZADOPRINOSE", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IZNOSOSNOVICEZADOPRINOSE", DataRowVersion.Original])));
                this.m__IZNOSOBRACUNANEPLACEPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA["IZNOSOBRACUNANEPLACE", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IZNOSOBRACUNANEPLACE", DataRowVersion.Original])));
                this.m__MBOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["MBOBVEZNIKA", DataRowVersion.Original]);
                this.m__MBGOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["MBGOBVEZNIKA", DataRowVersion.Original]);
                this.m__NAZIVOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["NAZIVOBVEZNIKA", DataRowVersion.Original]);
                this.m__ADRESAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["ADRESA", DataRowVersion.Original]);
                this.m__mjesecoBRACUNArsmOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["mjesecoBRACUNArsm", DataRowVersion.Original]);
                this.m__godinaobracunarsmOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["godinaobracunarsm", DataRowVersion.Original]);
                this.m__BROJOSIGURANIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["BROJOSIGURANIKA", DataRowVersion.Original]);
                this.m__mjesecisplatersmOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["mjesecisplatersm", DataRowVersion.Original]);
                this.m__godinaisplatersmOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["godinaisplatersm", DataRowVersion.Original]);
                this.m__IDRSVRSTEOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA", DataRowVersion.Original]);
                this.m__IDRSVRSTEOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA", DataRowVersion.Original]);
                this.m__IDOBRACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["IDOBRACUN", DataRowVersion.Original]);
            }
            else
            {
                this.m__MBOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["MBOBVEZNIKA"]);
                this.m__MBGOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["MBGOBVEZNIKA"]);
                this.m__NAZIVOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["NAZIVOBVEZNIKA"]);
                this.m__ADRESAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["ADRESA"]);
                this.m__mjesecoBRACUNArsmOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["mjesecoBRACUNArsm"]);
                this.m__godinaobracunarsmOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["godinaobracunarsm"]);
                this.m__BROJOSIGURANIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["BROJOSIGURANIKA"]);
                this.m__mjesecisplatersmOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["mjesecisplatersm"]);
                this.m__godinaisplatersmOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["godinaisplatersm"]);
                this.m__IDRSVRSTEOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA"]);
                this.m__IDRSVRSTEOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA"]);
                this.m__IDOBRACUNOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA["IDOBRACUN"]);
            }
            this._Gxremove = this.rowRSMA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRSMA = (RSMADataSet.RSMARow) DataSetUtil.CloneOriginalDataRow(this.rowRSMA);
            }
        }

        private void ReadRowRsma1()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRSMA1.RowState);
            if (this.rowRSMA1.RowState != DataRowState.Added)
            {
                this.m__IZNOSISPLACENEPLACERSMBPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA1["IZNOSISPLACENEPLACERSMB", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSISPLACENEPLACERSMB", DataRowVersion.Original])));
                this.m__MIO2RSMBPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA1["MIO2RSMB", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO2RSMB", DataRowVersion.Original])));
                this.m__MIO1RSMBPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA1["MIO1RSMB", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO1RSMB", DataRowVersion.Original])));
                this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA1["IZNOSOSNOVICEZADOPRINOSERSMB", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOSNOVICEZADOPRINOSERSMB", DataRowVersion.Original])));
                this.m__IZNOSOBRACUNANEPLACERSMBPrevious = Conversions.ToDecimal(Interaction.IIf(this.rowRSMA1["IZNOSOBRACUNANEPLACERSMB", DataRowVersion.Original] == Convert.DBNull, 0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOBRACUNANEPLACERSMB", DataRowVersion.Original])));
                this.m__REDNIBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["REDNIBROJ", DataRowVersion.Original]);
                this.m__PREZIMEIIMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["PREZIMEIIME", DataRowVersion.Original]);
                this.m__MBGOSIGURANIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["MBGOSIGURANIKA", DataRowVersion.Original]);
                this.m__SIFRAGRADARADAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["SIFRAGRADARADA", DataRowVersion.Original]);
                this.m__OOOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["OO", DataRowVersion.Original]);
                this.m__BOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["B", DataRowVersion.Original]);
                this.m__ODOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["OD", DataRowVersion.Original]);
                this.m__DOOOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["DOO", DataRowVersion.Original]);
                this.m__IZNOSOBRACUNANEPLACERSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOBRACUNANEPLACERSMB", DataRowVersion.Original]);
                this.m__IZNOSOSNOVICEZADOPRINOSERSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOSNOVICEZADOPRINOSERSMB", DataRowVersion.Original]);
                this.m__MIO1RSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO1RSMB", DataRowVersion.Original]);
                this.m__MIO2RSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO2RSMB", DataRowVersion.Original]);
                this.m__IZNOSISPLACENEPLACERSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSISPLACENEPLACERSMB", DataRowVersion.Original]);
            }
            else
            {
                this.m__IZNOSISPLACENEPLACERSMBPrevious = new decimal();
                this.m__MIO2RSMBPrevious = new decimal();
                this.m__MIO1RSMBPrevious = new decimal();
                this.m__IZNOSOSNOVICEZADOPRINOSERSMBPrevious = new decimal();
                this.m__IZNOSOBRACUNANEPLACERSMBPrevious = new decimal();
                this.m__REDNIBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["REDNIBROJ"]);
                this.m__PREZIMEIIMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["PREZIMEIIME"]);
                this.m__MBGOSIGURANIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["MBGOSIGURANIKA"]);
                this.m__SIFRAGRADARADAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["SIFRAGRADARADA"]);
                this.m__OOOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["OO"]);
                this.m__BOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["B"]);
                this.m__ODOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["OD"]);
                this.m__DOOOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["DOO"]);
                this.m__IZNOSOBRACUNANEPLACERSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOBRACUNANEPLACERSMB"]);
                this.m__IZNOSOSNOVICEZADOPRINOSERSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOSNOVICEZADOPRINOSERSMB"]);
                this.m__MIO1RSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO1RSMB"]);
                this.m__MIO2RSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO2RSMB"]);
                this.m__IZNOSISPLACENEPLACERSMBOriginal = RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSISPLACENEPLACERSMB"]);
            }
            this._Gxremove51 = this.rowRSMA1.RowState == DataRowState.Deleted;
            if (this._Gxremove51)
            {
                this.rowRSMA1 = (RSMADataSet.RSMA1Row) DataSetUtil.CloneOriginalDataRow(this.rowRSMA1);
            }
        }

        private void ScanByIDENTIFIKATOROBRASCA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString27 + "  FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString27, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDENTIFIKATOROBRASCA] ) AS DK_PAGENUM   FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString27 + " FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA] ";
            }
            this.cmRSMASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRSMASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            this.cmRSMASelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDENTIFIKATOROBRASCA"]));
            this.RSMASelect7 = this.cmRSMASelect7.FetchData();
            this.RcdFound27 = 0;
            this.ScanLoadRsma();
            this.LoadDataRsma(maxRows);
            if (this.RcdFound27 > 0)
            {
                this.SubLvlScanStartRsma1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDENTIFIKATOROBRASCARsma(this.cmRSMA1Select2);
                this.SubLvlFetchRsma1();
                this.SubLoadDataRsma1();
            }
        }

        private void ScanByIDOBRACUN(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOBRACUN] = @IDOBRACUN";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString27 + "  FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString27, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDENTIFIKATOROBRASCA] ) AS DK_PAGENUM   FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString27 + " FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA] ";
            }
            this.cmRSMASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRSMASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            this.cmRSMASelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDOBRACUN"]));
            this.RSMASelect7 = this.cmRSMASelect7.FetchData();
            this.RcdFound27 = 0;
            this.ScanLoadRsma();
            this.LoadDataRsma(maxRows);
            if (this.RcdFound27 > 0)
            {
                this.SubLvlScanStartRsma1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDOBRACUNRsma(this.cmRSMA1Select2);
                this.SubLvlFetchRsma1();
                this.SubLoadDataRsma1();
            }
        }

        private void ScanByIDRSVRSTEOBRACUNA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString27 + "  FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString27, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDENTIFIKATOROBRASCA] ) AS DK_PAGENUM   FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString27 + " FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA] ";
            }
            this.cmRSMASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRSMASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            this.cmRSMASelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA"]));
            this.RSMASelect7 = this.cmRSMASelect7.FetchData();
            this.RcdFound27 = 0;
            this.ScanLoadRsma();
            this.LoadDataRsma(maxRows);
            if (this.RcdFound27 > 0)
            {
                this.SubLvlScanStartRsma1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRSVRSTEOBRACUNARsma(this.cmRSMA1Select2);
                this.SubLvlFetchRsma1();
                this.SubLoadDataRsma1();
            }
        }

        private void ScanByIDRSVRSTEOBVEZNIKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString27 + "  FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString27, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDENTIFIKATOROBRASCA] ) AS DK_PAGENUM   FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString27 + " FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA] ";
            }
            this.cmRSMASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRSMASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            this.cmRSMASelect7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA"]));
            this.RSMASelect7 = this.cmRSMASelect7.FetchData();
            this.RcdFound27 = 0;
            this.ScanLoadRsma();
            this.LoadDataRsma(maxRows);
            if (this.RcdFound27 > 0)
            {
                this.SubLvlScanStartRsma1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDRSVRSTEOBVEZNIKARsma(this.cmRSMA1Select2);
                this.SubLvlFetchRsma1();
                this.SubLoadDataRsma1();
            }
        }

        private void ScanEndRsma()
        {
            this.RSMASelect7.Close();
        }

        private void ScanEndRsma1()
        {
            this.RSMA1Select2.Close();
        }

        private void ScanLoadRsma()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRSMASelect7.HasMoreRows)
            {
                this.RcdFound27 = 1;
                this.rowRSMA["IDENTIFIKATOROBRASCA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 0));
                this.rowRSMA["MBOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 1));
                this.rowRSMA["MBGOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 2));
                this.rowRSMA["NAZIVOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 3));
                this.rowRSMA["ADRESA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 4));
                this.rowRSMA["NAZIVRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 5));
                this.rowRSMA["NAZIVRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 6));
                this.rowRSMA["mjesecoBRACUNArsm"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 7));
                this.rowRSMA["godinaobracunarsm"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 8));
                this.rowRSMA["BROJOSIGURANIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 9));
                this.rowRSMA["mjesecisplatersm"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 10));
                this.rowRSMA["godinaisplatersm"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 11));
                this.rowRSMA["IDRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 12));
                this.rowRSMA["IDRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 13));
                this.rowRSMA["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 14));
                this.rowRSMA["NAZIVRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 5));
                this.rowRSMA["NAZIVRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMASelect7, 6));
            }
        }

        private void ScanLoadRsma1()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRSMA1Select2.HasMoreRows)
            {
                this.RcdFound28 = 1;
                this.rowRSMA1["IDENTIFIKATOROBRASCA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 0));
                this.rowRSMA1["ID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RSMA1Select2, 1));
                this.rowRSMA1["REDNIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 2));
                this.rowRSMA1["PREZIMEIIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 3));
                this.rowRSMA1["MBGOSIGURANIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 4));
                this.rowRSMA1["SIFRAGRADARADA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 5));
                this.rowRSMA1["OO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 6));
                this.rowRSMA1["B"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 7));
                this.rowRSMA1["OD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 8));
                this.rowRSMA1["DOO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSMA1Select2, 9));
                this.rowRSMA1["IZNOSOBRACUNANEPLACERSMB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RSMA1Select2, 10));
                this.rowRSMA1["IZNOSOSNOVICEZADOPRINOSERSMB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RSMA1Select2, 11));
                this.rowRSMA1["MIO1RSMB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RSMA1Select2, 12));
                this.rowRSMA1["MIO2RSMB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RSMA1Select2, 13));
                this.rowRSMA1["IZNOSISPLACENEPLACERSMB"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.RSMA1Select2, 14));
            }
        }

        private void ScanNextRsma()
        {
            this.cmRSMASelect7.HasMoreRows = this.RSMASelect7.Read();
            this.RcdFound27 = 0;
            this.ScanLoadRsma();
        }

        private void ScanNextRsma1()
        {
            this.cmRSMA1Select2.HasMoreRows = this.RSMA1Select2.Read();
            this.RcdFound28 = 0;
            this.ScanLoadRsma1();
        }

        private void ScanStartRsma(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString27 + "  FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString27, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDENTIFIKATOROBRASCA] ) AS DK_PAGENUM   FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString27 + " FROM (([RSMA] TM1 WITH (NOLOCK) INNER JOIN [RSVRSTEOBVEZNIKA] T2 WITH (NOLOCK) ON T2.[IDRSVRSTEOBVEZNIKA] = TM1.[IDRSVRSTEOBVEZNIKA]) INNER JOIN [RSVRSTEOBRACUNA] T3 WITH (NOLOCK) ON T3.[IDRSVRSTEOBRACUNA] = TM1.[IDRSVRSTEOBRACUNA])" + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA] ";
            }
            this.cmRSMASelect7 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RSMASelect7 = this.cmRSMASelect7.FetchData();
            this.RcdFound27 = 0;
            this.ScanLoadRsma();
            this.LoadDataRsma(maxRows);
            if (this.RcdFound27 > 0)
            {
                this.SubLvlScanStartRsma1(this.m_WhereString, startRow, maxRows);
                this.SetParametersRsmaRsma(this.cmRSMA1Select2);
                this.SubLvlFetchRsma1();
                this.SubLoadDataRsma1();
            }
        }

        private void ScanStartRsma1()
        {
            this.cmRSMA1Select2 = this.connDefault.GetCommand("SELECT [IDENTIFIKATOROBRASCA], [ID], [REDNIBROJ], [PREZIMEIIME], [MBGOSIGURANIKA], [SIFRAGRADARADA], [OO], [B], [OD], [DOO], [IZNOSOBRACUNANEPLACERSMB], [IZNOSOSNOVICEZADOPRINOSERSMB], [MIO1RSMB], [MIO2RSMB], [IZNOSISPLACENEPLACERSMB] FROM [RSMA1] WITH (NOLOCK) WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA ORDER BY [IDENTIFIKATOROBRASCA], [ID] ", false);
            if (this.cmRSMA1Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSMA1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            this.cmRSMA1Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IDENTIFIKATOROBRASCA"]));
            this.RSMA1Select2 = this.cmRSMA1Select2.FetchData();
            this.RcdFound28 = 0;
            this.ScanLoadRsma1();
        }

        private void SetParametersIDENTIFIKATOROBRASCARsma(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDENTIFIKATOROBRASCA"]));
        }

        private void SetParametersIDOBRACUNRsma(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDOBRACUN"]));
        }

        private void SetParametersIDRSVRSTEOBRACUNARsma(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA"]));
        }

        private void SetParametersIDRSVRSTEOBVEZNIKARsma(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA"]));
        }

        private void SetParametersRsmaRsma(ReadWriteCommand m_Command)
        {
        }

        private void SkipNextRsma1()
        {
            this.cmRSMA1Select2.HasMoreRows = this.RSMA1Select2.Read();
            this.RcdFound28 = 0;
            if (this.cmRSMA1Select2.HasMoreRows)
            {
                this.RcdFound28 = 1;
            }
        }

        private void SubLoadDataRsma1()
        {
            while (this.RcdFound28 != 0)
            {
                this.LoadRowRsma1();
                this.CreateNewRowRsma1();
                this.ScanNextRsma1();
            }
            this.ScanEndRsma1();
        }

        private void SubLvlFetchRsma1()
        {
            this.CreateNewRowRsma1();
            this.RSMA1Select2 = this.cmRSMA1Select2.FetchData();
            this.RcdFound28 = 0;
            this.ScanLoadRsma1();
        }

        private void SubLvlScanStartRsma1(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString28 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDENTIFIKATOROBRASCA]  FROM [RSMA]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDENTIFIKATOROBRASCA] )";
                    this.scmdbuf = "SELECT T1.[IDENTIFIKATOROBRASCA], T1.[ID], T1.[REDNIBROJ], T1.[PREZIMEIIME], T1.[MBGOSIGURANIKA], T1.[SIFRAGRADARADA], T1.[OO], T1.[B], T1.[OD], T1.[DOO], T1.[IZNOSOBRACUNANEPLACERSMB], T1.[IZNOSOSNOVICEZADOPRINOSERSMB], T1.[MIO1RSMB], T1.[MIO2RSMB], T1.[IZNOSISPLACENEPLACERSMB] FROM ([RSMA1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString28 + "  TMX ON TMX.[IDENTIFIKATOROBRASCA] = T1.[IDENTIFIKATOROBRASCA]) ORDER BY T1.[IDENTIFIKATOROBRASCA], T1.[ID]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDENTIFIKATOROBRASCA], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDENTIFIKATOROBRASCA]  ) AS DK_PAGENUM   FROM [RSMA]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString28 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDENTIFIKATOROBRASCA], T1.[ID], T1.[REDNIBROJ], T1.[PREZIMEIIME], T1.[MBGOSIGURANIKA], T1.[SIFRAGRADARADA], T1.[OO], T1.[B], T1.[OD], T1.[DOO], T1.[IZNOSOBRACUNANEPLACERSMB], T1.[IZNOSOSNOVICEZADOPRINOSERSMB], T1.[MIO1RSMB], T1.[MIO2RSMB], T1.[IZNOSISPLACENEPLACERSMB] FROM ([RSMA1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString28 + "  TMX ON TMX.[IDENTIFIKATOROBRASCA] = T1.[IDENTIFIKATOROBRASCA]) ORDER BY T1.[IDENTIFIKATOROBRASCA], T1.[ID]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString28 = "[RSMA]";
                this.scmdbuf = "SELECT T1.[IDENTIFIKATOROBRASCA], T1.[ID], T1.[REDNIBROJ], T1.[PREZIMEIIME], T1.[MBGOSIGURANIKA], T1.[SIFRAGRADARADA], T1.[OO], T1.[B], T1.[OD], T1.[DOO], T1.[IZNOSOBRACUNANEPLACERSMB], T1.[IZNOSOSNOVICEZADOPRINOSERSMB], T1.[MIO1RSMB], T1.[MIO2RSMB], T1.[IZNOSISPLACENEPLACERSMB] FROM ([RSMA1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString28 + "  TM1 WITH (NOLOCK) ON TM1.[IDENTIFIKATOROBRASCA] = T1.[IDENTIFIKATOROBRASCA])" + this.m_WhereString + " ORDER BY T1.[IDENTIFIKATOROBRASCA], T1.[ID] ";
            }
            this.cmRSMA1Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RSMASet = (RSMADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RSMASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RSMASet.RSMA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RSMADataSet.RSMARow current = (RSMADataSet.RSMARow) enumerator.Current;
                        this.rowRSMA = current;
                        if (Helpers.IsRowChanged(this.rowRSMA))
                        {
                            this.ReadRowRsma();
                            if (this.rowRSMA.RowState == DataRowState.Added)
                            {
                                this.InsertRsma();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRsma();
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

        private void UpdateRsma()
        {
            this.CheckOptimisticConcurrencyRsma();
            this.CheckExtendedTableRsma();
            this.AfterConfirmRsma();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RSMA] SET [MBOBVEZNIKA]=@MBOBVEZNIKA, [MBGOBVEZNIKA]=@MBGOBVEZNIKA, [NAZIVOBVEZNIKA]=@NAZIVOBVEZNIKA, [ADRESA]=@ADRESA, [mjesecoBRACUNArsm]=@mjesecoBRACUNArsm, [godinaobracunarsm]=@godinaobracunarsm, [BROJOSIGURANIKA]=@BROJOSIGURANIKA, [mjesecisplatersm]=@mjesecisplatersm, [godinaisplatersm]=@godinaisplatersm, [IDRSVRSTEOBVEZNIKA]=@IDRSVRSTEOBVEZNIKA, [IDRSVRSTEOBRACUNA]=@IDRSVRSTEOBRACUNA, [IDOBRACUN]=@IDOBRACUN  WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBOBVEZNIKA", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBGOBVEZNIKA", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOBVEZNIKA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ADRESA", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesecoBRACUNArsm", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godinaobracunarsm", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJOSIGURANIKA", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesecisplatersm", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godinaisplatersm", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA["MBOBVEZNIKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSMA["MBGOBVEZNIKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRSMA["NAZIVOBVEZNIKA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRSMA["ADRESA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRSMA["mjesecoBRACUNArsm"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRSMA["godinaobracunarsm"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRSMA["BROJOSIGURANIKA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRSMA["mjesecisplatersm"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRSMA["godinaisplatersm"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBVEZNIKA"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDRSVRSTEOBRACUNA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDOBRACUN"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRSMA["IDENTIFIKATOROBRASCA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRsma();
            }
            this.OnRSMAUpdated(new RSMAEventArgs(this.rowRSMA, StatementType.Update));
            this.ProcessLevelRsma();
        }

        private void UpdateRsma1()
        {
            this.CheckOptimisticConcurrencyRsma1();
            this.CheckExtendedTableRsma1();
            this.AfterConfirmRsma1();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RSMA1] SET [REDNIBROJ]=@REDNIBROJ, [PREZIMEIIME]=@PREZIMEIIME, [MBGOSIGURANIKA]=@MBGOSIGURANIKA, [SIFRAGRADARADA]=@SIFRAGRADARADA, [OO]=@OO, [B]=@B, [OD]=@OD, [DOO]=@DOO, [IZNOSOBRACUNANEPLACERSMB]=@IZNOSOBRACUNANEPLACERSMB, [IZNOSOSNOVICEZADOPRINOSERSMB]=@IZNOSOSNOVICEZADOPRINOSERSMB, [MIO1RSMB]=@MIO1RSMB, [MIO2RSMB]=@MIO2RSMB, [IZNOSISPLACENEPLACERSMB]=@IZNOSISPLACENEPLACERSMB  WHERE [IDENTIFIKATOROBRASCA] = @IDENTIFIKATOROBRASCA AND [ID] = @ID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@REDNIBROJ", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PREZIMEIIME", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MBGOSIGURANIKA", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAGRADARADA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@B", DbType.String, 1));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OD", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOO", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSOBRACUNANEPLACERSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSOSNOVICEZADOPRINOSERSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MIO1RSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MIO2RSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOSISPLACENEPLACERSMB", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDENTIFIKATOROBRASCA", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSMA1["REDNIBROJ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSMA1["PREZIMEIIME"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowRSMA1["MBGOSIGURANIKA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowRSMA1["SIFRAGRADARADA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowRSMA1["OO"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowRSMA1["B"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowRSMA1["OD"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowRSMA1["DOO"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOBRACUNANEPLACERSMB"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSOSNOVICEZADOPRINOSERSMB"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO1RSMB"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowRSMA1["MIO2RSMB"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IZNOSISPLACENEPLACERSMB"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowRSMA1["IDENTIFIKATOROBRASCA"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowRSMA1["ID"]));
            command.ExecuteStmt();
            this.OnRSMA1Updated(new RSMA1EventArgs(this.rowRSMA1, StatementType.Update));
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
        public class OBRACUNForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OBRACUNForeignKeyNotFoundException()
            {
            }

            public OBRACUNForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OBRACUNForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSMA1DataChangedException : DataChangedException
        {
            public RSMA1DataChangedException()
            {
            }

            public RSMA1DataChangedException(string message) : base(message)
            {
            }

            protected RSMA1DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMA1DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSMA1DataLockedException : DataLockedException
        {
            public RSMA1DataLockedException()
            {
            }

            public RSMA1DataLockedException(string message) : base(message)
            {
            }

            protected RSMA1DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMA1DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSMA1DuplicateKeyException : DuplicateKeyException
        {
            public RSMA1DuplicateKeyException()
            {
            }

            public RSMA1DuplicateKeyException(string message) : base(message)
            {
            }

            protected RSMA1DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMA1DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RSMA1EventArgs : EventArgs
        {
            private RSMADataSet.RSMA1Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public RSMA1EventArgs(RSMADataSet.RSMA1Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RSMADataSet.RSMA1Row Row
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

        public delegate void RSMA1UpdateEventHandler(object sender, RSMADataAdapter.RSMA1EventArgs e);

        [Serializable]
        public class RSMADataChangedException : DataChangedException
        {
            public RSMADataChangedException()
            {
            }

            public RSMADataChangedException(string message) : base(message)
            {
            }

            protected RSMADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSMADataLockedException : DataLockedException
        {
            public RSMADataLockedException()
            {
            }

            public RSMADataLockedException(string message) : base(message)
            {
            }

            protected RSMADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSMADuplicateKeyException : DuplicateKeyException
        {
            public RSMADuplicateKeyException()
            {
            }

            public RSMADuplicateKeyException(string message) : base(message)
            {
            }

            protected RSMADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RSMAEventArgs : EventArgs
        {
            private RSMADataSet.RSMARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RSMAEventArgs(RSMADataSet.RSMARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RSMADataSet.RSMARow Row
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
        public class RSMANotFoundException : DataNotFoundException
        {
            public RSMANotFoundException()
            {
            }

            public RSMANotFoundException(string message) : base(message)
            {
            }

            protected RSMANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RSMAUpdateEventHandler(object sender, RSMADataAdapter.RSMAEventArgs e);

        [Serializable]
        public class RSVRSTEOBRACUNAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RSVRSTEOBRACUNAForeignKeyNotFoundException()
            {
            }

            public RSVRSTEOBRACUNAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RSVRSTEOBRACUNAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBRACUNAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSVRSTEOBVEZNIKAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RSVRSTEOBVEZNIKAForeignKeyNotFoundException()
            {
            }

            public RSVRSTEOBVEZNIKAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RSVRSTEOBVEZNIKAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBVEZNIKAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

