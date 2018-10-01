using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls
{
    /// <summary>
    /// Represents a <see cref="TextBox"/> with a Visual Studio-like border.
    /// </summary>
    public partial class ModernTextBox : Panel
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ModernTextBox"/> class.
        /// </summary>
        public ModernTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            TextBox = new TextBox()
            {
                BorderStyle = BorderStyle.None
            };
            Controls.Add(TextBox);
        }

        // ---- EVENTS -------------------------------------------------------------------------------------------------

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        public new event KeyEventHandler KeyDown
        {
            add
            {
                TextBox.KeyDown += value;
            }
            remove
            {
                TextBox.KeyDown -= value;
            }
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                return TextBox.ForeColor;
            }
            set
            {
                TextBox.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets the inner <see cref="TextBox"/>.
        /// </summary>
        internal TextBox TextBox
        {
            get;
            private set;
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Raises the <see cref="BackColorChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            TextBox.BackColor = BackColor;
        }

        /// <summary>
        /// Raises the <see cref="ClientSizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnClientSizeChanged(EventArgs e)
        {
            TextBox.Location = new Point(3, 3);
            TextBox.Width = ClientSize.Width - 6;
        }

        /// <summary>
        /// Raises the <see cref="EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs" /> that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (Enabled)
            {
                BackColor = SystemColors.Window;
                ForeColor = Color.Empty;
            }
            else
            {
                BackColor = Color.FromArgb(238, 238, 242);
                ForeColor = Color.FromArgb(162, 164, 165);
            }
        }

        /// <summary>
        /// Raises the <see cref="GotFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            TextBox.Focus();
        }

        /// <summary>
        /// Raises the <see cref="Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(204, 206, 219));

            Rectangle innerRectangle = ClientRectangle;
            innerRectangle.Inflate(-1, -1);
            using (SolidBrush innerBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(innerBrush, innerRectangle);
            }
        }
    }
}
