using _05_Stock.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.IO;

namespace _05_Stock.InterfaceImp
{
    public partial class DataBaseCrudDefault : ObservableObject, IDataBaseCrud
    {
        [ObservableProperty] public string? connectionString;
        [ObservableProperty] public DataSet dataset = new();
        SqlConnection connection;
        Dictionary<string, SqlDataAdapter> adapters = new();
        Dictionary<string, SqlCommandBuilder> builders = new();
        Dictionary<string, DataTable> tables = new();
        public DataBaseCrudDefault()
        {

            ConnectionString = LoadConnectionString();
            connection = new SqlConnection(ConnectionString);
            CreatePrototypeTable();

        }
        public void AddProduct(string name, string type, int supplierId, int count, decimal costPrice, DateTime dateDelivery)
        {
            DataTable productTable = dataset.Tables["Products"];

            DataRow newRow = productTable.NewRow();
            newRow["ProductName"] = name;
            newRow["ProductType"] = type;
            newRow["SupplierID"] = supplierId;
            newRow["Quantity"] = count;
            newRow["Cost"] = costPrice;
            newRow["DeliveryDate"] = dateDelivery;

            productTable.Rows.Add(newRow);
            adapters["Products"].Update(dataset,"Products");
        }

        public void AddSupplier(string name)
        {
            DataTable supplierTable = dataset.Tables["Suppliers"];

            DataRow newRow = supplierTable.NewRow();
            newRow["SupplierName"] = name;

            supplierTable.Rows.Add(newRow);
            adapters["Suppliers"].Update(dataset, "Suppliers");
        }


        private void CreatePrototypeTable()
        {
           
            // Suppliers
            adapters.Add("Suppliers", new SqlDataAdapter("select * from Suppliers", connection));
            builders.Add("Suppliers", new SqlCommandBuilder(adapters["Suppliers"]));
            tables.Add("Suppliers", dataset.Tables.Add("Suppliers"));
            DataTable supplierTable = tables["Suppliers"];
            supplierTable.Columns.Add("ID", typeof(int));
            supplierTable.Columns.Add("SupplierName", typeof(string));
            supplierTable.Constraints.Add("PK_Suppliers", supplierTable.Columns["ID"], true); // Первичный ключ
            supplierTable.Columns["ID"].AutoIncrement = true; // Identity
            supplierTable.Columns["ID"].AllowDBNull = false; // Недопустима пустая ячейка
            supplierTable.Columns["SupplierName"].AllowDBNull = false;
            adapters["Suppliers"]?.Fill(dataset, "Suppliers");

            // Product
            adapters.Add("Products", new SqlDataAdapter("select * from Products", connection));
            builders.Add("Products", new SqlCommandBuilder(adapters["Products"]));
            tables.Add("Products", dataset.Tables.Add("Products"));
            DataTable productTable = tables["Products"];
            productTable.Columns.Add("ID", typeof(int));
            productTable.Columns.Add("ProductName", typeof(string));
            productTable.Columns.Add("ProductType", typeof(string));
            productTable.Columns.Add("SupplierID", typeof(int));
            productTable.Columns.Add("Quantity", typeof(int));
            productTable.Columns.Add("Cost", typeof(decimal));
            productTable.Columns.Add("DeliveryDate", typeof(DateTime));
            productTable.Constraints.Add("PK_Products", productTable.Columns["ID"], true); // Первичный ключ
            productTable.Columns["ID"].AutoIncrement = true; // Identity
            productTable.Columns["ID"].AllowDBNull = false; // Недопустима пустая ячейка
            productTable.Columns["ProductName"].AllowDBNull = false;
            productTable.Columns["Quantity"].AllowDBNull = false;
            productTable.Columns["Cost"].AllowDBNull = false;
            productTable.Columns["DeliveryDate"].AllowDBNull = false;
            adapters["Products"]?.Fill(dataset, "Products");

            ForeignKeyConstraint FK_Suppliers = // Внешний ключ
                new ForeignKeyConstraint("FK_Suppliers", supplierTable.Columns["id"], productTable.Columns["SupplierID"]);
            FK_Suppliers.DeleteRule = Rule.Cascade;
            FK_Suppliers.UpdateRule = Rule.Cascade;

          

        }

        private string LoadConnectionString()
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string jsonFilePath = Path.Combine(baseDirectory, "..\\..\\..\\appsettings.json");

