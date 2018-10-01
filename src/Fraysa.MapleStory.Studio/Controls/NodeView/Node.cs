using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Represents a tree node for the <see cref="NodeView"/> control.
    /// </summary>
    public class Node : TreeNode
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="nodeView">The <see cref="NodeView"/> this node is displayed in.</param>
        public Node(NodeView nodeView)
        {
            NodeView = nodeView;
            Nodes = new NodeCollection(nodeView, base.Nodes);
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the <see cref="NodeView"/> containing this node.
        /// </summary>
        [Browsable(false)]
        public NodeView NodeView
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the first child tree node in the tree node collection.
        /// </summary>
        [Browsable(false)]
        public new Node FirstNode
        {
            get
            {
                return (Node)base.FirstNode;
            }
        }

        /// <summary>
        /// Gets the image displayed on this node.
        /// </summary>
        public new virtual string ImageKey
        {
            get { return "File"; }
        }

        /// <summary>
        /// Gets the image displayed on this node when it is expanded, or <c>null</c> if the same image as the collapsed
        /// state should be used.
        /// </summary>
        public virtual string ImageKeyExpanded
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the last child tree node in the tree node collection.
        /// </summary>
        [Browsable(false)]
        public new Node LastNode
        {
            get
            {
                return (Node)base.LastNode;
            }
        }

        /// <summary>
        /// Gets the next sibling tree node.
        /// </summary>
        [Browsable(false)]
        public new Node NextNode
        {
            get
            {
                return (Node)base.NextNode;
            }
        }

        /// <summary>
        /// Gets the next visible tree node.
        /// </summary>
        [Browsable(false)]
        public new Node NextVisibleNode
        {
            get
            {
                return (Node)base.NextVisibleNode;
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="Node"/> objects assigned to the current tree node. This is not the real
        /// content of the node, as it is loaded at expand time. To get the real nodes, call <see cref="GetNodes"/>.
        /// </summary>
        [Browsable(false)]
        [ListBindable(false)]
        public new NodeCollection Nodes
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the parent tree node of the current tree node.
        /// </summary>
        [Browsable(false)]
        public new Node Parent
        {
            get
            {
                return (Node)base.Parent;
            }
        }

        /// <summary>
        /// Gets the previous sibling tree node.
        /// </summary>
        [Browsable(false)]
        public new Node PrevNode
        {
            get
            {
                return (Node)base.PrevNode;
            }
        }

        /// <summary>
        /// Gets the previous visible sibling tree node.
        /// </summary>
        [Browsable(false)]
        public new Node PrevVisibleNode
        {
            get
            {
                return (Node)base.PrevVisibleNode;
            }
        }

        /// <summary>
        /// Gets the parent tree view that the tree node is assigned to.
        /// </summary>
        [Browsable(false)]
        private new TreeView TreeView
        {
            get
            {
                return base.TreeView;
            }
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Returns a list of menu items to show in the context menu of the node.
        /// </summary>
        /// <returns>The list of <see cref="ToolStripMenuItem"/> instances which will be displayed.</returns>
        public virtual List<ToolStripItem> GetContextMenuItems()
        {
            return new List<ToolStripItem>();
        }

        /// <summary>
        /// Returns the closest parent node with the given type.
        /// </summary>
        /// <typeparam name="T">The type of the parent node.</typeparam>
        /// <returns>The parent node or <c>null</c> if no parent is of the given type.</returns>
        public T GetNextParent<T>()
            where T : Node
        {
            return GetNextParent<T>(this);
        }

        /// <summary>
        /// Returns the number of child tree nodes.
        /// </summary>
        /// <returns>The number of child tree nodes assigned to the <see cref="Nodes"/> collection.</returns>
        public virtual int GetNodeCount()
        {
            return 0;
        }

        /// <summary>
        /// Returns the real child nodes.
        /// </summary>
        /// <returns>The child nodes.</returns>
        public virtual List<Node> GetNodes()
        {
            return null;
        }

        /// <summary>
        /// Re-reads the children of this node. Note that this causes the children to be collapsed and expanded again.
        /// </summary>
        public void UpdateChildren()
        {
            if (IsExpanded)
            {
                NodeView.BeginUpdate();
                Nodes.Clear();
                foreach (Node child in GetNodes())
                {
                    Nodes.Add(child);
                }
                NodeView.EndUpdate();
            }
        }

        // ---- METHODS (INTERNAL) -------------------------------------------------------------------------------------

        /// <summary>
        /// Updates the image keys of the node according to its current state.
        /// </summary>
        internal void UpdateImageKeys()
        {
            if (IsExpanded && !String.IsNullOrEmpty(ImageKeyExpanded))
            {
                base.ImageKey = ImageKeyExpanded;
                SelectedImageKey = ImageKeyExpanded;
            }
            else
            {
                base.ImageKey = ImageKey;
                SelectedImageKey = ImageKey;
            }
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private T GetNextParent<T>(Node node)
            where T : Node
        {
            // Check if the parent of the given node is of the queried type.
            T typedParent = node.Parent as T;
            if (typedParent != null)
            {
                return typedParent;
            }

            // Otherwise check the parent of the parent, if it exists.
            if (node.Parent.Parent == null)
            {
                return null;
            }
            else
            {
                return GetNextParent<T>(node.Parent.Parent);
            }
        }

        /// <summary>
        /// Returns the number of child tree nodes.
        /// </summary>
        /// <param name="includeSubTrees"><c>true</c> if the resulting count includes all tree nodes indirectly rooted
        /// at this tree node; otherwise, <c>false</c>.</param>
        /// <returns>The number of child tree nodes assigned to the <see cref="Nodes"/> collection.</returns>
        private new int GetNodeCount(bool includeSubTrees)
        {
            throw new NotImplementedException();
        }
    }
}
