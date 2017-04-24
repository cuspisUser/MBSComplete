namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class BOLOVANJEFONDDataReader : IDisposable
    {
        private IDataReader BOLOVANJEFONDSelect5;
        private ReadWriteCommand cmBOLOVANJEFONDSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.BOLOVANJEFONDSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.BOLOVANJEFONDSelect5.Close();
                    }
                }
                finally
                {
                    try
                    {
                        this.connDefault.Close();
                    }
                    finally
                    {
                        this.Cleanup();
                    }
                }
            }
        }

        private void init_reader()
        {
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
            this.m_Disposed = false;
            this.m_Closed = true;
        }

        private void Initialize()
        {
            this.m_Disposed = false;
            this.m_Closed = false;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        public IDataReader Open()
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBOLOVANJEFONDSelect5 = this.connDefault.GetCommand("SELECT T2.[NAZIVELEMENT] AS ELEMENTBOLOVANJENAZIVELEMENT, TM1.[KOLONA], TM1.[ELEMENTBOLOVANJEIDELEMENT] AS ELEMENTBOLOVANJEIDELEMENT FROM ([BOLOVANJEFOND] TM1 WITH (NOLOCK) LEFT JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = TM1.[ELEMENTBOLOVANJEIDELEMENT]) ORDER BY TM1.[ELEMENTBOLOVANJEIDELEMENT] ", false);
            this.BOLOVANJEFONDSelect5 = this.cmBOLOVANJEFONDSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.BOLOVANJEFONDSelect5;
        }

        public IDataReader OpenByELEMENTBOLOVANJEIDELEMENT(int eLEMENTBOLOVANJEIDELEMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBOLOVANJEFONDSelect5 = this.connDefault.GetCommand("SELECT T2.[NAZIVELEMENT] AS ELEMENTBOLOVANJENAZIVELEMENT, TM1.[KOLONA], TM1.[ELEMENTBOLOVANJEIDELEMENT] AS ELEMENTBOLOVANJEIDELEMENT FROM ([BOLOVANJEFOND] TM1 WITH (NOLOCK) LEFT JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = TM1.[ELEMENTBOLOVANJEIDELEMENT]) WHERE TM1.[ELEMENTBOLOVANJEIDELEMENT] = @ELEMENTBOLOVANJEIDELEMENT ORDER BY TM1.[ELEMENTBOLOVANJEIDELEMENT] ", false);
            if (this.cmBOLOVANJEFONDSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmBOLOVANJEFONDSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ELEMENTBOLOVANJEIDELEMENT", DbType.Int32));
            }
            this.cmBOLOVANJEFONDSelect5.SetParameter(0, eLEMENTBOLOVANJEIDELEMENT);
            this.BOLOVANJEFONDSelect5 = this.cmBOLOVANJEFONDSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.BOLOVANJEFONDSelect5;
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
    }
}

