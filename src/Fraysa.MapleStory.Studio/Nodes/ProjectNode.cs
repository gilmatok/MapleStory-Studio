using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class ProjectNode : DirectoryNode
    {
        public GameProject GameProject { get; private set; }

        public override string ImageKey
        {
            get
            {
                return "MapleStory";
            }
        }

        public override string ImageKeyExpanded
        {
            get
            {
                return null;
            }
        }

        public ProjectNode(NodeView nodeView, GameProject gameProject)
            : base(nodeView, gameProject.RootDirectory)
        {
            this.GameProject = gameProject;
            this.Text = gameProject.RootDirectory;
        }

        public override List<ToolStripItem> GetContextMenuItems()
        {
            List<ToolStripItem> items = base.GetContextMenuItems();

            items.Insert(0, new ToolStripMenuItem("&Start Game", Resources.Start, tsmiStart_Click));
            items.Insert(1, new ToolStripMenuItem("&Kill Game", Resources.Stop, tsmiStop_Click));
            items.Insert(2, new ToolStripSeparator());

            return items;
        }

        private void tsmiStart_Click(object sender, EventArgs e)
        {
            GameProject.StartGame();
        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {
            GameProject.KillGame();
        }
    }
}
