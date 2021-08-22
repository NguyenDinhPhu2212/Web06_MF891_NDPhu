using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MISA.AMIS.Core.Entity;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Properties;
using MISA.AMIS.Core.Const;
using Dapper;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class EmployeeServices : BaseServices<Employee>, IEmployeeServices
    {
        #region Constructor
        IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ResponseMessage<bool> CheckDuplicateCode(string EmployeeCode)
        {
            ResponseMessage<bool> resMsg = new ResponseMessage<bool>();
            resMsg.Success = true;
            resMsg.Data = _employeeRepository.CheckDuplicateCode(EmployeeCode);
            return resMsg;
        }

        /// <summary>
        /// Lọc danh sách nhân viên
        /// </summary>
        /// <param name="employeeFilter">Keyword lọc theo họ tên, mã nhân viên, số điện thoại</param>
        /// <param name="pageIndex">Lấy từ bản ghi thứ pageIndex</param>
        /// <param name="pageSize">Lấy pageSize bản ghi</param>
        /// <returns>Danh sách nhân viên thỏa mãn</returns>
        public async Task<ResponseMessage<EmployeesFilterPaging<Employee>>> GetEmployeeFilterPaging(string employeeFilter, int pageIndex, int pageSize)
        {
            ResponseMessage<EmployeesFilterPaging<Employee>> resMsg = new ResponseMessage<EmployeesFilterPaging<Employee>>();
            resMsg.Success = true;
            resMsg.Data = await _employeeRepository.GetEmployeeFilterPaging(employeeFilter: employeeFilter,
                            pageIndex: pageIndex, pageSize: pageSize);
            return resMsg;
        }
        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        public ResponseMessage<string> GetMaxEmployeeCode()
        {
            ResponseMessage<string> resMsg = new ResponseMessage<string>();
            resMsg.Success = true;
            resMsg.Data =  _employeeRepository.GetMaxEmployeeCode();
            return resMsg;
        }

        #endregion

    }

}
