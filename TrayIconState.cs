using System.Drawing;
using System.Windows.Forms;

namespace GoatForms
{
    // Internal class for storing system tray icon and menu states
    internal class TrayIconState
    {
        public Icon Icon { get; set; }
        public string Text { get; set; }
        public ContextMenuStrip ContextMenu { get; set; }
    }
}
