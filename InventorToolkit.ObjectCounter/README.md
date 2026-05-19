InventorToolkit.ObjectCounter

A custom sketch analysis tool developed for Autodesk Inventor using C# and the Autodesk Inventor API.

This module counts sketch entities from the active 2D sketch and displays object information through a custom WPF window.

The plugin analyzes both:

raw sketch entities
recognized combined shapes


Project Purpose

The purpose of this module is to inspect active sketches in Autodesk Inventor and dynamically count objects used in CAD drawings.

This helps understand sketch composition and geometry usage.

Features
Entity Counting

Counts all available entities from active sketch.

Examples:

SketchLine
SketchCircle
SketchArc
SketchPoint
SketchEllipse
SketchSpline



Shape Recognition

Custom shape detection added.

Recognizes:

Rectangle
Slot
Polygon

These are not directly exposed by Inventor API, so custom logic was implemented.



Technologies Used

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
InventorToolkit.ObjectCounter
│
├── ObjectCounterService.cs
├── ResultWindow.xaml
├── ResultWindow.xaml.cs
├── CommandHandler.cs
└── README.md


Main Goal

The plugin counts all entities present in the currently edited 2D sketch.

Output includes:

total entity count
individual entity counts
combined shape counts

Displayed in custom result window.



Autodesk Inventor API Used

Main classes:

Application

Application
Document

Sketch

PlanarSketch
SketchEntity
SketchEntities

Entity Types

SketchLine
SketchCircle
SketchArc
SketchPoint
SketchEllipse
SketchSpline

Geometry

SketchPoint
Point2d


How It Works

Workflow
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



Implementation Logic
Step 1

Get current sketch.

Using:

app.ActiveEditObject

Step 2

Validate sketch.

Ensures user is editing 2D sketch.

Using:

PlanarSketch

Step 3

Traverse entities.

Using:

sketch.SketchEntities

Step 4

Check entity type.

Using:

entity.GetType().Name

Dynamic counting performed through dictionary.



Dynamic Counting Logic

The application automatically counts all entity types.

No hardcoded list required.

Implemented using:

Dictionary<string, int>

This allows future entities to be counted automatically.

Example:

SketchLine : 20
SketchCircle : 3
SketchArc : 5
SketchPoint : 12
Shape Detection


Rectangle Detection

Inventor stores rectangle as:

4 separate SketchLine objects

Custom logic groups:

4 connected lines

Then:

Rectangle = 1



Slot Detection

Inventor stores slot as:

2 lines
2 arcs

Custom grouping:

identifies slot shape



Polygon Detection

Polygon tool creates:

multiple connected lines

Custom logic:

closed line loop
line count > 4

Recognized as polygon.




WPF UI

Custom window created.

Displays:

Total

Total entity count.

Entity List

Dynamic list of entities.

Shape Count

Recognized shapes.

Scrollable interface added for large sketches.






Example Output
Total Objects : 135

SketchPoint : 71
SketchLine : 55
SketchArc : 4
SketchCircle : 2

Rectangle : 3
Slot : 2
Polygon : 11




Important Technical Concept

Transaction

This module is read-only.

No document modifications occur.

Therefore:

No transaction required.

Because it only:

reads
traverses
analyzes
displays

No geometry creation/editing.




Challenges Solved

During development:

detecting rectangle from lines
detecting slot from mixed entities
polygon grouping
dynamic entity detection
WPF display
ribbon integration
ActiveEditObject access
COM object handling
namespace ambiguity
plugin loading




Learning Outcomes

This project helped understand:

Inventor sketch traversal
Inventor API structure
WPF integration
dynamic counting
shape recognition
geometric logic
entity relationships
plugin architecture
debugging





Future Improvements

Possible upgrades:

3D sketch support
feature tree counting
assembly entity analysis
automatic reporting
CSV export
chart visualization
dimension counting
construction geometry filter
transaction-based editing



Author

Developed as Autodesk Inventor API practice project for learning sketch traversal and custom object counting.