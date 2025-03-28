using InstrumentsApp.Context;
using InstrumentsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstrumentsApp.Forms {
    public partial class OrdersPage : UserControl {
        private readonly DataContext _context;
        private readonly List<Order> _orders;

        public OrdersPage() {
            InitializeComponent();
            _context = Program.ServiceProvider.GetRequiredService<DataContext>();
            _orders = _context.Orders.Include(o => o.Items).ThenInclude(oi => oi.Instrument).ToList();
            LoadOrders();
        }

        private void LoadOrders() {
            foreach (var order in _orders) {
                Panel panel = new Panel {
                    Width = 550,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(5)
                };
                Label orderIdLabel = new Label {
                    Text = $"Order #{order.Id}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                Label orderDateLabel = new Label {
                    Text = $"Date: {order.OrderDate:dd/MM/yyyy}",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(10, 40)
                };
                Label totalAmountLabel = new Label {
                    Text = $"Total Amount: {order.TotalAmount:C}",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(10, 70)
                };
                Button btnDetails = new Button {
                    Text = "Details",
                    BackColor = Color.Blue,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Width = 100,
                    Height = 30,
                    Location = new Point(400, 30)
                };
                btnDetails.Click += (s, e) => ShowOrderDetails(order);

                panel.Controls.Add(orderIdLabel);
                panel.Controls.Add(orderDateLabel);
                panel.Controls.Add(totalAmountLabel);
                panel.Controls.Add(btnDetails);

                this.flowLayoutPanelOrders.Controls.Add(panel);
            }
        }

        private void ShowOrderDetails(Order order) {
            var detailsPage = new OrderDetailsPage(order);
            this.Parent?.Controls.Add(detailsPage);
            this.Parent?.Controls.Remove(this);
        }
    }
}