using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.BoilEvent += alarm.MakeAlert;
            //heater.BoilEvent += (new Alarm()).MakeAlert;
            heater.BoilEvent += Display.ShowMsg;
            heater.BoilWater();
        }
    }
    public class Heater
    {
        private int temperature;
        public delegate void BoilHandler(int param);
        public event BoilHandler BoilEvent;

        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    BoilEvent?.Invoke(temperature);
                }
            }
        }
    }
    public class Alarm
    {
        public void MakeAlert(int param)
        {
            Console.WriteLine($"Alarm:当前水温：{param}℃");
        }
    }

    public class Display
    {
        public static void ShowMsg(int param)
        {
            Console.WriteLine($"Display:当前水温：{param}℃");
        }
    }
}
