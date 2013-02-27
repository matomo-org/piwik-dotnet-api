#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

namespace Piwik.Analytics.Date
{
    public class RelativeRangeDate : PiwikDate
    {
        private string relativeRange;
        private int nbDays;

        public static RelativeRangeDate LAST(int nbDays)
        {
            return new RelativeRangeDate("last", nbDays);
        }

        public static RelativeRangeDate PREVIOUS(int nbDays)
        {
            return new RelativeRangeDate("previous", nbDays);
        }

        private RelativeRangeDate(String relativeRange, int nbDays)
        {
            this.relativeRange = relativeRange;
            this.nbDays = nbDays;
        }

        public string serialize()
        {
            return this.relativeRange + this.nbDays.ToString();
        }
    }
}
