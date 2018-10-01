using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Represents a <see cref="TreeView"/> using <see cref="Node"/> instances to store nodes.
    /// </summary>
    public class NodeView : ModernTreeView
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeView"/> class.
        /// </summary>
        public NodeView()
        {
            Nodes = new NodeCollection(this, base.Nodes);
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the collection of tree nodes that are assigned to the node view control.
        /// </summary>
        [Browsable(false)]
        [Category("Behavior")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [MergableProperty(false)]
        public new NodeCollection Nodes
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the tree node that is currently selected in the tree view control.
        /// </summary>
        [Browsable(false)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Node SelectedNode
        {
            get
            {
                return (Node)base.SelectedNode;
            }
            set
            {
                base.SelectedNode = value;
            }
        }

        /// <summary>
        /// Gets or sets the first fully-visible tree node in the tree view control.
        /// </summary>
        [Browsable(false)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Node TopNode
        {
            get
            {
                return (Node)base.TopNode;
            }
            set
            {
                base.TopNode = value;
            }
        }

        // ---- EVENTS -------------------------------------------------------------------------------------------------

        /// <summary>
        /// Occurs after the tree node check box is checked.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewEventHandler AfterCheck;
        
        /// <summary>
        /// Occurs after the tree node is collapsed.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewEventHandler AfterCollapse;

        /// <summary>
        /// Occurs after the tree node is expanded.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewEventHandler AfterExpand;

        /// <summary>
        /// Occurs after the tree node label text is edited.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewLabelEditEventHandler AfterLabelEdit;

        /// <summary>
        /// Occurs after the tree node is selected.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewEventHandler AfterSelect;

        /// <summary>
        /// Occurs before the tree node check box is checked.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewCancelEventHandler BeforeCheck;

        /// <summary>
        /// Occurs before the tree node is collapsed.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewCancelEventHandler BeforeCollapse;

        /// <summary>
        /// Occurs before the tree node is expanded.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewCancelEventHandler BeforeExpand;

        /// <summary>
        /// Occurs before the tree node label text is edited.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewLabelEditEventHandler BeforeLabelEdit;

        /// <summary>
        /// Occurs before the tree node is selected.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewCancelEventHandler BeforeSelect;

        /// <summary>
        /// Occurs when the user clicks a <see cref="Node"/> with the mouse.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewMouseClickEventHandler NodeMouseClick;

        /// <summary>
        /// Occurs when the user double-clicks a <see cref="Node"/> with the mouse.
        /// </summary>
        [Category("Behavior")]
        public new event NodeViewMouseClickEventHandler NodeMouseDoubleClick;
        
        /// <summary>
        /// Occurs when the mouse hovers over a <see cref="Node"/>.
        /// </summary>
        [Category("Action")]
        public new event NodeViewMouseHoverEventHandler NodeMouseHover;

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Retrieves the tree node that is at the specified point.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> to evaluate and retrieve the node from.</param>
        /// <returns>The <see cref="Node"/> at the specified point, in tree view (client) coordinates, or <c>null</c> if
        /// there is no node at that location.</returns>
        public new Node GetNodeAt(Point pt)
        {
            return (Node)base.GetNodeAt(pt);
        }
        
        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Forwards the <see cref="TreeView.AfterCheck"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TreeViewEventArgs"/> that contains the event data.</param>
        protected sealed override void OnAfterCheck(TreeViewEventArgs e)
        {
            NodeViewEventArgs newArgs = new NodeViewEventArgs((Node)e.Node, (NodeViewAction)e.Action);
            OnAfterCheck(newArgs);

            base.OnAfterCheck(e);
        }

        /// <summary>
        /// Raises the <see cref="AfterCheck"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewEventArgs"/> that contains the event data.</param>
        protected virtual void OnAfterCheck(NodeViewEventArgs e)
        {
            if (AfterCheck != null)
            {
                AfterCheck(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="AfterCollapse"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewEventArgs"/> that contains the event data.</param>
        protected sealed override void OnAfterCollapse(TreeViewEventArgs e)
        {
            NodeViewEventArgs newArgs = new NodeViewEventArgs((Node)e.Node, (NodeViewAction)e.Action);
            newArgs.Node.UpdateImageKeys();
            OnAfterCollapse(newArgs);

            base.OnAfterCollapse(e);
        }

        /// <summary>
        /// Raises the <see cref="AfterCollapse"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewEventArgs"/> that contains the event data.</param>
        protected virtual void OnAfterCollapse(NodeViewEventArgs e)
        {
            if (AfterCollapse != null)
            {
                AfterCollapse(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="AfterExpand"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewEventArgs"/> that contains the event data.</param>
        protected sealed override void OnAfterExpand(TreeViewEventArgs e)
        {
            NodeViewEventArgs newArgs = new NodeViewEventArgs((Node)e.Node, (NodeViewAction)e.Action);
            newArgs.Node.UpdateImageKeys();
            OnAfterExpand(newArgs);

            base.OnAfterExpand(e);
        }

        /// <summary>
        /// Raises the <see cref="AfterExpand"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewEventArgs"/> that contains the event data.</param>
        protected virtual void OnAfterExpand(NodeViewEventArgs e)
        {
            if (AfterExpand != null)
            {
                AfterExpand(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="AfterLabelEdit"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeLabelEditEventArgs"/> that contains the event data.</param>
        protected sealed override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            NodeViewLabelEditEventArgs newArgs = new NodeViewLabelEditEventArgs((Node)e.Node, e.Label);
            OnAfterLabelEdit(newArgs);
            e.CancelEdit = newArgs.CancelEdit;

            base.OnAfterLabelEdit(e);
        }

        /// <summary>
        /// Raises the <see cref="AfterLabelEdit"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewLabelEditEventArgs"/> that contains the event data.</param>
        protected virtual void OnAfterLabelEdit(NodeViewLabelEditEventArgs e)
        {
            if (AfterLabelEdit != null)
            {
                AfterLabelEdit(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="AfterSelect"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TreeViewEventArgs"/> that contains the event data.</param>
        protected sealed override void OnAfterSelect(TreeViewEventArgs e)
        {
            NodeViewEventArgs newArgs = new NodeViewEventArgs((Node)e.Node, (NodeViewAction)e.Action);
            OnAfterSelect(newArgs);

            base.OnAfterSelect(e);
        }

        /// <summary>
        /// Raises the <see cref="AfterSelect"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewEventArgs"/> that contains the event data.</param>
        protected virtual void OnAfterSelect(NodeViewEventArgs e)
        {
            if (AfterSelect != null)
            {
                AfterSelect(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="BeforeCheck"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TreeViewCancelEventArgs"/> that contains the event data.</param>
        protected sealed override void OnBeforeCheck(TreeViewCancelEventArgs e)
        {
            NodeViewCancelEventArgs newArgs = new NodeViewCancelEventArgs((Node)e.Node, e.Cancel,
                (NodeViewAction)e.Action);
            OnBeforeCheck(newArgs);
            e.Cancel = newArgs.Cancel;

            base.OnBeforeCheck(e);
        }

        /// <summary>
        /// Raises the <see cref="BeforeCheck"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewCancelEventArgs"/> that contains the event data.</param>
        protected virtual void OnBeforeCheck(NodeViewCancelEventArgs e)
        {
            if (BeforeCheck != null)
            {
                BeforeCheck(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="BeforeCollapse"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TreeViewCancelEventArgs"/> that contains the event data.</param>
        protected sealed override void OnBeforeCollapse(TreeViewCancelEventArgs e)
        {
            NodeViewCancelEventArgs newArgs = new NodeViewCancelEventArgs((Node)e.Node, e.Cancel,
                (NodeViewAction)e.Action);
            OnBeforeCollapse(newArgs);
            e.Cancel = newArgs.Cancel;

            base.OnBeforeCollapse(e);

            // Update the image keys and remove the children if the node should get collapsed.
            if (!e.Cancel)
            {
                newArgs.Node.UpdateImageKeys();
                newArgs.Node.Nodes.Clear();
                if (newArgs.Node.GetNodeCount() > 0)
                {
                    newArgs.Node.Nodes.Add(new Node(this));
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="BeforeCollapse"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewCancelEventArgs"/> that contains the event data.</param>
        protected virtual void OnBeforeCollapse(NodeViewCancelEventArgs e)
        {
            if (BeforeCollapse != null)
            {
                BeforeCollapse(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="BeforeExpand"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TreeViewCancelEventArgs"/> that contains the event data.</param>
        protected sealed override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            NodeViewCancelEventArgs newArgs = new NodeViewCancelEventArgs((Node)e.Node, e.Cancel,
                (NodeViewAction)e.Action);
            OnBeforeExpand(newArgs);
            e.Cancel = newArgs.Cancel;

            base.OnBeforeExpand(e);

            // Update the image keys and show the children if the node should get expanded.
            if (!e.Cancel)
            {
                newArgs.Node.UpdateImageKeys();
                newArgs.Node.Nodes.Clear();
                // Since the node count might have changed meanwhile, check if there are still children available.
                List<Node> children = newArgs.Node.GetNodes();
                if (children != null)
                {
                    foreach (Node childNode in children)
                    {
                        newArgs.Node.Nodes.Add(childNode);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="BeforeExpand"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewCancelEventArgs"/> that contains the event data.</param>
        protected virtual void OnBeforeExpand(NodeViewCancelEventArgs e)
        {
            if (BeforeExpand != null)
            {
                BeforeExpand(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="BeforeLabelEdit"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeLabelEditEventArgs"/> that contains the event data.</param>
        protected sealed override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
        {
            NodeViewLabelEditEventArgs newArgs = new NodeViewLabelEditEventArgs((Node)e.Node, e.Label);
            OnBeforeLabelEdit(newArgs);
            e.CancelEdit = newArgs.CancelEdit;

            base.OnBeforeLabelEdit(e);
        }

        /// <summary>
        /// Raises the <see cref="BeforeLabelEdit"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewLabelEditEventArgs"/> that contains the event data.</param>
        protected virtual void OnBeforeLabelEdit(NodeViewLabelEditEventArgs e)
        {
            if (BeforeLabelEdit != null)
            {
                BeforeLabelEdit(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="BeforeSelect"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TreeViewCancelEventArgs"/> that contains the event data.</param>
        protected sealed override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            NodeViewCancelEventArgs newArgs = new NodeViewCancelEventArgs((Node)e.Node, e.Cancel,
                (NodeViewAction)e.Action);
            OnBeforeSelect(newArgs);
            e.Cancel = newArgs.Cancel;

            base.OnBeforeSelect(e);
        }

        /// <summary>
        /// Raises the <see cref="BeforeSelect"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewCancelEventArgs"/> that contains the event data.</param>
        protected virtual void OnBeforeSelect(NodeViewCancelEventArgs e)
        {
            if (BeforeSelect != null)
            {
                BeforeSelect(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="NodeMouseClick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TreeNodeMouseClickEventArgs"/> that contains the event data.</param>
        protected sealed override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            NodeViewMouseClickEventArgs newArgs = new NodeViewMouseClickEventArgs((Node)e.Node, e.Button, e.Clicks, e.X,
                e.Y);
            OnNodeMouseClick(newArgs);

            base.OnNodeMouseClick(e);
        }

        /// <summary>
        /// Raises the <see cref="NodeMouseClick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewMouseClickEventArgs"/> that contains the event data.</param>
        protected virtual void OnNodeMouseClick(NodeViewMouseClickEventArgs e)
        {
            if (NodeMouseClick != null)
            {
                NodeMouseClick(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="NodeMouseDoubleClick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TreeNodeMouseClickEventArgs"/> that contains the event data.</param>
        protected sealed override void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            NodeViewMouseClickEventArgs newArgs = new NodeViewMouseClickEventArgs((Node)e.Node, e.Button, e.Clicks, e.X,
                e.Y);
            OnNodeMouseDoubleClick(newArgs);

            base.OnNodeMouseDoubleClick(e);
        }

        /// <summary>
        /// Raises the <see cref="NodeMouseDoubleClick"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NodeViewMouseClickEventArgs"/> that contains the event data.</param>
        protected virtual void OnNodeMouseDoubleClick(NodeViewMouseClickEventArgs e)
        {
            if (NodeMouseDoubleClick != null)
            {
                NodeMouseDoubleClick(this, e);
            }
        }

        /// <summary>
        /// Forwards the <see cref="NodeMouseHover"/> event.
        /// </summary>
        /// <param name="e">The <see cref="TreeNodeMouseHoverEventArgs"/> that contains the event data.</param>
        protected sealed override void OnNodeMouseHover(TreeNodeMouseHoverEventArgs e)
        {
            NodeViewMouseHoverEventArgs newArgs = new NodeViewMouseHoverEventArgs((Node)e.Node);
            OnNodeMouseHover(newArgs);

            base.OnNodeMouseHover(e);
        }

        /// <summary>
        /// Raises the <see cref="NodeMouseHover"/> event.
        /// </summary>
        /// <param name="e">The <see cref="NodeViewMouseHoverEventArgs"/> that contains the event data.</param>
        protected virtual void OnNodeMouseHover(NodeViewMouseHoverEventArgs e)
        {
            if (NodeMouseHover != null)
            {
                NodeMouseHover(this, e);
            }
        }
    }

    // ---- DELEGATES --------------------------------------------------------------------------------------------------
    
    /// <summary>
    /// Represents the method that will handle the <see cref="BeforeCheck"/>, <see cref="BeforeCollapse"/>,
    /// <see cref="BeforeExpand"/>, or <see cref="BeforeSelect"/> event of a <see cref="NodeView"/>.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="NodeViewCancelEventArgs"/> that contains the event data.</param>
    public delegate void NodeViewCancelEventHandler(object sender, NodeViewCancelEventArgs e);

    /// <summary>
    /// Represents the method that will handle the <see cref="NodeViewAfterCheck"/>,
    /// <see cref="NodeView.AfterCollapse"/>, <see cref="NodeView.AfterExpand"/>, or <see cref="NodeView.AfterSelect"/>
    /// event of a <see cref="NodeView"/>.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="NodeViewEventArgs"/> that contains the event data.</param>
    public delegate void NodeViewEventHandler(object sender, NodeViewEventArgs e);

    /// <summary>
    /// Represents the method that will handle the <see cref="BeforeLabelEdit"/> and <see cref="AfterLabelEdit"/> events
    /// of a <see cref="NodeView"/> control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="NodeViewLabelEditEventArgs"/> that contains the event data.</param>
    public delegate void NodeViewLabelEditEventHandler(object sender, NodeViewLabelEditEventArgs e);

    /// <summary>
    /// Represents the method that will handle the <see cref="NodeMouseClick"/> and <see cref="NodeMouseDoubleClick"/>
    /// events of a <see cref="NodeView"/>.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="NodeViewMouseClickEventArgs"/> that contains the event data.</param>
    public delegate void NodeViewMouseClickEventHandler(object sender, NodeViewMouseClickEventArgs e);

    /// <summary>
    /// Represents the method that will handle the <see cref="NodeMouseHover"/> event of a <see cref="NodeView"/>.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="NodeViewMouseHoverEventArgs"/> that contains the event data.</param>
    public delegate void NodeViewMouseHoverEventHandler(object sender, NodeViewMouseHoverEventArgs e);
}
