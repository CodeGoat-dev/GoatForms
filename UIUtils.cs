using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace GoatForms
{
    /// <summary>
    /// Provides utility methods for interacting with user interface controls and dialogs.
    /// </summary>
    /// <remarks>
    /// This class facilitates various operations related to user interface controls, such as 
    /// showing message boxes, file dialogs, folder dialogs, and managing control states.
    /// </remarks>
    public static class UIUtils
    {
        // Message Box Methods

        /// <summary>
        /// Displays an informational message box.
        /// </summary>
        /// <param name="message">The text to display in the message box.</param>
        /// <param name="title">The title of the message box.</param>
        /// <returns>A <see cref="DialogResult"/> indicating the result of the message box.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Displays an informational message box with the specified message and title. 
        /// If the message is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown.
        /// </remarks>
        public static DialogResult ShowInfoMessage(string message, string title = "Information")
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays a warning message box.
        /// </summary>
        /// <param name="message">The text to display in the message box.</param>
        /// <param name="title">The title of the message box.</param>
        /// <returns>A <see cref="DialogResult"/> indicating the result of the message box.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Displays a warning message box with the specified message and title. 
        /// If the message is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown.
        /// </remarks>
        public static DialogResult ShowWarningMessage(string message, string title = "Warning")
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Displays an error message box.
        /// </summary>
        /// <param name="message">The text to display in the message box.</param>
        /// <param name="title">The title of the message box.</param>
        /// <returns>A <see cref="DialogResult"/> indicating the result of the message box.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Displays an error message box with the specified message and title. 
        /// If the message is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown.
        /// </remarks>
        public static DialogResult ShowErrorMessage(string message, string title = "Error")
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons.
        /// </summary>
        /// <param name="message">The text to display in the message box.</param>
        /// <param name="title">The title of the message box.</param>
        /// <returns>A <see cref="DialogResult"/> indicating the user's choice.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Displays a confirmation message box with Yes and No buttons. 
        /// If the message is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown.
        /// </remarks>
        public static DialogResult ShowConfirmationMessage(string message, string title = "Confirmation")
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        // File Dialog Methods

        /// <summary>
        /// Opens a file dialog for selecting a file.
        /// </summary>
        /// <param name="filter">The file types to display in the dialog.</param>
        /// <param name="title">The title of the dialog.</param>
        /// <returns>The selected file path, or <see langword="null"/> if no file was selected.</returns>
        public static string OpenFile(string filter = "All Files (*.*)|*.*", string title = "Open File")
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = filter;
                openFileDialog.Title = title;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }

        /// <summary>
        /// Opens a save file dialog for saving a file.
        /// </summary>
        /// <param name="filter">The file types to display in the dialog.</param>
        /// <param name="title">The title of the dialog.</param>
        /// <returns>The selected file path, or <see langword="null"/> if no file was saved.</returns>
        public static string SaveFile(string filter = "All Files (*.*)|*.*", string title = "Save File As")
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = filter;
                saveFileDialog.Title = title;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            return null;
        }

        /// <summary>
        /// Opens a file dialog for selecting multiple files.
        /// </summary>
        /// <param name="filter">The file types to display in the dialog.</param>
        /// <param name="title">The title of the dialog.</param>
        /// <param name="multiSelect">Whether multiple files can be selected.</param>
        /// <returns>An array of selected file paths, or <see langword="null"/> if no files were selected.</returns>
        public static string[] OpenFiles(string filter = "All Files (*.*)|*.*", string title = "Open Files", bool multiSelect = false)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = filter;
                openFileDialog.Title = title;
                openFileDialog.Multiselect = multiSelect;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileNames;
                }
            }
            return null;
        }

        // Folder Dialog Method

        /// <summary>
        /// Opens a folder browser dialog for selecting a folder.
        /// </summary>
        /// <param name="description">The description of the dialog.</param>
        /// <param name="rootFolder">The root folder to use for browsing.</param>
        /// <param name="specialFolder">The special folder to use if <paramref name="rootFolder"/> is <see langword="null"/>.</param>
        /// <returns>The selected folder path, or <see langword="null"/> if no folder was selected.</returns>
        public static string BrowseFolder(string description = "Select Folder", string rootFolder = null, Environment.SpecialFolder specialFolder = Environment.SpecialFolder.Desktop)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = description;
                if (!string.IsNullOrEmpty(rootFolder))
                {
                    folderBrowserDialog.RootFolder = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), rootFolder);
                }
                else
                {
                    folderBrowserDialog.RootFolder = specialFolder;
                }

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderBrowserDialog.SelectedPath;
                }
            }
            return null;
        }

        // Input Box Method

        /// <summary>
        /// Displays an input box for user input.
        /// </summary>
        /// <param name="prompt">The prompt text to display in the input box.</param>
        /// <param name="title">The title of the input box.</param>
        /// <param name="defaultValue">The default text to display in the input box.</param>
        /// <param name="isPasswordInput">Whether the input box is a password box.</param>
        /// <returns>The user's input, or <see langword="null"/> if the user canceled.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="prompt"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Displays a simple input box for user input with the specified prompt and title. 
        /// If the prompt is <see langword="null"/>, an <see cref="ArgumentNullException"/> will be thrown.
        /// </remarks>
        public static string ShowInputBox(string prompt, string title = "Input", string defaultValue = "", bool isPasswordInput = false)
        {
            if (prompt == null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            using (Form form = new Form())
            {
                form.Text = title;
                Label label = new Label { Text = prompt, Left = 10, Top = 10, AutoSize = true };
                TextBox textBox = new TextBox { Text = defaultValue, Left = 10, Top = 30, Width = 200 };
                Button buttonOk = new Button { Text = "OK", Left = 140, Width = 70, Top = 60, DialogResult = DialogResult.OK };
                Button buttonCancel = new Button { Text = "Cancel", Left = 60, Width = 70, Top = 60, DialogResult = DialogResult.Cancel };

                form.ClientSize = new Size(220, 100);
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                if (isPasswordInput == true)
                {
                    textBox.PasswordChar = '*';
                }

                return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }
        }

        // Control State Methods

        /// <summary>
        /// Fetches the current state of a form control.
        /// </summary>
        /// <param name="control">The control to fetch the state from.</param>
        /// <returns>A <see cref="string"/> representing the state of the control.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="control"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Retrieves the current state or value of the specified control. 
        /// This method supports various types of controls such as CheckBox, RadioButton, TextBox, and others.
        /// </remarks>
        public static string GetControlState(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (control is CheckBox checkBox)
            {
                return checkBox.Checked ? "Checked" : "Unchecked";
            }
            else if (control is RadioButton radioButton)
            {
                return radioButton.Checked ? "Checked" : "Unchecked";
            }
            else if (control is TextBoxBase textBoxBase)
            {
                return textBoxBase.Text;
            }
            else if (control is ComboBox comboBox)
            {
                return comboBox.SelectedItem?.ToString() ?? "No Selection";
            }
            else if (control is ListBox listBox)
            {
                return listBox.SelectedItem?.ToString() ?? "No Selection";
            }
            else if (control is CheckedListBox checkedListBox)
            {
                return checkedListBox.SelectedItem?.ToString() ?? "No Selection";
            }
            else if (control is ListView listView)
            {
                return listView.SelectedItems?.ToString() ?? "No Selection";
            }
            else if (control is ProgressBar progressBar)
            {
                return progressBar.Value.ToString();
            }
            else if (control is TrackBar trackBar)
            {
                return trackBar.Value.ToString();
            }
            else if (control is ToolStrip toolStrip)
            {
                var stateBuilder = new StringBuilder();
                foreach (var item in toolStrip.Items)
                {
                    if (item is ToolStripStatusLabel statusLabel)
                    {
                        stateBuilder.AppendLine($"StatusLabel: {statusLabel.Text}");
                    }
                    else if (item is ToolStripTextBox toolStripTextBox)
                    {
                        stateBuilder.AppendLine($"TextBox: {toolStripTextBox.Text}");
                    }
                }
                return stateBuilder.ToString().Trim();
            }
            else
            {
                return "Unsupported Control Type";
            }
        }

        /// <summary>
        /// Sets the state of a form control.
        /// </summary>
        /// <param name="control">The control to set the state of.</param>
        /// <param name="state">The state to set on the control.</param>
        /// <returns><see langword="true"/> if the state was successfully set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="state"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Sets the state or value of the specified control based on the given state. 
        /// This method supports various types of controls such as CheckBox, RadioButton, TextBox, and others.
        /// </remarks>
        public static bool SetControlState(Control control, string state = null)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state), "State cannot be null.");
            }
    
            state = state.Trim().ToLower(); // Normalize state value for comparison

            if (control is CheckBox checkBox)
            {
                if (state == "checked")
                {
                    checkBox.Checked = true;
                    return true;
                }
                else if (state == "unchecked")
                {
                    checkBox.Checked = false;
                    return true;
                }
            }
            else if (control is RadioButton radioButton)
            {
                if (state == "checked")
                {
                    radioButton.Checked = true;
                    return true;
                }
                else if (state == "unchecked")
                {
                    radioButton.Checked = false;
                    return true;
                }
            }
            else if (control is TextBox textBox)
            {
                textBox.Text = state;
                return true;
            }
            else if (control is RichTextBox richTextBox)
            {
                richTextBox.Text = state;
                return true;
            }
            else if (control is MaskedTextBox maskedTextBox)
            {
                maskedTextBox.Text = state;
                return true;
            }
            else if (control is ProgressBar progressBar)
            {
                if (int.TryParse(state, out int value))
                {
                    progressBar.Value = Math.Max(progressBar.Minimum, Math.Min(progressBar.Maximum, value)); // Ensure value is within range
                    return true;
                }
            }
            else if (control is TrackBar trackBar)
            {
                if (int.TryParse(state, out int value))
                {
                    trackBar.Value = Math.Max(trackBar.Minimum, Math.Min(trackBar.Maximum, value)); // Ensure value is within range
                    return true;
                }
            }
            else if (control is ListBox listBox)
            {
                if (state == "clear")
                {
                    listBox.Items.Clear();
                    return true;
                }
                else
                {
                    listBox.Items.Add(state);
                    return true;
                }
            }
            else if (control is CheckedListBox checkedListBox)
            {
                string[] items = state.Split(';');
                checkedListBox.Items.Clear();
                foreach (var item in items)
                {
                    checkedListBox.Items.Add(item, false);
                }
                return true;
            }
            else if (control is TreeView treeView)
            {
                treeView.Nodes.Clear();
                string[] nodes = state.Split(';');
                foreach (var node in nodes)
                {
                    treeView.Nodes.Add(new TreeNode(node));
                }
                return true;
            }
            return false; // Return false if control type or state is unsupported
        }

        // Double Buffering Method

        /// <summary>
        /// Enables double buffering for a control to reduce flickering.
        /// </summary>
        /// <param name="control">The control to enable double buffering for.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="control"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Enables double buffering for the specified control to reduce flickering during redraws. 
        /// This is particularly useful for controls that experience flickering issues.
        /// </remarks>
        public static void EnableDoubleBuffering(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (SystemInformation.TerminalServerSession)
                return;

            PropertyInfo doubleBufferPropertyInfo =
                  control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            doubleBufferPropertyInfo.SetValue(control, true, null);
        }

        // Control Size Method

        /// <summary>
        /// Sets the size of a control with the specified width and height.
        /// </summary>
        /// <param name="control">The control to set the size of.</param>
        /// <param name="width">The width to set for the control.</param>
        /// <param name="height">The height to set for the control.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="control"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Sets the size of the specified control to the given width and height. 
        /// The size is applied directly to the control's <see cref="Control.Size"/> property.
        /// </remarks>
        public static void SetControlSize(Control control, int width, int height)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            control.Size = new Size(width, height);
        }

        // Control Centering Method

        /// <summary>
        /// Centers a control within its parent.
        /// </summary>
        /// <param name="control">The control to center.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="control"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Positions the specified control in the center of its parent container. 
        /// The position is set relative to the parent container's <see cref="Control.ClientSize"/> property.
        /// </remarks>
        public static void CenterControl(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (control.Parent != null)
            {
                control.Left = (control.Parent.ClientSize.Width - control.Width) / 2;
                control.Top = (control.Parent.ClientSize.Height - control.Height) / 2;
            }
        }

        // Global Font Method

        /// <summary>
        /// Applies a global font to all controls on a form or container.
        /// </summary>
        /// <param name="container">The container control to apply the font to.</param>
        /// <param name="font">The font to apply to all controls.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="container"/> or <paramref name="font"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// Recursively applies the specified font to all controls within the specified container. 
        /// This includes controls within child containers. 
        /// The font is applied by setting each control's <see cref="Control.Font"/> property.
        /// </remarks>
        public static void ApplyGlobalFont(Control container, Font font)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (font == null)
            {
                throw new ArgumentNullException(nameof(font));
            }

            foreach (Control control in container.Controls)
            {
                control.Font = font;

                if (control.HasChildren)
                {
                    ApplyGlobalFont(control, font);
                }
            }
        }
    }
}
