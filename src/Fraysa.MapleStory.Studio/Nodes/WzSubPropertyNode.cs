using Fraysa.MapleStory.reWZ.WZProperties;
using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class WzSubPropertyNode : Node
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

        private WZObject _wzSubProperty;

        public WzSubPropertyNode(NodeView nodeView, string directoryPath, WZObject wzSubProperty)
            : base(nodeView)
        {
            this.DirectoryPath = directoryPath;
            this.Text = wzSubProperty.Name;

            _wzSubProperty = wzSubProperty;
        }

        public override int GetNodeCount()
        {
            return _wzSubProperty.ChildCount;
        }

        public override List<Node> GetNodes()
        {
            List<Node> children = new List<Node>();

            foreach (var wzNode in _wzSubProperty)
            {
                switch (wzNode.Type)
                {
                    case WZObjectType.SubProperty:
                        children.Add(new WzSubPropertyNode(this.NodeView, this.DirectoryPath, wzNode));
                        break;

                    case WZObjectType.String:
                        children.Add(new WzStringNode(this.NodeView, this.DirectoryPath, wzNode));
                        break;
                }
            }

            return new List<Node>(children.OrderBy(n => n.Text).ToList());
        }
    }
}
