using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Automation;
using System.Windows.Navigation;

namespace StockManager
{
    class Supplier { 
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierPhone { get; set; }

        public override string ToString()
        {
            return $"{Id}\n{SupplierName}\n{SupplierName}\n{SupplierAddress}\n{SupplierPhone}";
        }
    }


    class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int SupplierID { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }

        public override string ToString()
        {
            return $"{Id}\n{ProductName}\n{ProductType}\n{SupplierID}\n{Quantity}\n{Cost}";
        }
    }




    class Model
    {
        public List<Product> products;
        public List<Supplier> suppliers;
        string SourceConnection = "";
        string DatabaseName = "";

        public Model(string sc, string db)
        {
            SourceConnection = sc;
            DatabaseName = db;
        }


        public void GetSuppliers()
        {
            SqlConnection connect = new SqlConnection($"Initial Catalog={DatabaseName};Data Source={SourceConnection};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Suppliers";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;

                for (int i = 0; reader.Read(); i += count)
                {
                    Supplier supplier = new Supplier();
                    supplier.Id = Convert.ToInt32(reader[i].ToString());
                    supplier.SupplierName = reader[i + 1].ToString();
                    supplier.SupplierAddress = reader[i + 2].ToString();
                    supplier.SupplierPhone = reader[i + 3].ToString();
                    suppliers.Add(supplier);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }



        public void GetProducts()
        {
            SqlConnection connect = new SqlConnection($"Initial Catalog={DatabaseName};Data Source={SourceConnection};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Products";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;

                for (int i = 0; reader.Read(); i += count)
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(reader[i].ToString());
                    product.ProductName = reader[i + 1].ToString();
                    product.ProductType = reader[i + 2].ToString();
                    product.SupplierID = Convert.ToInt32(reader[i + 3].ToString());
                    product.Quantity = Convert.ToInt32(reader[i + 4].ToString());
                    product.Cost = Convert.ToInt32(reader[i + 5].ToString());
                    products.Add(product);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }
    }
}
