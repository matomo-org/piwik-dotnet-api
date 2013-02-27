#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;
using System.Collections.Generic;
using System.Collections;

using Piwik.Analytics.Parameters;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>
namespace Piwik.Analytics.Modules
{

    /// <summary>
    /// Service Gateway for Piwik SitesManager Module API
    /// For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// 
    /// <remarks>
    /// This Analytics API is tested against Piwik 1.5
    /// </remarks> 
    public class SitesManager : PiwikAnalytics 
    {

        public const string ID = "idsite";
        public const string NAME = "name";
        public const string MAIN_URL = "main_url";
        public const string TS_CREATED = "ts_created";
        public const string TIMEZONE = "timezone";
        public const string CURRENCY = "currency";
        public const string EXCLUDED_IPS = "excluded_ips";
        public const string EXCLUDED_PARAMETERS = "excluded_parameters";
        public const string FEEDBURNER_NAME = "feedburnerName";
        public const string GROUP = "group";
        public const string ECOMMERCE = "ecommerce";

        private const string PLUGIN = "SitesManager";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        /// <summary>
        /// Add a piwik site
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="urls"></param>
        /// <param name="ecommerce"></param>
        /// <param name="excludedIps"></param>
        /// <param name="excludedQueryParameters"></param>
        /// <param name="timezone"></param>
        /// <param name="currency"></param>
        /// <param name="group"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public int addSite(
            string siteName, 
            string[] urls, 
            bool ecommerce = false, 
            string[] excludedIps = null,
            string[] excludedQueryParameters = null, 
            string timezone = null, 
            string currency = null, 
            string group = null, 
            DateTimeOffset startDate = default(DateTimeOffset))
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("siteName", siteName),
                new SimpleParameter("ecommerce", ecommerce),
                new ArrayParameter("excludedIps", excludedIps, true),
                new ArrayParameter("excludedQueryParameters", excludedQueryParameters, true),
                new ArrayParameter("urls", urls),
                new SimpleParameter("timezone", timezone),
                new SimpleParameter("currency", currency),
                new SimpleParameter("group", group),
                new DateParameter("startDate", startDate),
            };

            return this.sendRequest<int>("addSite", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Remove a Piwik site
        /// </summary>
        /// <param name="idSite"></param>
        /// <returns></returns>
        public Boolean deleteSite(int idSite)
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("idSite", idSite),
            };

            return this.sendRequest<Boolean>("deleteSite", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Find sites from their URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ArrayList getSitesIdFromSiteUrl(string url)
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("url", url),
            };

            return this.sendRequest<ArrayList>("getSitesIdFromSiteUrl", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Find a site from its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArrayList getSiteFromId(int id)
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("idSite", id),
            };

            return this.sendRequest<ArrayList>("getSiteFromId", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Update a Piwik Site.
        /// 
        /// All the existing parameters need to be provided otherwise they will be erased from the database.
        /// </summary>
        /// <param name="idSite"></param>
        /// <param name="siteName"></param>
        /// <param name="urls"></param>
        /// <param name="ecommerce"></param>
        /// <param name="excludedIps"></param>
        /// <param name="excludedQueryParameters"></param>
        /// <param name="timezone"></param>
        /// <param name="currency"></param>
        /// <param name="group"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public Boolean updateSite(
            int idSite,
            string siteName, 
            string[] urls, 
            bool ecommerce = false, 
            string[] excludedIps = null,
            string[] excludedQueryParameters = null, 
            string timezone = null, 
            string currency = null, 
            string group = null, 
            DateTimeOffset startDate = default(DateTimeOffset))
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("idSite", idSite),
                new SimpleParameter("siteName", siteName),
                new SimpleParameter("ecommerce", ecommerce),
                new ArrayParameter("excludedIps", excludedIps, true),
                new ArrayParameter("excludedQueryParameters", excludedQueryParameters, true),
                new ArrayParameter("urls", urls),
                new SimpleParameter("timezone", timezone),
                new SimpleParameter("currency", currency),
                new SimpleParameter("group", group),
                new DateParameter("startDate", startDate),
            };

            return this.sendRequest<Boolean>("updateSite", new List<Parameter>(parameters));
        }
    }
}
