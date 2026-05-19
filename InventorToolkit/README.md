InventorToolkit

A custom add-in for Autodesk Inventor developed using C# and .NET to extend Inventor functionality.
This toolkit provides productivity utilities for sketch analysis and file management inside Autodesk Inventor.

Features
1. Object Counter

Counts sketch entities from the active 2D sketch.

Supported:

Total Objects
Line
Circle
Arc
Point
Rectangle (detected from grouped lines)
Slot (detected from line + arc combination)
Polygon (detected from connected line groups)

Displays result in a custom WPF window.


2. File Manager

Helps import and export Inventor files.

Functions:

Import
Browse local Inventor file
Open selected file directly inside Inventor

Supported file types:

.ipt
.iam
.idw
.dwg
.ipn


Export
Export active Inventor document
Select save location
Rename file before export
Save using standard file dialog
Status confirmation


Technology Used

Language
C#

Framework
.NET 8
WPF

CAD API
Autodesk Inventor API

IDE
Microsoft Visual Studio


Project Structure
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


How It Works

Add-in Initialization

The add-in loads through StandardAddInServer.cs.

Responsibilities:

Connect to Inventor
Create custom ribbon tab
Create ribbon panel
Add command buttons
Link buttons to event handlers


Ribbon UI

Custom tab added:

InventorToolkit

Contains:

Tools panel

Buttons:

Object Counter
File Manager



Workflow

Object Counter Flow
User opens sketch
      ↓
User clicks Object Counter
      ↓
CommandHandler triggers service
      ↓
ObjectCounterService reads active sketch
      ↓
Traverses SketchEntities
      ↓
Counts entities
      ↓
Detects combined shapes
      ↓
Displays WPF result window




File Manager Flow

User clicks File Manager
      ↓
MainWindow opens
      ↓
User selects file
      ↓
Import into Inventor
      ↓
Or export active document
      ↓
Save dialog
      ↓
Confirmation


Autodesk Inventor API Used

Main classes used:

Core Application

Application
Document
PartDocument
NameValueMap


Sketch

PlanarSketch
SketchEntity
SketchLine
SketchCircle
SketchArc
SketchPoint


Geometry

Point2d
TransientGeometry


UI

Ribbon
RibbonTab
RibbonPanel
ButtonDefinition


Logic Used
O
bject Counting

Traverses:

sketch.SketchEntities


Uses runtime type checking:

entity is SketchLine
entity is SketchCircle
entity is SketchArc


Shape Recognition

Custom detection added:

Rectangle

Detected by:

grouping 4 connected lines

Slot

Detected by:

2 arcs + 2 lines

Polygon

Detected by:

closed connected line groups


UI Used

Built using WPF.

Windows:

Result Window

Shows:

shape name
count
total count


File Manager Window

Provides:

import section
export section
status display


Challenges Solved

During development:

Inventor DLL locking during build
Application reference ambiguity
WPF integration
Active document handling
Sketch traversal
Dynamic shape recognition
Export overwrite handling
Add-in loading
Manifest configuration



Learning Outcomes

This project helped understand:

Autodesk Inventor add-in architecture
Ribbon customization
Inventor API usage
WPF UI integration
event handling
sketch traversal
geometric analysis
custom shape recognition
file operations
debugging plugin workflow



Future Enhancements

Possible upgrades:

3D model entity counting
automatic dimension extraction
shape statistics report
CSV export
PDF report generation
undo transaction support
geometry editing
layer management
assembly object analysis


Author

Developed as Autodesk Inventor plugin practice project for learning Inventor API and custom add-in development.





****************************************************


# Inventor Toolkit

A custom Autodesk Inventor add-in toolkit developed in C# using the Autodesk Inventor API and WPF.  
This project demonstrates plugin development for CAD applications, including ribbon integration, sketch object traversal, object counting, and result visualization.

---

## Project Overview

Inventor Toolkit is a custom add-in created for Autodesk Inventor to automate sketch analysis tasks.

The plugin integrates into the Inventor ribbon and provides tools to inspect active 2D sketches.  
It traverses sketch entities, identifies object types, counts them, and displays results in a WPF interface.

This project was developed as part of a CAD plugin assignment to understand:

- Autodesk Inventor Add-In architecture
- Ribbon customization
- Sketch entity traversal
- Object counting logic
- WPF result display
- File/project organization
- GitHub version tracking

---

## Features

### 1. Ribbon Integration

The plugin adds a custom button to Autodesk Inventor's UI ribbon.

Implemented using:

- StandardAddInServer
- ButtonDefinition
- ControlDefinitions
- RibbonPanel integration

