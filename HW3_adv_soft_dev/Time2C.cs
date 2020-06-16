using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_2_Taylor_Leavelle
{
    class Time2C
    {
        
        private int hour;
        private int minute;
        private int second;
        static List<Time2C> list_time2 = new List<Time2C>();

        public Time2C(int hour = 0, int minute = 0, int second = 0)
        {
            SetTime(hour, minute, second);
        }

        public Time2C(Time2C time)
            : this(time.Hour, time.Minute, time.Second) { }

        public void SetTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public virtual string getTimeUniversal()
        {
            StringBuilder RetString = new StringBuilder();
            RetString.Append(Hour.ToString().PadLeft(2, '0') + ":" + Minute.ToString().PadLeft(2, '0') + ":" + Second.ToString().PadLeft(2, '0'));
            return RetString.ToString();
        }

        public virtual string getTime()
        {
            StringBuilder RetString = new StringBuilder();
            string pmoram;
            if (Hour == 12 || Hour == 0)
            {
                Hour = 12;
                pmoram = "AM";
            }
            else
            {
                Hour = Hour % 12;
                pmoram = "PM";
            }
            RetString.Append(Hour.ToString().PadLeft(2, '0') + ":" + Minute.ToString().PadLeft(2, '0') + ":" + Second.ToString().PadLeft(2, '0'));
            string time = RetString.ToString();
            string final = time + " " + pmoram;
            return final;
        }

        public virtual void addtime(int h = 0, int m = 0, int s = 0) {

            int total_hours = Hour + h;
            int total_minutes = Minute + m;
            int total_seconds = Second + s;

            Second = total_seconds % 60;
            Minute = total_minutes % 60;
            Hour = total_hours % 24;

            int remainder_seconds = ((Minute * 60) + (Second));
            remainder_seconds = (remainder_seconds + ((Hour * 60) * 60));

            int days_passed = 0;

            if (remainder_seconds > 0)
            {
               
                days_passed = days_passed +1;
                if (remainder_seconds >= 86400)
                {
                    days_passed = remainder_seconds / 86400;
                }
                Console.WriteLine("The clock passed midnight. "+ days_passed + " day has passed.");
            }

            StringBuilder RetString = new StringBuilder();
            RetString.Append(Hour.ToString().PadLeft(2, '0') + ":" + Minute.ToString().PadLeft(2, '0') + ":" + Second.ToString().PadLeft(2, '0'));

        }

        public virtual void addtime(Time2C atime) {
            int hour2 = atime.Hour;
            int minute2 = atime.Minute;
            int second2 = atime.Second;

            int total_hours = Hour + hour2;
            int total_minutes = Minute + minute2;
            int total_seconds = Second + second2;

            Second = total_seconds % 60;
            Minute = total_minutes % 60;
            Hour = total_hours % 24;

            int remainder_seconds = ((Minute * 60) + (Second));
            remainder_seconds = (remainder_seconds + ((Hour * 60) * 60));

            int days_passed = 0;

            if (remainder_seconds > 0)
            {

                days_passed = days_passed + 1;
                if (remainder_seconds >= 86400)
                {
                    days_passed = remainder_seconds / 86400;
                }
                Console.WriteLine("The clock passed midnight. " + days_passed + " day(s) have passed.");
            }

            StringBuilder RetString = new StringBuilder();
            RetString.Append(Hour.ToString().PadLeft(2, '0') + ":" + Minute.ToString().PadLeft(2, '0') + ":" + Second.ToString().PadLeft(2, '0'));
        }

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Hour)} must be 0-23");
                }
                hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Minute)} must be 0-59");
                }
                minute = value;
            }
        }

        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Second)} must be 0-59");
                }
                second = value;
            }
        }
    }

    class Time2tz : Time2C
    {
        private string timezone;

        public Time2tz(string timezone = "CST", int hour = 0, int minute = 0, int second = 0) : base(hour, minute, second)
        {
            this.timezone = timezone;
        }

        public Time2tz(Time2tz time)
            : this(time.timezone, time.Hour, time.Minute, time.Second) { }

        public override string getTimeUniversal()
        {
            StringBuilder RetString = new StringBuilder();
            RetString.Append(Hour.ToString().PadLeft(2, '0') + ":" + Minute.ToString().PadLeft(2, '0') + ":" + Second.ToString().PadLeft(2, '0') + " " + timezone.ToString().PadLeft(2, '0'));
            return RetString.ToString();
        }

        public override string getTime()
        {
            StringBuilder RetString = new StringBuilder();
            string pmoram;
            if (Hour == 12 || Hour == 0)
            {
                Hour = 12;
                pmoram = "AM";
            }
            else
            {
                Hour = Hour % 12;
                pmoram = "PM";
            }
            RetString.Append(Hour.ToString().PadLeft(2, '0') + ":" + Minute.ToString().PadLeft(2, '0') + ":" + Second.ToString().PadLeft(2, '0'));
            string time = RetString.ToString();
            string final = time + " " + pmoram + " " + timezone;
            return final;
        }
    }
}
