using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Nodes
{
    public class DirectoryNode : Node
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

        public DirectoryNode(NodeView nodeView, string directoryPath)
            : base(nodeView)
        {
            this.DirectoryPath = directoryPath;
            this.Text = Path.GetFileName(directoryPath);
        }

        public override List<ToolStripItem> GetContextMenuItems()
        {
            List<ToolStripItem> items = base.GetContextMenuItems();

            items.Insert(0, new ToolStripMenuItem("&Delete", Resources.Delete, tsmiDelete_Click));
            items.Insert(1, new ToolStripSeparator());

            items.Add(new ToolStripMenuItem("&Refresh Node", Resources.Refresh, tsmiUpdateNode_Click));
            items.Add(new ToolStripMenuItem("&Show in File Explorer", Resources.OpenFolder, tsmiExplorer_Click));

            return items;
        }

        public override int GetNodeCount()
        {
            return Directory.GetFileSystemEntries(this.DirectoryPath).Length;
        }

        public override List<Node> GetNodes()
        {
            List<Node> children = new List<Node>();

            // Add the child directories in this directory.
            List<string> childDirectories = new List<string>(Directory.GetDirectories(DirectoryPath));
            childDirectories.Sort();
            foreach (string childDirectory in childDirectories)
            {
                children.Add(new DirectoryNode(NodeView, childDirectory));
            }

            // Add the files in this directory with correctly typed nodes.
            List<string> files = new List<string>(Directory.GetFiles(DirectoryPath));
            files.Sort();
            foreach (string file in files)
            {
                children.Add(GetFileNode(file));
            }

            return children;
        }

        private Node GetFileNode(string filePath)
        {
            switch (Path.GetExtension(filePath).ToUpper())
            {
                //    case ".1S":
                //        return new SceneNode(NodeView, filePath);
                //    case ".BMH":
                //    case ".BMX":
                //    case ".TTF":
                //        return new FontNode(NodeView, filePath);
                //    case ".BML":
                //    case ".EML":
                //        return new BmlNode(NodeView, filePath);
                case ".BMP":
                case ".DDS":
                case ".JPG":
                case ".PNG":
                case ".TGA":
                    return new ImageNode(NodeView, filePath);
                case ".DLL":
                    return new LibraryNode(NodeView, filePath);
                case ".EXE":
                    return new ExecutableNode(NodeView, filePath);
                //    case ".LOG":
                //    case ".TXT":
                //        return new TxtNode(NodeView, filePath);
                //    case ".OGG":
                //    case ".WAV":
                //        return new AudioNode(NodeView, filePath);
                //    case ".PK":
                //        return new PackTreeNode(NodeView, filePath);
                //    case ".RHO":
                //        return new ContainerNode(NodeView, filePath);
                //    case ".XML":
                //        return new XmlNode(NodeView, filePath);
                case ".WZ":
                    {
                        string fileName = Path.GetFileNameWithoutExtension(filePath);

                        if (fileName == "Base" || fileName == "List")
                        {
                            return new FileNode(NodeView, filePath);
                        }

                        return new WzNode(this.NodeView, filePath);
                    }

                default:
                    return new FileNode(NodeView, filePath);
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            // Prompt the user to confirm the deletion of the folder.
            string prompt = String.Format("Are you sure you want to permanently delete \"{0}\" and all of its "
                + "contents?", Path.GetFileName(FullPath));
            if (MessageForm.Show(prompt, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Directory.Delete(FullPath, true);
                Remove();
            }
        }

        private void tsmiExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(FullPath);
        }

        private void tsmiUpdateNode_Click(object sender, EventArgs e)
        {
            UpdateChildren();
        }
    }
}
