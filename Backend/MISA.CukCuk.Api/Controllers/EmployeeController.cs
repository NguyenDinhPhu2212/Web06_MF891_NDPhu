using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    public class EmployeeController : BaseEntityController<Employee>
    {
        #region Constructor
        IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices) : base(employeeServices)
        {
            _employeeServices = employeeServices;
        }
        #endregion
        #region Lấy mã nhân viên lớn nhất
        [HttpGet("MaxEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var resMsg = _employeeServices.GetMaxEmployeeCode();
                if (!string.IsNullOrEmpty(resMsg.Data))
                {
                    return Ok(resMsg);
                }
                else return NoContent();
            }
            catch (Exception ex)
            {
                var resMsg = _employeeServices.BuildServerErrorMessage(ex);
                return StatusCode(500, resMsg);
            }
        }
        #endregion
        #region Lọc danh sách nhân viên theo trang
        [HttpGet("EmployeeFilter")]
        public async Task<IActionResult> GetEmployeesFilterPaging([FromQuery]string employeeFilter,
             [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            try
            {
                var resMsg = await _employeeServices.GetEmployeeFilterPaging(employeeFilter: employeeFilter,
                            pageIndex: pageIndex, pageSize: pageSize);
                if (resMsg.Data != null)
                {
                    return Ok(resMsg);
                }
                else return NoContent();
            }
            catch (Exception ex)
            {
                var resMsg = _employeeServices.BuildServerErrorMessage(ex);
                return StatusCode(500, resMsg);
            }
        }
        #endregion
        #region Kiểm tra trùng lặp mã nhân viên
        [HttpGet("Duplicate/{code}")]
        public IActionResult CheckEmployeeCodeExist(string code)
        {
            try
            {
                var duplicate = _employeeServices.CheckDuplicateCode(code);
                return Ok(duplicate);
            }
            catch (Exception ex)
            {
                var resMsg = _employeeServices.BuildServerErrorMessage(ex);
                return StatusCode(500, resMsg);
            }
        }
        #endregion
    }
}
