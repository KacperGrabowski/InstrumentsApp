namespace InstrumentsApp.Utilities {
    partial class MessageBox {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new Label();
            this.btnOk = new Button();
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = Color.White;
            this.lblMessage.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            this.lblMessage.AutoSize = true;
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.lblMessage.Padding = new Padding(10);
            this.lblMessage.Anchor = AnchorStyles.None;
            // 
            // btnOk
            // 
            this.btnOk.Text = "OK";
            this.btnOk.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnOk.BackColor = Color.FromArgb(50, 50, 50);
            this.btnOk.ForeColor = Color.White;
            this.btnOk.FlatStyle = FlatStyle.Flat;
            this.btnOk.Size = new Size(80, 30);
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.Click += (s, e) => this.Close();
            this.btnOk.MouseEnter += (s, e) => btnOk.BackColor = Color.FromArgb(70, 70, 70);
            this.btnOk.MouseLeave += (s, e) => btnOk.BackColor = Color.FromArgb(50, 50, 50);
            // 
            // MessageBox
            // 
            this.ClientSize = new Size(350, 150);
            this.Text = "Message";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnOk);
        }

        #endregion

        private Label lblMessage;
        private Button btnOk;
    }
}