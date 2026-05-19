using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace InventorToolkit.ObjectCounter
//{
//    class ObjectCounterService
//    {
//    }
//}



//using Inventor;
//using System.Collections.Generic;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static (int total, int circle, int rectangle, int line, int arc)? Count(Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//                return null;

//            int circles = 0;
//            int arcs = 0;
//            int lines = 0;

//            List<SketchLine> lineList = new();

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                if (entity is SketchCircle)
//                    circles++;

//                else if (entity is SketchArc)
//                    arcs++;

//                else if (entity is SketchLine line)
//                {
//                    lines++;
//                    lineList.Add(line);
//                }
//            }

//            int rectangles = lineList.Count / 4;
//            lines -= rectangles * 4;

//            int total = sketch.SketchEntities.Count;
//            return (total, circles, rectangles, lines, arcs);
//        }
//    }
//}


//using Inventor;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static (int total, int circle, int rectangle, int line, int arc)? Count(Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open and edit a sketch first.");
//                return null;
//            }

//            int total = 0;
//            int circles = 0;
//            int rectangles = 0;
//            int lines = 0;
//            int arcs = 0;

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                total++;

//                if (entity is SketchCircle)
//                    circles++;

//                else if (entity is SketchArc)
//                    arcs++;

//                else if (entity is SketchLine)
//                    lines++;

//                else if (entity.Type == ObjectTypeEnum.kSketchBlockDefinitionObject)
//                    rectangles++;
//            }

//            return (total, circles, rectangles, lines, arcs);
//        }
//    }
//}




//using Inventor;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static (int total, int circle, int rectangle, int line, int arc)? Count(Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open and edit a sketch first.");
//                return null;
//            }

//            int circles = 0;
//            int arcs = 0;
//            List<SketchLine> allLines = new();

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                if (entity is SketchCircle)
//                    circles++;

//                else if (entity is SketchArc)
//                    arcs++;

//                else if (entity is SketchLine line)
//                    allLines.Add(line);
//            }

//            int rectangles = DetectRectangles(allLines);

//            int remainingLines = allLines.Count - (rectangles * 4);

//            int total = sketch.SketchEntities.Count;

//            return (total, circles, rectangles, remainingLines, arcs);
//        }

//        private static int DetectRectangles(List<SketchLine> lines)
//        {
//            int rectangleCount = 0;
//            var used = new HashSet<SketchLine>();

//            foreach (var l1 in lines)
//            {
//                if (used.Contains(l1))
//                    continue;

//                var connected = lines
//                    .Where(x =>
//                        x != l1 &&
//                        IsConnected(l1, x) &&
//                        !used.Contains(x))
//                    .ToList();

//                if (connected.Count >= 3)
//                {
//                    rectangleCount++;
//                    used.Add(l1);

//                    for (int i = 0; i < 3; i++)
//                        used.Add(connected[i]);
//                }
//            }

//            return rectangleCount;
//        }

//        private static bool IsConnected(SketchLine a, SketchLine b)
//        {
//            return PointsEqual(a.StartSketchPoint, b.StartSketchPoint) ||
//                   PointsEqual(a.StartSketchPoint, b.EndSketchPoint) ||
//                   PointsEqual(a.EndSketchPoint, b.StartSketchPoint) ||
//                   PointsEqual(a.EndSketchPoint, b.EndSketchPoint);
//        }

//        private static bool PointsEqual(SketchPoint p1, SketchPoint p2)
//        {
//            return System.Math.Abs(p1.Geometry.X - p2.Geometry.X) < 0.001 &&
//                   System.Math.Abs(p1.Geometry.Y - p2.Geometry.Y) < 0.001;
//        }
//    }
//}




//using Inventor;
//using System.Collections.Generic;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static Dictionary<string, int>? Count(Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open and edit a sketch first.");
//                return null;
//            }

//            Dictionary<string, int> counts = new Dictionary<string, int>();
//            int total = 0;

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                total++;

//                string typeName = entity.GetType().Name;

//                if (counts.ContainsKey(typeName))
//                    counts[typeName]++;
//                else
//                    counts[typeName] = 1;
//            }

//            counts.InsertAtStart("Total", total);

//            return counts;
//        }

//        private static void InsertAtStart(this Dictionary<string, int> dict, string key, int value)
//        {
//            var temp = new Dictionary<string, int>();
//            temp[key] = value;

