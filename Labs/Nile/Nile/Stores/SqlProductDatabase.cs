/*
 * Hoa Luu
 * ITSE 1430
 * Lab 4
 * 11/25/2018 
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Nile.Stores.Sql
{
    /// <summary>Base class for product database.</summary>
    public class SqlProductDatabase : ProductDatabase
    {
        private string _connectionString; 
        public SqlProductDatabase(string connectionString )
        {
            _connectionString = connectionString;
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);
        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {

            var newProduct = ProductCopy(product);

            int prodId;

            using (SqlConnection conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@name", newProduct.Name),
                    new SqlParameter("@price", newProduct.Price),
                    new SqlParameter("@description", newProduct.Description),
                    new SqlParameter("@isDiscontinued", newProduct.IsDiscontinued)
                });

                conn.Open();
                if (Int32.TryParse(cmd.ExecuteScalar().ToString(), out prodId))
                {
                    newProduct.Id = prodId;
                }
                else
                {
                    throw new Exception($"Could not find product id: {product.Name}");
                }
            }
            
            return ProductCopy(newProduct);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        protected override Product GetCore ( int id )
        {
            var product = FindProduct(id);

            return (product != null) ? ProductCopy(product) : null;
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            using (SqlConnection conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Product()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            IsDiscontinued = reader.GetBoolean(4)
                        };
                    }
                }
            }
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
            var product = FindProduct(id);
            if (product != null)
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand("RemoveProduct", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore(Product existing, Product product)
        {
            //Replace
            var newProduct = ProductCopy(product);
            using (SqlConnection conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@id", newProduct.Id),
                    new SqlParameter("@name", newProduct.Name),
                    new SqlParameter("@price", newProduct.Price),
                    new SqlParameter("@description", newProduct.Description),
                    new SqlParameter("@isDiscontinued", newProduct.IsDiscontinued)
                });

                conn.Open();
                cmd.ExecuteNonQuery();

                return ProductCopy(newProduct);
            }
        }
        
        private Product ProductCopy ( Product product )
        {
            var newProduct = new Product();

            newProduct.Id = product.Id;
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }

        //Find a product by ID
        private Product FindProduct ( int id )
        {

            using(SqlConnection conn = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("GetProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (id != reader.GetInt32(0))
                            continue;

                        return new Product()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            IsDiscontinued = reader.GetBoolean(4)
                        };
                    }
                }
            }

            return null;
        }

        private List<Product> _products = new List<Product>();
    }
}
