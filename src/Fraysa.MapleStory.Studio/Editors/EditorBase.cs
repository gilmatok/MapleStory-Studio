using System.ComponentModel;
using System.Windows.Forms;
using Fraysa.MapleStory.Studio.Nodes;
using System.IO;
using Fraysa.MapleStory.reWZ.WZProperties;

namespace Fraysa.MapleStory.Studio.Editors
{
    public partial class EditorBase : UserControl
    {
        public ProjectNodeView ProjectTreeView { get; set; }

        public EditorBase()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal virtual string NodePath { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal virtual WZObject WzObject { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal virtual bool HasUnsavedChanges
        {
            get
            {
                return false;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal virtual string Title
        {
            get
            {
                return Path.GetFileName(this.NodePath);
            }
        }

        public virtual void CustomDispose() { }
    }
}