//            foreach (var item in dict)
//                temp[item.Key] = item.Value;

//            dict.Clear();

//            foreach (var item in temp)
//                dict.Add(item.Key, item.Value);
//        }
//    }
//}


//using Inventor;
//using System.Collections.Generic;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static Dictionary<string, int>? Count(Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open and edit a sketch first.");
//                return null;
//            }

//            Dictionary<string, int> counts = new Dictionary<string, int>();
//            int total = 0;

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                string shapeName = GetEntityName(entity);

//                total++;

//                if (counts.ContainsKey(shapeName))
//                    counts[shapeName]++;
//                else
//                    counts.Add(shapeName, 1);
//            }

//            counts.Add("Total", total);

//            return counts;
//        }

//        private static string GetEntityName(SketchEntity entity)
//        {
//            switch (entity.Type)
//            {
//                case ObjectTypeEnum.kSketchCircleObject:
//                    return "Circle";

//                case ObjectTypeEnum.kSketchArcObject:
//                    return "Arc";

//                case ObjectTypeEnum.kSketchLineObject:
//                    return "Line";

//                case ObjectTypeEnum.kSketchEllipseObject:
//                    return "Ellipse";

//                case ObjectTypeEnum.kSketchSplineObject:
//                    return "Spline";

//                case ObjectTypeEnum.kSketchPointObject:
//                    return "Point";

//                default:
//                    return "Other";
//            }
//        }
//    }
//}

//using Inventor;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static Dictionary<string, int>? Count(global::Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open and edit a sketch first.");
//                return null;
//            }

//            Dictionary<string, int> counts = new();

//            List<SketchLine> lines = new();
//            int circles = 0;
//            int arcs = 0;

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                if (entity is SketchCircle)
//                    circles++;

//                else if (entity is SketchArc)
//                    arcs++;

//                else if (entity is SketchLine line)
//                    lines.Add(line);
//            }

//            int rectangles = DetectRectangles(lines);

//            int actualLines = lines.Count - (rectangles * 4);

//            int total =
//                circles +
//                arcs +
//                actualLines +
//                rectangles;

//            counts.Add("Total", total);

//            if (circles > 0)
//                counts.Add("Circle", circles);

//            if (rectangles > 0)
//                counts.Add("Rectangle", rectangles);

//            if (actualLines > 0)
//                counts.Add("Line", actualLines);

//            if (arcs > 0)
//                counts.Add("Arc", arcs);

//            return counts;
//        }

//        private static int DetectRectangles(List<SketchLine> lines)
//        {
//            int count = 0;
//            HashSet<SketchLine> used = new();

//            foreach (var line in lines)
//            {
//                if (used.Contains(line))
//                    continue;

//                var group = FindConnectedLines(line, lines, used);

//                if (group.Count == 4 && IsRectangle(group))
//                {
//                    count++;

//                    foreach (var l in group)
//                        used.Add(l);
//                }
//            }

//            return count;
//        }

//        private static List<SketchLine> FindConnectedLines(
//            SketchLine start,
//            List<SketchLine> all,
//            HashSet<SketchLine> used)
//        {
//            List<SketchLine> result = new() { start };

//            foreach (var line in all)
//            {
//                if (line == start || used.Contains(line))
//                    continue;

//                if (IsConnected(start, line))
//                    result.Add(line);
//            }

//            return result.Take(4).ToList();
//        }

//        private static bool IsRectangle(List<SketchLine> lines)
//        {
//            if (lines.Count != 4)
//                return false;

//            var lengths = lines
//                .Select(l => Distance(
//                    l.StartSketchPoint,
//                    l.EndSketchPoint))
//                .ToList();

//            lengths.Sort();

//            return
//                System.Math.Abs(lengths[0] - lengths[1]) < 0.001 &&
//                System.Math.Abs(lengths[2] - lengths[3]) < 0.001;
//        }

//        private static bool IsConnected(SketchLine a, SketchLine b)
//        {
//            return
//                SamePoint(a.StartSketchPoint, b.StartSketchPoint) ||
//                SamePoint(a.StartSketchPoint, b.EndSketchPoint) ||
//                SamePoint(a.EndSketchPoint, b.StartSketchPoint) ||
//                SamePoint(a.EndSketchPoint, b.EndSketchPoint);
//        }

