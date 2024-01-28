using System.Windows;
using JollibeeOrderingSystem.Models;


namespace JollibeeOrderingSystem
{
    /// <summary>
    /// Interaction logic for PayOrder.xaml
    /// </summary>
    public partial class PayOrder : Window
    {
        private Order Order { get; set; }   
        public PayOrder(Order order)
        {
            InitializeComponent();
            this.Order = order;
            OrderList_Dg.ItemsSource = Order.Items;
            Price_Lbl.Content = "₱ " + Order.GetTotalPrice();
            Order_Description_Lbl.Content = "Order #" + Order.Id + " | " + Order.Type;
        }

        private void Pay_Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Order paid successfully.");
            MainWindow mainWindow = new MainWindow(new Order(++this.Order.Id));
            mainWindow.Show();
            this.Close();
        }
    }
}
