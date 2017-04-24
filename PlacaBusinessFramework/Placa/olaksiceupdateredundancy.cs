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

    public class olaksiceupdateredundancy
    {
        private string AV2GXV132;
        private string AV3GXV135;
        private string AV4GXV134;
        private string AV5GXV133;
        private string AV6GXV131;
        private int AV7GXV140;
        private int AV8GXV54;
        private string AV9GXV126;
        private ReadWriteCommand cmOLAKSICEUp2;
        private ReadWriteCommand cmOLAKSICEUp3;
        private ReadWriteConnection connDefault;
        private DataStore dsDefault;
        private bool m__IDGRUPEOLAKSICAIsNull;
        private bool m__IDOLAKSICEIsNull;
        private bool m__IDTIPOLAKSICEIsNull;
        private bool m__NAZIVOLAKSICEIsNull;
        private bool m__PRIMATELJOLAKSICA1IsNull;
        private bool m__PRIMATELJOLAKSICA2IsNull;
        private bool m__PRIMATELJOLAKSICA3IsNull;
        private bool m__VBDIOLAKSICAIsNull;
        private bool m__ZRNOLAKSICAIsNull;
        private int m_IDGRUPEOLAKSICA;
        private int m_IDOLAKSICE;
        private int m_IDTIPOLAKSICE;
        private string m_NAZIVOLAKSICE;
        private string m_PRIMATELJOLAKSICA1;
        private string m_PRIMATELJOLAKSICA2;
        private string m_PRIMATELJOLAKSICA3;
        private string m_VBDIOLAKSICA;
        private string m_ZRNOLAKSICA;
        private IDataReader OLAKSICEUp2;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;

        public event ReorganizationMessageEventHandler messageHandlerEvent;

        public olaksiceupdateredundancy(ref DataStore ds)
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

        public void execute(int aP0_IDOLAKSICE)
        {
            this.m_IDOLAKSICE = aP0_IDOLAKSICE;
            this.Initialize();
            this.executePrivate();
        }

        public void executePrivate()
        {
            this.cmOLAKSICEUp2 = this.connDefault.GetCommand("SELECT [IDOLAKSICE], [NAZIVOLAKSICE], [IDGRUPEOLAKSICA], [IDTIPOLAKSICE], [VBDIOLAKSICA], [PRIMATELJOLAKSICA1], [PRIMATELJOLAKSICA2], [PRIMATELJOLAKSICA3], [ZRNOLAKSICA] FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDOLAKSICE] = @IDOLAKSICE ORDER BY [IDOLAKSICE] ", false);
            if (this.cmOLAKSICEUp2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOLAKSICEUp2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
            }
            this.cmOLAKSICEUp2.SetParameter(0, this.m_IDOLAKSICE, this.m__IDOLAKSICEIsNull);
            this.cmOLAKSICEUp2.ErrorMask |= ErrorMask.Lock;
            this.OLAKSICEUp2 = this.cmOLAKSICEUp2.FetchData();
            while (this.cmOLAKSICEUp2.HasMoreRows)
            {
                this.m_NAZIVOLAKSICE = this.dsDefault.Db.GetString(this.OLAKSICEUp2, 1, ref this.m__NAZIVOLAKSICEIsNull);
                this.m_IDGRUPEOLAKSICA = this.dsDefault.Db.GetInt32(this.OLAKSICEUp2, 2, ref this.m__IDGRUPEOLAKSICAIsNull);
                this.m_IDTIPOLAKSICE = this.dsDefault.Db.GetInt32(this.OLAKSICEUp2, 3, ref this.m__IDTIPOLAKSICEIsNull);
                this.m_VBDIOLAKSICA = this.dsDefault.Db.GetString(this.OLAKSICEUp2, 4, ref this.m__VBDIOLAKSICAIsNull);
                this.m_PRIMATELJOLAKSICA1 = this.dsDefault.Db.GetString(this.OLAKSICEUp2, 5, ref this.m__PRIMATELJOLAKSICA1IsNull);
                this.m_PRIMATELJOLAKSICA2 = this.dsDefault.Db.GetString(this.OLAKSICEUp2, 6, ref this.m__PRIMATELJOLAKSICA2IsNull);
                this.m_PRIMATELJOLAKSICA3 = this.dsDefault.Db.GetString(this.OLAKSICEUp2, 7, ref this.m__PRIMATELJOLAKSICA3IsNull);
                this.m_ZRNOLAKSICA = this.dsDefault.Db.GetString(this.OLAKSICEUp2, 8, ref this.m__ZRNOLAKSICAIsNull);
                this.AV9GXV126 = this.m_NAZIVOLAKSICE;
                this.AV8GXV54 = this.m_IDGRUPEOLAKSICA;
                this.AV7GXV140 = this.m_IDTIPOLAKSICE;
                this.AV6GXV131 = this.m_VBDIOLAKSICA;
                this.AV5GXV133 = this.m_PRIMATELJOLAKSICA1;
                this.AV4GXV134 = this.m_PRIMATELJOLAKSICA2;
                this.AV3GXV135 = this.m_PRIMATELJOLAKSICA3;
                this.AV2GXV132 = this.m_ZRNOLAKSICA;
                this.cmOLAKSICEUp3 = this.connDefault.GetCommand("UPDATE [ObracunOlaksice] SET [NAZIVOLAKSICE]=@NAZIVOLAKSICE, [IDGRUPEOLAKSICA]=@IDGRUPEOLAKSICA, [IDTIPOLAKSICE]=@IDTIPOLAKSICE, [VBDIOLAKSICA]=@VBDIOLAKSICA, [PRIMATELJOLAKSICA1]=@PRIMATELJOLAKSICA1, [PRIMATELJOLAKSICA2]=@PRIMATELJOLAKSICA2, [PRIMATELJOLAKSICA3]=@PRIMATELJOLAKSICA3, [ZRNOLAKSICA]=@ZRNOLAKSICA  WHERE [IDOLAKSICE] = @IDOLAKSICE", false);
                if (this.cmOLAKSICEUp3.IDbCommand.Parameters.Count == 0)
                {
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOLAKSICE", DbType.String, 100));
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOLAKSICA", DbType.String, 7));
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA1", DbType.String, 20));
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA2", DbType.String, 20));
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOLAKSICA3", DbType.String, 20));
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOLAKSICA", DbType.String, 10));
                    this.cmOLAKSICEUp3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOLAKSICE", DbType.Int32));
                }
                this.cmOLAKSICEUp3.SetParameter(0, this.AV9GXV126, this.m__NAZIVOLAKSICEIsNull);
                this.cmOLAKSICEUp3.SetParameter(1, this.AV8GXV54, this.m__IDGRUPEOLAKSICAIsNull);
                this.cmOLAKSICEUp3.SetParameter(2, this.AV7GXV140, this.m__IDTIPOLAKSICEIsNull);
                this.cmOLAKSICEUp3.SetParameter(3, this.AV6GXV131, this.m__VBDIOLAKSICAIsNull);
                this.cmOLAKSICEUp3.SetParameter(4, this.AV5GXV133, this.m__PRIMATELJOLAKSICA1IsNull);
                this.cmOLAKSICEUp3.SetParameter(5, this.AV4GXV134, this.m__PRIMATELJOLAKSICA2IsNull);
                this.cmOLAKSICEUp3.SetParameter(6, this.AV3GXV135, this.m__PRIMATELJOLAKSICA3IsNull);
                this.cmOLAKSICEUp3.SetParameter(7, this.AV2GXV132, this.m__ZRNOLAKSICAIsNull);
                this.cmOLAKSICEUp3.SetParameter(8, this.m_IDOLAKSICE, this.m__IDOLAKSICEIsNull);
                this.cmOLAKSICEUp3.ExecuteStmt();
                break;
            }
            this.OLAKSICEUp2.Close();
            this.Cleanup();
        }

        public void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.m__IDOLAKSICEIsNull = false;
            this.m__NAZIVOLAKSICEIsNull = false;
            this.m_NAZIVOLAKSICE = "";
            this.m__IDGRUPEOLAKSICAIsNull = false;
            this.m_IDGRUPEOLAKSICA = 0;
            this.m__IDTIPOLAKSICEIsNull = false;
            this.m_IDTIPOLAKSICE = 0;
            this.m__VBDIOLAKSICAIsNull = false;
            this.m_VBDIOLAKSICA = "";
            this.m__PRIMATELJOLAKSICA1IsNull = false;
            this.m_PRIMATELJOLAKSICA1 = "";
            this.m__PRIMATELJOLAKSICA2IsNull = false;
            this.m_PRIMATELJOLAKSICA2 = "";
            this.m__PRIMATELJOLAKSICA3IsNull = false;
            this.m_PRIMATELJOLAKSICA3 = "";
            this.m__ZRNOLAKSICAIsNull = false;
            this.m_ZRNOLAKSICA = "";
            this.AV9GXV126 = "";
            this.AV8GXV54 = 0;
            this.AV7GXV140 = 0;
            this.AV6GXV131 = "";
            this.AV5GXV133 = "";
            this.AV4GXV134 = "";
            this.AV3GXV135 = "";
            this.AV2GXV132 = "";
        }
    }
}