//        private static bool SamePoint(SketchPoint p1, SketchPoint p2)
//        {
//            return
//                System.Math.Abs(p1.Geometry.X - p2.Geometry.X) < 0.001 &&
//                System.Math.Abs(p1.Geometry.Y - p2.Geometry.Y) < 0.001;
//        }

//        private static double Distance(SketchPoint p1, SketchPoint p2)
//        {
//            double dx = p1.Geometry.X - p2.Geometry.X;
//            double dy = p1.Geometry.Y - p2.Geometry.Y;

//            return System.Math.Sqrt(dx * dx + dy * dy);
//        }
//    }
//}


//using Inventor;
//using System.Collections.Generic;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static Dictionary<string, int>? Count(global::Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open and edit a sketch first.");
//                return null;
//            }

//            Dictionary<string, int> counts = new();
//            int total = 0;

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                total++;

//                string typeName = entity.GetType().Name;

//                if (counts.ContainsKey(typeName))
//                    counts[typeName]++;
//                else
//                    counts[typeName] = 1;
//            }

//            Dictionary<string, int> finalResult = new();

//            finalResult.Add("Total", total);

//            foreach (var item in counts)
//            {
//                finalResult.Add(item.Key, item.Value);
//            }

//            return finalResult;
//        }
//    }
//}


//using Inventor;
//using System.Collections.Generic;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static Dictionary<string, int>? Count(global::Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open and edit a sketch first.");
//                return null;
//            }

//            Dictionary<string, int> counts = new();

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                string name = GetEntityName(entity);

//                if (counts.ContainsKey(name))
//                    counts[name]++;
//                else
//                    counts[name] = 1;
//            }

//            int total = sketch.SketchEntities.Count;

//            Dictionary<string, int> result = new();
//            result.Add("Total", total);

//            foreach (var item in counts)
//                result.Add(item.Key, item.Value);

//            return result;
//        }

//        private static string GetEntityName(SketchEntity entity)
//        {
//            if (entity is SketchLine) return "Line";
//            if (entity is SketchCircle) return "Circle";
//            if (entity is SketchArc) return "Arc";
//            if (entity is SketchEllipse) return "Ellipse";
//            if (entity is SketchEllipticalArc) return "Elliptical Arc";
//            if (entity is SketchSpline) return "Spline";
//            if (entity is SketchFixedSpline) return "Fixed Spline";
//            if (entity is SketchEquationCurve) return "Equation Curve";
//            if (entity is SketchOffsetSpline) return "Offset Spline";
//            if (entity is SketchPoint) return "Point";

//            return "Other";
//        }
//    }
//}



//using Inventor;
//using System.Collections.Generic;
//using System.Windows;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static Dictionary<string, int>? Count(global::Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open and edit a sketch first.");
//                return null;
//            }

//            Dictionary<string, int> counts = new();
//            int total = 0;

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                total++;

//                string entityName = entity.Type.ToString()
//                    .Replace("k", "")
//                    .Replace("Object", "")
//                    .Replace("Sketch", "")
//                    .Replace("Proxy", "")
//                    .Trim();

//                if (counts.ContainsKey(entityName))
//                    counts[entityName]++;
//                else
//                    counts.Add(entityName, 1);
//            }

//            Dictionary<string, int> result = new();
//            result.Add("Total", total);

//            foreach (var item in counts)
//                result.Add(item.Key, item.Value);

//            return result;
//        }
//    }
//}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows;
//using Inventor;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static Dictionary<string, int>? Count(global::Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open sketch in edit mode first.");
//                return null;
//            }

//            Dictionary<string, int> counts = new();

//            int total = sketch.SketchEntities.Count;
//            counts.Add("Total", total);

//            List<SketchLine> lines = new();
//            List<SketchArc> arcs = new();

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                string name = entity.GetType().Name;

//                if (!counts.ContainsKey(name))
//                    counts[name] = 0;

//                counts[name]++;

//                if (entity is SketchLine l)
//                    lines.Add(l);

//                if (entity is SketchArc a)
//                    arcs.Add(a);
//            }

//            int rectangleCount = DetectRectangles(lines);
//            int slotCount = DetectSlots(lines, arcs);

//            if (rectangleCount > 0)
//                counts["Rectangle"] = rectangleCount;

//            if (slotCount > 0)
//                counts["Slot"] = slotCount;

//            return counts;
//        }

//        private static int DetectRectangles(List<SketchLine> lines)
//        {
//            int count = 0;
//            HashSet<SketchLine> used = new();

