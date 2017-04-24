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

    public class PRPLACEDataAdapter : IDataAdapter, IPRPLACEDataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove29;
        private ReadWriteCommand cmPRPLACEPRPLACEELEMENTIRADNIKSelect2;
        private ReadWriteCommand cmPRPLACEPRPLACEELEMENTISelect2;
        private ReadWriteCommand cmPRPLACESelect1;
        private ReadWriteCommand cmPRPLACESelect2;
        private ReadWriteCommand cmPRPLACESelect3;
        private ReadWriteCommand cmPRPLACESelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__PRPLACEIZNOSOriginal;
        private object m__PRPLACEOPISOriginal;
        private object m__PRPLACEOSNOVICAOriginal;
        private object m__PRPLACEPOSTOTAKOriginal;
        private object m__PRPLACEPROSJECNISATIOriginal;
        private object m__PRPLACESATIOriginal;
        private object m__PRPLACESATNICAOriginal;
        private readonly string m_SelectString131 = "TM1.[PRPLACEID], TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEZAGODINU], TM1.[PRPLACEOPIS], TM1.[PRPLACEOSNOVICA], TM1.[PRPLACEPROSJECNISATI]";
        private string m_SPOJENOPREZIME;
        private string m_SubSelTopString132;
        private string m_SubSelTopString133;
        private string m_WhereString;
        private IDataReader PRPLACEPRPLACEELEMENTIRADNIKSelect2;
        private IDataReader PRPLACEPRPLACEELEMENTISelect2;
        private IDataReader PRPLACESelect1;
        private IDataReader PRPLACESelect2;
        private IDataReader PRPLACESelect3;
        private IDataReader PRPLACESelect6;
        private PRPLACEDataSet PRPLACESet;
        private short RcdFound131;
        private short RcdFound132;
        private short RcdFound133;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private PRPLACEDataSet.PRPLACERow rowPRPLACE;
        private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow rowPRPLACEPRPLACEELEMENTI;
        private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow rowPRPLACEPRPLACEELEMENTIRADNIK;
        private string scmdbuf;
        private StatementType sMode131;
        private StatementType sMode132;
        private StatementType sMode133;

        public event PRPLACEPRPLACEELEMENTIRADNIKUpdateEventHandler PRPLACEPRPLACEELEMENTIRADNIKUpdated;

        public event PRPLACEPRPLACEELEMENTIRADNIKUpdateEventHandler PRPLACEPRPLACEELEMENTIRADNIKUpdating;

        public event PRPLACEPRPLACEELEMENTIUpdateEventHandler PRPLACEPRPLACEELEMENTIUpdated;

        public event PRPLACEPRPLACEELEMENTIUpdateEventHandler PRPLACEPRPLACEELEMENTIUpdating;

        public event PRPLACEUpdateEventHandler PRPLACEUpdated;

        public event PRPLACEUpdateEventHandler PRPLACEUpdating;

        private void AddRowPrplace()
        {
            this.PRPLACESet.PRPLACE.AddPRPLACERow(this.rowPRPLACE);
        }

        private void AddRowPrplaceprplaceelementi()
        {
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.AddPRPLACEPRPLACEELEMENTIRow(this.rowPRPLACEPRPLACEELEMENTI);
        }

        private void AddRowPrplaceprplaceelementiradnik()
        {
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.AddPRPLACEPRPLACEELEMENTIRADNIKRow(this.rowPRPLACEPRPLACEELEMENTIRADNIK);
        }

        private void AfterConfirmPrplace()
        {
            this.OnPRPLACEUpdating(new PRPLACEEventArgs(this.rowPRPLACE, this.Gx_mode));
        }

        private void AfterConfirmPrplaceprplaceelementi()
        {
            this.OnPRPLACEPRPLACEELEMENTIUpdating(new PRPLACEPRPLACEELEMENTIEventArgs(this.rowPRPLACEPRPLACEELEMENTI, this.Gx_mode));
        }

        private void AfterConfirmPrplaceprplaceelementiradnik()
        {
            this.OnPRPLACEPRPLACEELEMENTIRADNIKUpdating(new PRPLACEPRPLACEELEMENTIRADNIKEventArgs(this.rowPRPLACEPRPLACEELEMENTIRADNIK, this.Gx_mode));
        }

        private void CheckExtendedTablePrplaceprplaceelementi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT], [POSTOTAK] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            this.rowPRPLACEPRPLACEELEMENTI["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowPRPLACEPRPLACEELEMENTI["POSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            reader.Close();
        }

        private void CheckExtendedTablePrplaceprplaceelementiradnik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIME], [IME] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNIK") }));
            }
            this.rowPRPLACEPRPLACEELEMENTIRADNIK["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowPRPLACEPRPLACEELEMENTIRADNIK["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            reader.Close();
            if (!this.rowPRPLACEPRPLACEELEMENTIRADNIK.IsPREZIMENull() && !this.rowPRPLACEPRPLACEELEMENTIRADNIK.IsIMENull())
            {
                this.m_SPOJENOPREZIME = this.rowPRPLACEPRPLACEELEMENTIRADNIK.PREZIME + " " + this.rowPRPLACEPRPLACEELEMENTIRADNIK.IME;
            }
        }

        private void CheckOptimisticConcurrencyPrplace()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [PRPLACEOPIS], [PRPLACEOSNOVICA], [PRPLACEPROSJECNISATI] FROM [PRPLACE] WITH (UPDLOCK) WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAGODINU"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PRPLACEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PRPLACE") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRPLACEOPISOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!this.m__PRPLACEOSNOVICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4))) || !this.m__PRPLACEPROSJECNISATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5)))))
                {
                    reader.Close();
                    throw new PRPLACEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PRPLACE") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyPrplaceprplaceelementi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [IDELEMENT] FROM [PRPLACEPRPLACEELEMENTI] WITH (UPDLOCK) WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU AND [IDELEMENT] = @IDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEID"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAMJESEC"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAGODINU"]));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["IDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PRPLACEPRPLACEELEMENTIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PRPLACEPRPLACEELEMENTI") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new PRPLACEPRPLACEELEMENTIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PRPLACEPRPLACEELEMENTI") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyPrplaceprplaceelementiradnik()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [IDELEMENT], [PRPLACESATNICA], [PRPLACESATI], [PRPLACEIZNOS], [PRPLACEPOSTOTAK], [IDRADNIK] FROM [PRPLACEPRPLACEELEMENTIRADNIK] WITH (UPDLOCK) WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU AND [IDELEMENT] = @IDELEMENT AND [IDRADNIK] = @IDRADNIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEID"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAMJESEC"]));
                command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAGODINU"]));
                command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDELEMENT"]));
                command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDRADNIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PRPLACEPRPLACEELEMENTIRADNIKDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PRPLACEPRPLACEELEMENTIRADNIK") }));
                }
                if ((!command.HasMoreRows || !this.m__PRPLACESATNICAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4)))) || ((!this.m__PRPLACESATIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5))) || !this.m__PRPLACEIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 6)))) || !this.m__PRPLACEPOSTOTAKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 7)))))
                {
                    reader.Close();
                    throw new PRPLACEPRPLACEELEMENTIRADNIKDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PRPLACEPRPLACEELEMENTIRADNIK") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowPrplace()
        {
            this.rowPRPLACE = this.PRPLACESet.PRPLACE.NewPRPLACERow();
        }

        private void CreateNewRowPrplaceprplaceelementi()
        {
            this.rowPRPLACEPRPLACEELEMENTI = this.PRPLACESet.PRPLACEPRPLACEELEMENTI.NewPRPLACEPRPLACEELEMENTIRow();
        }

        private void CreateNewRowPrplaceprplaceelementiradnik()
        {
            this.rowPRPLACEPRPLACEELEMENTIRADNIK = this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.NewPRPLACEPRPLACEELEMENTIRADNIKRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPrplace();
            this.ProcessNestedLevelPrplaceprplaceelementi();
            this.AfterConfirmPrplace();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PRPLACE]  WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAGODINU"]));
            command.ExecuteStmt();
            this.OnPRPLACEUpdated(new PRPLACEEventArgs(this.rowPRPLACE, StatementType.Delete));
            this.rowPRPLACE.Delete();
            this.sMode131 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode131;
        }

        private void DeletePrplaceprplaceelementi()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPrplaceprplaceelementi();
            this.OnDeleteControlsPrplaceprplaceelementi();
            this.ProcessNestedLevelPrplaceprplaceelementiradnik();
            this.AfterConfirmPrplaceprplaceelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PRPLACEPRPLACEELEMENTI]  WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU AND [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAMJESEC"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAGODINU"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["IDELEMENT"]));
            command.ExecuteStmt();
            this.OnPRPLACEPRPLACEELEMENTIUpdated(new PRPLACEPRPLACEELEMENTIEventArgs(this.rowPRPLACEPRPLACEELEMENTI, StatementType.Delete));
            this.rowPRPLACEPRPLACEELEMENTI.Delete();
            this.sMode132 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode132;
        }

        private void DeletePrplaceprplaceelementiradnik()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPrplaceprplaceelementiradnik();
            this.OnDeleteControlsPrplaceprplaceelementiradnik();
            this.AfterConfirmPrplaceprplaceelementiradnik();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PRPLACEPRPLACEELEMENTIRADNIK]  WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU AND [IDELEMENT] = @IDELEMENT AND [IDRADNIK] = @IDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAMJESEC"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAGODINU"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDELEMENT"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDRADNIK"]));
            command.ExecuteStmt();
            this.OnPRPLACEPRPLACEELEMENTIRADNIKUpdated(new PRPLACEPRPLACEELEMENTIRADNIKEventArgs(this.rowPRPLACEPRPLACEELEMENTIRADNIK, StatementType.Delete));
            this.rowPRPLACEPRPLACEELEMENTIRADNIK.Delete();
            this.sMode133 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode133;
        }

        public virtual int Fill(PRPLACEDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, short.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), short.Parse(this.fillDataParameters[2].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.PRPLACESet = dataSet;
                    this.LoadChildPrplace(0, -1);
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
            this.PRPLACESet = (PRPLACEDataSet) dataSet;
            if (this.PRPLACESet != null)
            {
                return this.Fill(this.PRPLACESet);
            }
            this.PRPLACESet = new PRPLACEDataSet();
            this.Fill(this.PRPLACESet);
            dataSet.Merge(this.PRPLACESet);
            return 0;
        }

        public virtual int Fill(PRPLACEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["PRPLACEZAMJESEC"]), Conversions.ToInteger(dataRecord["PRPLACEID"]), Conversions.ToShort(dataRecord["PRPLACEZAGODINU"]));
        }

        public virtual int Fill(PRPLACEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["PRPLACEZAMJESEC"]), Conversions.ToInteger(dataRecord["PRPLACEID"]), Conversions.ToShort(dataRecord["PRPLACEZAGODINU"]));
        }

        public virtual int Fill(PRPLACEDataSet dataSet, short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU)
        {
            if (!this.FillByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(dataSet, pRPLACEZAMJESEC, pRPLACEID, pRPLACEZAGODINU))
            {
                throw new PRPLACENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PRPLACE") }));
            }
            return 0;
        }

        public virtual int FillByPRPLACEID(PRPLACEDataSet dataSet, int pRPLACEID)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PRPLACESet = dataSet;
            this.rowPRPLACE = this.PRPLACESet.PRPLACE.NewPRPLACERow();
            this.rowPRPLACE.PRPLACEID = pRPLACEID;
            try
            {
                this.LoadByPRPLACEID(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByPRPLACEIDPRPLACEZAMJESEC(PRPLACEDataSet dataSet, int pRPLACEID, short pRPLACEZAMJESEC)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PRPLACESet = dataSet;
            this.rowPRPLACE = this.PRPLACESet.PRPLACE.NewPRPLACERow();
            this.rowPRPLACE.PRPLACEID = pRPLACEID;
            this.rowPRPLACE.PRPLACEZAMJESEC = pRPLACEZAMJESEC;
            try
            {
                this.LoadByPRPLACEIDPRPLACEZAMJESEC(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(PRPLACEDataSet dataSet, short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PRPLACESet = dataSet;
            this.rowPRPLACE = this.PRPLACESet.PRPLACE.NewPRPLACERow();
            this.rowPRPLACE.PRPLACEZAMJESEC = pRPLACEZAMJESEC;
            this.rowPRPLACE.PRPLACEID = pRPLACEID;
            this.rowPRPLACE.PRPLACEZAGODINU = pRPLACEZAGODINU;
            try
            {
                this.LoadByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound131 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(PRPLACEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PRPLACESet = dataSet;
            try
            {
                this.LoadChildPrplace(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByPRPLACEID(PRPLACEDataSet dataSet, int pRPLACEID, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PRPLACESet = dataSet;
            this.rowPRPLACE = this.PRPLACESet.PRPLACE.NewPRPLACERow();
            this.rowPRPLACE.PRPLACEID = pRPLACEID;
            try
            {
                this.LoadByPRPLACEID(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByPRPLACEIDPRPLACEZAMJESEC(PRPLACEDataSet dataSet, int pRPLACEID, short pRPLACEZAMJESEC, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PRPLACESet = dataSet;
            this.rowPRPLACE = this.PRPLACESet.PRPLACE.NewPRPLACERow();
            this.rowPRPLACE.PRPLACEID = pRPLACEID;
            this.rowPRPLACE.PRPLACEZAMJESEC = pRPLACEZAMJESEC;
            try
            {
                this.LoadByPRPLACEIDPRPLACEZAMJESEC(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [PRPLACEOPIS], [PRPLACEOSNOVICA], [PRPLACEPROSJECNISATI] FROM [PRPLACE] WITH (NOLOCK) WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAGODINU"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound131 = 1;
                this.rowPRPLACE["PRPLACEID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowPRPLACE["PRPLACEZAMJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 1));
                this.rowPRPLACE["PRPLACEZAGODINU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 2));
                this.rowPRPLACE["PRPLACEOPIS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowPRPLACE["PRPLACEOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 4));
                this.rowPRPLACE["PRPLACEPROSJECNISATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 5));
                this.sMode131 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode131;
            }
            else
            {
                this.RcdFound131 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "PRPLACEID";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "PRPLACEZAMJESEC";
                parameter2.DbType = DbType.Int16;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "PRPLACEZAGODINU";
                parameter3.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPRPLACESelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PRPLACE] WITH (NOLOCK) ", false);
            this.PRPLACESelect3 = this.cmPRPLACESelect3.FetchData();
            if (this.PRPLACESelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PRPLACESelect3.GetInt32(0);
            }
            this.PRPLACESelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByPRPLACEID(int pRPLACEID)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPRPLACESelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PRPLACE] WITH (NOLOCK) WHERE [PRPLACEID] = @PRPLACEID ", false);
            if (this.cmPRPLACESelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
            }
            this.cmPRPLACESelect2.SetParameter(0, pRPLACEID);
            this.PRPLACESelect2 = this.cmPRPLACESelect2.FetchData();
            if (this.PRPLACESelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PRPLACESelect2.GetInt32(0);
            }
            this.PRPLACESelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByPRPLACEIDPRPLACEZAMJESEC(int pRPLACEID, short pRPLACEZAMJESEC)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPRPLACESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PRPLACE] WITH (NOLOCK) WHERE [PRPLACEID] = @PRPLACEID and [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC ", false);
            if (this.cmPRPLACESelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                this.cmPRPLACESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
            }
            this.cmPRPLACESelect1.SetParameter(0, pRPLACEID);
            this.cmPRPLACESelect1.SetParameter(1, pRPLACEZAMJESEC);
            this.PRPLACESelect1 = this.cmPRPLACESelect1.FetchData();
            if (this.PRPLACESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PRPLACESelect1.GetInt32(0);
            }
            this.PRPLACESelect1.Close();
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

        public virtual int GetRecordCountByPRPLACEID(int pRPLACEID)
        {
            int internalRecordCountByPRPLACEID;
            try
            {
                this.InitializeMembers();
                internalRecordCountByPRPLACEID = this.GetInternalRecordCountByPRPLACEID(pRPLACEID);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByPRPLACEID;
        }

        public virtual int GetRecordCountByPRPLACEIDPRPLACEZAMJESEC(int pRPLACEID, short pRPLACEZAMJESEC)
        {
            int internalRecordCountByPRPLACEIDPRPLACEZAMJESEC;
            try
            {
                this.InitializeMembers();
                internalRecordCountByPRPLACEIDPRPLACEZAMJESEC = this.GetInternalRecordCountByPRPLACEIDPRPLACEZAMJESEC(pRPLACEID, pRPLACEZAMJESEC);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByPRPLACEIDPRPLACEZAMJESEC;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound131 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_SPOJENOPREZIME = "";
            this.m__PRPLACESATNICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRPLACESATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRPLACEIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRPLACEPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove29 = false;
            this.RcdFound133 = 0;
            this.m_SubSelTopString133 = "";
            this.RcdFound132 = 0;
            this.m_SubSelTopString132 = "";
            this.m__PRPLACEOPISOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRPLACEOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRPLACEPROSJECNISATIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.PRPLACESet = new PRPLACEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertPrplace()
        {
            this.CheckOptimisticConcurrencyPrplace();
            this.AfterConfirmPrplace();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PRPLACE] ([PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [PRPLACEOPIS], [PRPLACEOSNOVICA], [PRPLACEPROSJECNISATI]) VALUES (@PRPLACEID, @PRPLACEZAMJESEC, @PRPLACEZAGODINU, @PRPLACEOPIS, @PRPLACEOSNOVICA, @PRPLACEPROSJECNISATI)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEOPIS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEPROSJECNISATI", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAGODINU"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEOPIS"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEOSNOVICA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEPROSJECNISATI"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PRPLACEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPRPLACEUpdated(new PRPLACEEventArgs(this.rowPRPLACE, StatementType.Insert));
            this.ProcessLevelPrplace();
        }

        private void InsertPrplaceprplaceelementi()
        {
            this.CheckOptimisticConcurrencyPrplaceprplaceelementi();
            this.CheckExtendedTablePrplaceprplaceelementi();
            this.AfterConfirmPrplaceprplaceelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PRPLACEPRPLACEELEMENTI] ([NAZIVELEMENT], [PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [IDELEMENT]) VALUES (@NAZIVELEMENT, @PRPLACEID, @PRPLACEZAMJESEC, @PRPLACEZAGODINU, @IDELEMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVELEMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["NAZIVELEMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEID"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAMJESEC"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAGODINU"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["IDELEMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PRPLACEPRPLACEELEMENTIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPRPLACEPRPLACEELEMENTIUpdated(new PRPLACEPRPLACEELEMENTIEventArgs(this.rowPRPLACEPRPLACEELEMENTI, StatementType.Insert));
            this.ProcessLevelPrplaceprplaceelementi();
        }

        private void InsertPrplaceprplaceelementiradnik()
        {
            this.CheckOptimisticConcurrencyPrplaceprplaceelementiradnik();
            this.CheckExtendedTablePrplaceprplaceelementiradnik();
            this.AfterConfirmPrplaceprplaceelementiradnik();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PRPLACEPRPLACEELEMENTIRADNIK] ([PRPLACEID], [PRPLACEZAMJESEC], [PRPLACEZAGODINU], [IDELEMENT], [PRPLACESATNICA], [PRPLACESATI], [PRPLACEIZNOS], [PRPLACEPOSTOTAK], [IDRADNIK]) VALUES (@PRPLACEID, @PRPLACEZAMJESEC, @PRPLACEZAGODINU, @IDELEMENT, @PRPLACESATNICA, @PRPLACESATI, @PRPLACEIZNOS, @PRPLACEPOSTOTAK, @IDRADNIK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACESATNICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACESATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEPOSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAMJESEC"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAGODINU"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDELEMENT"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATNICA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATI"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEIZNOS"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEPOSTOTAK"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDRADNIK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PRPLACEPRPLACEELEMENTIRADNIKDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPRPLACEPRPLACEELEMENTIRADNIKUpdated(new PRPLACEPRPLACEELEMENTIRADNIKEventArgs(this.rowPRPLACEPRPLACEELEMENTIRADNIK, StatementType.Insert));
        }

        private void LoadByPRPLACEID(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PRPLACESet.EnforceConstraints;
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.BeginLoadData();
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.BeginLoadData();
            this.PRPLACESet.PRPLACE.BeginLoadData();
            this.ScanByPRPLACEID(startRow, maxRows);
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.EndLoadData();
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.EndLoadData();
            this.PRPLACESet.PRPLACE.EndLoadData();
            this.PRPLACESet.EnforceConstraints = enforceConstraints;
            if (this.PRPLACESet.PRPLACE.Count > 0)
            {
                this.rowPRPLACE = this.PRPLACESet.PRPLACE[this.PRPLACESet.PRPLACE.Count - 1];
            }
        }

        private void LoadByPRPLACEIDPRPLACEZAMJESEC(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PRPLACESet.EnforceConstraints;
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.BeginLoadData();
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.BeginLoadData();
            this.PRPLACESet.PRPLACE.BeginLoadData();
            this.ScanByPRPLACEIDPRPLACEZAMJESEC(startRow, maxRows);
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.EndLoadData();
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.EndLoadData();
            this.PRPLACESet.PRPLACE.EndLoadData();
            this.PRPLACESet.EnforceConstraints = enforceConstraints;
            if (this.PRPLACESet.PRPLACE.Count > 0)
            {
                this.rowPRPLACE = this.PRPLACESet.PRPLACE[this.PRPLACESet.PRPLACE.Count - 1];
            }
        }

        private void LoadByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PRPLACESet.EnforceConstraints;
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.BeginLoadData();
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.BeginLoadData();
            this.PRPLACESet.PRPLACE.BeginLoadData();
            this.ScanByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(startRow, maxRows);
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.EndLoadData();
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.EndLoadData();
            this.PRPLACESet.PRPLACE.EndLoadData();
            this.PRPLACESet.EnforceConstraints = enforceConstraints;
            if (this.PRPLACESet.PRPLACE.Count > 0)
            {
                this.rowPRPLACE = this.PRPLACESet.PRPLACE[this.PRPLACESet.PRPLACE.Count - 1];
            }
        }

        private void LoadChildPrplace(int startRow, int maxRows)
        {
            this.CreateNewRowPrplace();
            bool enforceConstraints = this.PRPLACESet.EnforceConstraints;
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.BeginLoadData();
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.BeginLoadData();
            this.PRPLACESet.PRPLACE.BeginLoadData();
            this.ScanStartPrplace(startRow, maxRows);
            this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.EndLoadData();
            this.PRPLACESet.PRPLACEPRPLACEELEMENTI.EndLoadData();
            this.PRPLACESet.PRPLACE.EndLoadData();
            this.PRPLACESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildPrplaceprplaceelementi()
        {
            this.CreateNewRowPrplaceprplaceelementi();
            this.ScanStartPrplaceprplaceelementi();
        }

        private void LoadChildPrplaceprplaceelementiradnik()
        {
            this.CreateNewRowPrplaceprplaceelementiradnik();
            this.ScanStartPrplaceprplaceelementiradnik();
        }

        private void LoadDataPrplace(int maxRows)
        {
            int num = 0;
            if (this.RcdFound131 != 0)
            {
                this.ScanLoadPrplace();
                while ((this.RcdFound131 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowPrplace();
                    this.CreateNewRowPrplace();
                    this.ScanNextPrplace();
                }
            }
            if (num > 0)
            {
                this.RcdFound131 = 1;
            }
            this.ScanEndPrplace();
            if (this.PRPLACESet.PRPLACE.Count > 0)
            {
                this.rowPRPLACE = this.PRPLACESet.PRPLACE[this.PRPLACESet.PRPLACE.Count - 1];
            }
        }

        private void LoadDataPrplaceprplaceelementi()
        {
            while (this.RcdFound132 != 0)
            {
                this.LoadRowPrplaceprplaceelementi();
                this.CreateNewRowPrplaceprplaceelementi();
                this.ScanNextPrplaceprplaceelementi();
            }
            this.ScanEndPrplaceprplaceelementi();
        }

        private void LoadDataPrplaceprplaceelementiradnik()
        {
            while (this.RcdFound133 != 0)
            {
                this.LoadRowPrplaceprplaceelementiradnik();
                this.CreateNewRowPrplaceprplaceelementiradnik();
                this.ScanNextPrplaceprplaceelementiradnik();
            }
            this.ScanEndPrplaceprplaceelementiradnik();
        }

        private void LoadRowPrplace()
        {
            this.AddRowPrplace();
        }

        private void LoadRowPrplaceprplaceelementi()
        {
            this.AddRowPrplaceprplaceelementi();
        }

        private void LoadRowPrplaceprplaceelementiradnik()
        {
            this.OnLoadActionsPrplaceprplaceelementiradnik();
            this.AddRowPrplaceprplaceelementiradnik();
        }

        private void OnDeleteControlsPrplaceprplaceelementi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT], [POSTOTAK] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowPRPLACEPRPLACEELEMENTI["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowPRPLACEPRPLACEELEMENTI["POSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
            }
            reader.Close();
        }

        private void OnDeleteControlsPrplaceprplaceelementiradnik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIME], [IME] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            }
            reader.Close();
            if (!this.rowPRPLACEPRPLACEELEMENTIRADNIK.IsPREZIMENull() && !this.rowPRPLACEPRPLACEELEMENTIRADNIK.IsIMENull())
            {
                this.m_SPOJENOPREZIME = this.rowPRPLACEPRPLACEELEMENTIRADNIK.PREZIME + " " + this.rowPRPLACEPRPLACEELEMENTIRADNIK.IME;
            }
        }

        private void OnLoadActionsPrplaceprplaceelementiradnik()
        {
            if (!this.rowPRPLACEPRPLACEELEMENTIRADNIK.IsPREZIMENull() && !this.rowPRPLACEPRPLACEELEMENTIRADNIK.IsIMENull())
            {
                this.m_SPOJENOPREZIME = this.rowPRPLACEPRPLACEELEMENTIRADNIK.PREZIME + " " + this.rowPRPLACEPRPLACEELEMENTIRADNIK.IME;
            }
        }

        private void OnPRPLACEPRPLACEELEMENTIRADNIKUpdated(PRPLACEPRPLACEELEMENTIRADNIKEventArgs e)
        {
            if (this.PRPLACEPRPLACEELEMENTIRADNIKUpdated != null)
            {
                PRPLACEPRPLACEELEMENTIRADNIKUpdateEventHandler pRPLACEPRPLACEELEMENTIRADNIKUpdatedEvent = this.PRPLACEPRPLACEELEMENTIRADNIKUpdated;
                if (pRPLACEPRPLACEELEMENTIRADNIKUpdatedEvent != null)
                {
                    pRPLACEPRPLACEELEMENTIRADNIKUpdatedEvent(this, e);
                }
            }
        }

        private void OnPRPLACEPRPLACEELEMENTIRADNIKUpdating(PRPLACEPRPLACEELEMENTIRADNIKEventArgs e)
        {
            if (this.PRPLACEPRPLACEELEMENTIRADNIKUpdating != null)
            {
                PRPLACEPRPLACEELEMENTIRADNIKUpdateEventHandler pRPLACEPRPLACEELEMENTIRADNIKUpdatingEvent = this.PRPLACEPRPLACEELEMENTIRADNIKUpdating;
                if (pRPLACEPRPLACEELEMENTIRADNIKUpdatingEvent != null)
                {
                    pRPLACEPRPLACEELEMENTIRADNIKUpdatingEvent(this, e);
                }
            }
        }

        private void OnPRPLACEPRPLACEELEMENTIUpdated(PRPLACEPRPLACEELEMENTIEventArgs e)
        {
            if (this.PRPLACEPRPLACEELEMENTIUpdated != null)
            {
                PRPLACEPRPLACEELEMENTIUpdateEventHandler pRPLACEPRPLACEELEMENTIUpdatedEvent = this.PRPLACEPRPLACEELEMENTIUpdated;
                if (pRPLACEPRPLACEELEMENTIUpdatedEvent != null)
                {
                    pRPLACEPRPLACEELEMENTIUpdatedEvent(this, e);
                }
            }
        }

        private void OnPRPLACEPRPLACEELEMENTIUpdating(PRPLACEPRPLACEELEMENTIEventArgs e)
        {
            if (this.PRPLACEPRPLACEELEMENTIUpdating != null)
            {
                PRPLACEPRPLACEELEMENTIUpdateEventHandler pRPLACEPRPLACEELEMENTIUpdatingEvent = this.PRPLACEPRPLACEELEMENTIUpdating;
                if (pRPLACEPRPLACEELEMENTIUpdatingEvent != null)
                {
                    pRPLACEPRPLACEELEMENTIUpdatingEvent(this, e);
                }
            }
        }

        private void OnPRPLACEUpdated(PRPLACEEventArgs e)
        {
            if (this.PRPLACEUpdated != null)
            {
                PRPLACEUpdateEventHandler pRPLACEUpdatedEvent = this.PRPLACEUpdated;
                if (pRPLACEUpdatedEvent != null)
                {
                    pRPLACEUpdatedEvent(this, e);
                }
            }
        }

        private void OnPRPLACEUpdating(PRPLACEEventArgs e)
        {
            if (this.PRPLACEUpdating != null)
            {
                PRPLACEUpdateEventHandler pRPLACEUpdatingEvent = this.PRPLACEUpdating;
                if (pRPLACEUpdatingEvent != null)
                {
                    pRPLACEUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelPrplace()
        {
            this.sMode131 = this.Gx_mode;
            this.ProcessNestedLevelPrplaceprplaceelementi();
            this.Gx_mode = this.sMode131;
        }

        private void ProcessLevelPrplaceprplaceelementi()
        {
            this.sMode132 = this.Gx_mode;
            this.ProcessNestedLevelPrplaceprplaceelementiradnik();
            this.Gx_mode = this.sMode132;
        }

        private void ProcessNestedLevelPrplaceprplaceelementi()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.PRPLACESet.PRPLACEPRPLACEELEMENTI.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowPRPLACEPRPLACEELEMENTI = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) current;
                    if (Helpers.IsRowChanged(this.rowPRPLACEPRPLACEELEMENTI))
                    {
                        bool flag = false;
                        if (this.rowPRPLACEPRPLACEELEMENTI.RowState != DataRowState.Deleted)
                        {
                            flag = ((this.rowPRPLACEPRPLACEELEMENTI.PRPLACEZAMJESEC == this.rowPRPLACE.PRPLACEZAMJESEC) && (this.rowPRPLACEPRPLACEELEMENTI.PRPLACEID == this.rowPRPLACE.PRPLACEID)) && (this.rowPRPLACEPRPLACEELEMENTI.PRPLACEZAGODINU == this.rowPRPLACE.PRPLACEZAGODINU);
                        }
                        else
                        {
                            flag = (this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAMJESEC", DataRowVersion.Original].Equals(this.rowPRPLACE.PRPLACEZAMJESEC) && this.rowPRPLACEPRPLACEELEMENTI["PRPLACEID", DataRowVersion.Original].Equals(this.rowPRPLACE.PRPLACEID)) && this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAGODINU", DataRowVersion.Original].Equals(this.rowPRPLACE.PRPLACEZAGODINU);
                        }
                        if (flag)
                        {
                            this.ReadRowPrplaceprplaceelementi();
                            if (this.rowPRPLACEPRPLACEELEMENTI.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertPrplaceprplaceelementi();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeletePrplaceprplaceelementi();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdatePrplaceprplaceelementi();
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

        private void ProcessNestedLevelPrplaceprplaceelementiradnik()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.PRPLACESet.PRPLACEPRPLACEELEMENTIRADNIK.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowPRPLACEPRPLACEELEMENTIRADNIK = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) current;
                    if (Helpers.IsRowChanged(this.rowPRPLACEPRPLACEELEMENTIRADNIK))
                    {
                        bool flag = false;
                        if (this.rowPRPLACEPRPLACEELEMENTIRADNIK.RowState != DataRowState.Deleted)
                        {
                            flag = ((this.rowPRPLACEPRPLACEELEMENTIRADNIK.PRPLACEZAMJESEC == this.rowPRPLACEPRPLACEELEMENTI.PRPLACEZAMJESEC) && (this.rowPRPLACEPRPLACEELEMENTIRADNIK.PRPLACEID == this.rowPRPLACEPRPLACEELEMENTI.PRPLACEID)) && ((this.rowPRPLACEPRPLACEELEMENTIRADNIK.PRPLACEZAGODINU == this.rowPRPLACEPRPLACEELEMENTI.PRPLACEZAGODINU) && (this.rowPRPLACEPRPLACEELEMENTIRADNIK.IDELEMENT == this.rowPRPLACEPRPLACEELEMENTI.IDELEMENT));
                        }
                        else
                        {
                            flag = (this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAMJESEC", DataRowVersion.Original].Equals(this.rowPRPLACEPRPLACEELEMENTI.PRPLACEZAMJESEC) && this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEID", DataRowVersion.Original].Equals(this.rowPRPLACEPRPLACEELEMENTI.PRPLACEID)) && (this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAGODINU", DataRowVersion.Original].Equals(this.rowPRPLACEPRPLACEELEMENTI.PRPLACEZAGODINU) && this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDELEMENT", DataRowVersion.Original].Equals(this.rowPRPLACEPRPLACEELEMENTI.IDELEMENT));
                        }
                        if (flag)
                        {
                            this.ReadRowPrplaceprplaceelementiradnik();
                            if (this.rowPRPLACEPRPLACEELEMENTIRADNIK.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertPrplaceprplaceelementiradnik();
                            }
                            else
                            {
                                if (this._Gxremove29)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeletePrplaceprplaceelementiradnik();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdatePrplaceprplaceelementiradnik();
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

        private void ReadRowPrplace()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPRPLACE.RowState);
            if (this.rowPRPLACE.RowState != DataRowState.Added)
            {
                this.m__PRPLACEOPISOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEOPIS", DataRowVersion.Original]);
                this.m__PRPLACEOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEOSNOVICA", DataRowVersion.Original]);
                this.m__PRPLACEPROSJECNISATIOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEPROSJECNISATI", DataRowVersion.Original]);
            }
            else
            {
                this.m__PRPLACEOPISOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEOPIS"]);
                this.m__PRPLACEOSNOVICAOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEOSNOVICA"]);
                this.m__PRPLACEPROSJECNISATIOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEPROSJECNISATI"]);
            }
            this._Gxremove = this.rowPRPLACE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPRPLACE = (PRPLACEDataSet.PRPLACERow) DataSetUtil.CloneOriginalDataRow(this.rowPRPLACE);
            }
        }

        private void ReadRowPrplaceprplaceelementi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPRPLACEPRPLACEELEMENTI.RowState);
            if (this.rowPRPLACEPRPLACEELEMENTI.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowPRPLACEPRPLACEELEMENTI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPRPLACEPRPLACEELEMENTI = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) DataSetUtil.CloneOriginalDataRow(this.rowPRPLACEPRPLACEELEMENTI);
            }
        }

        private void ReadRowPrplaceprplaceelementiradnik()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPRPLACEPRPLACEELEMENTIRADNIK.RowState);
            if (this.rowPRPLACEPRPLACEELEMENTIRADNIK.RowState != DataRowState.Added)
            {
                this.m__PRPLACESATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATNICA", DataRowVersion.Original]);
                this.m__PRPLACESATIOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATI", DataRowVersion.Original]);
                this.m__PRPLACEIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEIZNOS", DataRowVersion.Original]);
                this.m__PRPLACEPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEPOSTOTAK", DataRowVersion.Original]);
            }
            else
            {
                this.m__PRPLACESATNICAOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATNICA"]);
                this.m__PRPLACESATIOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATI"]);
                this.m__PRPLACEIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEIZNOS"]);
                this.m__PRPLACEPOSTOTAKOriginal = RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEPOSTOTAK"]);
            }
            this._Gxremove29 = this.rowPRPLACEPRPLACEELEMENTIRADNIK.RowState == DataRowState.Deleted;
            if (this._Gxremove29)
            {
                this.rowPRPLACEPRPLACEELEMENTIRADNIK = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow) DataSetUtil.CloneOriginalDataRow(this.rowPRPLACEPRPLACEELEMENTIRADNIK);
            }
        }

        private void ScanByPRPLACEID(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[PRPLACEID] = @PRPLACEID";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString131 + "  FROM [PRPLACE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString131, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] ) AS DK_PAGENUM   FROM [PRPLACE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString131 + " FROM [PRPLACE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] ";
            }
            this.cmPRPLACESelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPRPLACESelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
            }
            this.cmPRPLACESelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            this.PRPLACESelect6 = this.cmPRPLACESelect6.FetchData();
            this.RcdFound131 = 0;
            this.ScanLoadPrplace();
            this.LoadDataPrplace(maxRows);
            if (this.RcdFound131 > 0)
            {
                this.SubLvlScanStartPrplaceprplaceelementi(this.m_WhereString, startRow, maxRows);
                this.SetParametersPRPLACEIDPrplace(this.cmPRPLACEPRPLACEELEMENTISelect2);
                this.SubLvlFetchPrplaceprplaceelementi();
                this.SubLoadDataPrplaceprplaceelementi();
                this.SubLvlScanStartPrplaceprplaceelementiradnik(this.m_WhereString, startRow, maxRows);
                this.SetParametersPRPLACEIDPrplace(this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2);
                this.SubLvlFetchPrplaceprplaceelementiradnik();
                this.SubLoadDataPrplaceprplaceelementiradnik();
            }
        }

        private void ScanByPRPLACEIDPRPLACEZAMJESEC(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[PRPLACEID] = @PRPLACEID and TM1.[PRPLACEZAMJESEC] = @PRPLACEZAMJESEC";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString131 + "  FROM [PRPLACE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString131, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] ) AS DK_PAGENUM   FROM [PRPLACE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString131 + " FROM [PRPLACE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] ";
            }
            this.cmPRPLACESelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPRPLACESelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                this.cmPRPLACESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
            }
            this.cmPRPLACESelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            this.cmPRPLACESelect6.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
            this.PRPLACESelect6 = this.cmPRPLACESelect6.FetchData();
            this.RcdFound131 = 0;
            this.ScanLoadPrplace();
            this.LoadDataPrplace(maxRows);
            if (this.RcdFound131 > 0)
            {
                this.SubLvlScanStartPrplaceprplaceelementi(this.m_WhereString, startRow, maxRows);
                this.SetParametersPRPLACEIDPRPLACEZAMJESECPrplace(this.cmPRPLACEPRPLACEELEMENTISelect2);
                this.SubLvlFetchPrplaceprplaceelementi();
                this.SubLoadDataPrplaceprplaceelementi();
                this.SubLvlScanStartPrplaceprplaceelementiradnik(this.m_WhereString, startRow, maxRows);
                this.SetParametersPRPLACEIDPRPLACEZAMJESECPrplace(this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2);
                this.SubLvlFetchPrplaceprplaceelementiradnik();
                this.SubLoadDataPrplaceprplaceelementiradnik();
            }
        }

        private void ScanByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[PRPLACEZAMJESEC] = @PRPLACEZAMJESEC and TM1.[PRPLACEID] = @PRPLACEID and TM1.[PRPLACEZAGODINU] = @PRPLACEZAGODINU";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString131 + "  FROM [PRPLACE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString131, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] ) AS DK_PAGENUM   FROM [PRPLACE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString131 + " FROM [PRPLACE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] ";
            }
            this.cmPRPLACESelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPRPLACESelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                this.cmPRPLACESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                this.cmPRPLACESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
            }
            this.cmPRPLACESelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
            this.cmPRPLACESelect6.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            this.cmPRPLACESelect6.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAGODINU"]));
            this.PRPLACESelect6 = this.cmPRPLACESelect6.FetchData();
            this.RcdFound131 = 0;
            this.ScanLoadPrplace();
            this.LoadDataPrplace(maxRows);
            if (this.RcdFound131 > 0)
            {
                this.SubLvlScanStartPrplaceprplaceelementi(this.m_WhereString, startRow, maxRows);
                this.SetParametersPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINUPrplace(this.cmPRPLACEPRPLACEELEMENTISelect2);
                this.SubLvlFetchPrplaceprplaceelementi();
                this.SubLoadDataPrplaceprplaceelementi();
                this.SubLvlScanStartPrplaceprplaceelementiradnik(this.m_WhereString, startRow, maxRows);
                this.SetParametersPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINUPrplace(this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2);
                this.SubLvlFetchPrplaceprplaceelementiradnik();
                this.SubLoadDataPrplaceprplaceelementiradnik();
            }
        }

        private void ScanEndPrplace()
        {
            this.PRPLACESelect6.Close();
        }

        private void ScanEndPrplaceprplaceelementi()
        {
            this.PRPLACEPRPLACEELEMENTISelect2.Close();
        }

        private void ScanEndPrplaceprplaceelementiradnik()
        {
            this.PRPLACEPRPLACEELEMENTIRADNIKSelect2.Close();
        }

        private void ScanLoadPrplace()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPRPLACESelect6.HasMoreRows)
            {
                this.RcdFound131 = 1;
                this.rowPRPLACE["PRPLACEID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PRPLACESelect6, 0));
                this.rowPRPLACE["PRPLACEZAMJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PRPLACESelect6, 1));
                this.rowPRPLACE["PRPLACEZAGODINU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PRPLACESelect6, 2));
                this.rowPRPLACE["PRPLACEOPIS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PRPLACESelect6, 3));
                this.rowPRPLACE["PRPLACEOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PRPLACESelect6, 4));
                this.rowPRPLACE["PRPLACEPROSJECNISATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PRPLACESelect6, 5));
            }
        }

        private void ScanLoadPrplaceprplaceelementi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPRPLACEPRPLACEELEMENTISelect2.HasMoreRows)
            {
                this.RcdFound132 = 1;
                this.rowPRPLACEPRPLACEELEMENTI["PRPLACEID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PRPLACEPRPLACEELEMENTISelect2, 0));
                this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAMJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PRPLACEPRPLACEELEMENTISelect2, 1));
                this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAGODINU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PRPLACEPRPLACEELEMENTISelect2, 2));
                this.rowPRPLACEPRPLACEELEMENTI["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PRPLACEPRPLACEELEMENTISelect2, 3));
                this.rowPRPLACEPRPLACEELEMENTI["POSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PRPLACEPRPLACEELEMENTISelect2, 4));
                this.rowPRPLACEPRPLACEELEMENTI["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PRPLACEPRPLACEELEMENTISelect2, 5));
                this.rowPRPLACEPRPLACEELEMENTI["POSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PRPLACEPRPLACEELEMENTISelect2, 4));
            }
        }

        private void ScanLoadPrplaceprplaceelementiradnik()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.HasMoreRows)
            {
                this.RcdFound133 = 1;
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 0));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAMJESEC"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 1));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAGODINU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 2));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 3));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATNICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 4));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 5));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 6));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 7));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 8));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 9));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 10));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 7));
                this.rowPRPLACEPRPLACEELEMENTIRADNIK["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PRPLACEPRPLACEELEMENTIRADNIKSelect2, 8));
            }
        }

        private void ScanNextPrplace()
        {
            this.cmPRPLACESelect6.HasMoreRows = this.PRPLACESelect6.Read();
            this.RcdFound131 = 0;
            this.ScanLoadPrplace();
        }

        private void ScanNextPrplaceprplaceelementi()
        {
            this.cmPRPLACEPRPLACEELEMENTISelect2.HasMoreRows = this.PRPLACEPRPLACEELEMENTISelect2.Read();
            this.RcdFound132 = 0;
            this.ScanLoadPrplaceprplaceelementi();
        }

        private void ScanNextPrplaceprplaceelementiradnik()
        {
            this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.HasMoreRows = this.PRPLACEPRPLACEELEMENTIRADNIKSelect2.Read();
            this.RcdFound133 = 0;
            this.ScanLoadPrplaceprplaceelementiradnik();
        }

        private void ScanStartPrplace(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString131 + "  FROM [PRPLACE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString131, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] ) AS DK_PAGENUM   FROM [PRPLACE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString131 + " FROM [PRPLACE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] ";
            }
            this.cmPRPLACESelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.PRPLACESelect6 = this.cmPRPLACESelect6.FetchData();
            this.RcdFound131 = 0;
            this.ScanLoadPrplace();
            this.LoadDataPrplace(maxRows);
            if (this.RcdFound131 > 0)
            {
                this.SubLvlScanStartPrplaceprplaceelementi(this.m_WhereString, startRow, maxRows);
                this.SetParametersPrplacePrplace(this.cmPRPLACEPRPLACEELEMENTISelect2);
                this.SubLvlFetchPrplaceprplaceelementi();
                this.SubLoadDataPrplaceprplaceelementi();
                this.SubLvlScanStartPrplaceprplaceelementiradnik(this.m_WhereString, startRow, maxRows);
                this.SetParametersPrplacePrplace(this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2);
                this.SubLvlFetchPrplaceprplaceelementiradnik();
                this.SubLoadDataPrplaceprplaceelementiradnik();
            }
        }

        private void ScanStartPrplaceprplaceelementi()
        {
            this.cmPRPLACEPRPLACEELEMENTISelect2 = this.connDefault.GetCommand("SELECT T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[NAZIVELEMENT], T2.[POSTOTAK], T1.[IDELEMENT] FROM ([PRPLACEPRPLACEELEMENTI] T1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = T1.[IDELEMENT]) WHERE T1.[PRPLACEID] = @PRPLACEID and T1.[PRPLACEZAMJESEC] = @PRPLACEZAMJESEC and T1.[PRPLACEZAGODINU] = @PRPLACEZAGODINU ORDER BY T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT] ", false);
            if (this.cmPRPLACEPRPLACEELEMENTISelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACEPRPLACEELEMENTISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                this.cmPRPLACEPRPLACEELEMENTISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                this.cmPRPLACEPRPLACEELEMENTISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
            }
            this.cmPRPLACEPRPLACEELEMENTISelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEID"]));
            this.cmPRPLACEPRPLACEELEMENTISelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAMJESEC"]));
            this.cmPRPLACEPRPLACEELEMENTISelect2.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAGODINU"]));
            this.PRPLACEPRPLACEELEMENTISelect2 = this.cmPRPLACEPRPLACEELEMENTISelect2.FetchData();
            this.RcdFound132 = 0;
            this.ScanLoadPrplaceprplaceelementi();
        }

        private void ScanStartPrplaceprplaceelementiradnik()
        {
            this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2 = this.connDefault.GetCommand("SELECT T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT], T1.[PRPLACESATNICA], T1.[PRPLACESATI], T1.[PRPLACEIZNOS], T2.[PREZIME], T2.[IME], T1.[PRPLACEPOSTOTAK], T1.[IDRADNIK] FROM ([PRPLACEPRPLACEELEMENTIRADNIK] T1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = T1.[IDRADNIK]) WHERE T1.[PRPLACEID] = @PRPLACEID and T1.[PRPLACEZAMJESEC] = @PRPLACEZAMJESEC and T1.[PRPLACEZAGODINU] = @PRPLACEZAGODINU and T1.[IDELEMENT] = @IDELEMENT ORDER BY T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT], T1.[IDRADNIK] ", false);
            if (this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEID"]));
            this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAMJESEC"]));
            this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAGODINU"]));
            this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDELEMENT"]));
            this.PRPLACEPRPLACEELEMENTIRADNIKSelect2 = this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.FetchData();
            this.RcdFound133 = 0;
            this.ScanLoadPrplaceprplaceelementiradnik();
        }

        private void SetParametersPRPLACEIDPrplace(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
        }

        private void SetParametersPRPLACEIDPRPLACEZAMJESECPrplace(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            m_Command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
        }

        private void SetParametersPrplacePrplace(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINUPrplace(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
            m_Command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            m_Command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAGODINU"]));
        }

        private void SkipNextPrplaceprplaceelementi()
        {
            this.cmPRPLACEPRPLACEELEMENTISelect2.HasMoreRows = this.PRPLACEPRPLACEELEMENTISelect2.Read();
            this.RcdFound132 = 0;
            if (this.cmPRPLACEPRPLACEELEMENTISelect2.HasMoreRows)
            {
                this.RcdFound132 = 1;
            }
        }

        private void SkipNextPrplaceprplaceelementiradnik()
        {
            this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.HasMoreRows = this.PRPLACEPRPLACEELEMENTIRADNIKSelect2.Read();
            this.RcdFound133 = 0;
            if (this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.HasMoreRows)
            {
                this.RcdFound133 = 1;
            }
        }

        private void SubLoadDataPrplaceprplaceelementi()
        {
            while (this.RcdFound132 != 0)
            {
                this.LoadRowPrplaceprplaceelementi();
                this.CreateNewRowPrplaceprplaceelementi();
                this.ScanNextPrplaceprplaceelementi();
            }
            this.ScanEndPrplaceprplaceelementi();
        }

        private void SubLoadDataPrplaceprplaceelementiradnik()
        {
            while (this.RcdFound133 != 0)
            {
                this.LoadRowPrplaceprplaceelementiradnik();
                this.CreateNewRowPrplaceprplaceelementiradnik();
                this.ScanNextPrplaceprplaceelementiradnik();
            }
            this.ScanEndPrplaceprplaceelementiradnik();
        }

        private void SubLvlFetchPrplaceprplaceelementi()
        {
            this.CreateNewRowPrplaceprplaceelementi();
            this.PRPLACEPRPLACEELEMENTISelect2 = this.cmPRPLACEPRPLACEELEMENTISelect2.FetchData();
            this.RcdFound132 = 0;
            this.ScanLoadPrplaceprplaceelementi();
        }

        private void SubLvlFetchPrplaceprplaceelementiradnik()
        {
            this.CreateNewRowPrplaceprplaceelementiradnik();
            this.PRPLACEPRPLACEELEMENTIRADNIKSelect2 = this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2.FetchData();
            this.RcdFound133 = 0;
            this.ScanLoadPrplaceprplaceelementiradnik();
        }

        private void SubLvlScanStartPrplaceprplaceelementi(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString132 = "(SELECT TOP " + maxRows.ToString() + " TM1.[PRPLACEZAMJESEC],TM1.[PRPLACEID],TM1.[PRPLACEZAGODINU]  FROM [PRPLACE]  TM1 " + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] )";
                    this.scmdbuf = "SELECT T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[NAZIVELEMENT], T3.[POSTOTAK], T1.[IDELEMENT] FROM (([PRPLACEPRPLACEELEMENTI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString132 + "  TMX ON TMX.[PRPLACEID] = T1.[PRPLACEID] AND TMX.[PRPLACEZAMJESEC] = T1.[PRPLACEZAMJESEC] AND TMX.[PRPLACEZAGODINU] = T1.[PRPLACEZAGODINU]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT]) ORDER BY T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[PRPLACEZAMJESEC],TM1.[PRPLACEID],TM1.[PRPLACEZAGODINU], ROW_NUMBER() OVER  (  ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU]  ) AS DK_PAGENUM   FROM [PRPLACE]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString132 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[NAZIVELEMENT], T3.[POSTOTAK], T1.[IDELEMENT] FROM (([PRPLACEPRPLACEELEMENTI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString132 + "  TMX ON TMX.[PRPLACEID] = T1.[PRPLACEID] AND TMX.[PRPLACEZAMJESEC] = T1.[PRPLACEZAMJESEC] AND TMX.[PRPLACEZAGODINU] = T1.[PRPLACEZAGODINU]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT]) ORDER BY T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString132 = "[PRPLACE]";
                this.scmdbuf = "SELECT T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[NAZIVELEMENT], T3.[POSTOTAK], T1.[IDELEMENT] FROM (([PRPLACEPRPLACEELEMENTI] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString132 + "  TM1 WITH (NOLOCK) ON TM1.[PRPLACEID] = T1.[PRPLACEID] AND TM1.[PRPLACEZAMJESEC] = T1.[PRPLACEZAMJESEC] AND TM1.[PRPLACEZAGODINU] = T1.[PRPLACEZAGODINU]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT])" + this.m_WhereString + " ORDER BY T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT] ";
            }
            this.cmPRPLACEPRPLACEELEMENTISelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        private void SubLvlScanStartPrplaceprplaceelementiradnik(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString133 = "(SELECT TOP " + maxRows.ToString() + " TM1.[PRPLACEZAMJESEC],TM1.[PRPLACEID],TM1.[PRPLACEZAGODINU]  FROM [PRPLACE]  TM1 " + this.m_WhereString + " ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU] )";
                    this.scmdbuf = "SELECT T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT], T1.[PRPLACESATNICA], T1.[PRPLACESATI], T1.[PRPLACEIZNOS], T3.[PREZIME], T3.[IME], T1.[PRPLACEPOSTOTAK], T1.[IDRADNIK] FROM (([PRPLACEPRPLACEELEMENTIRADNIK] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString133 + "  TMX ON TMX.[PRPLACEID] = T1.[PRPLACEID] AND TMX.[PRPLACEZAMJESEC] = T1.[PRPLACEZAMJESEC] AND TMX.[PRPLACEZAGODINU] = T1.[PRPLACEZAGODINU]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK]) ORDER BY T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT], T1.[IDRADNIK]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[PRPLACEZAMJESEC],TM1.[PRPLACEID],TM1.[PRPLACEZAGODINU], ROW_NUMBER() OVER  (  ORDER BY TM1.[PRPLACEZAMJESEC], TM1.[PRPLACEID], TM1.[PRPLACEZAGODINU]  ) AS DK_PAGENUM   FROM [PRPLACE]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString133 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT], T1.[PRPLACESATNICA], T1.[PRPLACESATI], T1.[PRPLACEIZNOS], T3.[PREZIME], T3.[IME], T1.[PRPLACEPOSTOTAK], T1.[IDRADNIK] FROM (([PRPLACEPRPLACEELEMENTIRADNIK] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString133 + "  TMX ON TMX.[PRPLACEID] = T1.[PRPLACEID] AND TMX.[PRPLACEZAMJESEC] = T1.[PRPLACEZAMJESEC] AND TMX.[PRPLACEZAGODINU] = T1.[PRPLACEZAGODINU]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK]) ORDER BY T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT], T1.[IDRADNIK]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString133 = "[PRPLACE]";
                this.scmdbuf = "SELECT T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT], T1.[PRPLACESATNICA], T1.[PRPLACESATI], T1.[PRPLACEIZNOS], T3.[PREZIME], T3.[IME], T1.[PRPLACEPOSTOTAK], T1.[IDRADNIK] FROM (([PRPLACEPRPLACEELEMENTIRADNIK] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString133 + "  TM1 WITH (NOLOCK) ON TM1.[PRPLACEID] = T1.[PRPLACEID] AND TM1.[PRPLACEZAMJESEC] = T1.[PRPLACEZAMJESEC] AND TM1.[PRPLACEZAGODINU] = T1.[PRPLACEZAGODINU]) INNER JOIN [RADNIK] T3 WITH (NOLOCK) ON T3.[IDRADNIK] = T1.[IDRADNIK])" + this.m_WhereString + " ORDER BY T1.[PRPLACEID], T1.[PRPLACEZAMJESEC], T1.[PRPLACEZAGODINU], T1.[IDELEMENT], T1.[IDRADNIK] ";
            }
            this.cmPRPLACEPRPLACEELEMENTIRADNIKSelect2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.PRPLACESet = (PRPLACEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.PRPLACESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.PRPLACESet.PRPLACE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        PRPLACEDataSet.PRPLACERow current = (PRPLACEDataSet.PRPLACERow) enumerator.Current;
                        this.rowPRPLACE = current;
                        if (Helpers.IsRowChanged(this.rowPRPLACE))
                        {
                            this.ReadRowPrplace();
                            if (this.rowPRPLACE.RowState == DataRowState.Added)
                            {
                                this.InsertPrplace();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdatePrplace();
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

        private void UpdatePrplace()
        {
            this.CheckOptimisticConcurrencyPrplace();
            this.AfterConfirmPrplace();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PRPLACE] SET [PRPLACEOPIS]=@PRPLACEOPIS, [PRPLACEOSNOVICA]=@PRPLACEOSNOVICA, [PRPLACEPROSJECNISATI]=@PRPLACEPROSJECNISATI  WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEOPIS", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEOSNOVICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEPROSJECNISATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEOPIS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEOSNOVICA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEPROSJECNISATI"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEID"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAMJESEC"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPRPLACE["PRPLACEZAGODINU"]));
            command.ExecuteStmt();
            this.OnPRPLACEUpdated(new PRPLACEEventArgs(this.rowPRPLACE, StatementType.Update));
            this.ProcessLevelPrplace();
        }

        private void UpdatePrplaceprplaceelementi()
        {
            this.CheckOptimisticConcurrencyPrplaceprplaceelementi();
            this.CheckExtendedTablePrplaceprplaceelementi();
            this.AfterConfirmPrplaceprplaceelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PRPLACEPRPLACEELEMENTI] SET [NAZIVELEMENT]=@NAZIVELEMENT  WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU AND [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVELEMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["NAZIVELEMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEID"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAMJESEC"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["PRPLACEZAGODINU"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTI["IDELEMENT"]));
            command.ExecuteStmt();
            this.OnPRPLACEPRPLACEELEMENTIUpdated(new PRPLACEPRPLACEELEMENTIEventArgs(this.rowPRPLACEPRPLACEELEMENTI, StatementType.Update));
            this.ProcessLevelPrplaceprplaceelementi();
        }

        private void UpdatePrplaceprplaceelementiradnik()
        {
            this.CheckOptimisticConcurrencyPrplaceprplaceelementiradnik();
            this.CheckExtendedTablePrplaceprplaceelementiradnik();
            this.AfterConfirmPrplaceprplaceelementiradnik();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PRPLACEPRPLACEELEMENTIRADNIK] SET [PRPLACESATNICA]=@PRPLACESATNICA, [PRPLACESATI]=@PRPLACESATI, [PRPLACEIZNOS]=@PRPLACEIZNOS, [PRPLACEPOSTOTAK]=@PRPLACEPOSTOTAK  WHERE [PRPLACEID] = @PRPLACEID AND [PRPLACEZAMJESEC] = @PRPLACEZAMJESEC AND [PRPLACEZAGODINU] = @PRPLACEZAGODINU AND [IDELEMENT] = @IDELEMENT AND [IDRADNIK] = @IDRADNIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACESATNICA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACESATI", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEPOSTOTAK", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAMJESEC", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRPLACEZAGODINU", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATNICA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACESATI"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEIZNOS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEPOSTOTAK"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEID"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAMJESEC"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["PRPLACEZAGODINU"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDELEMENT"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowPRPLACEPRPLACEELEMENTIRADNIK["IDRADNIK"]));
            command.ExecuteStmt();
            this.OnPRPLACEPRPLACEELEMENTIRADNIKUpdated(new PRPLACEPRPLACEELEMENTIRADNIKEventArgs(this.rowPRPLACEPRPLACEELEMENTIRADNIK, StatementType.Update));
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
        public class PRPLACEDataChangedException : DataChangedException
        {
            public PRPLACEDataChangedException()
            {
            }

            public PRPLACEDataChangedException(string message) : base(message)
            {
            }

            protected PRPLACEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEDataLockedException : DataLockedException
        {
            public PRPLACEDataLockedException()
            {
            }

            public PRPLACEDataLockedException(string message) : base(message)
            {
            }

            protected PRPLACEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEDuplicateKeyException : DuplicateKeyException
        {
            public PRPLACEDuplicateKeyException()
            {
            }

            public PRPLACEDuplicateKeyException(string message) : base(message)
            {
            }

            protected PRPLACEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PRPLACEEventArgs : EventArgs
        {
            private PRPLACEDataSet.PRPLACERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PRPLACEEventArgs(PRPLACEDataSet.PRPLACERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PRPLACEDataSet.PRPLACERow Row
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
        public class PRPLACENotFoundException : DataNotFoundException
        {
            public PRPLACENotFoundException()
            {
            }

            public PRPLACENotFoundException(string message) : base(message)
            {
            }

            protected PRPLACENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIDataChangedException : DataChangedException
        {
            public PRPLACEPRPLACEELEMENTIDataChangedException()
            {
            }

            public PRPLACEPRPLACEELEMENTIDataChangedException(string message) : base(message)
            {
            }

            protected PRPLACEPRPLACEELEMENTIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEPRPLACEELEMENTIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIDataLockedException : DataLockedException
        {
            public PRPLACEPRPLACEELEMENTIDataLockedException()
            {
            }

            public PRPLACEPRPLACEELEMENTIDataLockedException(string message) : base(message)
            {
            }

            protected PRPLACEPRPLACEELEMENTIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEPRPLACEELEMENTIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIDuplicateKeyException : DuplicateKeyException
        {
            public PRPLACEPRPLACEELEMENTIDuplicateKeyException()
            {
            }

            public PRPLACEPRPLACEELEMENTIDuplicateKeyException(string message) : base(message)
            {
            }

            protected PRPLACEPRPLACEELEMENTIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEPRPLACEELEMENTIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PRPLACEPRPLACEELEMENTIEventArgs : EventArgs
        {
            private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PRPLACEPRPLACEELEMENTIEventArgs(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow Row
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
        public class PRPLACEPRPLACEELEMENTIRADNIKDataChangedException : DataChangedException
        {
            public PRPLACEPRPLACEELEMENTIRADNIKDataChangedException()
            {
            }

            public PRPLACEPRPLACEELEMENTIRADNIKDataChangedException(string message) : base(message)
            {
            }

            protected PRPLACEPRPLACEELEMENTIRADNIKDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEPRPLACEELEMENTIRADNIKDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIRADNIKDataLockedException : DataLockedException
        {
            public PRPLACEPRPLACEELEMENTIRADNIKDataLockedException()
            {
            }

            public PRPLACEPRPLACEELEMENTIRADNIKDataLockedException(string message) : base(message)
            {
            }

            protected PRPLACEPRPLACEELEMENTIRADNIKDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEPRPLACEELEMENTIRADNIKDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PRPLACEPRPLACEELEMENTIRADNIKDuplicateKeyException : DuplicateKeyException
        {
            public PRPLACEPRPLACEELEMENTIRADNIKDuplicateKeyException()
            {
            }

            public PRPLACEPRPLACEELEMENTIRADNIKDuplicateKeyException(string message) : base(message)
            {
            }

            protected PRPLACEPRPLACEELEMENTIRADNIKDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PRPLACEPRPLACEELEMENTIRADNIKDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PRPLACEPRPLACEELEMENTIRADNIKEventArgs : EventArgs
        {
            private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PRPLACEPRPLACEELEMENTIRADNIKEventArgs(PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRADNIKRow Row
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

        public delegate void PRPLACEPRPLACEELEMENTIRADNIKUpdateEventHandler(object sender, PRPLACEDataAdapter.PRPLACEPRPLACEELEMENTIRADNIKEventArgs e);

        public delegate void PRPLACEPRPLACEELEMENTIUpdateEventHandler(object sender, PRPLACEDataAdapter.PRPLACEPRPLACEELEMENTIEventArgs e);

        public delegate void PRPLACEUpdateEventHandler(object sender, PRPLACEDataAdapter.PRPLACEEventArgs e);

        [Serializable]
        public class RADNIKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RADNIKForeignKeyNotFoundException()
            {
            }

            public RADNIKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RADNIKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

