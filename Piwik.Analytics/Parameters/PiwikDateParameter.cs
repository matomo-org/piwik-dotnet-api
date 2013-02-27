#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

using Piwik.Analytics.Date;

namespace Piwik.Analytics.Parameters
{
    class PiwikDateParameter : Parameter
    {
        private PiwikDate piwikDate;

        public PiwikDateParameter(string name, PiwikDate date) : base(name)
        {
            this.piwikDate = date;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.piwikDate != null)
            {
                parameter = "&" + this.name + "=" + urlEncode(this.piwikDate.serialize());
            }

            return parameter;
        }
    }
}
