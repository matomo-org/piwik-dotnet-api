#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Conversive.PHPSerializationLibrary;
using System.Collections;

using Piwik.Analytics.Parameters;

namespace Piwik.Analytics
{
    abstract public class PiwikAnalytics
    {
        public static string URL;

        private string tokenAuth;

        abstract protected string getPlugin();

        public void setTokenAuth(string tokenAuth)
        {
            this.tokenAuth = tokenAuth;
        }

        protected T sendRequest<T>(string method, List<Parameter> parameters)
        {
            if (String.IsNullOrEmpty(URL))
            {
                throw new Exception("You must first set the Piwik Server URL by setting the static property 'URL'");
            }

            parameters.Add(new SimpleParameter("token_auth", this.tokenAuth));
            parameters.Add(new SimpleParameter("method", this.getPlugin() + "." + method));

            string url = URL + "/?module=API&format=php";

            foreach (Parameter parameter in parameters)
            {
                url += parameter.serialize();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)((HttpWebRequest)WebRequest.Create(url)).GetResponse();

            string responseData;

            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")))
            {
                responseData = sr.ReadLine();

                if (String.IsNullOrEmpty(responseData))
                {
                    throw new PiwikAPIException("The server response doesn't contain any data.");
                }

                string secondLine = sr.ReadLine();

                if (!String.IsNullOrEmpty(secondLine))
                {
                    throw new PiwikAPIException(
                        "The server response contains an anormal number of lines. " + 
                        "Please contact the developer with the following details : " +
                        "secondLine = " + secondLine + ", responseData = " + responseData
                    );
                }
            }

            httpResponse.Close();

            Object deserializedObject = new Serializer().Deserialize(responseData);

            if (deserializedObject == null)
            {
                throw new PiwikAPIException(
                    "The server response is not deserializable. " + 
                    "Please contact the developer with the following details : responseData = " + responseData
                );
            }

            if (!(deserializedObject is T))
            {
                if (deserializedObject is Hashtable)
                {
                    Hashtable result = (Hashtable)deserializedObject;
                    string resultString = (string)result["result"];
                    
                    if (resultString.Equals("error"))
                    {
                        throw new PiwikAPIException((string)result["message"]);
                    }
                    else
                    {
                        Boolean resultStatus = false;
                        if (resultStatus is T && resultString.Equals("success"))
                        {
                            resultStatus = true;
                            return (T)(Object)resultStatus;
                        }
                        
                        throw new PiwikAPIException(
                            "The server response does not match the expected return type. " + 
                            "Please contact the developer with the following details : " + 
                            "responseData = " + responseData + ", deserializedObject.getType() = " + deserializedObject.GetType()
                        );
                    }
                }
                else
                {
                    throw new PiwikAPIException(
                        "The server response has an unknown format. " + 
                        "Please contact the developer with the following details : " + 
                        "responseData = " + responseData + ", deserializedObject.getType() = " + deserializedObject.GetType()
                    );
                }
            }

            return (T)deserializedObject;
        }
    }
}
