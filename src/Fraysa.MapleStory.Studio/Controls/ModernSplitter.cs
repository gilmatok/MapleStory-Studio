using System.Drawing;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls
{
    /// <summary>
    /// Splitter with immediate update while dragging.
    /// </summary>
    [ToolboxBitmap(typeof(Splitter))]
    public class ModernSplitter : Splitter
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ModernSplitter" /> class.
        /// </summary>
        public ModernSplitter()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Raises the <see cref="SplitterMoving"/> event.
        /// </summary>
        /// <param name="sevent">The <see cref="SplitterEventArgs"/>.</param>
        protected override void OnSplitterMoving(SplitterEventArgs sevent)
        {
            if (DesignMode)
            {
                base.OnSplitterMoving(sevent);
            }
            else
            {
                if (sevent != null)
                {
                    if (Width > Height)
                    {
                        if (Dock == DockStyle.Top)
                        {
                            // Move vertically
                            SplitPosition = sevent.SplitY;
                        }
                        else
                        {
                            // Move horizontally
                            // TODO: How to calculate the coordinates?
                            base.OnSplitterMoving(sevent);
                        }
                    }
                    else
                    {
                        if (Dock == DockStyle.Left)
                        {
                            // Move horizontally
                            SplitPosition = sevent.SplitX;
                        }
                        else
                        {
                            // Move vertically
                            // TODO: How to calculate the coordinates?
                            base.OnSplitterMoving(sevent);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="SplitterMoved"/> event.
        /// </summary>
        /// <param name="sevent">The <see cref="SplitterEventArgs"/>.</param>
        protected override void OnSplitterMoved(SplitterEventArgs sevent)
        {
            // Do not raise the event to prevent the splitter position to be set wrong.
            if (DesignMode)
            {
                base.OnSplitterMoved(sevent);
            }
        }
    }
}
