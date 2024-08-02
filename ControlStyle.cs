using System;
using System.Drawing;

namespace GoatForms
{
    /// <summary>
    /// Class for defining styles for styled control creation.
    /// </summary>
    public class ControlStyle
    {
        /// <summary>
        /// Gets or sets the background color of the control.
        /// </summary>
        /// <value>The default value is <see cref="Color.Transparent"/>.</value>
        public Color BackColor { get; set; } = Color.Transparent; // Default color

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The default value is <see cref="Color.Black"/>.</value>
        public Color ForeColor { get; set; } = Color.Black; // Default color

        /// <summary>
        /// Gets or sets the font of the control.
        /// </summary>
        /// <value>The default value is <see cref="SystemFonts.DefaultFont"/>.</value>
        public Font Font { get; set; } = SystemFonts.DefaultFont; // Default font

        // You can add additional style properties as needed
    }
}
