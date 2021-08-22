using MISA.AMIS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.AMIS.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace MISA.AMIS.Repository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        #region Constructor
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
        
    }
}
