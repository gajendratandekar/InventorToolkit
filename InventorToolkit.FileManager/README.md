InventorToolkit.FileManager

A beginner-friendly CAD File Import and Export Manager developed as part of the Autodesk Inventor add-in toolkit.

This module helps users import Inventor-supported files into the current Inventor session and export the active document to a selected location using a simple WPF interface.



Project Purpose

The goal of this module is to simplify basic file handling operations inside Autodesk Inventor.

Users can:

Browse supported CAD files
Open selected files in Autodesk Inventor workspace
Export active Inventor files
Select save location
Rename file before exporting
View operation status



Features

Import

Allows importing supported Inventor files.

Supported extensions:

.ipt → Part file
.iam → Assembly file
.idw → Drawing file
.dwg → AutoCAD drawing
.ipn → Presentation file


Import workflow

Browse file
Select supported CAD file
Click open
File opens inside Inventor workspace
Status displayed


Export

Allows exporting active Inventor document.

Supported extensions:

.ipt
.iam
.idw
.dwg
.pdf


Export workflow

Click export
Save file dialog opens
Select location
Change file name if required
Save
Status displayed


Technologies Used

Language
C#

Framework
.NET 8
WPF

API
Autodesk Inventor API

IDE
Microsoft Visual Studio


UI Components Used

The interface is developed using WPF.

Controls used:

Grid
StackPanel
TextBox
Button
Label
SaveFileDialog
OpenFileDialog
MessageBox



Project Structure

InventorToolkit.FileManager
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── App.xaml
├── App.xaml.cs
└── README.md

Main Functionality

Import Section
Browse Import File

Uses:

Microsoft.Win32.OpenFileDialog

Allows selecting Inventor-compatible files.

Filter used:

Inventor Files (*.ipt;*.iam;*.idw;*.dwg;*.ipn)


Open In Inventor

Uses Autodesk Inventor API:

_app.Documents.Open()

Purpose:

Open selected CAD file directly inside current Inventor workspace.



Export Section

Uses:

Microsoft.Win32.SaveFileDialog

Purpose:

Save active Inventor document to selected location.

Supports:

file renaming
extension selection
overwrite support



Autodesk Inventor API Used

Main classes:

Application Access

Application
Document

Document Management

Documents.Open()
ActiveDocument
SaveAs()

Session Handling

active Inventor instance handling
ribbon button integration




How It Works
Launch

User opens File Manager from Inventor ribbon.



Internal Flow
User clicks File Manager
       ↓
WPF window opens
       ↓
Connects to current Inventor application
       ↓
Import or Export action selected
       ↓
File dialog opens
       ↓
API operation executed
       ↓
Status shown



Logic Used

Import Logic
Step 1

Browse file.

Step 2

Validate extension.

Step 3

Use:

_app.Documents.Open(path, true)

Step 4

Open file in current Inventor session.



Export Logic
Step 1

Read active document.

Step 2

Get file name.

Step 3

Open save dialog.

Step 4

Use:

doc.SaveAs()
Step 5

Export file.


Error Handling

The application handles:

invalid file selection
unsupported file extension
missing active document
export cancellation
incorrect path
duplicate file name
save failures



Errors shown using:

MessageBox.Show()


Challenges Solved

During implementation:

Connected add-in WPF with Inventor
Used active Inventor session
Prevented opening new Inventor instance
Fixed export overwrite issue
Added file rename during export
Added path display
Resolved assembly reference conflicts
Fixed namespace ambiguity
Fixed build locking issues




Learning Outcomes

This module helped understand:

Autodesk Inventor file operations
document handling
API integration
WPF dialog integration
import/export workflows
UI event handling
plugin communication
session management



Future Improvements

Possible enhancements:

batch import
batch export
drag and drop
recent file history
extension auto-detection
PDF direct export
file preview
metadata reader



Author

Developed as part of learning Autodesk Inventor add-in development using C# and WPF.