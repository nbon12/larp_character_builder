﻿using System;
using System.Data;

namespace LarpCharacterBuilder3.Core.Dapper
{
    public interface IDataSession : IDisposable
    {
        bool UseTransaction { get; }
        IDbTransaction Transaction { get; }
        IDbConnection Connection { get; }
        void BeginTransaction();
    }
}