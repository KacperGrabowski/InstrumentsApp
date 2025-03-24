using InstrumentsApp.Services;

namespace InstrumentsApp.Forms {
    public partial class LoginPage : UserControl {
        private readonly UserService _userService;
        public event Action UserLoggedIn;
        public LoginPage(UserService userService) {
            _userService = userService;
            InitializeComponent();
        }
        private void btnLoginClick(object sender, EventArgs e) {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (!_userService.Login(email, password, out string message)) {
                Utilities.MessageBox.Show(message);
                return;
            }
            Utilities.MessageBox.Show(message);
            UserLoggedIn?.Invoke();
        }
        private void btnRegisterClick(object sender, EventArgs e) {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (!_userService.RegisterUser(email, password, out string message)) {
                Utilities.MessageBox.Show(message);
                return;
            }
            Utilities.MessageBox.Show(message);
        }
    }
}
