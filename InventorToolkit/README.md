# 🛠 InventorToolkit

> A custom add-in toolkit for :contentReference[oaicite:0]{index=0} developed using **C#**, **.NET 8**, **WPF**, and the Autodesk Inventor API.

InventorToolkit extends Autodesk Inventor with productivity utilities focused on sketch analysis and CAD file management.

The project demonstrates custom add-in development, ribbon integration, sketch traversal, shape recognition, and desktop UI integration using WPF.

---

## ✨ Modules Included

### 📐 ObjectCounter

Analyzes active 2D sketches and counts entities.

### Features

✔ Total object count  
✔ Individual entity count  
✔ Shape recognition  
✔ Custom WPF result display  

### Supported

- Line  
- Circle  
- Arc  
- Point  
- Spline  
- Ellipse  
- Rectangle *(detected)*  
- Slot *(detected)*  
- Polygon *(detected)*  

---

### 📁 FileManager

Provides file import/export utilities inside Inventor.

### Features

✔ Import CAD files  
✔ Export active document  
✔ Rename before save  
✔ Status display  
✔ Save location selection  

### Supported Files

- `.ipt`
- `.iam`
- `.idw`
- `.dwg`
- `.ipn`
- `.pdf`

---

# 🎯 Project Purpose

The toolkit was developed to explore Autodesk Inventor add-in development and create practical productivity tools for CAD workflows.

Main objectives:

- Understand Inventor API
- Build custom ribbon tools
- Traverse sketch objects
- Analyze geometry
- Handle file operations
- Create custom WPF interfaces

---

# 🛠 Technologies Used

| Technology | Details |
|---|---|
| Language | C# |
| Framework | .NET 8 |
| UI | WPF |
| CAD API | Autodesk Inventor API |
| IDE | Microsoft Visual Studio |

---

# 📂 Project Structure

```text
InventorToolkit
│
├── StandardAddInServer.cs
├── CommandHandler.cs
│
├── ObjectCounter
│   └── ObjectCounterService.cs
│
├── FileManager
│   ├── MainWindow.xaml
│   └── MainWindow.xaml.cs
│
├── ResultWindow.xaml
├── ResultWindow.xaml.cs
│
├── manifest files
└── resources
```

---

# 🚀 How It Works

---

## Add-in Initialization

The plugin loads through:

```csharp
StandardAddInServer.cs
```

Responsibilities:

- Connect to Inventor
- Create custom ribbon tab
- Create ribbon panel
- Add command buttons
- Link events

---

# 🖥 Ribbon UI

Custom tab created:

## InventorToolkit

Contains:

### Tools Panel

Buttons:

- Object Counter  
- File Manager  

---

# ⚙ Workflow

---

## ObjectCounter Flow

```text
User opens sketch
       ↓
Click Object Counter
       ↓
CommandHandler
       ↓
ObjectCounterService
       ↓
Read active sketch
       ↓
Traverse entities
       ↓
Count objects
       ↓
Detect shapes
       ↓
Show WPF result
```

---

## FileManager Flow

```text
Click File Manager
      ↓
Open WPF window
      ↓
Import file
      ↓
OR export file
      ↓
Execute Inventor API
      ↓
Show status
```

---

# 🔌 Autodesk Inventor API Used

---

## Core Application

- Application  
- Document  
- PartDocument  
- NameValueMap  

---

## Sketch

- PlanarSketch  
- SketchEntity  
- SketchLine  
- SketchCircle  
- SketchArc  
- SketchPoint  

---

## Geometry

- Point2d  
- TransientGeometry  

---

## UI

- Ribbon  
- RibbonTab  
- RibbonPanel  
- ButtonDefinition  

---

# 🧠 Logic Used

---

## Object Counting

Traverses:

```csharp
sketch.SketchEntities
```

Uses runtime type checking:

```csharp
entity is SketchLine
entity is SketchCircle
entity is SketchArc
```

---

# 🧩 Shape Recognition

---

## Rectangle

Detected by:

✔ grouping 4 connected lines

---

## Slot

Detected by:

✔ 2 arcs + 2 lines

---

## Polygon

Detected by:

✔ closed connected line groups

---

# 🖥 WPF UI

Built using WPF.

### Windows

---

## Result Window

Displays:

- shape name  
- count  
- total count  

---

## File Manager Window

Provides:

- import  
- export  
- path display  
- status updates  

---

# ⚡ Challenges Solved

During development:

- Inventor DLL locking  
- Application reference ambiguity  
- WPF integration  
- Active document access  
- Sketch traversal  
- Shape recognition  
- Export overwrite  
- Add-in loading  
- Manifest configuration  

---

# 📚 Learning Outcomes

This project helped understand:

- Inventor add-in architecture  
- Ribbon customization  
- API integration  
- WPF integration  
- Event handling  
- Sketch traversal  
- Shape recognition  
- File operations  
- Plugin debugging  

---

# 🔮 Future Enhancements

Possible upgrades:

- 3D sketch support  
- dimension extraction  
- CSV export  
- PDF reporting  
- chart generation  
- transaction editing  
- geometry editing  
- assembly analysis  
- layer management  

---

# 📦 Repository Usage

### Clone

```bash
git clone <your-repository-url>
```

---

### Open

Using:

:contentReference[oaicite:1]{index=1}

---

### Build

- Debug  
- Release  

---

### Run

1. Start :contentReference[oaicite:2]{index=2}  
2. Load add-in  
3. Use ribbon tools  

---

# 👨‍💻 Author

Developed as Autodesk Inventor plugin practice project for learning:

- CAD automation  
- Inventor API  
- Add-in architecture  
- WPF desktop apps  
- geometry analysis  

---

# ⭐ Project Summary

InventorToolkit is a modular Autodesk Inventor add-in toolkit that provides sketch analysis and file management tools.

It demonstrates:

✔ Autodesk Inventor API  
✔ C# Add-in development  
✔ Ribbon customization  
✔ WPF integration  
✔ Sketch traversal  
✔ Shape recognition  
✔ File handling  
✔ CAD automation  

---
