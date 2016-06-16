using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Projekt_4_taśma_produkcyjna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Line line;
        private List<Wall> walls;
        private int directionX = 1;
        private int directionY = 0;
        private DispatcherTimer timer;
        private static readonly int size = 10;
        public MainWindow()
        {
            
            InitializeComponent();
            initBoard();
            initWall();
            initTimer();
            
        }
        void initBoard()
        {
            for(int i=0;i<grid.Width/size;i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(size);
                grid.ColumnDefinitions.Add(columnDefinition);
            }
            for(int j=0;j<grid.Height/size;j++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(size);
                grid.RowDefinitions.Add(rowDefinition);
            }
            line = new Line();
            line.createLine();
            createObjects();
        }
        void initWall()
        {
            walls = new List<Wall>();
            Wall wall1 = new Wall(0, 35, 20, 2);
            grid.Children.Add(wall1.rectangle);
            Grid.SetColumn(wall1.rectangle, wall1.coordinateX);
            Grid.SetRow(wall1.rectangle, wall1.coordinateY);
            Grid.SetColumnSpan(wall1.rectangle, wall1.width);
            Grid.SetRowSpan(wall1.rectangle, wall1.height);
            walls.Add(wall1);

            Wall wall2 = new Wall(20, 37, 20, 2);
            grid.Children.Add(wall2.rectangle);
            Grid.SetColumn(wall2.rectangle, wall2.coordinateX);
            Grid.SetRow(wall2.rectangle, wall2.coordinateY);
            Grid.SetColumnSpan(wall2.rectangle, wall2.width);
            Grid.SetRowSpan(wall2.rectangle, wall2.height);
            walls.Add(wall2);

            Wall wall3 = new Wall(40, 39, 20, 2);
            grid.Children.Add(wall3.rectangle);
            Grid.SetColumn(wall3.rectangle, wall3.coordinateX);
            Grid.SetRow(wall3.rectangle, wall3.coordinateY);
            Grid.SetColumnSpan(wall3.rectangle, wall3.width);
            Grid.SetRowSpan(wall3.rectangle, wall3.height);
            walls.Add(wall3);
        }
        void createObjects()
        {
            line.createObjects(0, 0);
            foreach (BaseLine item in line.objects)
            {
                grid.Children.Add(item.rectangle);
                line.reDraw(line.objects);
            }
        }
        private void move()
        {
            for (int i = line.objects.Count - 1; i >= 1; i--)
            {
                line.objects[i].coordinateX = line.objects[i - 1].X;
                line.objects[i].coordinateY = line.objects[i - 1].Y;
            }
            
            line.objects[0].coordinateX += directionX;
            line.objects[0].coordinateY += directionY;
            line.reDraw(line.objects);
        }
        public void initTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0,0,100);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();
            
        }
        public void timerTick(object sender, EventArgs e)
        {
            move();
            checkColision();
        }
        public void checkColision()
        {
            if (checkWallCollision())
            {
                directionX = 1;
                directionY = 0;
            }
            else 
            {
                directionY = 1;
                directionX = 0;
            }
        }
        public bool checkWallCollision()
        {
            foreach (Wall wall in walls)
            {
                
                if ((line.objects[0].coordinateX>=wall.coordinateX)
                    &&(line.objects[0].coordinateX<(wall.coordinateX+wall.width))
                    &&(line.objects[0].coordinateY+1>=wall.coordinateY)
                    &&(line.objects[0].coordinateY+1<(wall.coordinateY+wall.height))
                    )
                    return true;
            }
            return false;
        }
        public bool checkBoardCollision()
        {
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createObjects();
        }
    }
}
