using System;
using System.Windows.Forms;

namespace GoatForms
{
    /// <summary>
    /// Represents a custom panel that supports both FlowLayoutPanel and Panel.
    /// </summary>
    public class CustomPanel : Panel
    {
        /// <summary>
        /// Represents the current panel layout type.
        /// </summary>
        public BaseForm.LayoutType LayoutType { get; set; }
    }
}
