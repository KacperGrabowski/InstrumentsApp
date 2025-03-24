namespace InstrumentsApp.Utilities {
    public partial class MessageBox : Form {
        public MessageBox(string message) {
            InitializeComponent();
            lblMessage.Text = message;
            lblMessage.Left = (this.ClientSize.Width - lblMessage.Width) / 2;
            lblMessage.Top = 30;
            this.btnOk.Location = new Point((this.ClientSize.Width - 80) / 2, 80);
        }

        public static void Show(string message) {
            using var messageBox = new MessageBox(message);
            messageBox.ShowDialog();
        }
    }
}