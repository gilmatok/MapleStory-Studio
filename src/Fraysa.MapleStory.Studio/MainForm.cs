using Fraysa.MapleStory.Studio.Controls;
using Fraysa.MapleStory.Studio.Controls.NodeView;
using Fraysa.MapleStory.Studio.Nodes;
using Fraysa.MapleStory.Studio.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio
{
    public partial class MainForm : Form
    {
        private GameProject _gameProject;
        private Settings _settings;
        private List<string> _favorites;

        private List<string> _history;
        private int _historyIndex;
        private bool _pauseHistory;

        private bool _hasLoaded;

        private GameProject GameProject
        {
            get
            {
                return _gameProject;
            }
            set
            {
                _gameProject = value;

                _settings.LastProjectPath = _gameProject.ExecutablePath;

                this.Text = _gameProject.RootDirectory + " - " + this.ProductName;

                _tssbMainFavorites.Enabled = true;

                if (!_settings.ProjectFavorites.TryGetValue(_gameProject.ExecutablePath, out _favorites))
                {
                    _favorites = new List<string>();
                    _settings.ProjectFavorites.Add(_gameProject.ExecutablePath, _favorites);
                }

                this.UpdateRecentGames();
                this.ClearHistory();

                _tvProject.GameProject = _gameProject;

                Node rootNode = _tvProject.GetNode(_gameProject.RootDirectory);
                rootNode.Expand();


                _editorContainer.ClearEditors();
                string lastLocation;
                if (_settings.ProjectLastLocation.TryGetValue(_gameProject.ExecutablePath, out lastLocation))
                {
                    _tvProject.Navigate(lastLocation);
                }
                else
                {
                    _tvProject.Navigate(_gameProject.RootDirectory);
                }

                // Enable tools and other user interface parts.
                _tsbtMainStart.Enabled = true;
                _tstbAddress.Enabled = true;
                _tssbMainFavorites.Enabled = true;
                _tstbProjectSearch.Enabled = true;
                _tsbtProjectFilter.Enabled = true;
            }
        }

        public MainForm()
        {
            this.InitializeComponent();

            this.Text = Application.ProductName;

            ToolStripManager.Renderer = new VisualStudioRenderer();

            _settings = new Settings();

            this.UpdateRecentGames();

            this.ResizeAddressBar();

            _history = new List<string>();

            _tssbMainFavorites.DropDownDirection = ToolStripDropDownDirection.BelowLeft;

            // The editor container requires to know how the project tree view, so editors can force updates in it.
            _editorContainer.ProjectTreeView = _tvProject;
        }

        private void UpdateRecentGames()
        {
            _tsmiMainAppGames.DropDownItems.Clear();
            _tsmiMainAppGames.Visible = _settings.ProjectFavorites.Count > 0;

            // Go through each project section found in the settings file and add its location to the menu.
            foreach (string project in _settings.ProjectFavorites.Keys)
            {
                ToolStripItem projectItem = _tsmiMainAppGames.DropDownItems.Add(project);
                projectItem.Click += ProjectItem_Click;
            }
        }

        private void ProjectItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            GameProject = new GameProject(menuItem.Text);
        }

        private void OpenGameProject()
        {
            // Set the current game directory as the initial open path.
            if (_gameProject != null)
            {
                _ofdProject.InitialDirectory = Path.GetDirectoryName(_gameProject.ExecutablePath);
            }
            _ofdProject.ShowDialog();
        }

        private void ResizeAddressBar()
        {
            // Resize the address bar to fill the top area.
            int addressBarWidth = _tsMain.Width - _tsMain.Padding.Horizontal - _tstbAddress.Margin.Horizontal;
            foreach (ToolStripItem toolStripItem in _tsMain.Items)
            {
                if (toolStripItem != _tstbAddress && toolStripItem.Visible)
                {
                    addressBarWidth -= toolStripItem.Width - toolStripItem.Margin.Horizontal;
                }
            }
            _tstbAddress.Width = addressBarWidth;
        }

        private bool Navigate(string path)
        {
            // Try to switch to the entered path.
            if (_tvProject.Navigate(path))
            {
                _tstbAddress.ForeColor = Color.Empty;
                return true;
            }
            else
            {
                // The entered path does not exist in the game root.
                _tstbAddress.ForeColor = Color.Red;
                SystemSounds.Exclamation.Play();
                return false;
            }
        }

        private void ClearHistory()
        {
            _history.Clear();
            _historyIndex = -1;

            UpdateHistoryButtons();
        }

        private void AddToHistory(string path)
        {
            // Do not do anything if this path does not differ from the last one.
            if (_historyIndex > -1 && _history[_historyIndex] == path)
            {
                return;
            }

            // If there is trailing history due to the current position in it being in the mid, remove it.
            if (_historyIndex < _history.Count)
            {
                _history.RemoveRange(_historyIndex + 1, _history.Count - (_historyIndex + 1));
            }

            _history.Add(path);
            _historyIndex++;

            UpdateHistoryButtons();
        }

        private void GoBackwards()
        {
            string previousLocation = _history[_historyIndex - 1];

            // Try to go to the previous location (not adding it to the history again when successful).
            _pauseHistory = true;
            if (Navigate(previousLocation))
            {
                _pauseHistory = false;
                _historyIndex--;
            }
            else
            {
                MessageForm.Show("The location \"" + previousLocation + "\" does not exist anymore.",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            UpdateHistoryButtons();
        }

        private void GoForwards()
        {
            string nextLocation = _history[_historyIndex + 1];

            // Try to go to the next location (not adding it to the history again when successful).
            _pauseHistory = true;
            if (Navigate(nextLocation))
            {
                _pauseHistory = false;
                _historyIndex++;
            }
            else
            {
                MessageForm.Show("The location \"" + nextLocation + "\" does not exist anymore.", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            UpdateHistoryButtons();
        }

        private void UpdateHistoryButtons()
        {
            _tsbtMainBackward.Enabled = _historyIndex > 0;
            _tsbtMainForward.Enabled = _historyIndex < _history.Count - 1;
        }

        private void UpdateFavoritesButton()
        {
            if (_favorites.Contains(_tvProject.SelectedNode.FullPath))
            {
                _tssbMainFavorites.Image = Resources.FavoriteYes;
                _tssbMainFavorites.Text = "Remove From Favorites";
            }
            else
            {
                _tssbMainFavorites.Image = Resources.FavoriteNo;
                _tssbMainFavorites.Text = "Add To Favorites";
            }
        }

        private void SaveWindowState()
        {
            // Do not store the startup initialization states.
            if (_hasLoaded)
            {
                // Do not store the coordinates and size when the window is not in restored state.
                if (WindowState == FormWindowState.Normal)
                {
                    _settings.WindowX = DesktopLocation.X;
                    _settings.WindowY = DesktopLocation.Y;
                    _settings.WindowWidth = ClientSize.Width;
                    _settings.WindowHeight = ClientSize.Height;
                }
                _settings.WindowMaximized = WindowState == FormWindowState.Maximized;
            }
        }

        private void Search(string filter)
        {
            // If no filter has been provided, show all files again.
            if (String.IsNullOrEmpty(filter))
            {
                filter = "*";
            }

            //_tvProject.NodeFilter.FileFilter = filter;
            string previousPath = _tvProject.SelectedNode.FullPath;

            // Filter the whole tree for the given text, and try to get back to the previous path.
            _tvProject.Navigate(previousPath);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            // Restore the last window states.
            DesktopLocation = new Point(_settings.WindowX, _settings.WindowY);
            ClientSize = new Size(_settings.WindowWidth, _settings.WindowHeight);
            if (_settings.WindowMaximized)
            {
                WindowState = FormWindowState.Maximized;
            }

            if (File.Exists(_settings.LastProjectPath))
            {
                GameProject = new GameProject(_settings.LastProjectPath);
                _tvProject.Navigate(_settings.ProjectLastLocation[_gameProject.ExecutablePath]);
            }

            _hasLoaded = true;
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            SaveWindowState();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeAddressBar();
            SaveWindowState();
        }

        private void _tsdbMainApp_ButtonClick(object sender, EventArgs e)
        {
            OpenGameProject();
        }

        private void _tsmiMainAppGames_DropDownOpening(object sender, EventArgs e)
        {
            UpdateRecentGames();
        }

        private void _tsmiMainAppAbout_Click(object sender, EventArgs e)
        {
            // Play some laughter and show information.
            MessageForm.Show(String.Format("{0} {1}{2}{2}", // TODO: Add credits.
                Application.ProductName, Application.ProductVersion, Environment.NewLine), MessageBoxButtons.OK,
                MessageBoxIcon.Information, "About " + Application.ProductName);
        }

        private void _tsmiMainAppExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _tsbtMainStart_Click(object sender, EventArgs e)
        {
            GameProject.StartGame();
        }

        private void _tsbtMainStop_Click(object sender, EventArgs e)
        {
            GameProject.KillGame();
        }

        private void _tsbtMainBackward_Click(object sender, EventArgs e)
        {
            GoBackwards();
        }

        private void _tsbtMainForward_Click(object sender, EventArgs e)
        {
            GoForwards();
        }

        private void _tstbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                Navigate(_tstbAddress.Text);
            }
        }

        private void _tstbAddress_TextChanged(object sender, EventArgs e)
        {
            _tstbAddress.ForeColor = Color.Empty;
        }

        private void _tssbMainFavorites_ButtonClick(object sender, EventArgs e)
        {
            string currentPath = _tvProject.SelectedNode.FullPath;
            if (_favorites.Contains(currentPath))
            {
                // Remove from favorites.
                _favorites.Remove(currentPath);
            }
            else
            {
                // Add to favorites.
                _favorites.Add(currentPath);
                _favorites.Sort();
            }

            _settings.SaveProjectSections();
            UpdateFavoritesButton();
        }

        private void _tssbMainFavorites_DropDownOpening(object sender, EventArgs e)
        {
            // Show all the favorites in the drop down.
            _tssbMainFavorites.DropDownItems.Clear();
            foreach (string favorite in _favorites)
            {
                ToolStripItem favoriteItem = _tssbMainFavorites.DropDownItems.Add(favorite);

                // TODO: Create a method retrieving node information without the need to navigate there.
                Node node = _tvProject.GetNode(favorite);
                favoriteItem.Image = _tvProject.ImageList.Images[node.ImageKey];

                favoriteItem.Click += _tsmiFavoriteItem_Click;
            }
        }

        private void _tsmiFavoriteItem_Click(object sender, EventArgs e)
        {
            ToolStripItem favoriteItem = (ToolStripItem)sender;
            Navigate(favoriteItem.Text);
        }

        private void _tsbtMainSearch_Click(object sender, EventArgs e)
        {
        }

        private void _pnProject_SizeChanged(object sender, EventArgs e)
        {
            _tstbProjectSearch.Width = _tsProject.Width - _tsProject.Padding.Horizontal - _tsbtProjectFilter.Width;
        }

        private void _tstbProjectSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Search(_tstbProjectSearch.Text);
            }
        }

        private void _tsbtProjectSearch_Click(object sender, EventArgs e)
        {
            Search(_tstbProjectSearch.Text);
        }

        private void _tvProject_Navigated(object sender, EventArgs e)
        {
            // Add the new location to the history (if this navigation is not stepping through the history itself).
            if (!_pauseHistory)
            {
                _pauseHistory = false;
                AddToHistory(_tvProject.SelectedNode.FullPath);
            }

            // Update the address bar and favorites button.
            _tstbAddress.Text = _tvProject.SelectedNode.FullPath;
            _tstbAddress.Select(_tstbAddress.Text.Length, 0);
            UpdateFavoritesButton();

            // Save the last project location.
            _settings.ProjectLastLocation[GameProject.ExecutablePath] = _tvProject.SelectedNode.FullPath;
            _settings.SaveProjectSections();
        }

        private void _ofdProject_FileOk(object sender, CancelEventArgs e)
        {
            // Check if the game directory is prepared for a game project and decline it if not.
            if (GameProject.ValidatePath(_ofdProject.FileName))
            {
                GameProject = new GameProject(_ofdProject.FileName);
            }
            else
            {
                // Neither the container file nor a DataRaw directory was found, deem game directory as invalid.
                MessageForm.Show("This is not in a valid KartRider game directory" + Environment.NewLine + "(no packed "
                    + "or unpacked game data was found).", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void _tsmiMainSettings_Click(object sender, EventArgs e)
        {
            MessageForm.Show("The settings panel is currently under... construction." + Environment.NewLine +
                             "Yes, construction. Definitely not because of laziness.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
