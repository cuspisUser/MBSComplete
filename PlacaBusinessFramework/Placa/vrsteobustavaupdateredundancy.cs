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

    public class vrsteobustavaupdateredundancy
    {
        private string AV2GXV201;
        private ReadWriteCommand cmVRSTEOBUST2;
        private ReadWriteCommand cmVRSTEOBUST3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__NAZIVVRSTAOBUSTAVEIsNull;
        private string m_NAZIVVRSTAOBUSTAVE;
        private short m_VRSTAOBUSTAVE;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IDataReader VRSTEOBUST2;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public vrsteobustavaupdateredundancy(ref DataStore ds)
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

        public void execute(short aP0_VRSTAOBUSTAVE)
        {
            this.m_VRSTAOBUSTAVE = aP0_VRSTAOBUSTAVE;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmVRSTEOBUST2 = this.connDefault.GetCommand("SELECT [VRSTAOBUSTAVE], [NAZIVVRSTAOBUSTAVE] FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ORDER BY [VRSTAOBUSTAVE] ", false);
            if (this.cmVRSTEOBUST2.IDbCommand.Parameters.Count == 0)
            {
                this.cmVRSTEOBUST2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            this.cmVRSTEOBUST2.SetParameter(0, this.m_VRSTAOBUSTAVE);
            this.cmVRSTEOBUST2.ErrorMask |= ErrorMask.Lock;
            this.VRSTEOBUST2 = this.cmVRSTEOBUST2.FetchData();
            while (this.cmVRSTEOBUST2.HasMoreRows)
            {
                this.m_NAZIVVRSTAOBUSTAVE = this.dsDefault.Db.GetString(this.VRSTEOBUST2, 1, ref this.m__NAZIVVRSTAOBUSTAVEIsNull);
                this.AV2GXV201 = this.m_NAZIVVRSTAOBUSTAVE;
                this.cmVRSTEOBUST3 = this.connDefault.GetCommand("UPDATE [OBRACUNObustave] SET [NAZIVVRSTAOBUSTAVE]=@NAZIVVRSTAOBUSTAVE ", false);
                if (this.cmVRSTEOBUST3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmVRSTEOBUST3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTAOBUSTAVE", DbType.String, 50));
                }
                this.cmVRSTEOBUST3.SetParameter(0, this.AV2GXV201);
                this.cmVRSTEOBUST3.ExecuteStmt();
                break;
            }
            this.VRSTEOBUST2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVVRSTAOBUSTAVEIsNull = false;
            this.m_NAZIVVRSTAOBUSTAVE = "";
            this.AV2GXV201 = "";
        }
    }
}

