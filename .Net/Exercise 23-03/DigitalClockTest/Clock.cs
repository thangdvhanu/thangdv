using System;

namespace DigitalClock
{
    public class Clock{
        public int Hour {get;set;}
        public int Minute {get;set;}
        public int Second {get;set;}
        public Clock(int hour, int minute, int second){
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }
}
