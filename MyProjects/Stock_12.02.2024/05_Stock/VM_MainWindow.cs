using _05_Stock.InterfaceImp;
using _05_Stock.WindowView;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace _05_Stock
{
    public partial class VM_MainWindow: ObservableObject
    {
        [ObservableProperty] DataTable table;
        DataBaseCrudDefault DB;
        public VM_MainWindow() 
        {
            DB = new ();
            GetProductDataTableCommand = new RelayCommand(GetProductDataTable, () => Table.TableName != "Products");
            GetSupplierDataTableCommand = new RelayCommand(GetSupplierDataTable, () => Table.TableName != "Suppliers");
        }
        public IRelayCommand GetProductDataTableCommand;

        private void GetProductDataTable()
        {
            Table = DB.GetProductDataTableWithLookup();
        }

        public IRelayCommand GetSupplierDataTableCommand;
        private void GetSupplierDataTable()
        {
            Table = DB.GetSupplierDataTable();
        }
        public IRelayCommand GetTypeOfProductDataTableCommand;
        

        public void Remove(DataRow row) 
        {
            DB.Remove(row);
        }

        public void AddItem()
        {
            if (Table.TableName == "Products")
            {
                VM_AddProduct vm = new VM_AddProduct(DB);
                AddProduct v = new AddProduct();
                v.DataContext = vm;
                if (v.ShowDialog() == true)
                {
                    DB.AddProduct(vm.Name, vm.Type, vm.Supplier.Id, vm.Count, vm.CostPrice, DateTime.Now);
                    GetProductDataTable();
                }
            }
            else
            {
                VM_AddSupplier vm = new VM_AddSupplier();
                AddType v = new AddType();
                GetSupplierDataTable();
                v.DataContext = vm;
                if (v.ShowDialog() == true)
                {
                    DB.AddSupplier(vm.Name);
                    GetSupplierDataTable();
                }

                

            }
        }

        public async Task UpdateItem(DataRow row, string ColumnName, object OldValue, object newValue)
        {
            if ((string)OldValue == (string)newValue) { return; }
            if (MessageBox.Show($"Вы действительно хотите изменить {OldValue} на {newValue}", "Confirmations", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    await DB.UpdateValue(row,ColumnName,newValue);
                }
                catch {throw; }
            }
            else { throw new Exception(); }
        }
    }
}
