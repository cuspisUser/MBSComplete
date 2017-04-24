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

    public class ddradnikupdateredundancy
    {
        private string AV2GXV151;
        private ReadWriteCommand cmDDRADNIKUp2;
        private ReadWriteCommand cmDDRADNIKUp3;
        private ReadWriteConnection connDefault;
        private IDataReader DDRADNIKUp2;
        private DataStore dsDefault;
        private bool m__OPCINASTANOVANJAIDOPCINEIsNull;
        private int m_DDIDRADNIK;
        private string m_OPCINASTANOVANJAIDOPCINE;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public ddradnikupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_DDIDRADNIK)
        {
            this.m_DDIDRADNIK = aP0_DDIDRADNIK;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmDDRADNIKUp2 = this.connDefault.GetCommand("SELECT [DDIDRADNIK], [OPCINASTANOVANJAIDOPCINE] FROM [DDRADNIK] WITH (NOLOCK) WHERE [DDIDRADNIK] = @DDIDRADNIK ORDER BY [DDIDRADNIK] ", false);
            if (this.cmDDRADNIKUp2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKUp2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            this.cmDDRADNIKUp2.SetParameter(0, this.m_DDIDRADNIK);
            this.cmDDRADNIKUp2.ErrorMask |= ErrorMask.Lock;
            this.DDRADNIKUp2 = this.cmDDRADNIKUp2.FetchData();
            while (this.cmDDRADNIKUp2.HasMoreRows)
            {
                this.m_OPCINASTANOVANJAIDOPCINE = this.dsDefault.Db.GetString(this.DDRADNIKUp2, 1, ref this.m__OPCINASTANOVANJAIDOPCINEIsNull);
                this.AV2GXV151 = this.m_OPCINASTANOVANJAIDOPCINE;
                this.cmDDRADNIKUp3 = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadnici] SET [OPCINASTANOVANJAIDOPCINE]=@OPCINASTANOVANJAIDOPCINE  WHERE [DDIDRADNIK] = @DDIDRADNIK", false);
                if (this.cmDDRADNIKUp3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmDDRADNIKUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
                    this.cmDDRADNIKUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
                }
                this.cmDDRADNIKUp3.SetParameter(0, this.AV2GXV151);
                this.cmDDRADNIKUp3.SetParameter(1, this.m_DDIDRADNIK);
                this.cmDDRADNIKUp3.ExecuteStmt();
                break;
            }
            this.DDRADNIKUp2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__OPCINASTANOVANJAIDOPCINEIsNull = false;
            this.m_OPCINASTANOVANJAIDOPCINE = "";
            this.AV2GXV151 = "";
        }
    }
}

