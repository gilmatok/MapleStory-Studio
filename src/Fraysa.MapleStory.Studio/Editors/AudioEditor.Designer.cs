namespace Fraysa.MapleStory.Studio.Editors
{
    partial class AudioEditor
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
            this._btPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btPlay
            // 
            this._btPlay.Location = new System.Drawing.Point(11, 11);
            this._btPlay.Name = "_btPlay";
            this._btPlay.Size = new System.Drawing.Size(75, 23);
            this._btPlay.TabIndex = 0;
            this._btPlay.Text = "Play";
            this._btPlay.UseVisualStyleBackColor = true;
            this._btPlay.Click += new System.EventHandler(this._btPlay_Click);
            // 
            // AudioEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this._btPlay);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "AudioEditor";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(642, 482);
            this.Load += new System.EventHandler(this.AudioEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btPlay;
    }
}
