#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

using Piwik.Analytics.Date;

namespace Piwik.Analytics.Parameters
{
    class PeriodParameter : Parameter
    {
        private PiwikPeriod period;

        public PeriodParameter(string name, PiwikPeriod period) : base(name)
        {
            this.period = period;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.period != null)
            {
                parameter = "&" + this.name + "=" + urlEncode(this.period.getPeriod());
            }

            return parameter;
        }
    }
}
