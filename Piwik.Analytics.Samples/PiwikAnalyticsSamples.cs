#region license
// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later
#endregion

using System;
using System.Collections;

using Piwik.Analytics.Date;
using Piwik.Analytics.Modules;

/// <summary>
/// Piwik - Open source web analytics
/// For more information, see http://piwik.org
/// </summary>
namespace Piwik.Analytics.Samples
{
    class PiwikAnalyticsSamples
    {
        static void Main(string[] args)
        {
            try
            {
                PiwikAnalytics.URL = "http://piwik-1.5";

                // ****************************************
                // SITES MANAGER MODULE - Doc/Test methods
                // ****************************************
//                AddMinimalSite();
//                addComplexeSite();
//                AddIncompleteSite();
//                AddUnthorizedSite();
//                DeleteSite();
//                GetSitesIdFromSiteUrl();
//                getSiteFromId();
//                UpdateSite();

                // ****************************************
                // USER SETTINGS MODULE - Doc/Test methods
                // ****************************************
//                GetBrowserMonthYesterday();
//                GetBrowserMonthSpecificDate();
//                GetBrowserMonthLast2();
//                GetBrowserRangeSpecificDates();
//                GetBrowserRangeYear();
//                GetBrowserYear();
//                GetOs();
//                GetMobileOs();

                // ****************************************
                // VISIT FREQUENCY MODULE - Doc/Test methods
                // ****************************************
//                GetVisitFrequencyOnePeriod();
//                GetVisitFrequencyTwoPeriods();


                // ****************************************
                // ACTIONS MODULE - Doc/Test methods
                // ****************************************
//                GetPageUrls();
//                GetPageTitles();

                // ****************************************
                // REFERERS MODULE - Doc/Test methods
                // ****************************************
//                GetWebsites();
//                GetWebsitesExpanded();
//                GetRefererType();
//                GetRefererTypeFiltered();

                // ****************************************
                // SCHEDULED REPORTS MODULE - Doc/Test methods
                // ****************************************
//                AddReport();

            }
            catch (PiwikAPIException ex)
            {
              Console.WriteLine(ex.Message);
            }

            Console.ReadKey(true);
        }

        private static void AddMinimalSite()
        {
            var siteManager = new SitesManager();
            siteManager.setTokenAuth("XYZ");

            string[] urls = { "http://brandNew", "http://shinyNew" };        
              
            var newSiteId = siteManager.addSite("Brand New Site", urls);

            Console.WriteLine("Brand New Site correctly created with id = " + newSiteId);
        }

        private static void addComplexeSite()
        {
            var siteManager = new SitesManager();
            siteManager.setTokenAuth("XYZ");

            string[] urls = { "http://brandNew", "http://shinyNew" };
            string[] excludedIps = { "123.123.13.1", "212.21.11.2" };
            string[] excludedQueryParameters = { "key1", "key2" };

            var newSiteId = siteManager.addSite("Brand New Site", urls, true, excludedIps, excludedQueryParameters, "UTC-4", "USD", "group2", new DateTime(2011, 01, 10));

            Console.WriteLine("Brand New Site correctly created with id = " + newSiteId);
        }

        private static void DeleteSite()
        {
            var siteManager = new SitesManager();
            siteManager.setTokenAuth("XYZ");

            var status = siteManager.deleteSite(23);

            if (status)
            {
                Console.WriteLine("Site removed");
            }
        }

        private static void AddIncompleteSite()
        {
            var siteManager = new SitesManager();

            // Test with invalid required parameters
            siteManager.addSite("", null);
        }

        private static void GetSitesIdFromSiteUrl()
        {
            var siteManager = new SitesManager();
            siteManager.setTokenAuth("XYZ");

            var sites = siteManager.getSitesIdFromSiteUrl("http://brandNew");

            Console.WriteLine(sites.Count + " sites found");

            foreach (Hashtable site in sites)
            {
                Console.WriteLine(site[SitesManager.ID]);
            }
        }


