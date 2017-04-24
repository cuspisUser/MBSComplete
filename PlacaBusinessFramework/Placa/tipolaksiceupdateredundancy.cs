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

    public class tipolaksiceupdateredundancy
    {
        private string AV2GXV141;
        private ReadWriteCommand cmTIPOLAKSIC2;
        private ReadWriteCommand cmTIPOLAKSIC3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__IDTIPOLAKSICEIsNull;
        private bool m__NAZIVTIPOLAKSICEIsNull;
        private int m_IDTIPOLAKSICE;
        private string m_NAZIVTIPOLAKSICE;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IDataReader TIPOLAKSIC2;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public tipolaksiceupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDTIPOLAKSICE)
        {
            this.m_IDTIPOLAKSICE = aP0_IDTIPOLAKSICE;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmTIPOLAKSIC2 = this.connDefault.GetCommand("SELECT [IDTIPOLAKSICE], [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ORDER BY [IDTIPOLAKSICE] ", false);
            if (this.cmTIPOLAKSIC2.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPOLAKSIC2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            this.cmTIPOLAKSIC2.SetParameter(0, this.m_IDTIPOLAKSICE, this.m__IDTIPOLAKSICEIsNull);
            this.cmTIPOLAKSIC2.ErrorMask |= ErrorMask.Lock;
            this.TIPOLAKSIC2 = this.cmTIPOLAKSIC2.FetchData();
            while (this.cmTIPOLAKSIC2.HasMoreRows)
            {
                this.m_NAZIVTIPOLAKSICE = this.dsDefault.Db.GetString(this.TIPOLAKSIC2, 1, ref this.m__NAZIVTIPOLAKSICEIsNull);
                this.AV2GXV141 = this.m_NAZIVTIPOLAKSICE;
                this.cmTIPOLAKSIC3 = this.connDefault.GetCommand("UPDATE [ObracunOlaksice] SET [NAZIVTIPOLAKSICE]=@NAZIVTIPOLAKSICE ", false);
                if (this.cmTIPOLAKSIC3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmTIPOLAKSIC3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPOLAKSICE", DbType.String, 50));
                }
                this.cmTIPOLAKSIC3.SetParameter(0, this.AV2GXV141, this.m__NAZIVTIPOLAKSICEIsNull);
                this.cmTIPOLAKSIC3.ExecuteStmt();
                break;
            }
            this.TIPOLAKSIC2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__IDTIPOLAKSICEIsNull = false;
            this.m__NAZIVTIPOLAKSICEIsNull = false;
            this.m_NAZIVTIPOLAKSICE = "";
            this.AV2GXV141 = "";
        }
    }
}

