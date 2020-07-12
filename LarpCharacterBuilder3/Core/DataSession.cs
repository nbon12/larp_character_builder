using System;
using System.Data;
using Core.CQRS;

namespace LarpCharacterBuilder3.Core
{
    public abstract class DataSession : IDataSession
    {
        protected DataSession(IDbConnection connection, bool useTransaction = true)
        {
            Connection = connection;
            UseTransaction = useTransaction;
        }

        public void BeginTransaction()
        {
            if (Transaction != null) return;
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            if(UseTransaction)
                Transaction = Connection.BeginTransaction();
        }

        public IDbConnection Connection { get; }
        public bool UseTransaction { get; }
        public IDbTransaction Transaction { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            Transaction?.Dispose();
            Connection?.Close();
        }
    }
}