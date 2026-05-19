using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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





