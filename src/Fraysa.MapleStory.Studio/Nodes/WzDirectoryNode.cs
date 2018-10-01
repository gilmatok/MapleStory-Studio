using Fraysa.MapleStory.reWZ.WZProperties;
using Fraysa.MapleStory.Studio.Controls.NodeView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class WzDirectoryNode : Node
    {
        public string DirectoryPath { get; private set; }

        public override string ImageKey
        {
            get
            {
                return "FolderClosed";
            }
        }

        public override string ImageKeyExpanded
        {
            get
            {
                return "FolderOpen";
            }
        }

        private WZObject _wzDirectory;

        public WzDirectoryNode(NodeView nodeView, string directoryPath, WZObject wzDirectory)
            : base(nodeView)
        {
            this.DirectoryPath = directoryPath;
            this.Text = wzDirectory.Name;

            _wzDirectory = wzDirectory;
        }

        public override int GetNodeCount()
        {
            return _wzDirectory.ChildCount;
        }

        public override List<Node> GetNodes()
        {
            List<Node> children = new List<Node>();

            foreach (var wzNode in _wzDirectory)
            {
                switch (wzNode.Type)
                {
                    case WZObjectType.Directory:
                        children.Add(new WzDirectoryNode(this.NodeView, this.DirectoryPath, wzNode));
                        break;

                    case WZObjectType.Image:
                        children.Add(new WzImageNode(this.NodeView, this.DirectoryPath, wzNode));
                        break;
                }
            }

            return new List<Node>(children.OrderBy(n => n.Text).ToList());
        }
    }
}
