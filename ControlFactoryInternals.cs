using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoatForms
{
    public partial class ControlFactory
    {
        // Define internal variables
        internal static ControlStyle _style = new ControlStyle();
        internal static ToolTip toolTip = new ToolTip();
        private static int _nextTop = 10; // Initial position for top margin
        private static int _nextLeft = 10; // Initial position for left margin
        private static int _spacing = 10; // Spacing between controls

        // Internal method to apply layout types to form controls
        internal void ApplyLayoutStyle(Control parent, BaseForm.LayoutType layoutType)
        {
            if (layoutType == BaseForm.LayoutType.Flow)
            {
                parent.Controls.Clear();
                parent.Dock = DockStyle.Fill;
            }
            else if (layoutType == BaseForm.LayoutType.Grid)
            {
                parent.Controls.Clear();
                var tableLayoutPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoSize = true
                };
                parent.Controls.Add(tableLayoutPanel);
            }
        }

        // Internal method to add a control to a specific GroupBox
        internal static void AddControlToGroupBox(GroupBox groupBox, Control control, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            // Find the panel inside the group box (either FlowLayoutPanel or Panel)
            Control container = groupBox.Controls[0];
            AddControlToContainer(container, control, styledControl);
        }

        // Internal method to add a control to a specific TabPage
        internal static void AddControlToTabPage(TabPage tabPage, Control control, bool styled = false)
        {
            if (tabPage == null)
            {
                throw new ArgumentNullException(nameof(tabPage));
            }

            AddControlToContainer(tabPage, control, styled);
        }

        // Internal method to add a control to a specific Panel
        internal static void AddControlToPanel(Panel panel, Control control, bool styled = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            AddControlToContainer(panel, control, styled);
        }

        // General method to handle control placement and styling in a container
        internal static void AddControlToContainer(Control container, Control control, bool styledControl)
        {
            if (styledControl)
            {
                control.BackColor = ControlFactory._style.BackColor;
                control.ForeColor = ControlFactory._style.ForeColor;
                control.Font = ControlFactory._style.Font;
            }

            // Position the control
            control.Location = new Point(_nextLeft, _nextTop);
            container.Controls.Add(control);

            // Update position for the next control
            _nextTop += control.Height + _spacing;
        }

        // Method to reset the layout for a new set of controls
        internal static void ResetLayout()
        {
            _nextTop = 10; // Reset the top position
            _nextLeft = 10; // Reset the left position
        }
    }
}
