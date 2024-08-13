# GoatForms

## Overview

GoatForms is a lightweight and intuitive library designed to simplify the creation and management of Windows Forms applications for visually impaired developers. It was developed to streamline the process of form creation, control management, and layout handling, making it easier for developers to build robust Windows Forms applications with minimal effort.

## Features

- **Simple Form Creation:** Easily create new forms with customizable parameters such as title, dimensions, border style, and layout type (Flow or Grid).
- **Dynamic Control Management:** Add various controls to your forms dynamically with options for automatic styling.
- **Layout Management:** Switch between Flow and Grid layouts effortlessly while maintaining control positions and sizes.
- **System Tray Icon Management:** Create and manage system tray icons with context menus, ensuring proper disposal and state management.
- **App Utilities:** Create and release mutexes, manipulate the Windows Registry, manage files and log messages.
- **UI Utilities:** Get and set control states and display common dialogs.

## Why GoatForms?

GoatForms was developed to address the need for a more straightforward approach to creating and managing Windows Forms applications. Traditional methods often involve repetitive tasks and boilerplate code, which can be cumbersome and error-prone.

GoatForms aims to reduce this overhead by providing a clean, easy-to-use API that automates many common tasks while allowing for flexibility and customization.

## Key Features

### Form Creation

To create a new form, simply instantiate the `BaseForm` class with your desired parameters:

```csharp
var myForm = new BaseForm("My Application", 1024, 768, FormBorderStyle.FixedSingle, true, true, BaseForm.LayoutType.Flow);
```

### Adding Controls

You can add controls to the form using the `AddControl` method.

For example, to add a styled button:

```csharp
Button myButton = ControlFactory.AddButton(this, "My Button", "Click Me", (s, e) => clickHandler());
```

### Cleaning Up

Once you have populated your form controls, use the `form.ResizeFormToFitControls` method to clean up your user interface.

You should use the methods in `ControlFactory` to do the same for `GroupBox` and `Panel` controls once fully populated.

### Getting And Setting Control States

You can get control states using the `GetControlState` method.

For example, to get the state of a text box:

```csharp
string textBoxValue = UIUtils.GetControlState(textbox);
```

You can set control states using the `SetControlState` method.

For example, to set the state of a check box:

```csharp
bool result = UIUtils.SetControlState(checkbox, "checked");
```

### Layout Management

You can switch between form layouts by calling the `SetLayoutType` method:

```csharp
myForm.SetLayoutType(BaseForm.LayoutType.Grid);
```

### System Tray Icon

Create and manage a system tray icon with a context menu:

```csharp
Icon trayIcon = ControlFactory.CreateSystemTrayIcon(this, "path_to_icon.ico", "Application Name", (s, e) => TrayIconClickHandler(), (s, e) => TrayIconDoubleClickHandler());
ToolStripMenuItem trayApplicationMenu = ControlFactory.AddSystemTrayContextMenuSubmenu(trayIcon, "Application");
ToolStripMenuItem trayShowMenuItem = ControlFactory.AddSystemTrayContextMenuItem(trayIcon, "Show", "Show the application", (s, e) => { this.WindowState = FormWindowState.Maximized; this.Show(); }, trayApplicationMenu);
ToolStripMenuItem trayHideMenuItem = ControlFactory.AddSystemTrayContextMenuItem(trayIcon, "Hide", "Hide the application", (s, e) => { this.WindowState = FormWindowState.Minimized; this.Hide(); }, trayApplicationMenu);
```

The library ensures that the tray icon and its associated resources are properly managed and disposed of when the form is closed.

### App Utilities

#### Mutex Management

Create or release a named mutex:

```csharp
AppUtils.CreateMutex("myMutexName");
AppUtils.ReleaseMutex("myMutexName");
```

#### Registry Management

Read or write a registry value:

```csharp
AppUtils.SetRegistryValue("Software\\MyApp", "SettingName", "Value");
string value = AppUtils.GetRegistryValue("Software\\MyApp", "SettingName");
```

## Getting Started

To get started with GoatForms, simply install the NuGet package:

```sh
dotnet add package GoatForms
```

Include the namespace in your project:

```csharp
using GoatForms;
```

Here’s a basic example to set up a form and add a button:

```csharp
public class MyForm : BaseForm
{
    public MyForm() : base("My Form", 800, 600, FormBorderStyle.Sizable, true, true, BaseForm.LayoutType.Flow)
    {
        Button myButton = ControlFactory.AddButton(this, "MyButton", "Click Me", (s, e) => MessageBox.Show("Button Clicked"));
        this.ResizeFormToFitControls();
    }
}
```

You are now ready to start building your application with GoatForms!

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request on GitHub.

## License

GoatForms is licensed under the MIT License. See the LICENSE file for more information.
