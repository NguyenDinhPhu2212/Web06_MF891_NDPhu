﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.AMIS.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.AMIS.Core.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thêm mới thành công..
        /// </summary>
        public static string Add_Successful {
            get {
                return ResourceManager.GetString("Add_Successful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa thông tin thành công..
        /// </summary>
        public static string Delete_Successfull {
            get {
                return ResourceManager.GetString("Delete_Successfull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Trong cơ sở dữ liệu không tồn tại dữ liệu liên quan. Vui lòng cung cấp lại thông tin..
        /// </summary>
        public static string ExistData {
            get {
                return ResourceManager.GetString("ExistData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra. Vui lòng liên hệ với MISA..
        /// </summary>
        public static string Server_Error {
            get {
                return ResourceManager.GetString("Server_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cập nhật thông tin thành công..
        /// </summary>
        public static string Update_Successful {
            get {
                return ResourceManager.GetString("Update_Successful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} đã tồn tại trong hệ thống. Vui lòng nhập {0} khác..
        /// </summary>
        public static string ValidateError_Duplicate {
            get {
                return ResourceManager.GetString("ValidateError_Duplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã phòng ban đã tồn tại trong hệ thống. Vui lòng nhập mã phòng ban khác..
        /// </summary>
        public static string ValidateError_DuplicateDepartmentCode {
            get {
                return ResourceManager.GetString("ValidateError_DuplicateDepartmentCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã nhân viên này đã tồn tại trong hệ thống. Vui lòng nhập mã nhân viên khác..
        /// </summary>
        public static string ValidateError_DuplicateEmployeeCode {
            get {
                return ResourceManager.GetString("ValidateError_DuplicateEmployeeCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã chức vụ đã tồn tại trong hệ thống. Vui lòng nhập mã chức vụ khác..
        /// </summary>
        public static string ValidateError_DuplicatePositionCode {
            get {
                return ResourceManager.GetString("ValidateError_DuplicatePositionCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Địa chỉ email không hợp lê. Vui lòng nhập địa chỉ email khác..
        /// </summary>
        public static string ValidateError_InvalidEmail {
            get {
                return ResourceManager.GetString("ValidateError_InvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số CMND/Căn cước không hợp lệ. Vui lòng nhập lại số CMND/Căn cước..
        /// </summary>
        public static string ValidateError_InvalidIdentityNumber {
            get {
                return ResourceManager.GetString("ValidateError_InvalidIdentityNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số điện thoại không hợp lệ. Vui lòng nhập lại số điện thoại..
        /// </summary>
        public static string ValidateError_InvalidPhoneNumber {
            get {
                return ResourceManager.GetString("ValidateError_InvalidPhoneNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} không được để trống..
        /// </summary>
        public static string ValidateError_RequiredFields {
            get {
                return ResourceManager.GetString("ValidateError_RequiredFields", resourceCulture);
            }
        }
    }
}
