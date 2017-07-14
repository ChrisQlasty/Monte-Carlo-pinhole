using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCspot
{
    public class GeometricalObject
    {
        public double x;
        public double y;
        public double z;
        public double r;
        public double tetha;
        public double phi;
        public double radius;
        public double side;

        public GeometricalObject() { }

        public GeometricalObject(CartesianCoordinates cartPoint, SphericalCoordinates spherPoint, double radius, double side)
        {
            this.x = cartPoint.x;
            this.y = cartPoint.y;
            this.z = cartPoint.z;
            this.r = spherPoint.r;
            this.tetha = spherPoint.tetha;
            this.phi = spherPoint.phi;
            this.radius = radius;
            this.side = side;            
        }           
    }
}
