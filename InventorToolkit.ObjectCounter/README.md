# 📐 InventorToolkit.ObjectCounter

> Custom sketch analysis add-in for :contentReference[oaicite:0]{index=0} built with **C#**, **.NET 8**, **WPF**, and the Autodesk Inventor API.

This plugin analyzes the active 2D sketch and counts all sketch entities, including both **raw entities** and **recognized combined shapes**.

---

## ✨ Features

### ✅ Entity Counting

Counts all sketch entities present inside the active sketch:

- SketchLine  
- SketchCircle  
- SketchArc  
- SketchPoint  
- SketchEllipse  
- SketchSpline  

---

### ✅ Shape Recognition

Custom detection logic added for shapes not directly exposed by Inventor API:

- Rectangle  
- Slot  
- Polygon  

These shapes are internally stored as multiple primitive entities, so custom grouping logic was implemented.

---

# 🎯 Project Purpose

This module was developed to inspect active sketches in Autodesk Inventor and dynamically analyze object composition inside CAD drawings.

It helps understand:

- sketch structure  
- geometry usage  
- object distribution  
- shape patterns  

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
InventorToolkit.ObjectCounter
│
├── ObjectCounterService.cs
├── CommandHandler.cs
├── ResultWindow.xaml
├── ResultWindow.xaml.cs
└── README.md
```

---

# 🚀 Main Goal

The plugin counts all entities inside the currently edited 2D sketch.

### Output includes:

✔ Total object count  
✔ Individual entity counts  
✔ Combined shape counts  

Results are displayed in a custom WPF window.

---

# 🔌 Autodesk Inventor API Used

## Main Classes

- Application  
- Document  
- PlanarSketch  
- SketchEntity  
- SketchEntities  

---

## Entity Classes

- SketchLine  
- SketchCircle  
- SketchArc  
- SketchPoint  
- SketchEllipse  
- SketchSpline  

---

## Geometry Classes

- SketchPoint  
- Point2d  

---

# ⚙ Workflow

```text
User opens sketch
        ↓
Edit sketch mode
        ↓
Click Object Counter
        ↓
Get active sketch
        ↓
Traverse SketchEntities
        ↓
Count entities
        ↓
Detect combined shapes
        ↓
Show result window
```

---

# 🧠 Implementation Logic

---

## Step 1 — Get Current Sketch

Uses:

```csharp
app.ActiveEditObject
```

Retrieves currently active sketch object.

---

## Step 2 — Validate Sketch

Checks whether user is editing a valid 2D sketch.

Uses:

```csharp
PlanarSketch
```

---

## Step 3 — Traverse Entities

Uses:

```csharp
sketch.SketchEntities
```

Loops through all sketch entities.

---

## Step 4 — Detect Entity Type

Uses:

```csharp
entity.GetType().Name
```

Dynamic counting performed using dictionary.

---

# 🔄 Dynamic Counting Logic

The application automatically counts all entity types.

No hardcoded list required.

Implemented using:

```csharp
Dictionary<string, int>
```

### Example:

```text
SketchLine : 20
SketchCircle : 3
SketchArc : 5
SketchPoint : 12
```

---

# 🧩 Shape Detection Logic

---

## Rectangle Detection

Inventor stores rectangle as:

- 4 separate SketchLine objects

Custom grouping identifies:

✔ 4 connected lines  
✔ Closed shape  

Then counted as:

```text
Rectangle = 1
```

---

## Slot Detection

Inventor stores slot as:

- 2 lines  
- 2 arcs  

Custom logic identifies matching pattern.

---

## Polygon Detection

Inventor polygon tool creates:

- multiple connected lines

Custom detection checks:

✔ closed loop  
✔ line count > 4  

Recognized as polygon.

---

# 🖥 WPF UI

Custom result window created.

### Displays:

- Total count  
- Entity list  
- Shape count  
- Scrollable view  

Supports large sketches.

---

# 📸 Example Output

```text
Total Objects : 135

SketchPoint : 71
SketchLine : 55
SketchArc : 4
SketchCircle : 2

Rectangle : 3
Slot : 2
Polygon : 11
```

---

# 💡 Important Technical Concept

## Transaction

This module is **read-only**.

No modifications are made to Inventor documents.

Therefore:

✅ Transaction not required

Because it only:

- reads  
- traverses  
- analyzes  
- displays  

---

# ⚡ Challenges Solved

During development:

- rectangle recognition  
- slot recognition  
- polygon grouping  
- dynamic entity detection  
- WPF integration  
- ribbon integration  
- ActiveEditObject handling  
- COM object handling  
- namespace ambiguity  
- plugin loading  

---

# 📚 Learning Outcomes

This project helped understand:

- Inventor API structure  
- sketch traversal  
- entity relationships  
- WPF integration  
- plugin architecture  
- debugging  
- shape recognition  
- dynamic counting  
- geometric analysis  

---

# 🔮 Future Improvements

Possible upgrades:

- 3D sketch support  
- feature tree counting  
- assembly analysis  
- CSV export  
- report generation  
- charts  
- dimension counting  
- construction geometry filtering  
- editable transaction support  

---

# 👨‍💻 Author

Developed as practice project for learning:

- Autodesk Inventor API  
- Sketch traversal  
- CAD automation  
- Add-in architecture  
- Geometry analysis  

---

# ⭐ Project Summary

InventorToolkit.ObjectCounter is a lightweight Inventor add-in that inspects active sketches and performs intelligent object counting using both direct entity traversal and custom shape recognition.

It demonstrates practical use of:

✔ Autodesk Inventor API  
✔ C# Add-in development  
✔ WPF UI  
✔ Sketch geometry analysis  
✔ CAD automation  

---
