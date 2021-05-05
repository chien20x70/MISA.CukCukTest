using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Enums;
using MISA.CukCuk.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Data;

namespace MISA.CukCuk.Infrastructute.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {      
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Check CustomerCode đã tồn tại hay chưa.
        /// </summary>
        /// <param name="customerCode">Mã khách hàng.</param>
        /// <param name="customerId">The customerId<see cref="Guid"/>.</param>
        /// <param name="http">The http<see cref="HTTPType"/>.</param>
        /// <returns>true or false.</returns>
        /// CreatedBy: NXChien (28/04/2021)
        public bool CheckCustomerCodeExist(string customerCode, Guid customerId, HTTPType http)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sqlCommandDuplicate = "";
                DynamicParameters parameters = new DynamicParameters();
                if (http == HTTPType.POST) // post
                {
                    sqlCommandDuplicate = "Proc_CheckCustomerCodeExists";
                    parameters.Add("@m_CustomerCode", customerCode);
                }
                else if (http == HTTPType.PUT)  //put
                {
                    sqlCommandDuplicate = "Proc_H_CheckCustomerCodeExists";
                    parameters.Add("@customerCode", customerCode);
                    parameters.Add("@customerId", customerId);
                }
                var check = dbConnection.QueryFirstOrDefault<bool>
                    (sqlCommandDuplicate, param: parameters, commandType: CommandType.StoredProcedure);
                return check;
            }
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại trong DB chưa.
        /// </summary>
        /// <param name="phoneNumber">.</param>
        /// <returns>.</returns>
        /// CreatedBy: NXChien (28/04/2021)
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sqlCommandDuplicate = "Proc_CheckPhoneNumberExists";
                var check = dbConnection.QueryFirstOrDefault<bool>
                    (sqlCommandDuplicate, param: new { m_PhoneNumber = phoneNumber }, commandType: CommandType.StoredProcedure);
                return check;
            }
        }
    }
}
