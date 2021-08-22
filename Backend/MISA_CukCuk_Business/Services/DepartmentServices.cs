using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.AMIS.Core.Properties;
using MISA.AMIS.Core.Const;

namespace MISA.AMIS.Core.Services
{
    public class DepartmentServices : BaseServices<Department>, IDepartmentServices
    {
        #region Constructor
        IDepartmentRepository _departmentRepository;
        public DepartmentServices(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
    }
}
