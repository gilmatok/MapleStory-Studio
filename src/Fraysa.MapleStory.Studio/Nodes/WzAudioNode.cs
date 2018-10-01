using System;
using Fraysa.MapleStory.reWZ.WZProperties;
using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Editors;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class WzAudioNode : FileNode
    {
        public string DirectoryPath { get; private set; }

        public WZObject WzNode { get; private set; }

        public override string ImageKey
        {
            get
            {
                return "Sound";
            }
        }

        public WzAudioNode(NodeView nodeView, string directoryPath, WZObject wzNode)
            : base(nodeView, directoryPath)
        {
            this.DirectoryPath = directoryPath;
            this.Text = wzNode.Name;

            this.WzNode = wzNode;
        }

        public override Type EditorType
        {
            get
            {
                return typeof(AudioEditor);
            }
        }
    }
}
