using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Represents a collection of <see cref="Node"/> objects.
    /// </summary>
    public class NodeCollection : IList<Node>
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private NodeView           _nodeView;
        private TreeNodeCollection _base;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeCollection"/> class.
        /// </summary>
        public NodeCollection(NodeView nodeView, TreeNodeCollection baseCollection)
        {
            _nodeView = nodeView;
            _base = baseCollection;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the number of nodes contained in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return _base.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return _base.IsReadOnly;
            }
        }

        // ---- OPERATORS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the <see cref="Node"/> at the specified index.
        /// </summary>
        public Node this[int index]
        {
            get
            {
                return (Node)_base[index];
            }
            set
            {
                // Reparent the node and all children.
                ReparentNode(value, _nodeView);
                _base[index] = value;
            }
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Determines the index of a specific node in the list.
        /// </summary>
        /// <param name="node">The node to locate in the list.</param>
        /// <returns>The index of <paramref name="node"/> if found in the list; otherwise, -1.</returns>
        public int IndexOf(Node node)
        {
            return _base.IndexOf(node);
        }

        /// <summary>
        /// Inserts a node to the list at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="node"/> should be inserted.</param>
        /// <param name="node">The node to insert into the list.</param>
        public void Insert(int index, Node node)
        {
            _nodeView.BeginUpdate();

            // Reparent the node and all children.
            ReparentNode(node, _nodeView);
            node.UpdateImageKeys();

            // Add a dummy child node to make it expandable.
            if (!node.IsExpanded && node.GetNodeCount(false) > 0)
            {
                node.Nodes.Add(new Node(_nodeView));
            }

            _base.Insert(index, node);

            _nodeView.EndUpdate();
        }

        /// <summary>
        /// Removes the node at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the node to remove.</param>
        public void RemoveAt(int index)
        {
            _nodeView.BeginUpdate();

            // Unparent the node and all children.
            Node node = (Node)_base[index];
            ReparentNode(node, null);
            _base.Remove(node);

            _nodeView.EndUpdate();
        }

        /// <summary>
        /// Adds a node to the collection.
        /// </summary>
        /// <param name="node">The node to add to the collection.</param>
        public void Add(Node node)
        {
            _nodeView.BeginUpdate();

            // Reparent the node and all children.
            ReparentNode(node, _nodeView);
            node.UpdateImageKeys();

            // Add a dummy child node to make it expandable.
            if (!node.IsExpanded && node.GetNodeCount() > 0)
            {
                node.Nodes.Add(new Node(_nodeView));
            }

            _base.Add(node);

            _nodeView.EndUpdate();
        }

        /// <summary>
        /// Removes all nodes from the collection.
        /// </summary>
        public void Clear()
        {
            _nodeView.BeginUpdate();

            // Unparent the nodes and all children.
            foreach (Node node in _base)
            {
                ReparentNode(node, null);
            }
            _base.Clear();

            _nodeView.EndUpdate();
        }

        /// <summary>
        /// Determines whether the collection contains a specific node.
        /// </summary>
        /// <param name="node">The node to locate in the collection.</param>
        /// <returns><c>true</c> if <paramref name="node"/> is found in the collection; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Node node)
        {
            return _base.Contains(node);
        }

        /// <summary>
        /// Copies the elements of the collection to an <see cref="Array"/>, starting at a particular
        /// <see cref="Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied
        /// from collection. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(Node[] array, int arrayIndex)
        {
            _base.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific node from the collection.
        /// </summary>
        /// <param name="node">The node to remove from the collection.</param>
        /// <returns><c>true</c> if <paramref name="node"/> was successfully removed from the collection; otherwise,
        /// <c>false</c>. This method also returns <c>false</c> if <paramref name="node"/> is not found in the original
        /// collection.</returns>
        public bool Remove(Node node)
        {
            _nodeView.BeginUpdate();
            
            // Unparent the node and all children.
            bool result = false;
            if (_base.Contains(node))
            {
                ReparentNode(node, null);
                result = true;
            }
            _base.Remove(node);

            _nodeView.EndUpdate();

            return result;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Node> GetEnumerator()
        {
            foreach (Node node in _base)
            {
                yield return node;
            }
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private static void ReparentNode(Node node, NodeView nodeView)
        {
            foreach (Node childNode in node.Nodes)
            {
                ReparentNode(childNode, nodeView);
            }
            node.NodeView = nodeView;
        }

        // ---- METHODS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}