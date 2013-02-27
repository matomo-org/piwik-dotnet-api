#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

using Piwik.Analytics.Parameters;

namespace Piwik.Analytics.Date
{
    public class AbsoluteRangeDate : PiwikDate
    {
        private DateTimeOffset dateStart;
        private DateTimeOffset dateEnd;

        public AbsoluteRangeDate(DateTimeOffset dateStart, DateTimeOffset dateEnd)
        {
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
        }

        public string serialize()
        {
            return DateParameter.formatDate(this.dateStart) + "," + DateParameter.formatDate(this.dateEnd);
        }
    }
}
