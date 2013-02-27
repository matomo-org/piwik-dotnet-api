#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

namespace Piwik.Analytics.Date
{
    public class PiwikPeriod
    {
        private string period;

        public static readonly PiwikPeriod DAY = new PiwikPeriod("day");
        public static readonly PiwikPeriod WEEK = new PiwikPeriod("week");
        public static readonly PiwikPeriod MONTH = new PiwikPeriod("month");
        public static readonly PiwikPeriod YEAR = new PiwikPeriod("year");
        public static readonly PiwikPeriod RANGE = new PiwikPeriod("range");

        private PiwikPeriod(string period)
        {
            this.period = period;
        }

        public string getPeriod() {
            return this.period;
        }

        public static Boolean isMultipleDates(PiwikPeriod period, PiwikDate date)
        {
            return 
                !String.Equals(PiwikPeriod.RANGE.getPeriod(), period.getPeriod()) &&
                (date is AbsoluteRangeDate || date is RelativeRangeDate);
        }
    }
}