        private static void getSiteFromId()
        {
            var siteManager = new SitesManager();
            siteManager.setTokenAuth("XYZ");

            var sites = siteManager.getSiteFromId(1);

            Console.WriteLine(sites.Count + " sites found");

            foreach (Hashtable site in sites)
            {
                Console.WriteLine(
                    site[SitesManager.ID] + " " +
                    site[SitesManager.NAME] + " " +
                    site[SitesManager.MAIN_URL] + " " +
                    site[SitesManager.TS_CREATED] + " " +
                    site[SitesManager.TIMEZONE] + " " +
                    site[SitesManager.CURRENCY] + " " +
                    site[SitesManager.EXCLUDED_IPS] + " " +
                    site[SitesManager.EXCLUDED_PARAMETERS] + " " +
                    site[SitesManager.FEEDBURNER_NAME] + " " +
                    site[SitesManager.GROUP] + " " +
                    site[SitesManager.ECOMMERCE]
                );
            }
        }

        private static void UpdateSite()
        {
            var siteManager = new SitesManager();
            siteManager.setTokenAuth("XYZ");

            string[] urls = { "http://brandNew", "http://shinyNew" };
            string[] excludedIps = { "123.123.11.1", "212.21.11.2" };
            string[] excludedQueryParameters = { "key1", "key2" };

            var status = siteManager.updateSite(
                5, 
                "Brand New Site", 
                urls, 
                true, 
                excludedIps, 
                excludedQueryParameters, 
                "UTC-4", 
                "USD", 
                "group2", 
                new DateTime(2011, 01, 10)
            );

            if (status)
            {
                Console.WriteLine("Site updated");
            }
        }


        private static void AddUnthorizedSite()
        {
            var siteManager = new SitesManager();

            // Test with valid required parameters but without the token auth
            string[] urls = { "http://brandNew", "http://shinyNew" };
            siteManager.addSite("Brand New Site", urls);
        }


        private static void GetBrowserMonthYesterday()
        {
            var userSettings = new UserSettings();
            userSettings.setTokenAuth("XYZ");
            var results = (ArrayList) userSettings.getBrowser(1, PiwikPeriod.MONTH, MagicDate.YESTERDAY);

            Console.WriteLine(results.Count + " results found");

            // Loop over each browser name (ie. LABEL)
            foreach (Hashtable result in results)
            {
                // Display browser stats
                Console.WriteLine(
                    result[UserSettings.LABEL] + " " +
                    result[UserSettings.NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.NB_VISITS] + " " +
                    result[UserSettings.NB_ACTIONS] + " " +
                    result[UserSettings.MAX_ACTIONS] + " " +
                    result[UserSettings.SUM_VISIT_LENGTH] + " " +
                    result[UserSettings.BOUNCE_COUNT] + " " +
                    result[UserSettings.NB_VISITS_CONVERTED] + " " +
                    result[UserSettings.SUM_DAILY_NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.LOGO] + " " +
                    result[UserSettings.SHORTLABEL]
                );
            }
        }

        private static void GetBrowserMonthSpecificDate()
        {
            var userSettings = new UserSettings();
            userSettings.setTokenAuth("XYZ");
            var results = (ArrayList)userSettings.getBrowser(1, PiwikPeriod.MONTH, new SimpleDate(new DateTime(2011, 09, 18)));

            System.Console.WriteLine(results.Count + " results found");

            // Loop over each browser name (ie. LABEL)
            foreach (Hashtable result in results)
            {
                // Display browser stats
                Console.WriteLine(
                    result[UserSettings.LABEL] + " " +
                    result[UserSettings.NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.NB_VISITS] + " " +
                    result[UserSettings.NB_ACTIONS] + " " +
                    result[UserSettings.MAX_ACTIONS] + " " +
                    result[UserSettings.SUM_VISIT_LENGTH] + " " +
                    result[UserSettings.BOUNCE_COUNT] + " " +
                    result[UserSettings.NB_VISITS_CONVERTED] + " " +
                    result[UserSettings.SUM_DAILY_NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.LOGO] + " " +
                    result[UserSettings.SHORTLABEL]
                );
            }
        }

