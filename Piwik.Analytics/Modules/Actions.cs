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
    /// Service Gateway for Piwik Actions Module API
    /// For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// 
    /// <remarks>
    /// This Analytics API is tested against Piwik 1.5
    /// </remarks> 
    public class Actions : PiwikAnalytics 
    {
        public const string LABEL = "label";
        public const string NB_VISITS = "nb_visits";
        public const string NB_UNIQ_VISITORS = "nb_uniq_visitors";
        public const string NB_HITS = "nb_hits";
        public const string SUM_TIME_SPENT = "sum_time_spent";
        public const string ENTRY_NB_UNIQ_VISITORS = "entry_nb_uniq_visitors";
        public const string ENTRY_NB_VISITS = "entry_nb_visits";
        public const string ENTRY_NB_ACTIONS = "entry_nb_actions";
        public const string ENTRY_SUM_VISIT_LENGTH = "entry_sum_visit_length";
        public const string ENTRY_BOUNCE_COUNT = "entry_bounce_count";
        public const string EXIT_NB_UNIQ_VISITORS = "exit_nb_uniq_visitors";
        public const string EXIT_NB_VISITS = "exit_nb_visits";
        public const string AVG_TIME_ON_PAGE = "avg_time_on_page";
        public const string BOUNCE_RATE = "bounce_rate";
        public const string EXIT_RATE = "exit_rate";
        public const string PAGE_URL = "url";

        private const string PLUGIN = "Actions";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        public Object getPageUrls(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
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
                return this.sendRequest<Hashtable>("getPageUrls", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<ArrayList>("getPageUrls", new List<Parameter>(parameters));
            }
        }

        public Object getPageTitles(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
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
                return this.sendRequest<Hashtable>("getPageTitles", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<ArrayList>("getPageTitles", new List<Parameter>(parameters));
            }
        }
    }
}
