using InstrumentsApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace InstrumentsApp.Forms {
    public partial class MainForm : Form {
        private readonly UserService? _userService;
        public MainForm() {
            InitializeComponent();
            _userService = Program.ServiceProvider.GetService<UserService>();
            ShowHomePage();
            UpdateUserStatus();
        }
        private void btnHomeClick(object sender, EventArgs e) => ShowHomePage();
        private void btnCartClick(object sender, EventArgs e) {
            if (!_userService.IsAuthenticated()) {
                Utilities.MessageBox.Show("Please log in to view your cart.");
                ShowLoginPage();
                return;
            }
            ShowCartPage();
        }
        private void btnOrdersClick(object sender, EventArgs e) {
            if (!_userService.IsAuthenticated()) {
                Utilities.MessageBox.Show("Please log in to view your orders.");
                ShowLoginPage();
                return;
            }
            ShowOrdersPage();
        }
        private void btnLoginClick(object sender, EventArgs e) => ShowLoginPage();
        private void ShowLoginPage() {
            contentPanel.Controls.Clear();
            var LoginPage = new LoginPage(_userService);
            LoginPage.UserLoggedIn += () => ShowHomePage();
            LoginPage.UserLoggedIn += () => UpdateUserStatus();
            LoginPage.Left = (contentPanel.Width - LoginPage.Width) / 2;
            LoginPage.Top = (contentPanel.Height - LoginPage.Height - 50) / 2;
            contentPanel.Controls.Add(LoginPage);
        }
        private void ShowHomePage() {
            contentPanel.Controls.Clear();
            var HomePage = new HomePage();
            HomePage.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(HomePage);
        }
        private void ShowCartPage() {
            contentPanel.Controls.Clear();
            var CartPage = new CartPage();
            CartPage.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(CartPage);
        }
        private void ShowOrdersPage() {
            contentPanel.Controls.Clear();
            var OrdersPage = new OrdersPage();
            OrdersPage.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(OrdersPage);
        }
        private void UpdateUserStatus() {
            btnLogin.Click -= btnLoginClick;
            btnLogin.Click -= btnLogoutClick;
            if (_userService.IsAuthenticated()) {
                btnLogin.Text = "Logout";
                btnLogin.Click += btnLogoutClick;
            }
            else {
                btnLogin.Text = "Login/Register";
                btnLogin.Click += btnLoginClick;
            }
        }
        private void btnLogoutClick(object sender, EventArgs e) {
            _userService.Logout();
            Utilities.MessageBox.Show("Logout successful");
            ShowLoginPage();
            UpdateUserStatus();
        }
        #region Dragging
        private bool isDragging = false;
        private Point mouseOffset;
        private void FormMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                isDragging = true;
                mouseOffset = new Point(e.X, e.Y);
            }
        }
        private void FormMouseMove(object sender, MouseEventArgs e) {
            if (isDragging) {
                this.Left = e.X + this.Left - mouseOffset.X;
                this.Top = e.Y + this.Top - mouseOffset.Y;
            }
        }
        private void FormMouseUp(object sender, MouseEventArgs e) => isDragging = false;
        #endregion
        private void EscButtonClick(object sender, EventArgs e) => this.Close();
    }
}