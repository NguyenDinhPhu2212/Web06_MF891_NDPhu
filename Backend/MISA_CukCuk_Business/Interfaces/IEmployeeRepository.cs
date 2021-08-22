
using MISA.AMIS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        /// <summary>
        /// Lọc danh sách nhân viên
        /// </summary>
        /// <param name="employeeFilter">Keyword lọc theo họ tên, mã nhân viên, số điện thoại</param>
        /// <param name="pageIndex">Lấy từ bản ghi thứ pageIndex</param>
        /// <param name="pageSize">Lấy pageSize bản ghi</param>
        /// <returns></returns>
        public Task<EmployeesFilterPaging<Employee>> GetEmployeeFilterPaging(string employeeFilter,
            int pageIndex, int pageSize);
        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns></returns>
        public string GetMaxEmployeeCode();
        /// <summary>
        /// Kiểm tra trùng lặp mã code
        /// </summary>
        /// <param name="EmployeeCode"></param>
        /// <returns></returns>
        public bool CheckDuplicateCode(string EmployeeCode);
    }
}
