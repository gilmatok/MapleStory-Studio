using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Fraysa.MapleStory.Studio.Editors
{
    public partial class ExternalEditor : EditorBase
    {
        public ExternalEditor()
        {
            InitializeComponent();
        }

        private void ExternalEditor_ClientSizeChanged(object sender, EventArgs e)
        {
            _lbInformation.MaximumSize = new Size(ClientSize.Width - Padding.Horizontal, Int32.MaxValue);
        }

        private void _btOpenExternal_Click(object sender, EventArgs e)
        {
            Process.Start(NodePath);
        }
    }
}
