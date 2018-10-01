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
    public class WzImageNode : Node
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

        private WZObject _wzImage;

        public WzImageNode(NodeView nodeView, string directoryPath, WZObject wzDirectory)
            : base(nodeView)
        {
            this.DirectoryPath = directoryPath;
            this.Text = wzDirectory.Name;

            _wzImage = wzDirectory;
        }

        public override int GetNodeCount()
        {
            return _wzImage.ChildCount;
        }

        public override List<Node> GetNodes()
        {
            List<Node> children = new List<Node>();

            foreach (var wzNode in _wzImage)
            {
                switch (wzNode.Type)
                {
                    case WZObjectType.Audio:
                        children.Add(new WzAudioNode(this.NodeView, this.DirectoryPath, wzNode));
                        break;

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
