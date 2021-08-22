using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entity
{
    public class ResponseMessage<T>
    {
        #region Khai báo thuộc tính cho thông điệp phản hồi
        /// <summary>
        /// 
        /// </summary>
        public Boolean Success { get; set; }
        /// <summary>
        /// Thông điệp của người phát triển
        /// </summary>
        public String DevMsg { get; set; }
        /// <summary>
        /// Thông điệp cho người dùng
        /// </summary>
        public String UserMsg { get; set; }
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public String ErrorCode { get; set; }
        public T Data { get; set; }
        #endregion
    }
}
