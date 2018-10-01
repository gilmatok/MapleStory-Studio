using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Provides data for the <see cref="NodeView.NodeMouseClick"/> and <see cref="NodeView.NodeMouseDoubleClick"/>
    /// events.
    /// </summary>
    public class NodeViewMouseClickEventArgs : MouseEventArgs
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewMouseClickEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node that was clicked.</param>
        /// <param name="button">One of the <see cref="MouseButtons"/> members.</param>
        /// <param name="clicks">The number of clicks that occurred.</param>
        /// <param name="x">The x-coordinate where the click occurred.</param>
        /// <param name="y">The y-coordinate where the click occurred.</param>
        public NodeViewMouseClickEventArgs(Node node, MouseButtons button, int clicks, int x, int y)
            : base(button, clicks, x, y, 0)
        {
            Node = node;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets the node that was clicked.
        /// </summary>
        public Node Node
        {
            get;
            private set;
        }
    }
}