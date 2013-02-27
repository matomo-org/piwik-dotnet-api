#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

using Piwik.Analytics.Parameters;

namespace Piwik.Analytics.Date
{
    public class SimpleDate : PiwikDate
    {
        private DateTimeOffset date;

        public SimpleDate(DateTimeOffset date)
        {
            this.date = date;
        }

        public string serialize()
        {
            return DateParameter.formatDate(this.date);
        }
    }
}
