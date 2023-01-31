namespace CineBookManager
{
    partial class Main
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.moviesStripOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesStripMovies = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesStripSessions = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesStripAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesStripChangeMyPass = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesStripLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moviesStripOperations,
            this.moviesStripAccount});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // moviesStripOperations
            // 
            this.moviesStripOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moviesStripMovies,
            this.moviesStripSessions});
            this.moviesStripOperations.Name = "moviesStripOperations";
            this.moviesStripOperations.Size = new System.Drawing.Size(77, 20);
            this.moviesStripOperations.Text = "Operations";
            // 
            // moviesStripMovies
            // 
            this.moviesStripMovies.Name = "moviesStripMovies";
            this.moviesStripMovies.Size = new System.Drawing.Size(152, 22);
            this.moviesStripMovies.Text = "Movies";
            this.moviesStripMovies.Click += new System.EventHandler(this.moviesStripMovies_Click);
            // 
            // moviesStripSessions
            // 
            this.moviesStripSessions.Name = "moviesStripSessions";
            this.moviesStripSessions.Size = new System.Drawing.Size(152, 22);
            this.moviesStripSessions.Text = "Sessions";
            this.moviesStripSessions.Click += new System.EventHandler(this.moviesStripSessions_Click);
            // 
            // moviesStripAccount
            // 
            this.moviesStripAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moviesStripChangeMyPass,
            this.moviesStripLogout});
            this.moviesStripAccount.Name = "moviesStripAccount";
            this.moviesStripAccount.Size = new System.Drawing.Size(64, 20);
            this.moviesStripAccount.Text = "Account";
            // 
            // moviesStripChangeMyPass
            // 
            this.moviesStripChangeMyPass.Name = "moviesStripChangeMyPass";
            this.moviesStripChangeMyPass.Size = new System.Drawing.Size(188, 22);
            this.moviesStripChangeMyPass.Text = "Change My Password";
            this.moviesStripChangeMyPass.Click += new System.EventHandler(this.moviesStripChangeMyPass_Click);
            // 
            // moviesStripLogout
            // 
            this.moviesStripLogout.Name = "moviesStripLogout";
            this.moviesStripLogout.Size = new System.Drawing.Size(188, 22);
            this.moviesStripLogout.Text = "Logout";
            this.moviesStripLogout.Click += new System.EventHandler(this.moviesStripLogout_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CineBook Manager";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem moviesStripOperations;
        private System.Windows.Forms.ToolStripMenuItem moviesStripMovies;
        private System.Windows.Forms.ToolStripMenuItem moviesStripSessions;
        private System.Windows.Forms.ToolStripMenuItem moviesStripAccount;
        private System.Windows.Forms.ToolStripMenuItem moviesStripChangeMyPass;
        private System.Windows.Forms.ToolStripMenuItem moviesStripLogout;
    }
}

