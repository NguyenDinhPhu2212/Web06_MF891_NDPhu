using MISA.AMIS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces
{
    public interface IBaseServices<MISAEntity>
    {
        /// <summary>
        /// Lấy các bản ghi trong database
        /// </summary>
        /// <returns>Tất cả bản ghi trong database</returns>
        public Task<ResponseMessage<IEnumerable<MISAEntity>>> GetAll();
        /// <summary>
        /// Lấy bản ghi theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns></returns>
        public Task<ResponseMessage<MISAEntity>> GetById(Guid entityId);
        /// <summary>
        /// Xóa bản ghi theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Thông điệp trả lời chuẩn resful</returns>
        public Task<ResponseMessage<int>> DeleteById(Guid entityId);
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm mới</param>
        /// <returns>Thông điệp trả lời chuẩn resful</returns>
        public Task<ResponseMessage<int>> Add(MISAEntity entity);
        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cập nhật</param>
        /// <returns>Thông điệp trả lời chuẩn resful</returns>
        public Task<ResponseMessage<int>> Update(MISAEntity entity);
        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">Bản ghi cần validate</param>
        /// <returns>Thông điệp trả lời chuẩn resful</returns>
        public ResponseMessage<int> Validate(MISAEntity entity);
        /// <summary>
        /// Dựng thông điệp nếu lỗi server
        /// </summary>
        /// <param name="ex">Ngoại lệ xảy ra</param>
        /// <returns>Thông điệp chuẩn resful</returns>
        public ResponseMessage<string> BuildServerErrorMessage(Exception ex);
    }
}
