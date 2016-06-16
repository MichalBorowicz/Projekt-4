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
        private int directionX = 1;
        private int directionY = 0;
        private DispatcherTimer timer;
        private static readonly int size = 10;
        public MainWindow()
        {
            
            InitializeComponent();
            initBoard();
            initLine();
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
        void initLine()
        {
            foreach (BaseLine item in line.line)
            {
                grid.Children.Add(item.rectangle);
                line.reDraw(line.line);                
            }
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
        void createWall()
        {
            line.createWall(0, 0);
            foreach (Wall item in line.listOfWalls)
            {
                grid.Children.Add(item.rectangle);
                line.reDraw(line.listOfWalls);
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
            foreach (BaseLine baseLine in line.line)
            {
                
                if ((line.objects[0].coordinateX > baseLine.coordinateX)&&(line.objects[0].coordinateY+1==baseLine.coordinateY))
                    return true;
            }
            return false;
        }
        public bool checkBoardCollision()
        {
            return true;
        }
    }
}
