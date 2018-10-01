using System;

namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Provides data for the <see cref="NodeView.BeforeLabelEdit"/> and <see cref="NodeView.AfterLabelEdit"/> events.
    /// </summary>
    public class NodeViewLabelEditEventArgs : EventArgs
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewLabelEditEventArgs"/> class for the specified
        /// <see cref="Node"/>.
        /// </summary>
        /// <param name="node">The tree node containing the text to edit.</param>
        public NodeViewLabelEditEventArgs(Node node)
        {
            Node = node;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewLabelEditEventArgs"/> class for the specified
        /// <see cref="Node"/> and the specified text with which to update the tree node label.
        /// </summary>
        /// <param name="node">The tree node containing the text to edit.</param>
        /// <param name="label">The new text to associate with the tree node.</param>
        public NodeViewLabelEditEventArgs(Node node, string label)
        {
            Node = node;
            Label = label;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Gets or sets a value indicating whether the edit has been canceled.
        /// </summary>
        public bool CancelEdit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the new text to associate with the tree node.
        /// </summary>
        public string Label
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the tree node containing the text to edit.
        /// </summary>
        public Node Node
        {
            get;
            private set;
        }
    }
}