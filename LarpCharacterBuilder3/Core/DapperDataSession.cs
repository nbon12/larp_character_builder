using Core.CQRS;

namespace LarpCharacterBuilder3.Core
{
    using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Core.Dapper
{
    public interface IDapperDataSession : IDataSession
    {
        #region Synchronous Methods

        int Execute(string query, object param = null, CommandType commandType = CommandType.Text);

        IEnumerable<T> Query<T>(string query, object param = null, CommandType commandType = CommandType.Text);

        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map,
            object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id");

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id");

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id");

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id");

        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id");

        IEnumerable<dynamic> Query(string query, object param = null, CommandType commandType = CommandType.Text);
        SqlMapper.GridReader QueryMultiple(string query, object param = null, CommandType commandType = CommandType.Text);
        IDataReader ExecuteReader(string query, object param = null, CommandType commandType = CommandType.Text);

        #endregion

        #region Async Methods

        Task<int> ExecuteAsync(string query, object param = null, CommandType commandType = CommandType.Text);
        Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null, CommandType commandType = CommandType.Text);
        Task<T> QueryFirstAsync<T>(string query, object param = null, CommandType commandType = CommandType.Text);
        Task<T> QueryFirstOrDefaultAsync<T>(string query, object param = null, CommandType commandType = CommandType.Text);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id");
        Task<IEnumerable<object>> QueryAsync(string query, object param = null, CommandType commandType = CommandType.Text);
        Task<SqlMapper.GridReader> QueryMultipleAsync(string query, object param = null, CommandType commandType = CommandType.Text);

        #endregion
    }

    public class DapperDataSession : DataSession, IDapperDataSession
    {
        public DapperDataSession(IDbConnection connection, bool useTransaction = true)
            : base(connection, useTransaction) { }
        
        #region Synchronous Methods

        public int Execute(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            return Connection.Execute(query, param, Transaction, commandType: commandType);
        }

        public IEnumerable<T> Query<T>(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            return Connection.Query<T>(query, param, Transaction, commandType: commandType);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map,
            object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.Query(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return Connection.Query(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.Query(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.Query(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.Query(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
            string query, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
            object param = null, CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.Query(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public IEnumerable<dynamic> Query(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            return Connection.Query(query, param, Transaction, commandType: commandType);
        }

        public SqlMapper.GridReader QueryMultiple(string query, object param = null,
            CommandType commandType = CommandType.Text)
        {
            return Connection.QueryMultiple(query, param, Transaction, commandType: commandType);
        }

        public IDataReader ExecuteReader(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            return Connection.ExecuteReader(query, param, Transaction, commandType: commandType);
        }

        #endregion

        #region Async Methods

        public Task<int> ExecuteAsync(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            return Connection.ExecuteAsync(query, param, Transaction, commandType: commandType);
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null,
            CommandType commandType = CommandType.Text)
        {
            return Connection.QueryAsync<T>(query, param, Transaction, commandType: commandType);
        }
        
        public Task<T> QueryFirstAsync<T>(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            return Connection.QueryFirstAsync<T>(query, param, Transaction, commandType: commandType);
        }
        
        public Task<T> QueryFirstOrDefaultAsync<T>(string query, object param = null, CommandType commandType = CommandType.Text)
        {
            return Connection.QueryFirstOrDefaultAsync<T>(query, param, Transaction, commandType: commandType);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string query,
            Func<TFirst, TSecond, TReturn> map, object param = null, CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return Connection.QueryAsync(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, CommandType commandType = CommandType.Text,
            string splitOn = "Id")
        {
            return Connection.QueryAsync(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.QueryAsync(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string query,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.QueryAsync(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            string query, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null,
            CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.QueryAsync(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public Task<IEnumerable<TReturn>> QueryAsync
            <TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string query,
                Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null,
                CommandType commandType = CommandType.Text, string splitOn = "Id")
        {
            return Connection.QueryAsync(query, map, param, Transaction, commandType: commandType, splitOn: splitOn);
        }

        public Task<IEnumerable<dynamic>> QueryAsync(string query, object param = null,
            CommandType commandType = CommandType.Text)
        {
            return Connection.QueryAsync(query, param, Transaction, commandType: commandType);
        }

        public Task<SqlMapper.GridReader> QueryMultipleAsync(string query, object param = null,
            CommandType commandType = CommandType.Text)
        {
            return Connection.QueryMultipleAsync(query, param, Transaction, commandType: commandType);
        }

        #endregion
    }


}
}