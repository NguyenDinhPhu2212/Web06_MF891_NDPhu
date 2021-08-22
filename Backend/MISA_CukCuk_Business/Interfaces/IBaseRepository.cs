using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy tất cả các bản ghi trong database
        /// </summary>
        /// <returns>Tất cả các bản ghi</returns>
        public Task<IEnumerable<MISAEntity>> GetAll();
        /// <summary>
        /// Lấy ra bản ghi theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>Bản ghi đầu tiên hoặc không có</returns>
        public Task<MISAEntity> GetById(Guid entityId);
        /// <summary>
        /// Xóa bản ghi theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính</param>
        /// <returns>số cột bị ảnh hưởng</returns>
        public Task<int> DeleteById(Guid entityId);
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm</param>
        /// <returns>Số cột ảnh hưởng</returns>
        public Task<int> Add(MISAEntity entity);
        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns></returns>
        public Task<int> Update(MISAEntity entity);
        /// <summary>
        /// Kiểm tra trùng lặp trong database
        /// </summary>
        /// <param name="prop">Property cần kiểm tra</param>
        /// <param name="entity">Bản ghi cần kiểm tra</param>
        /// <returns>true-nếu đã tồn tại, ngược lại là false</returns>
        public bool CheckDuplicate(PropertyInfo prop, MISAEntity entity);
    }
}
