namespace Fraysa.MapleStory.Studio.Editors
{
    partial class TextEditor
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
            this._lbInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this._lbInformation.Size = new System.Drawing.Size(38, 23);
            this._lbInformation.TabIndex = 5;
            this._lbInformation.Text = "Value.";
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this._lbInformation);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TextEditor";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(644, 484);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lbInformation;
    }
}
