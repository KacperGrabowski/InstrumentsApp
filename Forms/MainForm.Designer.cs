namespace InstrumentsApp.Forms {
    partial class MainForm {
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
            sidebarPanel = new Panel();
            btnHome = new Button();
            btnCart = new Button();
            btnOrders = new Button();
            btnLogin = new Button();
            contentPanel = new Panel();
            headerPanel = new Panel();
            lblAppTitle = new Label();
            EscButton = new Button();
            sidebarPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(45, 45, 48);
            sidebarPanel.Controls.Add(btnHome);
            sidebarPanel.Controls.Add(btnCart);
            sidebarPanel.Controls.Add(btnOrders);
            sidebarPanel.Controls.Add(btnLogin);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Padding = new Padding(20);
            sidebarPanel.Size = new Size(157, 500);
            sidebarPanel.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(60, 60, 60);
            btnHome.FlatStyle = FlatStyle.Popup;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(157, 58);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHomeClick;
            // 
            // btnCart
            // 
            btnCart.BackColor = Color.FromArgb(60, 60, 60);
            btnCart.FlatStyle = FlatStyle.Popup;
            btnCart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCart.ForeColor = Color.White;
            btnCart.Location = new Point(0, 64);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(157, 58);
            btnCart.TabIndex = 1;
            btnCart.Text = "Cart";
            btnCart.UseVisualStyleBackColor = true;
            btnCart.Click += btnCartClick;
            // 
            // btnOrders
            // 
            btnOrders.BackColor = Color.FromArgb(60, 60, 60);
            btnOrders.FlatStyle = FlatStyle.Popup;
            btnOrders.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOrders.ForeColor = Color.White;
            btnOrders.Location = new Point(0, 128);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(157, 58);
            btnOrders.TabIndex = 2;
            btnOrders.Text = "Orders";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrdersClick;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(60, 60, 60);
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(0, 464);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(157, 36);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login/Register";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // contentPanel
            // 
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(157, 40);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(643, 460);
            contentPanel.TabIndex = 1;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(30, 30, 30);
            headerPanel.Controls.Add(EscButton);
            headerPanel.Controls.Add(lblAppTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(157, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(643, 40);
            headerPanel.TabIndex = 2;
            headerPanel.MouseDown += FormMouseDown;
            headerPanel.MouseMove += FormMouseMove;
            headerPanel.MouseUp += FormMouseUp;
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(7, 7);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(162, 25);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Instrument Shop";
            lblAppTitle.MouseDown += FormMouseDown;
            lblAppTitle.MouseMove += FormMouseMove;
            lblAppTitle.MouseUp += FormMouseUp;
            // 
            // EscButton
            // 
            EscButton.BackColor = Color.FromArgb(60, 60, 60);
            EscButton.FlatStyle = FlatStyle.Popup;
            EscButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            EscButton.ForeColor = Color.IndianRed;
            EscButton.Location = new Point(595, 0);
            EscButton.Name = "EscButton";
            EscButton.Size = new Size(48, 40);
            EscButton.TabIndex = 3;
            EscButton.Text = "x";
            EscButton.UseVisualStyleBackColor = true;
            EscButton.Click += EscButtonClick;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(800, 500);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Instrument Shop";
            sidebarPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblAppTitle;
        private Button EscButton;
    }
}