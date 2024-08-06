using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;

namespace GoatForms
{
    /// <summary>
    /// Provides utility methods for common application tasks such as mutex management and file operations.
    /// </summary>
    public static class AppUtils
    {
        private static Mutex _mutex;

        /// <summary>
        /// Creates a named mutex to ensure only one instance of the application is running.
        /// </summary>
        /// <param name="mutexName">The name of the mutex.</param>
        /// <returns><c>true</c> if the mutex was created and is the only instance; <c>false</c> otherwise.</returns>
        public static bool CreateMutex(string mutexName)
        {
            if (mutexName == null)
            {
                throw new ArgumentNullException(nameof(mutexName));
            }

            bool isNew;
            try
            {
                // Ensure that any previous mutex is disposed of
                ReleaseMutex();
                
                _mutex = new Mutex(true, mutexName, out isNew);
            }
            catch (ArgumentException ex)
            {
                // Log and/or display the exception details
                MessageBox.Show($"Invalid mutex name: {ex.Message}", "Error");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                // Log and/or display the exception details
                LogError(ex, "error.log");
                MessageBox.Show($"Access denied: {ex.Message}", "Error");
                return false;
            }
            catch (Exception ex)
            {
                // Log and/or display the exception details
                LogError(ex, "error.log");
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
                return false;
            }

            return isNew;
        }

        /// <summary>
        /// Releases the mutex and disposes of it.
        /// </summary>
        public static void ReleaseMutex()
        {
            if (_mutex != null)
            {
                try
                {
                    _mutex.ReleaseMutex();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show($"Failed to release mutex: {ex.Message}", "Error");
                }
                finally
                {
                    _mutex.Dispose();
                    _mutex = null;
                }
            }
        }

        /// <summary>
        /// Gets the path of the currently executing application.
        /// </summary>
        /// <returns>The path of the executable.</returns>
        public static string GetExecutablePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Gets the path for storing application data.
        /// </summary>
        /// <param name="appName">Your application's name or the relative path to application data.</param>
        /// <returns>The path for application data.</returns>
        public static string GetAppDataPath(string appName = null)
        {
            if (appName == null)
            {
                throw new ArgumentNullException(nameof(appName));
            }

            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appName);
        }

        /// <summary>
        /// Creates the directory for storing application data.
        /// </summary>
        /// <param name="appName">Your application's name or the relative path to application data.</param>
        /// <returns>The path for application data.</returns>
        public static string CreateAppDataDirectory(string appName = null)
        {
            if (appName == null)
            {
                throw new ArgumentNullException(nameof(appName));
            }

            public string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appName);

            if (!DirectoryExists(directoryPath))
            {
                Directory.Create(directoryPath);
            }

