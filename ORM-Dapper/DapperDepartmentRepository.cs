using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection; //field

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection; //Value stored inside the field
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments");
        }

    }
}
