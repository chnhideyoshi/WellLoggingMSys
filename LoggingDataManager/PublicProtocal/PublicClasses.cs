using System;
using System.Collections.Generic;
using System.Text;

namespace PublicProtocal
{
    [Serializable]
    public class ResponsePackage
    {
        public Responses Response { get;set;}
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public Coordinate[] Points { get; set; }
    }
    [Serializable]
    public class CommandPackage
    {
        public Commands Command { get; set; }
    }
    [Serializable]
    public struct Coordinate
    {
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X;
        public double Y;
    }
}