        private static void GetBrowserMonthLast2()
        {
            var userSettings = new UserSettings();
            userSettings.setTokenAuth("XYZ");
            var results = (Hashtable)userSettings.getBrowser(1, PiwikPeriod.MONTH, RelativeRangeDate.LAST(2));

            Console.WriteLine(results.Count + " results found");

            // The request if for multiple periods
            // Loop over the requested periods
            foreach (String period in results.Keys)
            {
                Console.WriteLine("Data for " + period);

                // Loop over each browser name (ie. LABEL)
                foreach (Hashtable result in (ArrayList)results[period])
                {
                    // Display browser stats
                    Console.WriteLine(
                        result[UserSettings.LABEL] + " " +
                        result[UserSettings.NB_UNIQ_VISITORS] + " " +
                        result[UserSettings.NB_VISITS] + " " +
                        result[UserSettings.NB_ACTIONS] + " " +
                        result[UserSettings.MAX_ACTIONS] + " " +
                        result[UserSettings.SUM_VISIT_LENGTH] + " " +
                        result[UserSettings.BOUNCE_COUNT] + " " +
                        result[UserSettings.NB_VISITS_CONVERTED] + " " +
                        result[UserSettings.SUM_DAILY_NB_UNIQ_VISITORS] + " " +
                        result[UserSettings.LOGO] + " " +
                        result[UserSettings.SHORTLABEL]
                    );
                }
            }
        }

        private static void GetBrowserRangeSpecificDates()
        {
            var userSettings = new UserSettings();
            userSettings.setTokenAuth("XYZ");

            var results = (ArrayList)userSettings.getBrowser(
                1, 
                PiwikPeriod.RANGE, 
                new AbsoluteRangeDate(new DateTime(2011, 09, 10), (new DateTime(2011, 09, 18)))
            );

            Console.WriteLine(results.Count + " results found");

            // Loop over each browser name (ie. LABEL)
            foreach (Hashtable result in results)
            {
                // Display browser stats
                Console.WriteLine(
                    result[UserSettings.LABEL] + " " +
                    result[UserSettings.NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.NB_VISITS] + " " +
                    result[UserSettings.NB_ACTIONS] + " " +
                    result[UserSettings.MAX_ACTIONS] + " " +
                    result[UserSettings.SUM_VISIT_LENGTH] + " " +
                    result[UserSettings.BOUNCE_COUNT] + " " +
                    result[UserSettings.NB_VISITS_CONVERTED] + " " +
                    result[UserSettings.SUM_DAILY_NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.LOGO] + " " +
                    result[UserSettings.SHORTLABEL]
                );
            }
        }

        private static void GetBrowserRangeYear()
        {
            var userSettings = new UserSettings();
            userSettings.setTokenAuth("XYZ");

            var results = (ArrayList)userSettings.getBrowser(
                1,
                PiwikPeriod.RANGE,
                new AbsoluteRangeDate(DateTime.Now.AddDays(-365), DateTime.Now)
            );

            Console.WriteLine(results.Count + " results found");

            // Loop over each browser name (ie. LABEL)
            foreach (Hashtable result in results)
            {
                // Display browser stats
                Console.WriteLine(
                    result[UserSettings.LABEL] + " " +
                    result[UserSettings.NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.NB_VISITS] + " " +
                    result[UserSettings.NB_ACTIONS] + " " +
                    result[UserSettings.MAX_ACTIONS] + " " +
                    result[UserSettings.SUM_VISIT_LENGTH] + " " +
                    result[UserSettings.BOUNCE_COUNT] + " " +
                    result[UserSettings.NB_VISITS_CONVERTED] + " " +
                    result[UserSettings.SUM_DAILY_NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.LOGO] + " " +
                    result[UserSettings.SHORTLABEL]
                );
            }
        }

