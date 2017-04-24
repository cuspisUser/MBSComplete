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

    public class vrstaelementupdateredundancy
    {
        private string AV2GXV360;
        private ReadWriteCommand cmVRSTAELEME2;
        private ReadWriteCommand cmVRSTAELEME3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__NAZIVVRSTAELEMENTIsNull;
        private short m_IDVRSTAELEMENTA;
        private string m_NAZIVVRSTAELEMENT;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IDataReader VRSTAELEME2;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public vrstaelementupdateredundancy(ref DataStore ds)
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

        public void execute(short aP0_IDVRSTAELEMENTA)
        {
            this.m_IDVRSTAELEMENTA = aP0_IDVRSTAELEMENTA;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmVRSTAELEME2 = this.connDefault.GetCommand("SELECT [IDVRSTAELEMENTA], [NAZIVVRSTAELEMENT] FROM [VRSTAELEMENT] WITH (NOLOCK) WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ORDER BY [IDVRSTAELEMENTA] ", false);
            if (this.cmVRSTAELEME2.IDbCommand.Parameters.Count == 0)
            {
                this.cmVRSTAELEME2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            this.cmVRSTAELEME2.SetParameter(0, this.m_IDVRSTAELEMENTA);
            this.cmVRSTAELEME2.ErrorMask |= ErrorMask.Lock;
            this.VRSTAELEME2 = this.cmVRSTAELEME2.FetchData();
            while (this.cmVRSTAELEME2.HasMoreRows)
            {
                this.m_NAZIVVRSTAELEMENT = this.dsDefault.Db.GetString(this.VRSTAELEME2, 1, ref this.m__NAZIVVRSTAELEMENTIsNull);
                this.AV2GXV360 = this.m_NAZIVVRSTAELEMENT;
                this.cmVRSTAELEME3 = this.connDefault.GetCommand("UPDATE [ObracunElementi] SET [NAZIVVRSTAELEMENT]=@NAZIVVRSTAELEMENT ", false);
                if (this.cmVRSTAELEME3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmVRSTAELEME3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAELEMENT", DbType.String, 0x19));
                }
                this.cmVRSTAELEME3.SetParameter(0, this.AV2GXV360);
                this.cmVRSTAELEME3.ExecuteStmt();
                break;
            }
            this.VRSTAELEME2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVVRSTAELEMENTIsNull = false;
            this.m_NAZIVVRSTAELEMENT = "";
            this.AV2GXV360 = "";
        }
    }
}

