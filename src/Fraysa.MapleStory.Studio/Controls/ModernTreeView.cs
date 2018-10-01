using System;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls
{
    /// <summary>
    /// Represents a <see cref="TreeView"/> using modern visual styles and effects if supported.
    /// </summary>
    public class ModernTreeView : TreeView
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ModernTreeView"/> class.
        /// </summary>
        public ModernTreeView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint,
                true);
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the control creation parameters.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;

                // Only apply other effects on Windows Vista and newer.
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    createParams.Style |= 0x8000;
                }

                return createParams;
            }
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Raises the <see cref="HandleCreated"/> event.
        /// </summary>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            NativeMethods.ApplyVisualStyles(this);

            // Extended styles are supported since Windows Vista.
            if (Environment.OSVersion.Version.Major >= 6)
            {
                // Get the current extended style with lParam.
                IntPtr lParam = NativeMethods.SendWindowsMessage(Handle, 0x112d, IntPtr.Zero, IntPtr.Zero);

                // Merge current style with new style and set it.
                IntPtr style = new IntPtr(lParam.ToInt32()
                    | (int)(NativeMethods.TreeViewStyleExtended.DoubleBuffer
                    | NativeMethods.TreeViewStyleExtended.AutoHScroll
                    | NativeMethods.TreeViewStyleExtended.FadeInOutExpandos));
                NativeMethods.SendWindowsMessage(Handle, 0x112c, IntPtr.Zero, style);
            }

            base.OnHandleCreated(e);
        }

        /// <summary>
        /// Raises the Paint event.
        /// </summary>
        /// <param name="e">The PaintEventArgs.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (e != null)
            {
                // Send windows message to draw the control
                Message msg = new Message();
                msg.HWnd = Handle;
                msg.Msg = (int)NativeMethods.WindowsMessage.PrintClient;
                msg.WParam = e.Graphics.GetHdc();
                msg.LParam = (IntPtr)NativeMethods.PrintFlags.Client;
                DefWndProc(ref msg);

                e.Graphics.ReleaseHdc(msg.WParam);
            }

            base.OnPaint(e);
        }
    }
}
