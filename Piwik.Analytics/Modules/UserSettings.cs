#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;
using System.Collections.Generic;
using System.Collections;

using Piwik.Analytics.Date;
using Piwik.Analytics.Parameters;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>
namespace Piwik.Analytics.Modules
{

    /// <summary>
    /// Service Gateway for Piwik UserSettings Module API
    /// For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// 
    /// <remarks>
    /// This Analytics API is tested against Piwik 1.5
    /// </remarks> 
    public class UserSettings : PiwikAnalytics 
    {
        public const string LABEL = "label";
        public const string NB_UNIQ_VISITORS = "nb_uniq_visitors";
        public const string NB_VISITS = "nb_visits";
        public const string NB_ACTIONS = "nb_actions";
        public const string MAX_ACTIONS = "max_actions";
        public const string SUM_VISIT_LENGTH = "sum_visit_length";
        public const string BOUNCE_COUNT = "bounce_count";
        public const string NB_VISITS_CONVERTED = "nb_visits_converted";
        public const string LOGO = "logo";
        public const string SHORTLABEL = "shortLabel";
        public const string SUM_DAILY_NB_UNIQ_VISITORS = "sum_daily_nb_uniq_visitors";


        private const string PLUGIN = "UserSettings";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        public Object getBrowser(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter("period", period),
                new PiwikDateParameter("date", date),
                new SimpleParameter("segment", segment),
            };

            if (PiwikPeriod.isMultipleDates(period, date))
            {
                return this.sendRequest<Hashtable>("getBrowser", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<ArrayList>("getBrowser", new List<Parameter>(parameters));
            }
        }

        public Object getOS(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter("period", period),
                new PiwikDateParameter("date", date),
                new SimpleParameter("segment", segment),
            };

            if (PiwikPeriod.isMultipleDates(period, date))
            {
                return this.sendRequest<Hashtable>("getOS", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<ArrayList>("getOS", new List<Parameter>(parameters));
            }
        }

        public Object getMobileOS(int idSite, PiwikPeriod period, PiwikDate date)
        {
            List<String> mobileOS = new List<String>();
            mobileOS.Add("IPH"); // iPhone
            mobileOS.Add("AND"); // Android
            mobileOS.Add("IPD"); // iPod
            mobileOS.Add("IPA"); // iPad
            mobileOS.Add("BLB"); // Blackberry
            mobileOS.Add("WP7"); // Windows Phone 7
            mobileOS.Add("W65"); // Windows Mobile 6.5
            mobileOS.Add("W61"); // Windows Mobile 6.1
            mobileOS.Add("WOS"); // Palm webOS
            mobileOS.Add("POS"); // Palm OS
            mobileOS.Add("QNX"); // QNX & RIM Tablet OS
            mobileOS.Add("SYM"); // Symbian OS               

            String segment = String.Empty;
            foreach (String OS in mobileOS)
            {
                segment += "operatingSystem==" + OS + ",";
            }
                              
            return this.getOS(idSite, period, date, segment);
        }

    }
}
