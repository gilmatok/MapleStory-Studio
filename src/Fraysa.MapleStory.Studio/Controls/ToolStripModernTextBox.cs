using System.Drawing;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls
{
    /// <summary>
    /// Represents a host to display a <see cref="ModernTextBox"/> in a toolstrip.
    /// </summary>
    public partial class ToolStripModernTextBox : ToolStripControlHost
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripModernTextBox"/> class.
        /// </summary>
        public ToolStripModernTextBox()
            : base(new ModernTextBox())
        {
        }

        // ---- EVENTS -------------------------------------------------------------------------------------------------

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        public new event KeyEventHandler KeyDown
        {
            add
            {
                HostedControl.KeyDown += value;
            }
            remove
            {
                HostedControl.KeyDown -= value;
            }
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a value indicating whether pressing ENTER in a multiline <see cref="ModernTextBox"/> control
        /// creates a new line of text in the control or activates the default button for the form.
        /// </summary>
        public bool AcceptsReturn
        {
            get
            {
                return HostedControl.TextBox.AcceptsReturn;
            }
            set
            {
                HostedControl.TextBox.AcceptsReturn = value;
            }
        }

        /// <summary>
        /// Gets or sets an option that controls how automatic completion works for the <see cref="ModernTextBox"/>.
        /// </summary>
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return HostedControl.TextBox.AutoCompleteMode;
            }
            set
            {
                HostedControl.TextBox.AutoCompleteMode = value;
            }
        }

        /// <summary>
        /// Gets or sets a value specifying the source of complete strings used for automatic completion.
        /// </summary>
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return HostedControl.TextBox.AutoCompleteSource;
            }
            set
            {
                HostedControl.TextBox.AutoCompleteSource = value;
            }
        }

        /// <summary>
        /// Gets or sets the text to be displayed on the hosted control.
        /// </summary>
        public override string Text
        {
            get
            {
                return HostedControl.TextBox.Text;
            }
            set
            {
                HostedControl.TextBox.Text = value;
            }
        }

        private ModernTextBox HostedControl
        {
            get
            {
                return Control as ModernTextBox;
            }
        }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="constrainingSize">The custom-sized area for a control.</param>
        /// <returns>An ordered pair of type <see cref="Size"/> representing the width and height of a rectangle.
        /// </returns>
        public override Size GetPreferredSize(Size constrainingSize)
        {
            return HostedControl.PreferredSize;
        }

        /// <summary>
        /// Selects a range of text in the text box.
        /// </summary>
        /// <param name="start">The position of the first character in the current text selection within the text box.
        /// </param>
        /// <param name="length">The number of characters to select.</param>
        public void Select(int start, int length)
        {
            HostedControl.TextBox.Select(start, length);
        }

        /// <summary>
        /// Selects all text in the text box.
        /// </summary>
        public void SelectAll()
        {
            HostedControl.TextBox.SelectAll();
        }
    }
}
