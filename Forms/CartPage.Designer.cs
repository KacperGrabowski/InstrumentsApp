namespace InstrumentsApp.Forms {
    partial class CartPage {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            flowLayoutPanelCartItems = new FlowLayoutPanel();
            btnBuy = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanelCartItems
            // 
            flowLayoutPanelCartItems.AutoScroll = true;
            flowLayoutPanelCartItems.Location = new Point(12, 12);
            flowLayoutPanelCartItems.Name = "flowLayoutPanelCartItems";
            flowLayoutPanelCartItems.Size = new Size(618, 350);
            flowLayoutPanelCartItems.TabIndex = 0;
            // 
            // btnBuy
            // 
            btnBuy.BackColor = Color.DarkGreen;
            btnBuy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBuy.ForeColor = Color.White;
            btnBuy.Location = new Point(12, 380);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(618, 40);
            btnBuy.TabIndex = 1;
            btnBuy.Text = "Proceed to Purchase";
            btnBuy.UseVisualStyleBackColor = false;
            btnBuy.Click += BuyItems;
            // 
            // CartPage
            // 
            Controls.Add(btnBuy);
            Controls.Add(flowLayoutPanelCartItems);
            Name = "CartPage";
            Size = new Size(645, 445);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelCartItems;
        private Button btnBuy;
    }
}
