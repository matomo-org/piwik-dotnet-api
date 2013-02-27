#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

namespace Piwik.Analytics
{
    public class RefererType
    {
        private int type;

        public static readonly RefererType DIRECT = new RefererType(1);
        public static readonly RefererType SEARCH_ENGINE = new RefererType(2);
        public static readonly RefererType WEBSITE = new RefererType(3);


        private RefererType(int type)
        {
            this.type = type;
        }

        public int getType()
        {
            return this.type;
        }
    }
}
