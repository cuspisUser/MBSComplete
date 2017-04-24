namespace Placa
{
    using Deklarit.Data;
    using System;
    using System.Data;
    using System.Threading;

    public class DeklaritTransaction : IDeklaritTransaction
    {
        private IDbConnection m_Connection;
        private IDbTransaction m_Transaction;
        private static string m_TransactionSlotName = "Placa.DeklaritTransaction";

        public DeklaritTransaction()
        {
            this.m_Transaction = this.Connection.BeginTransaction();
            Thread.SetData(Thread.GetNamedDataSlot(m_TransactionSlotName), this.m_Transaction);
        }

        public DeklaritTransaction(System.Data.IsolationLevel il)
        {
            this.m_Transaction = this.Connection.BeginTransaction(il);
            Thread.SetData(Thread.GetNamedDataSlot(m_TransactionSlotName), this.m_Transaction);
        }

        public void Commit()
        {
            this.m_Transaction.Commit();
        }

        public void Dispose()
        {
            Thread.FreeNamedDataSlot(m_TransactionSlotName);
            this.m_Transaction.Dispose();
            this.m_Connection.Dispose();
        }

        public void Rollback()
        {
            this.m_Transaction.Rollback();
        }

        public IDbConnection Connection
        {
            get
            {
                if (this.m_Connection == null)
                {
                    this.m_Connection = Configuration.GetConnection();
                    this.m_Connection.Open();
                }
                return this.m_Connection;
            }
        }

        IDbConnection Deklarit.Data.IDeklaritTransaction.Connection
        {
            get
            {
                if (this.m_Connection == null)
                {
                    this.m_Connection = Configuration.GetConnection();
                    this.m_Connection.Open();
                }
                return this.m_Connection;
            }
        }

        System.Data.IsolationLevel Deklarit.Data.IDeklaritTransaction.IsolationLevel
        {
            get
            {
                return this.m_Transaction.IsolationLevel;
            }
        }

        public System.Data.IsolationLevel IsolationLevel
        {
            get
            {
                return this.m_Transaction.IsolationLevel;
            }
        }

        public static string TransactionSlotName
        {
            get
            {
                return m_TransactionSlotName;
            }
        }
    }
}

