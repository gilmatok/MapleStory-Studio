using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio.Controls
{
    /// <summary>
    /// Represents a collection of methods of native / WinAPI libraries.
    /// </summary>
    internal static class NativeMethods
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        private const int SUCCESS = 0x00000000;

        // ---- ENUMERATIONS -------------------------------------------------------------------------------------------

        internal enum PrintFlags : uint
        {
            Client = 0x00000004
        }

        /// <summary>
        /// The TVS_EX_* constants.
        /// </summary>
        [Flags]
        internal enum TreeViewStyleExtended : uint
        {
            /// <summary>
            /// The TVS_EX_MULTISELECT constant.
            /// </summary>
            MultiSelect = 0x00000002,

            /// <summary>
            /// The TVS_EX_DOUBLEBUFFER constant.
            /// </summary>
            DoubleBuffer = 0x00000004,

            /// <summary>
            /// The TVS_EX_NOINDENTSATE constant.
            /// </summary>
            NoIndentState = 0x00000008,

            /// <summary>
            /// The TVS_EX_RICHTOOLTIP constant.
            /// </summary>
            RichToolTip = 0x00000010,

            /// <summary>
            /// The TVS_EX_AUTOHSCROLL constant.
            /// </summary>
            AutoHScroll = 0x00000020,

            /// <summary>
            /// The TVS_EX_FADEINOUTEXPANDOS constant.
            /// </summary>
            FadeInOutExpandos = 0x00000040,

            /// <summary>
            /// The TVS_EX_PARTIALCHECKBOXES constant.
            /// </summary>
            PartialCheckBoxes = 0x00000080,

            /// <summary>
            /// The TVS_EX_EXCLUSIONCHECKBOXES constant.
            /// </summary>
            ExclusionCheckBoxes = 0x00000100,

            /// <summary>
            /// The TVS_EX_DIMMEDCHECKBOXES constant.
            /// </summary>
            DimmedCheckBoxes = 0x00000200,

            /// <summary>
            /// The TVS_EX_DRAWIMAGEASYNC constant.
            /// </summary>
            DrawImageAsync = 0x00000400
        }

        /// <summary>
        /// Messages defined by Windows.
        /// </summary>
        /// <remarks>Native constants: WM_*</remarks>
        internal enum WindowsMessage : uint
        {
            /// <summary>
            /// The WM_CHANGEUISTATE message.
            /// </summary>
            ChangeUIState = 0x00000127,

            /// <summary>
            /// The WM_PRINTCLIENT message.
            /// </summary>
            PrintClient = 0x00000318,
        }

        private enum UIState : uint
        {
            HideFocus = 0x00000001,
            Set = 0x00000001
        }

        // ---- METHODS (INTERNAL) -------------------------------------------------------------------------------------

        /// <summary>
        /// Applies visual styles on the specified control.
        /// </summary>
        /// <param name="control">The control on which visual styles are applied.</param>
        internal static void ApplyVisualStyles(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            int hResult = SetWindowTheme(control.Handle, "explorer", null);
            if (hResult != SUCCESS)
            {
                throw new Win32Exception(hResult, "SetWindowTheme");
            }
        }

        /// <summary>
        /// Hides the dotted focus rectangle in the given <see cref="Control"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> for which the focus rectangle will be hidden.</param>
        internal static void MakeFocusInvisible(Control control)
        {
            NativeMethods.SendMessage(control.Handle, (uint)WindowsMessage.ChangeUIState,
                new IntPtr(MAKELONG((int)UIState.Set, (int)UIState.HideFocus)), IntPtr.Zero);
        }

        /// <summary>
        /// Sends the specified message to a window or windows. The function calls the window procedure for the
        /// specified window and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wParam">First additional message-specific information.</param>
        /// <param name="lParam">Second additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.
        ///     </returns>
        internal static IntPtr SendWindowsMessage(IntPtr handle, uint message, IntPtr wParam, IntPtr lParam)
        {
            return NativeMethods.SendMessage(handle, message, wParam, lParam);
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private static int MAKELONG(int wLow, int wHigh)
        {
            int low = (int)LOWORD(wLow);
            short high = LOWORD(wHigh);
            int product = 0x00010000 * (int)high;
            int makeLong = (int)(low | product);
            return makeLong;
        }

        private static short LOWORD(int dw)
        {
            short loWord = 0;
            ushort andResult = (ushort)(dw & 0x00007FFF);
            ushort mask = 0x8000;
            if ((dw & 0x8000) != 0)
            {
                loWord = (short)(mask | andResult);
            }
            else
            {
                loWord = (short)andResult;
            }
            return loWord;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int SetWindowTheme(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)]string pszSubAppName,
            [MarshalAs(UnmanagedType.LPWStr)]string pszSubIdList);
    }
}
