using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Const;
using MISA.AMIS.Core.Entity;
using MISA.AMIS.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region Constructor
        IBaseServices<MISAEntity> _baseServices;
        public BaseEntityController(IBaseServices<MISAEntity> baseServices)
        {
            _baseServices = baseServices;
        }
        #endregion

        #region Methods

        #region Lấy toàn bộ các bản ghi trong database
        /// <summary>
        /// Lấy toàn bộ bản ghi trong database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var resMsg = await _baseServices.GetAll();
                if (resMsg.Data.Count() > 0)
                {
                    return Ok(resMsg);
                }
                else return NoContent();
            }
            catch (Exception ex)
            {
                var resMsg = _baseServices.BuildServerErrorMessage(ex);
                return StatusCode(500, resMsg);
            }
        }
        #endregion

        #region Lấy bản ghi theo khóa chính
        /// <summary>
        /// Lấy bản ghi theo khóa chính
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var resMsg = await _baseServices.GetById(id);
                if (resMsg.Data != null)
                {
                    return Ok(resMsg);
                }
                else return NoContent();
            }
            catch (Exception ex)
            {
                var resMsg = _baseServices.BuildServerErrorMessage(ex);
                return StatusCode(500, resMsg);
            }
        }
        #endregion

        #region Thêm mới bản ghi
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MISAEntity entity)
        {
            try
            {
                var resMsg = await _baseServices.Add(entity);
                return Ok(resMsg);
            }
            catch (Exception ex)
            {
                var resMsg = _baseServices.BuildServerErrorMessage(ex);
                return StatusCode(500, resMsg);
            }
        }
        #endregion

        #region Xóa bản ghi theo khóa chính
        /// <summary>
        /// Xóa bản ghi theo khóa chính
        /// </summary>
        /// <param name="id">Khóa chính</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var resMsg = await _baseServices.DeleteById(id);
                return Ok(resMsg);
            }
            catch (Exception ex)
            {
                var resMsg = _baseServices.BuildServerErrorMessage(ex);
                return StatusCode(500, resMsg);
            }
        }
        #endregion

        #region Cập nhật bản ghi
        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">Thông tin bản ghi đã được sửa đổi</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(MISAEntity entity)
        {
            try
            {
                var resMsg = await _baseServices.Update(entity);
                return Ok(resMsg);
            }
            catch (Exception ex)
            {
                var resMsg = _baseServices.BuildServerErrorMessage(ex);
                return StatusCode(500, resMsg);
            }
        }
        #endregion
        #endregion
    }
}
