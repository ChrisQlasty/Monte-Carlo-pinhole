﻿using SpreadsheetLight;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace MCspot
{
    public partial class Form1 : Form
    {
        static int NUM_THREADS = 7; 
        static int PHOTONS_PER_LED = 2100*4 / (NUM_THREADS);
        static int SECONDARY_EMISSION_PHOTONS = 2000;
        static int NUM_PIXELS_SIDE = 10;
        static int STEPPERCENT = 10;
        static int REFRESH_STEP = 0;
        int refrcnt = 0;

        private static Random GLOBAL_RANDOM_VAR = new Random();

        private Queue<double> SNRqueue = new Queue<double>();
        private Queue<double> ERRORqueue = new Queue<double>();
        private Queue<int> PHOTONSqueue = new Queue<int>();

        double[,] pixelHIT, siatkaHIT;
        double[] angleEff = new double[] { 0, 0, 0, 0 };

        public static double[] _1Dimage, _1Dprevimage;

        double L1, L2;
        double sideLength = 0.26*2;
        double resolution = 0.013;        

        Image previewImage = null;

        CartesianCoordinates newOriginCart;
        SphericalCoordinates newOriginSpher;

        GeometricalObject pinholeStuct, ballStruct, ballStructh, QPStruct;
        GeometricalObject[] LEDStruct;

        public Form1()
        {
            InitializeComponent();            

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
            _1Dprevimage = new double[NUM_PIXELS_SIDE * NUM_PIXELS_SIDE];


            double ballRad = Convert.ToDouble(nudPSEbr.Value)*0.1;
            //create ball
            CartesianCoordinates ballCoordinates = new CartesianCoordinates(x: 0, y: 0, z: 3);                      
            ballStruct = new GeometricalObject(ballCoordinates, Elementary.Cart2Sphere(ballCoordinates), radius: ballRad, side:0);

            double phRad = Convert.ToDouble(nudPSEphr.Value) * 0.1;
            //create pinhole            
            CartesianCoordinates pinholeCoordinates = new CartesianCoordinates(x: 0, y: 0, z: 0);            
            pinholeStuct = new GeometricalObject(pinholeCoordinates, Elementary.Cart2Sphere(pinholeCoordinates), radius: phRad, side: 0);

            //create LEDs
            if (rbCircle.Checked)
            {
                int numLEDS = Convert.ToInt16(nudPCnl.Value);
                double r_dist = Convert.ToDouble(nudPCr.Value) * 0.1;
                LEDStruct = new GeometricalObject[numLEDS];

                for (int ledsIterator = 0; ledsIterator < numLEDS; ledsIterator++)
                {
                    SphericalCoordinates sphericalTemp = new SphericalCoordinates(r: r_dist, tetha: 90.0, phi: 360 * ledsIterator / numLEDS);
                    LEDStruct[ledsIterator] = new GeometricalObject(Elementary.Sphere2Kart(sphericalTemp), sphericalTemp, 0, 0);
                }
            }

            else if (rbGrid.Checked)
            {
                int cols = Convert.ToInt16(nudPGc.Value);
                int rows = Convert.ToInt16(nudPGr.Value);
                double spacing = Convert.ToInt16(nudPGs.Value)*0.1;
                int numLEDS = cols * rows;
                LEDStruct = new GeometricalObject[numLEDS];

                int helpIter = 0;
                for (int colit = 0; colit < cols; colit++)
                {
                    for (int rowit = 0; rowit < rows; rowit++)
                    {
                        CartesianCoordinates tempC = new CartesianCoordinates(x: spacing * ((cols + 1) / 2.0 - colit) - spacing, 
                                                                              y: spacing * ((rows + 1) / 2.0 - rowit) - spacing,
                                                                              z: 0.0);
                        LEDStruct[helpIter++] = new GeometricalObject(tempC, Elementary.Cart2Sphere(tempC), radius: 0.0, side: 0.0);
                    }
                }     
            }
                         

            //create ball helper            
            CartesianCoordinates ballCh = new CartesianCoordinates(x: 0, y: 0, z: 0);            
            ballStructh = new GeometricalObject(ballCh, Elementary.Cart2Sphere(ballCh), radius: pinholeStuct.radius, side: 0);

            double imagePlaneDist = -Convert.ToDouble(nudPSEip.Value) * 0.1;
            double quadSide = Convert.ToDouble(nudPSEqps.Value) * 0.1;
            //create quad photodiode            
            CartesianCoordinates qpC = new CartesianCoordinates(x: 0, y: 0, z: imagePlaneDist);
            QPStruct = new GeometricalObject(qpC, Elementary.Cart2Sphere(qpC), 0, quadSide);
            
            REFRESH_STEP = STEPPERCENT* PHOTONS_PER_LED /100;
        }

        private async void bStart_Click(object sender, EventArgs e)
        {
            InitializeEnvironment();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            bStart.Enabled = false;

            //----------------------------------------------------------------------   
            SLDocument sl = new SLDocument();

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Settings");
            sl.AddWorksheet("Res1");


            Random r0 = new Random(Form1.GLOBAL_RANDOM_VAR.Next() & DateTime.Now.Millisecond);


            double xstart = 0.5;
            double xfinni = 0.5;
            double ystart = 0.15;
            double yfinni = 0.15;
            double zstart = 2;
            double zfinni = 2; 

            double xstep = 0.1;
            double ystep = 1.0;
            double zstep = 1.0;

            for (int zc = 0; zc <= (zfinni-zstart)/zstep; zc++)
            {
                for (int yc = 0; yc <= (yfinni-ystart)/ystep; yc++)
                {
                    for (int xc = 0; xc <= (xfinni-xstart)/xstep; xc++)
                    {
                        // update the position of the ball
                        var _inputParameters = new { Ax = xstart+(xstep*xc), Ay = ystart+(ystep*yc), Az = zstart+(zstep * zc), Ar = ballStruct.radius };                        

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

                        refrcnt = 0;

                        double qpA = pixelHIT[NUM_PIXELS_SIDE / 2-1, NUM_PIXELS_SIDE / 2];
                        double qpB = pixelHIT[NUM_PIXELS_SIDE / 2,   NUM_PIXELS_SIDE / 2];
                        double qpC = pixelHIT[NUM_PIXELS_SIDE / 2,   NUM_PIXELS_SIDE / 2-1];
                        double qpD = pixelHIT[NUM_PIXELS_SIDE / 2-1, NUM_PIXELS_SIDE / 2-1];

                        double tmpX = (qpA + qpD - qpB - qpC) / (qpA + qpB + qpC + qpD);
                        double tmpY = (qpA + qpB - qpC - qpD) / (qpA + qpB + qpC + qpD);

                        chartLOC.Series[0].Points.AddXY(tmpX, tmpY);

                        for (int w = 0; w < NUM_PIXELS_SIDE; w++)
                        {
                            for (int k = 0; k < NUM_PIXELS_SIDE; k++)
                            {
                                double tmp1 = pixelHIT[w, k];
                                sl.SetCellValue(w + 1, k + 1, tmp1);
                            }
                        }

                        Array.Clear(pixelHIT, 0, NUM_PIXELS_SIDE * NUM_PIXELS_SIDE);

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

                    sl.SaveAs((tbFileName.Text.Length > 0 ? tbFileName.Text : "test") + ".xlsx");

                    bStart.Enabled = true;

                    sw.Stop();

                    System.Console.WriteLine("Time: " + sw.Elapsed);
                    lTimeElapsed.Text = sw.Elapsed + "";
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void plab1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbCircle_CheckedChanged(object sender, EventArgs e)
        {            
            panelCirc.Enabled = true;
            panelGrid.Enabled = false;        
        }

        private void rbGrid_CheckedChanged(object sender, EventArgs e)
        {
            panelCirc.Enabled = false;
            panelGrid.Enabled = true;
        }

        public void GreatLoop(object param)
        {     
            var _SimulationParameters = Cast(param, new { Ax = 0.0, Ay = 0.0, Az = 0.0, Ar=0.0});

            double xcObst = _SimulationParameters.Ax;
            double ycObst = _SimulationParameters.Ay;
            double zcObst = _SimulationParameters.Az;
            double rcObst = _SimulationParameters.Ar;

            CartesianCoordinates ballC = new CartesianCoordinates(x: xcObst, y: ycObst, z: zcObst);            
            ballStruct = new GeometricalObject(cartPoint: ballC, spherPoint: Elementary.Cart2Sphere(ballC), radius: rcObst, side: 0);

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

            for (int iPhoton = 0; iPhoton < PHOTONS_PER_LED; iPhoton++)
            {

                for (int iled = 0; iled < LEDStruct.Length; iled++)
                {
                    tempLED = LEDStruct[iled];
                    posLED = new CartesianCoordinates(x: LEDStruct[iled].x, y: LEDStruct[iled].y, z: LEDStruct[iled].z);                    
                


                    double _tetha = localRandom.NextDouble() * alfaSA;
                    double _phi = localRandom.NextDouble() * 360.0;
                    double _r = 100.0;


                    CartesianCoordinates photonEndPoint = Elementary.Sphere2Kart(new SphericalCoordinates(r: _r, tetha:_tetha, phi:_phi ));

                    newOriginCart = new CartesianCoordinates(x: ballStruct.x - tempLED.x, y: ballStruct.y - tempLED.y, z: ballStruct.z - tempLED.z);
                    newOriginSpher = Elementary.Cart2Sphere(newOriginCart);

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

                        if (Double.IsNaN(angleEff[1]))
                        {
                            System.Console.Write("error 1");
                            angleEff[1] = 1.0;
                            // BUG : triangle sides a+b<c
                        }

                        for (int ipFot = 0; ipFot < SECONDARY_EMISSION_PHOTONS; ipFot++)
                        {
                            //sampling the end position of new emitting photon
                            _tetha = 180.0+localRandom.NextDouble() * alfaPH;
                            _phi = localRandom.NextDouble() * 360.0;
                            _r = 100.0;

                            CartesianCoordinates photonEndPointFinal = Elementary.Sphere2Kart(new SphericalCoordinates(r: _r, tetha: _tetha, phi: _phi));

                            newOriginCart = new CartesianCoordinates(x: BallHitPoint.x, y: BallHitPoint.y, z: BallHitPoint.z);
                            newOriginSpher = Elementary.Cart2Sphere(newOriginCart);

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

                                SphericalCoordinates hitParams = Elementary.Cart2Sphere(new CartesianCoordinates(x: x1 - x, y: y1 - y, z: z1 - z));
                                angleEff[3] = Math.Cos(hitParams.tetha * Math.PI / 180);
                          
                                double I0 = 1;
                                double Ifin = (I0 * angleEff[0] / (L1 * L1)) * angleEff[1] * angleEff[2] * angleEff[3] / (L2 * L2);

                                if (Double.IsNaN(Ifin))
                                {
                                    System.Console.Write("error");
                                    Ifin = 0;
                                }

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

                    updateHitMesh(pixelHITtemp);

                    if (refrcnt % NUM_THREADS == 0)
                    {
                        progressBar1.Invoke(new Action(delegate ()
                        {
                            double temppr = (double)(1.0 / NUM_THREADS) * refrcnt * STEPPERCENT;
                            temppr = temppr > 100.0 ? 100.0 : temppr;
                            lProgress.Text = String.Format("Progress: {0:0}%", temppr);
                            progressBar1.Value = (int)temppr;
                        }));

                        lock (GLOBAL_RANDOM_VAR) { 
                            previewImage = CreateImage(pixelHIT);
                        }
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

            updateHitMesh(pixelHITtemp);        
        }

        public void updateHitMesh(double[,] pixelHITtemp)
        {
            lock (GLOBAL_RANDOM_VAR)
            {
                for (int rowIterator = 0; rowIterator < NUM_PIXELS_SIDE; rowIterator++)
                {
                    for (int colIterator = 0; colIterator < NUM_PIXELS_SIDE; colIterator++)
                    {
                        pixelHIT[rowIterator, colIterator] += pixelHITtemp[rowIterator, colIterator];
                    }
                }                
            }            
        }

        T Cast<T>(object obj, T type)
        {
            return (T)obj;
        }

        
        private Image CreateImage(double[,] hitMatrix)
        {
            _1Dimage = new double[NUM_PIXELS_SIDE * NUM_PIXELS_SIDE];
            double min = hitMatrix.Cast<double>().Min();
            double max = hitMatrix.Cast<double>().Max();
            double range = max - min;
            byte v;

            System.Buffer.BlockCopy(hitMatrix, 0, _1Dimage, 0, NUM_PIXELS_SIDE * NUM_PIXELS_SIDE);
            //DisplaySNR(Elementary.CalculateSNR(min, max, _1Dimage));
            DisplayERROR(Elementary.CalculateError(NUM_PIXELS_SIDE));

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
     
        public void DisplaySNR(double snr)
        {
            SNRqueue.Enqueue(snr);
            lSNR.Invoke(new Action(delegate ()
            {
                lSNR.Text = String.Format("SNR: {0:0.00} dB", snr);

                chartSNR.Series[0].Points.DataBindY(SNRqueue);
            }));
        }

        public void DisplayERROR(double error)
        {
            ERRORqueue.Enqueue(error);
            lERROR.Invoke(new Action(delegate ()
            {
                lERROR.Text = String.Format("Error: {0:0.00}", error);                

                PHOTONSqueue.Enqueue(PHOTONS_PER_LED * SECONDARY_EMISSION_PHOTONS * STEPPERCENT * ERRORqueue.Count/1000);
                chartError.Series[0].Points.DataBindXY(PHOTONSqueue, ERRORqueue);


                chartError.ChartAreas[0].AxisX.IsLogarithmic = true;
                
            }));
        }
    }

}
