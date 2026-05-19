# 📁 InventorToolkit.FileManager

> A beginner-friendly CAD file import/export add-in for :contentReference[oaicite:0]{index=0} developed using **C#**, **.NET 8**, **WPF**, and Autodesk Inventor API.

This module allows users to import Inventor-supported files into the current Inventor session and export active documents using a simple custom WPF interface.

---

## ✨ Features

### 📥 Import

Allows importing supported Inventor files.

### Supported Extensions

| Extension | File Type |
|---|---|
| `.ipt` | Part file |
| `.iam` | Assembly file |
| `.idw` | Drawing file |
| `.dwg` | AutoCAD drawing |
| `.ipn` | Presentation file |

---

### Import Workflow

```text
Browse file
     ↓
Select supported file
     ↓
Click Open
     ↓
File opens in Inventor
     ↓
Status displayed
```

---

### 📤 Export

Allows exporting the active Inventor document.

### Supported Export Formats

| Extension | Output |
|---|---|
| `.ipt` | Part |
| `.iam` | Assembly |
| `.idw` | Drawing |
| `.dwg` | CAD |
| `.pdf` | PDF |

---

### Export Workflow

```text
Click Export
      ↓
Save dialog opens
      ↓
Select location
      ↓
Rename file (optional)
      ↓
Save
      ↓
Status displayed
```

---

# 🎯 Project Purpose

The goal of this module is to simplify file operations inside Autodesk Inventor.

Users can:

✔ Browse supported CAD files  
✔ Open files in current Inventor session  
✔ Export active documents  
✔ Select save location  
✔ Rename file before export  
✔ View operation status  

---

# 🛠 Technologies Used

| Technology | Details |
|---|---|
| Language | C# |
| Framework | .NET 8 |
| UI | WPF |
| API | Autodesk Inventor API |
| IDE | Microsoft Visual Studio |

---

# 🖥 UI Components Used

Built using WPF.

### Controls

- Grid  
- StackPanel  
- TextBox  
- Button  
- Label  
- OpenFileDialog  
- SaveFileDialog  
- MessageBox  

---

# 📂 Project Structure

```text
InventorToolkit.FileManager
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── App.xaml
├── App.xaml.cs
└── README.md
```

---

# 🚀 Main Functionality

---

## Import Section

### Browse Import File

Uses:

```csharp
Microsoft.Win32.OpenFileDialog
```

Allows selecting supported Inventor files.

### Filter

```text
Inventor Files (*.ipt;*.iam;*.idw;*.dwg;*.ipn)
```

---

## Open In Inventor

Uses Autodesk Inventor API:

```csharp
_app.Documents.Open()
```

Purpose:

Open selected CAD file directly inside the current Inventor workspace.

---

## Export Section

Uses:

```csharp
Microsoft.Win32.SaveFileDialog
```

Purpose:

Save active document to selected location.

Supports:

- file renaming  
- extension selection  
- overwrite handling  

---

# 🔌 Autodesk Inventor API Used

---

## Application Access

- Application  
- Document  

---

## Document Management

- Documents.Open()  
- ActiveDocument  
- SaveAs()  

---

## Session Handling

- active Inventor instance  
- ribbon integration  
- command execution  

---

# ⚙ How It Works

---

## Launch

User opens File Manager from Inventor ribbon.

---

## Internal Flow

```text
User clicks File Manager
        ↓
WPF window opens
        ↓
Connect to active Inventor
        ↓
Import / Export selected
        ↓
File dialog opens
        ↓
API operation executes
        ↓
Status shown
```

---

# 🧠 Logic Used

---

## Import Logic

### Step 1

Browse file.

### Step 2

Validate extension.

### Step 3

Open file:

```csharp
_app.Documents.Open(path, true)
```

### Step 4

Load inside current Inventor session.

---

## Export Logic

### Step 1

Read active document.

### Step 2

Get file name.

### Step 3

Open save dialog.

### Step 4

Save using:

```csharp
doc.SaveAs()
```

### Step 5

Export file.

---

# 🛡 Error Handling

The application handles:

- invalid file selection  
- unsupported extension  
- missing active document  
- export cancellation  
- incorrect path  
- duplicate file name  
- save failure  

---

### Error Display

```csharp
MessageBox.Show()
```

---

# ⚡ Challenges Solved

During implementation:

- Connected WPF to Inventor add-in  
- Used active Inventor session  
- Prevented launching new Inventor instance  
- Fixed export overwrite issue  
- Added rename during export  
- Added path display  
- Resolved assembly reference conflicts  
- Fixed namespace ambiguity  
- Fixed build lock issues  

---

# 📚 Learning Outcomes

This project helped understand:

- Autodesk Inventor file operations  
- document management  
- API integration  
- WPF dialog integration  
- import/export workflow  
- UI event handling  
- plugin communication  
- session management  

---

# 🔮 Future Improvements

Possible upgrades:

- batch import  
- batch export  
- drag and drop  
- recent file history  
- extension auto-detection  
- direct PDF export  
- preview panel  
- metadata reader  

---

# 👨‍💻 Author

Developed as part of learning:

- Autodesk Inventor add-in development  
- C# desktop application development  
- WPF interface design  
- CAD automation  
- API integration  

---

# ⭐ Project Summary

InventorToolkit.FileManager is a lightweight Inventor utility add-in that simplifies importing and exporting CAD files directly from Autodesk Inventor.

It demonstrates:

✔ Inventor API integration  
✔ WPF UI development  
✔ file management  
✔ session control  
✔ plugin communication  
✔ desktop automation  

---
