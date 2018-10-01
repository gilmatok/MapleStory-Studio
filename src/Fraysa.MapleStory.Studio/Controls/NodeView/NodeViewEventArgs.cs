using System;

namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Provides data for the <see cref="NodeView.AfterCheck"/>, <see cref="NodeView.AfterCollapse"/>,
    /// <see cref="NodeView.AfterExpand"/>, or <see cref="NodeView.AfterSelect"/> events of a <see cref="NodeView"/> control.
    /// </summary>
    public class NodeViewEventArgs : EventArgs
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewEventArgs"/> class for the specified tree node.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that the event is responding to.</param>
        public NodeViewEventArgs(Node node)
        {
            Node = node;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewEventArgs"/> class for the specified tree node and with
        /// the specified type of action that raised the event.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that the event is responding to.</param>
        /// <param name="action">The type of <see cref="NodeViewAction"/> that raised the event.</param>
        public NodeViewEventArgs(Node node, NodeViewAction action)
        {
            Node = node;
            Action = action;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets the type of action that raised the event.
        /// </summary>
        public NodeViewAction Action
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Gets the tree node that has been checked, expanded, collapsed, or selected.
        /// </summary>
        public Node Node
        {
            get;
            private set;
        }
    }
}