using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GoatForms
{
    public partial class ControlFactory
    {
        // Methods for adding controls to a GroupBox

        /// <summary>
        /// Creates and adds a <see cref="Label"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="Label"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="Label"/> control.</param>
        /// <param name="description">The description for the  <see cref="Label"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="Label"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="Label"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="Label"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static Label AddLabelToGroupBox(GroupBox groupBox, string text, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            Label label = new Label
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, label, styledControl);

            return label;
        }

        /// <summary>
        /// Creates and adds a <see cref="TextBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="TextBox"/> will be added.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="TextBox"/> control.</param>
        /// <param name="textBoxText">The default text to display in the <see cref="TextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="TextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TextBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TextBox AddTextBoxToGroupBox(GroupBox groupBox, string labelText, string textBoxText = "", string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            // Create the label
            Label label = AddLabelToGroupBox(groupBox, labelText, description, styledControl);

            // Create the text box
            TextBox textBox = new TextBox
            {
                Text = textBoxText,
                AccessibleName = labelText,
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, textBox, styledControl);

            return textBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="Button"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="Button"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="Button"/> control.</param>
        /// <param name="description">The description for the  <see cref="Button"/> control.</param>
        /// <param name="onClick">The <see chref="EventHandler"/> for the  <see cref="Button"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="Button"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="Button"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="Button"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static Button AddButtonToGroupBox(GroupBox groupBox, string text, string description = null, EventHandler onClick = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
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

            AddControlToGroupBox(groupBox, button, styledControl);

            return button;
        }

        /// <summary>
        /// Creates and adds a <see cref="CheckBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="CheckBox"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="CheckBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="CheckBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CheckBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CheckBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="CheckBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static CheckBox AddCheckBoxToGroupBox(GroupBox groupBox, string text, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            CheckBox checkBox = new CheckBox
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, checkBox, styledControl);

            return checkBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="RadioButton"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="RadioButton"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="RadioButton"/> control.</param>
        /// <param name="description">The description for the  <see cref="RadioButton"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="RadioButton"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="RadioButton"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="RadioButton"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static RadioButton AddRadioButtonToGroupBox(GroupBox groupBox, string text, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            RadioButton radioButton = new RadioButton
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, radioButton, styledControl);

            return radioButton;
        }

        /// <summary>
        /// Creates and adds a <see cref="ListBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="ListBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ListBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ListBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ListBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ListBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ListBox AddListBoxToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            ListBox listBox = new ListBox
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 150,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, listBox, styledControl);

            return listBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="CheckedListBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="CheckedListBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="CheckedListBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CheckedListBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CheckedListBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="CheckedListBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static CheckedListBox AddCheckedListBoxToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            CheckedListBox checkedListBox = new CheckedListBox
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 150,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, checkedListBox, styledControl);

            return checkedListBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="ListView"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="ListView"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ListView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ListView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ListView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ListView"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ListView AddListViewToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            ListView listView = new ListView
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 150,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, listView, styledControl);

            return listView;
        }

        /// <summary>
        /// Creates and adds a <see cref="ComboBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="ComboBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ComboBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ComboBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ComboBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ComboBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ComboBox AddComboBoxToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            ComboBox comboBox = new ComboBox
            {
                AccessibleDescription = description,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, comboBox, styledControl);

            return comboBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="TabControl"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="TabControl"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="TabControl"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TabControl"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TabControl"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TabControl"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TabControl AddTabControlToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            TabControl tabControl = new TabControl
            {
                AccessibleDescription = description,
                Width = 400,
                Height = 200,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, tabControl, styledControl);

            return tabControl;
        }

        /// <summary>
        /// Creates and adds a <see cref="DataGridView"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="DataGridView"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="DataGridView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="DataGridView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="DataGridView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="DataGridView"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static DataGridView AddDataGridViewToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            DataGridView dataGridView = new DataGridView
            {
                AccessibleDescription = description,
                Width = 400,
                Height = 200,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, dataGridView, styledControl);

            return dataGridView;
        }

        /// <summary>
        /// Creates and adds a <see cref="PictureBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="PictureBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="PictureBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="PictureBox"/> control should be styled.</param>
        /// <param name="imagePath">The path to an image file for the  <see cref="PictureBox"/> control.</param>
        /// <param name="imageData">The byte data of an image for the  <see cref="PictureBox"/> control.</param>
        /// <returns>A handle to the created <see cref="PictureBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="PictureBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static PictureBox AddPictureBoxToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false, string imagePath = null, byte[] imageData = null)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
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

            AddControlToGroupBox(groupBox, pictureBox, styledControl);

            return pictureBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="ProgressBar"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="ProgressBar"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ProgressBar"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ProgressBar"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ProgressBar"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ProgressBar"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ProgressBar AddProgressBarToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            ProgressBar progressBar = new ProgressBar
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 20,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, progressBar, styledControl);

            return progressBar;
        }

        /// <summary>
        /// Creates and adds a <see cref="DateTimePicker"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="DateTimePicker"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="DateTimePicker"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="DateTimePicker"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="DateTimePicker"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="DateTimePicker"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static DateTimePicker AddDateTimePickerToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            DateTimePicker dateTimePicker = new DateTimePicker
            {
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, dateTimePicker, styledControl);

            return dateTimePicker;
        }

        /// <summary>
        /// Creates and adds a <see cref="StatusBar"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="StatusBar"/> will be added.</param>
        /// <param name="text">The text to show on the  <see cref="StatusBar"/> control.</param>
        /// <param name="name">The accessible name for the  <see cref="StatusBar"/> control.</param>
        /// <param name="description">The description for the  <see cref="StatusBar"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="StatusBar"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="StatusBar"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="StatusBar"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static StatusBar AddStatusBarToGroupBox(GroupBox groupBox, string text = "", string name = null, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            StatusBar statusBar = new StatusBar{
                Text = text,
                AccessibleName = name,
                AccessibleDescription = description
            };

            AddControlToGroupBox(groupBox, statusBar, styledControl);

            return statusBar;
        }

        /// <summary>
        /// Creates and adds a <see cref="TrackBar"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="TrackBar"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="TrackBar"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TrackBar"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TrackBar"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TrackBar"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TrackBar AddTrackBarToGroupBox(GroupBox groupBox, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            TrackBar trackBar = new TrackBar
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 45,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, trackBar, styledControl);

            return trackBar;
        }

        /// <summary>
        /// Creates and adds a <see cref="GroupBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="GroupBox"/> will be added.</param>
        /// <param name="text">The text to show on the  <see cref="GroupBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="GroupBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="GroupBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="GroupBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="GroupBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static GroupBox AddGroupBoxToGroupBox(GroupBox groupBox, string text, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            GroupBox newGroupBox = new GroupBox
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, newGroupBox, styledControl);

            return newGroupBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="TreeView"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="TreeView"/> will be added.</param>
        /// <param name="name">The accessible name for the  <see cref="TreeView"/> control.</param>
        /// <param name="description">The description for the  <see cref="TreeView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TreeView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TreeView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TreeView"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TreeView AddTreeViewToGroupBox(GroupBox groupBox, string name = null, string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            TreeView treeView = new TreeView
            {
                AccessibleName = name,
                AccessibleDescription = description
            };

            AddControlToGroupBox(groupBox, treeView, styledControl);

            return treeView;
        }

        /// <summary>
        /// Creates and adds a <see cref="WebBrowser"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="WebBrowser"/> will be added.</param>
        /// <param name="url">The url for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="name">The name for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="description">The description for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="WebBrowser"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="WebBrowser"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="WebBrowser"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static WebBrowserControl AddWebBrowserControlToGroupBox(GroupBox groupBox, string url = "about:blank", string name = "Web Browser", string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            WebBrowserControl webBrowserControl = new WebBrowserControl
            {
                AccessibleName = name,
                AccessibleDescription = description,
                Dock = DockStyle.Fill,
                TabStop = true
            };

            webBrowserControl.Navigate(url);
            AddControlToGroupBox(groupBox, webBrowserControl, styledControl);

            return webBrowserControl;
        }

        /// <summary>
        /// Creates and adds a <see cref="RichTextBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="RichTextBox"/> will be added.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="RichTextBox"/> control.</param>
        /// <param name="richTextBoxText">The default text to display in the <see cref="RichTextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="RichTextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="RichTextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="RichTextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="RichTextBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static RichTextBox AddRichTextBoxToGroupBox(GroupBox groupBox, string labelText, string richTextBoxText = "", string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            // Create the label
            Label label = AddLabelToGroupBox(groupBox, labelText, description, styledControl);

            // Create the rich text box
            RichTextBox richTextBox = new RichTextBox
            {
                Text = richTextBoxText,
                AccessibleDescription = description,
                Width = 200,
                Height = 100,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, richTextBox, styledControl);

            return richTextBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="MaskedTextBox"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="MaskedTextBox"/> will be added.</param>
        /// <param name="mask">The mask to use for the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="maskedTextBoxText">The default text to display in the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="MaskedTextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="MaskedTextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="MaskedTextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="MaskedTextBox"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static MaskedTextBox AddMaskedTextBoxToGroupBox(GroupBox groupBox, string mask, string labelText, string maskedTextBoxText = "", string description = null, bool styledControl = false)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            // Create the label
            Label label = AddLabelToGroupBox(groupBox, labelText, description, styledControl);

            // Create the masked text box
            MaskedTextBox maskedTextBox = new MaskedTextBox
            {
                Text = maskedTextBoxText,
                Mask = mask,
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            AddControlToGroupBox(groupBox, maskedTextBox, styledControl);

            return maskedTextBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="ToolStrip"/> control to the specified group box.
        /// </summary>
        /// <param name="groupBox">The parent group box to which the <see cref="ToolStrip"/> will be added.</param>
        /// <param name="items">The list of <see chref="ToolStripItem"/> controls to add to the <see cref="ToolStrip"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStrip"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStrip"/> control with the specified properties and adds it to the specified group box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ToolStrip AddToolStripToGroupBox(GroupBox groupBox, params ToolStripItem[] items)
        {
            if (groupBox == null)
            {
                throw new ArgumentNullException(nameof(groupBox));
            }

            var toolStrip = new ToolStrip
            {
                Dock = DockStyle.Top // Default docking, you can change as needed
            };

            foreach (var item in items)
            {
                toolStrip.Items.Add(item);
            }

            AddControlToGroupBox(groupBox, toolStrip, false);

            return toolStrip;
        }
    }
}