                if (File.Exists(jsonFilePath))
                {
                    string jsonContent = File.ReadAllText(jsonFilePath);
                    JObject jsonObject = JObject.Parse(jsonContent);
                    return jsonObject["ConnectionStrings"]["DefaultConnection"].ToString();
                }
                else
                {
                    throw new FileNotFoundException("JSON file not found or invalid.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading connection string: " + ex.Message);
                throw;
            }
        }

        public DataTable GetProductDataTable()
        {
            return Dataset.Tables["Products"] ?? throw new Exception("Таблица не найдена");
        }
        public DataTable GetProductDataTableWithLookup()
        {
            var query = from productRow in dataset.Tables["Products"].AsEnumerable()
                        join supplierRow in dataset.Tables["Suppliers"].AsEnumerable()
                            on productRow.Field<int>("SupplierID") equals supplierRow.Field<int>("ID") into supplierJoin
                        from supplier in supplierJoin.DefaultIfEmpty()
                        select new
                        {
                            ProductId = productRow.Field<int>("ID"),
                            ProductName = productRow.Field<string>("ProductName"),
                            TypeName = productRow.Field<string>("ProductType"),
                            SupplierName = supplier?.Field<string>("SupplierName"),
                            Quantity = productRow.Field<int>("Quantity"),
                            CostPrice = productRow.Field<decimal>("Cost"),
                            DateDelivery = productRow.Field<DateTime>("DeliveryDate")
                        };
            DataTable resultTable = new DataTable();

            resultTable.TableName = "Products";
            resultTable.Columns.Add("ProductId", typeof(int));
            resultTable.Columns.Add("ProductName", typeof(string));
            resultTable.Columns.Add("TypeName", typeof(string));
            resultTable.Columns.Add("SupplierName", typeof(string));
            resultTable.Columns.Add("Quantity", typeof(int));
            resultTable.Columns.Add("CostPrice", typeof(decimal));
            resultTable.Columns.Add("DateDelivery", typeof(DateTime));

            foreach (var item in query)
            {
                resultTable.Rows.Add(item.ProductId, item.ProductName, item.TypeName, item.SupplierName, item.Quantity, item.CostPrice, item.DateDelivery);
            }

            return resultTable;
        }
        public async Task UpdateValue(DataRow row, string columnName, object newValue)
        {
            try
            {
                UpdateProduct(row, columnName, newValue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void UpdateProduct(DataRow row, string columnName, object newValue)
        {
            try
            {
                DataTable dt = tables[row.Table.TableName];
                DataRow rw = dt.Select("id = " + row.ItemArray[0])[0];

                string col;
                if (row.Table.TableName == "Products")
                {
                    col = columnName switch
                    {
                        "ProductId" => "ID",
                        "ProductName" => "ProductName",
                        "TypeName" => "ProductType",
                        "Type" => "ProductType",
                        "Name" => "ProductName",
                        "SupplierName" => "SupplierID",
                        "Count" => "Quantity",
                        "CostPrice" => "Cost",
                        "DateDelivery" => "DeliveryDate",
                        _ => throw new Exception("Поле не найдено")
                    };

                    if (columnName == "SupplierName")
                    {
                        DataRow[] supplierRows = tables["Supplier"].Select($"Name = '{newValue}'");
                        if (supplierRows.Length > 0)
                        {
                            int supplierId = supplierRows[0].Field<int>("ID");
                            rw[col] = supplierId;
                        }
                        else throw new Exception("Такого поставщика не существует. Добавьте его либо повторите попытку.");
                    }
                    else
                    {
                        rw[col] = newValue;
                    }
                }
                else
                {
                    col = columnName switch
                    {
                        "SupplierId" => "ID",
                        "SupplierName" => "SupplierName",

                        _ => throw new Exception("Поле не найдено")
                    };
                    rw[col] = newValue;
                }



                adapters[rw.Table.TableName].Update(dataset, rw.Table.TableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        public void Remove(DataRow row)
        {
            DataTable dt = tables[row.Table.TableName];
            DataRow rw = dt.Select("id = " + row.ItemArray[0])[0];
            dt.Rows.Remove(rw);
            if (dt.TableName == "Suppliers")
            {
                adapters[dt.TableName].Update(dataset, rw.Table.TableName);
            }
            adapters["Products"].Update(dataset, "Products");
        }


       
        public DataTable GetSupplierDataTable()
        {
            return Dataset.Tables["Suppliers"] ?? throw new Exception("Таблица не найдена");
        }
        
        public Task UpdateTable(string tableName)
        {
            try
            {
                adapters[tableName].Update(dataset, tableName);
            }
            catch { throw; };
            return Task.CompletedTask;
        }
    }
}
