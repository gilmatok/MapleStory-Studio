using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class ProjectNodeView : NodeView
    {
        private GameProject _gameProject;
        private bool _raiseNavigated;

        public ProjectNodeView()
        {
            this.ImageList = new ImageList();
            this.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.ImageList.Images.Add("WzFile", Resources.WzFile);
            this.ImageList.Images.Add("Cube", Resources.Cube);
            this.ImageList.Images.Add("File", Resources.File);
            this.ImageList.Images.Add("FolderClosed", Resources.FolderClosed);
            this.ImageList.Images.Add("FolderOpen", Resources.FolderOpen);
            this.ImageList.Images.Add("Font", Resources.Font);
            this.ImageList.Images.Add("Image", Resources.Image);
            this.ImageList.Images.Add("MapleStory", Resources.MapleStory);
            this.ImageList.Images.Add("Key", Resources.Key);
            this.ImageList.Images.Add("Library", Resources.Library);
            this.ImageList.Images.Add("Pack", Resources.Pack);
            this.ImageList.Images.Add("Sound", Resources.Sound);
            this.ImageList.Images.Add("TxtFile", Resources.TxtFile);
            this.ImageList.Images.Add("UnknownFile", Resources.UnknownFile);
            this.ImageList.Images.Add("Window", Resources.Window);
            this.ImageList.Images.Add("XmlFile", Resources.XmlFile);

            _raiseNavigated = true;
        }

        public event EventHandler Navigated;

        internal GameProject GameProject
        {
            get
            {
                return _gameProject;
            }
            set
            {
                _gameProject = value;

                this.BeginUpdate();
                this.Nodes.Clear();
                this.Nodes.Add(new ProjectNode(this, this.GameProject));
                this.EndUpdate();
            }
        }

        public bool Navigate(String path)
        {
            TreeNode targetNode = this.GetNode(path);

            if (targetNode == null)
            {
                return false;
            }
            else
            {
                this.SelectedNode = this.GetNode(path);
                this.OnNavigated();

                return true;
            }
        }

        public Node GetNode(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            string currentPath = this.GameProject.RootDirectory;
            string[] pathParts = path.Substring(this.GameProject.RootDirectory.Length).Split(new string[] { this.PathSeparator },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < pathParts.Length; i++)
            {
                Node node = this.GetNode(currentPath);
                List<Node> children = new List<Node>(node.GetNodes());
                bool childFound = false;

                foreach (Node child in children)
                {
                    if (child.Text == pathParts[i])
                    {
                        currentPath += this.PathSeparator + pathParts[i];
                        childFound = true;
                        break;
                    }
                }

                if (!childFound)
                {
                    return null;
                }
            }

            Node currentNode = this.Nodes[0];

            for (int i = 0; i < pathParts.Length; i++)
            {
                currentNode.Expand();

                foreach (Node childNode in currentNode.Nodes)
                {
                    if (childNode.Text == pathParts[i])
                    {
                        currentNode = childNode;
                        break;
                    }
                }
            }

            return currentNode;
        }

        protected override void OnBeforeExpand(NodeViewCancelEventArgs e)
        {
            // Do not raise a Navigated event for expanding nodes.
            _raiseNavigated = false;
            base.OnBeforeExpand(e);
            _raiseNavigated = true;
        }


        protected override void OnBeforeCollapse(NodeViewCancelEventArgs e)
        {
            // Do not allow collapsing project nodes.
            if (e.Node is ProjectNode)
            {
                e.Cancel = true;
            }

            base.OnBeforeCollapse(e);
        }

        protected override void OnNodeMouseClick(NodeViewMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the right-clicked node.
                SelectedNode = e.Node;

                // Create a context menu with the menu items provided by the node information.
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                contextMenu.Items.AddRange(e.Node.GetContextMenuItems().ToArray());
                contextMenu.Show(Cursor.Position);
            }

            base.OnNodeMouseClick(e);

            if (this.SelectedNode is WzStringNode)
            {
                this.OnNavigated();
            }
        }

        protected override void OnNodeMouseDoubleClick(NodeViewMouseClickEventArgs e)
        {
            base.OnNodeMouseDoubleClick(e);
            OnNavigated();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                OnNavigated();
            }
        }

        private void OnNavigated()
        {
            if (_raiseNavigated && Navigated != null)
            {
                Navigated(this, EventArgs.Empty);
            }
        }
    }
}
