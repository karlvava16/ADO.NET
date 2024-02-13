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

namespace StockManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model = new Model(@"DESKTOP-UIJQEL8\SQLEXPRESS", "Stock");
        public MainWindow()
        {
            InitializeComponent();
            model.GetProducts();
            model.GetSuppliers();
            foreach (var item in model.suppliers)
            {
                Console.WriteLine(item + "\n");
            }

            Console.WriteLine("--------------------");
            foreach (var item in model.products)
            {
                Console.WriteLine(item + "\n");
            }
        }
    }
}