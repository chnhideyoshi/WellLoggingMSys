using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphicsDemo
{
    public class Coordinate
    {
        public float X=0;
        public float Y=0;
        public Coordinate(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Color Color=Color.Black;
    }
    public class LineSegment
    {
        public Coordinate StartPoint;
        public Coordinate EndPoint;
        public LineSegment(Coordinate startPoint, Coordinate endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public Color Color=Color.Black;
    }
    public class Grid
    {
        public Grid()
        {
            Left = 0;
            Top = 0;
            Height = 100;
            Width = 100;
            HorizontalGridCellsCount = 10;
            VerticalGridCellsCount = 10;
        }
        public float Left { get; set; }
        public float Top { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public uint HorizontalGridCellsCount { get; set; }
        public uint VerticalGridCellsCount { get; set; }
        public float UnitWidth { get { return Width / HorizontalGridCellsCount; } }
        public float UnitHeight { get { return Height / VerticalGridCellsCount; } }
        public void Draw(Graphics graphics, Viewport viewport)
        {
            try
            {
                List<LineSegment> lines = GetGridLines(viewport);
                for (int i = 0; i < lines.Count; i++)
                {
                    graphics.DrawLine(new Pen(lines[i].Color), lines[i].StartPoint.X, lines[i].StartPoint.Y, lines[i].EndPoint.X, lines[i].EndPoint.Y);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private List<LineSegment> GetGridLines(Viewport viewport)
        {
            float wstart = viewport.Left;
            float wend = viewport.Left + viewport.Width;
            int wstartIndex = (int)(wstart / UnitWidth)+1;
            int wendIndex = (int)(wend / UnitWidth);
            if (wstartIndex >= wendIndex) { throw new Exception(); }

            float hstart = viewport.Top;
            float hend = viewport.Top + viewport.Height;
            int hstartIndex = (int)(hstart / UnitHeight) + 1;
            int hendIndex = (int)(hend / UnitHeight);
            if (hstartIndex >= hendIndex) { throw new Exception(); }

            linesToDraw.Clear();
            for (int i = wstartIndex-1; i <= wendIndex; i++)
            {
                if (i >= 0)
                {
                    LineSegment ls = new LineSegment(new Coordinate(i * UnitWidth - viewport.Left, 0), new Coordinate(i * UnitWidth - viewport.Left, viewport.Height));
                    linesToDraw.Add(ls);
                }
                else
                {
                }
            }
            for (int i = hstartIndex-1; i <= hendIndex; i++)
            {
                if (i >= 0)
                {
                    LineSegment ls = new LineSegment(new Coordinate(0, i * UnitHeight - viewport.Top), new Coordinate(viewport.Width, i * UnitHeight - viewport.Top));
                    linesToDraw.Add(ls);
                }
                else
                {
                }
            }          
            
            return linesToDraw;
        }
        private List<LineSegment> linesToDraw = new List<LineSegment>(10);
    }
    public class Viewport
    {
        public float Left { get; set; }
        public float Top { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
    }
}
