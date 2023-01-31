using System.Windows.Forms;

namespace CineBookManager.Forms
{
    partial class MovieForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewMovie = new System.Windows.Forms.DataGridView();
            this.textBoxMovieSearch = new System.Windows.Forms.TextBox();
            this.labelMovieSearch = new System.Windows.Forms.Label();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.menuMovieType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMovieTypeRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieTypeNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieTypeEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieTypeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieFormat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMovieFormatRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieFormatNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieFormatEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieFormatDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieDirector = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMovieDirectorRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieDirectorNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieDirectorEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieDirectorDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieCast = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMovieCastRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieCastNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieCastEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieCastDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMovieCategoryRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieCategoryNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieCategoryEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieCategoryDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieSession = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMovieSessionRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieSessionNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieSessionEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieSessionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieSessionSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMovieSessionAmount = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieSessionSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuUserRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.toolStripSaloon = new System.Windows.Forms.TabControl();
            this.tabPageMovie = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMovieDetails = new System.Windows.Forms.TableLayoutPanel();
            this.txtTicketTemplate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMovieDescription = new System.Windows.Forms.Label();
            this.labelMovieTitle = new System.Windows.Forms.Label();
            this.toolStripMovieDetails = new System.Windows.Forms.ToolStrip();
            this.buttonMovieDetailsNew = new System.Windows.Forms.ToolStripButton();
            this.buttonMovieDetailsSave = new System.Windows.Forms.ToolStripButton();
            this.buttonMovieDetailsDelete = new System.Windows.Forms.ToolStripButton();
            this.buttonMovieDetailsRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelMovieStatus = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanelMovieDetails2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxMovieTitle = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dateTimePickerMovieReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.labelMovieReleaseDate = new System.Windows.Forms.Label();
            this.numericUpDownMovieDuration = new System.Windows.Forms.NumericUpDown();
            this.labelMovieDuration = new System.Windows.Forms.Label();
            this.textBoxMovieDescription = new System.Windows.Forms.TextBox();
            this.labelMovieSummary = new System.Windows.Forms.Label();
            this.labelMovieStory = new System.Windows.Forms.Label();
            this.textBoxMovieSummary = new System.Windows.Forms.TextBox();
            this.textBoxMovieStory = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMovieDetailsPoster = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMovieUpdatePosterPreview = new System.Windows.Forms.Button();
            this.buttonMovieUpdatePosterOriginal = new System.Windows.Forms.Button();
            this.pictureBoxMoviePosterPreview = new System.Windows.Forms.PictureBox();
            this.pictureBoxMoviePosterOriginal = new System.Windows.Forms.PictureBox();
            this.labelMoviePosterPreviewLeft = new System.Windows.Forms.Label();
            this.labelMoviePosterPreviewRight = new System.Windows.Forms.Label();
            this.labelMoviePosterOriginalLeft = new System.Windows.Forms.Label();
            this.labelMoviePosterOriginalRight = new System.Windows.Forms.Label();
            this.tabPageMovieType = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMovieType = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMovieTypeRight = new System.Windows.Forms.ListBox();
            this.textBoxMovieTypeSearch = new System.Windows.Forms.TextBox();
            this.labelMovieTypeSearch = new System.Windows.Forms.Label();
            this.listBoxMovieTypeLeft = new System.Windows.Forms.ListBox();
            this.buttonMovieTypeRight = new System.Windows.Forms.Button();
            this.buttonMovieTypeLeft = new System.Windows.Forms.Button();
            this.tabPageMovieFormat = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMovieFormat = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMovieFormatRight = new System.Windows.Forms.ListBox();
            this.textBoxMovieFormatSearch = new System.Windows.Forms.TextBox();
            this.labelMovieFormatSearch = new System.Windows.Forms.Label();
            this.listBoxMovieFormatLeft = new System.Windows.Forms.ListBox();
            this.buttonMovieFormatRight = new System.Windows.Forms.Button();
            this.buttonMovieFormatLeft = new System.Windows.Forms.Button();
            this.tabPageMovieDirector = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMovieDirector = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMovieDirectorRight = new System.Windows.Forms.ListBox();
            this.textBoxMovieDirectorSearch = new System.Windows.Forms.TextBox();
            this.labelMovieDirectorSearch = new System.Windows.Forms.Label();
            this.listBoxMovieDirectorLeft = new System.Windows.Forms.ListBox();
            this.buttonMovieDirectorRight = new System.Windows.Forms.Button();
            this.buttonMovieDirectorLeft = new System.Windows.Forms.Button();
            this.tabPageMovieCast = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMovieCast = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMovieCastRight = new System.Windows.Forms.ListBox();
            this.textBoxMovieCastSearch = new System.Windows.Forms.TextBox();
            this.labelMovieCastSearch = new System.Windows.Forms.Label();
            this.listBoxMovieCastLeft = new System.Windows.Forms.ListBox();
            this.buttonMovieCastRight = new System.Windows.Forms.Button();
            this.buttonMovieCastLeft = new System.Windows.Forms.Button();
            this.tabPageMovieCategory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMovieCategory = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMovieCategoryRight = new System.Windows.Forms.ListBox();
            this.textBoxMovieCategorySearch = new System.Windows.Forms.TextBox();
            this.labelMovieCategorySearch = new System.Windows.Forms.Label();
            this.listBoxMovieCategoryLeft = new System.Windows.Forms.ListBox();
            this.buttonMovieCategoryRight = new System.Windows.Forms.Button();
            this.buttonMovieCategoryLeft = new System.Windows.Forms.Button();
            this.tabPageSaloon = new System.Windows.Forms.TabPage();
            this.tabSaloon = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBlockCount = new System.Windows.Forms.NumericUpDown();
            this.chkBlock = new System.Windows.Forms.CheckBox();
            this.cmbTemp = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnList = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tabPageMovieSession = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabSession = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewMovieSession = new System.Windows.Forms.DataGridView();
            this.Theatre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datePickerMovieSession = new System.Windows.Forms.DateTimePicker();
            this.buttonSessionTimePrev = new System.Windows.Forms.Button();
            this.buttonSessionTimeNext = new System.Windows.Forms.Button();
            this.groupBoxMovieSessionMovieFormat = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxMovieSessionMovieFormatRight = new System.Windows.Forms.ListBox();
            this.listBoxMovieSessionMovieFormatLeft = new System.Windows.Forms.ListBox();
            this.buttonMovieSessionMovieFormatRight = new System.Windows.Forms.Button();
            this.buttonMovieSessionMovieFormatLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMovieSessionMovieFormatSearch = new System.Windows.Forms.TextBox();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxUserSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.tabPageDesign = new System.Windows.Forms.TabPage();
            this.reportViewerDesign = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.toolStripDesign = new System.Windows.Forms.ToolStrip();
            this.buttonDesignRefresh = new System.Windows.Forms.ToolStripButton();
            this.buttonDesignUpdate = new System.Windows.Forms.ToolStripButton();
            this.buttonDesignExport = new System.Windows.Forms.ToolStripButton();
            this.menuSeats = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.standardSeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledSeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleSeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.menuSaloonCreate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddRow1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddRow5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddRow10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddRow20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddCol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddCol1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddCol5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddCol10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddCol20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAddSep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddSep1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddSep5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddSep10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddSep20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAddHall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.koltukAdıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaloonCreateSeat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuCreateSeatDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovie)).BeginInit();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.menuMovieType.SuspendLayout();
            this.menuMovieFormat.SuspendLayout();
            this.menuMovieDirector.SuspendLayout();
            this.menuMovieCast.SuspendLayout();
            this.menuMovieCategory.SuspendLayout();
            this.menuMovieSession.SuspendLayout();
            this.menuUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.toolStripSaloon.SuspendLayout();
            this.tabPageMovie.SuspendLayout();
            this.tableLayoutPanelMovieDetails.SuspendLayout();
            this.toolStripMovieDetails.SuspendLayout();
            this.tableLayoutPanelMovieDetails2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMovieDuration)).BeginInit();
            this.tableLayoutPanelMovieDetailsPoster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoviePosterPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoviePosterOriginal)).BeginInit();
            this.tabPageMovieType.SuspendLayout();
            this.tableLayoutPanelMovieType.SuspendLayout();
            this.tabPageMovieFormat.SuspendLayout();
            this.tableLayoutPanelMovieFormat.SuspendLayout();
            this.tabPageMovieDirector.SuspendLayout();
            this.tableLayoutPanelMovieDirector.SuspendLayout();
            this.tabPageMovieCast.SuspendLayout();
            this.tableLayoutPanelMovieCast.SuspendLayout();
            this.tabPageMovieCategory.SuspendLayout();
            this.tableLayoutPanelMovieCategory.SuspendLayout();
            this.tabPageSaloon.SuspendLayout();
            this.tabSaloon.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlockCount)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabPageMovieSession.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabSession.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovieSession)).BeginInit();
            this.groupBoxMovieSessionMovieFormat.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.tabPageDesign.SuspendLayout();
            this.toolStripDesign.SuspendLayout();
            this.menuSeats.SuspendLayout();
            this.menuSaloonCreate.SuspendLayout();
            this.menuSaloonCreateSeat.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMovie
            // 
            this.dataGridViewMovie.AllowUserToAddRows = false;
            this.dataGridViewMovie.AllowUserToDeleteRows = false;
            this.dataGridViewMovie.AllowUserToOrderColumns = true;
            this.dataGridViewMovie.AllowUserToResizeColumns = false;
            this.dataGridViewMovie.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMovie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMovie.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewMovie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMovie.Location = new System.Drawing.Point(4, 51);
            this.dataGridViewMovie.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewMovie.MultiSelect = false;
            this.dataGridViewMovie.Name = "dataGridViewMovie";
            this.dataGridViewMovie.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMovie.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewMovie.RowHeadersVisible = false;
            this.dataGridViewMovie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMovie.Size = new System.Drawing.Size(449, 512);
            this.dataGridViewMovie.TabIndex = 0;
            this.dataGridViewMovie.SelectionChanged += new System.EventHandler(this.dataGridViewMovie_SelectionChanged);
            // 
            // textBoxMovieSearch
            // 
            this.textBoxMovieSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieSearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxMovieSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieSearch.Name = "textBoxMovieSearch";
            this.textBoxMovieSearch.Size = new System.Drawing.Size(449, 22);
            this.textBoxMovieSearch.TabIndex = 4;
            this.textBoxMovieSearch.TextChanged += new System.EventHandler(this.textBoxMovieSearch_TextChanged);
            // 
            // labelMovieSearch
            // 
            this.labelMovieSearch.AutoSize = true;
            this.labelMovieSearch.Location = new System.Drawing.Point(4, 0);
            this.labelMovieSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieSearch.Name = "labelMovieSearch";
            this.labelMovieSearch.Size = new System.Drawing.Size(57, 17);
            this.labelMovieSearch.TabIndex = 3;
            this.labelMovieSearch.Text = "Search:";
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.dataGridViewMovie, 0, 2);
            this.tableLayoutPanelLeft.Controls.Add(this.textBoxMovieSearch, 0, 1);
            this.tableLayoutPanelLeft.Controls.Add(this.labelMovieSearch, 0, 0);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 3;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(457, 567);
            this.tableLayoutPanelLeft.TabIndex = 5;
            // 
            // menuMovieType
            // 
            this.menuMovieType.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMovieType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMovieTypeRefresh,
            this.menuMovieTypeNew,
            this.menuMovieTypeEdit,
            this.menuMovieTypeDelete});
            this.menuMovieType.Name = "menuMovieType";
            this.menuMovieType.Size = new System.Drawing.Size(132, 108);
            this.menuMovieType.Opening += new System.ComponentModel.CancelEventHandler(this.menuMovieType_Opening);
            // 
            // menuMovieTypeRefresh
            // 
            this.menuMovieTypeRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieTypeRefresh.Image")));
            this.menuMovieTypeRefresh.Name = "menuMovieTypeRefresh";
            this.menuMovieTypeRefresh.Size = new System.Drawing.Size(131, 26);
            this.menuMovieTypeRefresh.Text = "Refresh";
            this.menuMovieTypeRefresh.Click += new System.EventHandler(this.menuMovieTypeRefresh_Click);
            // 
            // menuMovieTypeNew
            // 
            this.menuMovieTypeNew.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieTypeNew.Image")));
            this.menuMovieTypeNew.Name = "menuMovieTypeNew";
            this.menuMovieTypeNew.Size = new System.Drawing.Size(131, 26);
            this.menuMovieTypeNew.Text = "New";
            this.menuMovieTypeNew.Click += new System.EventHandler(this.menuMovieTypeNew_Click);
            // 
            // menuMovieTypeEdit
            // 
            this.menuMovieTypeEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieTypeEdit.Image")));
            this.menuMovieTypeEdit.Name = "menuMovieTypeEdit";
            this.menuMovieTypeEdit.Size = new System.Drawing.Size(131, 26);
            this.menuMovieTypeEdit.Text = "Edit";
            this.menuMovieTypeEdit.Click += new System.EventHandler(this.menuMovieTypeEdit_Click);
            // 
            // menuMovieTypeDelete
            // 
            this.menuMovieTypeDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieTypeDelete.Image")));
            this.menuMovieTypeDelete.Name = "menuMovieTypeDelete";
            this.menuMovieTypeDelete.Size = new System.Drawing.Size(131, 26);
            this.menuMovieTypeDelete.Text = "Delete";
            this.menuMovieTypeDelete.Click += new System.EventHandler(this.menuMovieTypeDelete_Click);
            // 
            // menuMovieFormat
            // 
            this.menuMovieFormat.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMovieFormat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMovieFormatRefresh,
            this.menuMovieFormatNew,
            this.menuMovieFormatEdit,
            this.menuMovieFormatDelete});
            this.menuMovieFormat.Name = "menuMovieType";
            this.menuMovieFormat.Size = new System.Drawing.Size(132, 108);
            this.menuMovieFormat.Opening += new System.ComponentModel.CancelEventHandler(this.menuMovieFormat_Opening);
            // 
            // menuMovieFormatRefresh
            // 
            this.menuMovieFormatRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieFormatRefresh.Image")));
            this.menuMovieFormatRefresh.Name = "menuMovieFormatRefresh";
            this.menuMovieFormatRefresh.Size = new System.Drawing.Size(131, 26);
            this.menuMovieFormatRefresh.Text = "Refresh";
            this.menuMovieFormatRefresh.Click += new System.EventHandler(this.menuMovieFormatRefresh_Click);
            // 
            // menuMovieFormatNew
            // 
            this.menuMovieFormatNew.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieFormatNew.Image")));
            this.menuMovieFormatNew.Name = "menuMovieFormatNew";
            this.menuMovieFormatNew.Size = new System.Drawing.Size(131, 26);
            this.menuMovieFormatNew.Text = "New";
            this.menuMovieFormatNew.Click += new System.EventHandler(this.menuMovieFormatNew_Click);
            // 
            // menuMovieFormatEdit
            // 
            this.menuMovieFormatEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieFormatEdit.Image")));
            this.menuMovieFormatEdit.Name = "menuMovieFormatEdit";
            this.menuMovieFormatEdit.Size = new System.Drawing.Size(131, 26);
            this.menuMovieFormatEdit.Text = "Edit";
            this.menuMovieFormatEdit.Click += new System.EventHandler(this.menuMovieFormatEdit_Click);
            // 
            // menuMovieFormatDelete
            // 
            this.menuMovieFormatDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieFormatDelete.Image")));
            this.menuMovieFormatDelete.Name = "menuMovieFormatDelete";
            this.menuMovieFormatDelete.Size = new System.Drawing.Size(131, 26);
            this.menuMovieFormatDelete.Text = "Delete";
            this.menuMovieFormatDelete.Click += new System.EventHandler(this.menuMovieFormatDelete_Click);
            // 
            // menuMovieDirector
            // 
            this.menuMovieDirector.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMovieDirector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMovieDirectorRefresh,
            this.menuMovieDirectorNew,
            this.menuMovieDirectorEdit,
            this.menuMovieDirectorDelete});
            this.menuMovieDirector.Name = "menuMovieType";
            this.menuMovieDirector.Size = new System.Drawing.Size(132, 108);
            this.menuMovieDirector.Opening += new System.ComponentModel.CancelEventHandler(this.menuMovieDirector_Opening);
            // 
            // menuMovieDirectorRefresh
            // 
            this.menuMovieDirectorRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieDirectorRefresh.Image")));
            this.menuMovieDirectorRefresh.Name = "menuMovieDirectorRefresh";
            this.menuMovieDirectorRefresh.Size = new System.Drawing.Size(131, 26);
            this.menuMovieDirectorRefresh.Text = "Refresh";
            this.menuMovieDirectorRefresh.Click += new System.EventHandler(this.menuMovieDirectorRefresh_Click);
            // 
            // menuMovieDirectorNew
            // 
            this.menuMovieDirectorNew.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieDirectorNew.Image")));
            this.menuMovieDirectorNew.Name = "menuMovieDirectorNew";
            this.menuMovieDirectorNew.Size = new System.Drawing.Size(131, 26);
            this.menuMovieDirectorNew.Text = "New";
            this.menuMovieDirectorNew.Click += new System.EventHandler(this.menuMovieDirectorNew_Click);
            // 
            // menuMovieDirectorEdit
            // 
            this.menuMovieDirectorEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieDirectorEdit.Image")));
            this.menuMovieDirectorEdit.Name = "menuMovieDirectorEdit";
            this.menuMovieDirectorEdit.Size = new System.Drawing.Size(131, 26);
            this.menuMovieDirectorEdit.Text = "Edit";
            this.menuMovieDirectorEdit.Click += new System.EventHandler(this.menuMovieDirectorEdit_Click);
            // 
            // menuMovieDirectorDelete
            // 
            this.menuMovieDirectorDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieDirectorDelete.Image")));
            this.menuMovieDirectorDelete.Name = "menuMovieDirectorDelete";
            this.menuMovieDirectorDelete.Size = new System.Drawing.Size(131, 26);
            this.menuMovieDirectorDelete.Text = "Delete";
            this.menuMovieDirectorDelete.Click += new System.EventHandler(this.menuMovieDirectorDelete_Click);
            // 
            // menuMovieCast
            // 
            this.menuMovieCast.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMovieCast.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMovieCastRefresh,
            this.menuMovieCastNew,
            this.menuMovieCastEdit,
            this.menuMovieCastDelete});
            this.menuMovieCast.Name = "menuMovieType";
            this.menuMovieCast.Size = new System.Drawing.Size(132, 108);
            this.menuMovieCast.Opening += new System.ComponentModel.CancelEventHandler(this.menuMovieCast_Opening);
            // 
            // menuMovieCastRefresh
            // 
            this.menuMovieCastRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieCastRefresh.Image")));
            this.menuMovieCastRefresh.Name = "menuMovieCastRefresh";
            this.menuMovieCastRefresh.Size = new System.Drawing.Size(131, 26);
            this.menuMovieCastRefresh.Text = "Refresh";
            this.menuMovieCastRefresh.Click += new System.EventHandler(this.menuMovieCastRefresh_Click);
            // 
            // menuMovieCastNew
            // 
            this.menuMovieCastNew.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieCastNew.Image")));
            this.menuMovieCastNew.Name = "menuMovieCastNew";
            this.menuMovieCastNew.Size = new System.Drawing.Size(131, 26);
            this.menuMovieCastNew.Text = "New";
            this.menuMovieCastNew.Click += new System.EventHandler(this.menuMovieCastNew_Click);
            // 
            // menuMovieCastEdit
            // 
            this.menuMovieCastEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieCastEdit.Image")));
            this.menuMovieCastEdit.Name = "menuMovieCastEdit";
            this.menuMovieCastEdit.Size = new System.Drawing.Size(131, 26);
            this.menuMovieCastEdit.Text = "Edit";
            this.menuMovieCastEdit.Click += new System.EventHandler(this.menuMovieCastEdit_Click);
            // 
            // menuMovieCastDelete
            // 
            this.menuMovieCastDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieCastDelete.Image")));
            this.menuMovieCastDelete.Name = "menuMovieCastDelete";
            this.menuMovieCastDelete.Size = new System.Drawing.Size(131, 26);
            this.menuMovieCastDelete.Text = "Delete";
            this.menuMovieCastDelete.Click += new System.EventHandler(this.menuMovieCastDelete_Click);
            // 
            // menuMovieCategory
            // 
            this.menuMovieCategory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMovieCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMovieCategoryRefresh,
            this.menuMovieCategoryNew,
            this.menuMovieCategoryEdit,
            this.menuMovieCategoryDelete});
            this.menuMovieCategory.Name = "menuMovieType";
            this.menuMovieCategory.Size = new System.Drawing.Size(132, 108);
            this.menuMovieCategory.Opening += new System.ComponentModel.CancelEventHandler(this.menuMovieCategory_Opening);
            // 
            // menuMovieCategoryRefresh
            // 
            this.menuMovieCategoryRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieCategoryRefresh.Image")));
            this.menuMovieCategoryRefresh.Name = "menuMovieCategoryRefresh";
            this.menuMovieCategoryRefresh.Size = new System.Drawing.Size(131, 26);
            this.menuMovieCategoryRefresh.Text = "Refresh";
            this.menuMovieCategoryRefresh.Click += new System.EventHandler(this.menuMovieCategoryRefresh_Click);
            // 
            // menuMovieCategoryNew
            // 
            this.menuMovieCategoryNew.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieCategoryNew.Image")));
            this.menuMovieCategoryNew.Name = "menuMovieCategoryNew";
            this.menuMovieCategoryNew.Size = new System.Drawing.Size(131, 26);
            this.menuMovieCategoryNew.Text = "New";
            this.menuMovieCategoryNew.Click += new System.EventHandler(this.menuMovieCategoryNew_Click);
            // 
            // menuMovieCategoryEdit
            // 
            this.menuMovieCategoryEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieCategoryEdit.Image")));
            this.menuMovieCategoryEdit.Name = "menuMovieCategoryEdit";
            this.menuMovieCategoryEdit.Size = new System.Drawing.Size(131, 26);
            this.menuMovieCategoryEdit.Text = "Edit";
            this.menuMovieCategoryEdit.Click += new System.EventHandler(this.menuMovieCategoryEdit_Click);
            // 
            // menuMovieCategoryDelete
            // 
            this.menuMovieCategoryDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieCategoryDelete.Image")));
            this.menuMovieCategoryDelete.Name = "menuMovieCategoryDelete";
            this.menuMovieCategoryDelete.Size = new System.Drawing.Size(131, 26);
            this.menuMovieCategoryDelete.Text = "Delete";
            this.menuMovieCategoryDelete.Click += new System.EventHandler(this.menuMovieCategoryDelete_Click);
            // 
            // menuMovieSession
            // 
            this.menuMovieSession.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMovieSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMovieSessionRefresh,
            this.menuMovieSessionNew,
            this.menuMovieSessionEdit,
            this.menuMovieSessionDelete,
            this.menuMovieSessionSeparator1,
            this.menuMovieSessionAmount,
            this.menuMovieSessionSaveAs});
            this.menuMovieSession.Name = "menuMovieType";
            this.menuMovieSession.Size = new System.Drawing.Size(193, 166);
            this.menuMovieSession.Opening += new System.ComponentModel.CancelEventHandler(this.menuMovieSession_Opening);
            // 
            // menuMovieSessionRefresh
            // 
            this.menuMovieSessionRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieSessionRefresh.Image")));
            this.menuMovieSessionRefresh.Name = "menuMovieSessionRefresh";
            this.menuMovieSessionRefresh.Size = new System.Drawing.Size(192, 26);
            this.menuMovieSessionRefresh.Text = "Refresh";
            this.menuMovieSessionRefresh.Click += new System.EventHandler(this.menuMovieSessionRefresh_Click);
            // 
            // menuMovieSessionNew
            // 
            this.menuMovieSessionNew.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieSessionNew.Image")));
            this.menuMovieSessionNew.Name = "menuMovieSessionNew";
            this.menuMovieSessionNew.Size = new System.Drawing.Size(192, 26);
            this.menuMovieSessionNew.Text = "New";
            this.menuMovieSessionNew.Click += new System.EventHandler(this.menuMovieSessionNew_Click);
            // 
            // menuMovieSessionEdit
            // 
            this.menuMovieSessionEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieSessionEdit.Image")));
            this.menuMovieSessionEdit.Name = "menuMovieSessionEdit";
            this.menuMovieSessionEdit.Size = new System.Drawing.Size(192, 26);
            this.menuMovieSessionEdit.Text = "Edit";
            this.menuMovieSessionEdit.Click += new System.EventHandler(this.menuMovieSessionEdit_Click);
            // 
            // menuMovieSessionDelete
            // 
            this.menuMovieSessionDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieSessionDelete.Image")));
            this.menuMovieSessionDelete.Name = "menuMovieSessionDelete";
            this.menuMovieSessionDelete.Size = new System.Drawing.Size(192, 26);
            this.menuMovieSessionDelete.Text = "Delete";
            this.menuMovieSessionDelete.Click += new System.EventHandler(this.menuMovieSessionDelete_Click);
            // 
            // menuMovieSessionSeparator1
            // 
            this.menuMovieSessionSeparator1.Name = "menuMovieSessionSeparator1";
            this.menuMovieSessionSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // menuMovieSessionAmount
            // 
            this.menuMovieSessionAmount.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieSessionAmount.Image")));
            this.menuMovieSessionAmount.Name = "menuMovieSessionAmount";
            this.menuMovieSessionAmount.Size = new System.Drawing.Size(192, 26);
            this.menuMovieSessionAmount.Text = "Set Amount";
            this.menuMovieSessionAmount.Click += new System.EventHandler(this.menuMovieSessionAmount_Click);
            // 
            // menuMovieSessionSaveAs
            // 
            this.menuMovieSessionSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("menuMovieSessionSaveAs.Image")));
            this.menuMovieSessionSaveAs.Name = "menuMovieSessionSaveAs";
            this.menuMovieSessionSaveAs.Size = new System.Drawing.Size(192, 26);
            this.menuMovieSessionSaveAs.Text = "Save As Sessions";
            this.menuMovieSessionSaveAs.Click += new System.EventHandler(this.menuMovieSessionSaveAs_Click);
            // 
            // menuUser
            // 
            this.menuUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUserRefresh,
            this.menuUserNew,
            this.menuUserEdit,
            this.menuUserDelete});
            this.menuUser.Name = "menuMovieType";
            this.menuUser.Size = new System.Drawing.Size(132, 108);
            this.menuUser.Opening += new System.ComponentModel.CancelEventHandler(this.menuUser_Opening);
            // 
            // menuUserRefresh
            // 
            this.menuUserRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuUserRefresh.Image")));
            this.menuUserRefresh.Name = "menuUserRefresh";
            this.menuUserRefresh.Size = new System.Drawing.Size(131, 26);
            this.menuUserRefresh.Text = "Refresh";
            this.menuUserRefresh.Click += new System.EventHandler(this.menuUserRefresh_Click);
            // 
            // menuUserNew
            // 
            this.menuUserNew.Image = ((System.Drawing.Image)(resources.GetObject("menuUserNew.Image")));
            this.menuUserNew.Name = "menuUserNew";
            this.menuUserNew.Size = new System.Drawing.Size(131, 26);
            this.menuUserNew.Text = "New";
            this.menuUserNew.Click += new System.EventHandler(this.menuUserNew_Click);
            // 
            // menuUserEdit
            // 
            this.menuUserEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuUserEdit.Image")));
            this.menuUserEdit.Name = "menuUserEdit";
            this.menuUserEdit.Size = new System.Drawing.Size(131, 26);
            this.menuUserEdit.Text = "Edit";
            this.menuUserEdit.Click += new System.EventHandler(this.menuUserEdit_Click);
            // 
            // menuUserDelete
            // 
            this.menuUserDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuUserDelete.Image")));
            this.menuUserDelete.Name = "menuUserDelete";
            this.menuUserDelete.Size = new System.Drawing.Size(131, 26);
            this.menuUserDelete.Text = "Delete";
            this.menuUserDelete.Click += new System.EventHandler(this.menuUserDelete_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tableLayoutPanelLeft);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.toolStripSaloon);
            this.splitContainerMain.Size = new System.Drawing.Size(1312, 567);
            this.splitContainerMain.SplitterDistance = 457;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 8;
            // 
            // toolStripSaloon
            // 
            this.toolStripSaloon.Controls.Add(this.tabPageMovie);
            this.toolStripSaloon.Controls.Add(this.tabPageMovieType);
            this.toolStripSaloon.Controls.Add(this.tabPageMovieFormat);
            this.toolStripSaloon.Controls.Add(this.tabPageMovieDirector);
            this.toolStripSaloon.Controls.Add(this.tabPageMovieCast);
            this.toolStripSaloon.Controls.Add(this.tabPageMovieCategory);
            this.toolStripSaloon.Controls.Add(this.tabPageSaloon);
            this.toolStripSaloon.Controls.Add(this.tabPageMovieSession);
            this.toolStripSaloon.Controls.Add(this.tabPageUser);
            this.toolStripSaloon.Controls.Add(this.tabPageDesign);
            this.toolStripSaloon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripSaloon.Location = new System.Drawing.Point(0, 0);
            this.toolStripSaloon.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripSaloon.Name = "toolStripSaloon";
            this.toolStripSaloon.SelectedIndex = 0;
            this.toolStripSaloon.Size = new System.Drawing.Size(850, 567);
            this.toolStripSaloon.TabIndex = 7;
            this.toolStripSaloon.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageMovie
            // 
            this.tabPageMovie.Controls.Add(this.tableLayoutPanelMovieDetails);
            this.tabPageMovie.Location = new System.Drawing.Point(4, 25);
            this.tabPageMovie.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMovie.Name = "tabPageMovie";
            this.tabPageMovie.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMovie.Size = new System.Drawing.Size(842, 538);
            this.tabPageMovie.TabIndex = 0;
            this.tabPageMovie.Text = "MovieDetail";
            this.tabPageMovie.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMovieDetails
            // 
            this.tableLayoutPanelMovieDetails.ColumnCount = 3;
            this.tableLayoutPanelMovieDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMovieDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMovieDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMovieDetails.Controls.Add(this.txtTicketTemplate, 1, 7);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelMovieDescription, 0, 2);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelMovieTitle, 0, 1);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.toolStripMovieDetails, 0, 0);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.tableLayoutPanelMovieDetails2, 1, 1);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.dateTimePickerMovieReleaseDate, 1, 4);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelMovieReleaseDate, 0, 4);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.numericUpDownMovieDuration, 1, 3);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelMovieDuration, 0, 3);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.textBoxMovieDescription, 1, 2);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelMovieSummary, 0, 5);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelMovieStory, 0, 6);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.textBoxMovieSummary, 1, 5);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.textBoxMovieStory, 1, 6);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.tableLayoutPanelMovieDetailsPoster, 2, 1);
            this.tableLayoutPanelMovieDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMovieDetails.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelMovieDetails.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMovieDetails.Name = "tableLayoutPanelMovieDetails";
            this.tableLayoutPanelMovieDetails.RowCount = 8;
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMovieDetails.Size = new System.Drawing.Size(834, 530);
            this.tableLayoutPanelMovieDetails.TabIndex = 0;
            // 
            // txtTicketTemplate
            // 
            this.txtTicketTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTicketTemplate.Location = new System.Drawing.Point(419, 513);
            this.txtTicketTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.txtTicketTemplate.MaxLength = 100;
            this.txtTicketTemplate.Name = "txtTicketTemplate";
            this.txtTicketTemplate.Size = new System.Drawing.Size(243, 22);
            this.txtTicketTemplate.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 509);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(407, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "TicketTemplate:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMovieDescription
            // 
            this.labelMovieDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMovieDescription.Location = new System.Drawing.Point(4, 63);
            this.labelMovieDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieDescription.Name = "labelMovieDescription";
            this.labelMovieDescription.Size = new System.Drawing.Size(407, 34);
            this.labelMovieDescription.TabIndex = 5;
            this.labelMovieDescription.Text = "Description:";
            this.labelMovieDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMovieTitle
            // 
            this.labelMovieTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMovieTitle.Location = new System.Drawing.Point(4, 27);
            this.labelMovieTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieTitle.Name = "labelMovieTitle";
            this.labelMovieTitle.Size = new System.Drawing.Size(407, 36);
            this.labelMovieTitle.TabIndex = 1;
            this.labelMovieTitle.Text = "Title:";
            this.labelMovieTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripMovieDetails
            // 
            this.tableLayoutPanelMovieDetails.SetColumnSpan(this.toolStripMovieDetails, 3);
            this.toolStripMovieDetails.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMovieDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMovieDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonMovieDetailsNew,
            this.buttonMovieDetailsSave,
            this.buttonMovieDetailsDelete,
            this.buttonMovieDetailsRefresh,
            this.toolStripSeparator1,
            this.toolStripLabelMovieStatus});
            this.toolStripMovieDetails.Location = new System.Drawing.Point(0, 0);
            this.toolStripMovieDetails.Name = "toolStripMovieDetails";
            this.toolStripMovieDetails.Size = new System.Drawing.Size(834, 27);
            this.toolStripMovieDetails.TabIndex = 6;
            this.toolStripMovieDetails.Text = "toolStrip1";
            // 
            // buttonMovieDetailsNew
            // 
            this.buttonMovieDetailsNew.Image = ((System.Drawing.Image)(resources.GetObject("buttonMovieDetailsNew.Image")));
            this.buttonMovieDetailsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMovieDetailsNew.Name = "buttonMovieDetailsNew";
            this.buttonMovieDetailsNew.Size = new System.Drawing.Size(63, 24);
            this.buttonMovieDetailsNew.Text = "New";
            this.buttonMovieDetailsNew.Click += new System.EventHandler(this.buttonMovieDetailsNew_Click);
            // 
            // buttonMovieDetailsSave
            // 
            this.buttonMovieDetailsSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonMovieDetailsSave.Image")));
            this.buttonMovieDetailsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMovieDetailsSave.Name = "buttonMovieDetailsSave";
            this.buttonMovieDetailsSave.Size = new System.Drawing.Size(64, 24);
            this.buttonMovieDetailsSave.Text = "Save";
            this.buttonMovieDetailsSave.Click += new System.EventHandler(this.buttonMovieDetailsSave_Click);
            // 
            // buttonMovieDetailsDelete
            // 
            this.buttonMovieDetailsDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonMovieDetailsDelete.Image")));
            this.buttonMovieDetailsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMovieDetailsDelete.Name = "buttonMovieDetailsDelete";
            this.buttonMovieDetailsDelete.Size = new System.Drawing.Size(77, 24);
            this.buttonMovieDetailsDelete.Text = "Delete";
            this.buttonMovieDetailsDelete.Click += new System.EventHandler(this.buttonMovieDetailsDelete_Click);
            // 
            // buttonMovieDetailsRefresh
            // 
            this.buttonMovieDetailsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonMovieDetailsRefresh.Image")));
            this.buttonMovieDetailsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMovieDetailsRefresh.Name = "buttonMovieDetailsRefresh";
            this.buttonMovieDetailsRefresh.Size = new System.Drawing.Size(82, 24);
            this.buttonMovieDetailsRefresh.Text = "Refresh";
            this.buttonMovieDetailsRefresh.Click += new System.EventHandler(this.buttonMovieDetailsRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabelMovieStatus
            // 
            this.toolStripLabelMovieStatus.Name = "toolStripLabelMovieStatus";
            this.toolStripLabelMovieStatus.Size = new System.Drawing.Size(49, 24);
            this.toolStripLabelMovieStatus.Text = "Status";
            // 
            // tableLayoutPanelMovieDetails2
            // 
            this.tableLayoutPanelMovieDetails2.ColumnCount = 2;
            this.tableLayoutPanelMovieDetails2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.34694F));
            this.tableLayoutPanelMovieDetails2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.65306F));
            this.tableLayoutPanelMovieDetails2.Controls.Add(this.textBoxMovieTitle, 0, 0);
            this.tableLayoutPanelMovieDetails2.Controls.Add(this.chkActive, 1, 0);
            this.tableLayoutPanelMovieDetails2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMovieDetails2.Location = new System.Drawing.Point(418, 30);
            this.tableLayoutPanelMovieDetails2.Name = "tableLayoutPanelMovieDetails2";
            this.tableLayoutPanelMovieDetails2.RowCount = 1;
            this.tableLayoutPanelMovieDetails2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMovieDetails2.Size = new System.Drawing.Size(245, 30);
            this.tableLayoutPanelMovieDetails2.TabIndex = 18;
            // 
            // textBoxMovieTitle
            // 
            this.textBoxMovieTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieTitle.Location = new System.Drawing.Point(4, 4);
            this.textBoxMovieTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieTitle.MaxLength = 100;
            this.textBoxMovieTitle.Name = "textBoxMovieTitle";
            this.textBoxMovieTitle.Size = new System.Drawing.Size(157, 22);
            this.textBoxMovieTitle.TabIndex = 2;
            // 
            // chkActive
            // 
            this.chkActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkActive.Location = new System.Drawing.Point(168, 3);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(74, 24);
            this.chkActive.TabIndex = 18;
            this.chkActive.Text = "Active";
            // 
            // dateTimePickerMovieReleaseDate
            // 
            this.dateTimePickerMovieReleaseDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerMovieReleaseDate.Location = new System.Drawing.Point(419, 135);
            this.dateTimePickerMovieReleaseDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerMovieReleaseDate.Name = "dateTimePickerMovieReleaseDate";
            this.dateTimePickerMovieReleaseDate.Size = new System.Drawing.Size(243, 22);
            this.dateTimePickerMovieReleaseDate.TabIndex = 10;
            // 
            // labelMovieReleaseDate
            // 
            this.labelMovieReleaseDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMovieReleaseDate.Location = new System.Drawing.Point(4, 131);
            this.labelMovieReleaseDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieReleaseDate.Name = "labelMovieReleaseDate";
            this.labelMovieReleaseDate.Size = new System.Drawing.Size(407, 34);
            this.labelMovieReleaseDate.TabIndex = 9;
            this.labelMovieReleaseDate.Text = "Release Date:";
            this.labelMovieReleaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownMovieDuration
            // 
            this.numericUpDownMovieDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownMovieDuration.Location = new System.Drawing.Point(419, 101);
            this.numericUpDownMovieDuration.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownMovieDuration.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMovieDuration.Name = "numericUpDownMovieDuration";
            this.numericUpDownMovieDuration.Size = new System.Drawing.Size(243, 22);
            this.numericUpDownMovieDuration.TabIndex = 8;
            // 
            // labelMovieDuration
            // 
            this.labelMovieDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMovieDuration.Location = new System.Drawing.Point(4, 97);
            this.labelMovieDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieDuration.Name = "labelMovieDuration";
            this.labelMovieDuration.Size = new System.Drawing.Size(407, 34);
            this.labelMovieDuration.TabIndex = 7;
            this.labelMovieDuration.Text = "Duration:";
            this.labelMovieDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMovieDescription
            // 
            this.textBoxMovieDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieDescription.Location = new System.Drawing.Point(419, 67);
            this.textBoxMovieDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieDescription.MaxLength = 100;
            this.textBoxMovieDescription.Name = "textBoxMovieDescription";
            this.textBoxMovieDescription.Size = new System.Drawing.Size(243, 22);
            this.textBoxMovieDescription.TabIndex = 6;
            // 
            // labelMovieSummary
            // 
            this.labelMovieSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMovieSummary.Location = new System.Drawing.Point(4, 165);
            this.labelMovieSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieSummary.Name = "labelMovieSummary";
            this.labelMovieSummary.Size = new System.Drawing.Size(407, 86);
            this.labelMovieSummary.TabIndex = 11;
            this.labelMovieSummary.Text = "Summary:";
            this.labelMovieSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMovieStory
            // 
            this.labelMovieStory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMovieStory.Location = new System.Drawing.Point(4, 251);
            this.labelMovieStory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieStory.Name = "labelMovieStory";
            this.labelMovieStory.Size = new System.Drawing.Size(407, 258);
            this.labelMovieStory.TabIndex = 12;
            this.labelMovieStory.Text = "Story:";
            this.labelMovieStory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMovieSummary
            // 
            this.textBoxMovieSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieSummary.Location = new System.Drawing.Point(419, 169);
            this.textBoxMovieSummary.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieSummary.Multiline = true;
            this.textBoxMovieSummary.Name = "textBoxMovieSummary";
            this.textBoxMovieSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMovieSummary.Size = new System.Drawing.Size(243, 78);
            this.textBoxMovieSummary.TabIndex = 13;
            // 
            // textBoxMovieStory
            // 
            this.textBoxMovieStory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieStory.Location = new System.Drawing.Point(419, 255);
            this.textBoxMovieStory.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieStory.Multiline = true;
            this.textBoxMovieStory.Name = "textBoxMovieStory";
            this.textBoxMovieStory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMovieStory.Size = new System.Drawing.Size(243, 250);
            this.textBoxMovieStory.TabIndex = 14;
            // 
            // tableLayoutPanelMovieDetailsPoster
            // 
            this.tableLayoutPanelMovieDetailsPoster.ColumnCount = 3;
            this.tableLayoutPanelMovieDetailsPoster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMovieDetailsPoster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMovieDetailsPoster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMovieDetailsPoster.Controls.Add(this.buttonMovieUpdatePosterPreview, 0, 0);
            this.tableLayoutPanelMovieDetailsPoster.Controls.Add(this.buttonMovieUpdatePosterOriginal, 0, 3);
            this.tableLayoutPanelMovieDetailsPoster.Controls.Add(this.pictureBoxMoviePosterPreview, 0, 1);
            this.tableLayoutPanelMovieDetailsPoster.Controls.Add(this.pictureBoxMoviePosterOriginal, 0, 4);
            this.tableLayoutPanelMovieDetailsPoster.Controls.Add(this.labelMoviePosterPreviewLeft, 0, 2);
            this.tableLayoutPanelMovieDetailsPoster.Controls.Add(this.labelMoviePosterPreviewRight, 2, 2);
            this.tableLayoutPanelMovieDetailsPoster.Controls.Add(this.labelMoviePosterOriginalLeft, 0, 5);
            this.tableLayoutPanelMovieDetailsPoster.Controls.Add(this.labelMoviePosterOriginalRight, 2, 5);
            this.tableLayoutPanelMovieDetailsPoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMovieDetailsPoster.Location = new System.Drawing.Point(670, 31);
            this.tableLayoutPanelMovieDetailsPoster.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMovieDetailsPoster.Name = "tableLayoutPanelMovieDetailsPoster";
            this.tableLayoutPanelMovieDetailsPoster.RowCount = 6;
            this.tableLayoutPanelMovieDetails.SetRowSpan(this.tableLayoutPanelMovieDetailsPoster, 6);
            this.tableLayoutPanelMovieDetailsPoster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetailsPoster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieDetailsPoster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetailsPoster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetailsPoster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieDetailsPoster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDetailsPoster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieDetailsPoster.Size = new System.Drawing.Size(160, 474);
            this.tableLayoutPanelMovieDetailsPoster.TabIndex = 15;
            // 
            // buttonMovieUpdatePosterPreview
            // 
            this.tableLayoutPanelMovieDetailsPoster.SetColumnSpan(this.buttonMovieUpdatePosterPreview, 3);
            this.buttonMovieUpdatePosterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieUpdatePosterPreview.Location = new System.Drawing.Point(4, 4);
            this.buttonMovieUpdatePosterPreview.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieUpdatePosterPreview.Name = "buttonMovieUpdatePosterPreview";
            this.buttonMovieUpdatePosterPreview.Size = new System.Drawing.Size(152, 28);
            this.buttonMovieUpdatePosterPreview.TabIndex = 0;
            this.buttonMovieUpdatePosterPreview.Text = "Update Poster Preview";
            this.buttonMovieUpdatePosterPreview.UseVisualStyleBackColor = true;
            this.buttonMovieUpdatePosterPreview.Click += new System.EventHandler(this.buttonMovieUpdatePosterPreview_Click);
            // 
            // buttonMovieUpdatePosterOriginal
            // 
            this.tableLayoutPanelMovieDetailsPoster.SetColumnSpan(this.buttonMovieUpdatePosterOriginal, 3);
            this.buttonMovieUpdatePosterOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieUpdatePosterOriginal.Location = new System.Drawing.Point(4, 241);
            this.buttonMovieUpdatePosterOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieUpdatePosterOriginal.Name = "buttonMovieUpdatePosterOriginal";
            this.buttonMovieUpdatePosterOriginal.Size = new System.Drawing.Size(152, 28);
            this.buttonMovieUpdatePosterOriginal.TabIndex = 1;
            this.buttonMovieUpdatePosterOriginal.Text = "Update Poster Original";
            this.buttonMovieUpdatePosterOriginal.UseVisualStyleBackColor = true;
            this.buttonMovieUpdatePosterOriginal.Click += new System.EventHandler(this.buttonMovieUpdatePosterOriginal_Click);
            // 
            // pictureBoxMoviePosterPreview
            // 
            this.pictureBoxMoviePosterPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelMovieDetailsPoster.SetColumnSpan(this.pictureBoxMoviePosterPreview, 3);
            this.pictureBoxMoviePosterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMoviePosterPreview.Location = new System.Drawing.Point(4, 40);
            this.pictureBoxMoviePosterPreview.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxMoviePosterPreview.Name = "pictureBoxMoviePosterPreview";
            this.pictureBoxMoviePosterPreview.Size = new System.Drawing.Size(152, 176);
            this.pictureBoxMoviePosterPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMoviePosterPreview.TabIndex = 2;
            this.pictureBoxMoviePosterPreview.TabStop = false;
            // 
            // pictureBoxMoviePosterOriginal
            // 
            this.pictureBoxMoviePosterOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelMovieDetailsPoster.SetColumnSpan(this.pictureBoxMoviePosterOriginal, 3);
            this.pictureBoxMoviePosterOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMoviePosterOriginal.Location = new System.Drawing.Point(4, 277);
            this.pictureBoxMoviePosterOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxMoviePosterOriginal.Name = "pictureBoxMoviePosterOriginal";
            this.pictureBoxMoviePosterOriginal.Size = new System.Drawing.Size(152, 176);
            this.pictureBoxMoviePosterOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMoviePosterOriginal.TabIndex = 3;
            this.pictureBoxMoviePosterOriginal.TabStop = false;
            // 
            // labelMoviePosterPreviewLeft
            // 
            this.labelMoviePosterPreviewLeft.AutoSize = true;
            this.labelMoviePosterPreviewLeft.Location = new System.Drawing.Point(4, 220);
            this.labelMoviePosterPreviewLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMoviePosterPreviewLeft.Name = "labelMoviePosterPreviewLeft";
            this.labelMoviePosterPreviewLeft.Size = new System.Drawing.Size(30, 17);
            this.labelMoviePosterPreviewLeft.TabIndex = 4;
            this.labelMoviePosterPreviewLeft.Text = "0x0";
            // 
            // labelMoviePosterPreviewRight
            // 
            this.labelMoviePosterPreviewRight.AutoSize = true;
            this.labelMoviePosterPreviewRight.Location = new System.Drawing.Point(118, 220);
            this.labelMoviePosterPreviewRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMoviePosterPreviewRight.Name = "labelMoviePosterPreviewRight";
            this.labelMoviePosterPreviewRight.Size = new System.Drawing.Size(38, 17);
            this.labelMoviePosterPreviewRight.TabIndex = 5;
            this.labelMoviePosterPreviewRight.Text = "0 KB";
            // 
            // labelMoviePosterOriginalLeft
            // 
            this.labelMoviePosterOriginalLeft.AutoSize = true;
            this.labelMoviePosterOriginalLeft.Location = new System.Drawing.Point(4, 457);
            this.labelMoviePosterOriginalLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMoviePosterOriginalLeft.Name = "labelMoviePosterOriginalLeft";
            this.labelMoviePosterOriginalLeft.Size = new System.Drawing.Size(30, 17);
            this.labelMoviePosterOriginalLeft.TabIndex = 6;
            this.labelMoviePosterOriginalLeft.Text = "0x0";
            // 
            // labelMoviePosterOriginalRight
            // 
            this.labelMoviePosterOriginalRight.AutoSize = true;
            this.labelMoviePosterOriginalRight.Location = new System.Drawing.Point(118, 457);
            this.labelMoviePosterOriginalRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMoviePosterOriginalRight.Name = "labelMoviePosterOriginalRight";
            this.labelMoviePosterOriginalRight.Size = new System.Drawing.Size(38, 17);
            this.labelMoviePosterOriginalRight.TabIndex = 7;
            this.labelMoviePosterOriginalRight.Text = "0 KB";
            // 
            // tabPageMovieType
            // 
            this.tabPageMovieType.Controls.Add(this.tableLayoutPanelMovieType);
            this.tabPageMovieType.Location = new System.Drawing.Point(4, 25);
            this.tabPageMovieType.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMovieType.Name = "tabPageMovieType";
            this.tabPageMovieType.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMovieType.Size = new System.Drawing.Size(842, 538);
            this.tabPageMovieType.TabIndex = 1;
            this.tabPageMovieType.Text = "MovieType";
            this.tabPageMovieType.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMovieType
            // 
            this.tableLayoutPanelMovieType.ColumnCount = 3;
            this.tableLayoutPanelMovieType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanelMovieType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieType.Controls.Add(this.listBoxMovieTypeRight, 2, 2);
            this.tableLayoutPanelMovieType.Controls.Add(this.textBoxMovieTypeSearch, 0, 1);
            this.tableLayoutPanelMovieType.Controls.Add(this.labelMovieTypeSearch, 0, 0);
            this.tableLayoutPanelMovieType.Controls.Add(this.listBoxMovieTypeLeft, 0, 2);
            this.tableLayoutPanelMovieType.Controls.Add(this.buttonMovieTypeRight, 1, 3);
            this.tableLayoutPanelMovieType.Controls.Add(this.buttonMovieTypeLeft, 1, 4);
            this.tableLayoutPanelMovieType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMovieType.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelMovieType.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMovieType.Name = "tableLayoutPanelMovieType";
            this.tableLayoutPanelMovieType.RowCount = 6;
            this.tableLayoutPanelMovieType.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieType.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieType.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieType.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieType.Size = new System.Drawing.Size(834, 530);
            this.tableLayoutPanelMovieType.TabIndex = 0;
            // 
            // listBoxMovieTypeRight
            // 
            this.listBoxMovieTypeRight.DisplayMember = "MovieTypeName";
            this.listBoxMovieTypeRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieTypeRight.FormattingEnabled = true;
            this.listBoxMovieTypeRight.ItemHeight = 16;
            this.listBoxMovieTypeRight.Location = new System.Drawing.Point(454, 51);
            this.listBoxMovieTypeRight.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieTypeRight.Name = "listBoxMovieTypeRight";
            this.tableLayoutPanelMovieType.SetRowSpan(this.listBoxMovieTypeRight, 4);
            this.listBoxMovieTypeRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieTypeRight.Size = new System.Drawing.Size(376, 475);
            this.listBoxMovieTypeRight.TabIndex = 9;
            // 
            // textBoxMovieTypeSearch
            // 
            this.textBoxMovieTypeSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieTypeSearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxMovieTypeSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieTypeSearch.Name = "textBoxMovieTypeSearch";
            this.textBoxMovieTypeSearch.Size = new System.Drawing.Size(375, 22);
            this.textBoxMovieTypeSearch.TabIndex = 5;
            this.textBoxMovieTypeSearch.TextChanged += new System.EventHandler(this.textBoxMovieTypeSearch_TextChanged);
            // 
            // labelMovieTypeSearch
            // 
            this.labelMovieTypeSearch.AutoSize = true;
            this.labelMovieTypeSearch.Location = new System.Drawing.Point(4, 0);
            this.labelMovieTypeSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieTypeSearch.Name = "labelMovieTypeSearch";
            this.labelMovieTypeSearch.Size = new System.Drawing.Size(57, 17);
            this.labelMovieTypeSearch.TabIndex = 4;
            this.labelMovieTypeSearch.Text = "Search:";
            // 
            // listBoxMovieTypeLeft
            // 
            this.listBoxMovieTypeLeft.ContextMenuStrip = this.menuMovieType;
            this.listBoxMovieTypeLeft.DisplayMember = "MovieTypeName";
            this.listBoxMovieTypeLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieTypeLeft.FormattingEnabled = true;
            this.listBoxMovieTypeLeft.ItemHeight = 16;
            this.listBoxMovieTypeLeft.Location = new System.Drawing.Point(4, 51);
            this.listBoxMovieTypeLeft.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieTypeLeft.Name = "listBoxMovieTypeLeft";
            this.tableLayoutPanelMovieType.SetRowSpan(this.listBoxMovieTypeLeft, 4);
            this.listBoxMovieTypeLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieTypeLeft.Size = new System.Drawing.Size(375, 475);
            this.listBoxMovieTypeLeft.TabIndex = 6;
            // 
            // buttonMovieTypeRight
            // 
            this.buttonMovieTypeRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieTypeRight.Location = new System.Drawing.Point(387, 256);
            this.buttonMovieTypeRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieTypeRight.Name = "buttonMovieTypeRight";
            this.buttonMovieTypeRight.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieTypeRight.TabIndex = 10;
            this.buttonMovieTypeRight.Text = ">";
            this.buttonMovieTypeRight.UseVisualStyleBackColor = true;
            this.buttonMovieTypeRight.Click += new System.EventHandler(this.buttonMovieTypeRight_Click);
            // 
            // buttonMovieTypeLeft
            // 
            this.buttonMovieTypeLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieTypeLeft.Location = new System.Drawing.Point(387, 292);
            this.buttonMovieTypeLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieTypeLeft.Name = "buttonMovieTypeLeft";
            this.buttonMovieTypeLeft.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieTypeLeft.TabIndex = 11;
            this.buttonMovieTypeLeft.Text = "<";
            this.buttonMovieTypeLeft.UseVisualStyleBackColor = true;
            this.buttonMovieTypeLeft.Click += new System.EventHandler(this.buttonMovieTypeLeft_Click);
            // 
            // tabPageMovieFormat
            // 
            this.tabPageMovieFormat.Controls.Add(this.tableLayoutPanelMovieFormat);
            this.tabPageMovieFormat.Location = new System.Drawing.Point(4, 25);
            this.tabPageMovieFormat.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMovieFormat.Name = "tabPageMovieFormat";
            this.tabPageMovieFormat.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMovieFormat.Size = new System.Drawing.Size(842, 538);
            this.tabPageMovieFormat.TabIndex = 2;
            this.tabPageMovieFormat.Text = "MovieFormat";
            this.tabPageMovieFormat.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMovieFormat
            // 
            this.tableLayoutPanelMovieFormat.ColumnCount = 3;
            this.tableLayoutPanelMovieFormat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieFormat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanelMovieFormat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieFormat.Controls.Add(this.listBoxMovieFormatRight, 2, 2);
            this.tableLayoutPanelMovieFormat.Controls.Add(this.textBoxMovieFormatSearch, 0, 1);
            this.tableLayoutPanelMovieFormat.Controls.Add(this.labelMovieFormatSearch, 0, 0);
            this.tableLayoutPanelMovieFormat.Controls.Add(this.listBoxMovieFormatLeft, 0, 2);
            this.tableLayoutPanelMovieFormat.Controls.Add(this.buttonMovieFormatRight, 1, 3);
            this.tableLayoutPanelMovieFormat.Controls.Add(this.buttonMovieFormatLeft, 1, 4);
            this.tableLayoutPanelMovieFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMovieFormat.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelMovieFormat.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMovieFormat.Name = "tableLayoutPanelMovieFormat";
            this.tableLayoutPanelMovieFormat.RowCount = 6;
            this.tableLayoutPanelMovieFormat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieFormat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieFormat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieFormat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieFormat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieFormat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieFormat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieFormat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieFormat.Size = new System.Drawing.Size(834, 530);
            this.tableLayoutPanelMovieFormat.TabIndex = 1;
            // 
            // listBoxMovieFormatRight
            // 
            this.listBoxMovieFormatRight.DisplayMember = "MovieFormatName";
            this.listBoxMovieFormatRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieFormatRight.FormattingEnabled = true;
            this.listBoxMovieFormatRight.ItemHeight = 16;
            this.listBoxMovieFormatRight.Location = new System.Drawing.Point(454, 51);
            this.listBoxMovieFormatRight.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieFormatRight.Name = "listBoxMovieFormatRight";
            this.tableLayoutPanelMovieFormat.SetRowSpan(this.listBoxMovieFormatRight, 4);
            this.listBoxMovieFormatRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieFormatRight.Size = new System.Drawing.Size(376, 475);
            this.listBoxMovieFormatRight.TabIndex = 9;
            // 
            // textBoxMovieFormatSearch
            // 
            this.textBoxMovieFormatSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieFormatSearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxMovieFormatSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieFormatSearch.Name = "textBoxMovieFormatSearch";
            this.textBoxMovieFormatSearch.Size = new System.Drawing.Size(375, 22);
            this.textBoxMovieFormatSearch.TabIndex = 5;
            this.textBoxMovieFormatSearch.TextChanged += new System.EventHandler(this.textBoxMovieFormatSearch_TextChanged);
            // 
            // labelMovieFormatSearch
            // 
            this.labelMovieFormatSearch.AutoSize = true;
            this.labelMovieFormatSearch.Location = new System.Drawing.Point(4, 0);
            this.labelMovieFormatSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieFormatSearch.Name = "labelMovieFormatSearch";
            this.labelMovieFormatSearch.Size = new System.Drawing.Size(57, 17);
            this.labelMovieFormatSearch.TabIndex = 4;
            this.labelMovieFormatSearch.Text = "Search:";
            // 
            // listBoxMovieFormatLeft
            // 
            this.listBoxMovieFormatLeft.ContextMenuStrip = this.menuMovieFormat;
            this.listBoxMovieFormatLeft.DisplayMember = "MovieFormatName";
            this.listBoxMovieFormatLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieFormatLeft.FormattingEnabled = true;
            this.listBoxMovieFormatLeft.ItemHeight = 16;
            this.listBoxMovieFormatLeft.Location = new System.Drawing.Point(4, 51);
            this.listBoxMovieFormatLeft.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieFormatLeft.Name = "listBoxMovieFormatLeft";
            this.tableLayoutPanelMovieFormat.SetRowSpan(this.listBoxMovieFormatLeft, 4);
            this.listBoxMovieFormatLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieFormatLeft.Size = new System.Drawing.Size(375, 475);
            this.listBoxMovieFormatLeft.TabIndex = 6;
            // 
            // buttonMovieFormatRight
            // 
            this.buttonMovieFormatRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieFormatRight.Location = new System.Drawing.Point(387, 256);
            this.buttonMovieFormatRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieFormatRight.Name = "buttonMovieFormatRight";
            this.buttonMovieFormatRight.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieFormatRight.TabIndex = 10;
            this.buttonMovieFormatRight.Text = ">";
            this.buttonMovieFormatRight.UseVisualStyleBackColor = true;
            this.buttonMovieFormatRight.Click += new System.EventHandler(this.buttonMovieFormatRight_Click);
            // 
            // buttonMovieFormatLeft
            // 
            this.buttonMovieFormatLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieFormatLeft.Location = new System.Drawing.Point(387, 292);
            this.buttonMovieFormatLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieFormatLeft.Name = "buttonMovieFormatLeft";
            this.buttonMovieFormatLeft.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieFormatLeft.TabIndex = 11;
            this.buttonMovieFormatLeft.Text = "<";
            this.buttonMovieFormatLeft.UseVisualStyleBackColor = true;
            this.buttonMovieFormatLeft.Click += new System.EventHandler(this.buttonMovieFormatLeft_Click);
            // 
            // tabPageMovieDirector
            // 
            this.tabPageMovieDirector.Controls.Add(this.tableLayoutPanelMovieDirector);
            this.tabPageMovieDirector.Location = new System.Drawing.Point(4, 25);
            this.tabPageMovieDirector.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMovieDirector.Name = "tabPageMovieDirector";
            this.tabPageMovieDirector.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMovieDirector.Size = new System.Drawing.Size(842, 538);
            this.tabPageMovieDirector.TabIndex = 3;
            this.tabPageMovieDirector.Text = "MovieDirector";
            this.tabPageMovieDirector.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMovieDirector
            // 
            this.tableLayoutPanelMovieDirector.ColumnCount = 3;
            this.tableLayoutPanelMovieDirector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieDirector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanelMovieDirector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieDirector.Controls.Add(this.listBoxMovieDirectorRight, 2, 2);
            this.tableLayoutPanelMovieDirector.Controls.Add(this.textBoxMovieDirectorSearch, 0, 1);
            this.tableLayoutPanelMovieDirector.Controls.Add(this.labelMovieDirectorSearch, 0, 0);
            this.tableLayoutPanelMovieDirector.Controls.Add(this.listBoxMovieDirectorLeft, 0, 2);
            this.tableLayoutPanelMovieDirector.Controls.Add(this.buttonMovieDirectorRight, 1, 3);
            this.tableLayoutPanelMovieDirector.Controls.Add(this.buttonMovieDirectorLeft, 1, 4);
            this.tableLayoutPanelMovieDirector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMovieDirector.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelMovieDirector.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMovieDirector.Name = "tableLayoutPanelMovieDirector";
            this.tableLayoutPanelMovieDirector.RowCount = 6;
            this.tableLayoutPanelMovieDirector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDirector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDirector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieDirector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDirector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieDirector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieDirector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieDirector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieDirector.Size = new System.Drawing.Size(834, 530);
            this.tableLayoutPanelMovieDirector.TabIndex = 1;
            // 
            // listBoxMovieDirectorRight
            // 
            this.listBoxMovieDirectorRight.DisplayMember = "MovieDirectorName";
            this.listBoxMovieDirectorRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieDirectorRight.FormattingEnabled = true;
            this.listBoxMovieDirectorRight.ItemHeight = 16;
            this.listBoxMovieDirectorRight.Location = new System.Drawing.Point(454, 51);
            this.listBoxMovieDirectorRight.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieDirectorRight.Name = "listBoxMovieDirectorRight";
            this.tableLayoutPanelMovieDirector.SetRowSpan(this.listBoxMovieDirectorRight, 4);
            this.listBoxMovieDirectorRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieDirectorRight.Size = new System.Drawing.Size(376, 475);
            this.listBoxMovieDirectorRight.TabIndex = 9;
            // 
            // textBoxMovieDirectorSearch
            // 
            this.textBoxMovieDirectorSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieDirectorSearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxMovieDirectorSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieDirectorSearch.Name = "textBoxMovieDirectorSearch";
            this.textBoxMovieDirectorSearch.Size = new System.Drawing.Size(375, 22);
            this.textBoxMovieDirectorSearch.TabIndex = 5;
            this.textBoxMovieDirectorSearch.TextChanged += new System.EventHandler(this.textBoxMovieDirectorSearch_TextChanged);
            // 
            // labelMovieDirectorSearch
            // 
            this.labelMovieDirectorSearch.AutoSize = true;
            this.labelMovieDirectorSearch.Location = new System.Drawing.Point(4, 0);
            this.labelMovieDirectorSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieDirectorSearch.Name = "labelMovieDirectorSearch";
            this.labelMovieDirectorSearch.Size = new System.Drawing.Size(57, 17);
            this.labelMovieDirectorSearch.TabIndex = 4;
            this.labelMovieDirectorSearch.Text = "Search:";
            // 
            // listBoxMovieDirectorLeft
            // 
            this.listBoxMovieDirectorLeft.ContextMenuStrip = this.menuMovieDirector;
            this.listBoxMovieDirectorLeft.DisplayMember = "MovieDirectorName";
            this.listBoxMovieDirectorLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieDirectorLeft.FormattingEnabled = true;
            this.listBoxMovieDirectorLeft.ItemHeight = 16;
            this.listBoxMovieDirectorLeft.Location = new System.Drawing.Point(4, 51);
            this.listBoxMovieDirectorLeft.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieDirectorLeft.Name = "listBoxMovieDirectorLeft";
            this.tableLayoutPanelMovieDirector.SetRowSpan(this.listBoxMovieDirectorLeft, 4);
            this.listBoxMovieDirectorLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieDirectorLeft.Size = new System.Drawing.Size(375, 475);
            this.listBoxMovieDirectorLeft.TabIndex = 6;
            // 
            // buttonMovieDirectorRight
            // 
            this.buttonMovieDirectorRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieDirectorRight.Location = new System.Drawing.Point(387, 256);
            this.buttonMovieDirectorRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieDirectorRight.Name = "buttonMovieDirectorRight";
            this.buttonMovieDirectorRight.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieDirectorRight.TabIndex = 10;
            this.buttonMovieDirectorRight.Text = ">";
            this.buttonMovieDirectorRight.UseVisualStyleBackColor = true;
            this.buttonMovieDirectorRight.Click += new System.EventHandler(this.buttonMovieDirectorRight_Click);
            // 
            // buttonMovieDirectorLeft
            // 
            this.buttonMovieDirectorLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieDirectorLeft.Location = new System.Drawing.Point(387, 292);
            this.buttonMovieDirectorLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieDirectorLeft.Name = "buttonMovieDirectorLeft";
            this.buttonMovieDirectorLeft.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieDirectorLeft.TabIndex = 11;
            this.buttonMovieDirectorLeft.Text = "<";
            this.buttonMovieDirectorLeft.UseVisualStyleBackColor = true;
            this.buttonMovieDirectorLeft.Click += new System.EventHandler(this.buttonMovieDirectorLeft_Click);
            // 
            // tabPageMovieCast
            // 
            this.tabPageMovieCast.Controls.Add(this.tableLayoutPanelMovieCast);
            this.tabPageMovieCast.Location = new System.Drawing.Point(4, 25);
            this.tabPageMovieCast.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMovieCast.Name = "tabPageMovieCast";
            this.tabPageMovieCast.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMovieCast.Size = new System.Drawing.Size(842, 538);
            this.tabPageMovieCast.TabIndex = 4;
            this.tabPageMovieCast.Text = "MovieCast";
            this.tabPageMovieCast.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMovieCast
            // 
            this.tableLayoutPanelMovieCast.ColumnCount = 3;
            this.tableLayoutPanelMovieCast.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieCast.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanelMovieCast.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieCast.Controls.Add(this.listBoxMovieCastRight, 2, 2);
            this.tableLayoutPanelMovieCast.Controls.Add(this.textBoxMovieCastSearch, 0, 1);
            this.tableLayoutPanelMovieCast.Controls.Add(this.labelMovieCastSearch, 0, 0);
            this.tableLayoutPanelMovieCast.Controls.Add(this.listBoxMovieCastLeft, 0, 2);
            this.tableLayoutPanelMovieCast.Controls.Add(this.buttonMovieCastRight, 1, 3);
            this.tableLayoutPanelMovieCast.Controls.Add(this.buttonMovieCastLeft, 1, 4);
            this.tableLayoutPanelMovieCast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMovieCast.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelMovieCast.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMovieCast.Name = "tableLayoutPanelMovieCast";
            this.tableLayoutPanelMovieCast.RowCount = 6;
            this.tableLayoutPanelMovieCast.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieCast.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieCast.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieCast.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieCast.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieCast.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieCast.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieCast.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieCast.Size = new System.Drawing.Size(834, 530);
            this.tableLayoutPanelMovieCast.TabIndex = 1;
            // 
            // listBoxMovieCastRight
            // 
            this.listBoxMovieCastRight.DisplayMember = "CastName";
            this.listBoxMovieCastRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieCastRight.FormattingEnabled = true;
            this.listBoxMovieCastRight.ItemHeight = 16;
            this.listBoxMovieCastRight.Location = new System.Drawing.Point(454, 51);
            this.listBoxMovieCastRight.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieCastRight.Name = "listBoxMovieCastRight";
            this.tableLayoutPanelMovieCast.SetRowSpan(this.listBoxMovieCastRight, 4);
            this.listBoxMovieCastRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieCastRight.Size = new System.Drawing.Size(376, 475);
            this.listBoxMovieCastRight.TabIndex = 9;
            // 
            // textBoxMovieCastSearch
            // 
            this.textBoxMovieCastSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieCastSearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxMovieCastSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieCastSearch.Name = "textBoxMovieCastSearch";
            this.textBoxMovieCastSearch.Size = new System.Drawing.Size(375, 22);
            this.textBoxMovieCastSearch.TabIndex = 5;
            this.textBoxMovieCastSearch.TextChanged += new System.EventHandler(this.textBoxMovieCastSearch_TextChanged);
            // 
            // labelMovieCastSearch
            // 
            this.labelMovieCastSearch.AutoSize = true;
            this.labelMovieCastSearch.Location = new System.Drawing.Point(4, 0);
            this.labelMovieCastSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieCastSearch.Name = "labelMovieCastSearch";
            this.labelMovieCastSearch.Size = new System.Drawing.Size(57, 17);
            this.labelMovieCastSearch.TabIndex = 4;
            this.labelMovieCastSearch.Text = "Search:";
            // 
            // listBoxMovieCastLeft
            // 
            this.listBoxMovieCastLeft.ContextMenuStrip = this.menuMovieCast;
            this.listBoxMovieCastLeft.DisplayMember = "CastName";
            this.listBoxMovieCastLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieCastLeft.FormattingEnabled = true;
            this.listBoxMovieCastLeft.ItemHeight = 16;
            this.listBoxMovieCastLeft.Location = new System.Drawing.Point(4, 51);
            this.listBoxMovieCastLeft.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieCastLeft.Name = "listBoxMovieCastLeft";
            this.tableLayoutPanelMovieCast.SetRowSpan(this.listBoxMovieCastLeft, 4);
            this.listBoxMovieCastLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieCastLeft.Size = new System.Drawing.Size(375, 475);
            this.listBoxMovieCastLeft.TabIndex = 6;
            // 
            // buttonMovieCastRight
            // 
            this.buttonMovieCastRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieCastRight.Location = new System.Drawing.Point(387, 256);
            this.buttonMovieCastRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieCastRight.Name = "buttonMovieCastRight";
            this.buttonMovieCastRight.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieCastRight.TabIndex = 10;
            this.buttonMovieCastRight.Text = ">";
            this.buttonMovieCastRight.UseVisualStyleBackColor = true;
            this.buttonMovieCastRight.Click += new System.EventHandler(this.buttonMovieCastRight_Click);
            // 
            // buttonMovieCastLeft
            // 
            this.buttonMovieCastLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieCastLeft.Location = new System.Drawing.Point(387, 292);
            this.buttonMovieCastLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieCastLeft.Name = "buttonMovieCastLeft";
            this.buttonMovieCastLeft.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieCastLeft.TabIndex = 11;
            this.buttonMovieCastLeft.Text = "<";
            this.buttonMovieCastLeft.UseVisualStyleBackColor = true;
            this.buttonMovieCastLeft.Click += new System.EventHandler(this.buttonMovieCastLeft_Click);
            // 
            // tabPageMovieCategory
            // 
            this.tabPageMovieCategory.Controls.Add(this.tableLayoutPanelMovieCategory);
            this.tabPageMovieCategory.Location = new System.Drawing.Point(4, 25);
            this.tabPageMovieCategory.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMovieCategory.Name = "tabPageMovieCategory";
            this.tabPageMovieCategory.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMovieCategory.Size = new System.Drawing.Size(842, 538);
            this.tabPageMovieCategory.TabIndex = 5;
            this.tabPageMovieCategory.Text = "MovieCategory";
            this.tabPageMovieCategory.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMovieCategory
            // 
            this.tableLayoutPanelMovieCategory.ColumnCount = 3;
            this.tableLayoutPanelMovieCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanelMovieCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieCategory.Controls.Add(this.listBoxMovieCategoryRight, 2, 2);
            this.tableLayoutPanelMovieCategory.Controls.Add(this.textBoxMovieCategorySearch, 0, 1);
            this.tableLayoutPanelMovieCategory.Controls.Add(this.labelMovieCategorySearch, 0, 0);
            this.tableLayoutPanelMovieCategory.Controls.Add(this.listBoxMovieCategoryLeft, 0, 2);
            this.tableLayoutPanelMovieCategory.Controls.Add(this.buttonMovieCategoryRight, 1, 3);
            this.tableLayoutPanelMovieCategory.Controls.Add(this.buttonMovieCategoryLeft, 1, 4);
            this.tableLayoutPanelMovieCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMovieCategory.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelMovieCategory.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMovieCategory.Name = "tableLayoutPanelMovieCategory";
            this.tableLayoutPanelMovieCategory.RowCount = 6;
            this.tableLayoutPanelMovieCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMovieCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMovieCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMovieCategory.Size = new System.Drawing.Size(834, 530);
            this.tableLayoutPanelMovieCategory.TabIndex = 1;
            // 
            // listBoxMovieCategoryRight
            // 
            this.listBoxMovieCategoryRight.DisplayMember = "MovieCategoryName";
            this.listBoxMovieCategoryRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieCategoryRight.FormattingEnabled = true;
            this.listBoxMovieCategoryRight.ItemHeight = 16;
            this.listBoxMovieCategoryRight.Location = new System.Drawing.Point(454, 51);
            this.listBoxMovieCategoryRight.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieCategoryRight.Name = "listBoxMovieCategoryRight";
            this.tableLayoutPanelMovieCategory.SetRowSpan(this.listBoxMovieCategoryRight, 4);
            this.listBoxMovieCategoryRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieCategoryRight.Size = new System.Drawing.Size(376, 475);
            this.listBoxMovieCategoryRight.TabIndex = 9;
            // 
            // textBoxMovieCategorySearch
            // 
            this.textBoxMovieCategorySearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieCategorySearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxMovieCategorySearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieCategorySearch.Name = "textBoxMovieCategorySearch";
            this.textBoxMovieCategorySearch.Size = new System.Drawing.Size(375, 22);
            this.textBoxMovieCategorySearch.TabIndex = 5;
            this.textBoxMovieCategorySearch.TextChanged += new System.EventHandler(this.textBoxMovieCategorySearch_TextChanged);
            // 
            // labelMovieCategorySearch
            // 
            this.labelMovieCategorySearch.AutoSize = true;
            this.labelMovieCategorySearch.Location = new System.Drawing.Point(4, 0);
            this.labelMovieCategorySearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMovieCategorySearch.Name = "labelMovieCategorySearch";
            this.labelMovieCategorySearch.Size = new System.Drawing.Size(57, 17);
            this.labelMovieCategorySearch.TabIndex = 4;
            this.labelMovieCategorySearch.Text = "Search:";
            // 
            // listBoxMovieCategoryLeft
            // 
            this.listBoxMovieCategoryLeft.ContextMenuStrip = this.menuMovieCategory;
            this.listBoxMovieCategoryLeft.DisplayMember = "MovieCategoryName";
            this.listBoxMovieCategoryLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieCategoryLeft.FormattingEnabled = true;
            this.listBoxMovieCategoryLeft.ItemHeight = 16;
            this.listBoxMovieCategoryLeft.Location = new System.Drawing.Point(4, 51);
            this.listBoxMovieCategoryLeft.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieCategoryLeft.Name = "listBoxMovieCategoryLeft";
            this.tableLayoutPanelMovieCategory.SetRowSpan(this.listBoxMovieCategoryLeft, 4);
            this.listBoxMovieCategoryLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieCategoryLeft.Size = new System.Drawing.Size(375, 475);
            this.listBoxMovieCategoryLeft.TabIndex = 6;
            // 
            // buttonMovieCategoryRight
            // 
            this.buttonMovieCategoryRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieCategoryRight.Location = new System.Drawing.Point(387, 256);
            this.buttonMovieCategoryRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieCategoryRight.Name = "buttonMovieCategoryRight";
            this.buttonMovieCategoryRight.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieCategoryRight.TabIndex = 10;
            this.buttonMovieCategoryRight.Text = ">";
            this.buttonMovieCategoryRight.UseVisualStyleBackColor = true;
            this.buttonMovieCategoryRight.Click += new System.EventHandler(this.buttonMovieCategoryRight_Click);
            // 
            // buttonMovieCategoryLeft
            // 
            this.buttonMovieCategoryLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieCategoryLeft.Location = new System.Drawing.Point(387, 292);
            this.buttonMovieCategoryLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieCategoryLeft.Name = "buttonMovieCategoryLeft";
            this.buttonMovieCategoryLeft.Size = new System.Drawing.Size(59, 28);
            this.buttonMovieCategoryLeft.TabIndex = 11;
            this.buttonMovieCategoryLeft.Text = "<";
            this.buttonMovieCategoryLeft.UseVisualStyleBackColor = true;
            this.buttonMovieCategoryLeft.Click += new System.EventHandler(this.buttonMovieCategoryLeft_Click);
            // 
            // tabPageSaloon
            // 
            this.tabPageSaloon.Controls.Add(this.tabSaloon);
            this.tabPageSaloon.Controls.Add(this.panel1);
            this.tabPageSaloon.Controls.Add(this.toolStrip1);
            this.tabPageSaloon.Location = new System.Drawing.Point(4, 25);
            this.tabPageSaloon.Name = "tabPageSaloon";
            this.tabPageSaloon.Size = new System.Drawing.Size(842, 538);
            this.tabPageSaloon.TabIndex = 9;
            this.tabPageSaloon.Text = "Saloon";
            this.tabPageSaloon.UseVisualStyleBackColor = true;
            // 
            // tabSaloon
            // 
            this.tabSaloon.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSaloon.Controls.Add(this.tabPage1);
            this.tabSaloon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSaloon.ImageList = this.imageList1;
            this.tabSaloon.Location = new System.Drawing.Point(0, 58);
            this.tabSaloon.Name = "tabSaloon";
            this.tabSaloon.SelectedIndex = 0;
            this.tabSaloon.Size = new System.Drawing.Size(842, 480);
            this.tabSaloon.TabIndex = 11;
            this.tabSaloon.SelectedIndexChanged += new System.EventHandler(this.tabSaloon_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 50);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(834, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "theatre_11.png");
            this.imageList1.Images.SetKeyName(1, "theatre_22.png");
            this.imageList1.Images.SetKeyName(2, "theatre_22.png");
            this.imageList1.Images.SetKeyName(3, "theatre_33.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBlockCount);
            this.panel1.Controls.Add(this.chkBlock);
            this.panel1.Controls.Add(this.cmbTemp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 31);
            this.panel1.TabIndex = 8;
            // 
            // txtBlockCount
            // 
            this.txtBlockCount.Location = new System.Drawing.Point(278, 4);
            this.txtBlockCount.Name = "txtBlockCount";
            this.txtBlockCount.ReadOnly = true;
            this.txtBlockCount.Size = new System.Drawing.Size(44, 22);
            this.txtBlockCount.TabIndex = 4;
            this.txtBlockCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtBlockCount.ValueChanged += new System.EventHandler(this.txtBlockCount_ValueChanged);
            // 
            // chkBlock
            // 
            this.chkBlock.AutoSize = true;
            this.chkBlock.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBlock.Location = new System.Drawing.Point(169, 5);
            this.chkBlock.Name = "chkBlock";
            this.chkBlock.Size = new System.Drawing.Size(93, 21);
            this.chkBlock.TabIndex = 3;
            this.chkBlock.Text = "Add Block";
            this.chkBlock.UseVisualStyleBackColor = true;
            this.chkBlock.CheckedChanged += new System.EventHandler(this.chkBlock_CheckedChanged);
            // 
            // cmbTemp
            // 
            this.cmbTemp.FormattingEnabled = true;
            this.cmbTemp.Location = new System.Drawing.Point(3, 4);
            this.cmbTemp.Name = "cmbTemp";
            this.cmbTemp.Size = new System.Drawing.Size(160, 24);
            this.cmbTemp.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnList,
            this.toolStripBtnClear,
            this.toolStripBtnRefresh,
            this.toolStripBtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(842, 27);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnList
            // 
            this.toolStripBtnList.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnList.Image")));
            this.toolStripBtnList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnList.Name = "toolStripBtnList";
            this.toolStripBtnList.Size = new System.Drawing.Size(55, 24);
            this.toolStripBtnList.Text = "List";
            this.toolStripBtnList.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // toolStripBtnClear
            // 
            this.toolStripBtnClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnClear.Image")));
            this.toolStripBtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnClear.Name = "toolStripBtnClear";
            this.toolStripBtnClear.Size = new System.Drawing.Size(67, 24);
            this.toolStripBtnClear.Text = "Clear";
            this.toolStripBtnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // toolStripBtnRefresh
            // 
            this.toolStripBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRefresh.Image")));
            this.toolStripBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRefresh.Name = "toolStripBtnRefresh";
            this.toolStripBtnRefresh.Size = new System.Drawing.Size(82, 24);
            this.toolStripBtnRefresh.Text = "Refresh";
            this.toolStripBtnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(64, 24);
            this.toolStripBtnSave.Text = "Save";
            this.toolStripBtnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPageMovieSession
            // 
            this.tabPageMovieSession.Controls.Add(this.panel2);
            this.tabPageMovieSession.Controls.Add(this.tableLayoutPanel1);
            this.tabPageMovieSession.Location = new System.Drawing.Point(4, 25);
            this.tabPageMovieSession.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMovieSession.Name = "tabPageMovieSession";
            this.tabPageMovieSession.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMovieSession.Size = new System.Drawing.Size(842, 538);
            this.tabPageMovieSession.TabIndex = 6;
            this.tabPageMovieSession.Text = "MovieSession";
            this.tabPageMovieSession.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tabSession);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 389);
            this.panel2.TabIndex = 13;
            // 
            // tabSession
            // 
            this.tabSession.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSession.Controls.Add(this.tabPage2);
            this.tabSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSession.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabSession.ImageList = this.imageList1;
            this.tabSession.ItemSize = new System.Drawing.Size(109, 40);
            this.tabSession.Location = new System.Drawing.Point(0, 0);
            this.tabSession.Name = "tabSession";
            this.tabSession.Padding = new System.Drawing.Point(0, 0);
            this.tabSession.RightToLeftLayout = true;
            this.tabSession.SelectedIndex = 0;
            this.tabSession.Size = new System.Drawing.Size(834, 389);
            this.tabSession.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSession.TabIndex = 12;
            this.tabSession.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabSession_DrawItem);
            this.tabSession.SelectedIndexChanged += new System.EventHandler(this.tabSession_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(826, 341);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewMovieSession, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.datePickerMovieSession, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSessionTimePrev, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSessionTimeNext, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxMovieSessionMovieFormat, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 141);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewMovieSession
            // 
            this.dataGridViewMovieSession.AllowUserToAddRows = false;
            this.dataGridViewMovieSession.AllowUserToDeleteRows = false;
            this.dataGridViewMovieSession.AllowUserToOrderColumns = true;
            this.dataGridViewMovieSession.AllowUserToResizeColumns = false;
            this.dataGridViewMovieSession.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMovieSession.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewMovieSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMovieSession.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Theatre,
            this.SessionTime});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewMovieSession, 3);
            this.dataGridViewMovieSession.ContextMenuStrip = this.menuMovieSession;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMovieSession.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewMovieSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMovieSession.Location = new System.Drawing.Point(4, 37);
            this.dataGridViewMovieSession.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewMovieSession.MultiSelect = false;
            this.dataGridViewMovieSession.Name = "dataGridViewMovieSession";
            this.dataGridViewMovieSession.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMovieSession.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewMovieSession.RowHeadersVisible = false;
            this.dataGridViewMovieSession.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMovieSession.Size = new System.Drawing.Size(299, 100);
            this.dataGridViewMovieSession.TabIndex = 9;
            this.dataGridViewMovieSession.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewMovieSession_CellFormatting);
            this.dataGridViewMovieSession.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewMovieSession_DataBindingComplete);
            this.dataGridViewMovieSession.SelectionChanged += new System.EventHandler(this.dataGridViewMovieSession_SelectionChanged);
            this.dataGridViewMovieSession.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewMovieSession_KeyDown);
            // 
            // Theatre
            // 
            this.Theatre.HeaderText = "Theatre Place";
            this.Theatre.Name = "Theatre";
            this.Theatre.ReadOnly = true;
            // 
            // SessionTime
            // 
            this.SessionTime.HeaderText = "SessionTime";
            this.SessionTime.Name = "SessionTime";
            this.SessionTime.ReadOnly = true;
            // 
            // datePickerMovieSession
            // 
            this.datePickerMovieSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datePickerMovieSession.Location = new System.Drawing.Point(45, 4);
            this.datePickerMovieSession.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerMovieSession.Name = "datePickerMovieSession";
            this.datePickerMovieSession.Size = new System.Drawing.Size(221, 22);
            this.datePickerMovieSession.TabIndex = 10;
            this.datePickerMovieSession.ValueChanged += new System.EventHandler(this.datePickerMovieSession_ValueChanged);
            // 
            // buttonSessionTimePrev
            // 
            this.buttonSessionTimePrev.Location = new System.Drawing.Point(4, 4);
            this.buttonSessionTimePrev.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSessionTimePrev.Name = "buttonSessionTimePrev";
            this.buttonSessionTimePrev.Size = new System.Drawing.Size(33, 25);
            this.buttonSessionTimePrev.TabIndex = 11;
            this.buttonSessionTimePrev.Text = "<";
            this.buttonSessionTimePrev.UseVisualStyleBackColor = true;
            this.buttonSessionTimePrev.Click += new System.EventHandler(this.buttonSessionTimePrev_Click);
            // 
            // buttonSessionTimeNext
            // 
            this.buttonSessionTimeNext.Location = new System.Drawing.Point(270, 4);
            this.buttonSessionTimeNext.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.buttonSessionTimeNext.Name = "buttonSessionTimeNext";
            this.buttonSessionTimeNext.Size = new System.Drawing.Size(33, 25);
            this.buttonSessionTimeNext.TabIndex = 12;
            this.buttonSessionTimeNext.Text = ">";
            this.buttonSessionTimeNext.UseVisualStyleBackColor = true;
            this.buttonSessionTimeNext.Click += new System.EventHandler(this.buttonSessionTimeNext_Click);
            // 
            // groupBoxMovieSessionMovieFormat
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxMovieSessionMovieFormat, 3);
            this.groupBoxMovieSessionMovieFormat.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxMovieSessionMovieFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMovieSessionMovieFormat.Location = new System.Drawing.Point(311, 37);
            this.groupBoxMovieSessionMovieFormat.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxMovieSessionMovieFormat.Name = "groupBoxMovieSessionMovieFormat";
            this.groupBoxMovieSessionMovieFormat.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxMovieSessionMovieFormat.Size = new System.Drawing.Size(519, 100);
            this.groupBoxMovieSessionMovieFormat.TabIndex = 15;
            this.groupBoxMovieSessionMovieFormat.TabStop = false;
            this.groupBoxMovieSessionMovieFormat.Text = "Session\'s Movie Formats";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.listBoxMovieSessionMovieFormatRight, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.listBoxMovieSessionMovieFormatLeft, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonMovieSessionMovieFormatRight, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonMovieSessionMovieFormatLeft, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMovieSessionMovieFormatSearch, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(511, 77);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // listBoxMovieSessionMovieFormatRight
            // 
            this.listBoxMovieSessionMovieFormatRight.DisplayMember = "MovieFormatName";
            this.listBoxMovieSessionMovieFormatRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieSessionMovieFormatRight.FormattingEnabled = true;
            this.listBoxMovieSessionMovieFormatRight.ItemHeight = 16;
            this.listBoxMovieSessionMovieFormatRight.Location = new System.Drawing.Point(293, 51);
            this.listBoxMovieSessionMovieFormatRight.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieSessionMovieFormatRight.Name = "listBoxMovieSessionMovieFormatRight";
            this.tableLayoutPanel2.SetRowSpan(this.listBoxMovieSessionMovieFormatRight, 4);
            this.listBoxMovieSessionMovieFormatRight.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieSessionMovieFormatRight.Size = new System.Drawing.Size(214, 22);
            this.listBoxMovieSessionMovieFormatRight.TabIndex = 9;
            // 
            // listBoxMovieSessionMovieFormatLeft
            // 
            this.listBoxMovieSessionMovieFormatLeft.DisplayMember = "MovieFormatName";
            this.listBoxMovieSessionMovieFormatLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMovieSessionMovieFormatLeft.FormattingEnabled = true;
            this.listBoxMovieSessionMovieFormatLeft.ItemHeight = 16;
            this.listBoxMovieSessionMovieFormatLeft.Location = new System.Drawing.Point(4, 51);
            this.listBoxMovieSessionMovieFormatLeft.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMovieSessionMovieFormatLeft.Name = "listBoxMovieSessionMovieFormatLeft";
            this.tableLayoutPanel2.SetRowSpan(this.listBoxMovieSessionMovieFormatLeft, 4);
            this.listBoxMovieSessionMovieFormatLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMovieSessionMovieFormatLeft.Size = new System.Drawing.Size(214, 22);
            this.listBoxMovieSessionMovieFormatLeft.TabIndex = 9;
            // 
            // buttonMovieSessionMovieFormatRight
            // 
            this.buttonMovieSessionMovieFormatRight.AutoSize = true;
            this.buttonMovieSessionMovieFormatRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieSessionMovieFormatRight.Location = new System.Drawing.Point(226, 25);
            this.buttonMovieSessionMovieFormatRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieSessionMovieFormatRight.Name = "buttonMovieSessionMovieFormatRight";
            this.buttonMovieSessionMovieFormatRight.Size = new System.Drawing.Size(59, 33);
            this.buttonMovieSessionMovieFormatRight.TabIndex = 11;
            this.buttonMovieSessionMovieFormatRight.Text = ">";
            this.buttonMovieSessionMovieFormatRight.UseVisualStyleBackColor = true;
            this.buttonMovieSessionMovieFormatRight.Click += new System.EventHandler(this.buttonMovieSessionMovieFormatRight_Click);
            // 
            // buttonMovieSessionMovieFormatLeft
            // 
            this.buttonMovieSessionMovieFormatLeft.AutoSize = true;
            this.buttonMovieSessionMovieFormatLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieSessionMovieFormatLeft.Location = new System.Drawing.Point(226, 66);
            this.buttonMovieSessionMovieFormatLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMovieSessionMovieFormatLeft.Name = "buttonMovieSessionMovieFormatLeft";
            this.buttonMovieSessionMovieFormatLeft.Size = new System.Drawing.Size(59, 33);
            this.buttonMovieSessionMovieFormatLeft.TabIndex = 12;
            this.buttonMovieSessionMovieFormatLeft.Text = "<";
            this.buttonMovieSessionMovieFormatLeft.UseVisualStyleBackColor = true;
            this.buttonMovieSessionMovieFormatLeft.Click += new System.EventHandler(this.buttonMovieSessionMovieFormatLeft_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Search:";
            // 
            // textBoxMovieSessionMovieFormatSearch
            // 
            this.textBoxMovieSessionMovieFormatSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMovieSessionMovieFormatSearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxMovieSessionMovieFormatSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMovieSessionMovieFormatSearch.Name = "textBoxMovieSessionMovieFormatSearch";
            this.textBoxMovieSessionMovieFormatSearch.Size = new System.Drawing.Size(214, 22);
            this.textBoxMovieSessionMovieFormatSearch.TabIndex = 14;
            this.textBoxMovieSessionMovieFormatSearch.TextChanged += new System.EventHandler(this.textBoxMovieSessionMovieFormatSearch_TextChanged);
            // 
            // tabPageUser
            // 
            this.tabPageUser.Controls.Add(this.tableLayoutPanel3);
            this.tabPageUser.Location = new System.Drawing.Point(4, 25);
            this.tabPageUser.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageUser.Size = new System.Drawing.Size(842, 538);
            this.tabPageUser.TabIndex = 7;
            this.tabPageUser.Text = "Users";
            this.tabPageUser.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.textBoxUserSearch, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataGridViewUser, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(834, 530);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // textBoxUserSearch
            // 
            this.textBoxUserSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUserSearch.Location = new System.Drawing.Point(4, 21);
            this.textBoxUserSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUserSearch.Name = "textBoxUserSearch";
            this.textBoxUserSearch.Size = new System.Drawing.Size(826, 22);
            this.textBoxUserSearch.TabIndex = 15;
            this.textBoxUserSearch.TextChanged += new System.EventHandler(this.textBoxUserSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Search:";
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.AllowUserToDeleteRows = false;
            this.dataGridViewUser.AllowUserToOrderColumns = true;
            this.dataGridViewUser.AllowUserToResizeColumns = false;
            this.dataGridViewUser.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewUser.ContextMenuStrip = this.menuUser;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUser.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUser.Location = new System.Drawing.Point(4, 51);
            this.dataGridViewUser.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewUser.MultiSelect = false;
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewUser.RowHeadersVisible = false;
            this.dataGridViewUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUser.Size = new System.Drawing.Size(826, 475);
            this.dataGridViewUser.TabIndex = 10;
            // 
            // tabPageDesign
            // 
            this.tabPageDesign.Controls.Add(this.reportViewerDesign);
            this.tabPageDesign.Controls.Add(this.toolStripDesign);
            this.tabPageDesign.Location = new System.Drawing.Point(4, 25);
            this.tabPageDesign.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageDesign.Name = "tabPageDesign";
            this.tabPageDesign.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageDesign.Size = new System.Drawing.Size(842, 538);
            this.tabPageDesign.TabIndex = 8;
            this.tabPageDesign.Text = "Design";
            this.tabPageDesign.UseVisualStyleBackColor = true;
            // 
            // reportViewerDesign
            // 
            this.reportViewerDesign.AccessibilityKeyMap = null;
            this.reportViewerDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerDesign.Location = new System.Drawing.Point(4, 31);
            this.reportViewerDesign.Margin = new System.Windows.Forms.Padding(5);
            this.reportViewerDesign.Name = "reportViewerDesign";
            this.reportViewerDesign.Size = new System.Drawing.Size(834, 503);
            this.reportViewerDesign.TabIndex = 0;
            // 
            // toolStripDesign
            // 
            this.toolStripDesign.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripDesign.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripDesign.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDesignRefresh,
            this.buttonDesignUpdate,
            this.buttonDesignExport});
            this.toolStripDesign.Location = new System.Drawing.Point(4, 4);
            this.toolStripDesign.Name = "toolStripDesign";
            this.toolStripDesign.Size = new System.Drawing.Size(834, 27);
            this.toolStripDesign.TabIndex = 7;
            this.toolStripDesign.Text = "toolStrip1";
            // 
            // buttonDesignRefresh
            // 
            this.buttonDesignRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonDesignRefresh.Image")));
            this.buttonDesignRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDesignRefresh.Name = "buttonDesignRefresh";
            this.buttonDesignRefresh.Size = new System.Drawing.Size(82, 24);
            this.buttonDesignRefresh.Text = "Refresh";
            this.buttonDesignRefresh.Click += new System.EventHandler(this.buttonDesignRefresh_Click);
            // 
            // buttonDesignUpdate
            // 
            this.buttonDesignUpdate.Image = ((System.Drawing.Image)(resources.GetObject("buttonDesignUpdate.Image")));
            this.buttonDesignUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDesignUpdate.Name = "buttonDesignUpdate";
            this.buttonDesignUpdate.Size = new System.Drawing.Size(82, 24);
            this.buttonDesignUpdate.Text = "Update";
            this.buttonDesignUpdate.Click += new System.EventHandler(this.buttonDesignUpdate_Click);
            // 
            // buttonDesignExport
            // 
            this.buttonDesignExport.Image = ((System.Drawing.Image)(resources.GetObject("buttonDesignExport.Image")));
            this.buttonDesignExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDesignExport.Name = "buttonDesignExport";
            this.buttonDesignExport.Size = new System.Drawing.Size(76, 24);
            this.buttonDesignExport.Text = "Export";
            this.buttonDesignExport.Click += new System.EventHandler(this.buttonDesignExport_Click);
            // 
            // menuSeats
            // 
            this.menuSeats.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuSeats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.standardSeatToolStripMenuItem,
            this.disabledSeatToolStripMenuItem,
            this.doubleSeatToolStripMenuItem,
            this.vIPToolStripMenuItem});
            this.menuSeats.Name = "menuMovieType";
            this.menuSeats.Size = new System.Drawing.Size(176, 140);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(175, 26);
            this.toolStripMenuItem2.Text = "Set Amount";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // standardSeatToolStripMenuItem
            // 
            this.standardSeatToolStripMenuItem.Name = "standardSeatToolStripMenuItem";
            this.standardSeatToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.standardSeatToolStripMenuItem.Text = "Standard Seat";
            this.standardSeatToolStripMenuItem.Click += new System.EventHandler(this.standardSeatToolStripMenuItem_Click);
            // 
            // disabledSeatToolStripMenuItem
            // 
            this.disabledSeatToolStripMenuItem.Name = "disabledSeatToolStripMenuItem";
            this.disabledSeatToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.disabledSeatToolStripMenuItem.Text = "Disabled Seat";
            this.disabledSeatToolStripMenuItem.Click += new System.EventHandler(this.disabledSeatToolStripMenuItem_Click);
            // 
            // doubleSeatToolStripMenuItem
            // 
            this.doubleSeatToolStripMenuItem.Name = "doubleSeatToolStripMenuItem";
            this.doubleSeatToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.doubleSeatToolStripMenuItem.Text = "Double Seat";
            this.doubleSeatToolStripMenuItem.Click += new System.EventHandler(this.doubleSeatToolStripMenuItem_Click);
            // 
            // vIPToolStripMenuItem
            // 
            this.vIPToolStripMenuItem.Name = "vIPToolStripMenuItem";
            this.vIPToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.vIPToolStripMenuItem.Text = "VIP";
            this.vIPToolStripMenuItem.Click += new System.EventHandler(this.vIPToolStripMenuItem_Click);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(240, 1);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(834, 27);
            this.miniToolStrip.TabIndex = 7;
            // 
            // menuSaloonCreate
            // 
            this.menuSaloonCreate.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuSaloonCreate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddRow,
            this.toolStripAddCol,
            this.toolStripSeparator3,
            this.toolStripAddSep,
            this.toolStripAddHall,
            this.toolStripDeleteRow,
            this.koltukAdıToolStripMenuItem});
            this.menuSaloonCreate.Name = "menuMovieType";
            this.menuSaloonCreate.Size = new System.Drawing.Size(179, 166);
            this.menuSaloonCreate.Opening += new System.ComponentModel.CancelEventHandler(this.menuSaloonCreate_Opening);
            // 
            // toolStripAddRow
            // 
            this.toolStripAddRow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddRow1,
            this.toolStripAddRow5,
            this.toolStripAddRow10,
            this.toolStripAddRow20});
            this.toolStripAddRow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddRow.Image")));
            this.toolStripAddRow.Name = "toolStripAddRow";
            this.toolStripAddRow.Size = new System.Drawing.Size(178, 26);
            this.toolStripAddRow.Text = "Sıra Ekle";
            // 
            // toolStripAddRow1
            // 
            this.toolStripAddRow1.Name = "toolStripAddRow1";
            this.toolStripAddRow1.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddRow1.Text = "1";
            this.toolStripAddRow1.Click += new System.EventHandler(this.toolStripAddRow1_Click);
            // 
            // toolStripAddRow5
            // 
            this.toolStripAddRow5.Name = "toolStripAddRow5";
            this.toolStripAddRow5.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddRow5.Text = "5";
            this.toolStripAddRow5.Click += new System.EventHandler(this.toolStripAddRow5_Click);
            // 
            // toolStripAddRow10
            // 
            this.toolStripAddRow10.Name = "toolStripAddRow10";
            this.toolStripAddRow10.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddRow10.Text = "10";
            this.toolStripAddRow10.Click += new System.EventHandler(this.toolStripAddRow10_Click);
            // 
            // toolStripAddRow20
            // 
            this.toolStripAddRow20.Name = "toolStripAddRow20";
            this.toolStripAddRow20.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddRow20.Text = "20";
            this.toolStripAddRow20.Click += new System.EventHandler(this.toolStripAddRow20_Click);
            // 
            // toolStripAddCol
            // 
            this.toolStripAddCol.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddCol1,
            this.toolStripAddCol5,
            this.toolStripAddCol10,
            this.toolStripAddCol20});
            this.toolStripAddCol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddCol.Image")));
            this.toolStripAddCol.Name = "toolStripAddCol";
            this.toolStripAddCol.Size = new System.Drawing.Size(178, 26);
            this.toolStripAddCol.Text = "Koltuk Ekle";
            // 
            // toolStripAddCol1
            // 
            this.toolStripAddCol1.Name = "toolStripAddCol1";
            this.toolStripAddCol1.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddCol1.Text = "1";
            this.toolStripAddCol1.Click += new System.EventHandler(this.toolStripAddCol1_Click);
            // 
            // toolStripAddCol5
            // 
            this.toolStripAddCol5.Name = "toolStripAddCol5";
            this.toolStripAddCol5.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddCol5.Text = "5";
            this.toolStripAddCol5.Click += new System.EventHandler(this.toolStripAddCol5_Click);
            // 
            // toolStripAddCol10
            // 
            this.toolStripAddCol10.Name = "toolStripAddCol10";
            this.toolStripAddCol10.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddCol10.Text = "10";
            this.toolStripAddCol10.Click += new System.EventHandler(this.toolStripAddCol10_Click);
            // 
            // toolStripAddCol20
            // 
            this.toolStripAddCol20.Name = "toolStripAddCol20";
            this.toolStripAddCol20.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddCol20.Text = "20";
            this.toolStripAddCol20.Click += new System.EventHandler(this.toolStripAddCol20_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripAddSep
            // 
            this.toolStripAddSep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddSep1,
            this.toolStripAddSep5,
            this.toolStripAddSep10,
            this.toolStripAddSep20});
            this.toolStripAddSep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddSep.Image")));
            this.toolStripAddSep.Name = "toolStripAddSep";
            this.toolStripAddSep.Size = new System.Drawing.Size(178, 26);
            this.toolStripAddSep.Text = "Separatör Ekle";
            // 
            // toolStripAddSep1
            // 
            this.toolStripAddSep1.Name = "toolStripAddSep1";
            this.toolStripAddSep1.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddSep1.Text = "1";
            this.toolStripAddSep1.Click += new System.EventHandler(this.toolStripAddSep1_Click);
            // 
            // toolStripAddSep5
            // 
            this.toolStripAddSep5.Name = "toolStripAddSep5";
            this.toolStripAddSep5.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddSep5.Text = "5";
            this.toolStripAddSep5.Click += new System.EventHandler(this.toolStripAddSep5_Click);
            // 
            // toolStripAddSep10
            // 
            this.toolStripAddSep10.Name = "toolStripAddSep10";
            this.toolStripAddSep10.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddSep10.Text = "10";
            this.toolStripAddSep10.Click += new System.EventHandler(this.toolStripAddSep10_Click);
            // 
            // toolStripAddSep20
            // 
            this.toolStripAddSep20.Name = "toolStripAddSep20";
            this.toolStripAddSep20.Size = new System.Drawing.Size(100, 26);
            this.toolStripAddSep20.Text = "20";
            this.toolStripAddSep20.Click += new System.EventHandler(this.toolStripAddSep20_Click);
            // 
            // toolStripAddHall
            // 
            this.toolStripAddHall.Name = "toolStripAddHall";
            this.toolStripAddHall.Size = new System.Drawing.Size(178, 26);
            this.toolStripAddHall.Text = "Koridor Ekle";
            this.toolStripAddHall.Click += new System.EventHandler(this.toolStripAddHall_Click);
            // 
            // toolStripDeleteRow
            // 
            this.toolStripDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteRow.Image")));
            this.toolStripDeleteRow.Name = "toolStripDeleteRow";
            this.toolStripDeleteRow.Size = new System.Drawing.Size(178, 26);
            this.toolStripDeleteRow.Text = "Sıra Sil";
            this.toolStripDeleteRow.Click += new System.EventHandler(this.toolStripDeleteRow_Click);
            // 
            // koltukAdıToolStripMenuItem
            // 
            this.koltukAdıToolStripMenuItem.Name = "koltukAdıToolStripMenuItem";
            this.koltukAdıToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.koltukAdıToolStripMenuItem.Text = "Koltuk Adı";
            this.koltukAdıToolStripMenuItem.Click += new System.EventHandler(this.koltukAdıToolStripMenuItem_Click);
            // 
            // menuSaloonCreateSeat
            // 
            this.menuSaloonCreateSeat.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuSaloonCreateSeat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.toolStripMenuCreateSeatDelete});
            this.menuSaloonCreateSeat.Name = "menuMovieType";
            this.menuSaloonCreateSeat.Size = new System.Drawing.Size(99, 36);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(95, 6);
            // 
            // toolStripMenuCreateSeatDelete
            // 
            this.toolStripMenuCreateSeatDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuCreateSeatDelete.Image")));
            this.toolStripMenuCreateSeatDelete.Name = "toolStripMenuCreateSeatDelete";
            this.toolStripMenuCreateSeatDelete.Size = new System.Drawing.Size(98, 26);
            this.toolStripMenuCreateSeatDelete.Text = "Sil";
            this.toolStripMenuCreateSeatDelete.Click += new System.EventHandler(this.toolStripMenuCreateSeatDelete_Click);
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 567);
            this.Controls.Add(this.splitContainerMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MovieForm";
            this.Text = "Movies";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovie)).EndInit();
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.tableLayoutPanelLeft.PerformLayout();
            this.menuMovieType.ResumeLayout(false);
            this.menuMovieFormat.ResumeLayout(false);
            this.menuMovieDirector.ResumeLayout(false);
            this.menuMovieCast.ResumeLayout(false);
            this.menuMovieCategory.ResumeLayout(false);
            this.menuMovieSession.ResumeLayout(false);
            this.menuUser.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.toolStripSaloon.ResumeLayout(false);
            this.tabPageMovie.ResumeLayout(false);
            this.tableLayoutPanelMovieDetails.ResumeLayout(false);
            this.tableLayoutPanelMovieDetails.PerformLayout();
            this.toolStripMovieDetails.ResumeLayout(false);
            this.toolStripMovieDetails.PerformLayout();
            this.tableLayoutPanelMovieDetails2.ResumeLayout(false);
            this.tableLayoutPanelMovieDetails2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMovieDuration)).EndInit();
            this.tableLayoutPanelMovieDetailsPoster.ResumeLayout(false);
            this.tableLayoutPanelMovieDetailsPoster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoviePosterPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoviePosterOriginal)).EndInit();
            this.tabPageMovieType.ResumeLayout(false);
            this.tableLayoutPanelMovieType.ResumeLayout(false);
            this.tableLayoutPanelMovieType.PerformLayout();
            this.tabPageMovieFormat.ResumeLayout(false);
            this.tableLayoutPanelMovieFormat.ResumeLayout(false);
            this.tableLayoutPanelMovieFormat.PerformLayout();
            this.tabPageMovieDirector.ResumeLayout(false);
            this.tableLayoutPanelMovieDirector.ResumeLayout(false);
            this.tableLayoutPanelMovieDirector.PerformLayout();
            this.tabPageMovieCast.ResumeLayout(false);
            this.tableLayoutPanelMovieCast.ResumeLayout(false);
            this.tableLayoutPanelMovieCast.PerformLayout();
            this.tabPageMovieCategory.ResumeLayout(false);
            this.tableLayoutPanelMovieCategory.ResumeLayout(false);
            this.tableLayoutPanelMovieCategory.PerformLayout();
            this.tabPageSaloon.ResumeLayout(false);
            this.tabPageSaloon.PerformLayout();
            this.tabSaloon.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlockCount)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPageMovieSession.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabSession.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovieSession)).EndInit();
            this.groupBoxMovieSessionMovieFormat.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPageUser.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.tabPageDesign.ResumeLayout(false);
            this.tabPageDesign.PerformLayout();
            this.toolStripDesign.ResumeLayout(false);
            this.toolStripDesign.PerformLayout();
            this.menuSeats.ResumeLayout(false);
            this.menuSaloonCreate.ResumeLayout(false);
            this.menuSaloonCreateSeat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMovie;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.TextBox textBoxMovieSearch;
        private System.Windows.Forms.Label labelMovieSearch;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ContextMenuStrip menuMovieType;
        private System.Windows.Forms.ToolStripMenuItem menuMovieTypeNew;
        private System.Windows.Forms.ToolStripMenuItem menuMovieTypeEdit;
        private System.Windows.Forms.ToolStripMenuItem menuMovieTypeDelete;
        private System.Windows.Forms.ToolStripMenuItem menuMovieTypeRefresh;
        private System.Windows.Forms.ContextMenuStrip menuMovieFormat;
        private System.Windows.Forms.ToolStripMenuItem menuMovieFormatRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuMovieFormatNew;
        private System.Windows.Forms.ToolStripMenuItem menuMovieFormatEdit;
        private System.Windows.Forms.ToolStripMenuItem menuMovieFormatDelete;
        private System.Windows.Forms.ContextMenuStrip menuMovieDirector;
        private System.Windows.Forms.ToolStripMenuItem menuMovieDirectorRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuMovieDirectorNew;
        private System.Windows.Forms.ToolStripMenuItem menuMovieDirectorEdit;
        private System.Windows.Forms.ToolStripMenuItem menuMovieDirectorDelete;
        private System.Windows.Forms.ContextMenuStrip menuMovieCast;
        private System.Windows.Forms.ToolStripMenuItem menuMovieCastRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuMovieCastNew;
        private System.Windows.Forms.ToolStripMenuItem menuMovieCastEdit;
        private System.Windows.Forms.ToolStripMenuItem menuMovieCastDelete;
        private System.Windows.Forms.ContextMenuStrip menuMovieCategory;
        private System.Windows.Forms.ToolStripMenuItem menuMovieCategoryRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuMovieCategoryNew;
        private System.Windows.Forms.ToolStripMenuItem menuMovieCategoryEdit;
        private System.Windows.Forms.ToolStripMenuItem menuMovieCategoryDelete;
        private System.Windows.Forms.ContextMenuStrip menuMovieSession;
        private System.Windows.Forms.ToolStripMenuItem menuMovieSessionRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuMovieSessionNew;
        private System.Windows.Forms.ToolStripMenuItem menuMovieSessionEdit;
        private System.Windows.Forms.ToolStripMenuItem menuMovieSessionDelete;
        private System.Windows.Forms.ToolStripSeparator menuMovieSessionSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuMovieSessionAmount;
        private System.Windows.Forms.ToolStripMenuItem menuMovieSessionSaveAs;
        private System.Windows.Forms.ContextMenuStrip menuUser;
        private System.Windows.Forms.ToolStripMenuItem menuUserRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuUserNew;
        private System.Windows.Forms.ToolStripMenuItem menuUserEdit;
        private System.Windows.Forms.ToolStripMenuItem menuUserDelete;
        private System.Windows.Forms.ContextMenuStrip menuSeats;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem standardSeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledSeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleSeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vIPToolStripMenuItem;
        private System.Windows.Forms.TabControl toolStripSaloon;
        private System.Windows.Forms.TabPage tabPageMovie;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieDetails2;
        private System.Windows.Forms.Label labelMovieDescription;
        private System.Windows.Forms.Label labelMovieTitle;
        private System.Windows.Forms.ToolStrip toolStripMovieDetails;
        private System.Windows.Forms.ToolStripButton buttonMovieDetailsNew;
        private System.Windows.Forms.ToolStripButton buttonMovieDetailsSave;
        private System.Windows.Forms.ToolStripButton buttonMovieDetailsDelete;
        private System.Windows.Forms.ToolStripButton buttonMovieDetailsRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMovieStatus;
        private System.Windows.Forms.TextBox textBoxMovieTitle;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DateTimePicker dateTimePickerMovieReleaseDate;
        private System.Windows.Forms.Label labelMovieReleaseDate;
        private System.Windows.Forms.NumericUpDown numericUpDownMovieDuration;
        private System.Windows.Forms.Label labelMovieDuration;
        private System.Windows.Forms.TextBox textBoxMovieDescription;
        private System.Windows.Forms.Label labelMovieSummary;
        private System.Windows.Forms.Label labelMovieStory;
        private System.Windows.Forms.TextBox textBoxMovieSummary;
        private System.Windows.Forms.TextBox textBoxMovieStory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieDetailsPoster;
        private System.Windows.Forms.Button buttonMovieUpdatePosterPreview;
        private System.Windows.Forms.Button buttonMovieUpdatePosterOriginal;
        private System.Windows.Forms.PictureBox pictureBoxMoviePosterPreview;
        private System.Windows.Forms.PictureBox pictureBoxMoviePosterOriginal;
        private System.Windows.Forms.Label labelMoviePosterPreviewLeft;
        private System.Windows.Forms.Label labelMoviePosterPreviewRight;
        private System.Windows.Forms.Label labelMoviePosterOriginalLeft;
        private System.Windows.Forms.Label labelMoviePosterOriginalRight;
        private System.Windows.Forms.TabPage tabPageMovieType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieType;
        private System.Windows.Forms.ListBox listBoxMovieTypeRight;
        private System.Windows.Forms.TextBox textBoxMovieTypeSearch;
        private System.Windows.Forms.Label labelMovieTypeSearch;
        private System.Windows.Forms.ListBox listBoxMovieTypeLeft;
        private System.Windows.Forms.Button buttonMovieTypeRight;
        private System.Windows.Forms.Button buttonMovieTypeLeft;
        private System.Windows.Forms.TabPage tabPageMovieFormat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieFormat;
        private System.Windows.Forms.ListBox listBoxMovieFormatRight;
        private System.Windows.Forms.TextBox textBoxMovieFormatSearch;
        private System.Windows.Forms.Label labelMovieFormatSearch;
        private System.Windows.Forms.ListBox listBoxMovieFormatLeft;
        private System.Windows.Forms.Button buttonMovieFormatRight;
        private System.Windows.Forms.Button buttonMovieFormatLeft;
        private System.Windows.Forms.TabPage tabPageMovieDirector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieDirector;
        private System.Windows.Forms.ListBox listBoxMovieDirectorRight;
        private System.Windows.Forms.TextBox textBoxMovieDirectorSearch;
        private System.Windows.Forms.Label labelMovieDirectorSearch;
        private System.Windows.Forms.ListBox listBoxMovieDirectorLeft;
        private System.Windows.Forms.Button buttonMovieDirectorRight;
        private System.Windows.Forms.Button buttonMovieDirectorLeft;
        private System.Windows.Forms.TabPage tabPageMovieCast;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieCast;
        private System.Windows.Forms.ListBox listBoxMovieCastRight;
        private System.Windows.Forms.TextBox textBoxMovieCastSearch;
        private System.Windows.Forms.Label labelMovieCastSearch;
        private System.Windows.Forms.ListBox listBoxMovieCastLeft;
        private System.Windows.Forms.Button buttonMovieCastRight;
        private System.Windows.Forms.Button buttonMovieCastLeft;
        private System.Windows.Forms.TabPage tabPageMovieCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieCategory;
        private System.Windows.Forms.ListBox listBoxMovieCategoryRight;
        private System.Windows.Forms.TextBox textBoxMovieCategorySearch;
        private System.Windows.Forms.Label labelMovieCategorySearch;
        private System.Windows.Forms.ListBox listBoxMovieCategoryLeft;
        private System.Windows.Forms.Button buttonMovieCategoryRight;
        private System.Windows.Forms.Button buttonMovieCategoryLeft;
        private System.Windows.Forms.TabPage tabPageMovieSession;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewMovieSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theatre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionTime;
        private System.Windows.Forms.DateTimePicker datePickerMovieSession;
        private System.Windows.Forms.Button buttonSessionTimePrev;
        private System.Windows.Forms.Button buttonSessionTimeNext;
        private System.Windows.Forms.GroupBox groupBoxMovieSessionMovieFormat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox listBoxMovieSessionMovieFormatRight;
        private System.Windows.Forms.ListBox listBoxMovieSessionMovieFormatLeft;
        private System.Windows.Forms.Button buttonMovieSessionMovieFormatRight;
        private System.Windows.Forms.Button buttonMovieSessionMovieFormatLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMovieSessionMovieFormatSearch;
        private System.Windows.Forms.TabPage tabPageUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBoxUserSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.TabPage tabPageDesign;
        private Telerik.ReportViewer.WinForms.ReportViewer reportViewerDesign;
        private System.Windows.Forms.ToolStrip toolStripDesign;
        private System.Windows.Forms.ToolStripButton buttonDesignRefresh;
        private System.Windows.Forms.ToolStripButton buttonDesignUpdate;
        private System.Windows.Forms.ToolStripButton buttonDesignExport;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.TabPage tabPageSaloon;
        private System.Windows.Forms.ContextMenuStrip menuSaloonCreate;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddCol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddSep;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddCol1;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddCol5;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddCol10;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddSep1;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddSep5;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddSep10;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddCol20;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddSep20;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeleteRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddRow1;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddRow5;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddRow10;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddRow20;
        private System.Windows.Forms.ContextMenuStrip menuSaloonCreateSeat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCreateSeatDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripAddHall;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbTemp;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnList;
        private System.Windows.Forms.ToolStripButton toolStripBtnClear;
        private System.Windows.Forms.ToolStripButton toolStripBtnRefresh;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
        private System.Windows.Forms.CheckBox chkBlock;
        private System.Windows.Forms.NumericUpDown txtBlockCount;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabSaloon;
        private TabControl tabSession;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private ToolStripMenuItem koltukAdıToolStripMenuItem;
        private Panel panel2;
        private Label label3;
        private TextBox txtTicketTemplate;
    }
}