using Fraysa.MapleStory.reWZ;
using Fraysa.MapleStory.Studio.Controls.NodeView;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class WzNode : Node
    {
        public string DirectoryPath { get; private set; }

        private WZFile _wzFile;

        public override string ImageKey
        {
            get
            {
                return "WzFile";
            }
        }

        public override string ImageKeyExpanded
        {
            get
            {
                return "WzFile";
            }
        }

        public WzNode(NodeView nodeView, string directoryPath)
            : base(nodeView)
        {
            this.DirectoryPath = directoryPath;
            this.Text = Path.GetFileName(directoryPath);

            if (Program.WzFileCache.ContainsKey(this.Text))
            {
                _wzFile = Program.WzFileCache[this.Text];
            }
            else
            {
                _wzFile = new WZFile(directoryPath, WZVariant.GMS, true);

                Program.WzFileCache[this.Text] = _wzFile;
            }
        }

        public override int GetNodeCount()
        {
            return _wzFile.MainDirectory.ChildCount;
        }

        public override List<Node> GetNodes()
        {
            List<Node> children = new List<Node>();

            // Add the child directories in this directory.

            foreach (var wzNode in _wzFile.MainDirectory)
            {
                switch (wzNode.Type)
                {
                    case reWZ.WZProperties.WZObjectType.Directory:
                        children.Add(new WzDirectoryNode(this.NodeView, this.DirectoryPath, wzNode));
                        break;

                    case reWZ.WZProperties.WZObjectType.Image:
                        children.Add(new WzImageNode(this.NodeView, this.DirectoryPath, wzNode));
                        break;
                }
            }

            return new List<Node>(children.OrderBy(n => n.Text).ToList());
        }
    }
}
