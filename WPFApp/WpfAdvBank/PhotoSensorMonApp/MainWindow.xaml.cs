using LiveCharts;
using LiveCharts.Wpf;
using MahApps.Metro.Controls;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PhotoSensorMonApp
{
    public class SensorData
    {
        public int Idx { get; set; }
        public DateTime CurrentDt { get; set; }
        public int Value { get; set; }
        public bool SimulFlag { get; set; }
        public SensorData(int idx, DateTime currentDt, int value, bool simulFlag)
        {
            Idx = idx;
            CurrentDt = currentDt;
            Value = value;
            SimulFlag = simulFlag;
        }
    }

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();

            logger.Info("PhotoSensorMonApp Initialized...");
        }

        public ChartValues<int> ChartValues { get; set; }
        public double SensorValue { get; set; }
        public DispatcherTimer CustomTimer { get; set; }

        public string connString = "Data Source=127.0.0.1;" +
                                   "Initial Catalog=IoTData;" +
                                   "Persist Security Info=True;" +
                                   "User ID=sa;Password=mssql_p@ssw0rd!";

        public SensorData GetRealTimeSensor()
        {
            SensorData result = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                    var query = @"SELECT Top 1 Idx
                                  , CurrentDt
                                  , Value
                                  , SimulFlag
                              FROM dbo.Tbl_PhotoResistor
                             ORDER BY Idx DESC; ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    var temp = cmd.ExecuteReader();
                    if (temp.Read())
                    {
                        result = new SensorData(Convert.ToInt32(temp["Idx"]),
                                                Convert.ToDateTime(temp["CurrentDt"]),
                                                Convert.ToInt32(temp["Value"]),
                                                Convert.ToBoolean(temp["SimulFlag"]));
                    }
                }

                logger.Info("GetRealTimeSensor completed!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"예외발생 : {ex.Message}");
                logger.Error($"GetRealTimeSensor() error occured : {ex.Message}");
            }

            return result;
        }


        private void Window_Initialized(object sender, EventArgs e)
        {
            /*var x = Enumerable.Range(0, 1001).Select(i => i / 10.0).ToArray();
            var y = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v);
            ChtLine.Plot(x, y);*/

            ChartValues = new ChartValues<int>() { 4, 1, 5, 2, 6, 3 };
            GrdHistory.DataContext = ChartValues;

            CustomTimer = new DispatcherTimer();
            CustomTimer.Interval = TimeSpan.FromSeconds(1);
            CustomTimer.Tick += CustomTimer_Tick;
            // CustomTimer.Start();
        }

        private void CustomTimer_Tick(object sender, EventArgs e)
        {
            SensorValue = GetRealTimeSensor().Value;
            GrdRealTime.DataContext = SensorValue;
        }

        private void MnuStart_Click(object sender, RoutedEventArgs e)
        {
            CustomTimer.Start();
        }

        private void MnuStop_Click(object sender, RoutedEventArgs e)
        {
            CustomTimer.Stop();
        }

        private void MnuExit_Click(object sender, RoutedEventArgs e)
        {
            //Environment.Exit(0);
            Application.Current.Shutdown(0); //더 빨리 종료 됨
        }

        private void MenuLoad_Click(object sender, RoutedEventArgs e)
        {
            HistoryValues.ItemsSource = GetHistorySensor();
        }

        private List<DataPoint> GetHistorySensor()
        {
            List<DataPoint> result = new List<DataPoint>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                    var query = $@"SELECT Idx, Value
                                      FROM Tbl_PhotoResistor
                                     WHERE CurrentDt > CONVERT(DATETIME, '{DateTime.Now.ToString("yyyy-MM-dd")}')
                                     ORDER BY Idx;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(new DataPoint(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1])));
                    }
                }

                logger.Info("GetHistorySensor() completed!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"예외 발생 : {ex.Message}");
                logger.Error($"GetHistorySensor() error occured : {ex.Message}");
            }

            return result;
        }
    }
}