            return directoryPath;
        }

        /// <summary>
        /// Logs a message to a specified log file.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="logFilePath">The path to the log file.</param>
        public static void LogMessage(string message, string logFilePath)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (logFilePath == null)
            {
                throw new ArgumentNullException(nameof(logFilePath));
            }

            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }

        /// <summary>
        /// Logs an error with stack trace to a specified log file.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="logFilePath">The path to the log file.</param>
        public static void LogError(Exception exception, string logFilePath)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (logFilePath == null)
            {
                throw new ArgumentNullException(nameof(logFilePath));
            }

            File.AppendAllText(logFilePath, $"{DateTime.Now}: ERROR - {exception.Message}{Environment.NewLine}{exception.StackTrace}{Environment.NewLine}");
        }

        /// <summary>
        /// Logs an informational message to the event log.
        /// </summary>
        /// <param name="source">The source of the event log entry.</param>
        /// <param name="message">The informational message to log.</param>
        /// <exception cref="InvalidOperationException">Thrown when the event log source cannot be created or accessed.</exception>
        public static void LogInformation(string source, string message)
        {
            WriteToEventLog(source, message, EventLogEntryType.Information);
        }

        /// <summary>
        /// Logs a warning message to the event log.
        /// </summary>
        /// <param name="source">The source of the event log entry.</param>
        /// <param name="message">The warning message to log.</param>
        /// <exception cref="InvalidOperationException">Thrown when the event log source cannot be created or accessed.</exception>
        public static void LogWarning(string source, string message)
        {
            WriteToEventLog(source, message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Logs an error message to the event log.
        /// </summary>
        /// <param name="source">The source of the event log entry.</param>
        /// <param name="message">The error message to log.</param>
        /// <exception cref="InvalidOperationException">Thrown when the event log source cannot be created or accessed.</exception>
        public static void LogError(string source, string message)
        {
            WriteToEventLog(source, message, EventLogEntryType.Error);
        }

        /// <summary>
        /// Writes a message to the event log with the specified entry type.
        /// </summary>
        /// <param name="source">The source of the event log entry.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="type">The type of the event log entry (Information, Warning, Error).</param>
        /// <exception cref="InvalidOperationException">Thrown when the event log source cannot be created or accessed.</exception>
        private static void WriteToEventLog(string source, string message, EventLogEntryType type)
        {
            try
            {
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, "Application");
                }

                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = source;
                    eventLog.WriteEntry(message, type);
                }
            }
            catch (Exception ex)
            {
                // Throw an InvalidOperationException with the error details
                throw new InvalidOperationException($"Failed to write to event log: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Sets text to the clipboard.
        /// </summary>
        /// <param name="text">The text to set to the clipboard.</param>
        public static void SetClipboardText(string text)
        {
            Clipboard.SetText(text);
        }

        /// <summary>
        /// Gets text from the clipboard.
        /// </summary>
        /// <returns>The text from the clipboard.</returns>
        public static string GetClipboardText()
        {
            return Clipboard.GetText();
        }

        /// <summary>
        /// Safely deletes a file.
        /// </summary>
        /// <param name="filePath">The path to the file to delete.</param>
        public static void SafeDeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "error.log");
            }
        }

        /// <summary>
        /// Copies a file from source to destination.
        /// </summary>
        /// <param name="sourceFilePath">The path to the source file.</param>
        /// <param name="destinationFilePath">The path to the destination file.</param>
        public static void CopyFile(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                File.Copy(sourceFilePath, destinationFilePath, true);
            }
            catch (Exception ex)
            {
                LogError(ex, "error.log");
            }
        }

        /// <summary>
        /// Writes a value to the registry at the specified key and value name.
        /// </summary>
        /// <param name="registryKey">The base registry key to write to (e.g., Registry.CurrentUser).</param>
        /// <param name="subKey">The subkey path under the base key.</param>
        /// <param name="valueName">The name of the value to write.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="valueType">The type of the value being written.</param>
        public static void WriteRegistryValue(RegistryKey registryKey, string subKey, string valueName, object value, RegistryValueKind valueType)
        {
            using (var key = registryKey.CreateSubKey(subKey))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value, valueType);
                }
            }
        }

        /// <summary>
        /// Reads a value from the registry at the specified key and value name.
        /// </summary>
        /// <param name="registryKey">The base registry key to read from (e.g., Registry.CurrentUser).</param>
        /// <param name="subKey">The subkey path under the base key.</param>
        /// <param name="valueName">The name of the value to read.</param>
        /// <returns>The value read from the registry, or <see langword="null"/> if the value does not exist.</returns>
        public static object ReadRegistryValue(RegistryKey registryKey, string subKey, string valueName)
        {
            using (var key = registryKey.OpenSubKey(subKey))
            {
                return key?.GetValue(valueName);
            }
        }

        /// <summary>
        /// Deletes a value from the registry at the specified key and value name.
        /// </summary>
        /// <param name="registryKey">The base registry key to delete from (e.g., Registry.CurrentUser).</param>
        /// <param name="subKey">The subkey path under the base key.</param>
        /// <param name="valueName">The name of the value to delete.</param>
        public static void DeleteRegistryValue(RegistryKey registryKey, string subKey, string valueName)
        {
            using (var key = registryKey.OpenSubKey(subKey, writable: true))
            {
                key?.DeleteValue(valueName, throwOnMissingValue: false);
            }
        }

        /// <summary>
        /// Deletes a registry subkey and all its values.
        /// </summary>
        /// <param name="registryKey">The base registry key to delete from (e.g., Registry.CurrentUser).</param>
        /// <param name="subKey">The subkey path under the base key.</param>
        public static void DeleteRegistrySubKey(RegistryKey registryKey, string subKey)
        {
            using (var key = registryKey.OpenSubKey(subKey, writable: true))
            {
                if (key != null)
                {
                    foreach (var valueName in key.GetValueNames())
                    {
                        key.DeleteValue(valueName, throwOnMissingValue: false);
                    }
                    key.Close();
                    registryKey.DeleteSubKey(subKey, throwOnMissingSubKey: false);
                }
            }
        }

        /// <summary>
        /// Checks if a registry key exists at the specified base key and subkey path.
        /// </summary>
        /// <param name="registryKey">The base registry key to check (e.g., Registry.CurrentUser).</param>
        /// <param name="subKey">The subkey path under the base key.</param>
        /// <returns><see langword="true"/> if the subkey exists; otherwise, <see langword="false"/>.</returns>
        public static bool RegistryKeyExists(RegistryKey registryKey, string subKey)
        {
            using (var key = registryKey.OpenSubKey(subKey))
            {
                return key != null;
            }
        }

        /// <summary>
        /// Checks if a registry value exists at the specified key and value name.
        /// </summary>
        /// <param name="registryKey">The base registry key to check (e.g., Registry.CurrentUser).</param>
        /// <param name="subKey">The subkey path under the base key.</param>
        /// <param name="valueName">The name of the value to check.</param>
        /// <returns><see langword="true"/> if the value exists; otherwise, <see langword="false"/>.</returns>
        public static bool RegistryValueExists(RegistryKey registryKey, string subKey, string valueName)
        {
            using (var key = registryKey.OpenSubKey(subKey))
            {
                return key?.GetValue(valueName) != null;
            }
        }

        /// <summary>
        /// Loads an XML document from a file.
        /// </summary>
        /// <param name="filePath">The path to the XML file.</param>
        /// <returns>The loaded XDocument.</returns>
        public static XDocument LoadXml(string filePath)
        {
            return XDocument.Load(filePath);
        }

        /// <summary>
        /// Saves an XDocument to a file.
        /// </summary>
        /// <param name="document">The XDocument to save.</param>
        /// <param name="filePath">The path to save the XML file.</param>
        public static void SaveXml(XDocument document, string filePath)
        {
            document.Save(filePath);
        }

        /// <summary>
        /// Adds a new element to the XML document.
        /// </summary>
        /// <param name="document">The XDocument to modify.</param>
        /// <param name="parentElement">The name of the parent element to add the new element under.</param>
        /// <param name="newElement">The XElement to add.</param>
        public static void AddElement(XDocument document, string parentElement, XElement newElement)
        {
            var parent = document.Root.Element(parentElement);
            if (parent != null)
            {
                parent.Add(newElement);
            }
        }

        /// <summary>
        /// Removes an element from the XML document.
        /// </summary>
        /// <param name="document">The XDocument to modify.</param>
        /// <param name="elementName">The name of the element to remove.</param>
        public static void RemoveElement(XDocument document, string elementName)
        {
            var element = document.Root.Element(elementName);
            if (element != null)
            {
                element.Remove();
            }
        }

        /// <summary>
        /// Updates the value of an existing element in the XML document.
        /// </summary>
        /// <param name="document">The XDocument to modify.</param>
        /// <param name="elementName">The name of the element to update.</param>
        /// <param name="newValue">The new value to set.</param>
        public static void UpdateElement(XDocument document, string elementName, string newValue)
        {
            var element = document.Root.Element(elementName);
            if (element != null)
            {
                element.Value = newValue;
            }
        }

        /// <summary>
        /// Finds an element by name and returns it.
        /// </summary>
        /// <param name="document">The XDocument to search.</param>
        /// <param name="elementName">The name of the element to find.</param>
        /// <returns>The found XElement or null if not found.</returns>
        public static XElement FindElement(XDocument document, string elementName)
        {
            return document.Root.Element(elementName);
        }
    }
}
