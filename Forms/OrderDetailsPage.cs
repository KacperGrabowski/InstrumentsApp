using InstrumentsApp.Models;

namespace InstrumentsApp.Forms {
    public partial class OrderDetailsPage : UserControl {
        private Order _order;

        public OrderDetailsPage(Order order) {
            InitializeComponent();
            _order = order;
            LoadOrderDetails();
        }

        private void LoadOrderDetails() {
            foreach (var item in _order.Items) {
                Panel panel = new Panel {
                    Width = 550,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                    Margin = new Padding(5)
                };

                Label nameLabel = new Label {
                    Text = item.Instrument.Name,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(10, 10)
                };

                Label quantityLabel = new Label {
                    Text = $"Quantity: {item.Quantity}",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(10, 40)
                };

                Label amountLabel = new Label {
                    Text = $"Amount: {item.Price*item.Quantity:C}",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Location = new Point(10, 70)
                };

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(quantityLabel);
                panel.Controls.Add(amountLabel);

                this.flowLayoutPanelOrderDetails.Controls.Add(panel);
            }
        }
    }
}