        private static void GetBrowserYear()
        {
            var userSettings = new UserSettings();
            userSettings.setTokenAuth("XYZ");

            var results = (ArrayList)userSettings.getBrowser(
                1,
                PiwikPeriod.YEAR,
                MagicDate.TODAY
            );

            Console.WriteLine(results.Count + " results found");

            // Loop over each browser name (ie. LABEL)
            foreach (Hashtable result in results)
            {
                // Display browser stats
                Console.WriteLine(
                    result[UserSettings.LABEL] + " " +
                    result[UserSettings.NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.NB_VISITS] + " " +
                    result[UserSettings.NB_ACTIONS] + " " +
                    result[UserSettings.MAX_ACTIONS] + " " +
                    result[UserSettings.SUM_VISIT_LENGTH] + " " +
                    result[UserSettings.BOUNCE_COUNT] + " " +
                    result[UserSettings.NB_VISITS_CONVERTED] + " " +
                    result[UserSettings.SUM_DAILY_NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.LOGO] + " " +
                    result[UserSettings.SHORTLABEL]
                );
            }
        }

        private static void GetOs()
        {
            var userSettings = new UserSettings();
            //userSettings.setTokenAuth("XYZ");

            var results = (ArrayList)userSettings.getOS(
                7,
                PiwikPeriod.YEAR,
                MagicDate.TODAY
            );

            Console.WriteLine(results.Count + " results found");

            // Loop over each OS name (ie. LABEL)
            foreach (Hashtable result in results)
            {
                // Display OS stats
                Console.WriteLine(
                    result[UserSettings.LABEL] + " " +
                    result[UserSettings.NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.NB_VISITS] + " " +
                    result[UserSettings.NB_ACTIONS] + " " +
                    result[UserSettings.MAX_ACTIONS] + " " +
                    result[UserSettings.SUM_VISIT_LENGTH] + " " +
                    result[UserSettings.BOUNCE_COUNT] + " " +
                    result[UserSettings.NB_VISITS_CONVERTED] + " " +
                    result[UserSettings.SUM_DAILY_NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.LOGO] + " " +
                    result[UserSettings.SHORTLABEL]
                );
            }
        }

        private static void GetMobileOs()
        {
            var userSettings = new UserSettings();
            //userSettings.setTokenAuth("XYZ");

            var results = (ArrayList)userSettings.getMobileOS(
                7,
                PiwikPeriod.YEAR,
                MagicDate.TODAY
            );

            Console.WriteLine(results.Count + " results found");

            // Loop over each mobile OS name (ie. LABEL)
            foreach (Hashtable result in results)
            {
                // Display OS stats
                Console.WriteLine(
                    result[UserSettings.LABEL] + " " +
                    result[UserSettings.NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.NB_VISITS] + " " +
                    result[UserSettings.NB_ACTIONS] + " " +
                    result[UserSettings.MAX_ACTIONS] + " " +
                    result[UserSettings.SUM_VISIT_LENGTH] + " " +
                    result[UserSettings.BOUNCE_COUNT] + " " +
                    result[UserSettings.NB_VISITS_CONVERTED] + " " +
                    result[UserSettings.SUM_DAILY_NB_UNIQ_VISITORS] + " " +
                    result[UserSettings.LOGO] + " " +
                    result[UserSettings.SHORTLABEL]
                );
            }
        }

        private static void GetVisitFrequencyOnePeriod()
        {
            var visitFrequency = new VisitFrequency();
            visitFrequency.setTokenAuth("XYZ");

            var result = visitFrequency.get(
                1,
                PiwikPeriod.RANGE,
                new AbsoluteRangeDate(new DateTime(2011, 09, 10), (new DateTime(2011, 09, 18)))
            );

            // Display visit frequency metrics for the requested period
            Console.WriteLine(
                result[VisitFrequency.NB_UNIQ_VISITORS_RETURNING] + " " +
                result[VisitFrequency.NB_VISITS_RETURNING] + " " +
                result[VisitFrequency.NB_ACTIONS_RETURNING] + " " +
                result[VisitFrequency.MAX_ACTIONS_RETURNING] + " " +
                result[VisitFrequency.SUM_VISIT_LENGTH_RETURNING] + " " +
                result[VisitFrequency.BOUNCE_COUNT_RETURNING] + " " +
                result[VisitFrequency.NB_VISITS_CONVERTED_RETURNING] + " " +
                result[VisitFrequency.BOUNCE_RATE_RETURNING] + " " +
                result[VisitFrequency.NB_ACTIONS_PER_VISIT_RETURNING] + " " +
                result[VisitFrequency.AVG_TIME_ON_SITE_RETURNING]
            );
        }

