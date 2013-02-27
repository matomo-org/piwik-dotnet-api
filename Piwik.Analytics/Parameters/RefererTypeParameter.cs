#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

namespace Piwik.Analytics.Parameters
{
    public class RefererTypeParameter : Parameter
    {
        private RefererType refererType;

        public RefererTypeParameter(string name, RefererType refererType)
            : base(name)
        {
            this.refererType = refererType;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.refererType != null)
            {
                parameter = "&" + this.name + "=" + urlEncode(this.refererType.getType().ToString());
            }

            return parameter;
        }
    }
}
