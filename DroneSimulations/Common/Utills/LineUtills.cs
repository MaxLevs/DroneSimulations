using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DroneSimulations.Common.Utills
{
    public static partial class Utills
    {
        public static Line GetHorizontalLine(double x1, double x2, double y)
        {
            return new Line { X1 = x1, Y1 = y, X2 = x2, Y2 = y, StrokeThickness=1, Stroke=Brushes.Black };
        }

        public static Line GetVerticalLine(double x, double y1, double y2)
        {
            return new Line { X1 = x, Y1 = y1, X2 = x, Y2 = y2, StrokeThickness=1, Stroke=Brushes.Black };
        }
    }
}
