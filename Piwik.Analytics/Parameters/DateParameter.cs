#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

namespace Piwik.Analytics.Parameters
{
    class DateParameter : Parameter
    {
        private DateTimeOffset date;

        public DateParameter(string name, DateTimeOffset date) : base(name)
        {
            this.date = date;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.date != null && !this.date.Equals(default(DateTimeOffset)))
            {
                parameter = "&" + this.name + "=" + formatDate(this.date);
            }

            return parameter;
        }

        public static string formatDate(DateTimeOffset date)
        {
            return String.Format("{0:yyyy-MM-dd}", date);
        }
    }
}
