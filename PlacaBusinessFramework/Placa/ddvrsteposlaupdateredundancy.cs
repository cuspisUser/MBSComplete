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

    public class ddvrsteposlaupdateredundancy
    {
        private string AV2GXV755;
        private ReadWriteCommand cmDDVRSTEPOS2;
        private ReadWriteCommand cmDDVRSTEPOS3;
        private ReadWriteConnection connDefault;
        private IDataReader DDVRSTEPOS2;
        private DataStore dsDefault;
        private bool m__DDNAZIVVRSTAPOSLAIsNull;
        private int m_DDIDVRSTAPOSLA;
        private string m_DDNAZIVVRSTAPOSLA;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public ddvrsteposlaupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_DDIDVRSTAPOSLA)
        {
            this.m_DDIDVRSTAPOSLA = aP0_DDIDVRSTAPOSLA;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmDDVRSTEPOS2 = this.connDefault.GetCommand("SELECT [DDIDVRSTAPOSLA], [DDNAZIVVRSTAPOSLA] FROM [DDVRSTEPOSLA] WITH (NOLOCK) WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA ORDER BY [DDIDVRSTAPOSLA] ", false);
            if (this.cmDDVRSTEPOS2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDVRSTEPOS2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            this.cmDDVRSTEPOS2.SetParameter(0, this.m_DDIDVRSTAPOSLA);
            this.cmDDVRSTEPOS2.ErrorMask |= ErrorMask.Lock;
            this.DDVRSTEPOS2 = this.cmDDVRSTEPOS2.FetchData();
            while (this.cmDDVRSTEPOS2.HasMoreRows)
            {
                this.m_DDNAZIVVRSTAPOSLA = this.dsDefault.Db.GetString(this.DDVRSTEPOS2, 1, ref this.m__DDNAZIVVRSTAPOSLAIsNull);
                this.AV2GXV755 = this.m_DDNAZIVVRSTAPOSLA;
                this.cmDDVRSTEPOS3 = this.connDefault.GetCommand("UPDATE [DDOBRACUNRadniciVrstePosla] SET [DDNAZIVVRSTAPOSLA]=@DDNAZIVVRSTAPOSLA  WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA", false);
                if (this.cmDDVRSTEPOS3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmDDVRSTEPOS3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVVRSTAPOSLA", DbType.String, 50));
                    this.cmDDVRSTEPOS3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
                }
                this.cmDDVRSTEPOS3.SetParameter(0, this.AV2GXV755);
                this.cmDDVRSTEPOS3.SetParameter(1, this.m_DDIDVRSTAPOSLA);
                this.cmDDVRSTEPOS3.ExecuteStmt();
                break;
            }
            this.DDVRSTEPOS2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__DDNAZIVVRSTAPOSLAIsNull = false;
            this.m_DDNAZIVVRSTAPOSLA = "";
            this.AV2GXV755 = "";
        }
    }
}

