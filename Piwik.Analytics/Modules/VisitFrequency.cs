#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

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
    /// Service Gateway for Piwik VisitFrequency Module API
    /// For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// 
    /// <remarks>
    /// This Analytics API is tested against Piwik 1.5
    /// </remarks> 
    public class VisitFrequency : PiwikAnalytics 
    {
        public const string NB_UNIQ_VISITORS_RETURNING = "nb_uniq_visitors_returning";
        public const string NB_VISITS_RETURNING = "nb_visits_returning";
        public const string NB_ACTIONS_RETURNING = "nb_actions_returning";
        public const string MAX_ACTIONS_RETURNING = "max_actions_returning";
        public const string SUM_VISIT_LENGTH_RETURNING = "sum_visit_length_returning";
        public const string BOUNCE_COUNT_RETURNING = "bounce_count_returning";
        public const string NB_VISITS_CONVERTED_RETURNING = "nb_visits_converted_returning";
        public const string BOUNCE_RATE_RETURNING = "bounce_rate_returning";
        public const string NB_ACTIONS_PER_VISIT_RETURNING = "nb_actions_per_visit_returning";
        public const string AVG_TIME_ON_SITE_RETURNING = "avg_time_on_site_returning";

        private const string PLUGIN = "VisitFrequency";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        public Hashtable get(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter("period", period),
                new PiwikDateParameter("date", date),
                new SimpleParameter("segment", segment),
            };

            return this.sendRequest<Hashtable>("get", new List<Parameter>(parameters));
        }

    }
}
