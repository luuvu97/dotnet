using System;

namespace KTLT
{
    public class TimeOfWork
    {
        DateTime begin;
        DateTime end;

        public TimeOfWork()
        {
            begin = new DateTime();
            end = new DateTime();
        }

        public void setData(String str)
        {
            String[] arr = str.Split(",");
            this.begin = TimeOfWork.parseDateString(arr[0]);
            this.end = TimeOfWork.parseDateString(arr[0]);
            this.begin += TimeOfWork.parseTimeString(arr[1]);
            this.end += TimeOfWork.parseTimeString(arr[2]);
        }

        public void display(){
            Console.Write($"{this.begin.Day}/{this.begin.Month}/{this.begin.Year}");
            Console.Write($",{this.begin.Hour}:{this.begin.Minute}");
            Console.Write($",{this.end.Hour}:{this.end.Minute}");
        }
        public static DateTime parseDateString(String str)
        {
            int d, m, y;
            String[] arr = str.Split("/");
            d = Int32.Parse(arr[0]);
            m = Int32.Parse(arr[1]);
            y = Int32.Parse(arr[2]);
            return new DateTime(y, m, d);
        }

        public static TimeSpan parseTimeString(String str)
        {
            int h, m;
            String[] arr = str.Split(":");
            h = Int32.Parse(arr[0]);
            m = Int32.Parse(arr[1]);
            return new TimeSpan(h, m, 0);
        }
    }
}