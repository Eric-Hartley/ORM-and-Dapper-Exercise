using Dapper;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection; //field

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection; //Value stored inside the field
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products");
        }

        

    }
}
