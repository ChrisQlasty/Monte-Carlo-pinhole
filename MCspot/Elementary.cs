using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCspot
{
    public static class Elementary
    {                            
        static public SphericalCoordinates Kart2Sphere(CartesianCoordinates kart)
        {
            double r = Math.Sqrt(kart.x * kart.x + kart.y * kart.y + kart.z * kart.z);
            double tetha = (Math.Acos(kart.z / r) * 180 / Math.PI);
            double phi = 0.0;            

            if(kart.x >0 && kart.y > 0)
               phi = (Math.Atan(kart.y / kart.x) * 180 / Math.PI);
            else if(kart.x <0 && kart.y >0)
               phi = (90+Math.Atan(kart.y / kart.x) * 180 / Math.PI)+90;               
            else if(kart.x <0 && kart.y <0)
               phi = (Math.Atan(kart.y / kart.x) * 180 / Math.PI)+180;                 
            else
               phi = (90+Math.Atan(kart.y / kart.x) * 180 / Math.PI)+270;                           
       
            if(kart.x >0 && kart.y == 0)
                phi = 0;
            else if(kart.x ==0 && kart.y > 0)
                phi = 90;
            else if(kart.x <0 && kart.y == 0)
                phi = 180;
            else if(kart.x ==0 && kart.y < 0)
                phi = 270;
            else if(kart.x ==0 && kart.y ==0)
                phi = 0;

            return new SphericalCoordinates(r: r, tetha: tetha, phi: phi);
        }

        static public CartesianCoordinates Sphere2Kart(SphericalCoordinates spher)
        {            
            double x = (spher.r * Math.Sin(spher.tetha * Math.PI / 180) * Math.Cos(spher.phi * Math.PI / 180));
            double y = (spher.r * Math.Sin(spher.tetha * Math.PI / 180) * Math.Sin(spher.phi * Math.PI / 180));
            double z = (spher.r * Math.Cos(spher.tetha * Math.PI / 180));

            return new CartesianCoordinates(x: x, y: y, z: z);
        }

        static public CartesianCoordinates AddVectors(CartesianCoordinates vector1, CartesianCoordinates vector2)
        {                
            vector1.x += vector2.x;
            vector1.y += vector2.y;
            vector1.z += vector2.z;

            return vector1;
        }

        static public CartesianCoordinates SubtractVectors(CartesianCoordinates vector1, CartesianCoordinates vector2)
        {
            vector1.x -= vector2.x;
            vector1.y -= vector2.y;
            vector1.z -= vector2.z;

            return vector1;
        }

        static public object DoesHitBall(CartesianCoordinates pos_LED, CartesianCoordinates finPoint, GeometricalObject ballStruct)
        {
            double R = ballStruct.radius;

            var P1 = new { x = pos_LED.x, y = pos_LED.y, z = pos_LED.z };
            var P2 = new { x = finPoint.x, y = finPoint.y, z = finPoint.z };
            var P3 = new { x = ballStruct.x, y = ballStruct.y, z = ballStruct.z };

            double a = Math.Pow(P2.x - P1.x,2) + Math.Pow(P2.y - P1.y,2) + Math.Pow(P2.z - P1.z, 2);
            double b = 2 * ((P2.x - P1.x) * (P1.x - P3.x) + (P2.y - P1.y) * (P1.y - P3.y) + (P2.z - P1.z) * (P1.z - P3.z));
            double c = P3.x*P3.x + P3.y*P3.y + P3.z *P3.z + P1.x *P1.x + P1.y *P1.y + P1.z *P1.z - 2 * (P3.x * P1.x + P3.y * P1.y + P3.z * P1.z) - R * R;

            double delta = b * b - 4 * a * c;
            double[] odp = new double[] { 0, 0, 0 };

            if (delta >= 0)
            {
                double t1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double t2 = (-b + Math.Sqrt(delta)) / (2 * a);

                double x1 = P1.x + (P2.x - P1.x) * t1;
                double y1 = P1.y + (P2.y - P1.y) * t1;
                double z1 = P1.z + (P2.z - P1.z) * t1;

                double x2 = P1.x + (P2.x - P1.x) * t2;
                double y2 = P1.y + (P2.y - P1.y) * t2;
                double z2 = P1.z + (P2.z - P1.z) * t2;

                double[] Po1 = new double[] { x1, y1, z1 };
                double[] Po2 = new double[] { x2, y2, z2 };

                if (z2 < z1)
                    Po2.CopyTo(odp, 0);
                else
                    Po1.CopyTo(odp, 0);
            }
            else
            {
                odp = new double[] { 0, 0, -1 };
            }

            return new { x = odp[0], y = odp[1], z = odp[2] };
        }

        static public object DoesGoTrCirc(CartesianCoordinates pos_LED, CartesianCoordinates finPoint, GeometricalObject ballStruct)
        {
            double R = ballStruct.radius;

            var P1 = new { x = pos_LED.x, y = pos_LED.y, z = pos_LED.z };
            var P2 = new { x = finPoint.x, y = finPoint.y, z = finPoint.z };
            var P3 = new { x = ballStruct.x, y = ballStruct.y, z = ballStruct.z };

            double a = Math.Pow(P2.x - P1.x, 2) + Math.Pow(P2.y - P1.y, 2) + Math.Pow(P2.z - P1.z, 2);
            double b = 2 * ((P2.x - P1.x) * (P1.x - P3.x) + (P2.y - P1.y) * (P1.y - P3.y) + (P2.z - P1.z) * (P1.z - P3.z));
            double c = P3.x * P3.x + P3.y * P3.y + P3.z * P3.z + P1.x * P1.x + P1.y * P1.y + P1.z * P1.z - 2 * (P3.x * P1.x + P3.y * P1.y + P3.z * P1.z) - R * R;

            double t = P1.z/(P1.z-P2.z);
    
            double x1 = P1.x + (P2.x - P1.x) * t;
            double y1 = P1.y + (P2.y - P1.y) * t;


            double[] Po1 = new double[] { x1, y1, 0 };                

            if (Math.Sqrt(x1*x1+y1*y1)<=R*R)
            {
                return new { x = Po1[0], y = Po1[1], z = Po1[2] };
            }
            else
            {
                return new { x = 0, y = 0, z = -1 };
            }            
        }

        static public double DistanceFind(CartesianCoordinates point1, CartesianCoordinates point2)
        {
            CartesianCoordinates tempPoint = SubtractVectors(point1, point2);
            return Math.Sqrt(tempPoint.x * tempPoint.x + tempPoint.y * tempPoint.y + tempPoint.z * tempPoint.z);
        }

        public static CartesianCoordinates PointRotation(CartesianCoordinates cartPoint, SphericalCoordinates spherPoint)
        {            
            double tetha = spherPoint.tetha;
            double phi = spherPoint.phi;

            double[,] RotZ = new double[,]{ { Math.Cos(phi * Math.PI / 180),- Math.Sin(phi * Math.PI / 180), 0 },
                                            { Math.Sin(phi * Math.PI / 180),  Math.Cos(phi * Math.PI / 180), 0 },
                                            {                            0 ,                              0, 1 }};

            double[,] RotY = new double[,] {{ Math.Cos(tetha * Math.PI / 180), 0, Math.Sin(tetha * Math.PI / 180) },
                                            {                               0, 1,                              0  },
                                            {-Math.Sin(tetha * Math.PI / 180), 0, Math.Cos(tetha * Math.PI / 180) }};

            double[] point2Rotate = new double[] { cartPoint.x, cartPoint.y, cartPoint.z};

            point2Rotate = MatrixProduct(RotY, point2Rotate);
            point2Rotate = MatrixProduct(RotZ, point2Rotate);

            return new CartesianCoordinates(x: point2Rotate[0], y:point2Rotate[1], z:point2Rotate[2]);
        }

        private static double[] MatrixProduct(double[,] rotationMatrix, double[] point2Rotate)
        {
            double[] pointRotated = new double[point2Rotate.Length];

            for(int iter1=0; iter1<point2Rotate.Length; iter1++)
            {
                pointRotated[iter1] = 0.0;
                for (int iter2 = 0; iter2 < point2Rotate.Length; iter2++)                
                    pointRotated[iter1] += rotationMatrix[iter1, iter2] * point2Rotate[iter2];
            }

            return pointRotated;
        }

        public static double CalculateSNR(double min, double max, double[] tm)
        {
            double average = tm.Average();
            double sumOfSquaresOfDifferences = tm.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / tm.Length);

            return 20 * Math.Log10((max - min) / sd);                     
        }

        public static double CalculateError(int NUM_PIXELS_SIDE)
        {
            double maxOrg = Form1._1Dimage.Max();
            double[] norm_1Dimage = Form1._1Dimage.Select(item => item / maxOrg).ToArray();

            double errorSum = 0.0;

            for (int itemIterator = 0; itemIterator < NUM_PIXELS_SIDE*NUM_PIXELS_SIDE; itemIterator++)
            {
                errorSum += Math.Abs(norm_1Dimage[itemIterator] - Form1._1Dprevimage[itemIterator]);
            }       


            // At the 1st time the method is called no normalization is required, hence for next calculations we can pass the normalized one
            Array.Copy(norm_1Dimage, Form1._1Dprevimage, NUM_PIXELS_SIDE * NUM_PIXELS_SIDE);

            return errorSum;
        }
    }

}
