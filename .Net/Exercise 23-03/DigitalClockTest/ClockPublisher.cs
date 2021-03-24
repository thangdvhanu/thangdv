using System;
using System.Threading;

namespace DigitalClock
{

    public class ClockPublisher
    {
        //create Delegate
        public delegate void SecondChangeHandler(ClockPublisher clockPublisher, Clock time);
        //create Event based on delegate
        public event SecondChangeHandler SecondChange;

        //create method to fire Event
        public void OnSecondChange(ClockPublisher clockPublisher, Clock time)
        {
            SecondChange(clockPublisher, time);
        }

        //setup Clock Running
        //On each second it will raise an eent to display clock

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);
                var dateTime = DateTime.Now;
                Clock time = new Clock(dateTime.Hour, dateTime.Minute, dateTime.Second);
                OnSecondChange(this, time);
            }
        }
    }
}