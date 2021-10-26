using SimulatorAirport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;
using DAL;

namespace UI_WPF
{
    public partial class MainWindow : Window
    {
        Random ran = new Random();
        DispatcherTimer dtimer = new DispatcherTimer();

        Rectangle rect;
        
        DBAirport db = new DBAirport();
        Simulator sLand = new Simulator();

        bool[] stations2 = new bool[]
            {true,true,true,true,true,true,true,true,true};

        int totalStations=0;

        public MainWindow()
        {
            InitializeComponent();

            int seconds = ran.Next(1, 2);
            dtimer.Tick += new EventHandler(Landing);
            //dtimer.Tick += new EventHandler(Takeoffs);
            dtimer.Interval = new TimeSpan(0, 0, seconds);
            dtimer.Start();


            //Landing();
            //Takeoffs();          
        }

        private void Landing(object sender, EventArgs e)
        {
            rect = new Rectangle { Height = 20, Width = 20, Fill = new SolidColorBrush(Colors.Black) };

            Grid1.Children.Add(rect);

            Grid.SetRow(rect, 0);
            Grid.SetColumn(rect, 5);

            totalStations = sLand.landingStations.Length;

            for (int cs = 0, column = 3, row=0; cs < totalStations; cs++, column--)
            {
                if (sLand.continueLanding(stations2,cs))
                {
                    if(column > -1)
                    {
                        Grid.SetColumn(rect, column);
                    }
                    else
                    {
                        row++;
                        Grid.SetRow(rect, row);
                    }                    
                    GetCoordinates();
                }
            }
            Grid1.Children.Remove(rect);

            for (int i = 0; i < stations2.Length; i++)
            {
                stations2[i] = true;
            }

            //var moveLeft = new DoubleAnimation(0, -w - w - wd, new TimeSpan(0, 0, 5));
            //rect.RenderTransform = new TranslateTransform();
            //rect.RenderTransform.BeginAnimation(TranslateTransform.XProperty, moveLeft);
        }

        private void GetCoordinates() => MessageBox.Show($"row Y: {Grid.GetRow(rect)}, column X: {Grid.GetColumn(rect)} ");

        private void Takeoffs(object sender, EventArgs e)
        {
            rect = new Rectangle { Height = 20, Width = 20, Fill = new SolidColorBrush(Colors.Black) };

            Grid1.Children.Add(rect);

            Grid.SetRow(rect, 2);
            Grid.SetColumn(rect, 0);

            totalStations = sLand.takeOffStations.Length;

            for (int cs = 0, column = 3, row = 0, times=0; times < totalStations; cs++, column--,times++)
            {
                if (sLand.Takeoff(stations2, sLand.takeOffStations[cs]))
                {
                    if (column > -1)
                    {
                        Grid.SetColumn(rect, column);
                    }
                    else
                    {
                        row++;
                        Grid.SetRow(rect, row);
                    }
                    GetCoordinates();
                }
            }
            Grid1.Children.Remove(rect);

            for (int i = 0; i < stations2.Length; i++)
            {
                stations2[i] = true;
            }
        }
    }
}
