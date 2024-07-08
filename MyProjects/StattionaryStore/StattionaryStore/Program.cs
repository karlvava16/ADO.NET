using System;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json.Linq;

namespace StationeryStoreApp
{
    class Program
    {
        private static string _connectionString;

        static void Main(string[] args)
        {
            _connectionString = LoadConnectionString("StationeryStore");

            Console.WriteLine("Connecting to the database...");
            if (!ConnectToDatabase(_connectionString))
            {
                Console.WriteLine("Failed to connect to the database. Press any key to exit.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Successfully connected to the database.");

            DisplayMenu();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.Write("Select an option: ");
                string input = Console.ReadLine()?.Trim();

                switch (input?.ToLower())
                {
                    case "1":
                        DisplayAllProducts();
                        break;
                    case "2":
                        DisplayAllProductTypes();
                        break;
                    case "3":
                        DisplayAllSalesManagers();
                        break;
                    case "4":
                        DisplayProductsWithMaxQuantity();
                        break;
                    case "5":
                        DisplayProductsWithMinQuantity();
                        break;
                    case "6":
                        DisplayProductsWithMinCost();
                        break;
                    case "7":
                        DisplayProductsWithMaxCost();
                        break;
                    case "8":
                        InsertNewProduct();
                        break;
                    case "9":
                        InsertNewProductType();
                        break;
                    case "10":
                        InsertNewSalesManager();
                        break;
                    case "11":
                        InsertNewBuyerCompany();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            DisconnectFromDatabase();
            Console.WriteLine("Disconnected from the database. Press any key to exit.");
            Console.ReadKey();
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Stationery Store Database Menu ===");
            Console.WriteLine("1. Display all products");
            Console.WriteLine("2. Display all product types");
            Console.WriteLine("3. Display all sales managers");
            Console.WriteLine("4. Display products with maximum quantity");
            Console.WriteLine("5. Display products with minimum quantity");
            Console.WriteLine("6. Display products with minimum cost");
            Console.WriteLine("7. Display products with maximum cost");
            Console.WriteLine("8. Insert new product");
            Console.WriteLine("9. Insert new product type");
            Console.WriteLine("10. Insert new sales manager");
            Console.WriteLine("11. Insert new buyer company");
            Console.WriteLine("Type 'exit' to quit the application");
            Console.WriteLine();
        }


        static string LoadConnectionString(string name)
        {
            try
            {
                var json = File.ReadAllText("appsettings.json");
                var jobject = JObject.Parse(json);
                return jobject["ConnectionStrings"]["DefaultConnection"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the connection string: {ex.Message}");
                return null;
            }
        }

        static bool ConnectToDatabase(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Connection string is null or empty.");
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Connection successful
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        static void DisconnectFromDatabase()
        {
            // Clean up resources if needed
        }

        static void DisplayAllProducts()
        {
            Console.WriteLine("=== All Products ===");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT ProductID, ProductName, Quantity, Cost FROM Products";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10}", "ID", "Product Name", "Quantity", "Cost");
                            Console.WriteLine(new string('-', 50));

                            while (reader.Read())
                            {
                                int productId = (int)reader["ProductID"];
                                string productName = reader["ProductName"].ToString();
                                int quantity = (int)reader["Quantity"];
                                decimal cost = (decimal)reader["Cost"];

                                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10:C}", productId, productName, quantity, cost);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching products: {ex.Message}");
            }
        }

        static void DisplayAllProductTypes()
        {
            Console.WriteLine("=== All Product Types ===");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT ProductTypeName FROM ProductTypes";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string productTypeName = reader["ProductTypeName"].ToString();
                                Console.WriteLine(productTypeName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching product types: {ex.Message}");
            }
        }

        static void DisplayAllSalesManagers()
        {
            Console.WriteLine("=== All Sales Managers ===");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT ManagerName FROM SalesManagers";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string managerName = reader["ManagerName"].ToString();
                                Console.WriteLine(managerName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching sales managers: {ex.Message}");
            }
        }

        static void DisplayProductsWithMaxQuantity()
        {
            Console.WriteLine("=== Products with Maximum Quantity ===");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT ProductID, ProductName, Quantity, Cost FROM Products WHERE Quantity = (SELECT MAX(Quantity) FROM Products)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10}", "ID", "Product Name", "Quantity", "Cost");
                            Console.WriteLine(new string('-', 50));

                            while (reader.Read())
                            {
                                int productId = (int)reader["ProductID"];
                                string productName = reader["ProductName"].ToString();
                                int quantity = (int)reader["Quantity"];
                                decimal cost = (decimal)reader["Cost"];

                                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10:C}", productId, productName, quantity, cost);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching products with maximum quantity: {ex.Message}");
            }
        }

        static void DisplayProductsWithMinQuantity()
        {
            Console.WriteLine("=== Products with Minimum Quantity ===");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT ProductID, ProductName, Quantity, Cost FROM Products WHERE Quantity = (SELECT MIN(Quantity) FROM Products)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10}", "ID", "Product Name", "Quantity", "Cost");
                            Console.WriteLine(new string('-', 50));

                            while (reader.Read())
                            {
                                int productId = (int)reader["ProductID"];
                                string productName = reader["ProductName"].ToString();
                                int quantity = (int)reader["Quantity"];
                                decimal cost = (decimal)reader["Cost"];

                                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10:C}", productId, productName, quantity, cost);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching products with minimum quantity: {ex.Message}");
            }
        }

        static void DisplayProductsWithMinCost()
        {
            Console.WriteLine("=== Products with Minimum Cost per Unit ===");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT ProductID, ProductName, Quantity, Cost FROM Products WHERE Cost = (SELECT MIN(Cost) FROM Products)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10}", "ID", "Product Name", "Quantity", "Cost");
                            Console.WriteLine(new string('-', 50));

                            while (reader.Read())
                            {
                                int productId = (int)reader["ProductID"];
                                string productName = reader["ProductName"].ToString();
                                int quantity = (int)reader["Quantity"];
                                decimal cost = (decimal)reader["Cost"];

                                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10:C}", productId, productName, quantity, cost);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching products with minimum cost: {ex.Message}");
            }
        }

        static void DisplayProductsWithMaxCost()
        {
            Console.WriteLine("=== Products with Maximum Cost per Unit ===");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "SELECT ProductID, ProductName, Quantity, Cost FROM Products WHERE Cost = (SELECT MAX(Cost) FROM Products)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10}", "ID", "Product Name", "Quantity", "Cost");
                            Console.WriteLine(new string('-', 50));

                            while (reader.Read())
                            {
                                int productId = (int)reader["ProductID"];
                                string productName = reader["ProductName"].ToString();
                                int quantity = (int)reader["Quantity"];
                                decimal cost = (decimal)reader["Cost"];

                                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-10:C}", productId, productName, quantity, cost);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching products with maximum cost: {ex.Message}");
            }
        }
        

        static void InsertNewProduct()
        {
            Console.WriteLine("=== Insert New Product ===");

            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine()?.Trim();

            Console.Write("Enter Product Type ID: ");
            if (!int.TryParse(Console.ReadLine()?.Trim(), out int productTypeId))
            {
                Console.WriteLine("Invalid Product Type ID.");
                return;
            }

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine()?.Trim(), out int quantity))
            {
                Console.WriteLine("Invalid Quantity.");
                return;
            }

            Console.Write("Enter Cost: ");
            if (!decimal.TryParse(Console.ReadLine()?.Trim(), out decimal cost))
            {
                Console.WriteLine("Invalid Cost.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Products (ProductName, ProductTypeID, Quantity, Cost) VALUES (@ProductName, @ProductTypeID, @Quantity, @Cost)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@ProductTypeID", productTypeId);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@Cost", cost);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Product inserted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert product.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting product: {ex.Message}");
            }
        }

        static void InsertNewProductType()
        {
            Console.WriteLine("=== Insert New Product Type ===");

            Console.Write("Enter Product Type Name: ");
            string productTypeName = Console.ReadLine()?.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO ProductTypes (ProductTypeName) VALUES (@ProductTypeName)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProductTypeName", productTypeName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Product type inserted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert product type.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting product type: {ex.Message}");
            }
        }

        static void InsertNewSalesManager()
        {
            Console.WriteLine("=== Insert New Sales Manager ===");

            Console.Write("Enter Manager Name: ");
            string managerName = Console.ReadLine()?.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO SalesManagers (ManagerName) VALUES (@ManagerName)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ManagerName", managerName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Sales manager inserted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert sales manager.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting sales manager: {ex.Message}");
            }
        }

        static void InsertNewBuyerCompany()
        {
            Console.WriteLine("=== Insert New Buyer Company ===");

            Console.Write("Enter Company Name: ");
            string companyName = Console.ReadLine()?.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO BuyerCompanies (CompanyName) VALUES (@CompanyName)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CompanyName", companyName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Buyer company inserted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert buyer company.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting buyer company: {ex.Message}");
            }
        }
    }
}
