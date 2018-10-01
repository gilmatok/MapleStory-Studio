using System.Drawing;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls
{
    /// <summary>
    /// Represents Visual Studio 2015-like colors for the <see cref="ToolStripProfessionalRenderer"/>.
    /// </summary>
    public class VisualStudioColorTable : ProfessionalColorTable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private static readonly Color _background = Color.FromArgb(238, 238, 242);
        private static readonly Color _backgroundDropDown = Color.FromArgb(246, 246, 246);
        private static readonly Color _backgroundSelected = Color.FromArgb(201, 222, 245);
        private static readonly Color _backgroundPressed = Color.FromArgb(0, 122, 204);
        private static readonly Color _backgroundChecked = Color.FromArgb(254, 254, 254);
        private static readonly Color _backgroundStatus = Color.FromArgb(0, 122, 204);
        private static readonly Color _borderGrip = Color.FromArgb(153, 153, 153);
        private static readonly Color _borderDropDown = Color.FromArgb(204, 206, 219);
        private static readonly Color _borderSeperatorLight = Color.FromArgb(246, 246, 246);
        private static readonly Color _borderSeperatorDark = Color.FromArgb(204, 206, 219);

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the starting color of the gradient used when the button is checked.
        /// </summary>
        public override Color ButtonCheckedGradientBegin
        {
            get { return _backgroundChecked; }
        }

        /// <summary>
        /// Gets the end color of the gradient used when the button is checked.
        /// </summary>
        public override Color ButtonCheckedGradientEnd
        {
            get { return _backgroundChecked; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used when the button is checked.
        /// </summary>
        public override Color ButtonCheckedGradientMiddle
        {
            get { return _backgroundChecked; }
        }

        /// <summary>
        /// Gets the solid color used when the button is checked.
        /// </summary>
        public override Color ButtonCheckedHighlight
        {
            get { return _backgroundChecked; }
        }

        /// <summary>
        /// Gets the border color to use with <see cref="ButtonCheckedHighlight"/>.
        /// </summary>
        public override Color ButtonCheckedHighlightBorder
        {
            get { return Color.Transparent; }
        }

        /// <summary>
        /// Gets the border color to use with the <see cref="ButtonPressedGradientBegin"/>,
        /// <see cref="ButtonPressedGradientMiddle"/>, and <see cref="ButtonPressedGradientEnd"/> colors.
        /// </summary>
        public override Color ButtonPressedBorder
        {
            get { return Color.Transparent; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used when the button is pressed.
        /// </summary>
        public override Color ButtonPressedGradientBegin
        {
            get { return _backgroundPressed; }
        }

        /// <summary>
        /// Gets the end color of the gradient used when the button is pressed.
        /// </summary>
        public override Color ButtonPressedGradientEnd
        {
            get { return _backgroundPressed; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used when the button is pressed.
        /// </summary>
        public override Color ButtonPressedGradientMiddle
        {
            get { return _backgroundPressed; }
        }

        /// <summary>
        /// Gets the solid color used when the button is pressed.
        /// </summary>
        public override Color ButtonPressedHighlight
        {
            get { return Color.Transparent; }
        }

        /// <summary>
        /// Gets the border color to use with <see cref="ButtonPressedHighlight"/>.
        /// </summary>
        public override Color ButtonPressedHighlightBorder
        {
            get { return Color.Transparent; }
        }

        /// <summary>
        /// Gets the border color to use with the <see cref="ButtonSelectedGradientBegin"/>,
        /// <see cref="ButtonSelectedGradientMiddle"/>, and <see cref="ButtonSelectedGradientEnd"/> colors.
        /// </summary>
        public override Color ButtonSelectedBorder
        {
            get { return Color.Transparent; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used when the button is selected.
        /// </summary>
        public override Color ButtonSelectedGradientBegin
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the end color of the gradient used when the button is selected.
        /// </summary>
        public override Color ButtonSelectedGradientEnd
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used when the button is selected.
        /// </summary>
        public override Color ButtonSelectedGradientMiddle
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the solid color used when the button is selected.
        /// </summary>
        public override Color ButtonSelectedHighlight
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the border color to use with <see cref="ButtonSelectedHighlight"/>.
        /// </summary>
        public override Color ButtonSelectedHighlightBorder
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the solid color to use when the button is checked and gradients are being used.
        /// </summary>
        public override Color CheckBackground
        {
            get { return _backgroundChecked; }
        }

        /// <summary>
        /// Gets the solid color to use when the button is checked and selected and gradients are being used.
        /// </summary>
        public override Color CheckPressedBackground
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the solid color to use when the button is checked and selected and gradients are being used.
        /// </summary>
        public override Color CheckSelectedBackground
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the color to use for shadow effects on the grip (move handle).
        /// </summary>
        public override Color GripDark
        {
            get { return _borderGrip; }
        }

        /// <summary>
        /// Gets the color to use for highlight effects on the grip (move handle).
        /// </summary>
        public override Color GripLight
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the image margin of a <see cref="ToolStripDropDownMenu"/>.
        /// </summary>
        public override Color ImageMarginGradientBegin
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the end color of the gradient used in the image margin of a <see cref="ToolStripDropDownMenu"/>.
        /// </summary>
        public override Color ImageMarginGradientEnd
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used in the image margin of a <see cref="ToolStripDropDownMenu"/>.
        /// </summary>
        public override Color ImageMarginGradientMiddle
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the image margin of a <see cref="ToolStripDropDownMenu"/>
        /// when an item is revealed.
        /// </summary>
        public override Color ImageMarginRevealedGradientBegin
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the end color of the gradient used in the image margin of a <see cref="ToolStripDropDownMenu"/> when an
        /// item is revealed.
        /// </summary>
        public override Color ImageMarginRevealedGradientEnd
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used in the image margin of a <see cref="ToolStripDropDownMenu"/> when
        /// an item is revealed.
        /// </summary>
        public override Color ImageMarginRevealedGradientMiddle
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the color that is the border color to use on a <see cref="MenuStrip"/>.
        /// </summary>
        public override Color MenuBorder
        {
            get { return _borderDropDown; }
        }

        /// <summary>
        /// Gets the border color to use with a <see cref="ToolStripMenuItem"/>.
        /// </summary>
        public override Color MenuItemBorder
        {
            get { return Color.Transparent; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used when a top-level <see cref="ToolStripMenuItem"/> is pressed.
        /// </summary>
        public override Color MenuItemPressedGradientBegin
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the end color of the gradient used when a top-level <see cref="ToolStripMenuItem"/> is pressed.
        /// </summary>
        public override Color MenuItemPressedGradientEnd
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used when a top-level <see cref="ToolStripMenuItem"/> is pressed.
        /// </summary>
        public override Color MenuItemPressedGradientMiddle
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the solid color to use when a <see cref="ToolStripMenuItem"/> other than the top-level
        /// <see cref="ToolStripMenuItem"/> is selected.
        /// </summary>
        public override Color MenuItemSelected
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used when the <see cref="ToolStripMenuItem"/> is selected.
        /// </summary>
        public override Color MenuItemSelectedGradientBegin
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the end color of the gradient used when the <see cref="ToolStripMenuItem"/> is selected.
        /// </summary>
        public override Color MenuItemSelectedGradientEnd
        {
            get { return _backgroundSelected; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the <see cref="MenuStrip"/>.
        /// </summary>
        public override Color MenuStripGradientBegin
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the end color of the gradient used in the <see cref="MenuStrip"/>.
        /// </summary>
        public override Color MenuStripGradientEnd
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the <see cref="ToolStripOverflowButton"/>.
        /// </summary>
        public override Color OverflowButtonGradientBegin
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the end color of the gradient used in the <see cref="ToolStripOverflowButton"/>.
        /// </summary>
        public override Color OverflowButtonGradientEnd
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used in the <see cref="ToolStripOverflowButton"/>.
        /// </summary>
        public override Color OverflowButtonGradientMiddle
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the <see cref="ToolStripContainer"/>.
        /// </summary>
        public override Color RaftingContainerGradientBegin
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the end color of the gradient used in the <see cref="ToolStripContainer"/>.
        /// </summary>
        public override Color RaftingContainerGradientEnd
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the color to use to for shadow effects on the <see cref="ToolStripSeparator"/>.
        /// </summary>
        public override Color SeparatorDark
        {
            get { return _borderSeperatorDark; }
        }

        /// <summary>
        /// Gets the color to use to for highlight effects on the <see cref="ToolStripSeparator"/>.
        /// </summary>
        public override Color SeparatorLight
        {
            get { return _borderSeperatorLight; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used on the <see cref="StatusStrip"/>.
        /// </summary>
        public override Color StatusStripGradientBegin
        {
            get { return _backgroundStatus; }
        }

        /// <summary>
        /// Gets the end color of the gradient used on the <see cref="StatusStrip"/>.
        /// </summary>
        public override Color StatusStripGradientEnd
        {
            get { return _backgroundStatus; }
        }

        /// <summary>
        /// Gets the border color to use on the bottom edge of the <see cref="ToolStrip"/>.
        /// </summary>
        public override Color ToolStripBorder
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the <see cref="ToolStripContentPanel"/>.
        /// </summary>
        public override Color ToolStripContentPanelGradientBegin
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the end color of the gradient used in the <see cref="ToolStripContentPanel"/>.
        /// </summary>
        public override Color ToolStripContentPanelGradientEnd
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the solid background color of the <see cref="ToolStripDropDown"/>.
        /// </summary>
        public override Color ToolStripDropDownBackground
        {
            get { return _backgroundDropDown; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the <see cref="ToolStrip"/> background.
        /// </summary>
        public override Color ToolStripGradientBegin
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the end color of the gradient used in the <see cref="ToolStrip"/> background.
        /// </summary>
        public override Color ToolStripGradientEnd
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used in the <see cref="ToolStrip"/> background.
        /// </summary>
        public override Color ToolStripGradientMiddle
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the <see cref="ToolStripPanel"/>.
        /// </summary>
        public override Color ToolStripPanelGradientBegin
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the end color of the gradient used in the <see cref="ToolStripPanel"/>.
        /// </summary>
        public override Color ToolStripPanelGradientEnd
        {
            get { return _background; }
        }
    }
}
