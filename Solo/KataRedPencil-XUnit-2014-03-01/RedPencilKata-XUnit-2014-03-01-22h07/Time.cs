namespace RedPencilKata_XUnit_2014_03_01_22h07
{
    using System;

    public static class Time
    {
        private static DateTime? now = null;

        public static DateTime Now
        {
            get
            {
                return now ?? DateTime.Now;
            }
            set
            {
                now = value;
            }
        }

        public static void AdvanceDays(int i)
        {
            Now = Now.AddDays(i);
        }
    }
}