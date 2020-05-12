using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Backup
    {
        public string ID { get; set; }
        public string DateCreated { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Status { get; set; }
    }

    public struct BackupResult
    {
        public Dictionary<string, Backup> Backups { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class Schedule
    {
        public bool Enabled { get; set; }

        /// <summary>
        /// Backup cron type. Can be one of 'daily', 'weekly', 'monthly', 'daily_alt_even', or 'daily_alt_odd'.
        /// </summary>
        /// <returns></returns>
        public string CronType { get; set; }

        public string NextScheduledTimeUTC { get; set; }

        /// <summary>
        /// Hour value (0-23). Applicable to crons: 'daily', 'weekly', 'monthly', 'daily_alt_even', 'daily_alt_odd'
        /// </summary>
        /// <returns></returns>
        public Hour Hour { get; set; }

        /// <summary>
        /// Day-of-week value (0-6). Applicable to crons: 'weekly'.
        /// </summary>
        /// <returns></returns>
        public DOW DOW { get; set; }

        /// <summary>
        /// Day-of-month value (1-28). Applicable to crons: 'monthly'.
        /// </summary>
        /// <returns></returns>
        public DOM DOM { get; set; }
    }

    public struct ScheduleResult
    {
        public Schedule Schedule { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    /// <summary>
    /// Hour value (0-23). Applicable to crons: 'daily', 'weekly', 'monthly', 'daily_alt_even', 'daily_alt_odd'
    /// </summary>
    public enum Hour
    {
        HOUR00,
        HOUR01,
        HOUR02,
        HOUR03,
        HOUR04,
        HOUR05,
        HOUR06,
        HOUR07,
        HOUR08,
        HOUR09,
        HOUR10,
        HOUR11,
        HOUR12,
        HOUR13,
        HOUR14,
        HOUR15,
        HOUR16,
        HOUR17,
        HOUR18,
        HOUR19,
        HOUR20,
        HOUR21,
        HOUR22,
        HOUR23,
        HOUR24
    }

    /// <summary>
    /// Day-of-week value (0-6). Applicable to crons: 'weekly'.
    /// </summary>
    public enum DOW
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    /// <summary>
    /// Day-of-month value (1-28). Applicable to crons: 'monthly'.
    /// </summary>
    public enum DOM
    {
        DAY01 = 1,
        DAY02 = 2,
        DAY03 = 3,
        DAY04 = 4,
        DAY05 = 5,
        DAY06 = 6,
        DAY07 = 7,
        DAY08 = 8,
        DAY09 = 9,
        DAY10 = 10,
        DAY11 = 11,
        DAY12 = 12,
        DAY13 = 13,
        DAY14 = 14,
        DAY15 = 15,
        DAY16 = 16,
        DAY17 = 17,
        DAY18 = 18,
        DAY19 = 19,
        DAY20 = 20,
        DAY21 = 21,
        DAY22 = 22,
        DAY23 = 23,
        DAY24 = 24,
        DAY25 = 25,
        DAY26 = 26,
        DAY27 = 27,
        DAY28 = 28
    }
}