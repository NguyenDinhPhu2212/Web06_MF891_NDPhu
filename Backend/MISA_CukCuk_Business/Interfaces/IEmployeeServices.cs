using MISA.AMIS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces
{
    public interface IEmployeeServices : IBaseServices<Employee>
    {
        /// <summary>
        /// Lọc danh sách nhân viên theo trang
        /// </summary>
        /// <param name="employeeFilter">Keyword lọc theo họ tên, mã nhân viên, số điện thoại</param>
        /// <param name="departmentId">Định danh phòng ban</param>
        /// <param name="positionId">Định danh chức vụ</param>
        /// <param name="pageIndex">Lấy từ bản ghi thứ pageIndex</param>
        /// <param name="pageSize">Lấy pageSize bản ghi</param>
        /// <returns></returns>
        public Task<ResponseMessage<EmployeesFilterPaging<Employee>>> GetEmployeeFilterPaging(string employeeFilter,
             int pageIndex, int pageSize);
        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns></returns>
        public ResponseMessage<string> GetMaxEmployeeCode();
        /// <summary>
        /// Kiểm tra trùng lặp mã code
        /// </summary>
        /// <param name="EmployeeCode"></param>
        /// <returns></returns>
        public ResponseMessage<bool> CheckDuplicateCode(string EmployeeCode);
    }
}
