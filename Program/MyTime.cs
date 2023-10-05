using System;

namespace Program
{
    public class MyTime
    {
        private int _hour, _minute, _second;

        public MyTime(int h, int m, int s)
        {
            SetTime(h, m, s);
        }

        private void SetTime(int h, int m, int s)
        {
            if (h >= 0 && h <= 23 && m >= 0 && m <= 59 && s >= 0 && s <= 59)
            {
                _hour = h;
                _minute = m;
                _second = s;
            }
            else
            {
                throw new Exception("Invalid time format!");
            }
        }

        public override string ToString()
        {
            return $"{_hour:D2}:{_minute:D2}:{_second:D2}";
        }

        public int TimeSinceMidnight()
        {
            return _hour * 3600 + _minute * 60 + _second;
        }
        
        public void AddOneSecond()
        {
            int totalSeconds = TimeSinceMidnight() + 1;
            SetTime(totalSeconds / 3600, (totalSeconds / 60) % 60, totalSeconds % 60);
        }

        public void AddOneMinute()
        {
            int totalSeconds = TimeSinceMidnight() + 60;
            SetTime(totalSeconds / 3600, (totalSeconds / 60) % 60, totalSeconds % 60);
        }

        public void AddOneHour()
        {
            int totalSeconds = TimeSinceMidnight() + 3600;
            SetTime(totalSeconds / 3600, (totalSeconds / 60) % 60, totalSeconds % 60);
        }

        public void AddSeconds(int s)
        {
            int totalSeconds = TimeSinceMidnight() + s;
            totalSeconds = (totalSeconds % 86400 + 86400) % 86400; // Ensure the result is non-negative and within a day
            SetTime(totalSeconds / 3600, (totalSeconds / 60) % 60, totalSeconds % 60);
        }

        public int Difference(MyTime otherTime)
        {
            int diff = Math.Abs(TimeSinceMidnight() - otherTime.TimeSinceMidnight());
            if (diff > 43200) diff = 86400 - diff;
            return diff;
        }
    }
}