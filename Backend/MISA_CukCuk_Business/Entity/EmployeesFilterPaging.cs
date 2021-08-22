using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Entity
{
    public class EmployeesFilterPaging<MISAEntity>
    {
        public int TotalPage { get; set; }
        public int TotalRecord { get; set; }
        public IEnumerable<MISAEntity> Data { get; set; }
    }
}
