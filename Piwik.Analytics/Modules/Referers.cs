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
    /// Service Gateway for Piwik Referers Module API
    /// For more information, see http://piwik.org/docs/analytics-api/reference
    /// </summary>
    /// 
    /// <remarks>
    /// This Analytics API is tested against Piwik 1.5
    /// </remarks> 
    public class Referers : PiwikAnalytics 
    {

        public const string LABEL = "label";
        public const string NB_UNIQ_VISITORS = "nb_uniq_visitors";
        public const string NB_VISITS = "nb_visits";
        public const string NB_ACTIONS = "nb_actions";
        public const string MAX_ACTIONS = "max_actions";
        public const string SUM_VISIT_LENGTH = "sum_visit_length";
        public const string BOUNCE_COUNT = "bounce_count";
        public const string NB_VISITS_CONVERTED = "nb_visits_converted";
        public const string IDSUBDATATABLE = "idsubdatatable";     
        public const string NB_CONVERSIONS = "nb_conversions";
        public const string REVENUE = "revenue";
        public const string SUBTABLE = "subtable";

        private const string PLUGIN = "Referers";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        public Object getWebsites(int idSite, PiwikPeriod period, PiwikDate date, string segment = null, Boolean expanded = false)
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter("period", period),
                new PiwikDateParameter("date", date),
                new SimpleParameter("segment", segment),
                new SimpleParameter("expanded", expanded),
            };

            if (PiwikPeriod.isMultipleDates(period, date))
            {
                return this.sendRequest<Hashtable>("getWebsites", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<ArrayList>("getWebsites", new List<Parameter>(parameters));
            }
        }

        public Object getRefererType(int idSite, PiwikPeriod period, PiwikDate date, string segment = null, RefererType refererType = null)
        {
            Parameter[] parameters = 
            {
                new SimpleParameter("idSite", idSite),
                new PeriodParameter("period", period),
                new PiwikDateParameter("date", date),
                new SimpleParameter("segment", segment),
                new RefererTypeParameter("typeReferer", refererType),
            };

            if (PiwikPeriod.isMultipleDates(period, date))
            {
                return this.sendRequest<Hashtable>("getRefererType", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<ArrayList>("getRefererType", new List<Parameter>(parameters));
            }
        }

    }
}