Function:

- Adds launch button
- Starts object traversal process
- Connects UI and business logic

---

## 2. Object Traversal

The plugin reads the currently active 2D sketch and traverses all sketch entities.

Traversal means iterating through each object inside the sketch.

Examples:

- Line
- Circle
- Arc
- Point
- Spline
- Ellipse

Used API:

- PlanarSketch
- SketchEntities
- SketchEntity
- ActiveEditObject

Implementation:

- Access active sketch
- Loop through entity collection
- Detect object type
- Process objects

---

## 3. Object Counting

After traversal, entities are categorized and counted.

Counted objects include:

- SketchLine
- SketchCircle
- SketchArc
- SketchPoint
- SketchSpline
- SketchEllipse

Important:

Composite sketch tools are internally stored as basic entities.

Examples:

### Rectangle

Stored as:

- 4 SketchLine entities

### Polygon

Stored as:

- multiple SketchLine entities

### Slot

Stored as:

- line + arc combinations

This project counts actual sketch entities generated by Inventor.

---

## 4. WPF Result UI

The counted result is shown in a WPF window.

UI includes:

- object type display
- total count display
- formatted result output

Implemented using:

- WPF
- XAML
- C#

Files:

- ResultWindow.xaml
- ResultWindow.xaml.cs

---

## 5. File Management / Project Structure

The project also includes organized file handling.

Managed:

- Add-in manifest
- resource files
- assembly setup
- configuration files
- deployment structure

This improves maintainability and version control.

---

## Autodesk Inventor API Used

Official API:

:contentReference[oaicite:1]{index=1}

Main API objects:

### Application

Used to access Inventor application instance.

### Document

Used to access current active document.

### PartDocument

Used to work with part environment.

### PlanarSketch

Used to access active 2D sketch.

### SketchEntities

Used to traverse sketch objects.

### SketchEntity

Base object for all sketch entities.

### ButtonDefinition

Used to create ribbon button.

### UserInterfaceManager

Used for ribbon integration.

---

## Technologies Used

- C#
- .NET
- WPF
- XAML
- Autodesk Inventor API
- Visual Studio 2022
- Git
- GitHub

---

## Project Workflow

### Step 1

Launch Autodesk Inventor

### Step 2

Open Part File

### Step 3

Create / Edit 2D Sketch

### Step 4

Draw sketch objects

### Step 5

Click custom ribbon button

### Step 6

Plugin reads active sketch

### Step 7

Traverse all sketch entities

### Step 8

Count entities

### Step 9

Display results in WPF UI

---

## Internal Code Flow

System flow:

```text
Inventor Start
    ↓
Load Add-In
    ↓
Create Ribbon Button
    ↓
User Clicks Button
    ↓
Read Active Sketch
    ↓
Traverse SketchEntities
    ↓
Identify Object Type
    ↓
Count Objects
    ↓
Open WPF Window
    ↓
Display Results
```

---

## Project Structure

### StandardAddInServer.cs

Responsibilities:

- Add-in startup
- ribbon creation
- button initialization
- event hookup

---

### ObjectCounter.cs

Responsibilities:

- active sketch access
- traversal logic
- counting logic
- result preparation

---

### ResultWindow.xaml

Responsibilities:

- WPF design
- output layout

---

### ResultWindow.xaml.cs

Responsibilities:

- UI interaction
- displaying object count

---

### Manifest Files

Responsibilities:

- add-in registration
- Inventor loading

---

## Assignment Implementation

Requirement completed:

### Build Plugin for CAD Application

Implemented in Autodesk Inventor.

### Ribbon and Launch Button

Implemented using custom ribbon integration.

### Traverse Objects

Implemented using SketchEntities traversal.

### Count Objects

Implemented using entity classification logic.

### Show Results on WPF UI

Implemented using custom WPF window.

---

## Learning Outcomes

This project helped understand:

- Inventor add-in development
- CAD API usage
- object traversal
- entity recognition
- event handling
- WPF integration
- GitHub versioning
- project organization

---

## Future Improvements

Planned:

- rectangle recognition
- polygon recognition
- slot recognition
- combined shape detection
- export results
- enhanced UI
- entity filtering
- sketch analysis tools

---

## Repository Usage

Clone repository:

```bash
git clone <your-repo-url>
```

Open in:

- Visual Studio 2022

Build:

- Debug / Release

Run:

- Start Autodesk Inventor
- Load add-in
- Use ribbon button

---

## Author

Developed as Autodesk Inventor toolkit project for CAD automation and plugin development.