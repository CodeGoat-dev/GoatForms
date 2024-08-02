using System;
using System.Windows.Forms;

namespace GoatForms
{
    public partial class ControlFactory
    {
        // Define internal variables
        internal static ControlStyle _style = new ControlStyle();
        internal static ToolTip toolTip = new ToolTip();

        // Internal method to add a control to a specific TabPage
        internal static void AddControlToTabPage(TabPage tabPage, Control control, bool styled)
        {
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
