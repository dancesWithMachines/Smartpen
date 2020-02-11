namespace Visualiser
{
    partial class cursor
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cursor));
            this.selectPort = new System.Windows.Forms.GroupBox();
            this.selectPortBox = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dButton = new System.Windows.Forms.Button();
            this.eButton = new System.Windows.Forms.Button();
            this.cursorek = new System.Windows.Forms.PictureBox();
            this.selectPort.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursorek)).BeginInit();
            this.SuspendLayout();
            // 
            // selectPort
            // 
            this.selectPort.BackColor = System.Drawing.Color.Transparent;
            this.selectPort.Controls.Add(this.connectButton);
            this.selectPort.Controls.Add(this.selectPortBox);
            resources.ApplyResources(this.selectPort, "selectPort");
            this.selectPort.Name = "selectPort";
            this.selectPort.TabStop = false;
            // 
            // selectPortBox
            // 
            this.selectPortBox.FormattingEnabled = true;
            resources.ApplyResources(this.selectPortBox, "selectPortBox");
            this.selectPortBox.Name = "selectPortBox";
            // 
            // connectButton
            // 
            resources.ApplyResources(this.connectButton, "connectButton");
            this.connectButton.Name = "connectButton";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.outputTextBox);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.outputTextBox.ForeColor = System.Drawing.Color.Lime;
            resources.ApplyResources(this.outputTextBox, "outputTextBox");
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.eButton);
            this.groupBox2.Controls.Add(this.dButton);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // dButton
            // 
            resources.ApplyResources(this.dButton, "dButton");
            this.dButton.Name = "dButton";
            this.dButton.UseVisualStyleBackColor = true;
            this.dButton.Click += new System.EventHandler(this.dButton_Click);
            // 
            // eButton
            // 
            resources.ApplyResources(this.eButton, "eButton");
            this.eButton.Name = "eButton";
            this.eButton.UseVisualStyleBackColor = true;
            this.eButton.Click += new System.EventHandler(this.eButton_Click);
            // 
            // cursorek
            // 
            this.cursorek.Image = global::Visualiser.Properties.Resources.kursor3;
            resources.ApplyResources(this.cursorek, "cursorek");
            this.cursorek.Name = "cursorek";
            this.cursorek.TabStop = false;
            // 
            // cursor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Visualiser.Properties.Resources.siatka;
            this.Controls.Add(this.cursorek);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.selectPort);
            this.DoubleBuffered = true;
            this.Name = "cursor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.cursor_Load);
            this.selectPort.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cursorek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox selectPort;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox selectPortBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button eButton;
        private System.Windows.Forms.Button dButton;
        private System.Windows.Forms.PictureBox cursorek;
    }
}

