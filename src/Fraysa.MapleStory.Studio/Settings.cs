using System;
using System.Collections.Generic;

namespace Fraysa.MapleStory.Studio
{
    public class Settings
    {
        private const string _settingsFileName = "Settings.ini";

        private const string _mainSection = "Main";
        private const string _windowXSetting = "WindowX";
        private const string _windowYSetting = "WindowY";
        private const string _windowWidthSetting = "WindowWidth";
        private const string _windowHeightSetting = "WindowHeight";
        private const string _windowMaximizedSetting = "WindowMaximized";
        private const string _lastProjectPathSetting = "LastProjectPath";

        private const string _projectSectionPrefix = "Project_";
        private const string _projectFavoritesSetting = "Favorites";
        private const string _projectLastLocationSetting = "LastLocation";

        private IniFile _iniFile;

        private string _lastProjectPath;
        private int _windowX;
        private int _windowY;
        private int _windowWidth;
        private int _windowHeight;
        private bool _windowMaximized;

        private Dictionary<string, List<string>> _projectFavorites;
        private Dictionary<string, string> _projectLastLocation;

        internal Settings()
        {
            _iniFile = new IniFile(_settingsFileName);

            // Read in the settings for the first time.
            _lastProjectPath = _iniFile.GetString(_mainSection, _lastProjectPathSetting, null);
            _windowX = _iniFile.GetInt(_mainSection, _windowXSetting, 100);
            _windowY = _iniFile.GetInt(_mainSection, _windowYSetting, 100);
            _windowWidth = _iniFile.GetInt(_mainSection, _windowWidthSetting, 800);
            _windowHeight = _iniFile.GetInt(_mainSection, _windowHeightSetting, 600);
            _windowMaximized = _iniFile.GetBool(_mainSection, _windowMaximizedSetting, false);

            LoadProjectSections();
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the most recently opened project path which will be automatically opened when the studio
        /// starts.
        /// </summary>
        internal string LastProjectPath
        {
            get
            {
                return _lastProjectPath;
            }
            set
            {
                _lastProjectPath = value;
                _iniFile.SetValue(_mainSection, _lastProjectPathSetting, _lastProjectPath);
            }
        }

        /// <summary>
        /// Gets or sets the window X position the last time the program was used.
        /// </summary>
        internal int WindowX
        {
            get
            {
                return _windowX;
            }
            set
            {
                _windowX = value;
                _iniFile.SetValue(_mainSection, _windowXSetting, _windowX);
            }
        }

        /// <summary>
        /// Gets or sets the window Y position the last time the program was used.
        /// </summary>
        internal int WindowY
        {
            get
            {
                return _windowY;
            }
            set
            {
                _windowY = value;
                _iniFile.SetValue(_mainSection, _windowYSetting, _windowY);
            }
        }

        /// <summary>
        /// Gets or sets the window width the last time the program was used.
        /// </summary>
        internal int WindowWidth
        {
            get
            {
                return _windowWidth;
            }
            set
            {
                _windowWidth = value;
                _iniFile.SetValue(_mainSection, _windowWidthSetting, _windowWidth);
            }
        }

        /// <summary>
        /// Gets or sets the window height the last time the program was used.
        /// </summary>
        internal int WindowHeight
        {
            get
            {
                return _windowHeight;
            }
            set
            {
                _windowHeight = value;
                _iniFile.SetValue(_mainSection, _windowHeightSetting, _windowHeight);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window was maximized the last time the program was used.
        /// </summary>
        internal bool WindowMaximized
        {
            get
            {
                return _windowMaximized;
            }
            set
            {
                _windowMaximized = value;
                _iniFile.SetValue(_mainSection, _windowMaximizedSetting, _windowMaximized);
            }
        }

        /// <summary>
        /// Gets the list of favorites for each project.
        /// </summary>
        internal Dictionary<string, List<string>> ProjectFavorites
        {
            get
            {
                return _projectFavorites;
            }
        }

        /// <summary>
        /// Gets the list of favorites for each project.
        /// </summary>
        internal Dictionary<string, string> ProjectLastLocation
        {
            get
            {
                return _projectLastLocation;
            }
        }

        // ---- METHODS (INTERNAL) -------------------------------------------------------------------------------------

        /// <summary>
        /// Saves the favorites for the projects.
        /// </summary>
        internal void SaveProjectSections()
        {
            // Go through both dictionaries at the same time, as both should have the same keys.
            foreach (string project in _projectFavorites.Keys)
            {
                string sectionName = _projectSectionPrefix + project;
                List<string> projectFavorites = _projectFavorites[project];
                _iniFile.SetValue(sectionName, _projectFavoritesSetting, String.Join("|", projectFavorites));
                _iniFile.SetValue(sectionName, _projectLastLocationSetting, _projectLastLocation[project]);
            }
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void LoadProjectSections()
        {
            _projectFavorites = new Dictionary<string, List<string>>();
            _projectLastLocation = new Dictionary<string, string>();

            // Go through the project sections and get favorites and last locations.
            foreach (string sectionName in _iniFile.SectionNames)
            {
                if (sectionName.StartsWith(_projectSectionPrefix))
                {
                    string projectPath = sectionName.Substring(_projectSectionPrefix.Length);

                    string favorites = _iniFile.GetString(sectionName, _projectFavoritesSetting, String.Empty);
                    _projectFavorites.Add(projectPath, new List<string>(favorites.Split(new char[] { '|' },
                        StringSplitOptions.RemoveEmptyEntries)));

                    string lastLocation = _iniFile.GetString(sectionName, _projectLastLocationSetting, String.Empty);
                    _projectLastLocation.Add(projectPath, lastLocation);
                }
            }
        }
    }
}
