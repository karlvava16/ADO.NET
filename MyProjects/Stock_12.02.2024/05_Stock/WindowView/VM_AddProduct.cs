using _05_Stock.InterfaceImp;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _05_Stock.WindowView
{
    
    public struct Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public partial class VM_AddProduct : ObservableObject, INotifyPropertyChanged
    {
        [ObservableProperty] List<Supplier> suppliers;

        [ObservableProperty] string name;
        [ObservableProperty] string type;
        [ObservableProperty] Supplier supplier;
        [ObservableProperty] int count;
        [ObservableProperty] decimal costPrice;
        [ObservableProperty] decimal price;

        DataBaseCrudDefault def;
        public VM_AddProduct () { }
        public VM_AddProduct(DataBaseCrudDefault def) 
        {
            this.def = def;
            InitializeSuppliers();
        }
       
        private void InitializeSuppliers()
        {
            DataTable suppliersTable = def.GetSupplierDataTable();
            if (suppliersTable != null)
            {
                Suppliers = new List<Supplier>();

                foreach (DataRow row in suppliersTable.Rows)
                {
                    int id = (int)row["Id"];
                    string name = row["SupplierName"].ToString();

                    Supplier supplier = new Supplier { Id = id, Name = name };
                    Suppliers.Add(supplier);
                }
            }
        }
    }
}
