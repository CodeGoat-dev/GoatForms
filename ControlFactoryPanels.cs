using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GoatForms
{
    public partial class ControlFactory
    {
        // Methods for adding controls to Panels

        /// <summary>
        /// Creates and adds a <see cref="Label"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="Label"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="Label"/> control.</param>
        /// <param name="description">The description for the  <see cref="Label"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="Label"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="Label"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="Label"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static Label AddLabelToPanel(Panel panel, string text, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            Label label = new Label
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            AddControlToPanel(panel, label, styledControl);

            return label;
        }

        /// <summary>
        /// Creates and adds a <see cref="TextBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="TextBox"/> will be added.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="TextBox"/> control.</param>
        /// <param name="textBoxText">The default text to display in the <see cref="TextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="TextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TextBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TextBox AddTextBoxToPanel(Panel panel, string labelText, string textBoxText = "", string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            // Create the label
            Label label = AddLabelToPanel(panel, labelText, description, styledControl);

            // Create the text box
            TextBox textBox = new TextBox
            {
                Text = textBoxText,
                AccessibleName = labelText,
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            AddControlToPanel(panel, textBox, styledControl);

            return textBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="Button"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="Button"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="Button"/> control.</param>
        /// <param name="description">The description for the  <see cref="Button"/> control.</param>
        /// <param name="onClick">The <see chref="EventHandler"/> for the  <see cref="Button"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="Button"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="Button"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="Button"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static Button AddButtonToPanel(Panel panel, string text, string description = null, EventHandler onClick = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            Button button = new Button
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            if (onClick != null)
            {
                button.Click += onClick;
            }

            AddControlToPanel(panel, button, styledControl);

            return button;
        }

        /// <summary>
        /// Creates and adds a <see cref="CheckBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="CheckBox"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="CheckBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="CheckBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CheckBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CheckBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="CheckBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static CheckBox AddCheckBoxToPanel(Panel panel, string text, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            CheckBox checkBox = new CheckBox
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            AddControlToPanel(panel, checkBox, styledControl);

            return checkBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="RadioButton"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="RadioButton"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="RadioButton"/> control.</param>
        /// <param name="description">The description for the  <see cref="RadioButton"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="RadioButton"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="RadioButton"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="RadioButton"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static RadioButton AddRadioButtonToPanel(Panel panel, string text, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            RadioButton radioButton = new RadioButton
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            AddControlToPanel(panel, radioButton, styledControl);

            return radioButton;
        }

        /// <summary>
        /// Creates and adds a <see cref="ListBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="ListBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ListBox"/> control.</param>
        /// <param name="onSelectedIndexChanged">The selection changed <see chref="EventHandler"/> for the  <see cref="ListBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ListBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ListBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ListBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ListBox AddListBoxToPanel(Panel panel, string description = null, EventHandler onSelectedIndexChanged = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            ListBox listBox = new ListBox
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 150,
                TabStop = true
            };

            if (onSelectedIndexChanged != null)
            {
                listBox.SelectedIndexChanged += onSelectedIndexChanged;
            }

            AddControlToPanel(panel, listBox, styledControl);

            return listBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="CheckedListBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="CheckedListBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="CheckedListBox"/> control.</param>
        /// <param name="onSelectedIndexChanged">The selection changed <see chref="EventHandler"/> for the  <see cref="CheckedListBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CheckedListBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CheckedListBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="CheckedListBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static CheckedListBox AddCheckedListBoxToPanel(Panel panel, string description = null, EventHandler onSelectedIndexChanged = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            CheckedListBox checkedListBox = new CheckedListBox
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 150,
                TabStop = true
            };

            if (onSelectedIndexChanged != null)
            {
                checkedListBox.SelectedIndexChanged += onSelectedIndexChanged;
            }

            AddControlToPanel(panel, checkedListBox, styledControl);

            return checkedListBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="ListView"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="ListView"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ListView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ListView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ListView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ListView"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ListView AddListViewToPanel(Panel panel, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            ListView listView = new ListView
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 150,
                TabStop = true
            };

            AddControlToPanel(panel, listView, styledControl);

            return listView;
        }

        /// <summary>
        /// Creates and adds a <see cref="ComboBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="ComboBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ComboBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ComboBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ComboBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ComboBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ComboBox AddComboBoxToPanel(Panel panel, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            ComboBox comboBox = new ComboBox
            {
                AccessibleDescription = description,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                TabStop = true
            };

            AddControlToPanel(panel, comboBox, styledControl);

            return comboBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="CustomGroupBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="CustomGroupBox"/> will be added.</param>
        /// <param name="text">The text for the  <see cref="CustomGroupBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="CustomGroupBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CustomGroupBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CustomGroupBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="CustomGroupBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static CustomGroupBox AddGroupBoxToPanel(CustomPanel panel, string text, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            CustomGroupBox groupBox = new CustomGroupBox
            {
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                TabStop = true
            };

            switch (panel.LayoutType)
            {
                case BaseForm.LayoutType.Flow:
                    var flowPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
                    groupBox.Controls.Add(flowPanel);
                    break;
                case BaseForm.LayoutType.Grid:
                    var newPanel = new Panel { Dock = DockStyle.Fill, AutoSize = false, AutoScroll = true };
                    groupBox.Controls.Add(newPanel);
                    break;
                default:
                    throw new ArgumentException("Unsupported layout type", nameof(panel.LayoutType));
            }

            groupBox.LayoutType = panel.LayoutType;

            AddControlToPanel(panel, groupBox, styledControl);

            return groupBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="TabControl"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="TabControl"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="TabControl"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TabControl"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TabControl"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TabControl"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TabControl AddTabControlToPanel(Panel panel, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            TabControl tabControl = new TabControl
            {
                AccessibleDescription = description,
                Width = 400,
                Height = 200,
                TabStop = true
            };

            AddControlToPanel(panel, tabControl, styledControl);

            return tabControl;
        }

        /// <summary>
        /// Creates and adds a <see cref="DataGridView"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="DataGridView"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="DataGridView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="DataGridView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="DataGridView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="DataGridView"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static DataGridView AddDataGridViewToPanel(Panel panel, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            DataGridView dataGridView = new DataGridView
            {
                AccessibleDescription = description,
                Width = 400,
                Height = 200,
                TabStop = true
            };

            AddControlToPanel(panel, dataGridView, styledControl);

            return dataGridView;
        }

        /// <summary>
        /// Creates and adds a <see cref="PictureBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="PictureBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="PictureBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="PictureBox"/> control should be styled.</param>
        /// <param name="imagePath">The path to an image file for the  <see cref="PictureBox"/> control.</param>
        /// <param name="imageData">The byte data of an image for the  <see cref="PictureBox"/> control.</param>
        /// <returns>A handle to the created <see cref="PictureBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="PictureBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static PictureBox AddPictureBoxToPanel(Panel panel, string description = null, bool styledControl = false, string imagePath = null, byte[] imageData = null)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            PictureBox pictureBox = new PictureBox
            {
                AccessibleDescription = description,
                Width = 100,
                Height = 100,
                TabStop = true
            };

            // Set image if imagePath or imageData is provided
            if (imagePath != null)
            {
                try
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Error loading image from file '{imagePath}': {ex.Message}", ex);
                }
            }
            else if (imageData != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error loading image from byte array.", ex);
                }
            }

            AddControlToPanel(panel, pictureBox, styledControl);

            return pictureBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="ProgressBar"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="ProgressBar"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ProgressBar"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ProgressBar"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ProgressBar"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ProgressBar"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ProgressBar AddProgressBarToPanel(Panel panel, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            ProgressBar progressBar = new ProgressBar
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 20,
                TabStop = true
            };

            AddControlToPanel(panel, progressBar, styledControl);

            return progressBar;
        }

        /// <summary>
        /// Creates and adds a <see cref="DateTimePicker"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="DateTimePicker"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="DateTimePicker"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="DateTimePicker"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="DateTimePicker"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="DateTimePicker"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static DateTimePicker AddDateTimePickerToPanel(Panel panel, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            DateTimePicker dateTimePicker = new DateTimePicker
            {
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            AddControlToPanel(panel, dateTimePicker, styledControl);

            return dateTimePicker;
        }

        /// <summary>
        /// Creates and adds a status control (either <see cref="StatusBar"/> or <see cref="StatusStrip"/> depending on the framework) to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the status control will be added.</param>
        /// <param name="text">The text to show on the status control.</param>
        /// <param name="name">The accessible name for the status control.</param>
        /// <param name="description">The description for the status control.</param>
        /// <param name="styledControl">Whether the status control should be styled.</param>
        /// <returns>A handle to the created status control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a status control with the specified properties and adds it to the specified panel.
        /// </remarks>
        public static Control AddStatusBarToPanel(Panel panel, string text = "", string name = null, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            #if NET48
            // .NET Framework 4.8 and earlier - Use StatusBar
            StatusBar statusBar = new StatusBar
            {
                Text = text,
                AccessibleName = name,
                AccessibleDescription = description
            };
            AddControlToPanel(panel, statusBar, styledControl);
            return (StatusBar)statusBar;
            #else
            // .NET Core and later - Use StatusStrip
            StatusStrip statusStrip = new StatusStrip
            {
                Text = text,
                AccessibleName = name,
                AccessibleDescription = description
            };
            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel
            {
                Text = text,
                AccessibleName = name,
                AccessibleDescription = description
            };
            statusStrip.Items.Add(statusLabel);
            AddControlToPanel(panel, statusStrip, styledControl);
            return (StatusStrip)statusStrip;
            #endif
        }

        /// <summary>
        /// Creates and adds a <see cref="TrackBar"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="TrackBar"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="TrackBar"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TrackBar"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TrackBar"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TrackBar"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TrackBar AddTrackBarToPanel(Panel panel, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            TrackBar trackBar = new TrackBar
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 45,
                TabStop = true
            };

            AddControlToPanel(panel, trackBar, styledControl);

            return trackBar;
        }

        /// <summary>
        /// Creates and adds a <see cref="Panel"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="Panel"/> will be added.</param>
        /// <param name="text">The text to show on the  <see cref="Panel"/> control.</param>
        /// <param name="description">The description for the  <see cref="Panel"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="Panel"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="Panel"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="Panel"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static CustomPanel AddPanelToPanel(CustomPanel panel, string text, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            CustomPanel newPanel = new CustomPanel();

            switch (panel.LayoutType)
            {
                case BaseForm.LayoutType.Flow:
                    newPanel = new CustomPanel { Dock = DockStyle.Top, AutoSize = true };
                    break;
                case BaseForm.LayoutType.Grid:
                    newPanel = new CustomPanel { Dock = DockStyle.Top, AutoSize = false, AutoScroll = true };
                    break;
            }

            newPanel.AccessibleName = text;
            newPanel.AccessibleDescription = description;
            newPanel.AutoSize = true;
            newPanel.TabStop = true;

            newPanel.LayoutType = panel.LayoutType;

            AddControlToPanel(panel, newPanel, styledControl);

            return newPanel;
        }

        /// <summary>
        /// Creates and adds a <see cref="TreeView"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="TreeView"/> will be added.</param>
        /// <param name="name">The accessible name for the  <see cref="TreeView"/> control.</param>
        /// <param name="description">The description for the  <see cref="TreeView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TreeView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TreeView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TreeView"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TreeView AddTreeViewToPanel(Panel panel, string name = null, string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            TreeView treeView = new TreeView
            {
                AccessibleName = name,
                AccessibleDescription = description
            };

            AddControlToPanel(panel, treeView, styledControl);

            return treeView;
        }

        /// <summary>
        /// Creates and adds a <see cref="WebBrowser"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="WebBrowser"/> will be added.</param>
        /// <param name="url">The url for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="name">The name for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="description">The description for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="WebBrowser"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="WebBrowser"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="WebBrowser"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static WebBrowserControl AddWebBrowserControlToPanel(Panel panel, string url = "about:blank", string name = "Web Browser", string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            WebBrowserControl webBrowserControl = new WebBrowserControl
            {
                AccessibleName = name,
                AccessibleDescription = description,
                Dock = DockStyle.Fill,
                TabStop = true
            };

            webBrowserControl.Navigate(url);
            AddControlToPanel(panel, webBrowserControl, styledControl);

            return webBrowserControl;
        }

        /// <summary>
        /// Creates and adds a <see cref="RichTextBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="RichTextBox"/> will be added.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="RichTextBox"/> control.</param>
        /// <param name="richTextBoxText">The default text to display in the <see cref="RichTextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="RichTextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="RichTextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="RichTextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="RichTextBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static RichTextBox AddRichTextBoxToPanel(Panel panel, string labelText, string richTextBoxText = "", string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            // Create the label
            Label label = AddLabelToPanel(panel, labelText, description, styledControl);

            // Create the rich text box
            RichTextBox richTextBox = new RichTextBox
            {
                Text = richTextBoxText,
                AccessibleDescription = description,
                Width = 200,
                Height = 100,
                TabStop = true
            };

            AddControlToPanel(panel, richTextBox, styledControl);

            return richTextBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="MaskedTextBox"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="MaskedTextBox"/> will be added.</param>
        /// <param name="mask">The mask to use for the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="maskedTextBoxText">The default text to display in the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="MaskedTextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="MaskedTextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="MaskedTextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="MaskedTextBox"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static MaskedTextBox AddMaskedTextBoxToPanel(Panel panel, string mask, string labelText, string maskedTextBoxText = "", string description = null, bool styledControl = false)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            // Create the label
            Label label = AddLabelToPanel(panel, labelText, description, styledControl);

            // Create the masked text box
            MaskedTextBox maskedTextBox = new MaskedTextBox
            {
                Text = maskedTextBoxText,
                Mask = mask,
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            AddControlToPanel(panel, maskedTextBox, styledControl);

            return maskedTextBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="ToolStrip"/> control to the specified panel.
        /// </summary>
        /// <param name="panel">The parent panel to which the <see cref="ToolStrip"/> will be added.</param>
        /// <param name="items">The list of <see chref="ToolStripItem"/> controls to add to the <see cref="ToolStrip"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStrip"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStrip"/> control with the specified properties and adds it to the specified panel. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ToolStrip AddToolStripToPanel(Panel panel, params ToolStripItem[] items)
        {
            if (panel == null)
            {
                throw new ArgumentNullException(nameof(panel));
            }

            var toolStrip = new ToolStrip
            {
                Dock = DockStyle.Top // Default docking, you can change as needed
            };

            foreach (var item in items)
            {
                toolStrip.Items.Add(item);
            }

            AddControlToPanel(panel, toolStrip, false);

            return toolStrip;
        }
    }
}
