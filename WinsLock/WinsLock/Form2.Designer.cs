namespace WinsLock
{
    partial class LockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockForm));
            this.tLock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tLock
            // 
            this.tLock.Enabled = true;
            this.tLock.Tick += new System.EventHandler(this.tLock_Tick);
            // 
            // LockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LockForm";
            this.Text = "LockForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LockForm_FormClosing);
            this.Load += new System.EventHandler(this.LockForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleKeys);
            this.LostFocus += new System.EventHandler(this.LockForm_LostFocus);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tLock;
    }
}