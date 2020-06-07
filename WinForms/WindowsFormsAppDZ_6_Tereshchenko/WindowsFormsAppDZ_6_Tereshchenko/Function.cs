using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAppDZ_6_Tereshchenko
{
    class Function
    {
        double xBegin;
        double xEnd;
        int count;
        const double xStep=0.1;
        double[] point_Array;
        double[] point_SinF;
        double[] point_CosF;
        double minSin, maxSin;
        double minCos, maxCos;
        double min, max;
        Plot myPlot;
        public Function(Size size)
        {
            myPlot = new Plot(size);
        }
        public Function(double xBegin,double xEnd)
        {
            this.xBegin = xBegin;
            this.xEnd = xEnd;
            
        }
        public double XBegin
        { get => xBegin; set => xBegin = value; }
        public double XEnd
        { get => xEnd; set => xEnd = value; }
        public void FillingData()
        {
            count = Convert.ToInt32(Math.Round((xEnd - xBegin) / xStep + 1));
            point_Array = new double[count];
            point_SinF = new double[count];
            point_CosF = new double[count];
            for (int i = 0; i < count; i++)
                point_Array[i] = xBegin + i * xStep;
            for (int i = 0; i < count; i++)
                point_SinF[i] = Math.Sin(point_Array[i] * point_Array[i]);
            for (int i = 0; i < count; i++)
                point_CosF[i] = Math.Cos(point_Array[i]) + 1;
            minSin = point_SinF.Min();
            maxSin = point_SinF.Max();
            minCos = point_CosF.Min();
            maxCos = point_CosF.Max();
            min = minSin < minCos ? minSin : minCos;
            max = maxCos > maxSin ? maxCos : maxSin;

        }
        public void PaintGraphSin(Size size,Pen pen, Graphics graphics)
        {
            myPlot.GetPlotPort(minSin,maxSin);
            myPlot.PaintPixelCosOrSin(point_Array, point_SinF,xBegin,xEnd, pen, graphics);
        }
        public void PaintGraphCos(Size size, Pen pen, Graphics graphics)
        {
            myPlot.GetPlotPort(minCos, maxCos);
            myPlot.PaintPixelCosOrSin(point_Array, point_CosF, xBegin, xEnd, pen, graphics);
        }
        public void PaintGraphSinCos(Size size,Pen pen1,Pen pen2,Graphics graphics)
        {
            myPlot.GetPlotPort(min, max);
            myPlot.PaintPixelCosOrSin(point_Array, point_SinF, xBegin, xEnd, pen1, graphics);
            myPlot.PaintPixelCosOrSin(point_Array, point_CosF, xBegin, xEnd, pen2, graphics);
        }

    }
}
