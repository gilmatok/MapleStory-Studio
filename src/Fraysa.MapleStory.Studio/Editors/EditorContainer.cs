using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Nodes;
using Fraysa.MapleStory.Studio.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Editors
{
    /// <summary>
    /// Represents an editor container showing editors for specific game content.
    /// </summary>
    public class EditorContainer : TabControl
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private ProjectNodeView _projectTreeView;
        private Dictionary<string, TabPage> _openEditors;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorContainer"/> class.
        /// </summary>
        public EditorContainer()
        {
            ItemSize = new Size(0, 21);
            _openEditors = new Dictionary<string, TabPage>();
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the project <see cref="ProjectTreeView"/> displaying the game contents.
        /// </summary>
        internal ProjectNodeView ProjectTreeView
        {
            get
            {
                return _projectTreeView;
            }
            set
            {
                _projectTreeView = value;
                _projectTreeView.Navigated += _projectTreeView_Navigated;

                // Reuse the image list of the tree to display icons in tabs.
                ImageList = _projectTreeView.ImageList;
            }
        }

        // ---- METHODS (INTERNAL) -------------------------------------------------------------------------------------

        /// <summary>
        /// Removes all open editors.
        /// </summary>
        internal void ClearEditors()
        {
            TabPages.Clear();
            _openEditors.Clear();
            Visible = false;
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Raises the <see cref="Selected"/> event.
        /// </summary>
        /// <param name="e">A <see cref="TabControlEventArgs"/> that contains the event data.</param>
        protected override void OnSelected(TabControlEventArgs e)
        {
            // Select the corresponding node in the project tree view.
            //_projectTreeView.Navigate(GetNodePathFromTab(e.TabPage));
        }

        /// <summary>
        /// Raises the <see cref="MouseClick"/> event.
        /// </summary>
        /// <param name="e">An <see cref="MouseEventArgs"/> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            TabPage clickedTab = GetTabFromLocation(e.Location);
            if (clickedTab != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Middle:
                        // Close a tab with the middle mouse button.
                        RemoveEditor(clickedTab);
                        break;
                    case MouseButtons.Right:
                        // Select the tab and show the node context menu with the right click button.
                        SelectedTab = clickedTab;
                        Node node = _projectTreeView.GetNode(GetNodePathFromTab(clickedTab));
                        ContextMenuStrip contextMenu = new ContextMenuStrip();
                        contextMenu.Items.AddRange(GetTabContextMenuItems().ToArray());
                        contextMenu.Items.Add(new ToolStripSeparator());
                        contextMenu.Items.AddRange(node.GetContextMenuItems().ToArray());
                        contextMenu.Show(Cursor.Position);
                        break;
                }
            }
            base.OnMouseClick(e);
        }

        /// <summary>
        /// Raises the <see cref="MouseDoubleClick"/> event.
        /// </summary>
        /// <param name="e">An <see cref="MouseEventArgs"/> that contains the event data.</param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            // Quickly closing tabs with the middle button causes a double click event. Handle it like a single click.
            TabPage clickedTab = GetTabFromLocation(e.Location);
            if (clickedTab != null)
            {
                if (e.Button == MouseButtons.Middle)
                {
                    // Close a tab with the middle mouse button.
                    RemoveEditor(clickedTab);
                }
            }
            base.OnMouseDoubleClick(e);
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void AddEditor(FileNode node)
        {
            // Check if there is already an open tab visualizing this path, and if yes, select it.
            TabPage existingTab;
            if (_openEditors.TryGetValue(node.FullPath, out existingTab))
            {
                SelectedTab = existingTab;
            }
            else
            {
                // Get the node info of the node with the given path.
                if (node.EditorType != null)
                {
                    // Create the new editor.
                    EditorBase editor = (EditorBase)Activator.CreateInstance(node.EditorType, true);
                    editor.ProjectTreeView = _projectTreeView;
                    editor.NodePath = node.FullPath;

                    if (node is WzAudioNode)
                    {
                        editor.WzObject = ((WzAudioNode)node).WzNode;
                    }
                    else if (node is WzStringNode)
                    {
                        editor.WzObject = ((WzStringNode)node).WzNode;
                    }

                    // Create the tab page and display the editor on it.
                    TabPage editorTab = new TabPage(Path.GetFileName(node.FullPath))
                    {
                        Padding = new Padding(0, 2, 2, 1),
                        UseVisualStyleBackColor = true,
                        Tag = editor // reference so we can dispose it l8r!!
                    };
                    editor.Parent = editorTab;
                    editor.Dock = DockStyle.Fill;

                    // Add tab page, set up icon (now being able to get the image from the list) and make it active.
                    _openEditors.Add(node.FullPath, editorTab);
                    TabPages.Add(editorTab);
                    editorTab.ImageKey = node.ImageKey;
                    SelectedTab = editorTab;

                    Visible = true;
                }
            }
        }

        private void RemoveEditor(TabPage tabPage)
        {
            // Remove the corresponding node path from the dictionary.
            _openEditors.Remove(GetNodePathFromTab(tabPage));

            ((EditorBase)tabPage.Tag).CustomDispose();

            TabPages.Remove(tabPage);
            Visible = TabPages.Count > 0;
        }

        private TabPage GetTabFromLocation(Point location)
        {
            // Find out which tab was middle clicked.
            for (int i = 0; i < TabPages.Count; i++)
            {
                if (GetTabRect(i).Contains(location))
                {
                    return TabPages[i];
                }
            }
            return null;
        }

        private string GetNodePathFromTab(TabPage tabPage)
        {
            foreach (KeyValuePair<string, TabPage> openEditor in _openEditors)
            {
                if (openEditor.Value == tabPage)
                {
                    return openEditor.Key;
                }
            }
            return null;
        }

        private List<ToolStripMenuItem> GetTabContextMenuItems()
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();

            items.Add(new ToolStripMenuItem("&Close Tab", Resources.Exit, tsmiCloseTab_Click));

            ToolStripMenuItem tsmiCloseAllButThis = new ToolStripMenuItem("Close All &But This", Resources.Exit,
                tsmiCloseAllButThis_Click);
            tsmiCloseAllButThis.Enabled = TabPages.Count > 1;
            items.Add(tsmiCloseAllButThis);

            items.Add(new ToolStripMenuItem("Close &All Tabs", Resources.Exit, tsmiCloseAll_Click));

            return items;
        }

        // ---- EVENTHANDLERS ------------------------------------------------------------------------------------------

        private void tsmiCloseTab_Click(object sender, EventArgs e)
        {
            RemoveEditor(SelectedTab);
        }

        private void tsmiCloseAllButThis_Click(object sender, EventArgs e)
        {
            for (int i = TabPages.Count - 1; i >= 0; i--)
            {
                TabPage tabPage = TabPages[i];
                if (tabPage != SelectedTab)
                {
                    RemoveEditor(tabPage);
                }
            }
        }

        private void tsmiCloseAll_Click(object sender, EventArgs e)
        {
            for (int i = TabPages.Count - 1; i >= 0; i--)
            {
                TabPage tabPage = TabPages[i];
                RemoveEditor(tabPage);
            }
        }

        private void _projectTreeView_Navigated(object sender, EventArgs e)
        {
            // Open an editor when the navigation was to a file node.
            FileNode fileNode = _projectTreeView.SelectedNode as FileNode;
            if (fileNode != null)
            {
                AddEditor(fileNode);
            }
        }
    }
}
