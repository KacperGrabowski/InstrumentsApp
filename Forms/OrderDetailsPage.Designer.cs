namespace InstrumentsApp.Forms {
    partial class OrderDetailsPage {
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
            components = new System.ComponentModel.Container();
            this.flowLayoutPanelOrderDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelOrderDetails
            // 
            this.flowLayoutPanelOrderDetails.AutoScroll = true;
            this.flowLayoutPanelOrderDetails.Dock = DockStyle.Fill;
            this.flowLayoutPanelOrderDetails.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelOrderDetails.Name = "flowLayoutPanelOrderDetails";
            this.flowLayoutPanelOrderDetails.WrapContents = true;
            this.flowLayoutPanelOrderDetails.TabIndex = 0;
            // 
            // OrderDetailsPage
            // 
            this.Dock = DockStyle.Fill;
            this.Controls.Add(this.flowLayoutPanelOrderDetails);
            this.Name = "OrderDetailsPage";
            this.ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelOrderDetails;
    }
}
