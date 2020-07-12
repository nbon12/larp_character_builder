﻿using System;
using System.Data;

namespace Core.CQRS
{
    public interface IDataSession : IDisposable
    {
        bool UseTransaction { get; }
        IDbTransaction Transaction { get; }
        IDbConnection Connection { get; }
        void BeginTransaction();
    }
}