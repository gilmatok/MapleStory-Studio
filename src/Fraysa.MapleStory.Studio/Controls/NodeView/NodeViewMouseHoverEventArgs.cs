using System;

namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Provides data for the <see cref="NodeViewNodeMouseHover"/> event.
    /// </summary>
    public class NodeViewMouseHoverEventArgs : EventArgs
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewMouseHoverEventArgs"/> class.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> the mouse pointer is currently resting on.</param>
        public NodeViewMouseHoverEventArgs(Node node)
        {
            Node = node;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets the node the mouse pointer is currently resting on.
        /// </summary>
        public Node Node
        {
            get;
            private set;
        }
    }
}