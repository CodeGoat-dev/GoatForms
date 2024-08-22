using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GoatForms
{
    /// <summary>
    /// Facilitates the creation and automatic addition of form controls to a form.
    /// </summary>
    /// <remarks>
    /// This class creates form controls and adds them to your forms with no layout or size coordinates required. 
    /// Most methods in this class return a handle to the created control to enable further manipulation outside of GoatForms. 
    /// See the BaseForm class to learn how to define forms.
        /// </remarks>
    public partial class ControlFactory
    {
        /// <summary>
        /// Sets a <see cref="ControlStyle"/> to be applied to all styled form controls.
        /// </summary>
        /// <param name="style">The <see cref="ControlStyle"/> to apply.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="style"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method sets the style for all styled controls created using ControlFactory. First define a <see cref="ControlStyle"/> using the ControlStyle class. 
        /// If the control style is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void SetStyle(ControlStyle style)
        {
            _style = style ?? throw new ArgumentNullException(nameof(style));
        }

        // Standard Methods to add controls to forms

        /// <summary>
        /// Creates and adds a <see cref="Label"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="Label"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="Label"/> control.</param>
        /// <param name="description">The description for the  <see cref="Label"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="Label"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="Label"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="Label"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static Label AddLabel(BaseForm form, string text, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            Label label = new Label
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            form.AddControl(label, styledControl);

            return label;
        }

        /// <summary>
        /// Creates and adds a <see cref="TextBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="TextBox"/> will be added.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="TextBox"/> control.</param>
        /// <param name="textBoxText">The default text to display in the <see cref="TextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="TextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TextBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TextBox AddTextBox(BaseForm form, string labelText, string textBoxText = "", string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            // Create the label
            Label label = AddLabel(form, labelText, description, styledControl);

            // Create the text box
            TextBox textBox = new TextBox
            {
                Text = textBoxText,
                AccessibleName = labelText,
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            form.AddControl(textBox, styledControl);

            return textBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="Button"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="Button"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="Button"/> control.</param>
        /// <param name="description">The description for the  <see cref="Button"/> control.</param>
        /// <param name="onClick">The <see chref="EventHandler"/> for the  <see cref="Button"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="Button"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="Button"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="Button"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static Button AddButton(BaseForm form, string text, string description = null, EventHandler onClick = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
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

            form.AddControl(button, styledControl);

            return button;
        }

        /// <summary>
        /// Creates and adds a <see cref="CheckBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="CheckBox"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="CheckBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="CheckBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CheckBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CheckBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="CheckBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static CheckBox AddCheckBox(BaseForm form, string text, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            CheckBox checkBox = new CheckBox
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            form.AddControl(checkBox, styledControl);

            return checkBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="RadioButton"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="RadioButton"/> will be added.</param>
        /// <param name="text">The text to display on the <see cref="RadioButton"/> control.</param>
        /// <param name="description">The description for the  <see cref="RadioButton"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="RadioButton"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="RadioButton"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="RadioButton"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static RadioButton AddRadioButton(BaseForm form, string text, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            RadioButton radioButton = new RadioButton
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            form.AddControl(radioButton, styledControl);

            return radioButton;
        }

        /// <summary>
        /// Creates and adds a <see cref="ListBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="ListBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ListBox"/> control.</param>
        /// <param name="onSelectedIndexChanged">The selection changed <see chref="EventHandler"/> for the  <see cref="ListBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ListBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ListBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ListBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ListBox AddListBox(BaseForm form, string description = null, EventHandler onSelectedIndexChanged = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
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

            form.AddControl(listBox, styledControl);

            return listBox;
        }

        /// <summary>
        /// Creates and adds a list box item to the specified list box.
        /// </summary>
        /// <param name="listBox">The parent list box to which the list box item will be added.</param>
        /// <param name="itemText">The text to display on the list box item.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="listBox"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemText"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a list box item with the specified properties and adds it to the specified list box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the item text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static void AddListBoxItem(ListBox listBox, string itemText)
        {
            if (listBox == null)
            {
                throw new ArgumentNullException(nameof(listBox));
            }

            listBox.Items.Add(itemText);
        }

        /// <summary>
        /// Creates and adds a <see cref="CheckedListBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="CheckedListBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="CheckedListBox"/> control.</param>
        /// <param name="onSelectedIndexChanged">The selection changed <see chref="EventHandler"/> for the  <see cref="CheckedListBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CheckedListBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CheckedListBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="CheckedListBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static CheckedListBox AddCheckedListBox(BaseForm form, string description = null, EventHandler onSelectedIndexChanged = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
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

            form.AddControl(checkedListBox, styledControl);

            return checkedListBox;
        }

        /// <summary>
        /// Creates and adds a checked list box item to the specified checked list box.
        /// </summary>
        /// <param name="checkedListBox">The parent checked list box to which the checked list box item will be added.</param>
        /// <param name="itemText">The text to display on the checked list box item.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="checkedListBox"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemText"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a checked list box item with the specified properties and adds it to the specified checked list box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the item text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static void AddCheckedListBoxItem(CheckedListBox checkedListBox, string itemText)
        {
            if (checkedListBox == null)
            {
                throw new ArgumentNullException(nameof(checkedListBox));
            }

            checkedListBox.Items.Add(itemText);
        }

        /// <summary>
        /// Creates and adds a <see cref="ListView"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="ListView"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ListView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ListView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ListView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ListView"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ListView AddListView(BaseForm form, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            ListView listView = new ListView
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 150,
                TabStop = true
            };

            form.AddControl(listView, styledControl);

            return listView;
        }

        /// <summary>
        /// Creates and adds a <see cref="ListViewItem"/> control to the specified form.
        /// </summary>
        /// <param name="listView">The parent list view to which the <see cref="ListViewItem"/> will be added.</param>
        /// <param name="itemText">The text to display on the <see cref="ListViewItem"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ListViewItem"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ListViewItem"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="listView"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemText"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="ListViewItem"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the item text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static ListViewItem AddListViewItem(ListView listView, string itemText, bool styledControl = false)
        {
            if (listView == null)
            {
                throw new ArgumentNullException(nameof(listView));
            }

            ListViewItem listViewItem = new ListViewItem(itemText);

            if (styledControl == true)
            {
                listViewItem.BackColor = _style.BackColor;
                listViewItem.ForeColor = _style.ForeColor;
                listViewItem.Font = _style.Font;
            }

            listView.Items.Add(listViewItem);

            return listViewItem;
        }

        /// <summary>
        /// Creates and adds a <see cref="ListViewItem.ListViewSubItem"/> control to the specified list view item.
        /// </summary>
        /// <param name="listViewItem">The parent list view item to which the <see cref="ListViewItem.ListViewSubItem"/> will be added.</param>
        /// <param name="subItemText">The text to display on the <see cref="ListViewItem.ListViewSubItem"/> control.</param>
        /// <returns>A handle to the created <see cref="ListViewItem.ListViewSubItem"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="listViewItem"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="subItemText"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a <see cref="ListViewItem.ListViewSubItem"/> control with the specified properties and adds it to the specified list view item. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the sub item text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static ListViewItem.ListViewSubItem AddListViewSubItem(ListViewItem listViewItem, string subItemText)
        {
            if (listViewItem == null)
            {
                throw new ArgumentNullException(nameof(listViewItem));
            }

            ListViewItem.ListViewSubItem listViewSubItem = new ListViewItem.ListViewSubItem
            {
                Text = subItemText
            };

            listViewItem.SubItems.Add(listViewSubItem);

            return listViewSubItem;
        }

        /// <summary>
        /// Creates and adds a <see cref="ComboBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="ComboBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ComboBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ComboBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ComboBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ComboBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ComboBox AddComboBox(BaseForm form, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            ComboBox comboBox = new ComboBox
            {
                AccessibleDescription = description,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                TabStop = true
            };

            form.AddControl(comboBox, styledControl);

            return comboBox;
        }

        /// <summary>
        /// Creates and adds a combo box item to the specified combo box.
        /// </summary>
        /// <param name="comboBox">The parent combo box to which the combo box item will be added.</param>
        /// <param name="itemText">The text to display on the combo box item.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="comboBox"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="itemText"/> is <see langword="null"/> or empty.</exception>
        /// <remarks>
        /// This method creates a combo box item with the specified properties and adds it to the specified combo box. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// If the item text is <see langword="null"/> or empty, an <see cref="ArgumentException"/> will be thrown. 
        /// </remarks>
        public static void AddComboBoxItem(ComboBox comboBox, string itemText)
        {
            if (comboBox == null)
            {
                throw new ArgumentNullException(nameof(comboBox));
            }

            if (string.IsNullOrWhiteSpace(itemText))
            {
                throw new ArgumentException("Item text cannot be null or empty.", nameof(itemText));
            }

            comboBox.Items.Add(itemText);
        }

        /// <summary>
        /// Creates and adds a key-value pair item to the specified combo box.
        /// </summary>
        /// <param name="comboBox">The parent combo box to which the combo box item will be added.</param>
        /// <param name="key">The display text for the combo box item.</param>
        /// <param name="value">The value associated with the combo box item.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="comboBox"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="key"/> is <see langword="null"/> or empty.</exception>
        public static void AddComboBoxItem(ComboBox comboBox, string key, int value)
        {
            if (comboBox == null)
            {
                throw new ArgumentNullException(nameof(comboBox));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            }

            // Add the key-value pair as a KeyValuePair object to the combo box
            comboBox.Items.Add(new KeyValuePair<string, int>(key, value));

            // Set the DisplayMember and ValueMember properties if they are not already set
            if (string.IsNullOrEmpty(comboBox.DisplayMember))
            {
                comboBox.DisplayMember = "Key";
            }

            if (string.IsNullOrEmpty(comboBox.ValueMember))
            {
                comboBox.ValueMember = "Value";
            }
        }

        /// <summary>
        /// Creates and adds a <see cref="CustomGroupBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="CustomGroupBox"/> will be added.</param>
        /// <param name="text">The text for the  <see cref="CustomGroupBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="CustomGroupBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CustomGroupBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CustomGroupBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="CustomGroupBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static CustomGroupBox AddGroupBox(BaseForm form, string text, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            CustomGroupBox groupBox = new CustomGroupBox
            {
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                TabStop = true
            };

            switch (form.layoutType)
            {
                case BaseForm.LayoutType.Flow:
                    var flowPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
                    groupBox.Controls.Add(flowPanel);
                    break;
                case BaseForm.LayoutType.Grid:
                    var panel = new Panel { Dock = DockStyle.Fill, AutoSize = false, AutoScroll = true };
                    groupBox.Controls.Add(panel);
                    break;
                default:
                    throw new ArgumentException("Unsupported layout type", nameof(form.layoutType));
            }

            groupBox.LayoutType = form.layoutType;

            form.AddControl(groupBox, styledControl);

            return groupBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="TabControl"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="TabControl"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="TabControl"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TabControl"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TabControl"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TabControl"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TabControl AddTabControl(BaseForm form, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            TabControl tabControl = new TabControl
            {
                AccessibleDescription = description,
                Width = 400,
                Height = 200,
                TabStop = true
            };

            form.AddControl(tabControl, styledControl);

            return tabControl;
        }

        /// <summary>
        /// Creates and adds a <see cref="TabPage"/> control to the specified tab control.
        /// </summary>
        /// <param name="tabControl">The parent tab control to which the <see cref="TabPage"/> will be added.</param>
        /// <param name="text">The text for the  <see cref="TabPage"/> control.</param>
        /// <param name="description">The description for the  <see cref="TabPage"/> control.</param>
        /// <returns>A handle to the created <see cref="TabPage"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="tabControl"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TabPage"/> control with the specified properties and adds it to the specified tab control. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TabPage AddTabPage(TabControl tabControl, string text, string description)
        {
            if (tabControl == null)
            {
                throw new ArgumentNullException(nameof(tabControl));
            }

            TabPage tabPage = new TabPage
            {
                Text = text,
                AccessibleName = text,
                AccessibleDescription = description,
                AutoSize = true,
                TabStop = true
            };

            tabControl.TabPages.Add(tabPage);

            return tabPage;
        }

        /// <summary>
        /// Creates and adds a <see cref="DataGridView"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="DataGridView"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="DataGridView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="DataGridView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="DataGridView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="DataGridView"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static DataGridView AddDataGridView(BaseForm form, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            DataGridView dataGridView = new DataGridView
            {
                AccessibleDescription = description,
                Width = 400,
                Height = 200,
                TabStop = true
            };

            form.AddControl(dataGridView, styledControl);

            return dataGridView;
        }

        /// <summary>
        /// Creates and adds a text column to the specified <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="dataGridView">The parent data grid view to which the <see cref="Label"/> will be added.</param>
        /// <param name="headerText">The header text to display on the column.</param>
        /// <param name="columnName">The name for the  column.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataGridView"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a text column with the specified properties and adds it to the specified data grid view. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void AddDataGridViewTextColumn(DataGridView dataGridView, string headerText, string columnName)
        {
            if (dataGridView == null)
            {
                throw new ArgumentNullException(nameof(dataGridView));
            }

            var column = new DataGridViewTextBoxColumn
            {
                HeaderText = headerText,
                Name = columnName
            };

            dataGridView.Columns.Add(column);
        }

        /// <summary>
        /// Creates and adds a check box column to the specified <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="dataGridView">The parent data grid view to which the <see cref="Label"/> will be added.</param>
        /// <param name="headerText">The header text to display on the column.</param>
        /// <param name="columnName">The name for the  column.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataGridView"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a check box column with the specified properties and adds it to the specified data grid view. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void AddDataGridViewCheckBoxColumn(DataGridView dataGridView, string headerText, string columnName)
        {
            if (dataGridView == null)
            {
                throw new ArgumentNullException(nameof(dataGridView));
            }

            var column = new DataGridViewCheckBoxColumn
            {
                HeaderText = headerText,
                Name = columnName
            };

            dataGridView.Columns.Add(column);
        }

        /// <summary>
        /// Creates and adds a combo box column to the specified <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="dataGridView">The parent data grid view to which the <see cref="Label"/> will be added.</param>
        /// <param name="headerText">The header text to display on the column.</param>
        /// <param name="columnName">The name for the  column.</param>
        /// <param name="items">The items to add to the  column.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataGridView"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a combo box column with the specified properties and adds it to the specified data grid view. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void AddDataGridViewComboBoxColumn(DataGridView dataGridView, string headerText, string columnName, string[] items)
        {
            if (dataGridView == null)
            {
                throw new ArgumentNullException(nameof(dataGridView));
            }

            var column = new DataGridViewComboBoxColumn
            {
                HeaderText = headerText,
                Name = columnName
            };

            column.Items.AddRange(items);

            dataGridView.Columns.Add(column);
        }

        /// <summary>
        /// Creates and adds a button column to the specified <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="dataGridView">The parent data grid view to which the <see cref="Label"/> will be added.</param>
        /// <param name="headerText">The header text to display on the column.</param>
        /// <param name="columnName">The name for the  column.</param>
        /// <param name="buttonText">The text to display on the button.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataGridView"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a button column with the specified properties and adds it to the specified data grid view. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void AddDataGridViewButtonColumn(DataGridView dataGridView, string headerText, string columnName, string buttonText)
        {
            if (dataGridView == null)
            {
                throw new ArgumentNullException(nameof(dataGridView));
            }

            var column = new DataGridViewButtonColumn
            {
                HeaderText = headerText,
                Name = columnName,
                Text = buttonText,
                UseColumnTextForButtonValue = true
            };

            dataGridView.Columns.Add(column);
        }

        /// <summary>
        /// Creates and adds an image column to the specified <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="dataGridView">The parent data grid view to which the <see cref="Label"/> will be added.</param>
        /// <param name="headerText">The header text to display on the column.</param>
        /// <param name="columnName">The name for the  column.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataGridView"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates an image column with the specified properties and adds it to the specified data grid view. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void AddDataGridViewImageColumn(DataGridView dataGridView, string headerText, string columnName)
        {
            if (dataGridView == null)
            {
                throw new ArgumentNullException(nameof(dataGridView));
            }

            var column = new DataGridViewImageColumn
            {
                HeaderText = headerText,
                Name = columnName
            };

            dataGridView.Columns.Add(column);
        }

        /// <summary>
        /// Creates and adds a link column to the specified <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="dataGridView">The parent data grid view to which the <see cref="Label"/> will be added.</param>
        /// <param name="headerText">The header text to display on the column.</param>
        /// <param name="columnName">The name for the  column.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataGridView"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a link column with the specified properties and adds it to the specified data grid view. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void AddDataGridViewLinkColumn(DataGridView dataGridView, string headerText, string columnName)
        {
            if (dataGridView == null)
            {
                throw new ArgumentNullException(nameof(dataGridView));
            }

            var column = new DataGridViewLinkColumn
            {
                HeaderText = headerText,
                Name = columnName
            };

            dataGridView.Columns.Add(column);
        }

        /// <summary>
        /// Creates and adds a row to the specified <see cref="DataGridView"/> control.
        /// </summary>
        /// <param name="dataGridView">The parent data grid view to which the <see cref="Label"/> will be added.</param>
        /// <param name="values">The values to display on the row.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataGridView"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a row with the specified values and adds it to the specified data grid view. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void AddDataGridViewRow(DataGridView dataGridView, params object[] values)
        {
            if (dataGridView == null)
            {
                throw new ArgumentNullException(nameof(dataGridView));
            }

            dataGridView.Rows.Add(values);
        }

        /// <summary>
        /// Creates and adds a <see cref="PictureBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="PictureBox"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="PictureBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="PictureBox"/> control should be styled.</param>
        /// <param name="imagePath">The path to an image file for the  <see cref="PictureBox"/> control.</param>
        /// <param name="imageData">The byte data of an image for the  <see cref="PictureBox"/> control.</param>
        /// <returns>A handle to the created <see cref="PictureBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="PictureBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static PictureBox AddPictureBox(BaseForm form, string description = null, bool styledControl = false, string imagePath = null, byte[] imageData = null)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
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

            form.AddControl(pictureBox, styledControl);

            return pictureBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="ProgressBar"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="ProgressBar"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="ProgressBar"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="ProgressBar"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="ProgressBar"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ProgressBar"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ProgressBar AddProgressBar(BaseForm form, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            ProgressBar progressBar = new ProgressBar
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 20,
                TabStop = true
            };

            form.AddControl(progressBar, styledControl);

            return progressBar;
        }

        /// <summary>
        /// Creates and adds a <see cref="DateTimePicker"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="DateTimePicker"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="DateTimePicker"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="DateTimePicker"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="DateTimePicker"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="DateTimePicker"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static DateTimePicker AddDateTimePicker(BaseForm form, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            DateTimePicker dateTimePicker = new DateTimePicker
            {
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            form.AddControl(dateTimePicker, styledControl);

            return dateTimePicker;
        }

        /// <summary>
        /// Creates and adds a status control (either <see cref="StatusBar"/> or <see cref="StatusStrip"/> depending on the framework) to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the status control will be added.</param>
        /// <param name="text">The text to show on the status control.</param>
        /// <param name="name">The accessible name for the status control.</param>
        /// <param name="description">The description for the status control.</param>
        /// <param name="styledControl">Whether the status control should be styled.</param>
        /// <returns>A handle to the created status control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a status control with the specified properties and adds it to the specified form.
        /// </remarks>
        public static Control AddStatusBar(BaseForm form, string text = "", string name = null, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            #if NET48
            // .NET Framework 4.8 and earlier - Use StatusBar
            StatusBar statusBar = new StatusBar
            {
                Text = text,
                AccessibleName = name,
                AccessibleDescription = description
            };
            form.AddControl(statusBar, styledControl);
            return statusBar;
            #else
            // .NET Core and later - Use StatusStrip
            StatusStrip statusStrip = new StatusStrip();
            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel
            {
                Text = text,
                AccessibleName = name,
                AccessibleDescription = description
            };
            statusStrip.Items.Add(statusLabel);
            form.AddControl(statusStrip, styledControl);
            return statusStrip;
            #endif
        }

        /// <summary>
        /// Creates and adds a <see cref="TrackBar"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="TrackBar"/> will be added.</param>
        /// <param name="description">The description for the  <see cref="TrackBar"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TrackBar"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TrackBar"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TrackBar"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TrackBar AddTrackBar(BaseForm form, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            TrackBar trackBar = new TrackBar
            {
                AccessibleDescription = description,
                Width = 200,
                Height = 45,
                TabStop = true
            };

            form.AddControl(trackBar, styledControl);

            return trackBar;
        }

        /// <summary>
        /// Creates and adds a <see cref="CustomPanel"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="CustomPanel"/> will be added.</param>
        /// <param name="text">The text to show on the  <see cref="CustomPanel"/> control.</param>
        /// <param name="description">The description for the  <see cref="CustomPanel"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="CustomPanel"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="CustomPanel"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="CustomPanel"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static CustomPanel AddPanel(BaseForm form, string text, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            CustomPanel panel = new CustomPanel();

            switch (form.layoutType)
            {
                case BaseForm.LayoutType.Flow:
                    panel = new CustomPanel { Dock = DockStyle.Top, AutoSize = true };
                    break;
                case BaseForm.LayoutType.Grid:
                    panel = new CustomPanel { Dock = DockStyle.Top, AutoSize = false, AutoScroll = true };
                    break;
            }

            panel.AccessibleName = text;
            panel.AccessibleDescription = description;
            panel.AutoSize = true;
            panel.TabStop = true;

            panel.LayoutType = form.layoutType;

            form.AddControl(panel, styledControl);

            return panel;
        }

        /// <summary>
        /// Creates and adds a <see cref="TreeView"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="TreeView"/> will be added.</param>
        /// <param name="name">The accessible name for the  <see cref="TreeView"/> control.</param>
        /// <param name="description">The description for the  <see cref="TreeView"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="TreeView"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="TreeView"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TreeView"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TreeView AddTreeView(BaseForm form, string name = null, string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            TreeView treeView = new TreeView
            {
                AccessibleName = name,
                AccessibleDescription = description
            };

            form.AddControl(treeView, styledControl);

            return treeView;
        }

        /// <summary>
        /// Creates and adds a <see cref="TreeNode"/> control to the specified tree view.
        /// </summary>
        /// <param name="treeView">The parent tree view to which the <see cref="TreeNode"/> will be added.</param>
        /// <param name="text">The text to show on the  <see cref="TreeNode"/> control.</param>
        /// <param name="name">The name for the  <see cref="TreeNode"/> control.</param>
        /// <param name="description">The description for the  <see cref="TreeNode"/> control.</param>
        /// <returns>A handle to the created <see cref="TreeNode"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="treeView"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TreeNode"/> control with the specified properties and adds it to the specified tree view. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TreeNode AddTreeNode(TreeView treeView, string text, string name = null, string description = null)
        {
            if (treeView == null)
            {
                throw new ArgumentNullException(nameof(treeView));
            }

            TreeNode treeNode = new TreeNode(text)
            {
                Name = name,
                ToolTipText = description
            };

            treeView.Nodes.Add(treeNode);

            return treeNode;
        }

        /// <summary>
        /// Creates and adds a child <see cref="TreeNode"/> control to the specified tree node.
        /// </summary>
        /// <param name="parentNode">The parent tree node to which the <see cref="TreeNode"/> will be added.</param>
        /// <param name="text">The text to show on the  <see cref="TreeNode"/> control.</param>
        /// <param name="name">The name for the  <see cref="TreeNode"/> control.</param>
        /// <param name="description">The description for the  <see cref="TreeNode"/> control.</param>
        /// <returns>A handle to the created <see cref="TreeNode"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="parentNode"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="TreeNode"/> control with the specified properties and adds it to the specified tree node. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static TreeNode AddChildTreeNode(TreeNode parentNode, string text, string name = null, string description = null)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException(nameof(parentNode));
            }

            TreeNode childNode = new TreeNode(text)
            {
                Name = name,
                ToolTipText = description
            };

            parentNode.Nodes.Add(childNode);

            return childNode;
        }

        /// <summary>
        /// Creates and adds a <see cref="WebBrowser"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="WebBrowser"/> will be added.</param>
        /// <param name="url">The url for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="name">The name for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="description">The description for the  <see cref="WebBrowser"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="WebBrowser"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="WebBrowser"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="WebBrowser"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static WebBrowserControl AddWebBrowserControl(BaseForm form, string url = "about:blank", string name = "Web Browser", string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            WebBrowserControl webBrowserControl = new WebBrowserControl
            {
                AccessibleName = name,
                AccessibleDescription = description,
                Dock = DockStyle.Fill,
                TabStop = true
            };

            webBrowserControl.Navigate(url);
            form.AddControl(webBrowserControl, styledControl);

            return webBrowserControl;
        }

        /// <summary>
        /// Creates and adds a <see cref="RichTextBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="RichTextBox"/> will be added.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="RichTextBox"/> control.</param>
        /// <param name="richTextBoxText">The default text to display in the <see cref="RichTextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="RichTextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="RichTextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="RichTextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="RichTextBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static RichTextBox AddRichTextBox(BaseForm form, string labelText, string richTextBoxText = "", string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            // Create the label
            Label label = AddLabel(form, labelText, description, styledControl);

            // Create the rich text box
            RichTextBox richTextBox = new RichTextBox
            {
                Text = richTextBoxText,
                AccessibleDescription = description,
                Width = 200,
                Height = 100,
                TabStop = true
            };

            form.AddControl(richTextBox, styledControl);

            return richTextBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="MaskedTextBox"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="MaskedTextBox"/> will be added.</param>
        /// <param name="mask">The mask to use for the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="labelText">The text to display on the <see cref="Label"/> for the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="maskedTextBoxText">The default text to display in the <see cref="MaskedTextBox"/> control.</param>
        /// <param name="description">The description for the  <see cref="MaskedTextBox"/> control.</param>
        /// <param name="styledControl">Whether the the <see cref="MaskedTextBox"/> control should be styled.</param>
        /// <returns>A handle to the created <see cref="MaskedTextBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="MaskedTextBox"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static MaskedTextBox AddMaskedTextBox(BaseForm form, string mask, string labelText, string maskedTextBoxText = "", string description = null, bool styledControl = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            // Create the label
            Label label = AddLabel(form, labelText, description, styledControl);

            // Create the masked text box
            MaskedTextBox maskedTextBox = new MaskedTextBox
            {
                Text = maskedTextBoxText,
                Mask = mask,
                AccessibleDescription = description,
                Width = 200,
                TabStop = true
            };

            form.AddControl(maskedTextBox, styledControl);

            return maskedTextBox;
        }

        /// <summary>
        /// Creates and adds a <see cref="MenuStrip"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="MenuStrip"/> will be added.</param>
        /// <returns>A handle to the created <see cref="MenuStrip"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="MenuStrip"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static MenuStrip CreateMenuBar(BaseForm form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            MenuStrip menuStrip = new MenuStrip();
            form.MainMenuStrip = menuStrip;

            form.Controls.Add(menuStrip);

            return menuStrip;
        }

        /// <summary>
        /// Creates and adds a <see cref="ToolStripMenuItem"/> control to the specified menu strip.
        /// </summary>
        /// <param name="menuStrip">The parent menu strip to which the <see cref="ToolStripMenuItem"/> will be added.</param>
        /// <param name="menuName">The name of the <see cref="ToolStripMenuItem"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStripMenuItem"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="menuStrip"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="menuName"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripMenuItem"/> control with the specified properties and adds it to the specified menu strip. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ToolStripMenuItem AddMenuBarMenu(MenuStrip menuStrip, string menuName)
        {
            if (menuStrip == null)
            {
                throw new ArgumentNullException(nameof(menuStrip));
            }

            ToolStripMenuItem newMenu = new ToolStripMenuItem(menuName);

            menuStrip.Items.Add(newMenu);

            return newMenu;
        }

        /// <summary>
        /// Creates and adds a <see cref="ToolStripMenuItem"/> control to the specified tool strip menu item.
        /// </summary>
        /// <param name="menu">The parent menu to which the <see cref="ToolStripMenuItem"/> will be added.</param>
        /// <param name="submenuName">The name of the <see cref="ToolStripMenuItem"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStripMenuItem"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="menu"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="submenuName"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripMenuItem"/> control with the specified properties and adds it to the specified tool strip menu item. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ToolStripMenuItem AddMenuBarSubmenu(ToolStripMenuItem menu, string submenuName)
        {
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }

            ToolStripMenuItem newSubmenu = new ToolStripMenuItem(submenuName);

            menu.DropDownItems.Add(newSubmenu);

            return newSubmenu;
        }

        /// <summary>
        /// Creates and adds a <see cref="ToolStripMenuItem"/> control to the specified tool strip menu item.
        /// </summary>
        /// <param name="menu">The parent menu to which the <see cref="ToolStripMenuItem"/> will be added.</param>
        /// <param name="menuItemName">The name of the <see cref="ToolStripMenuItem"/>.</param>
        /// <param name="description">The description of the <see cref="ToolStripMenuItem"/>.</param>
        /// <param name="clickEventHandler">The click event handler for the <see cref="ToolStripMenuItem"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStripMenuItem"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="menu"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="menuItemName"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripMenuItem"/> control with the specified properties and adds it to the specified tool strip menu item. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ToolStripMenuItem AddMenuBarMenuItem(ToolStripMenuItem menu, string menuItemName, string description = null, EventHandler clickEventHandler = null)
        {
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }

            ToolStripMenuItem newMenuItem = new ToolStripMenuItem(menuItemName);

            if (clickEventHandler != null)
            {
                newMenuItem.Click += clickEventHandler;
            }

            menu.DropDownItems.Add(newMenuItem);

            return newMenuItem;
        }

        /// <summary>
        /// Creates and adds a <see cref="ToolStrip"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="ToolStrip"/> will be added.</param>
        /// <param name="items">The list of <see chref="ToolStripItem"/> controls to add to the <see cref="ToolStrip"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStrip"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStrip"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ToolStrip AddToolStrip(BaseForm form, params ToolStripItem[] items)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            var toolStrip = new ToolStrip
            {
                Dock = DockStyle.Top // Default docking, you can change as needed
            };

            foreach (var item in items)
            {
                toolStrip.Items.Add(item);
            }

            form.AddControl(toolStrip, false);

            return toolStrip;
        }

        /// <summary>
        /// Creates a <see cref="ToolStripButton"/> control.
        /// </summary>
        /// <param name="text">The text to show on the <see cref="ToolStripButton"/>.</param>
        /// <param name="image">The image to display on the <see chref="ToolStripButton"/>.</param>
        /// <param name="onClick">The <see chref="EventHandler"/> for the  <see cref="ToolStripButton"/> control.</param>
        /// <returns>A handle to the created <see cref="ToolStripButton"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripButton"/> control with the specified properties. 
        /// </remarks>
        public static ToolStripButton CreateToolStripButton(string text, Image image = null, EventHandler onClick = null)
        {
            var button = new ToolStripButton
            {
                Text = text,
                Image = image,
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            };

            if (onClick != null)
            {
                button.Click += onClick;
            }

            return button;
        }

        /// <summary>
        /// Creates a <see cref="ToolStripLabel"/> control.
        /// </summary>
        /// <param name="text">The text to show on the <see cref="ToolStripLabel"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStripLabel"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripLabel"/> control with the specified properties. 
        /// </remarks>
        public static ToolStripLabel CreateToolStripLabel(string text)
        {
            return new ToolStripLabel
            {
                Text = text
            };
        }

        /// <summary>
        /// Creates a <see cref="ToolStripTextBox"/> control.
        /// </summary>
        /// <param name="text">The text to show on the <see cref="ToolStripTextBox"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStripTextBox"/> control.</returns>
        /// <remarks>
        /// This method creates a <see cref="ToolStripTextBox"/> control with the specified properties. 
        /// </remarks>
        public static ToolStripTextBox CreateToolStripTextBox(string text = "")
        {
            return new ToolStripTextBox
            {
                Text = text
            };
        }

        /// <summary>
        /// Creates a <see cref="ToolStripSeparator"/> control.
        /// </summary>
        /// <returns>A handle to the created <see cref="ToolStripSeparator"/> control.</returns>
        /// <remarks>
        /// This method creates a <see cref="ToolStripSeparator"/> control. 
        /// </remarks>
        public static ToolStripSeparator CreateToolStripSeparator()
        {
            return new ToolStripSeparator();
        }

        /// <summary>
        /// Creates a <see cref="ToolStripComboBox"/> control.
        /// </summary>
        /// <param name="items">The items to show in the <see cref="ToolStripComboBox"/>.</param>
        /// <param name="selectedItem">The items to automatically select in the <see cref="ToolStripComboBox"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStripComboBox"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripComboBox"/> control with the specified properties. 
        /// </remarks>
        public static ToolStripComboBox CreateToolStripComboBox(string[] items, string selectedItem = null)
        {
            var comboBox = new ToolStripComboBox();

            if (items != null)
            {
                comboBox.Items.AddRange(items);
            }

            if (selectedItem != null && comboBox.Items.Contains(selectedItem))
            {
                comboBox.SelectedItem = selectedItem;
            }

            return comboBox;
        }

        /// <summary>
        /// Creates a <see cref="ToolStripDropDownButton"/> control.
        /// </summary>
        /// <param name="text">The text to show on the <see cref="ToolStripDropDownButton"/>.</param>
        /// <param name="dropDownItems">The <see chref="ToolStripItem"/> controls to add to the <see cref="ToolStripDropDownButton"/>.</param>
        /// <returns>A handle to the created <see cref="ToolStripDropDownButton"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="text"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripDropDownButton"/> control with the specified properties. 
        /// </remarks>
        public static ToolStripDropDownButton CreateToolStripDropDownButton(string text, ToolStripItem[] dropDownItems)
        {
            var dropDownButton = new ToolStripDropDownButton
            {
                Text = text
            };

            if (dropDownItems != null)
            {
                dropDownButton.DropDownItems.AddRange(dropDownItems);
            }

            return dropDownButton;
        }

        /// <summary>
        /// Creates a <see cref="NotifyIcon"/> control.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="NotifyIcon"/> will be added.</param>
        /// <param name="icon">The icon to display on the <see cref="NotifyIcon"/> control.</param>
        /// <param name="tooltip">The tooltip or title for the <see cref="NotifyIcon"/> control.</param>
        /// <param name="onClick">The click event handler for the  <see cref="NotifyIcon"/> control.</param>
        /// <param name="onDoubleClick">The double click event handler for the  <see cref="NotifyIcon"/> control.</param>
        /// <returns>A handle to the created <see cref="NotifyIcon"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="NotifyIcon"/> control with the specified properties. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static NotifyIcon CreateSystemTrayIcon(BaseForm form, Icon icon = null, string tooltip = "Application", EventHandler onClick = null, EventHandler onDoubleClick = null)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = icon ?? NativeMethods.IconFromShell32(2),
                Text = tooltip,
                Visible = true
            };

            if (onClick != null)
            {
                notifyIcon.Click += onClick;
            }

            if (onDoubleClick != null)
            {
                notifyIcon.DoubleClick += onDoubleClick;
            }

            form._trayIconHandle = notifyIcon;

            return notifyIcon;
        }

        /// <summary>
        /// Creates and adds a <see cref="ToolStripMenuItem"/> control to the specified system tray icon.
        /// </summary>
        /// <param name="notifyIcon">The parent system tray icon to which the <see cref="ToolStripMenuItem"/> will be added.</param>
        /// <param name="submenuName">The name of the <see cref="ToolStripMenuItem"/> control.</param>
        /// <returns>A handle to the created <see cref="ToolStripMenuItem"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="notifyIcon"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripMenuItem"/> control with the specified properties and adds it to the specified system tray icon. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ToolStripMenuItem AddSystemTrayContextMenuSubmenu(NotifyIcon notifyIcon, string submenuName)
        {
            if (notifyIcon == null)
            {
                throw new ArgumentNullException(nameof(notifyIcon));
            }

            // Ensure the ContextMenuStrip exists
            if (notifyIcon.ContextMenuStrip == null)
            {
                notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            }

            ToolStripMenuItem newSubmenu = new ToolStripMenuItem(submenuName);

            notifyIcon.ContextMenuStrip.Items.Add(newSubmenu);

            return newSubmenu;
        }

        /// <summary>
        /// Creates and adds a <see cref="ToolStripMenuItem"/> control to the specified system tray icon.
        /// </summary>
        /// <param name="notifyIcon">The parent system tray icon to which the <see cref="ToolStripMenuItem"/> will be added.</param>
        /// <param name="itemName">The name of the <see cref="ToolStripMenuItem"/> control.</param>
        /// <param name="itemDescription">The description for the  <see cref="ToolStripMenuItem"/> control.</param>
        /// <param name="onClick">The click event handler for the  <see cref="ToolStripMenuItem"/> control.</param>
        /// <param name="submenu">The name of the submenu for the  <see cref="ToolStripMenuItem"/> control.</param>
        /// <returns>A handle to the created <see cref="ToolStripMenuItem"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="notifyIcon"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="ToolStripMenuItem"/> control with the specified properties and adds it to the specified system tray icon. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static ToolStripMenuItem AddSystemTrayContextMenuItem(NotifyIcon notifyIcon, string itemName, string itemDescription = null, EventHandler onClick = null, ToolStripMenuItem submenu = null)
        {
            if (notifyIcon == null)
            {
                throw new ArgumentNullException(nameof(notifyIcon));
            }

            // Ensure the ContextMenuStrip exists
            if (notifyIcon.ContextMenuStrip == null)
            {
                notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            }

            ToolStripMenuItem menuItem = new ToolStripMenuItem(itemName)
            {
                AccessibleName = itemName,
                AccessibleDescription = itemDescription
            };

            if (onClick != null)
            {
                menuItem.Click += onClick;
            }

            if (submenu == null)
            {
                notifyIcon.ContextMenuStrip.Items.Add(menuItem);
            }
            else
            {
                // Ensure the submenu is in the main context menu
                if (!notifyIcon.ContextMenuStrip.Items.Contains(submenu))
                {
                    notifyIcon.ContextMenuStrip.Items.Add(submenu);
                }
                // Add the item to the submenu
                submenu.DropDownItems.Add(menuItem);
            }

            return menuItem;
        }

        /// <summary>
        /// Creates and adds a <see cref="System.Windows.Forms.Timer"/> control to the specified form.
        /// </summary>
        /// <param name="form">The parent form to which the <see cref="System.Windows.Forms.Timer"/> will be added.</param>
        /// <param name="timerInterval">The interval to apply in ms to the <see cref="System.Windows.Forms.Timer"/> control.</param>
        /// <param name="tickHandler">The timer tick event handler for the  <see cref="System.Windows.Forms.Timer"/> control.</param>
        /// <param name="startTimer">whether to automatically start the <see cref="System.Windows.Forms.Timer"/>.</param>
        /// <returns>A handle to the created <see cref="System.Windows.Forms.Timer"/> control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="form"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method creates a <see cref="System.Windows.Forms.Timer"/> control with the specified properties and adds it to the specified form. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static System.Windows.Forms.Timer CreateTimer(BaseForm form, int timerInterval, EventHandler tickHandler = null, bool startTimer = false)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            System.Windows.Forms.Timer newTimer = new System.Windows.Forms.Timer
            {
                Interval = timerInterval
            };

            if (tickHandler != null)
            {
                newTimer.Tick += tickHandler;
            }

            if (startTimer)
            {
                newTimer.Start();
            }

            return newTimer;
        }

        /// <summary>
        /// Sets a tooltip for the specified <see chref="Control"/>.
        /// </summary>
        /// <param name="control">The control to set the tooltip for.</param>
        /// <param name="text">The text for the tooltip.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="control"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method sets a tooltip for the specified <see chref="Control"/>. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void AddToolTip(Control control, string text)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (text == null) throw new ArgumentNullException(nameof(text));
            toolTip.SetToolTip(control, text);
        }

        /// <summary>
        /// Resizes the specified <see chref="GroupBox"/> to fit it's controls.
        /// </summary>
        /// <param name="groupBox">The group box to resize.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="groupBox"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method resizes the specified <see chref="GroupBox"/> to fit it's controls. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void ResizeGroupBoxToFitControls(GroupBox groupBox)
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

        /// <summary>
        /// Resizes the specified <see chref="Panel"/> to fit it's controls.
        /// </summary>
        /// <param name="panel">The panel to resize.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="panel"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method resizes the specified <see chref="Panel"/> to fit it's controls. 
        /// If the parent control is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown. 
        /// </remarks>
        public static void ResizePanelToFitControls(Panel panel)
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
