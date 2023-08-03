﻿using Dapper;
using System.Data.Common;
using System.Data;
using Data.Models;

namespace Data
{
    public interface IDapperRepository
    {
        DbConnection GetDbconnection();
        IDbConnection GetMasterConnection();
        Task<T> GetByDynamicParamAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<T> GetAsync<T>(string sp, object parms = null, CommandType commandType = CommandType.StoredProcedure, string connectionString = "");
        Task<IEnumerable<T>> GetAllAsync<T>(string sp, object parms = null, CommandType commandType = CommandType.StoredProcedure, string connectionString = "");     
        Task<int> ExecuteAsync(string sp, object parms = null, CommandType commandType = CommandType.StoredProcedure, string connectionString = "");
        Task<T> InsertAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<T> UpdateAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<dynamic> GetMultipleAsync<T1, T2>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<dynamic> GetMultipleAsync<T1, T2>(string sp, object parms, CommandType commandType = CommandType.StoredProcedure);



        //MultiWith Split
        Task<dynamic> GetMultipleAsync<T1, T2, TReturn>(string sp, object parms, Func<T1, T2, TReturn> p, string splitOn, CommandType commandType = CommandType.StoredProcedure);
        Task<dynamic> GetMultipleAsync<T1, T2, TReturn>(string sp, DynamicParameters parms, Func<T1, T2, TReturn> p, string splitOn, CommandType commandType = CommandType.StoredProcedure);







        Task<dynamic> GetMultipleAsync<T1, T2, T3>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        IEnumerable<TReturn> Get<T1, T2, TReturn>(string sqlQuery, Func<T1, T2, TReturn> p, string splitOn, DynamicParameters parms = null, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<TReturn>> GetAllAsyncProc<T1, T2, TReturn>(T1 entity, string sqlQuery, DynamicParameters parms, Func<T1, T2, TReturn> p, string splitOn);

        Task<IEnumerable<TReturn>> GetAllAsync<T1, T2, TReturn>(string sqlQuery, object param, Func<T1, T2, TReturn> p, string splitOn, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<TReturn>> GetAllAsync<T1, T2, T3, TReturn>(string sqlQuery, object param, Func<T1, T2, T3, TReturn> p, string splitOn, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<TReturn>> GetAllAsyncProc<T1, T2, T3, TReturn>(T1 entity, string sqlQuery, DynamicParameters parms,
            Func<T1, T2, T3, TReturn> p, string splitOn);
        Task<IEnumerable<TReturn>> GetAllAsyncProc<T1, T2, T3, T4, TReturn>(T1 entity, string sqlQuery, DynamicParameters parms, Func<T1, T2, T3, T4, TReturn> p, string splitOn);
        Task<IEnumerable<TReturn>> GetAllAsyncProc<T1, T2, T3, T4, T5, T6, T7, TReturn>(T1 entity, string sqlQuery, DynamicParameters parms, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> p, string splitOn);
        Task<JDataTable<T1>> GetJDatTableAsync<T1>(string sp, object parms, CommandType commandType = CommandType.StoredProcedure);
        Task<dynamic> GetMultipleAsync<T1, T2, T3, TReturn>(string sp, object parms, Func<T1, T2, T3, TReturn> p, string splitOn, CommandType commandType = CommandType.StoredProcedure);
        Parameters PrepareParameters(string sqlQuery, Dictionary<string, dynamic> args = null);
        Task saveLog(LogRequest request);
    }
}
