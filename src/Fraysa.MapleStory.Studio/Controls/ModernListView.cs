using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls
{
    /// <summary>
    /// Represents a list view supporting more visual style elements.
    /// </summary>
    public class ModernListView : ListView
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        private const int WM_CREATE = 0x01;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ModernListView"/> class.
        /// </summary>
        public ModernListView()
        {
            // Enables the transparent blue rubber box.
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Raises the <see cref="ClientSizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);

            // Automatically make the first column take the remaining space.
            int remainingWidth = ClientSize.Width;
            for (int i = 1; i < Columns.Count; i++)
            {
                remainingWidth -= Columns[i].Width;
            }
            Columns[0].Width = remainingWidth;
        }

        /// <summary>
        /// Overrides <see cref="WndProc(Message)"/>.
        /// </summary>
        /// <param name="m">The Windows <see cref="Message"/> to process.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CREATE)
            {
                // Enables modern selection highlights.
                SetWindowTheme(Handle, "Explorer", null);
            }
            base.WndProc(ref m);
        }
        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
    }
}
