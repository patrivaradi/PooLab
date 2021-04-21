using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractPoint
{
    abstract public class AbstractPoint
    {
        public enum PointRepresentation { Polar, Rectangular }
        //tipul de reprezentare nu este stabilit
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double R { get; set; }
        public abstract double A { get; set; }
        public void Move(double dx, double dy)
        {
            X += dx; Y += dy;
        }
        public void Rotate(double angle)
        {
            A += angle;
        }
        public override string ToString()
        {
            return "(" + X + ", " + Y + ")" + " " + "[r:" + R + ", A:" + A + "] ";
        }
        protected static double RadiusGivenXy(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
        protected static double AngleGivenXy(double x, double y)
        {
            return Math.Atan2(y, x);
        }
        protected static double XGivenRadiusAngle(double r, double a)
        {
            return r * Math.Cos(a);
        }
        protected static double YGivenRadiusAngle(double r, double a)
        {
            return r * Math.Sin(a);
        }
    }
    public class Point : AbstractPoint
    {
        private double radius, angle;
        // tipul de reprezentare este cel polar
        // constructor
        public Point(PointRepresentation pr, double n1, double n2)
        {
            if (pr == PointRepresentation.Polar)
            {
                radius = n1; angle = n2;
            }
            else if (pr == PointRepresentation.Rectangular)
            {
                radius = RadiusGivenXy(n1, n2);
                angle = AngleGivenXy(n1, n2);
            }
            else
            {
                throw new Exception("Situație imprevizibilă!");
            }
        }
        public override double X
        {
            get
            {
                return XGivenRadiusAngle(radius, angle);
            }
            set
            {
                double yBefore = YGivenRadiusAngle(radius, angle);
                angle = AngleGivenXy(value, yBefore);
                radius = RadiusGivenXy(value, yBefore);
            }
        }
        public override double Y
        {
            get
            {
                return YGivenRadiusAngle(radius, angle);
            }
            set
            {
                double xBefore = XGivenRadiusAngle(radius, angle);
                angle = AngleGivenXy(xBefore, value);
                radius = RadiusGivenXy(xBefore, value);
            }
        }
        public override double R
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
        public override double A
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractPoint.PointRepresentation point1 = AbstractPoint.PointRepresentation.Polar;
            AbstractPoint a = new Point(point1, 6.23, 9.1); ;
            Console.WriteLine(a);

            AbstractPoint.PointRepresentation point2 = AbstractPoint.PointRepresentation.Rectangular;
            Point b = new Point(point2, 3.24, 7.33);
            Console.WriteLine(b);
            
            Console.ReadKey();
        }
    }
}
