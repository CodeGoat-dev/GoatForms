using System;
using System.Windows.Forms;

namespace GoatForms
{
    /// <summary>
    /// Represents a custom group box that supports both FlowLayoutPanel and Panel.
    /// </summary>
    public class CustomGroupBox : GroupBox
    {
        /// <summary>
        /// Represents the current group box layout type.
        /// </summary>
        public BaseForm.LayoutType LayoutType { get; set; }
    }
}
