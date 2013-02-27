#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

namespace Piwik.Analytics
{
    public class PiwikAPIException: Exception
    {
        public PiwikAPIException(string message) : base(message)
        {
        }
    }
}