//            foreach (var line in lines)
//            {
//                if (used.Contains(line))
//                    continue;

//                var connected = lines
//                    .Where(x => x != line && IsConnected(line, x) && !used.Contains(x))
//                    .ToList();

//                if (connected.Count >= 3)
//                {
//                    count++;
//                    used.Add(line);

//                    foreach (var c in connected.Take(3))
//                        used.Add(c);
//                }
//            }

//            return count;
//        }

//        private static int DetectSlots(List<SketchLine> lines, List<SketchArc> arcs)
//        {
//            int slotCount = 0;

//            if (lines.Count >= 2 && arcs.Count >= 2)
//                slotCount = Math.Min(lines.Count / 2, arcs.Count / 2);

//            return slotCount;
//        }

//        private static bool IsConnected(SketchLine a, SketchLine b)
//        {
//            return PointsEqual(a.StartSketchPoint, b.StartSketchPoint) ||
//                   PointsEqual(a.StartSketchPoint, b.EndSketchPoint) ||
//                   PointsEqual(a.EndSketchPoint, b.StartSketchPoint) ||
//                   PointsEqual(a.EndSketchPoint, b.EndSketchPoint);
//        }

//        private static bool PointsEqual(SketchPoint p1, SketchPoint p2)
//        {
//            return Math.Abs(p1.Geometry.X - p2.Geometry.X) < 0.001 &&
//                   Math.Abs(p1.Geometry.Y - p2.Geometry.Y) < 0.001;
//        }
//    }
//}




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows;
//using Inventor;

//namespace InventorToolkit.ObjectCounter
//{
//    public static class ObjectCounterService
//    {
//        public static Dictionary<string, int>? Count(global::Inventor.Application app)
//        {
//            if (app.ActiveEditObject is not PlanarSketch sketch)
//            {
//                MessageBox.Show("Open sketch in edit mode first.");
//                return null;
//            }

//            Dictionary<string, int> counts = new();

//            List<SketchLine> lines = new();
//            List<SketchArc> arcs = new();

//            counts["Total"] = sketch.SketchEntities.Count;

//            foreach (SketchEntity entity in sketch.SketchEntities)
//            {
//                if (entity is SketchLine)
//                    AddCount(counts, "Line");

//                else if (entity is SketchCircle)
//                    AddCount(counts, "Circle");

//                else if (entity is SketchArc)
//                    AddCount(counts, "Arc");

//                else if (entity is SketchEllipse)
//                    AddCount(counts, "Ellipse");

//                else if (entity is SketchEllipticalArc)
//                    AddCount(counts, "Elliptical Arc");

//                else if (entity is SketchSpline)
//                    AddCount(counts, "Spline");

//                else if (entity is SketchPoint)
//                    AddCount(counts, "Point");

//                else
//                    AddCount(counts, "Other");

//                if (entity is SketchLine line)
//                    lines.Add(line);

//                if (entity is SketchArc arc)
//                    arcs.Add(arc);
//            }

//            int rectangleCount = DetectRectangles(lines);
//            int slotCount = DetectSlots(lines, arcs);

//            if (rectangleCount > 0)
//                counts["Rectangle"] = rectangleCount;

//            if (slotCount > 0)
//                counts["Slot"] = slotCount;

//            return counts;
//        }

//        private static void AddCount(Dictionary<string, int> dict, string key)
//        {
//            if (!dict.ContainsKey(key))
//                dict[key] = 0;

//            dict[key]++;
//        }

//        private static int DetectRectangles(List<SketchLine> lines)
//        {
//            int rectangleCount = 0;
//            HashSet<SketchLine> used = new();

//            foreach (var l1 in lines)
//            {
//                if (used.Contains(l1))
//                    continue;

//                var connected = lines
//                    .Where(x => x != l1 && IsConnected(l1, x) && !used.Contains(x))
//                    .ToList();

//                if (connected.Count >= 3)
//                {
//                    rectangleCount++;
//                    used.Add(l1);

//                    foreach (var c in connected.Take(3))
//                        used.Add(c);
//                }
//            }

//            return rectangleCount;
//        }

//        private static int DetectSlots(List<SketchLine> lines, List<SketchArc> arcs)
//        {
//            if (lines.Count >= 2 && arcs.Count >= 2)
//                return Math.Min(lines.Count / 2, arcs.Count / 2);

//            return 0;
//        }

