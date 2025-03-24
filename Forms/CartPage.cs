using InstrumentsApp.Context;
using InstrumentsApp.Models;
using InstrumentsApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InstrumentsApp.Forms {
    public partial class CartPage : UserControl {
        private readonly Cart? _cart;
        private readonly DataContext? _context;
        private readonly UserService? _userService;
        private readonly Dictionary<int, Panel> _itemPanels = [];
        public CartPage() {
            InitializeComponent();
            _context = Program.ServiceProvider.GetService<DataContext>();
            _userService = Program.ServiceProvider.GetService<UserService>();
            _cart = CartService.GetCart(_userService);
            if ((_cart?.Items.Count ?? 0) == 0) {
                Utilities.MessageBox.Show("No items in cart!");
                return;
            }
            LoadCartItems();
        }
        private void LoadCartItems() {
            foreach (var item in _cart.Items) {
                if (!_itemPanels.ContainsKey(item.Id)) {
                    Panel panel = CreateItemPanel(item);
                    _itemPanels[item.Id] = panel;
                    flowLayoutPanelCartItems.Controls.Add(panel);
                }
                else {
                    UpdateItemPanel(_itemPanels[item.Id], item);
                }
            }
        }
        private Panel CreateItemPanel(ItemEntry item) {
            Panel panel = new() {
                Width = 550,
                Height = 80,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                Margin = new Padding(5),
                BackColor = Color.FromArgb(50, 50, 50)
            };

            PictureBox pictureBox = new() {
                Image = Image.FromFile(item.Instrument.ImagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 80,
                Height = 60,
                Location = new Point(10, 10)
            };

            Label nameLabel = new() {
                Text = item.Instrument.Name,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(100, 10)
            };

            Label priceLabel = new() {
                Text = $"Price: {item.Price * item.Quantity:C}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(100, 35)
            };

            Label quantityLabel = new() {
                Text = $"Quantity: {item.Quantity}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(100, 55)
            };

            Button btnDecrease = new() {
                Text = "-",
                BackColor = Color.OrangeRed,
                ForeColor = Color.White,
                Width = 30,
                Height = 30,
                Location = new Point(250, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnDecrease.Click += (s, e) => UpdateQuantity(item, -1);

            Button btnIncrease = new() {
                Text = "+",
                BackColor = Color.Green,
                ForeColor = Color.White,
                Width = 30,
                Height = 30,
                Location = new Point(290, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnIncrease.Click += (s, e) => UpdateQuantity(item, 1);

            Button btnRemove = new() {
                Text = "Remove",
                BackColor = Color.Red,
                ForeColor = Color.White,
                Width = 80,
                Height = 30,
                Location = new Point(250, 45),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnRemove.Click += (s, e) => RemoveItem(item);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(quantityLabel);
            panel.Controls.Add(btnDecrease);
            panel.Controls.Add(btnIncrease);
            panel.Controls.Add(btnRemove);

            return panel;
        }
        private static void UpdateItemPanel(Panel panel, ItemEntry item) {
            foreach (Control control in panel.Controls) {
                if (control is Label label) {
                    if (label.Text.StartsWith("Quantity:")) {
                        label.Text = $"Quantity: {item.Quantity}";
                    }
                    if (label.Text.StartsWith("Price:")) {
                        label.Text = $"Price: {item.Price * item.Quantity:C}";
                    }
                }
            }
        }
        private void UpdateQuantity(ItemEntry item, int change) {
            if (change > 0 && !CartService.CheckStock(item.Instrument, out var message)) {
                Utilities.MessageBox.Show(message);
                return;
            }
            try {
                if (item.Quantity + change >= 1) {
                    item.Quantity += change;
                    _context.SaveChanges();
                }
            }
            catch {
                Utilities.MessageBox.Show("Database error!");
                return;
            }
            UpdateItemPanel(_itemPanels[item.Id], item);
        }
        private void RemoveItem(ItemEntry item) {
            try {
                _context.ItemEntry.Remove(item);
                flowLayoutPanelCartItems.Controls.Remove(_itemPanels[item.Id]);
                _context.SaveChanges();
                LoadCartItems();
            }
            catch (Exception ex) {
                Utilities.MessageBox.Show(ex.Message);
            }
        }
        private void BuyItems(object sender, EventArgs e) {
            if ((_cart?.Items.Count ?? 0) == 0) {
                Utilities.MessageBox.Show("No items in cart!");
                return;
            }
            Utilities.MessageBox.Show("Proceeding with purchase...");
            var order = new Order() {
                UserId = _userService.GetLoggedUserId(),
                TotalAmount = GetTotalPrice(),
                Items = _cart.Items
            };
            foreach (var item in _cart.Items) {
                CartService.UpdateStockMinus(item.Instrument, item.Quantity);
            }
            try {
                _context.Cart.Remove(_cart);
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            catch(Exception ex) {
                Utilities.MessageBox.Show(ex.Message);
            }
            this.ReloadItems();
        }
        private void ReloadItems() {
            flowLayoutPanelCartItems.Controls.Clear();
            LoadCartItems();
        }
        private decimal GetTotalPrice() {
            decimal totalPrice = 0;
            foreach (var item in _cart.Items) {
                totalPrice += item.Quantity * item.Price;
            }
            return totalPrice;
        }
    }
}