        private static void GetVisitFrequencyTwoPeriods()
        {
            var visitFrequency = new VisitFrequency();
            visitFrequency.setTokenAuth("XYZ");

            var results = visitFrequency.get(
                1,
                PiwikPeriod.MONTH,
                RelativeRangeDate.LAST(2)
            );

            Console.WriteLine(results.Count + " results found");

            // The request if for multiple periods
            // Loop over the requested periods
            foreach (String period in results.Keys)
            {
                Console.WriteLine("Data for " + period);

                var result = (Hashtable)results[period];

                // Display visit frequency metrics for the current period
                Console.WriteLine(
                    result[VisitFrequency.NB_VISITS_RETURNING] + " " +
                    result[VisitFrequency.NB_ACTIONS_RETURNING] + " " +
                    result[VisitFrequency.MAX_ACTIONS_RETURNING] + " " +
                    result[VisitFrequency.SUM_VISIT_LENGTH_RETURNING] + " " +
                    result[VisitFrequency.BOUNCE_COUNT_RETURNING] + " " +
                    result[VisitFrequency.BOUNCE_RATE_RETURNING] + " " +
                    result[VisitFrequency.NB_ACTIONS_PER_VISIT_RETURNING] + " " +
                    result[VisitFrequency.AVG_TIME_ON_SITE_RETURNING]
                );
            }
        }

        private static void GetPageUrls()
        {
            var actions = new Actions();
            actions.setTokenAuth("XYZ");

            var results = (ArrayList)actions.getPageUrls(
                1,
                PiwikPeriod.RANGE,
                new AbsoluteRangeDate(new DateTime(2011, 09, 10), (new DateTime(2011, 09, 18)))
            );

            Console.WriteLine(results.Count + " results found");

            foreach (Hashtable result in results)
            {
                Console.WriteLine(
                    result[Actions.LABEL] + " " +
                    result[Actions.NB_VISITS] + " " +
                    result[Actions.NB_UNIQ_VISITORS] + " " +
                    result[Actions.NB_HITS] + " " +
                    result[Actions.SUM_TIME_SPENT] + " " +
                    result[Actions.ENTRY_NB_UNIQ_VISITORS] + " " +
                    result[Actions.ENTRY_NB_VISITS] + " " +
                    result[Actions.ENTRY_NB_ACTIONS] + " " +
                    result[Actions.ENTRY_SUM_VISIT_LENGTH] + " " +
                    result[Actions.ENTRY_BOUNCE_COUNT] + " " +
                    result[Actions.EXIT_NB_UNIQ_VISITORS] + " " +
                    result[Actions.EXIT_NB_VISITS] + " " +
                    result[Actions.AVG_TIME_ON_PAGE] + " " +
                    result[Actions.BOUNCE_RATE] + " " +
                    result[Actions.EXIT_RATE] + " " +
                    result[Actions.PAGE_URL]
                );
            }
        }

