using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio
{
    public class GameProject
    {
        public string ExecutablePath { get; private set; }
        public string RootDirectory { get; private set; }

        public GameProject(string executablePath)
        {
            this.ExecutablePath = executablePath;
            this.RootDirectory = Path.GetDirectoryName(executablePath);
        }

        public static bool ValidatePath(string executablePath)
        {
            string gameDirectory = Path.GetDirectoryName(executablePath);

            return Directory.GetFiles(gameDirectory, "*.wz").Length > 0;
        }

        public void StartGame()
        {
            Process[] processes = this.GetGameProcesses();

            if (processes.Length > 0)
            {
                DialogResult result = MessageForm.Show("The game is running already." + Environment.NewLine
                    + "Do you want to kill it before starting it again?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation);

                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            this.KillProcesses(processes);

                            Thread.Sleep(500);
                        }
                        break;

                    case DialogResult.Cancel:
                        return;
                }
            }

            Process.Start(this.ExecutablePath);
        }

        public void KillGame()
        {
            this.KillProcesses(this.GetGameProcesses());
        }

        private Process[] GetGameProcesses()
        {
            string processName = Path.GetFileNameWithoutExtension(this.ExecutablePath);

            return Process.GetProcessesByName(processName);
        }

        private void KillProcesses(Process[] processes)
        {
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }
    }
}
