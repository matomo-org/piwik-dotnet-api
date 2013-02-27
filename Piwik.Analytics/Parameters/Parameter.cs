#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System.Web;

namespace Piwik.Analytics.Parameters
{
    public abstract class Parameter
    {
        protected string name;

        abstract public string serialize();

        public Parameter(string name)
        {
            this.name = name;
        }

        protected static string urlEncode(string value)
        {
            return HttpUtility.UrlEncode(value);
        }
    }
}
