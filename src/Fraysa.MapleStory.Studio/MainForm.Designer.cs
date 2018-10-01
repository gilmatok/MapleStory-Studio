namespace Fraysa.MapleStory.Studio
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._tsMain = new System.Windows.Forms.ToolStrip();
            this._tsdbMainApp = new System.Windows.Forms.ToolStripDropDownButton();
            this._tsmiMainAppOpen = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiMainAppGames = new System.Windows.Forms.ToolStripMenuItem();
            this._tssMainApp1 = new System.Windows.Forms.ToolStripSeparator();
            this._tsmiMainSettings = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiMainAppAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiMainAppExit = new System.Windows.Forms.ToolStripMenuItem();
            this._tssMain1 = new System.Windows.Forms.ToolStripSeparator();
            this._tsbtMainStart = new System.Windows.Forms.ToolStripButton();
            this._tsbtMainStop = new System.Windows.Forms.ToolStripButton();
            this._tsbtMainSearch = new System.Windows.Forms.ToolStripButton();
            this._tssMain2 = new System.Windows.Forms.ToolStripSeparator();
            this._tsbtMainBackward = new System.Windows.Forms.ToolStripButton();
            this._tsbtMainForward = new System.Windows.Forms.ToolStripButton();
            this._tstbAddress = new Fraysa.MapleStory.Studio.Controls.ToolStripModernTextBox();
            this._tssbMainFavorites = new System.Windows.Forms.ToolStripSplitButton();
            this._ofdProject = new System.Windows.Forms.OpenFileDialog();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this._tvProject = new Fraysa.MapleStory.Studio.Nodes.ProjectNodeView();
            this._editorContainer = new Fraysa.MapleStory.Studio.Editors.EditorContainer();
            this._pnMain = new System.Windows.Forms.Panel();
            this._pnEditor = new System.Windows.Forms.Panel();
            this._splitterTreeContent = new Fraysa.MapleStory.Studio.Controls.ModernSplitter();
            this._pnProject = new System.Windows.Forms.Panel();
            this._tsProject = new System.Windows.Forms.ToolStrip();
            this._tstbProjectSearch = new System.Windows.Forms.ToolStripTextBox();
            this._tsbtProjectFilter = new System.Windows.Forms.ToolStripButton();
            this._tsMain.SuspendLayout();
            this._pnMain.SuspendLayout();
            this._pnEditor.SuspendLayout();
            this._pnProject.SuspendLayout();
            this._tsProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tsMain
            // 
            this._tsMain.CanOverflow = false;
            this._tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsdbMainApp,
            this._tssMain1,
            this._tsbtMainStart,
            this._tsbtMainStop,
            this._tsbtMainSearch,
            this._tssMain2,
            this._tsbtMainBackward,
            this._tsbtMainForward,
            this._tstbAddress,
            this._tssbMainFavorites});
            this._tsMain.Location = new System.Drawing.Point(0, 0);
            this._tsMain.Margin = new System.Windows.Forms.Padding(6);
            this._tsMain.Name = "_tsMain";
            this._tsMain.Padding = new System.Windows.Forms.Padding(6);
            this._tsMain.Size = new System.Drawing.Size(784, 35);
            this._tsMain.TabIndex = 0;
            // 
            // _tsdbMainApp
            // 
            this._tsdbMainApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsdbMainApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiMainAppOpen,
            this._tsmiMainAppGames,
            this._tssMainApp1,
            this._tsmiMainSettings,
            this._tsmiMainAppAbout,
            this._tsmiMainAppExit});
            this._tsdbMainApp.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.AppButton;
            this._tsdbMainApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsdbMainApp.Margin = new System.Windows.Forms.Padding(0);
            this._tsdbMainApp.Name = "_tsdbMainApp";
            this._tsdbMainApp.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this._tsdbMainApp.ShowDropDownArrow = false;
            this._tsdbMainApp.Size = new System.Drawing.Size(23, 23);
            this._tsdbMainApp.Text = "Open Game...";
            // 
            // _tsmiMainAppOpen
            // 
            this._tsmiMainAppOpen.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.OpenFolder;
            this._tsmiMainAppOpen.Name = "_tsmiMainAppOpen";
            this._tsmiMainAppOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._tsmiMainAppOpen.Size = new System.Drawing.Size(226, 22);
            this._tsmiMainAppOpen.Text = "&Open Game...";
            this._tsmiMainAppOpen.Click += new System.EventHandler(this._tsdbMainApp_ButtonClick);
            // 
            // _tsmiMainAppGames
            // 
            this._tsmiMainAppGames.Name = "_tsmiMainAppGames";
            this._tsmiMainAppGames.Size = new System.Drawing.Size(226, 22);
            this._tsmiMainAppGames.Text = "Recent Games";
            this._tsmiMainAppGames.Visible = false;
            this._tsmiMainAppGames.DropDownOpening += new System.EventHandler(this._tsmiMainAppGames_DropDownOpening);
            // 
            // _tssMainApp1
            // 
            this._tssMainApp1.Name = "_tssMainApp1";
            this._tssMainApp1.Size = new System.Drawing.Size(223, 6);
            // 
            // _tsmiMainSettings
            // 
            this._tsmiMainSettings.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.settings;
            this._tsmiMainSettings.Name = "_tsmiMainSettings";
            this._tsmiMainSettings.Size = new System.Drawing.Size(226, 22);
            this._tsmiMainSettings.Text = "Settings";
            this._tsmiMainSettings.Click += new System.EventHandler(this._tsmiMainSettings_Click);
            // 
            // _tsmiMainAppAbout
            // 
            this._tsmiMainAppAbout.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.About;
            this._tsmiMainAppAbout.Name = "_tsmiMainAppAbout";
            this._tsmiMainAppAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this._tsmiMainAppAbout.Size = new System.Drawing.Size(226, 22);
            this._tsmiMainAppAbout.Text = "&About MapleStory Studio";
            this._tsmiMainAppAbout.Click += new System.EventHandler(this._tsmiMainAppAbout_Click);
            // 
            // _tsmiMainAppExit
            // 
            this._tsmiMainAppExit.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.Exit;
            this._tsmiMainAppExit.Name = "_tsmiMainAppExit";
            this._tsmiMainAppExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._tsmiMainAppExit.Size = new System.Drawing.Size(226, 22);
            this._tsmiMainAppExit.Text = "Exit";
            this._tsmiMainAppExit.Click += new System.EventHandler(this._tsmiMainAppExit_Click);
            // 
            // _tssMain1
            // 
            this._tssMain1.Name = "_tssMain1";
            this._tssMain1.Size = new System.Drawing.Size(6, 23);
            // 
            // _tsbtMainStart
            // 
            this._tsbtMainStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbtMainStart.Enabled = false;
            this._tsbtMainStart.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.Start;
            this._tsbtMainStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbtMainStart.Margin = new System.Windows.Forms.Padding(0);
            this._tsbtMainStart.Name = "_tsbtMainStart";
            this._tsbtMainStart.Size = new System.Drawing.Size(23, 23);
            this._tsbtMainStart.Text = "Start Game";
            this._tsbtMainStart.Click += new System.EventHandler(this._tsbtMainStart_Click);
            // 
            // _tsbtMainStop
            // 
            this._tsbtMainStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbtMainStop.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.Stop;
            this._tsbtMainStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbtMainStop.Margin = new System.Windows.Forms.Padding(0);
            this._tsbtMainStop.Name = "_tsbtMainStop";
            this._tsbtMainStop.Size = new System.Drawing.Size(23, 23);
            this._tsbtMainStop.Text = "Kill Game";
            this._tsbtMainStop.Click += new System.EventHandler(this._tsbtMainStop_Click);
            // 
            // _tsbtMainSearch
            // 
            this._tsbtMainSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbtMainSearch.Enabled = false;
            this._tsbtMainSearch.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.Search;
            this._tsbtMainSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbtMainSearch.Margin = new System.Windows.Forms.Padding(0);
            this._tsbtMainSearch.Name = "_tsbtMainSearch";
            this._tsbtMainSearch.Size = new System.Drawing.Size(23, 23);
            this._tsbtMainSearch.Text = "Search...";
            this._tsbtMainSearch.Visible = false;
            this._tsbtMainSearch.Click += new System.EventHandler(this._tsbtMainSearch_Click);
            // 
            // _tssMain2
            // 
            this._tssMain2.Name = "_tssMain2";
            this._tssMain2.Size = new System.Drawing.Size(6, 23);
            // 
            // _tsbtMainBackward
            // 
            this._tsbtMainBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbtMainBackward.Enabled = false;
            this._tsbtMainBackward.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.Backward;
            this._tsbtMainBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbtMainBackward.Margin = new System.Windows.Forms.Padding(0);
            this._tsbtMainBackward.Name = "_tsbtMainBackward";
            this._tsbtMainBackward.Size = new System.Drawing.Size(23, 23);
            this._tsbtMainBackward.Text = "Backward";
            this._tsbtMainBackward.Click += new System.EventHandler(this._tsbtMainBackward_Click);
            // 
            // _tsbtMainForward
            // 
            this._tsbtMainForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbtMainForward.Enabled = false;
            this._tsbtMainForward.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.Forward;
            this._tsbtMainForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsbtMainForward.Margin = new System.Windows.Forms.Padding(0);
            this._tsbtMainForward.Name = "_tsbtMainForward";
            this._tsbtMainForward.Size = new System.Drawing.Size(23, 23);
            this._tsbtMainForward.Text = "Forward";
            this._tsbtMainForward.Click += new System.EventHandler(this._tsbtMainForward_Click);
            // 
            // _tstbAddress
            // 
            this._tstbAddress.AcceptsReturn = true;
            this._tstbAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this._tstbAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this._tstbAddress.AutoSize = false;
            this._tstbAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this._tstbAddress.Enabled = false;
            this._tstbAddress.Margin = new System.Windows.Forms.Padding(0);
            this._tstbAddress.Name = "_tstbAddress";
            this._tstbAddress.Size = new System.Drawing.Size(100, 23);
            this._tstbAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this._tstbAddress_KeyDown);
            this._tstbAddress.TextChanged += new System.EventHandler(this._tstbAddress_TextChanged);
            // 
            // _tssbMainFavorites
            // 
            this._tssbMainFavorites.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._tssbMainFavorites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tssbMainFavorites.Enabled = false;
            this._tssbMainFavorites.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.FavoriteNo;
            this._tssbMainFavorites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tssbMainFavorites.Margin = new System.Windows.Forms.Padding(0);
            this._tssbMainFavorites.Name = "_tssbMainFavorites";
            this._tssbMainFavorites.Size = new System.Drawing.Size(32, 23);
            this._tssbMainFavorites.Text = "Add To Favorites";
            this._tssbMainFavorites.ButtonClick += new System.EventHandler(this._tssbMainFavorites_ButtonClick);
            this._tssbMainFavorites.DropDownOpening += new System.EventHandler(this._tssbMainFavorites_DropDownOpening);
            // 
            // _ofdProject
            // 
            this._ofdProject.Filter = "MapleStory Executables|MapleStory.exe|All Executables|*.exe|All Files|*.*";
            this._ofdProject.Title = "Open Game";
            this._ofdProject.FileOk += new System.ComponentModel.CancelEventHandler(this._ofdProject_FileOk);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // _tvProject
            // 
            this._tvProject.BackColor = System.Drawing.Color.WhiteSmoke;
            this._tvProject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tvProject.ImageIndex = 0;
            this._tvProject.Location = new System.Drawing.Point(1, 1);
            this._tvProject.Name = "_tvProject";
            this._tvProject.SelectedImageIndex = 0;
            this._tvProject.Size = new System.Drawing.Size(198, 518);
            this._tvProject.TabIndex = 1;
            this._tvProject.Navigated += new System.EventHandler(this._tvProject_Navigated);
            // 
            // _editorContainer
            // 
            this._editorContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._editorContainer.ItemSize = new System.Drawing.Size(0, 21);
            this._editorContainer.Location = new System.Drawing.Point(6, 0);
            this._editorContainer.Name = "_editorContainer";
            this._editorContainer.SelectedIndex = 0;
            this._editorContainer.Size = new System.Drawing.Size(568, 521);
            this._editorContainer.TabIndex = 2;
            this._editorContainer.Visible = false;
            // 
            // _pnMain
            // 
            this._pnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnMain.Controls.Add(this._pnEditor);
            this._pnMain.Controls.Add(this._pnProject);
            this._pnMain.Location = new System.Drawing.Point(6, 35);
            this._pnMain.Margin = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this._pnMain.Name = "_pnMain";
            this._pnMain.Size = new System.Drawing.Size(772, 520);
            this._pnMain.TabIndex = 4;
            // 
            // _pnEditor
            // 
            this._pnEditor.Controls.Add(this._splitterTreeContent);
            this._pnEditor.Controls.Add(this._editorContainer);
            this._pnEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnEditor.Location = new System.Drawing.Point(200, 0);
            this._pnEditor.Name = "_pnEditor";
            this._pnEditor.Size = new System.Drawing.Size(572, 520);
            this._pnEditor.TabIndex = 4;
            // 
            // _splitterTreeContent
            // 
            this._splitterTreeContent.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this._splitterTreeContent.Location = new System.Drawing.Point(0, 0);
            this._splitterTreeContent.Name = "_splitterTreeContent";
            this._splitterTreeContent.Size = new System.Drawing.Size(6, 520);
            this._splitterTreeContent.TabIndex = 2;
            this._splitterTreeContent.TabStop = false;
            // 
            // _pnProject
            // 
            this._pnProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            this._pnProject.Controls.Add(this._tsProject);
            this._pnProject.Controls.Add(this._tvProject);
            this._pnProject.Dock = System.Windows.Forms.DockStyle.Left;
            this._pnProject.Location = new System.Drawing.Point(0, 0);
            this._pnProject.Name = "_pnProject";
            this._pnProject.Padding = new System.Windows.Forms.Padding(1);
            this._pnProject.Size = new System.Drawing.Size(200, 520);
            this._pnProject.TabIndex = 0;
            this._pnProject.SizeChanged += new System.EventHandler(this._pnProject_SizeChanged);
            // 
            // _tsProject
            // 
            this._tsProject.CanOverflow = false;
            this._tsProject.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._tsProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tstbProjectSearch,
            this._tsbtProjectFilter});
            this._tsProject.Location = new System.Drawing.Point(1, 1);
            this._tsProject.Name = "_tsProject";
            this._tsProject.Padding = new System.Windows.Forms.Padding(2);
            this._tsProject.Size = new System.Drawing.Size(198, 27);
            this._tsProject.TabIndex = 2;
            this._tsProject.Visible = false;
            // 
            // _tstbProjectSearch
            // 
            this._tstbProjectSearch.Name = "_tstbProjectSearch";
            this._tstbProjectSearch.Size = new System.Drawing.Size(100, 23);
            // 
            // _tsbtProjectFilter
            // 
            this._tsbtProjectFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsbtProjectFilter.Enabled = false;
            this._tsbtProjectFilter.Image = ((System.Drawing.Image)(resources.GetObject("_tsbtProjectFilter.Image")));
            this._tsbtProjectFilter.Margin = new System.Windows.Forms.Padding(0);
            this._tsbtProjectFilter.Name = "_tsbtProjectFilter";
            this._tsbtProjectFilter.Size = new System.Drawing.Size(23, 23);
            this._tsbtProjectFilter.Text = "Filter";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._pnMain);
            this.Controls.Add(this._tsMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MapleStory Studio";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this._tsMain.ResumeLayout(false);
            this._tsMain.PerformLayout();
            this._pnMain.ResumeLayout(false);
            this._pnEditor.ResumeLayout(false);
            this._pnProject.ResumeLayout(false);
            this._pnProject.PerformLayout();
            this._tsProject.ResumeLayout(false);
            this._tsProject.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _tsMain;
        private System.Windows.Forms.ToolStripDropDownButton _tsdbMainApp;
        private System.Windows.Forms.ToolStripMenuItem _tsmiMainAppOpen;
        private System.Windows.Forms.ToolStripMenuItem _tsmiMainAppGames;
        private System.Windows.Forms.ToolStripSeparator _tssMainApp1;
        private System.Windows.Forms.ToolStripMenuItem _tsmiMainAppAbout;
        private System.Windows.Forms.ToolStripMenuItem _tsmiMainAppExit;
        private System.Windows.Forms.ToolStripSeparator _tssMain1;
        private System.Windows.Forms.ToolStripButton _tsbtMainStart;
        private System.Windows.Forms.ToolStripButton _tsbtMainStop;
        private System.Windows.Forms.ToolStripButton _tsbtMainSearch;
        private System.Windows.Forms.ToolStripSeparator _tssMain2;
        private System.Windows.Forms.ToolStripButton _tsbtMainBackward;
        private System.Windows.Forms.ToolStripButton _tsbtMainForward;
        private Controls.ToolStripModernTextBox _tstbAddress;
        private System.Windows.Forms.ToolStripSplitButton _tssbMainFavorites;
        private System.Windows.Forms.OpenFileDialog _ofdProject;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private Nodes.ProjectNodeView _tvProject;
        private Editors.EditorContainer _editorContainer;
        private System.Windows.Forms.Panel _pnMain;
        private System.Windows.Forms.Panel _pnEditor;
        private System.Windows.Forms.Panel _pnProject;
        private System.Windows.Forms.ToolStrip _tsProject;
        private System.Windows.Forms.ToolStripButton _tsbtProjectFilter;
        private Controls.ModernSplitter _splitterTreeContent;
        private System.Windows.Forms.ToolStripTextBox _tstbProjectSearch;
        private System.Windows.Forms.ToolStripMenuItem _tsmiMainSettings;
    }
}

