using Fraysa.MapleStory.Studio.Controls.NodeView;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class LibraryNode : FileNode
    {
        public LibraryNode(NodeView nodeView, string filePath) : base(nodeView, filePath) { }

        public override string ImageKey
        {
            get
            {
                return "Library";
            }
        }
    }
}
