namespace WpfApp1asds
{
    partial class skl
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.спискиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тканиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фурнитураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.спискиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // спискиToolStripMenuItem
            // 
            this.спискиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тканиToolStripMenuItem,
            this.фурнитураToolStripMenuItem});
            this.спискиToolStripMenuItem.Name = "спискиToolStripMenuItem";
            this.спискиToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.спискиToolStripMenuItem.Text = "Списки";
            // 
            // тканиToolStripMenuItem
            // 
            this.тканиToolStripMenuItem.Name = "тканиToolStripMenuItem";
            this.тканиToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.тканиToolStripMenuItem.Text = "Ткани";
            this.тканиToolStripMenuItem.Click += new System.EventHandler(this.тканиToolStripMenuItem_Click);
            // 
            // фурнитураToolStripMenuItem
            // 
            this.фурнитураToolStripMenuItem.Name = "фурнитураToolStripMenuItem";
            this.фурнитураToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.фурнитураToolStripMenuItem.Text = "Фурнитура";
            this.фурнитураToolStripMenuItem.Click += new System.EventHandler(this.фурнитураToolStripMenuItem_Click);
            // 
            // skl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "skl";
            this.Text = "Кладовщик";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.skl_FormClosing);
            this.Load += new System.EventHandler(this.skl_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem спискиToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem тканиToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem фурнитураToolStripMenuItem;
    }
}