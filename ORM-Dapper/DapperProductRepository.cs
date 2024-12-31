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
    internal class DapperProductRepository : IProductRepository // must implement the Interface's methods
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

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id",
                new { id = id });
        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products " +
                "SET Name = @name, " +
                "Price = @price, " +
                "CategoryID = @catID, " +
                "OnSale = @onSale, " +
                "StockLevel = @stock " +
                "WHERE ProductID = @id;",
                new {
                    id = product.ProductID,
                    name = product.Name,
                    price = product.Price,
                    catID = product.CategoryID,
                    onSale = product.OnSale,
                    stock = product.StockLevel
                    }
                );
        }

        public void DeleteProduct(int id)
        {
            _connection.Execute("DELETE FROM sales WHERE ProductID = @id;", new {id = id});
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @id;", new { id = id });
            _connection.Execute("DELETE FROM products WHERE ProductID = @id;", new { id = id });
        }
    }
}
