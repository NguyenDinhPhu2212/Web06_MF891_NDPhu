using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Dapper;
using MySqlConnector;
using System.Linq;
using System.Reflection;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Entity;
using System.Data;
using System.Threading.Tasks;

namespace MISA.AMIS.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>, IDisposable where MISAEntity:BaseEntity
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        protected DbConnection _dbConnection = null;
        string entityName;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MyAMISConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            
            entityName = typeof(MISAEntity).Name;
        }
        #endregion
        #region Thực hiên lệnh truy vấn thêm mới bản ghi
        /// <summary>
        /// Thực hiện lệnh truy vấn thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm mới</param>
        /// <returns></returns>
        public async Task<int> Add(MISAEntity entity)
        {
            var parameters = MapingType(entity);
            var rowAffected = 0;

            _dbConnection.Open();
            using (var transition = _dbConnection.BeginTransaction())
            {
                try
                {
                    //Truy vấn
                    rowAffected = await _dbConnection.ExecuteAsync($"Proc_Insert{entityName}", parameters,
                        commandType: CommandType.StoredProcedure);
                    transition.Commit();
                }
                catch (Exception)
                {
                    transition.Rollback();
                }
            }
            return rowAffected;
        }
        #endregion
        #region Xóa bản ghi theo khóa chính
        /// <summary>
        /// Xóa bản ghi theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns></returns>
        public async Task<int> DeleteById(Guid entityId)
        {
            var rowAffected = 0;
            //Tạo câu truy vấn
            var sqlCommand = $"DELETE FROM {entityName} WHERE {entityName}Id = @{entityName}Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{entityName}Id", entityId);
            //Thực hiện truy vấn
            _dbConnection.Open();
            using (var transition = _dbConnection.BeginTransaction())
            {
                try
                {
                    rowAffected = await _dbConnection.ExecuteAsync(sql: sqlCommand, param: parameters);
                    transition.Commit();
                }
                catch (Exception)
                {
                    transition.Rollback();
                }
            }
            return rowAffected;
        }
        #endregion
        #region Lấy tất cả các bản ghi trong database
        public async Task<IEnumerable<MISAEntity>> GetAll()
        {  
            var entities = await _dbConnection.QueryAsync<MISAEntity>($"Proc_Get{entityName}s",
                commandType: CommandType.StoredProcedure);
               
            return entities;
        }
        #endregion
        #region Lấy bản ghi theo khóa chính
        public async Task<MISAEntity> GetById(Guid entityId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{entityName}Id", entityId.ToString());
            var entity = await _dbConnection.QueryFirstOrDefaultAsync<MISAEntity>($"Proc_Get{entityName}ById", parameters,
                         commandType: CommandType.StoredProcedure); 
            return entity;
        }
        #endregion
        #region Cập nhật bản ghi
        public async Task<int> Update(MISAEntity entity)
        {
            var rowAffected = 0;
            _dbConnection.Open();
            using (var transition = _dbConnection.BeginTransaction())
            {
                var parameters = MapingType(entity);
                //Truy vấn
                try
                {
                    rowAffected = await _dbConnection.ExecuteAsync($"Proc_Update{entityName}", parameters,
                    commandType: CommandType.StoredProcedure);
                    transition.Commit();
                }
                catch (Exception)
                {

                    transition.Rollback();
                }
            }
            return rowAffected;
        }
        #endregion
        #region Kiểm tra trùng lặp mã code
        public bool CheckDuplicate(PropertyInfo prop, MISAEntity entity)
        {
            var propName = prop.Name;
            var propValue = prop.GetValue(entity).ToString();
            if (entity.EntityState == Core.Enum.EntityState.Add)
            {
                //Khai báo lệnh truy vấn dữ liệu
                var sqlCommand = $"SELECT * FROM {entityName} WHERE {propName} = '{propValue}'";
                //Truy vấn
                var response = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand);
                if (response != null)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        #endregion
        #region Maping Type
        public DynamicParameters MapingType(MISAEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var paramerters = new DynamicParameters();
            foreach (var prop in properties)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);
                var propType = prop.PropertyType;
                if(propType == typeof(Guid) || propType == typeof(Guid?))
                {
                    paramerters.Add($"@{propName}", propValue, DbType.String);
                }else
                {
                    paramerters.Add($"@{propName}", propValue);
                }
            }
            return paramerters;
        }

        /// <summary>
        /// Hàm xóa đối tượng DbConnection để đỡ tốn tài nguyên
        /// </summary>
        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
            }
        }
        #endregion
    }
}
