namespace InstrumentsApp.Forms {
    partial class HomePage {
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
            this.instrumentsPanel = new FlowLayoutPanel();
            this.SuspendLayout();

            // 
            // instrumentsPanel
            // 
            this.instrumentsPanel.Dock = DockStyle.Fill;
            this.instrumentsPanel.AutoScroll = true;
            this.instrumentsPanel.WrapContents = true;
            this.instrumentsPanel.FlowDirection = FlowDirection.LeftToRight;
            this.Controls.Add(this.instrumentsPanel);

            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "Instrument Store";
            this.ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel instrumentsPanel;
    }
}
