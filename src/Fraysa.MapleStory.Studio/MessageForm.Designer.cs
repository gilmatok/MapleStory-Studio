namespace Fraysa.MapleStory.Studio
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this._pbIcon = new System.Windows.Forms.PictureBox();
            this._lbMessage = new System.Windows.Forms.Label();
            this._flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // _pbIcon
            // 
            this._pbIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._pbIcon.Image = global::Fraysa.MapleStory.Studio.Properties.Resources.MsgIconInformation;
            this._pbIcon.Location = new System.Drawing.Point(12, 0);
            this._pbIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this._pbIcon.Name = "_pbIcon";
            this._pbIcon.Size = new System.Drawing.Size(64, 64);
            this._pbIcon.TabIndex = 6;
            this._pbIcon.TabStop = false;
            // 
            // _lbMessage
            // 
            this._lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lbMessage.AutoSize = true;
            this._lbMessage.Location = new System.Drawing.Point(82, 10);
            this._lbMessage.Margin = new System.Windows.Forms.Padding(3, 0, 6, 6);
            this._lbMessage.MaximumSize = new System.Drawing.Size(750, 750);
            this._lbMessage.Name = "_lbMessage";
            this._lbMessage.Size = new System.Drawing.Size(56, 15);
            this._lbMessage.TabIndex = 5;
            this._lbMessage.Text = "Message.";
            // 
            // _flpButtons
            // 
            this._flpButtons.AutoSize = true;
            this._flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._flpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this._flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._flpButtons.Location = new System.Drawing.Point(0, 87);
            this._flpButtons.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this._flpButtons.Name = "_flpButtons";
            this._flpButtons.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this._flpButtons.Size = new System.Drawing.Size(384, 20);
            this._flpButtons.TabIndex = 4;
            this._flpButtons.Paint += new System.Windows.Forms.PaintEventHandler(this._flpButtons_Paint);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 107);
            this.Controls.Add(this._pbIcon);
            this.Controls.Add(this._lbMessage);
            this.Controls.Add(this._flpButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 146);
            this.Name = "MessageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MapleStory Studio";
            ((System.ComponentModel.ISupportInitialize)(this._pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pbIcon;
        private System.Windows.Forms.Label _lbMessage;
        private System.Windows.Forms.FlowLayoutPanel _flpButtons;
    }
}