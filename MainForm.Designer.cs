namespace Attribute.ChatSpeaker
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.Windows.Forms.ToolStripSeparator fileMenuSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._logPathFileWatcher = new System.IO.FileSystemWatcher();
            this._logOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._mainFormStatusStrip = new System.Windows.Forms.StatusStrip();
            this._mainFormToolStrip = new System.Windows.Forms.ToolStrip();
            this._fileMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this._exitButtonFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._mainFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._controlPanel = new System.Windows.Forms.Panel();
            this._settingsPanel = new System.Windows.Forms.Panel();
            this._mainPanel = new System.Windows.Forms.Panel();
            this._registeredSpeakerPanel = new System.Windows.Forms.Panel();
            this._gridPanel = new System.Windows.Forms.Panel();
            this._speakerSettingsPanel = new System.Windows.Forms.Panel();
            this._editMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            fileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this._logPathFileWatcher)).BeginInit();
            this._mainFormToolStrip.SuspendLayout();
            this._controlPanel.SuspendLayout();
            this._registeredSpeakerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileMenuSeparator1
            // 
            fileMenuSeparator1.Name = "fileMenuSeparator1";
            fileMenuSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // _logPathFileWatcher
            // 
            this._logPathFileWatcher.EnableRaisingEvents = true;
            this._logPathFileWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this._logPathFileWatcher.SynchronizingObject = this;
            // 
            // _mainFormStatusStrip
            // 
            this._mainFormStatusStrip.Location = new System.Drawing.Point(0, 508);
            this._mainFormStatusStrip.Name = "_mainFormStatusStrip";
            this._mainFormStatusStrip.Size = new System.Drawing.Size(905, 22);
            this._mainFormStatusStrip.TabIndex = 0;
            // 
            // _mainFormToolStrip
            // 
            this._mainFormToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenuButton,
            this._editMenuButton});
            this._mainFormToolStrip.Location = new System.Drawing.Point(0, 0);
            this._mainFormToolStrip.Name = "_mainFormToolStrip";
            this._mainFormToolStrip.Size = new System.Drawing.Size(905, 25);
            this._mainFormToolStrip.TabIndex = 1;
            // 
            // _fileMenuButton
            // 
            this._fileMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._fileMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileMenuSeparator1,
            this._exitButtonFileMenu});
            this._fileMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("_fileMenuButton.Image")));
            this._fileMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._fileMenuButton.Name = "_fileMenuButton";
            this._fileMenuButton.Size = new System.Drawing.Size(38, 22);
            this._fileMenuButton.Text = "&File";
            // 
            // _exitButtonFileMenu
            // 
            this._exitButtonFileMenu.Name = "_exitButtonFileMenu";
            this._exitButtonFileMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._exitButtonFileMenu.Size = new System.Drawing.Size(152, 22);
            this._exitButtonFileMenu.Text = "E&xit";
            this._exitButtonFileMenu.Click += new System.EventHandler(this._exitButtonFileMenu_Click);
            // 
            // _controlPanel
            // 
            this._controlPanel.BackColor = System.Drawing.SystemColors.Control;
            this._controlPanel.Controls.Add(this._settingsPanel);
            this._controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._controlPanel.Location = new System.Drawing.Point(0, 25);
            this._controlPanel.Name = "_controlPanel";
            this._controlPanel.Size = new System.Drawing.Size(266, 483);
            this._controlPanel.TabIndex = 2;
            // 
            // _settingsPanel
            // 
            this._settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._settingsPanel.BackColor = System.Drawing.SystemColors.Control;
            this._settingsPanel.Location = new System.Drawing.Point(0, 322);
            this._settingsPanel.Name = "_settingsPanel";
            this._settingsPanel.Size = new System.Drawing.Size(266, 161);
            this._settingsPanel.TabIndex = 0;
            // 
            // _mainPanel
            // 
            this._mainPanel.BackColor = System.Drawing.SystemColors.Control;
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(266, 25);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(639, 483);
            this._mainPanel.TabIndex = 3;
            // 
            // _registeredSpeakerPanel
            // 
            this._registeredSpeakerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._registeredSpeakerPanel.BackColor = System.Drawing.SystemColors.Control;
            this._registeredSpeakerPanel.Controls.Add(this._gridPanel);
            this._registeredSpeakerPanel.Controls.Add(this._speakerSettingsPanel);
            this._registeredSpeakerPanel.Location = new System.Drawing.Point(0, 25);
            this._registeredSpeakerPanel.Name = "_registeredSpeakerPanel";
            this._registeredSpeakerPanel.Size = new System.Drawing.Size(266, 322);
            this._registeredSpeakerPanel.TabIndex = 0;
            // 
            // _gridPanel
            // 
            this._gridPanel.BackColor = System.Drawing.SystemColors.Control;
            this._gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridPanel.Location = new System.Drawing.Point(0, 0);
            this._gridPanel.Name = "_gridPanel";
            this._gridPanel.Size = new System.Drawing.Size(266, 222);
            this._gridPanel.TabIndex = 1;
            // 
            // _speakerSettingsPanel
            // 
            this._speakerSettingsPanel.BackColor = System.Drawing.SystemColors.Control;
            this._speakerSettingsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._speakerSettingsPanel.Location = new System.Drawing.Point(0, 222);
            this._speakerSettingsPanel.Name = "_speakerSettingsPanel";
            this._speakerSettingsPanel.Size = new System.Drawing.Size(266, 100);
            this._speakerSettingsPanel.TabIndex = 0;
            // 
            // _editMenuButton
            // 
            this._editMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._editMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("_editMenuButton.Image")));
            this._editMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._editMenuButton.Name = "_editMenuButton";
            this._editMenuButton.Size = new System.Drawing.Size(40, 22);
            this._editMenuButton.Text = "&Edit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 530);
            this.Controls.Add(this._mainPanel);
            this.Controls.Add(this._registeredSpeakerPanel);
            this.Controls.Add(this._controlPanel);
            this.Controls.Add(this._mainFormToolStrip);
            this.Controls.Add(this._mainFormStatusStrip);
            this.Name = "MainForm";
            this.Text = "MinecrafTTS";
            ((System.ComponentModel.ISupportInitialize)(this._logPathFileWatcher)).EndInit();
            this._mainFormToolStrip.ResumeLayout(false);
            this._mainFormToolStrip.PerformLayout();
            this._controlPanel.ResumeLayout(false);
            this._registeredSpeakerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher _logPathFileWatcher;
        private System.Windows.Forms.OpenFileDialog _logOpenFileDialog;
        private System.Windows.Forms.ToolStrip _mainFormToolStrip;
        private System.Windows.Forms.StatusStrip _mainFormStatusStrip;
        private System.Windows.Forms.Panel _mainPanel;
        private System.Windows.Forms.Panel _controlPanel;
        private System.Windows.Forms.ToolTip _mainFormToolTip;
        private System.Windows.Forms.Panel _registeredSpeakerPanel;
        private System.Windows.Forms.Panel _settingsPanel;
        private System.Windows.Forms.Panel _gridPanel;
        private System.Windows.Forms.Panel _speakerSettingsPanel;
        private System.Windows.Forms.ToolStripDropDownButton _fileMenuButton;
        private System.Windows.Forms.ToolStripMenuItem _exitButtonFileMenu;
        private System.Windows.Forms.ToolStripDropDownButton _editMenuButton;
    }
}

