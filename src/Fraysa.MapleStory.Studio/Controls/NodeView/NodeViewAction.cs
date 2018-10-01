namespace Fraysa.MapleStory.Studio.Controls.NodeView
{
    /// <summary>
    /// Specifies the action that raised a <see cref="NodeViewEventArgs"/> event.
    /// </summary>
    public enum NodeViewAction
    {
        /// <summary>
        /// The action that caused the event is unknown.
        /// </summary>
        Unknown = 0,
        
        /// <summary>
        /// The event was caused by a keystroke.
        /// </summary>
        ByKeyboard = 1,
        
        /// <summary>
        /// The event was caused by a mouse operation.
        /// </summary>
        ByMouse = 2,
        
        /// <summary>
        /// The event was caused by the <see cref="Node"/> collapsing.
        /// </summary>
        Collapse = 3,
        
        /// <summary>
        /// The event was caused by the <see cref="Node"/> expanding.
        /// </summary>
        Expand = 4
    }
}
