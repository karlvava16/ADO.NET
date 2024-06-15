﻿using _05_Stock.DataTemplete;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05_Stock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM_MainWindow VM;
        public MainWindow()
        {
            InitializeComponent();
            VM = (VM_MainWindow)this.DataContext;
        }
        private async void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
                DataRowView rowView = e.Row.Item as DataRowView;
                if (rowView != null)
                {
                    DataRow row = rowView.Row;

                    var column = e.Column.Header.ToString();

                    var oldValue = rowView.Row[column];
                    var cellContent = e.EditingElement as TextBox;
                    var newValue = cellContent.Text;
                    try
                    {
                        await VM.UpdateItem(row, column, oldValue, newValue);
                    }
                    catch (Exception ex)
                    {
                        e.Cancel = true;
                        row[column] = oldValue;
                    }
                }
        }
        private void GetProductCommand(object sender, RoutedEventArgs e)
        {
            VM.GetProductDataTableCommand.Execute(null);
        }
        
        private void GetSupplierCommand(object sender, RoutedEventArgs e)
        {
            VM.GetSupplierDataTableCommand.Execute(null);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItem is DataRowView row)
            {
                try
                {
                    VM.Remove(row.Row);
                    VM.GetProductDataTableCommand.Execute(null);
                }
                catch { }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                VM.AddItem();
            }
            catch { }
        }
    }
}