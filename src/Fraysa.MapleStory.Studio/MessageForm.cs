using Fraysa.MapleStory.Studio.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio
{
    public partial class MessageForm : Form
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        private SolidBrush _borderBrush;
        private MessageBoxIcon _icon;

        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageForm"/> class.
        /// </summary>
        public MessageForm()
        {
            InitializeComponent();
            _borderBrush = new SolidBrush(Color.FromArgb(204, 206, 219));
        }

        private MessageForm(string message, MessageBoxButtons buttons, MessageBoxIcon icon, string title,
            MessageBoxDefaultButton defaultButton)
            : this()
        {
            // Set up the upper area.
            _icon = icon;
            Text = title;
            _pbIcon.Image = GetIconImage(_icon);
            _lbMessage.Text = message;

            // Add the required buttons to the form.
            List<Button> buttonList = CreateButtons(buttons, defaultButton);
            for (int i = buttonList.Count - 1; i >= 0; i--)
            {
                _flpButtons.Controls.Add(buttonList[i]);
            }

            // Set the default button which is accepted with enter or escape.
            AcceptButton = buttonList[(int)MessageBoxDefaultButton.Button1 / 256];

            // Resize to show the whole label.
            int width = _lbMessage.Width + _lbMessage.Bounds.Left + _lbMessage.Margin.Right;
            int height = _lbMessage.Height + _lbMessage.Bounds.Top + _lbMessage.Margin.Bottom + _flpButtons.Height;
            ClientSize = new Size(Math.Max(400, width), Math.Max(107, height));
        }

        // ---- METHODS (INTERNAL) -------------------------------------------------------------------------------------

        /// <summary>
        /// Shows the message with the given settings.
        /// </summary>
        /// <param name="message">The textual message to show.</param>
        /// <returns>The result of the clicked button.</returns>
        internal static DialogResult Show(string message)
        {
            return Show(message, MessageBoxButtons.OK, MessageBoxIcon.None, Application.ProductName,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Shows the message with the given settings.
        /// </summary>
        /// <param name="message">The textual message to show.</param>
        /// <param name="buttons">The buttons the user can click on.</param>
        /// <returns>The result of the clicked button.</returns>
        internal static DialogResult Show(string message, MessageBoxButtons buttons)
        {
            return Show(message, buttons, MessageBoxIcon.Question, Application.ProductName,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Shows the message with the given settings.
        /// </summary>
        /// <param name="message">The textual message to show.</param>
        /// <param name="buttons">The buttons the user can click on.</param>
        /// <param name="icon">The icon to show on the left side.</param>
        /// <returns>The result of the clicked button.</returns>
        internal static DialogResult Show(string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(message, buttons, icon, Application.ProductName, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Shows the message with the given settings.
        /// </summary>
        /// <param name="message">The textual message to show.</param>
        /// <param name="buttons">The buttons the user can click on.</param>
        /// <param name="icon">The icon to show on the left side.</param>
        /// <param name="title">The window title of the message form.</param>
        /// <returns>The result of the clicked button.</returns>
        internal static DialogResult Show(string message, MessageBoxButtons buttons, MessageBoxIcon icon, string title)
        {
            return Show(message, buttons, icon, title, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Shows the message with the given settings.
        /// </summary>
        /// <param name="message">The textual message to show.</param>
        /// <param name="buttons">The buttons the user can click on.</param>
        /// <param name="icon">The icon to show on the left side.</param>
        /// <param name="title">The window title of the message form.</param>
        /// <param name="defaultButton">The default button acceptable with Enter.</param>
        /// <returns>The result of the clicked button.</returns>
        internal static DialogResult Show(string message, MessageBoxButtons buttons, MessageBoxIcon icon, string title,
            MessageBoxDefaultButton defaultButton)
        {
            MessageForm form = new MessageForm(message, buttons, icon, title, defaultButton);
            return form.ShowDialog();
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Raises the <see cref="FormClosed"/> event.
        /// </summary>
        /// <param name="e">A <see cref="FormClosedEventArgs"/> that contains the event data.</param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _borderBrush.Dispose();
        }

        /// <summary>
        /// Raises the <see cref="Shown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            // Play a corresponding sound if any.
            Stream soundStream = null;
            try
            {
                soundStream = GetSoundStream(_icon);
                if (soundStream != null)
                {
                    SoundPlayer soundPlayer = new SoundPlayer(soundStream);
                    soundPlayer.Play();
                }
            }
            finally
            {
                if (soundStream != null) soundStream.Dispose();
            }

            base.OnShown(e);
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private Image GetIconImage(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    return Resources.MsgIconInformation;
                case MessageBoxIcon.Error:
                    return Resources.MsgIconError;
                //case MessageBoxIcon.Exclamation:
                //    return Resources.MsgIconExclamation;
                default:
                    return Resources.MsgIconQuestion;
            }
        }

        private Stream GetSoundStream(MessageBoxIcon icon)
        {
            switch (icon)
            {
                //case MessageBoxIcon.Information:
                //    return Resources.MsgSoundInformation;
                //case MessageBoxIcon.Error:
                //    return Resources.MsgSoundError;
                //case MessageBoxIcon.Exclamation:
                //    return Resources.MsgSoundExclamation;
                default:
                    return null;
            }
        }

        private List<Button> CreateButtons(MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            // Create the required buttons.
            List<Button> buttonList = new List<Button>();
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    buttonList.Add(CreateButton("Abort", DialogResult.Abort));
                    buttonList.Add(CreateButton("Retry", DialogResult.Retry));
                    buttonList.Add(CreateButton("Ignore", DialogResult.Ignore));
                    break;
                case MessageBoxButtons.OK:
                    buttonList.Add(CreateButton("OK", DialogResult.OK));
                    break;
                case MessageBoxButtons.OKCancel:
                    buttonList.Add(CreateButton("OK", DialogResult.OK));
                    buttonList.Add(CreateButton("Cancel", DialogResult.Cancel));
                    break;
                case MessageBoxButtons.RetryCancel:
                    buttonList.Add(CreateButton("Retry", DialogResult.Retry));
                    buttonList.Add(CreateButton("Cancel", DialogResult.Cancel));
                    break;
                case MessageBoxButtons.YesNo:
                    buttonList.Add(CreateButton("Yes", DialogResult.Yes));
                    buttonList.Add(CreateButton("No", DialogResult.No));
                    break;
                case MessageBoxButtons.YesNoCancel:
                    buttonList.Add(CreateButton("Yes", DialogResult.Yes));
                    buttonList.Add(CreateButton("No", DialogResult.No));
                    buttonList.Add(CreateButton("Cancel", DialogResult.Cancel));
                    break;
            }
            return buttonList;
        }

        private Button CreateButton(string text, DialogResult dialogResult)
        {
            return new Button()
            {
                DialogResult = dialogResult,
                Margin = new Padding(10, 0, 0, 0),
                Text = text,
                UseVisualStyleBackColor = true
            };
        }

        private void _flpButtons_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(_borderBrush, 0, 0, _flpButtons.Width, 1);
        }
    }
}
