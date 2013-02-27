#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

namespace Piwik.Analytics.Date
{
    public class MagicDate : PiwikDate
    {
        private string keyword;

        public static readonly MagicDate TODAY =  new MagicDate("today");
        public static readonly MagicDate YESTERDAY = new MagicDate("yesterday");

        private MagicDate(String keyword)
        {
            this.keyword = keyword;
        }

        public string serialize()
        {
            return this.keyword;
        }
    }
}
