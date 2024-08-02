using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GoatForms
{
    /// <summary>
    /// Represents a base form that provides layout management and system tray icon support.
    /// </summary>
    public class BaseForm : Form
    {
        /// <summary>
        /// Defines the layout types for the form.
        /// </summary>
        public enum LayoutType
        {
            /// <summary>
            /// Flow layout where controls are arranged in a flow direction.
            /// </summary>
            Flow,

            /// <summary>
            /// Grid layout where controls are arranged in a grid.
            /// </summary>
            Grid
        }

        /// <summary>
        /// Gets the current layout type of the form.
        /// </summary>
        public LayoutType CurrentLayoutType { get; private set; }

        /// <summary>
        /// Gets the FlowLayoutPanel used for the Flow layout type.
        /// </summary>
        public FlowLayoutPanel FlowLayoutPanel { get; private set; }

        /// <summary>
        /// Gets the TableLayoutPanel used for the Grid layout type.
        /// </summary>
        public TableLayoutPanel GridLayoutPanel { get; private set; }

        /// <summary>
        /// Represents the system tray icon handle.
        /// </summary>
        internal NotifyIcon _trayIconHandle = null;

        /// <summary>
        /// Represents the context menu associated with the system tray icon.
        /// </summary>
        internal ContextMenuStrip _trayIconMenu = null;

        /// <summary>
        /// This is needed for form disposal, compilation warnings should be ignored.
        /// </summary>
        #pragma warning disable CS0649
        private IContainer components;
        #pragma warning restore CS0649

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseForm"/> class with specified parameters.
        /// </summary>
        /// <param name="title">The title of the form.</param>
        /// <param name="width">The width of the form.</param>
        /// <param name="height">The height of the form.</param>
        /// <param name="borderStyle">The border style of the form.</param>
        /// <param name="showIcon">Indicates whether to show the form's icon.</param>
        /// <param name="showInTaskbar">Indicates whether to show the form in the taskbar.</param>
        /// <param name="layoutType">The layout type of the form.</param>
        public BaseForm(string title = "New Form", int width = 800, int height = 600, FormBorderStyle borderStyle = FormBorderStyle.Sizable, bool showIcon = true, bool showInTaskbar = true, LayoutType layoutType = LayoutType.Flow)
        {
            Text = title;
            Width = width;
            Height = height;
            FormBorderStyle = borderStyle;
            Icon = showIcon ? SystemIcons.Application : null;
            ShowInTaskbar = showInTaskbar;

            CurrentLayoutType = layoutType;

            InitializeLayout();
        }

        /// <summary>
        /// Sets the layout type for the form.
        /// </summary>
        /// <param name="layoutType">The new layout type.</param>
        public void SetLayoutType(LayoutType layoutType)
        {
            if (CurrentLayoutType == layoutType)
                return;

            // Clear existing controls and layout panels
            Controls.Clear();

            // Reinitialize the layout and restore the system tray icon
            InitializeLayout();
            if (_trayIconHandle != null)
            {
                _trayIconHandle.Visible = true;
            }

            // Resize form to fit controls after changing layout
            ResizeFormToFitControls();
        }

        /// <summary>
        /// Creates or updates the system tray icon with the specified icon and context menu.
        /// </summary>
        /// <param name="icon">The icon to display in the system tray.</param>
        /// <param name="contextMenu">The context menu to associate with the tray icon.</param>
        internal void SetTrayIcon(Icon icon, ContextMenuStrip contextMenu = null)
        {
            // Dispose of the existing tray icon if it exists
            if (_trayIconHandle != null)
            {
                _trayIconHandle.Dispose();
            }

            // Create a new tray icon
            _trayIconHandle = new NotifyIcon
            {
                Icon = icon,
                Visible = true,
                ContextMenuStrip = contextMenu
            };

            // Save the context menu for potential future use
            _trayIconMenu = contextMenu != null ? CloneContextMenuStrip(contextMenu) : null;
        }

        /// <summary>
        /// Clones a <see cref="ContextMenuStrip"/> including its items.
        /// </summary>
        /// <param name="menuStrip">The context menu strip to clone.</param>
        /// <returns>A new <see cref="ContextMenuStrip"/> with the same items.</returns>
        /// <remarks>
        /// This method creates a copy of the <see cref="ContextMenuStrip"/> and all its items, ensuring that the cloned menu functions similarly to the original.
        /// </remarks>
        internal ContextMenuStrip CloneContextMenuStrip(ContextMenuStrip menuStrip)
        {
            var clonedMenuStrip = new ContextMenuStrip();

            foreach (ToolStripMenuItem item in menuStrip.Items.OfType<ToolStripMenuItem>())
            {
                clonedMenuStrip.Items.Add(CloneToolStripMenuItem(item));
            }

            return clonedMenuStrip;
        }

        /// <summary>
        /// Clones a <see cref="ToolStripMenuItem"/> including its sub-items.
        /// </summary>
        /// <param name="item">The menu item to clone.</param>
        /// <returns>A new <see cref="ToolStripMenuItem"/> with the same properties and sub-items.</returns>
        /// <remarks>
        /// This method creates a copy of the <see cref="ToolStripMenuItem"/> and its sub-items, preserving its text, image, and other properties.
        /// </remarks>
        internal ToolStripMenuItem CloneToolStripMenuItem(ToolStripMenuItem item)
        {
            var clone = new ToolStripMenuItem
            {
                Text = item.Text,
                Image = item.Image, // Copy the image if any
                Enabled = item.Enabled,
                Visible = item.Visible,
                ShortcutKeys = item.ShortcutKeys,
                ShortcutKeyDisplayString = item.ShortcutKeyDisplayString
            };

            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    clone.DropDownItems.Add(CloneToolStripMenuItem(subMenuItem));
                }
                else
                {
                    clone.DropDownItems.Add(subItem);
                }
            }

            return clone;
        }

        /// <summary>
        /// Resizes the form to fit the controls based on the current layout type.
        /// </summary>
        private void ResizeFormToFitControls()
        {
            if (CurrentLayoutType == LayoutType.Flow)
            {
                // Size the form based on the FlowLayoutPanel's preferred size
                var preferredSize = FlowLayoutPanel.PreferredSize;
                this.ClientSize = new Size(preferredSize.Width + 16, preferredSize.Height + 39); // Adding extra space for borders and title bar
            }
            else if (CurrentLayoutType == LayoutType.Grid)
            {
                // Size the form based on the TableLayoutPanel's preferred size
                var preferredSize = GridLayoutPanel.GetPreferredSize(new Size(GridLayoutPanel.Width, GridLayoutPanel.Height));
                this.ClientSize = new Size(preferredSize.Width + 16, preferredSize.Height + 39); // Adding extra space for borders and title bar
            }
        }

        /// <summary>
        /// Overrides the <see cref="Dispose(bool)"/> method to clean up form resources.
        /// </summary>
        /// <param name="disposing">Indicates whether the method is being called from the Dispose method.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of managed resources
                if (components != null)
                {
                    components.Dispose();
                }
                // Dispose of all child controls
                foreach (Control control in this.Controls)
                {
                    control.Dispose();
                }
                // Cleanup system tray icon
                if (_trayIconHandle != null)
                {
                    _trayIconHandle.Dispose();
                }
            }

            // Call base class Dispose
            base.Dispose(disposing);
        }

        // Internal method to initialize the layout of the form
        private void InitializeLayout()
        {
            if (CurrentLayoutType == LayoutType.Flow)
            {
                FlowLayoutPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };
                Controls.Add(FlowLayoutPanel);
            }
            else if (CurrentLayoutType == LayoutType.Grid)
            {
                GridLayoutPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    ColumnCount = 2, // Default column count
                    RowCount = 1 // Default row count
                };

                // Set default styles for columns and rows
                for (int i = 0; i < GridLayoutPanel.ColumnCount; i++)
                {
                    GridLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                }
                for (int i = 0; i < GridLayoutPanel.RowCount; i++)
                {
                    GridLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    Controls.Add(GridLayoutPanel);
                }
            }
        }

        /// <summary>
        /// Adds a control to the form with optional styling.
        /// </summary>
        /// <param name="control">The control to add to the form.</param>
        /// <param name="styled">Whether the control should be styled.</param>
        /// <remarks>
        /// If <paramref name="styled"/> is <see langword="true"/>, the control will be styled according to predefined settings. 
        /// If <paramref name="styled"/> is <see langword="false"/>, the control will be added without additional styling.
        /// </remarks>
        internal void AddControl(Control control, bool styled)
        {
            if (styled)
            {
                control.BackColor = ControlFactory._style.BackColor;
                control.ForeColor = ControlFactory._style.ForeColor;
                control.Font = ControlFactory._style.Font;
            }
            
            if (CurrentLayoutType == LayoutType.Flow)
            {
                FlowLayoutPanel.Controls.Add(control);
            }
            else if (CurrentLayoutType == LayoutType.Grid)
            {
                GridLayoutPanel.Controls.Add(control);
            }
        }
    }
}
