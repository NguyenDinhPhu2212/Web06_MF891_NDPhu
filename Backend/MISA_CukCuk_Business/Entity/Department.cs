using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Entity
{
    public class Department :BaseEntity
    {
        #region Khai báo các thuộc tính cho class Department
        //Định danh phòng ban
        [Required]
        [PrimaryKey]
        public Guid DepartmentId { get; set; }
        //Tên phòng ban
        [Required]
        public String DepartmentName { get; set; }
        //Mã phòng ban
        [Required]
        [Original]
        public String DepartmentCode { get; set; }
        //mô tả
        [Required]
        public String Description { get; set; }
        #endregion
    }
}
