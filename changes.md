# GoatForms Version History

This document outlines the changes made between versions of the GoatForms library.

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
