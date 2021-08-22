using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Constructor
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Lọc danh sách nhân viên theo trang
        /// </summary>
        /// <param name="employeeFilter">Keyword lọc theo họ tên, mã nhân viên, số điện thoại</param>
        /// <param name="pageIndex">Lấy từ bản ghi thứ pageIndex</param>
        /// <param name="pageSize">Lấy pageSize bản ghi</param>
        /// <returns>Danh sách nhân viên thỏa mãn</returns>
        public async Task<EmployeesFilterPaging<Employee>> GetEmployeeFilterPaging(string employeeFilter,
            int pageIndex, int pageSize)
        {
            var employeesFilterPaging = new EmployeesFilterPaging<Employee>();
            int totalPage = 0;
            int totalRecord = 0;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeFilter", employeeFilter);
            parameters.Add("PageIndex", pageIndex);
            parameters.Add("PageSize", pageSize);
            parameters.Add("TotalPage", totalPage, DbType.Int32, ParameterDirection.Output);
            parameters.Add("TotalRecord", totalRecord, DbType.Int32, ParameterDirection.Output);
            //Truy vấn
            employeesFilterPaging.Data = await _dbConnection.QueryAsync<Employee>("Proc_GetEmployeesFilterPaging", parameters,
                commandType: CommandType.StoredProcedure);
            employeesFilterPaging.TotalPage = parameters.Get<int>("TotalPage");
            employeesFilterPaging.TotalRecord = parameters.Get<int>("TotalRecord");
            return employeesFilterPaging;
        }
        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        public string GetMaxEmployeeCode()
        {
            var newCode = _dbConnection.Query<string>("Proc_GetMaxEmployeeCode",
                commandType: CommandType.StoredProcedure).FirstOrDefault().ToString();

            return newCode;
        }

        public bool CheckDuplicateCode(string EmployeeCode)
        {
            var duplicate = false;
            //Khai báo lệnh truy vấn dữ liệu
            var sqlCommand = $"SELECT * FROM Employee WHERE EmployeeCode = '{EmployeeCode}'";
            //Truy vấn
            var response = _dbConnection.QueryFirstOrDefault<Employee>(sqlCommand);
            if (response != null)
            {
                duplicate = true;
            }
            return duplicate;
        }
        #endregion

    }
}
