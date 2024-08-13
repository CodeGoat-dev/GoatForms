using System;
using System.Windows.Forms;

namespace GoatForms
{
    public partial class ControlFactory
    {
        // Define internal variables
        internal static ControlStyle _style = new ControlStyle();
        internal static ToolTip toolTip = new ToolTip();

        // Internal method to apply layout types to form controls
        internal void ApplyLayoutStyle(Control parent, BaseForm.LayoutType layoutType)
        {
            if (layoutType == BaseForm.LayoutType.Flow)
            {
                parent.Controls.Clear();
                // parent.AutoScroll = true;
                parent.Dock = DockStyle.Fill;
            }
            else if (layoutType == BaseForm.LayoutType.Grid)
            {
                parent.Controls.Clear();
                var tableLayoutPanel = new TableLayoutPanel();
                tableLayoutPanel.Dock = DockStyle.Fill;
                tableLayoutPanel.AutoSize = true;
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

            if (styledControl)
            {
                control.BackColor = ControlFactory._style.BackColor;
                control.ForeColor = ControlFactory._style.ForeColor;
                control.Font = ControlFactory._style.Font;
            }

            container.Controls.Add(control);
        }

        // Internal method to add a control to a specific TabPage
        internal static void AddControlToTabPage(TabPage tabPage, Control control, bool styled)
        {
            if (tabPage == null)
            {
                throw new ArgumentNullException(nameof(tabPage));
            }

            if (styled == true)
            {
                control.BackColor = ControlFactory._style.BackColor;
                control.ForeColor = ControlFactory._style.ForeColor;
                control.Font = ControlFactory._style.Font;
            }

            tabPage.Controls.Add(control);
        }

        // Internal method to add a control to a specific Pannel
        internal static void AddControlToPanel(Panel panel, Control control, bool styled)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            if (styled == true)
            {
                control.BackColor = ControlFactory._style.BackColor;
                control.ForeColor = ControlFactory._style.ForeColor;
                control.Font = ControlFactory._style.Font;
            }

            panel.Controls.Add(control);
        }
    }
}
