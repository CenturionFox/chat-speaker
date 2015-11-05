namespace Attribute.ChatSpeaker.Controls
{
    partial class SpeakerGridView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel controls;
            this._speakerGrid = new System.Windows.Forms.DataGridView();
            controls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._speakerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // controls
            // 
            controls.Dock = System.Windows.Forms.DockStyle.Bottom;
            controls.Location = new System.Drawing.Point(0, 229);
            controls.Name = "controls";
            controls.Size = new System.Drawing.Size(332, 73);
            controls.TabIndex = 0;
            // 
            // _speakerGrid
            // 
            this._speakerGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this._speakerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._speakerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._speakerGrid.Location = new System.Drawing.Point(0, 0);
            this._speakerGrid.Name = "_speakerGrid";
            this._speakerGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._speakerGrid.RowHeadersVisible = false;
            this._speakerGrid.Size = new System.Drawing.Size(332, 229);
            this._speakerGrid.TabIndex = 1;
            // 
            // SpeakerGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._speakerGrid);
            this.Controls.Add(controls);
            this.Name = "SpeakerGridView";
            this.Size = new System.Drawing.Size(332, 302);
            ((System.ComponentModel.ISupportInitialize)(this._speakerGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView _speakerGrid;
    }
}
