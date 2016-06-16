using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Projekt_4_taśma_produkcyjna
{
    class Wall
    {
        public Rectangle rectangle { get; private set; }
        public int coordinateX { get; set; }
        public int coordinateY { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Wall(int x, int y, int width, int height)
        {
            this.coordinateX = x;
            this.coordinateY = y;
            this.width = width;
            this.height = height;
            rectangle = new Rectangle();
            rectangle.Width = 10*width;
            rectangle.Height = 10*height;
            rectangle.Fill = Brushes.RoyalBlue;
        }
    }
}
