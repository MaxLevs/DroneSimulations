using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DroneSimulations.Common
{
    public class ColorFactory
    {
        public Color GetRandomColor() => Color.FromArgb(255, GetRandomByte(), GetRandomByte(), GetRandomByte());
        public Brush GetRundomBrush() => new SolidColorBrush(GetRandomColor());
        private byte GetRandomByte() => Convert.ToByte(Random.Shared.Next(255));
    }
}
