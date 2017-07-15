using SpreadsheetLight;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace MCspot
{
    public partial class Form1 : Form
    {
        static int NUM_THREADS = 7; 
        static int PHOTONS_PER_LED = 1500 / (NUM_THREADS);
        static int SECONDARY_EMISSION_PHOTONS = 4000;
        static int NUM_PIXELS_SIDE =10;
        static int STEPPERCENT = 2;
        static int REFRESH_STEP = 0;
        int refrcnt = 0;

        private static Random GLOBAL_RANDOM_VAR = new Random();


        double[,] pixelHIT, siatkaHIT;
        double[] angleEff = new double[] { 0, 0, 0, 0 };

        double L1, L2;
        double sideLength = 1;
        double resolution = 0.01;        

        Image previewImage = null;

        CartesianCoordinates newOriginCart;
        SphericalCoordinates newOriginSpher;

        GeometricalObject pinholeStuct, ballStruct, ballStructh, QPStruct;
        GeometricalObject[] LEDStruct;

        public Form1()
        {
            InitializeComponent();
            InitializeEnvironment();

            // other elements
            lProgress.BackColor = System.Drawing.Color.Transparent;
        }
      

        private void bCpyImg_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(previewImage);
        }

        public void InitializeEnvironment()
        {
            NUM_PIXELS_SIDE = Convert.ToInt16(sideLength / resolution);            
            pixelHIT = new double[NUM_PIXELS_SIDE,NUM_PIXELS_SIDE];
            siatkaHIT = new double[NUM_PIXELS_SIDE, NUM_PIXELS_SIDE];

            //create ball
            CartesianCoordinates ballCoordinates = new CartesianCoordinates(x: 0, y: 0, z: 3);                      
            ballStruct = new GeometricalObject(ballCoordinates, Elementary.Kart2Sphere(ballCoordinates), radius: 1, side:0);
            
            //create pinhole            
            CartesianCoordinates pinholeCoordinates = new CartesianCoordinates(x: 0, y: 0, z: 0);            
            pinholeStuct = new GeometricalObject(pinholeCoordinates, Elementary.Kart2Sphere(pinholeCoordinates), radius: 0.5, side: 0);

            //create LEDs
            int numLEDS = 4;
            double r_dist = 0.5f;
            LEDStruct = new GeometricalObject[numLEDS];
            /*
            LEDStruct[0] = new GeoObject(new double[] { -1.5, 0, 0 }, Elementary.Kart2Sphere(new double[] { -1.5, 0, 0 }), 0, 0);
            LEDStruct[1] = new GeoObject(new double[] { -0.5, 0, 0 }, Elementary.Kart2Sphere(new double[] { -0.5, 0, 0 }), 0, 0);
            LEDStruct[2] = new GeoObject(new double[] { 0.5, 0, 0 }, Elementary.Kart2Sphere(new double[] { 0.5, 0, 0 }), 0, 0);
            LEDStruct[3] = new GeoObject(new double[] { 1.5, 0, 0 }, Elementary.Kart2Sphere(new double[] { 1.5, 0, 0 }), 0, 0);
            */
           
           /* 
            LEDStruct[4] = new GeoObject(new double[] {-1.5, 2, 0 }, Elementary.Kart2Sphere(new double[] {-1.5, 2, 0 }), 0, 0);
            LEDStruct[5] = new GeoObject(new double[] {-0.5, 2, 0 }, Elementary.Kart2Sphere(new double[] { -0.5, 2, 0 }), 0, 0);
            LEDStruct[6] = new GeoObject(new double[] { 0.5, 2, 0 }, Elementary.Kart2Sphere(new double[] {  0.5, 2, 0 }), 0, 0);
            LEDStruct[7] = new GeoObject(new double[] { 1.5, 2, 0 }, Elementary.Kart2Sphere(new double[] {  1.5, 2, 0 }), 0, 0);

            */
     
            
            for (int ledsIterator = 0; ledsIterator < numLEDS; ledsIterator++)
            {                
                SphericalCoordinates sphericalTemp = new SphericalCoordinates(r: r_dist, tetha: 90.0, phi: 360 * ledsIterator / numLEDS);
                LEDStruct[ledsIterator] = new GeometricalObject(Elementary.Sphere2Kart(sphericalTemp), sphericalTemp, 0, 0);
            }
            
            //create ball helper            
            CartesianCoordinates ballCh = new CartesianCoordinates(x: 0, y: 0, z: 0);            
            ballStructh = new GeometricalObject(ballCh, Elementary.Kart2Sphere(ballCh), radius: pinholeStuct.radius, side: 0);
            
            //create quad photodiode            
            CartesianCoordinates qpC = new CartesianCoordinates(x: 0, y: 0, z: -1);
            QPStruct = new GeometricalObject(qpC, Elementary.Kart2Sphere(qpC), 0, 0.127);
            
            REFRESH_STEP = STEPPERCENT* PHOTONS_PER_LED /100;
        }

        private async void bStart_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bStart.Enabled = false;

            //----------------------------------------------------------------------   
            SLDocument sl = new SLDocument();

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Settings");
            sl.AddWorksheet("Res1");


            Random r0 = new Random(Form1.GLOBAL_RANDOM_VAR.Next() & DateTime.Now.Millisecond);


            int xstart = 0;
            int xfinni = 0;
            int ystart = 1;
            int yfinni = 1;
            int zstart = 3;
            int zfinni = 3; 

            double xstep = 1.0;
            double ystep = 1.0;
            double zstep = 1.0;

            for (int zc = zstart; zc <= zfinni/zstep; zc++)
            {
                for (int yc = ystart; yc <= yfinni/ystep; yc++)
                {
                    for (int xc = xstart; xc <= xfinni/xstep; xc++)
                    {
                        // update the position of the ball
                        var _inputParameters = new { Ax = (xstep*xc), Ay = (ystep*yc), Az = (zstep * zc), Ar = ballStruct.radius };                         

                        await Task.Run(() =>
                        {
                            Thread[] threadsArray = new Thread[NUM_THREADS];

                            for (int threadIterator = 0; threadIterator < NUM_THREADS; threadIterator++)
                            {                                
                                threadsArray[threadIterator] = new Thread(GreatLoop);
                                threadsArray[threadIterator].Priority = ThreadPriority.Highest;
                                threadsArray[threadIterator].Start(_inputParameters);
                            }
                            
                            foreach (Thread t in threadsArray)
                                t.Join();
                        });

                        
                        /*for (int w = 0; w < NUM_PIXELS; w++)
                        {
                            for (int k = 0; k < NUM_PIXELS; k++)
                            {
                                double tmp1 = pixelHIT[w, k];
                                sl.SetCellValue(w + 1, k + 1, tmp1);
                            }
                        }*/

                        /*
                        progressBar2.Invoke(new Action(delegate ()
                        {
                            progressBar2.Value = (int)(100.0 * (x - xstart + 1) / (xfinni - xstart));
                            label1.Text = String.Format("{0:0.00}%", (100.0 * (x - xstart) / (xfinni - xstart)));

                            BitmapSource bSource = new BitmapImage(new Uri("C:\\Users\\" + userName + "\\Desktop\\obrazy\\im" + imc + ".png"));
                            encoder.Frames.Add(BitmapFrame.Create(bSource));
                            imc++;
                        }));
                        */

                    }

                    //sl.SaveAs((tbFileName.Text.Length > 0 ? tbFileName.Text : "test") + ".xlsx");

                    bStart.Enabled = true;

                    sw.Stop();

                    System.Console.WriteLine("Time: " + sw.Elapsed);
                    lTimeElapsed.Text = sw.Elapsed + "";
                }
            }
        }

        
        public void GreatLoop(object param)
        {     
            var _SimulationParameters = Cast(param, new { Ax = 0.0, Ay = 0.0, Az = 0.0, Ar=0.0});

            double xcObst = _SimulationParameters.Ax;
            double ycObst = _SimulationParameters.Ay;
            double zcObst = _SimulationParameters.Az;
            double rcObst = _SimulationParameters.Ar;

            CartesianCoordinates ballC = new CartesianCoordinates(x: xcObst, y: ycObst, z: zcObst);            
            ballStruct = new GeometricalObject(cartPoint: ballC, spherPoint: Elementary.Kart2Sphere(ballC), radius: rcObst, side: 0);

            Random localRandom = new Random(Form1.GLOBAL_RANDOM_VAR.Next() & DateTime.Now.Millisecond);

            double[,] pixelHITtemp = new double[NUM_PIXELS_SIDE, NUM_PIXELS_SIDE];
            double[,] siatkaHITTemp = new double[NUM_PIXELS_SIDE, NUM_PIXELS_SIDE];

            GeometricalObject tempLED = null;
            CartesianCoordinates posLED = new CartesianCoordinates(x: 0, y: 0, z: 0);
            double[] Lsa = new double[LEDStruct.Length];
            for (int iled = 0; iled < LEDStruct.Length; iled++)
            {
                tempLED = LEDStruct[iled];
                posLED = new CartesianCoordinates(x: LEDStruct[iled].x, y: LEDStruct[iled].y, z: LEDStruct[iled].z);
                Lsa[iled] = Elementary.DistanceFind(posLED, new CartesianCoordinates(x: ballStruct.x, y: ballStruct.y, z: ballStruct.z));
            }

            // angle of the most wide beam from a LED
            double alfaSA = Math.Asin(ballStruct.radius/Lsa.Min())*180.0/Math.PI;

            // angle of the most wide beam to the pinhole
            dynamic BallHitPointT = Elementary.DoesHitBall(new CartesianCoordinates(x:0,y:0,z:0), new CartesianCoordinates(x: ballStruct.x, y: ballStruct.y, z: ballStruct.z ), ballStruct);
            double Lphc = Elementary.DistanceFind(new CartesianCoordinates(x: BallHitPointT.x, y: BallHitPointT.y, z: BallHitPointT.z ), new CartesianCoordinates(x: 0, y: 0, z: 0));
            double alfaPH = Math.Atan(pinholeStuct.radius / Lphc) * 180.0 / Math.PI;

            int step = 100;

            for (int iPhoton = 0; iPhoton < PHOTONS_PER_LED; iPhoton++)
            {

                for (int iled = 0; iled < LEDStruct.Length; iled++)
                {
                    tempLED = LEDStruct[iled];
                    posLED = new CartesianCoordinates(x: LEDStruct[iled].x, y: LEDStruct[iled].y, z: LEDStruct[iled].z);
                    System.Console.WriteLine(iled);

                
                    //if (iPhoton % step == 0)
               


                    double _tetha = localRandom.NextDouble() * alfaSA;
                    double _phi = localRandom.NextDouble() * 360.0;
                    double _r = 100.0;


                    CartesianCoordinates photonEndPoint = Elementary.Sphere2Kart(new SphericalCoordinates(r: _r, tetha:_tetha, phi:_phi ));

                    newOriginCart = new CartesianCoordinates(x: ballStruct.x - tempLED.x, y: ballStruct.y - tempLED.y, z: ballStruct.z - tempLED.z);
                    newOriginSpher = Elementary.Kart2Sphere(newOriginCart);

                    photonEndPoint = Elementary.PointRotation(photonEndPoint, newOriginSpher);

                    photonEndPoint = Elementary.AddVectors(photonEndPoint, posLED);

                    dynamic BallHitPoint = Elementary.DoesHitBall(posLED, photonEndPoint, ballStruct);
                    
                    double Llh = Elementary.DistanceFind(new CartesianCoordinates(x: BallHitPoint.x, y: BallHitPoint.y, z: BallHitPoint.z ), posLED);
                    double alfa_p = Math.Acos(BallHitPoint.z / Llh) * 180.0 / Math.PI;
                    angleEff[0] = Math.Cos(alfa_p * Math.PI / 180.0);

                    if(BallHitPoint.z != -1)
                    {
                        L1 = Elementary.DistanceFind( new CartesianCoordinates(x: BallHitPoint.x, y: BallHitPoint.y, z: BallHitPoint.z ),  posLED); 
                        double Lc = Elementary.DistanceFind( new CartesianCoordinates(x: ballStruct.x, y: ballStruct.y, z: ballStruct.z ), posLED);
                    
                        alfa_p = Math.Acos((L1 *L1 + ballStruct.radius *ballStruct.radius - Lc *Lc) / (2 * ballStruct.radius * L1)) * 180 / Math.PI;
                        angleEff[1] = Math.Cos((180.0 - alfa_p) * Math.PI / 180.0);
                        
                        for (int ipFot = 0; ipFot < SECONDARY_EMISSION_PHOTONS; ipFot++)
                        {
                            //sampling the end position of new emitting photon
                            _tetha = 180.0+localRandom.NextDouble() * alfaPH;
                            _phi = localRandom.NextDouble() * 360.0;
                            _r = 100.0;

                            CartesianCoordinates photonEndPointFinal = Elementary.Sphere2Kart(new SphericalCoordinates(r: _r, tetha: _tetha, phi: _phi));

                            newOriginCart = new CartesianCoordinates(x: BallHitPoint.x, y: BallHitPoint.y, z: BallHitPoint.z);
                            newOriginSpher = Elementary.Kart2Sphere(newOriginCart);

                            double[] wek = new double[] { 0, 0 };                           

                            // rotation with respect to hitBall point
                            photonEndPointFinal = Elementary.PointRotation(photonEndPointFinal, newOriginSpher);

                            // translation
                            Elementary.AddVectors(photonEndPointFinal, new CartesianCoordinates(x: BallHitPoint.x, y: BallHitPoint.y, z: BallHitPoint.z));


                            // secondary emission angle
                            double Lh = Elementary.DistanceFind(new CartesianCoordinates(x: BallHitPoint.x, y: BallHitPoint.y, z: BallHitPoint.z ), photonEndPointFinal);
                            Lc = Elementary.DistanceFind(photonEndPointFinal, new CartesianCoordinates(x: ballStruct.x, y: ballStruct.y, z: ballStruct.z));
                            alfa_p = Math.Acos((Lh * Lh + ballStruct.radius * ballStruct.radius - Lc * Lc) / (2 * ballStruct.radius * Lh)) * 180 / Math.PI;
                            angleEff[2] = Math.Cos((180.0 - alfa_p) * Math.PI / 180.0);


                            dynamic CircHitPoint = Elementary.DoesGoTrCirc(new CartesianCoordinates(x: BallHitPoint.x, y: BallHitPoint.y, z: BallHitPoint.z), photonEndPointFinal, ballStructh);


                            if (CircHitPoint.z != -1) //Photon goes trhough pinhole
                            {
                                double z0 = QPStruct.z;
                                double x2 = photonEndPointFinal.x;
                                double y2 = photonEndPointFinal.y;
                                double z2 = photonEndPointFinal.z;
                                double x1 = BallHitPoint.x;
                                double y1 = BallHitPoint.y;
                                double z1 = BallHitPoint.z;

                                // parametric form solution
                                double t = (z0 - z1) / (z2 - z1);

                                double x = x1 + (x2 - x1) * t;
                                double y = y1 + (y2 - y1) * t;
                                double z = z1 + (z2 - z1) * t;

                                L2 = Elementary.DistanceFind(new CartesianCoordinates(x: BallHitPoint.x, y: BallHitPoint.y, z: BallHitPoint.z), new CartesianCoordinates(x: x, y: y, z: z));

                                SphericalCoordinates hitParams = Elementary.Kart2Sphere(new CartesianCoordinates(x: x1 - x, y: y1 - y, z: z1 - z));
                                angleEff[3] = Math.Cos(hitParams.tetha * Math.PI / 180);
                          
                                double I0 = 1;
                                double Ifin = (I0 * angleEff[0] / (L1 * L1)) * angleEff[1] * angleEff[2] * angleEff[3] / (L2 * L2);

                                int posx=0, posy=0;

                                if (x > 0)
                                    posx = Convert.ToInt16(Math.Floor(x / resolution) + sideLength / resolution / 2 );
                                else
                                    posx = Convert.ToInt16(Math.Ceiling(x / resolution) + sideLength / resolution / 2)-1;


                                if (y > 0)
                                    posy = Convert.ToInt16(Math.Floor(y / resolution) + sideLength / resolution / 2 );
                                else
                                    posy = Convert.ToInt16(Math.Ceiling(y / resolution) + sideLength / resolution / 2)-1;


                                if (posx < Math.Floor(sideLength / resolution) && posy < Math.Floor(sideLength / resolution) && posx >= 0 && posy >= 0)
                                {
                                    pixelHITtemp[posx, posy] = pixelHITtemp[posx, posy] + Ifin;
                                    siatkaHITTemp[posx, posy] = siatkaHITTemp[posx, posy] + 1;
                                }
                            }
                        }
                    }
                }

                if (iPhoton % REFRESH_STEP == 0)
                {
                    refrcnt++;
                    progressBar1.Invoke(new Action(delegate ()
                    {
                        double temppr = (double)(1.0/NUM_THREADS)* refrcnt * STEPPERCENT;
                        temppr = temppr>100.0 ? 100.0 : temppr;
                        lProgress.Text = String.Format("Progress: {0:0}%", temppr);
                        progressBar1.Value = (int)temppr;
                    }));

                    lock (GLOBAL_RANDOM_VAR)
                    {
                        for (int rowIterator = 0; rowIterator < NUM_PIXELS_SIDE; rowIterator++)
                        {
                            for (int colIterator = 0; colIterator < NUM_PIXELS_SIDE; colIterator++)
                            {
                                pixelHIT[rowIterator, colIterator] += pixelHITtemp[rowIterator, colIterator];
                                siatkaHIT[rowIterator, colIterator] = siatkaHITTemp[rowIterator, colIterator];
                            }
                        }

                        previewImage = CreateImage(pixelHIT);

                        //automatically copy the resulting Image to clipboard after the simulation is performed
                        pictureBox1.BeginInvoke(new Action(delegate ()
                        {
                            pictureBox1.Image = previewImage;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            Clipboard.SetImage(previewImage);
                        }));
                    }
                }
            }

            lock (GLOBAL_RANDOM_VAR)
            {
                for(int rowIterator = 0; rowIterator < NUM_PIXELS_SIDE; rowIterator++)
                {
                    for(int colIterator = 0; colIterator < NUM_PIXELS_SIDE; colIterator++)
                    {
                        pixelHIT[rowIterator, colIterator] += pixelHITtemp[rowIterator, colIterator];
                        siatkaHIT[rowIterator, colIterator] = siatkaHITTemp[rowIterator, colIterator];                        
                    }
                }

                previewImage = CreateImage(pixelHIT);
                
                //automatically copy the resulting Image to clipboard after the simulation is performed
                pictureBox1.BeginInvoke(new Action(delegate ()
                {
                    pictureBox1.Image = previewImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Clipboard.SetImage(previewImage);
                }));
            }

        }


        T Cast<T>(object obj, T type)
        {
            return (T)obj;
        }


        double[] tm = new double[100 * 100];
        private Image CreateImage(double[,] hitMatrix)
        {            
            double min = hitMatrix.Cast<double>().Min();
            double max = hitMatrix.Cast<double>().Max();
            double range = max - min;
            byte v;

            System.Buffer.BlockCopy(hitMatrix, 0, tm, 0, 100 * 100);

            double average = tm.Average();
            double sumOfSquaresOfDifferences = tm.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / tm.Length);

            double snr = 20 * Math.Log10((max - min) / sd);

            lSNR.Invoke(new Action(delegate ()
            {
                lSNR.Text = String.Format("SNR: {0:0.00} dB", snr);
            }));

            Bitmap     bitmap = new Bitmap(hitMatrix.GetLength(0), hitMatrix.GetLength(1));
            BitmapData bidmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // This is much faster than calling Bitmap.SetPixel() for each pixel.
            unsafe
            {
                byte* pointer = (byte*)bidmapdata.Scan0;
                for (int colIterator = 0; colIterator < bidmapdata.Height; colIterator++)
                {
                    for (int rowIterator = 0; rowIterator < bidmapdata.Width; rowIterator++)
                    {
                        v = (byte)(255 * (hitMatrix[rowIterator, bidmapdata.Height - 1 - colIterator] - min) / range);
                        pointer[0] = v;
                        pointer[1] = v;
                        pointer[2] = v;
                        pointer[3] = (byte)255;
                        pointer += 4;
                    }
                    pointer += (bidmapdata.Stride - (bidmapdata.Width * 4));
                }
            }

            bitmap.UnlockBits(bidmapdata);
            return bitmap;

        }
     
    }

}
