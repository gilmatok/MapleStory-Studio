namespace Fraysa.MapleStory.Studio.Editors
{
    partial class ExternalEditor
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
            this._btOpenExternal = new System.Windows.Forms.Button();
            this._lbInformation = new System.Windows.Forms.Label();
            this._pbBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._pbBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // _btOpenExternal
            // 
            this._btOpenExternal.Dock = System.Windows.Forms.DockStyle.Top;
            this._btOpenExternal.Location = new System.Drawing.Point(8, 46);
            this._btOpenExternal.MaximumSize = new System.Drawing.Size(100, 1000000);
            this._btOpenExternal.Name = "_btOpenExternal";
            this._btOpenExternal.Size = new System.Drawing.Size(100, 23);
            this._btOpenExternal.TabIndex = 5;
            this._btOpenExternal.Text = "Open Externally";
            this._btOpenExternal.UseVisualStyleBackColor = true;
            this._btOpenExternal.Click += new System.EventHandler(this._btOpenExternal_Click);
            // 
            // _lbInformation
            // 
            this._lbInformation.AutoEllipsis = true;
            this._lbInformation.AutoSize = true;
            this._lbInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this._lbInformation.Location = new System.Drawing.Point(8, 8);
            this._lbInformation.Margin = new System.Windows.Forms.Padding(0);
            this._lbInformation.MaximumSize = new System.Drawing.Size(624, 1000000);
            this._lbInformation.Name = "_lbInformation";
            this._lbInformation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this._lbInformation.Size = new System.Drawing.Size(623, 38);
            this._lbInformation.TabIndex = 4;
            this._lbInformation.Text = "No internal editor exists yet to display the contents of this file, but you can t" +
    "ry to open it with your associated external program.";
            // 
            // _pbBackground
            // 
            this._pbBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._pbBackground.Location = new System.Drawing.Point(315, 212);
            this._pbBackground.Name = "_pbBackground";
            this._pbBackground.Size = new System.Drawing.Size(325, 268);
            this._pbBackground.TabIndex = 6;
            this._pbBackground.TabStop = false;
            // 
            // ExternalEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this._btOpenExternal);
            this.Controls.Add(this._lbInformation);
            this.Controls.Add(this._pbBackground);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ExternalEditor";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(644, 484);
            this.ClientSizeChanged += new System.EventHandler(this.ExternalEditor_ClientSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this._pbBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btOpenExternal;
        private System.Windows.Forms.Label _lbInformation;
        private System.Windows.Forms.PictureBox _pbBackground;
    }
}
