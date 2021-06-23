using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using TimeZoneConverter;
using TimeZoneConverter.Posix;
using TimeZoneNames;

namespace TimeZones {
    class Program {
        static void Main(string[] args) {
            //TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Time");
            //Console.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}\t{4}",
            //    tzInfo.Id,
            //    tzInfo.StandardName,
            //    tzInfo.DisplayName,
            //    tzInfo.BaseUtcOffset,
            //    tzInfo.SupportsDaylightSavingTime));

            //ReadOnlyCollection<TimeZoneInfo> timezones = TimeZoneInfo.GetSystemTimeZones();
            //Console.WriteLine(String.Format("{0, -35}{1, -35}{2, -62}{3, -17}{4, -17}{5, -15}",
            //    "ID", "Standard Name", "Display Name", "Base UTC Offset", "Current UTC", "Daylight Time"));

            //foreach (var tz in timezones) {
            //    Console.WriteLine(String.Format("{0, -35}{1, -35}{2, -62}{3, -17}{4, -17}{5, -15}",
            //        tz.Id,
            //        tz.StandardName,
            //        tz.DisplayName,
            //        tz.BaseUtcOffset,
            //        tz.GetUtcOffset(DateTime.Now),
            //        tz.SupportsDaylightSavingTime));
            //}

            string timeZoneName = "America/New_York";
            DateTime dt = new DateTime(2021, 3, 1);
            TimeZoneInfo tzi = TZConvert.GetTimeZoneInfo(timeZoneName);
            Console.WriteLine(tzi.ToString());
            Console.WriteLine(String.Format("{0, -35}{1, -35}{2, -62}{3, -17}{4, -17}{5, -15}",
                "ID", "Standard Name", "Display Name", "Base UTC Offset", "Current UTC", "Daylight Time"));
            Console.WriteLine(String.Format("{0, -35}{1, -35}{2, -62}{3, -17}{4, -17}{5, -15}",
                tzi.Id, tzi.StandardName, tzi.DisplayName, tzi.BaseUtcOffset, tzi.GetUtcOffset(DateTime.Now), tzi.SupportsDaylightSavingTime));
            
            string posix = PosixTimeZone.FromIanaTimeZoneName(timeZoneName);
            Console.WriteLine("-------------------------------");
            Console.WriteLine(posix);

            //posix = PosixTimeZone.FromIanaTimeZoneName("Pacific/Honolulu");
            //Console.WriteLine("-------------------------------");
            //Console.WriteLine(posix);

            Console.WriteLine("-------------------------------");
            //TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById("America/Chicago");
            bool isDaylight = tzi.IsDaylightSavingTime(dt);
            Console.WriteLine(isDaylight);
            if (isDaylight)
                Console.WriteLine(posix.Substring(4, 3));
            else
                Console.WriteLine(posix.Substring(0, 3));

            Console.WriteLine("---------- time zone names ----------");
            string tzID = tzi.Id;
            string lang = CultureInfo.CurrentCulture.Name;
            var tzAbbr = TZNames.GetAbbreviationsForTimeZone(tzID, lang);
            if (isDaylight)
                Console.WriteLine(tzAbbr.Daylight);
            else
                Console.WriteLine(tzAbbr.Standard);
        }
    }
}
