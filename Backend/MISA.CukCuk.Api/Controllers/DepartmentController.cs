using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    public class DepartmentController : BaseEntityController<Department>
    {
        #region Constructor
        IDepartmentServices _departmentServices;
        public DepartmentController(IDepartmentServices departmentServices) : base(departmentServices)
        {
            _departmentServices = departmentServices;
        }
        #endregion
    }
}
