# GoatForms Version History

This document outlines the changes made between versions of the GoatForms library.

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
