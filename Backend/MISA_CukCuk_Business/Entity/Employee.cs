using MISA.AMIS.Core.Enum;
using MISA.AMIS.Core.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.AMIS.Core.Entity
{
    public class Employee:BaseEntity
    {
        #region Khai báo thuộc tính cho class Employee
        /*
         * Id của nhân viên
         */
        [Required]
        [PrimaryKey]
        public Guid EmployeeId { get; set; }
        /*
         * Tên nhân viên
         */
        [Required]
        [DisplayName("Tên nhân viên")]
        public String EmployeeName { get; set; }
        /*
         * Mã nhân viên
         */
        [Original]
        [Required]
        [DisplayName("Mã nhân viên")]
        public String EmployeeCode { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }
        /*
         * Email
         */
        [Email]
        public String Email { get; set; }
        /*
         * Số điện thoại
         */
        [PhoneNumber]
        public String PhoneNumber { get; set; }
        /*
         * Số CMND/Căn Cước
         */
        [IdentityNumber]
        public String IdentityNumber { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ngày cấp phát CMND/Căn cước
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp CMND/Căn cước
        /// </summary>
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public String TelephoneNumber { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// Tên chi nhánh  ngân hàng
        /// </summary>
        public string BankBranchName { get; set; }
        public string BankProvinceName { get; set; }
        /// <summary>
        /// Định danh phòng ban
        /// </summary>
        [Required]
        [DisplayName("Đơn vị")]
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Chức danh
        /// </summary>
        public String EmployeePosition { get; set; }
        /// <summary>
        /// Số TK
        /// </summary>
        public String BankAccountNumber { get; set; }
        #endregion
    }
}
