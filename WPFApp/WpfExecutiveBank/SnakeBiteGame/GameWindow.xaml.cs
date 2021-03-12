using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeBiteGame
{
    /// <summary>
    /// GameWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GameWindow : Window
    {
        Random rand = new Random();

        Ellipse[] snake = new Ellipse[30];
        Ellipse egg = new Ellipse();
        private int size = 12; // egg, body
        private int visibleCount = 5;
        private string move = "";
        private int eaten = 0;
        DispatcherTimer playTimer = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();
        private bool startFlag/*IsStart*/ = false;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            InitSnake();
            InitEgg();

            playTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            playTimer.Tick += PlayTimer_Tick;
            playTimer.Start();
        }

        private void InitSnake()
        {
            int x = rand.Next(1, 500 / size) * size;
            int y = rand.Next(1, 400 / size) * size;

            for (int i = 0; i < 30; i++)
            {
                snake[i] = new Ellipse();
                snake[i].Width = snake[i].Height = size;
                if (i == 0)
                    snake[i].Fill = Brushes.Chocolate;
                else if (i % 5 == 0)
                    snake[i].Fill = Brushes.YellowGreen;
                else
                    snake[i].Fill = Brushes.Gold;
                snake[i].Stroke = Brushes.Black;

                CvsGame.Children.Add(snake[i]);

            }

            // snake 길이가 5개, 나머지 화면에서 지움
            for (int i = visibleCount; i < 30; i++)
            {
                snake[i].Visibility = Visibility.Hidden;
            }

            CreateSnake(x, y);
        }

        private void CreateSnake(int x, int y)
        {
            for (int i = 0; i < visibleCount; i++)
            {
                snake[i].Tag = new Point(x, y + i * size); // Tag : 뱀의 위치
                Canvas.SetLeft(snake[i], x);
                Canvas.SetTop(snake[i], y + i * size);
            }
        }

        private void InitEgg()
        {

        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            if (move != null)
            {
                startFlag = true;

                for (int i = visibleCount; i <= 1; i--)
                {
                    Point p = (Point)snake[i - 1].Tag;
                    snake[i].Tag = new Point(p.X, p.Y);
                }

                // 키보드로 옮겼을때 처리
                
                //알을 먹었는지 체크
            }

            if (startFlag)
            {
                TimeSpan span = stopwatch.Elapsed;
                Txttime.Text = $"Time = {span.Minutes} : {span.Seconds} : {span.Milliseconds / 10}";
                DrawSnake();
            }
        }

        private void DrawSnake()
        {
            for (int i = 0; i < visibleCount; i++)
            {
                Point p = (Point)snake[i].Tag;
                Canvas.SetLeft(snake[i], p.X);
                Canvas.SetTop(snake[i], p.Y);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            stopwatch.Start();

            // 키조작
        }

    }
}
