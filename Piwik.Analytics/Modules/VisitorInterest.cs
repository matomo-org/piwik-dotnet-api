using System;
using System.Collections;
using System.Collections.Generic;
using Piwik.Analytics.Date;
using Piwik.Analytics.Parameters;

namespace Piwik.Analytics.Modules
{
    public class VisitorInterest : PiwikAnalytics
    {
        private const string PLUGIN = "VisitorInterest";

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        public Object GetNumberOfVisitsPerPage(int idSite, PiwikPeriod period, PiwikDate date, string segment = null)
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
                return this.sendRequest<Hashtable>("getNumberOfVisitsPerPage", new List<Parameter>(parameters));
            }
            else
            {
                return this.sendRequest<ArrayList>("getNumberOfVisitsPerPage", new List<Parameter>(parameters));
            }
        }
    }
}