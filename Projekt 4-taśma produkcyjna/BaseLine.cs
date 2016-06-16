using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Projekt_4_taśma_produkcyjna
{
    class BaseLine : Line
    {
        
        public Rectangle rectangle = new Rectangle();
        public int coordinateX { get; set; }
        public int coordinateY { get; set; }
        public BaseLine(int x, int y)
        {
            this.coordinateX = x;
            this.coordinateY = y;
            rectangle = new Rectangle();
            rectangle.Width = rectangle.Height = 9;
            rectangle.Fill = Brushes.Black;
        }
    }
}
