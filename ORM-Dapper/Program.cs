using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Departments
            /*var repo = new DapperDepartmentRepository(conn);

            var departments = repo.GetAllDepartments();

            foreach(var department in departments)
            {
                Console.WriteLine($"{department.DepartmentId} {department.Name}");
            }*/
            #endregion

            #region Products
            var productsRepo = new DapperProductRepository(conn);

            /*var productToUpdate = productsRepo.GetProduct(950);

            productToUpdate.Name = "Updated";
            productToUpdate.Price = 19.99;
            productToUpdate.CategoryID = 1;
            productToUpdate.OnSale = false;
            productToUpdate.StockLevel = 999;

            productsRepo.UpdateProduct(productToUpdate);
            */
            productsRepo.DeleteProduct(950);
            var products = productsRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductID}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"CategoryID: {product.CategoryID}");
                Console.WriteLine($"On Sale: {product.OnSale}");
                Console.WriteLine($"In Stock: {product.StockLevel}");
                Console.WriteLine("-----------------");
            }
            #endregion
        }
    }
}
