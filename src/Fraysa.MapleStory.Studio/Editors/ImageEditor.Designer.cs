namespace Fraysa.MapleStory.Studio.Editors
{
    partial class ImageEditor
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
            this._pbImage = new System.Windows.Forms.PictureBox();
            this._pnScroll = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).BeginInit();
            this._pnScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pbImage
            // 
            this._pbImage.Location = new System.Drawing.Point(0, 0);
            this._pbImage.Name = "_pbImage";
            this._pbImage.Size = new System.Drawing.Size(0, 0);
            this._pbImage.TabIndex = 0;
            this._pbImage.TabStop = false;
            // 
            // _pnScroll
            // 
            this._pnScroll.AutoScroll = true;
            this._pnScroll.Controls.Add(this._pbImage);
            this._pnScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnScroll.Location = new System.Drawing.Point(0, 0);
            this._pnScroll.Name = "_pnScroll";
            this._pnScroll.Size = new System.Drawing.Size(644, 484);
            this._pnScroll.TabIndex = 2;
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this._pnScroll);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ImageEditor";
            this.Size = new System.Drawing.Size(644, 484);
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).EndInit();
            this._pnScroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pbImage;
        private System.Windows.Forms.Panel _pnScroll;
    }
}