        private static void GetPageTitles()
        {
            var actions = new Actions();
            actions.setTokenAuth("XYZ");

            var results = (ArrayList)actions.getPageTitles(
                1,
                PiwikPeriod.RANGE,
                new AbsoluteRangeDate(new DateTime(2011, 11, 14), (new DateTime(2011, 11, 15)))
            );

            Console.WriteLine(results.Count + " results found");

            foreach (Hashtable result in results)
            {
                Console.WriteLine(
                    result[Actions.LABEL] + " " +
                    result[Actions.NB_VISITS] + " " +
                    result[Actions.NB_UNIQ_VISITORS] + " " +
                    result[Actions.NB_HITS] + " " +
                    result[Actions.SUM_TIME_SPENT] + " " +
                    result[Actions.ENTRY_NB_UNIQ_VISITORS] + " " +
                    result[Actions.ENTRY_NB_VISITS] + " " +
                    result[Actions.ENTRY_NB_ACTIONS] + " " +
                    result[Actions.ENTRY_SUM_VISIT_LENGTH] + " " +
                    result[Actions.ENTRY_BOUNCE_COUNT] + " " +
                    result[Actions.EXIT_NB_UNIQ_VISITORS] + " " +
                    result[Actions.EXIT_NB_VISITS] + " " +
                    result[Actions.AVG_TIME_ON_PAGE] + " " +
                    result[Actions.BOUNCE_RATE] + " " +
                    result[Actions.EXIT_RATE]
                );
            }
        }

        private static void GetWebsites()
        {
            var referers = new Referers();
            referers.setTokenAuth("XYZ");
            var results = (ArrayList)referers.getWebsites(1, PiwikPeriod.MONTH, MagicDate.YESTERDAY);

            Console.WriteLine(results.Count + " results found");

            // Loop over referers (ie. LABEL) who led visitors to your website
            foreach (Hashtable result in results)
            {
                Console.WriteLine(
                    result[Referers.LABEL] + " " +
                    result[Referers.NB_UNIQ_VISITORS] + " " +
                    result[Referers.NB_VISITS] + " " +
                    result[Referers.NB_ACTIONS] + " " +
                    result[Referers.MAX_ACTIONS] + " " +
                    result[Referers.SUM_VISIT_LENGTH] + " " +
                    result[Referers.BOUNCE_COUNT] + " " +
                    result[Referers.NB_CONVERSIONS] + " " +
                    result[Referers.REVENUE] + " " +
                    result[Referers.IDSUBDATATABLE]
                );
            }
        }


        private static void GetWebsitesExpanded()
        {
            var referers = new Referers();
            referers.setTokenAuth("XYZ");
            var results = (ArrayList)referers.getWebsites(1, PiwikPeriod.MONTH, MagicDate.YESTERDAY, String.Empty, true);

            Console.WriteLine(results.Count + " results found");

            // Loop over referers (ie. LABEL) who led visitors to your website
            foreach (Hashtable result in results)
            {
                Console.WriteLine(
                    result[Referers.LABEL] + " " +
                    result[Referers.NB_UNIQ_VISITORS] + " " +
                    result[Referers.NB_VISITS] + " " +
                    result[Referers.NB_ACTIONS] + " " +
                    result[Referers.MAX_ACTIONS] + " " +
                    result[Referers.SUM_VISIT_LENGTH] + " " +
                    result[Referers.BOUNCE_COUNT] + " " +
                    result[Referers.NB_CONVERSIONS] + " " +
                    result[Referers.REVENUE] + " " +
                    result[Referers.IDSUBDATATABLE]
                );

                // Loop over pages of referers who led visitors to your website
                if(result.ContainsKey(Referers.SUBTABLE))
                {
                    foreach (Hashtable subtable in (ArrayList)result[Referers.SUBTABLE])
                    {
                        Console.WriteLine(
                            subtable[Referers.LABEL] + " " +
                            subtable[Referers.NB_UNIQ_VISITORS] + " " +
                            subtable[Referers.NB_VISITS] + " " +
                            subtable[Referers.NB_ACTIONS] + " " +
                            subtable[Referers.MAX_ACTIONS] + " " +
                            subtable[Referers.SUM_VISIT_LENGTH] + " " +
                            subtable[Referers.BOUNCE_COUNT] + " " +
                            subtable[Referers.NB_VISITS_CONVERTED]
                        );
                    }
                }
            }
        }

