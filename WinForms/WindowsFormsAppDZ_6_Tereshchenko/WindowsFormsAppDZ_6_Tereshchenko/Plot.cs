using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppDZ_6_Tereshchenko
{
    class Plot
    {
        struct PlotPort
        {
            public double min;
            public double max;

        }
        Size ClientArea;
        PlotPort plotPort;
        Point func1 = new Point();
        Point func2 = new Point();
        public Plot()
        { }
        public Plot(Size PlotArea)
        {
            ClientArea = PlotArea;
            func1 = new Point();
            func2 = new Point();
        }
        public void GetPlotPort(double minx, double maxx)
        {
            plotPort.min = minx;
            plotPort.max = maxx;

        }
        public void PaintPixelCosOrSin(double[] point_Array, double[] point_Func, double xBegin, double xEnd, Pen pen, Graphics g)
        {
            int countPiksel = Convert.ToInt32(Math.Round(ClientArea.Width / (xEnd - xBegin)));
            int countOtr = Convert.ToInt32(Math.Round(ClientArea.Height / (plotPort.max - plotPort.min)));
            func1.X = 0;
            func1.Y = ClientArea.Height - Convert.ToInt32(Math.Round((point_Func[0] - plotPort.min) * countOtr));
            for (int i = 1; i < point_Array.Length; i++)
            {
                func2.X = Convert.ToInt32((point_Array[i] - point_Array[0]) * countPiksel);
                func2.Y = ClientArea.Height - Convert.ToInt32(Math.Round((point_Func[i] - plotPort.min) * countOtr));
                g.DrawLine(pen, func1, func2);
                func1 = func2;
            }
        }
    }
}
