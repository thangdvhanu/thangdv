using System;
using DigitalClock;

namespace DigitalClockTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockPublisher clockPublisher = new ClockPublisher();
            ClockSubcriber clockSubcriber = new ClockSubcriber();
            clockSubcriber.Subcribe(clockPublisher);

            clockPublisher.Run();
        }
    }
}