        private static void GetRefererType()
        {
            var referers = new Referers();
            referers.setTokenAuth("XYZ");
            var results = (ArrayList)referers.getRefererType(1, PiwikPeriod.MONTH, MagicDate.YESTERDAY);

            Console.WriteLine(results.Count + " results found");

            // Loop over referer types (ie. LABEL) who led visitors to your website
            foreach (Hashtable result in results)
            {
                Console.WriteLine(
                    result[Referers.LABEL] + " " +
                    result[Referers.NB_UNIQ_VISITORS] + " " +
                    result[Referers.NB_VISITS] + " " +
                    result[Referers.NB_ACTIONS] + " " +
                    result[Referers.MAX_ACTIONS] + " " +
                    result[Referers.SUM_VISIT_LENGTH] + " " +
                    result[Referers.BOUNCE_COUNT] + " " +
                    result[Referers.NB_CONVERSIONS] + " " +
                    result[Referers.REVENUE]
                );
            }
        }

        private static void GetRefererTypeFiltered()
        {
            var referers = new Referers();
            referers.setTokenAuth("XYZ");
            var results = (ArrayList)referers.getRefererType(1, PiwikPeriod.MONTH, MagicDate.YESTERDAY, String.Empty, RefererType.SEARCH_ENGINE);

            var specificRefererTypeStats = (Hashtable) results[0];
                
            Console.WriteLine(
                specificRefererTypeStats[Referers.LABEL] + " " +
                specificRefererTypeStats[Referers.NB_UNIQ_VISITORS] + " " +
                specificRefererTypeStats[Referers.NB_VISITS] + " " +
                specificRefererTypeStats[Referers.NB_ACTIONS] + " " +
                specificRefererTypeStats[Referers.MAX_ACTIONS] + " " +
                specificRefererTypeStats[Referers.SUM_VISIT_LENGTH] + " " +
                specificRefererTypeStats[Referers.BOUNCE_COUNT] + " " +
                specificRefererTypeStats[Referers.NB_CONVERSIONS] + " " +
                specificRefererTypeStats[Referers.REVENUE]
            );
        }

        private static int AddReport()
        {
            ScheduledReports scheduledReports = new ScheduledReports();
            scheduledReports.setTokenAuth("XYZ");

            System.Collections.Generic.List<ScheduledReports.Statistic> reports = new System.Collections.Generic.List<ScheduledReports.Statistic>();

            reports.Add(ScheduledReports.Statistic.VisitsSummary_get);
            reports.Add(ScheduledReports.Statistic.VisitTime_getByDayOfWeek);
            reports.Add(ScheduledReports.Statistic.VisitTime_getVisitInformationPerLocalTime);
            reports.Add(ScheduledReports.Statistic.Resolution_getResolution);
            reports.Add(ScheduledReports.Statistic.UserLanguage_getLanguage);
            reports.Add(ScheduledReports.Statistic.Actions_get);
            reports.Add(ScheduledReports.Statistic.Actions_getDownloads);
            reports.Add(ScheduledReports.Statistic.Actions_getEntryPageTitles);
            reports.Add(ScheduledReports.Statistic.Actions_getPageUrls);
            reports.Add(ScheduledReports.Statistic.Actions_getSiteSearchKeywords);
            reports.Add(ScheduledReports.Statistic.Actions_getPageTitles);
            reports.Add(ScheduledReports.Statistic.Referrers_getAll);
            reports.Add(ScheduledReports.Statistic.Goals_get);
            reports.Add(ScheduledReports.Statistic.VisitorInterest_getNumberOfVisitsPerPage);
            reports.Add(ScheduledReports.Statistic.DevicesDetection_getBrowsers);

            string[] recipients = 
            {
                "foobar@domain.tld",
                "barfoo@domain.tld"
            };

            return scheduledReports.addReport(1, "My new report", PiwikPeriod.DAY, 9, ScheduledReports.ReportType.email, ScheduledReports.ReportFormat.pdf, reports, false, recipients);
        }
    }
}
