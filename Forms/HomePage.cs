using InstrumentsApp.Context;
using InstrumentsApp.Models;
using InstrumentsApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InstrumentsApp.Forms {
    public partial class HomePage : UserControl {
        private readonly Cart? _cart;
        private readonly DataContext? _context;
        private readonly UserService? _userService;
        public HomePage() {
            InitializeComponent();
            _context = Program.ServiceProvider.GetService<DataContext>();
            _userService = Program.ServiceProvider.GetService<UserService>();
            _cart = CartService.GetCart(_userService);
            LoadInstruments();
        }

        private void LoadInstruments() {
            var instruments = _context?.Instruments.ToList();
            foreach (var instrument in instruments) {
                if (instrument != null) AddInstrumentCard(instrument);
            }
        }

        private void AddInstrumentCard(Instrument instrument) {
            Panel panel = new Panel {
                Width = 200,
                Height = 250,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pictureBox = new PictureBox {
                Image = Image.FromFile(instrument.ImagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 180,
                Height = 120,
                Location = new Point(10, 10)
            };

            Label nameLabel = new Label {
                Text = instrument.Name,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(10, 140)
            };

            Label priceLabel = new Label {
                Text = $"Price: {instrument.Price:C}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(10, 165)
            };

            Label stockLabel = new Label {
                Text = $"Stock: {instrument.Stock}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(10, 185)
            };

            Button btnAddToCart = new Button {
                Text = "Add to Cart",
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Width = 180,
                Height = 30,
                Location = new Point(10, 210)
            };

            btnAddToCart.Click += (s, e) => AddToCart(instrument);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(stockLabel);
            panel.Controls.Add(btnAddToCart);
            this.instrumentsPanel.Controls.Add(panel);
        }
        private void AddToCart(Instrument instrument) {
            if (!_userService.CheckAuth(out string message) || !CartService.CheckStock(instrument, out message)) {
                Utilities.MessageBox.Show(message);
                return;
            }
            try {
                var itemEntry = _context.ItemEntry.FirstOrDefault(x => x.Instrument == instrument && x.Cart == _cart);
                if (itemEntry == null) _cart.Items.Add(new ItemEntry { Instrument = instrument, Cart = _cart, Price = instrument.Price, Quantity = 1 });
                else itemEntry.Quantity++;
                Utilities.MessageBox.Show($"{instrument.Name} added to cart!");
                _context.SaveChanges();
            }
            catch(Exception ex) {
                Utilities.MessageBox.Show(ex.ToString());
            }
        }
    }
}