//        private static bool IsConnected(SketchLine a, SketchLine b)
//        {
//            return PointsEqual(a.StartSketchPoint, b.StartSketchPoint) ||
//                   PointsEqual(a.StartSketchPoint, b.EndSketchPoint) ||
//                   PointsEqual(a.EndSketchPoint, b.StartSketchPoint) ||
//                   PointsEqual(a.EndSketchPoint, b.EndSketchPoint);
//        }

//        private static bool PointsEqual(SketchPoint p1, SketchPoint p2)
//        {
//            return Math.Abs(p1.Geometry.X - p2.Geometry.X) < 0.001 &&
//                   Math.Abs(p1.Geometry.Y - p2.Geometry.Y) < 0.001;
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Inventor;

namespace InventorToolkit.ObjectCounter
{
    public static class ObjectCounterService
    {
        public static Dictionary<string, int>? Count(global::Inventor.Application app)
        {
            if (app.ActiveEditObject is not PlanarSketch sketch)
            {
                MessageBox.Show("Open sketch in edit mode first.");
                return null;
            }

            Dictionary<string, int> counts = new();
            List<SketchLine> lines = new();
            List<SketchArc> arcs = new();

            counts["Total"] = sketch.SketchEntities.Count;

            foreach (SketchEntity entity in sketch.SketchEntities)
            {
                if (entity is SketchLine line)
                {
                    AddCount(counts, "SketchLine");
                    lines.Add(line);
                }
                else if (entity is SketchCircle)
                {
                    AddCount(counts, "SketchCircle");
                }
                else if (entity is SketchArc arc)
                {
                    AddCount(counts, "SketchArc");
                    arcs.Add(arc);
                }
                else if (entity is SketchEllipse)
                {
                    AddCount(counts, "SketchEllipse");
                }
                else if (entity is SketchEllipticalArc)
                {
                    AddCount(counts, "SketchEllipticalArc");
                }
                else if (entity is SketchSpline)
                {
                    AddCount(counts, "SketchSpline");
                }
                else if (entity is SketchPoint)
                {
                    AddCount(counts, "SketchPoint");
                }
                else
                {
                    AddCount(counts, "Other");
                }
            }

            int rectangleCount = DetectRectangles(lines);
            int slotCount = DetectSlots(lines, arcs);
            int polygonCount = DetectPolygons(lines);

            if (rectangleCount > 0)
                counts["Rectangle"] = rectangleCount;

            if (slotCount > 0)
                counts["Slot"] = slotCount;

            if (polygonCount > 0)
                counts["Polygon"] = polygonCount;

            return counts;
        }

        private static void AddCount(Dictionary<string, int> dict, string key)
        {
            if (!dict.ContainsKey(key))
                dict[key] = 0;

            dict[key]++;
        }

        private static int DetectRectangles(List<SketchLine> lines)
        {
            int rectangleCount = 0;
            HashSet<SketchLine> used = new();

            foreach (var l1 in lines)
            {
                if (used.Contains(l1))
                    continue;

                var group = lines
                    .Where(x => x != l1 && IsConnected(l1, x) && !used.Contains(x))
                    .Take(3)
                    .ToList();

                if (group.Count == 3)
                {
                    rectangleCount++;
                    used.Add(l1);

                    foreach (var g in group)
                        used.Add(g);
                }
            }

            return rectangleCount;
        }

        private static int DetectSlots(List<SketchLine> lines, List<SketchArc> arcs)
        {
            return Math.Min(lines.Count / 2, arcs.Count / 2);
        }

        private static int DetectPolygons(List<SketchLine> lines)
        {
            int polygonCount = 0;

            if (lines.Count >= 5)
                polygonCount = lines.Count / 5;

            return polygonCount;
        }

        private static bool IsConnected(SketchLine a, SketchLine b)
        {
            return PointsEqual(a.StartSketchPoint, b.StartSketchPoint) ||
                   PointsEqual(a.StartSketchPoint, b.EndSketchPoint) ||
                   PointsEqual(a.EndSketchPoint, b.StartSketchPoint) ||
                   PointsEqual(a.EndSketchPoint, b.EndSketchPoint);
        }

        private static bool PointsEqual(SketchPoint p1, SketchPoint p2)
        {
            return Math.Abs(p1.Geometry.X - p2.Geometry.X) < 0.001 &&
                   Math.Abs(p1.Geometry.Y - p2.Geometry.Y) < 0.001;
        }
    }
}





