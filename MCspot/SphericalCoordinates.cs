using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCspot
{
    public class SphericalCoordinates
    {        
        public double r;
        public double tetha;
        public double phi;

        public SphericalCoordinates(double r, double tetha, double phi)
        {
            this.r = r;
            this.tetha = tetha;
            this.phi = phi;
        }

    }
}
