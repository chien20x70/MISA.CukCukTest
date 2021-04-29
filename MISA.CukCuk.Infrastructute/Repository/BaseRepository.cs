﻿using MISA.CukCuk.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Dapper;

namespace MISA.CukCuk.Infrastructute.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {
        protected IDbConnection dbConnection;
        protected IConfiguration _configuration;
        protected string connectionString;
        protected string tableName = typeof(MISAEntity).Name;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("ConnectionDB");
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Get{tableName}s";
                var entities = dbConnection.Query<MISAEntity>(sql, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public MISAEntity GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Get{tableName}ById";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);
                var entity = dbConnection.QueryFirstOrDefault<MISAEntity>(sql, dynamicParameters,commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public IEnumerable<MISAEntity> GetEntityFilter(int pageSize, int pageIndex)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Get{tableName}Paging";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_PageIndex", pageIndex);
                dynamicParameters.Add("@m_PageSize", pageSize);
                var entities = dbConnection.Query<MISAEntity>(sql, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Insert{tableName}";
                //DynamicParameters dynamicParameters = new DynamicParameters();
                //dynamicParameters.Add($"@{tableName}Id", entityId);
                var rowEffects = dbConnection.Execute(sql, entity, commandType: CommandType.StoredProcedure);
                return rowEffects;
            }
        }

        public int Update(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Update{tableName}";
                //DynamicParameters dynamicParameters = new DynamicParameters();
                //dynamicParameters.Add($"@{tableName}Id", entityId);
                var rowEffects = dbConnection.Execute(sql, entity, commandType: CommandType.StoredProcedure);
                return rowEffects;
            }
        }

        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Insert{tableName}";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);
                var rowEffects = dbConnection.Execute(sql, dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowEffects;
            }
        }
    }
}