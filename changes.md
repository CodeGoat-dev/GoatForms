# GoatForms Version History

This document outlines the changes made between versions of the GoatForms library.

## V1.2.4

## New Features

Just like in the vV1.2.3 update, GoatForms now performs more intelligent form analysis when adding controls to panels, group boxes and tab pages. This change should improve the layout of complex forms which use advanced control arrangements and make the library more usable.

## V1.2.3

## New Features

GoatForms now performs more intelligent form analysis when adding controls. This change should improve the layout of complex forms and make the library more usable.

The `AppUtils` class now contains methods for fetching and creating common application data directories.

## V1.2.2

## New Features

You can now resize tab pages to fit child controls.

You should use the new `ResizeTabPageToFitControls` method in the `ControlFactory` class to resize tab pages after populating all controls.

## V1.2.1

### Updated Features

In DotNET 6 or above, when creating a `StatusStrip`, the `Text`, `AccessibleName` and `AccessibleDescription` properties for the actual `StatusStrip` are populated the same as the properties for the label.

## Bug Fixes

When creating `StatusBar` or `StatusStrip` controls the correct return type is now returned. This issue can be worked around by using `(StatusStrip)ControlFactory.AddStatusBar(this, "Status", "Status", "Status Bar", false)` replacing `StatusStrip` for `StatusBar` in DotNET Framework 4.8.

## V1.2.0

### New Features

GoatForms now supports DotNET 6, 7 and 8.

There is only one difference when using DotNET 6 and above, the `StatusBar` control is replaced by `StatusStrip`.

## V1.1.5

### Updated Features

When adding controls to forms, group boxes and panels, the parent control is no longer automatically resized.

Parent control resizing should be done after adding all controls, using the `BaseForm.ResizeFormToFitControls` method for forms and the `ControlFactory.ResizeGroupBoxToFitControls` and `ControlFactory.ResizePanelToFitControls` methods for group boxes and panels respectively.

## V1.1.4

## New Features

The `ControlFactory` class now has an overload method to add key/value pairs to combo boxes.

## V1.1.3

## Updated Features

The `AddListBox()`, `AddCheckedListBox()`, `AddListBoxToGroupBox()`, `AddCheckedListBoxToGroupBox()`, `AddListBoxToPanel()`, `AddCheckedListBoxToPanel()`, `AddListBoxToTabPage()` and `AddCheckedListBoxToTabPage()` methods in the `ControlFactory` class now accept arguments for `SelectionChanged` event handlers. This is a breaking change.

## Bug Fixes

The change log was not correctly included in NuGet packages.

## V1.1.2

## Bug Fixes

Fixed issues in `AppUtils` regarding application data directory creation and retrieval.

## V1.1.1

### New Features

The `AppUtils` class now has a new `CreateAppDataDirectory()` method to create application data directories.

## Bug Fixes

The `CreateMutex()` method in the `AppUtils` class could cause unexpected compilation errors in applications.

## V1.1.0

### New Features

New methods have been added to the `ControlFactory` class to enable controls to be added to group boxes.

New methods have been added to the `AppUtils` class to facilitate event logging.

### Updated Features

When creating `GroupBox` and `Panel` controls using methods in the `ControlFactory` class, parent form layout preferences are now applied to the new controls.

When adding controls to `GroupBox` or `Panel` controls, the parent control is now automatically resized to fit child controls.

The `GetAppDataPath()` method in the `AppUtils` class now takes your application name or relative path to your application data directory as an argument.

### Improvements

Exception handling has been improved in the `AppUtils` class.

##V1.0.1

### New Features

Added XML document manipulation methods to the AppUtils class.

## V1.0.0

Initial release.
