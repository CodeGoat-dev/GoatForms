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

            ResizeGroupBoxToFitControls(groupBox);
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

            if (panel is FlowLayoutPanel || panel is Panel)
            {
                ResizePanelToFitControls(panel);
            }
        }

        // Internal method to resize a GroupBox to fit controls
        internal static void ResizeGroupBoxToFitControls(GroupBox groupBox)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            // Ensure that there are controls inside the GroupBox
            if (groupBox.Controls.Count == 0)
            {
                return;
            }

            // Get the container control (either FlowLayoutPanel or Panel)
            Control container = groupBox.Controls[0];
    
            // Calculate the desired size based on the contained controls
            int width = container.Width;
            int height = container.Height;
    
            foreach (Control control in container.Controls)
            {
                // Calculate the bottom and right edge of the controls
                int bottom = control.Bottom;
                int right = control.Right;
        
                if (bottom > height)
                {
                    height = bottom;
                }
                if (right > width)
                {
                    width = right;
                }
            }

            // Set the size of the GroupBox to fit its contained controls
            groupBox.AutoSize = false;
            groupBox.AutoSizeMode = AutoSizeMode.GrowOnly; // Or other desired AutoSizeMode
            groupBox.Width = width;
            groupBox.Height = height;
        }

        // Internal method to resize a Panel to fit controls
        internal static void ResizePanelToFitControls(Panel panel)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            // Ensure that there are controls inside the Panel
            if (panel.Controls.Count == 0)
            {
                return;
            }

            // Calculate the desired size based on the contained controls
            int width = panel.Width;
            int height = panel.Height;

            foreach (Control control in panel.Controls)
            {
                // Calculate the bottom and right edge of the controls
                int bottom = control.Bottom;
                int right = control.Right;

                if (bottom > height)
                {
                    height = bottom;
                }
                if (right > width)
                {
                    width = right;
                }
            }

            // Set the size of the Panel to fit its contained controls
            panel.AutoSize = false;
            panel.AutoSizeMode = AutoSizeMode.GrowOnly; // Or other desired AutoSizeMode
            panel.Width = width;
            panel.Height = height;
        }
    }
}
