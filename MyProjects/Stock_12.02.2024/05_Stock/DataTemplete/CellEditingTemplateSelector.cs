﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _05_Stock.DataTemplete
{
    public class CellEditingTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextBoxTemplate { get; set; }
        public DataTemplate ComboBoxTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataRowView dataRowView = item as DataRowView;
            if (dataRowView != null)
            {
                DataTable table = dataRowView.Row.Table;
                string columnName = dataRowView.Row.Table.Columns[dataRowView.Row.Table.Columns.IndexOf(dataRowView.Row.Table.Columns[container.GetValue(DataGridColumn.HeaderProperty).ToString()])].ColumnName;
                if (table.TableName == "Products")
                {
                    if (columnName == "ID")
                    {
                        return ComboBoxTemplate;
                    }
                }
            }

            return TextBoxTemplate;
        }
    }
}
