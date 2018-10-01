using System.ComponentModel;

namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Provides data for the <see cref="NodeView.BeforeCheck"/>, <see cref="NodeView.BeforeCollapse"/>,
    /// <see cref="NodeView.BeforeExpand"/>, and <see cref="NodeView.BeforeSelect"/> events of a <see cref="NodeView"/>
    /// control.
    /// </summary>
    public class NodeViewCancelEventArgs : CancelEventArgs
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewCancelEventArgs"/> class with the specified tree node,
        /// a value specifying whether the event is to be canceled, and the type of tree view action that raised the
        /// event.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that the event is responding to.</param>
        /// <param name="cancel"><c>true</c> to cancel the event; otherwise, <c>false</c>.</param>
        /// <param name="action">One of the <see cref="NodeViewAction"/> values indicating the type of action that
        /// raised the event.</param>
        public NodeViewCancelEventArgs(Node node, bool cancel, NodeViewAction action)
            : base(cancel)
        {
            Node = node;
            Action = action;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the type of <see cref="NodeView"/> action that raised the event.
        /// </summary>
        public NodeViewAction Action
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Gets the tree node to be checked, expanded, collapsed, or selected. 
        /// </summary>
        public Node Node
        {
            get;
            private set;
        }
    }
}