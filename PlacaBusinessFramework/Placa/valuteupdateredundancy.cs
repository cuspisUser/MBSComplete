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

    public class valuteupdateredundancy
    {
        private decimal AV2GXV285;
        private string AV3GXV284;
        private ReadWriteCommand cmVALUTEUpda2;
        private ReadWriteCommand cmVALUTEUpda3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__NAZIVVALUTAIsNull;
        private bool m__TECAJIsNull;
        private int m_IDVALUTA;
        private string m_NAZIVVALUTA;
        private decimal m_TECAJ;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IDataReader VALUTEUpda2;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public valuteupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDVALUTA)
        {
            this.m_IDVALUTA = aP0_IDVALUTA;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmVALUTEUpda2 = this.connDefault.GetCommand("SELECT [IDVALUTA], [NAZIVVALUTA], [TECAJ] FROM [VALUTE] WITH (NOLOCK) WHERE [IDVALUTA] = @IDVALUTA ORDER BY [IDVALUTA] ", false);
            if (this.cmVALUTEUpda2.IDbCommand.Parameters.Count == 0)
            {
                this.cmVALUTEUpda2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVALUTA", DbType.Int32));
            }
            this.cmVALUTEUpda2.SetParameter(0, this.m_IDVALUTA);
            this.cmVALUTEUpda2.ErrorMask |= ErrorMask.Lock;
            this.VALUTEUpda2 = this.cmVALUTEUpda2.FetchData();
            while (this.cmVALUTEUpda2.HasMoreRows)
            {
                this.m_NAZIVVALUTA = this.dsDefault.Db.GetString(this.VALUTEUpda2, 1, ref this.m__NAZIVVALUTAIsNull);
                this.m_TECAJ = this.dsDefault.Db.GetDecimal(this.VALUTEUpda2, 2, ref this.m__TECAJIsNull);
                this.AV3GXV284 = this.m_NAZIVVALUTA;
                this.AV2GXV285 = this.m_TECAJ;
                this.cmVALUTEUpda3 = this.connDefault.GetCommand("UPDATE [OBRACUNKrediti] SET [NAZIVVALUTA]=@NAZIVVALUTA, [TECAJ]=@TECAJ  WHERE [IDVALUTA] = @IDVALUTA", false);
                if (this.cmVALUTEUpda3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmVALUTEUpda3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVALUTA", DbType.AnsiString, 50));
                    this.cmVALUTEUpda3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TECAJ", DbType.Decimal));
                    this.cmVALUTEUpda3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVALUTA", DbType.Int32));
                }
                this.cmVALUTEUpda3.SetParameter(0, this.AV3GXV284);
                this.cmVALUTEUpda3.SetParameter(1, this.AV2GXV285);
                this.cmVALUTEUpda3.SetParameter(2, this.m_IDVALUTA);
                this.cmVALUTEUpda3.ExecuteStmt();
                break;
            }
            this.VALUTEUpda2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__NAZIVVALUTAIsNull = false;
            this.m_NAZIVVALUTA = "";
            this.m__TECAJIsNull = false;
            this.m_TECAJ = new decimal();
            this.AV3GXV284 = "";
            this.AV2GXV285 = new decimal();
        }
    }
}

