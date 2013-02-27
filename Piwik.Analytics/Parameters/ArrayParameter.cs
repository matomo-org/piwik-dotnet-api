#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;

namespace Piwik.Analytics.Parameters
{
    class ArrayParameter : Parameter
    {
        private string[] values;
        private bool inline;

        public ArrayParameter(string name, string[] values, bool inline = false) : base (name)
        {
            this.values = values;
            this.inline = inline;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.values != null)
            {
                if (this.inline)
                {
                    parameter = "&" + this.name + "=";

                    for (int i = 0; i < this.values.Length; i++)
                    {
                        parameter += urlEncode(this.values[i]) + ",";
                    }
                }
                else
                {
                    for (int i = 0; i < this.values.Length; i++)
                    {
                        parameter += "&" + this.name + "[" + i + "]=" + urlEncode(this.values[i]);
                    }
                }

            }

            return parameter;
        }
    }
}
