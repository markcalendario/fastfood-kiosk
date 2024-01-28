using JollibeeOrderingSystem.Models;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace JollibeeOrderingSystem
{
    /// <summary>
    /// Interaction logic for OrderingView.xaml
    /// </summary>
    public partial class OrderingView : Window
    {
        private List<Item> Items { get; set; }
        private Order Order { get; set; }
        private Item? SelectedItem { get; set;}
        private int Quantity { get; set; }

        public OrderingView(Order order)
        {
            InitializeComponent();
            this.Items = [];
            this.Order = order;
            this.SelectedItem = null;
            this.Quantity = 0;
        }
        private List<Item> GetItemsFromJSON(string filePath)
        {
            List<Item>? items = [];

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                items = JsonSerializer.Deserialize<List<Item>>(jsonString);
            }
            else
            {
                MessageBox.Show("Data is missing.");
            }

            if (items == null)
            {
                return [];
            }

            return items;
        }

        public void LoadItems(string filePath)
        {
            Items.AddRange(GetItemsFromJSON(filePath));
            ItemsContainer_Ic.ItemsSource = this.Items;
        }
        private void Item_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                object Id = button.Tag;
                Item? itemData = this.Items.FirstOrDefault(obj => obj.Id == Id.ToString());

                if (itemData == null) return;

                this.SelectedItem = new Item(itemData.Id, itemData.Name, itemData.Price, itemData.Image);
                this.Quantity = 1;

                UpdateQuantityPreview();
                UpdateImagePreview();
                UpdateNamePreview();
                UpdatePricePreview();
            }
        }
        private void UpdateQuantityPreview()
        {
            Quantity_Lbl.Content = this.Quantity;
        }
        private void UpdateImagePreview()
        {
            string imageLocation = this.SelectedItem?.Image ?? "Images/logo.png";

            // Display Image on Sidebar Preview
            BitmapImage bitmapImage = new();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageLocation, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            Preview_Img.Source = bitmapImage;
        }

        private void UpdateNamePreview()
        {
            // Display Name on Sidebar
            SelectedItem_Tb.Text = this.SelectedItem?.Name ?? "Select an Item";
        }

        private void UpdatePricePreview()
        {
            // Display Price on Sidebar
            Price_Lbl.Content = this.SelectedItem?.Price * this.Quantity;
        }

        private void IncrementQuantity_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.SelectedItem == null) return;

            this.Quantity += 1;
            Quantity_Lbl.Content = this.Quantity;

            UpdatePricePreview();
        }

        private void DecrementQuantity_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Quantity <= 0) return;

            this.Quantity -= 1;
            Quantity_Lbl.Content = this.Quantity;

            UpdatePricePreview();

            if (this.Quantity <= 0)
            {
                this.SelectedItem = null;
                UpdatePricePreview();
                UpdateImagePreview();
                UpdateNamePreview();
            }
        }

        private void AddToOrder_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.SelectedItem == null) return;

            Order.PlaceOrder(
                new OrderItem(
                    this.SelectedItem.Id, 
                    this.SelectedItem.Name, 
                    this.SelectedItem.Price, 
                    this.SelectedItem.Image, 
                    this.Quantity
                )
            );

            MainMenu mainMenu = new MainMenu(this.Order);
            mainMenu.Show();
            this.Close();
        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(this.Order);
            mainMenu.Show();
            this.Close();
        }
    }
}
