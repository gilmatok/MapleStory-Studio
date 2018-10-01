using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Editors;
using System;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class ImageNode : FileNode
    {
        public ImageNode(NodeView nodeView, string filePath) : base(nodeView, filePath) { }

        public override string ImageKey
        {
            get
            {
                return "Image";
            }
        }

        public override Type EditorType
        {
            get
            {
                return typeof(ImageEditor);
            }
        }
    }
}
