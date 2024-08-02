using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
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
            bool isNew;
            _mutex = new Mutex(true, mutexName, out isNew);
            return isNew;
        }

        /// <summary>
        /// Releases the mutex.
        /// </summary>
        public static void ReleaseMutex()
        {
            _mutex?.ReleaseMutex();
            _mutex?.Dispose();
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
        /// <returns>The path for application data.</returns>
        public static string GetAppDataPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GoatForms");
        }

        /// <summary>
        /// Logs a message to a specified log file.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="logFilePath">The path to the log file.</param>
        public static void LogMessage(string message, string logFilePath)
        {
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }

        /// <summary>
        /// Logs an error with stack trace to a specified log file.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="logFilePath">The path to the log file.</param>
        public static void LogError(Exception exception, string logFilePath)
        {
            File.AppendAllText(logFilePath, $"{DateTime.Now}: ERROR - {exception.Message}{Environment.NewLine}{exception.StackTrace}{Environment.NewLine}");
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
    }
}
