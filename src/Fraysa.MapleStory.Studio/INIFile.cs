using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fraysa.MapleStory.Studio
{
    /// <summary>
    /// Represents an initialization file which values are stored and read in real time.
    /// </summary>
    public class IniFile
    {
        // ---- CONSTRUCTORS -------------------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="IniFile"/> class for the file stored under the specified file
        /// name.
        /// </summary>
        /// <param name="fileName">The name of the file which will be used.</param>
        public IniFile(string fileName)
        {
            FileName = fileName;
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the filename under which the initialization file will be written to and read from.
        /// </summary>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a list of all named section names in the initialization file.
        /// </summary>
        internal List<string> SectionNames
        {
            get
            {
                // Read in all text lines
                List<string> lines = ReadFileLines(FileName);

                // Get all named section names
                List<string> sectionNames = new List<string>();
                int currentLine = 0;
                while (currentLine < lines.Count)
                {
                    IniParseResult result = ParseIni(lines, currentLine);
                    if (result.Type == IniLineType.SectionHeader)
                    {
                        sectionNames.Add(result.PrimaryContent);
                    }
                    currentLine += result.LinesRead;
                }
                return sectionNames;
            }
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Queries the setting in the given section with the specified key as a boolean.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <returns>The value of the setting.</returns>
        internal bool GetBool(string section, string key)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                value = value.ToUpper();
                return value == "TRUE" || value == "1" || value == "ON" || value == "YES";
            }
            throw CreateSettingNotFoundException(section, key);
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as a boolean. If the setting does not exist,
        /// the default value is returned.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <param name="defaultValue">The default which will be returned if the setting is not found.</param>
        /// <returns>The value of the setting or the default value if the setting was not found.</returns>
        internal bool GetBool(string section, string key, bool defaultValue)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                value = value.ToUpper();
                return value == "TRUE" || value == "1" || value == "ON" || value == "YES";
            }
            return defaultValue;
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as a DateTime.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <returns>The value of the setting.</returns>
        internal DateTime GetDateTime(string section, string key)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                return new DateTime(long.Parse(value));
            }
            throw CreateSettingNotFoundException(section, key);
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as a DateTime. If the setting does not
        /// exist, the default value is returned.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <param name="defaultValue">The default value which will be returned if the setting is not found.</param>
        /// <returns>The value of the setting or the default value if the setting was not found.</returns>
        internal DateTime GetDateTime(string section, string key, DateTime defaultValue)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                return new DateTime(long.Parse(value));
            }
            return defaultValue;
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as an integer.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <returns>The value of the setting.</returns>
        internal int GetInt(string section, string key)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                return int.Parse(value);
            }
            throw CreateSettingNotFoundException(section, key);
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as an integer. If the setting does not
        /// exist, the default value is returned.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <param name="defaultValue">The default value which will be returned if the setting is not found.</param>
        /// <returns>The value of the setting or the default value if the setting was not found.</returns>
        internal int GetInt(string section, string key, int defaultValue)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                return int.Parse(value);
            }
            return defaultValue;
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as an IP address.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <returns>The value of the setting.</returns>
        internal IPAddress GetIPAddress(string section, string key)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                return IPAddress.Parse(value);
            }
            throw CreateSettingNotFoundException(section, key);
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as an IP address. If the setting does not
        /// exist, the default value is returned.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <param name="defaultValue">The default value which will be returned if the setting is not found.</param>
        /// <returns>The value of the setting or the default value if the setting was not found.</returns>
        internal IPAddress GetIPAddress(string section, string key, IPAddress defaultValue)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                return IPAddress.Parse(value);
            }
            return defaultValue;
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as a string.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <returns>The value of the setting.</returns>
        internal string GetString(string section, string key)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                return value;
            }
            throw CreateSettingNotFoundException(section, key);
        }

        /// <summary>
        /// Queries the setting in the given section with the specified key as a string. If the setting does not exist,
        /// the default value is returned.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The name of the key under which the setting is stored.</param>
        /// <param name="defaultValue">The default value which will be returned if the setting is not found.</param>
        /// <returns>The value of the setting or the default value if the setting was not found.</returns>
        internal string GetString(string section, string key, string defaultValue)
        {
            string value;
            if (TryGetString(section, key, out value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Renames the section with the given name.
        /// </summary>
        /// <param name="section">The name of the section to remove.</param>
        /// <param name="newName">The new name of the section.</param>
        internal void RenameSection(string section, string newName)
        {
            newName = newName.Trim();

            // Read in all text lines
            List<string> lines = new List<string>(ReadFileLines(FileName));

            if (section == null)
            {
                // Rename the global by adding a section name on top of it
                lines.Insert(0, "[" + newName + "]");
            }
            else
            {
                // Find the section with the given name and rename it
                int line = GetFirstLineOfSection(lines, section);
                if (line == -1)
                {
                    throw new InvalidDataException("Section \"" + section + "\" does not exist.");
                }
                lines[line] = "[" + newName + "]";
            }

            // Write the changes to the file
            WriteFileLines(FileName, lines);
        }

        /// <summary>
        /// Removes the section with the given name and all its lines until the next section starts.
        /// </summary>
        /// <param name="section">The name of the section to remove.</param>
        internal void RemoveSection(string section)
        {
            // Read in all text lines
            List<string> lines = new List<string>(ReadFileLines(FileName));

            // Get the line where the section starts
            int firstLine = GetFirstLineOfSection(lines, section);
            if (firstLine == -1)
            {
                throw new InvalidDataException("Section \"" + section + "\" does not exist.");
            }

            // Get the line where the section ends
            int lastLine = firstLine + 1;
            while (lastLine < lines.Count)
            {
                IniParseResult result = ParseIni(lines, lastLine);
                if (result.Type == IniLineType.SectionHeader)
                {
                    break;
                }
                lastLine += result.LinesRead;
            }

            // Remove the lines
            for (int i = lastLine - 1; i >= firstLine; i--)
            {
                lines.RemoveAt(i);
            }

            // Write the changes to the file
            WriteFileLines(FileName, lines);
        }

        /// <summary>
        /// Sets the specified boolean value in the given section under the provided key.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The key of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        internal void SetValue(string section, string key, bool value)
        {
            SetValue(section, key, value.ToString());
        }

        /// <summary>
        /// Sets the specified DateTime value in the given section under the provided key.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The key of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        internal void SetValue(string section, string key, DateTime value)
        {
            SetValue(section, key, value.Ticks.ToString());
        }

        /// <summary>
        /// Sets the specified integer value in the given section under the provided key.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The key of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        internal void SetValue(string section, string key, int value)
        {
            SetValue(section, key, value.ToString());
        }

        /// <summary>
        /// Sets the specified IPAddress value in the given section under the provided key.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The key of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        internal void SetValue(string section, string key, IPAddress value)
        {
            SetValue(section, key, value.ToString());
        }

        /// <summary>
        /// Sets the specified value in the given section under the provided key.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The key of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        internal void SetValue(string section, string key, object value)
        {
            SetValue(section, key, value.ToString());
        }

        /// <summary>
        /// Sets the specified string value in the given section under the provided key.
        /// </summary>
        /// <param name="section">The section under which the setting is stored.</param>
        /// <param name="key">The key of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        internal void SetValue(string section, string key, string value)
        {
            // Set up parameters
            if (section != null)
            {
                section = section.Trim();
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key name must not be null or whitespace.");
            }
            key = key.Trim();
            value = value == null ? string.Empty : value.ToString().Trim();

            // Read in all text lines
            List<string> lines = new List<string>(ReadFileLines(FileName));

            // Get the section line of the setting
            int lastLine = GetFirstLineOfSection(lines, section);
            if (lastLine == -1)
            {
                // If the section does not exist, insert a new one at the end of the file
                lines.Add("[" + section + "]");
                InsertSettingLines(lines, key, value, lines.Count);
            }
            else
            {
                // Find the setting line or add it to the bottom of the section
                int lastSettingLine = -1;
                while (lastLine < lines.Count)
                {
                    IniParseResult result = ParseIni(lines, lastLine);
                    if (result.Type == IniLineType.SingeLineValue || result.Type == IniLineType.MultiLineValue)
                    {
                        lastSettingLine = lastLine - 1 + result.LinesRead;
                        // Check if this is the setting searched for and change it then
                        if (result.PrimaryContent == key)
                        {
                            // Remove the lines of the multiline value first
                            for (int i = lastLine + result.LinesRead - 1; i >= lastLine; i--)
                            {
                                lines.RemoveAt(i);
                            }
                            // Insert the new value
                            InsertSettingLines(lines, key, value, lastLine);
                            break;
                        }
                    }
                    else if (result.Type == IniLineType.SectionHeader && result.PrimaryContent != section)
                    {
                        // Value not found in section, add it after the last setting of the previous section
                        InsertSettingLines(lines, key, value, lastSettingLine + 1);
                        break;
                    }
                    lastLine += result.LinesRead;
                }

                // Setting not found in the last section, insert the setting at the end of the file
                if (lastLine == lines.Count)
                {
                    InsertSettingLines(lines, key, value, lastSettingLine + 1);
                }
            }

            // Write the changes to the file
            WriteFileLines(FileName, lines);
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private static List<string> ReadFileLines(string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream stream = GetFileStreamSafe(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                using (StreamReader reader = new StreamReader(stream))
                {
                    return new List<string>(reader.ReadToEnd().Split(new string[] { Environment.NewLine },
                        StringSplitOptions.None));
                }
            }
            else
            {
                return new List<string>();
            }
        }

        private static void WriteFileLines(string fileName, List<string> lines)
        {
            FileStream stream = GetFileStreamSafe(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // Write all lines except last without line break
                for (int i = 0; i < lines.Count - 1; i++)
                {
                    writer.WriteLine(lines[i]);
                }
                // Write the last line without line break
                writer.Write(lines[lines.Count - 1]);
            }
        }

        private static FileStream GetFileStreamSafe(string filename, FileMode mode, FileAccess access, FileShare share)
        {
            // Retry for 2 seconds in 250 ms steps
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    return new FileStream(filename, mode, access, share);
                }
                catch (IOException)
                {
                    // Check if the IO exception was raised because of a locked file
                    int errorCode = Marshal.GetLastWin32Error();
                    if (errorCode == (int)Win32Error.SharingViolation || errorCode == (int)Win32Error.LockViolation)
                    {
                        Thread.Sleep(250);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return null;
        }

        private static IniParseResult ParseIni(List<string> lines, int firstLine)
        {
            IniParseResult result = null;
            string key = null;
            string value = null;
            bool isInMultilineValue = false;
            for (int i = firstLine; i < lines.Count; i++)
            {
                string line = lines[i];
                string trimmedLine = line.Trim();

                // In multiline mode, every line except "}" counts as a part of the value
                if (isInMultilineValue)
                {
                    if (trimmedLine == "}")
                    {
                        // End of multiline value
                        result = new IniParseResult(IniLineType.MultiLineValue, key, value, i - firstLine + 1);
                        break;
                    }
                    else
                    {
                        // Additional multiline line
                        value = value == null ? line : string.Join(Environment.NewLine, value, line);
                    }
                }
                else
                {
                    if (trimmedLine.Length == 0)
                    {
                        // Empty line
                        result = new IniParseResult(IniLineType.EmptyLine, null, null, 1);
                        break;
                    }
                    else if (trimmedLine[0] == ';' || trimmedLine[0] == '#')
                    {
                        // Comment
                        string commentText = trimmedLine.Substring(1).TrimEnd();
                        result = new IniParseResult(IniLineType.Comment, commentText, null, 1);
                        break;
                    }
                    else if (trimmedLine[0] == '[' && trimmedLine[trimmedLine.Length - 1] == ']')
                    {
                        // Section header
                        string sectionName = trimmedLine.Substring(1, trimmedLine.Length - 2).Trim();
                        result = new IniParseResult(IniLineType.SectionHeader, sectionName, null, 1);
                        break;
                    }
                    else
                    {
                        int equalsIndex = trimmedLine.IndexOf('=');
                        if (equalsIndex > 0)
                        {
                            // Setting
                            key = trimmedLine.Substring(0, equalsIndex).Trim();
                            value = trimmedLine.Substring(equalsIndex + 1).Trim();
                            if (value == "{")
                            {
                                // Multiline setting
                                isInMultilineValue = true;
                                value = null;
                            }
                            else
                            {
                                // Single line setting
                                result = new IniParseResult(IniLineType.SingeLineValue, key, value, 1);
                                break;
                            }
                        }
                        else
                        {
                            // Invalid line
                            result = new IniParseResult(IniLineType.InvalidLine, line, null, 1);
                            break;
                        }
                    }
                }
            }

            // Invalid content
            return result;
        }

        private static int GetFirstLineOfSection(List<string> lines, string section)
        {
            // The global section always starts at the first line
            if (section == null)
            {
                return 0;
            }

            // Find the first setting line of a named section
            section = section.Trim();
            int currentLine = 0;
            while (currentLine < lines.Count)
            {
                IniParseResult result = ParseIni(lines, currentLine);
                if (result.Type == IniLineType.SectionHeader && result.PrimaryContent == section)
                {
                    return currentLine;
                }
                currentLine += result.LinesRead;
            }

            // No section with the given name found
            return -1;
        }

        private static void InsertSettingLines(List<string> lines, string key, string value, int insertionLineIndex)
        {
            string[] valueTextLines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (valueTextLines.Length == 1)
            {
                // Simple insertion of single line value
                lines.Insert(insertionLineIndex, key + " = " + value);
            }
            else
            {
                // Multiple insertion for multiline values
                lines.Insert(insertionLineIndex, key + " = {");
                for (int i = 0; i < valueTextLines.Length; i++)
                {
                    lines.Insert(insertionLineIndex + 1 + i, valueTextLines[i]);
                }
                lines.Insert(insertionLineIndex + 1 + valueTextLines.Length, "}");
            }
        }

        private bool TryGetString(string section, string key, out string value)
        {
            // Check arguments
            if (section != null && section.Trim().Length == 0)
            {
                throw new ArgumentException("Section name must not be whitespace. Pass null to query the global "
                    + "section.");
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key name must not be null or whitespace.");
            }

            key = key.Trim();

            // Read in all text lines
            List<string> lines = ReadFileLines(FileName);

            // Find the first setting line of the given section
            int firstSettingLine = GetFirstLineOfSection(lines, section);
            if (firstSettingLine == -1)
            {
                // Section and thus value not found.
                value = null;
                return false;
            }
            firstSettingLine++;

            // Find the setting in the section
            int currentLine = firstSettingLine;
            while (currentLine < lines.Count)
            {
                IniParseResult result = ParseIni(lines, currentLine);
                if ((result.Type == IniLineType.SingeLineValue || result.Type == IniLineType.MultiLineValue)
                    && result.PrimaryContent == key)
                {
                    value = result.SecondaryContent;
                    return true;
                }
                currentLine += result.LinesRead;
            }

            // Value not found
            value = null;
            return false;
        }

        private InvalidDataException CreateSettingNotFoundException(string section, string key)
        {
            return new InvalidDataException(string.Format("Setting \"{0}\" not found in {1} section.", key,
                section == null ? "global" : "\"" + section + "\""));
        }

        // ---- CLASSES ------------------------------------------------------------------------------------------------

        /// <summary>
        /// Represents a single initialization parsing result containing the extracted information.
        /// </summary>
        private class IniParseResult
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="IniParseResult"/> class with the given extracted data.
            /// </summary>
            /// <param name="type">The type of the extracted data.</param>
            /// <param name="primaryContent">The primary text of the extracted data.</param>
            /// <param name="secondaryContent">The secondary text of the extracted data.</param>
            /// <param name="linesRead">The number of lines read for extracting data.</param>
            internal IniParseResult(IniLineType type, string primaryContent, string secondaryContent,
                int linesRead)
            {
                Type = type;
                PrimaryContent = primaryContent;
                SecondaryContent = secondaryContent;
                LinesRead = linesRead;
            }

            /// <summary>
            /// Gets the type of the parsed results.
            /// </summary>
            internal IniLineType Type
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the primary text parsed from the file.
            /// </summary>
            internal string PrimaryContent
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the secondary text parsed from the file.
            /// </summary>
            internal string SecondaryContent
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the number of lines read for the parse result. Except for multiline values, this is always 1.
            /// </summary>
            internal int LinesRead
            {
                get;
                private set;
            }
        }

        // ---- ENUMERATIONS -------------------------------------------------------------------------------------------

        /// <summary>
        /// List of relevant Win32 file-sharing errors.
        /// </summary>
        private enum Win32Error : int
        {
            /// <summary>
            /// The process cannot access the file because it is being used by another process.
            /// </summary>
            SharingViolation = 32,

            /// <summary>
            /// The process cannot access the file because another process has locked a portion of the file.
            /// </summary>
            LockViolation = 33
        }

        /// <summary>
        /// Possible types of parsing results for a initialization file text line.
        /// </summary>
        private enum IniLineType
        {
            /// <summary>
            /// Represents an invalid line which could not be parsed.
            /// </summary>
            InvalidLine,

            /// <summary>
            /// Represents an empty, whitespace line.
            /// </summary>
            EmptyLine,

            /// <summary>
            /// Represents a comment which text is stored in PrimaryContent.
            /// </summary>
            Comment,

            /// <summary>
            /// Represents a section header which name is stored in PrimaryContent.
            /// </summary>
            SectionHeader,

            /// <summary>
            /// Represents a setting using one line which key is stored in PrimaryContent and value in SecondaryContent.
            /// </summary>
            SingeLineValue,

            /// <summary>
            /// Represents a setting spanning multiple lines which key is stored in PrimaryContent and value in
            /// SecondaryContent.
            /// </summary>
            MultiLineValue
        }
    }
}
