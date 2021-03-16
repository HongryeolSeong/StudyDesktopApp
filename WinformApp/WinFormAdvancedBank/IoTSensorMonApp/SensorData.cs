using System;

namespace IoTSensorMonApp
{
    internal class SensorData
    {
        public DateTime Current { get; set; }
        public int Value { get; set; }
        public bool SimulFlag { get; set; }

        public SensorData(DateTime current, int value, bool simulFlag)
        {
            Current = current;
            Value = value;
            SimulFlag = simulFlag;
        }
    }
}
