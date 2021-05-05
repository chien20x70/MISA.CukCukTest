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
using MISA.CukCuk.Core.Enums;

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

        /// <summary>
        /// Lấy danh sách tất cả các đối tượng
        /// </summary>
        /// <returns>Mảng danh sách đối tượng</returns>
        /// Created By: NXCHIEN 29/04/2021
        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Get{tableName}s";
                var entities = dbConnection.Query<MISAEntity>(sql, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        /// <summary>
        /// Lấy 1 đối tượng theo ID
        /// </summary>
        /// <param name="entityId">Mã ID của đối tượng</param>
        /// <returns>1 đối tượng có id là entityId</returns>
        /// Created By: NXCHIEN 29/04/2021
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

        /// <summary>
        /// Phân trang đối tượng
        /// </summary>
        /// <param name="pageSize">số đối tượng trên 1 trang</param>
        /// <param name="pageIndex">Trang số bao nhiêu</param>
        /// <returns>Mảng danh sách đối tượng</returns>
        /// Created By: NXCHIEN 29/04/2021
        public IEnumerable<MISAEntity> GetEntityFilter(int pageSize, int pageIndex)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Get{tableName}Paging";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_PageIndex", pageIndex);
                dynamicParameters.Add("@m_PageSize", pageSize);
                var entities = dbConnection.Query<MISAEntity>(sql, dynamicParameters,commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>số dòng trong bảng trong DB bị ảnh hưởng</returns>
        /// Created By: NXCHIEN 29/04/2021
        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Insert{tableName}";
                var rowEffects = dbConnection.Execute(sql, entity, commandType: CommandType.StoredProcedure);
                return rowEffects;
            }
        }

        /// <summary>
        /// Sửa 1 đối tượng 
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa</param>
        /// <returns>1 đối tượng đã được sửa</returns>
        /// Created By: NXCHIEN 29/04/2021
        public int Update(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Update{tableName}";
                var rowEffects = dbConnection.Execute(sql, entity, commandType: CommandType.StoredProcedure);
                return rowEffects;
            }
        }

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="entityId">Mã ID cảu đối tượng</param>
        /// <returns>Thông báo xóa thành công</returns>
        /// Created By: NXCHIEN 29/04/2021
        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Delete{tableName}";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);
                var rowEffects = dbConnection.Execute(sql, dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowEffects;
            }
        }


        //TODO: chưa cần dùng đến --- CheckCode dùng chung
        /// <summary>
        /// Check trùng mã đối tượng
        /// </summary>
        /// <param name="entityCode">Mã code của đối tượng</param>
        /// <param name="entityId">Mã ID của đối tượng</param>
        /// <param name="http">Phương thức POST OR PUT</param>
        /// <returns></returns>
        /// Created by: NXChien 29/04/2021
        /// Chưa cần dùng đến do customerGroup chưa cần.
        //public bool CheckEntityCodeExist(string entityCode, Guid entityId, HTTPType http)
        //{
        //    using (dbConnection = new MySqlConnection(connectionString))
        //    {
        //        var sqlCommandDuplicate = "";
        //        DynamicParameters parameters = new DynamicParameters();
        //        if (http == HTTPType.POST) // post
        //        {
        //            sqlCommandDuplicate = $"Proc_Check{tableName}CodeExists";
        //            parameters.Add($"@m_{tableName}Code", entityCode);
        //        }
        //        else if (http == HTTPType.PUT)  //put
        //        {
        //            sqlCommandDuplicate = $"Proc_H_Check{tableName}CodeExists";
        //            parameters.Add($"@{tableName}Code", entityCode);
        //            parameters.Add($"@{tableName}Id", entityId);
        //        }
        //        var check = dbConnection.QueryFirstOrDefault<bool>
        //            (sqlCommandDuplicate, param: parameters, commandType: CommandType.StoredProcedure);
        //        return check;
        //    }
        //}
    }
}
