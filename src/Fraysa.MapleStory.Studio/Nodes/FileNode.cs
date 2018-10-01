using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Editors;
using Fraysa.MapleStory.Studio.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class FileNode : Node
    {
        public string FilePath { get; private set; }

        public override string ImageKey
        {
            get
            {
                return "File";
            }
        }

        public override string ImageKeyExpanded
        {
            get
            {
                return null;
            }
        }

        public virtual Type EditorType
        {
            get
            {
                return typeof(ExternalEditor);
            }
        }

        public FileNode(NodeView nodeView, string filePath)
            : base(nodeView)
        {
            this.FilePath = filePath;
            this.Text = Path.GetFileName(filePath);
        }

        public override List<ToolStripItem> GetContextMenuItems()
        {
            List<ToolStripItem> items = base.GetContextMenuItems();

            items.Insert(0, new ToolStripMenuItem("&Delete", Resources.Delete, tsmiDelete_Click));
            items.Insert(1, new ToolStripSeparator());

            items.Add(new ToolStripMenuItem("&Open Externally", Resources.OpenFile, tsmiOpenExternally_Click));
            items.Add(new ToolStripMenuItem("&Show in File Explorer", Resources.OpenFolder, tsmiExplorer_Click));

            return items;
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            // Prompt the user to confirm the deletion of the file.
            string prompt = String.Format("Are you sure you want to permanently delete \"{0}\"?",
                Path.GetFileName(FullPath));
            if (MessageForm.Show(prompt, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.Delete(FullPath);
                Remove();
            }
        }

        private void tsmiOpenExternally_Click(object sender, EventArgs e)
        {
            Process.Start(FullPath);
        }

        private void tsmiExplorer_Click(object sender, EventArgs e)
        {
            // Open the File Explorer and preselect the file.
            string argument = "/select, \"" + FullPath + "\"";
            Process.Start("explorer.exe", argument);
        }
    }
}
