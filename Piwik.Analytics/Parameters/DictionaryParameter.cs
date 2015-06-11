#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;
using System.Collections.Generic;

namespace Piwik.Analytics.Parameters
{
    class DictionaryParameter : Parameter
    {

        private Dictionary<string, Object> values;

        public DictionaryParameter(string name, Dictionary<string, Object> values)
            : base(name)
        {
            this.values = values;
        }

        public override string serialize()
        {
            string parameter = String.Empty;

            if (this.values != null)
            {
                foreach (KeyValuePair<String, Object> kv in values)
                {
                    if (kv.Value == null)
                        continue;

                    if (kv.Value is String[])
                    {
                        String[] arr = (String[])kv.Value;
                        foreach (String s in arr)
                        {
                            parameter += "&" + this.name + "[" + kv.Key + "][]=" + urlEncode(s);
                        }
                    }
                    else
                    {
                        parameter += "&" + this.name + "[" + kv.Key + "]=" + urlEncode(kv.Value.ToString());
                    }
                }
            }
            return parameter;
        }
    }
}