using System.Drawing;
using System.Windows.Forms;

namespace CinemaBooking
{
    partial class SeatSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatSelection));
            this.tabSession = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelPlace = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.radioButtonXL = new System.Windows.Forms.RadioButton();
            this.radioButtonXS = new System.Windows.Forms.RadioButton();
            this.radioButtonS = new System.Windows.Forms.RadioButton();
            this.radioButtonM = new System.Windows.Forms.RadioButton();
            this.radioButtonL = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonReservation = new System.Windows.Forms.Button();
            this.menuTicketSale = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.biletSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSession.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.menuTicketSale.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSession
            // 
            this.tabSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSession.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSession.Controls.Add(this.tabPage1);
            this.tabSession.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabSession.ImageList = this.imageList1;
            this.tabSession.ItemSize = new System.Drawing.Size(109, 49);
            this.tabSession.Location = new System.Drawing.Point(0, 70);
            this.tabSession.Name = "tabSession";
            this.tabSession.Padding = new System.Drawing.Point(0, 0);
            this.tabSession.RightToLeftLayout = true;
            this.tabSession.SelectedIndex = 0;
            this.tabSession.Size = new System.Drawing.Size(1051, 536);
            this.tabSession.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSession.TabIndex = 1;
            this.tabSession.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabSession_DrawItem);
            this.tabSession.SelectedIndexChanged += new System.EventHandler(this.tabSession_SelectedIndexChanged);
            this.tabSession.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabSession_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 53);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1043, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "theatre_11.png");
            this.imageList1.Images.SetKeyName(1, "theatre_22.png");
            this.imageList1.Images.SetKeyName(2, "theatre_22.png");
            this.imageList1.Images.SetKeyName(3, "theatre_33.png");
            this.imageList1.Images.SetKeyName(4, "promotion_percent3.png");
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTitle.Location = new System.Drawing.Point(327, 12);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(27, 12, 27, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(87, 46);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Controls.Add(this.buttonNext, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelTime, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelPlace, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonBack, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1055, 70);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // buttonNext
            // 
            this.buttonNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNext.BackgroundImage")));
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNext.Location = new System.Drawing.Point(958, 4);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(93, 62);
            this.buttonNext.TabIndex = 9;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Visible = false;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTime.Location = new System.Drawing.Point(630, 12);
            this.labelTime.Margin = new System.Windows.Forms.Padding(27, 12, 27, 12);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(97, 46);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "Time";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPlace.Location = new System.Drawing.Point(468, 12);
            this.labelPlace.Margin = new System.Windows.Forms.Padding(27, 12, 27, 12);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(108, 46);
            this.labelPlace.TabIndex = 5;
            this.labelPlace.Text = "Place";
            this.labelPlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBack.BackgroundImage")));
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBack.Location = new System.Drawing.Point(4, 4);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(93, 62);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // radioButtonXL
            // 
            this.radioButtonXL.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonXL.AutoSize = true;
            this.radioButtonXL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonXL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonXL.Location = new System.Drawing.Point(622, 4);
            this.radioButtonXL.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonXL.MinimumSize = new System.Drawing.Size(67, 46);
            this.radioButtonXL.Name = "radioButtonXL";
            this.radioButtonXL.Size = new System.Drawing.Size(67, 46);
            this.radioButtonXL.TabIndex = 13;
            this.radioButtonXL.Text = "XL";
            this.radioButtonXL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonXL.UseVisualStyleBackColor = true;
            this.radioButtonXL.CheckedChanged += new System.EventHandler(this.radioButtonXL_CheckedChanged);
            // 
            // radioButtonXS
            // 
            this.radioButtonXS.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonXS.AutoSize = true;
            this.radioButtonXS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonXS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonXS.Location = new System.Drawing.Point(322, 4);
            this.radioButtonXS.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonXS.MinimumSize = new System.Drawing.Size(67, 46);
            this.radioButtonXS.Name = "radioButtonXS";
            this.radioButtonXS.Size = new System.Drawing.Size(67, 46);
            this.radioButtonXS.TabIndex = 14;
            this.radioButtonXS.Text = "XS";
            this.radioButtonXS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonXS.UseVisualStyleBackColor = true;
            this.radioButtonXS.CheckedChanged += new System.EventHandler(this.radioButtonXS_CheckedChanged);
            // 
            // radioButtonS
            // 
            this.radioButtonS.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonS.AutoSize = true;
            this.radioButtonS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonS.Location = new System.Drawing.Point(397, 4);
            this.radioButtonS.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonS.MinimumSize = new System.Drawing.Size(67, 46);
            this.radioButtonS.Name = "radioButtonS";
            this.radioButtonS.Size = new System.Drawing.Size(67, 46);
            this.radioButtonS.TabIndex = 11;
            this.radioButtonS.Text = "S";
            this.radioButtonS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS.UseVisualStyleBackColor = true;
            this.radioButtonS.CheckedChanged += new System.EventHandler(this.radioButtonS_CheckedChanged);
            // 
            // radioButtonM
            // 
            this.radioButtonM.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonM.AutoSize = true;
            this.radioButtonM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonM.Location = new System.Drawing.Point(472, 4);
            this.radioButtonM.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonM.MinimumSize = new System.Drawing.Size(67, 46);
            this.radioButtonM.Name = "radioButtonM";
            this.radioButtonM.Size = new System.Drawing.Size(67, 46);
            this.radioButtonM.TabIndex = 15;
            this.radioButtonM.Text = "M";
            this.radioButtonM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonM.UseVisualStyleBackColor = true;
            this.radioButtonM.CheckedChanged += new System.EventHandler(this.radioButtonM_CheckedChanged);
            // 
            // radioButtonL
            // 
            this.radioButtonL.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonL.AutoSize = true;
            this.radioButtonL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonL.Location = new System.Drawing.Point(547, 4);
            this.radioButtonL.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonL.MinimumSize = new System.Drawing.Size(67, 46);
            this.radioButtonL.Name = "radioButtonL";
            this.radioButtonL.Size = new System.Drawing.Size(67, 46);
            this.radioButtonL.TabIndex = 12;
            this.radioButtonL.Text = "L";
            this.radioButtonL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonL.UseVisualStyleBackColor = true;
            this.radioButtonL.CheckedChanged += new System.EventHandler(this.radioButtonL_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel4.ColumnCount = 8;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.labelCount, 7, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonL, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonM, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonS, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonXS, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonXL, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonReservation, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 606);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1055, 54);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCount.Location = new System.Drawing.Point(1011, 0);
            this.labelCount.Margin = new System.Windows.Forms.Padding(0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(44, 54);
            this.labelCount.TabIndex = 16;
            this.labelCount.Text = "0";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonReservation
            // 
            this.buttonReservation.AutoSize = true;
            this.buttonReservation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReservation.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonReservation.Location = new System.Drawing.Point(4, 4);
            this.buttonReservation.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReservation.Name = "buttonReservation";
            this.buttonReservation.Size = new System.Drawing.Size(190, 46);
            this.buttonReservation.TabIndex = 17;
            this.buttonReservation.Text = "Rezervasyonlar";
            this.buttonReservation.UseVisualStyleBackColor = true;
            this.buttonReservation.Visible = false;
            this.buttonReservation.Click += new System.EventHandler(this.buttonReservation_Click);
            // 
            // menuTicketSale
            // 
            this.menuTicketSale.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTicketSale.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biletSilToolStripMenuItem});
            this.menuTicketSale.Name = "menuTicketSale";
            this.menuTicketSale.Size = new System.Drawing.Size(133, 30);
            // 
            // biletSilToolStripMenuItem
            // 
            this.biletSilToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("biletSilToolStripMenuItem.Image")));
            this.biletSilToolStripMenuItem.Name = "biletSilToolStripMenuItem";
            this.biletSilToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.biletSilToolStripMenuItem.Text = "Bilet Sil";
            this.biletSilToolStripMenuItem.Click += new System.EventHandler(this.biletSilToolStripMenuItem_Click);
            // 
            // SeatSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 660);
            this.Controls.Add(this.tabSession);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SeatSelection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SeatSelection";
            this.tabSession.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.menuTicketSale.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.RadioButton radioButtonXL;
        private System.Windows.Forms.RadioButton radioButtonXS;
        private System.Windows.Forms.RadioButton radioButtonS;
        private System.Windows.Forms.RadioButton radioButtonM;
        private System.Windows.Forms.RadioButton radioButtonL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonReservation;
        //private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabSession;
        private TabPage tabPage1;
        private ImageList imageList1;
        private ContextMenuStrip menuTicketSale;
        private ToolStripMenuItem biletSilToolStripMenuItem;
    }
}