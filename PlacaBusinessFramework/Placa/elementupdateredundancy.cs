namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Reorganization;
    using Deklarit.Utils;
    using System;
    using System.Data;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;

    public class elementupdateredundancy
    {
        private short AV2GXV359;
        private string AV3GXV358;
        private ReadWriteCommand cmELEMENTUpd2;
        private ReadWriteCommand cmELEMENTUpd3;
        private ReadWriteCommand cmELEMENTUpd4;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private IDataReader ELEMENTUpd2;
        private bool m__IDVRSTAELEMENTAIsNull;
        private bool m__NAZIVELEMENTIsNull;
        private int m_IDELEMENT;
        private short m_IDVRSTAELEMENTA;
        private string m_NAZIVELEMENT;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public elementupdateredundancy(ref DataStore ds)
        {
            this.dsDefault = ds;
            this.connDefault = this.dsDefault.GetReadWriteConnection();
            this.Initialize();
        }

        public void AddMsg(string message)
        {
            if (this.messageHandlerEvent != null)
            {
                ReorganizationMessageEventHandler messageHandlerEvent = this.messageHandlerEvent;
                if (messageHandlerEvent != null)
                {
                    messageHandlerEvent(this, new ReorganizationMessageEventArgs(message));
                }
            }
        }

        protected void Cleanup()
        {
        }

        public void execute(int aP0_IDELEMENT)
        {
            this.m_IDELEMENT = aP0_IDELEMENT;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmELEMENTUpd2 = this.connDefault.GetCommand("SELECT [IDELEMENT], [NAZIVELEMENT], [IDVRSTAELEMENTA] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ORDER BY [IDELEMENT] ", false);
            if (this.cmELEMENTUpd2.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTUpd2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmELEMENTUpd2.SetParameter(0, this.m_IDELEMENT);
            this.cmELEMENTUpd2.ErrorMask |= ErrorMask.Lock;
            this.ELEMENTUpd2 = this.cmELEMENTUpd2.FetchData();
            while (this.cmELEMENTUpd2.HasMoreRows)
            {
                this.m_NAZIVELEMENT = this.dsDefault.Db.GetString(this.ELEMENTUpd2, 1, ref this.m__NAZIVELEMENTIsNull);
                this.m_IDVRSTAELEMENTA = this.dsDefault.Db.GetInt16(this.ELEMENTUpd2, 2, ref this.m__IDVRSTAELEMENTAIsNull);
                this.AV3GXV358 = this.m_NAZIVELEMENT;
                this.AV2GXV359 = this.m_IDVRSTAELEMENTA;
                this.cmELEMENTUpd3 = this.connDefault.GetCommand("UPDATE [ObracunElementi] SET [NAZIVELEMENT]=@NAZIVELEMENT, [IDVRSTAELEMENTA]=@IDVRSTAELEMENTA  WHERE [IDELEMENT] = @IDELEMENT", false);
                if (this.cmELEMENTUpd3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmELEMENTUpd3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVELEMENT", DbType.String, 50));
                    this.cmELEMENTUpd3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
                    this.cmELEMENTUpd3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                }
                this.cmELEMENTUpd3.SetParameter(0, this.AV3GXV358);
                this.cmELEMENTUpd3.SetParameter(1, this.AV2GXV359);
                this.cmELEMENTUpd3.SetParameter(2, this.m_IDELEMENT);
                this.cmELEMENTUpd3.ExecuteStmt();
                this.cmELEMENTUpd4 = this.connDefault.GetCommand("UPDATE [PRPLACEPRPLACEELEMENTI] SET [NAZIVELEMENT]=@NAZIVELEMENT  WHERE [IDELEMENT] = @IDELEMENT", false);
                if (this.cmELEMENTUpd4.IDbCommand.Parameters.Count == 0)
                {
                    this.cmELEMENTUpd4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVELEMENT", DbType.String, 50));
                    this.cmELEMENTUpd4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                }
                this.cmELEMENTUpd4.SetParameter(0, this.AV3GXV358);
                this.cmELEMENTUpd4.SetParameter(1, this.m_IDELEMENT);
                this.cmELEMENTUpd4.ExecuteStmt();
                break;
            }
            this.ELEMENTUpd2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVELEMENTIsNull = false;
            this.m_NAZIVELEMENT = "";
            this.m__IDVRSTAELEMENTAIsNull = false;
            this.m_IDVRSTAELEMENTA = 0;
            this.AV3GXV358 = "";
            this.AV2GXV359 = 0;
        }
    }
}

