using JollibeeOrderingSystem.Models;
using System.Windows;
using System.Windows.Controls;

namespace JollibeeOrderingSystem
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private Order Order { get; set; }

        public MainMenu(Order order)
        {
            InitializeComponent();

            this.Order = order;
            OrderList_Dg.ItemsSource = Order.Items;
            Price_Tb.Text = Convert.ToString(Order.GetTotalPrice());
        }

        private void Category_Btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return; 

            string? tag = button.Tag.ToString();

            OrderingView orderingView = new OrderingView(this.Order);
            orderingView.Show();
            orderingView.LoadItems("./Data/" + tag + ".json");
            this.Close();
        }
        private void Clear_Btn(object sender, RoutedEventArgs e)
        {
            this.Order = new Order(this.Order.Id);
            OrderList_Dg.ItemsSource = Order.Items;
            Price_Tb.Text = Convert.ToString(this.Order.GetTotalPrice());
        }

        private void RemoveItem_Btn(object sender, RoutedEventArgs e)
        {
            OrderItem selectedItem = (OrderItem)OrderList_Dg.SelectedItem;
            Order.Items.Remove(selectedItem);
            OrderList_Dg.Items.Refresh();
            Price_Tb.Text = Convert.ToString(Order.GetTotalPrice());
        }

        private void DineIn_Btn_Click(object sender, RoutedEventArgs e)
        {
            Order.Type = "Dine In";
            PayOrder payOrder = new PayOrder(this.Order);
            payOrder.Show();
            this.Close();
        }

        private void TakeOut_Btn_Click(object sender, RoutedEventArgs e)
        {
            Order.Type = "Take Out";
            PayOrder payOrder = new PayOrder(this.Order);
            payOrder.Show();
            this.Close();
        }

        private void Exit_Btn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(new Order(this.Order.Id));
            mainWindow.Show();
            this.Close();
        }
    }
}
