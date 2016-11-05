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
    /// Service Gateway for Piwik UsersManager Module API
    /// For more information, see http://developer.piwik.org/api-reference/reporting-api#SitesManager
    /// </summary>
    /// 
    /// <remarks>
    /// This Analytics API is tested against Piwik 2.16.5
    /// </remarks> 
    public class UsersManager : PiwikAnalytics
    {
        private const string PLUGIN = "UsersManager";

        public enum UserAccess
        {
            noaccess,
            view,
            admin
        }

        protected override string getPlugin()
        {
            return PLUGIN;
        }

        /// <summary>
        /// Set a piwik user preference
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="preferenceName"></param>
        /// <param name="preferenceValue"></param>
        /// <returns>Hashtable containing the result message</returns>
        public Hashtable setUserPreference(
            string userLogin,
            string preferenceName,
            object preferenceValue)
        {

            SimpleParameter valueParameter = null;
            Type pType = preferenceValue.GetType();
            switch (pType.Name)
            {
                case "String":
                    valueParameter = new SimpleParameter("preferenceValue", (string)preferenceValue);
                    break;
                case "Int32":
                    valueParameter = new SimpleParameter("preferenceValue", (int)preferenceValue);
                    break;
                default:
                    throw new Exception("preferenceValue must be int or string");
            }

            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("preferenceName", preferenceName),
                valueParameter
            };

            return this.sendRequest<Hashtable>("setUserPreference", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get a piwik user preference
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="preferenceName"></param>
        /// <returns>Hashtable containing the user preference</returns>
        public object getUserPreference(
            string userLogin,
            string preferenceName)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("preferenceName", preferenceName)
            };

            return this.sendRequest<object>("getUserPreference", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get all piwik users with the given list of logins
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns>ArrayList containing Hashtables of users objects</returns>
        public ArrayList getUsers(
            string[] userLogins = null)
        {
            List<Parameter> parameters = new List<Parameter>();
            if (userLogins != null)
                parameters.Add(new SimpleParameter("userLogins", String.Join(",", userLogins)));

            return this.sendRequest<ArrayList>("getUsers", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get user logins of all registered piwik users
        /// </summary>
        /// <returns>ArrayList containing user logins</returns>
        public ArrayList getUsersLogin()
        {
            return this.sendRequest<ArrayList>("getUsersLogin", new List<Parameter>());
        }

        /// <summary>
        /// Get all piwik users and their sites where they have the given access level
        /// </summary>
        /// <param name="access"></param>
        /// <returns>Hashtables of users containing ArrayList of site ids</returns>
        public Hashtable getUsersSitesFromAccess(
            UserAccess access)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("access", access.ToString())
            };

            return this.sendRequest<Hashtable>("getUsersSitesFromAccess", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get all piwik users and their access level for the piwik site with the given id
        /// </summary>
        /// <param name="idSite"></param>
        /// <returns>ArrayList of Hashtables containing user logins and their access level</returns>
        public ArrayList getUsersAccessFromSite(
            int idSite)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite)
            };

            return this.sendRequest<ArrayList>("getUsersAccessFromSite", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get all piwik users which have the given access to the piwik site with the given id
        /// </summary>
        /// <param name="idSite"></param>
        /// <param name="access"></param>
        /// <returns>ArrayList of user objects</returns>
        public ArrayList getUsersWithSiteAccess(
            int idSite,
            UserAccess access)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("idSite", idSite),
                new SimpleParameter("access", access.ToString())
            };

            return this.sendRequest<ArrayList>("getUsersWithSiteAccess ", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get all sites and the specific access level (view or admin) where the given user has access to
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>ArrayList of Hashtables containing idSite and access</returns>
        public ArrayList getSitesAccessFromUser(
            string userLogin)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin)
            };

            return this.sendRequest<ArrayList>("getSitesAccessFromUser  ", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get a piwik user by login
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>ArrayList containing Hashtables of users objects</returns>
        public ArrayList getUser(
            string userLogin)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin)
            };

            return this.sendRequest<ArrayList>("getUser", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get a piwik user by email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>ArrayList containing Hashtables of users objects</returns>
        public ArrayList getUserByEmail(
            string userEmail)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userEmail", userEmail)
            };

            return this.sendRequest<ArrayList>("getUserByEmail", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Add a piwik user
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="alias"></param>
        /// <returns>Hashtable containing the result message</returns>
        public Hashtable addUser(
            string userLogin,
            string password,
            string email,
            string alias = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("password", password),
                new SimpleParameter("email", email),
                new SimpleParameter("alias", alias)
            };

            return this.sendRequest<Hashtable>("addUser", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Define if a piwik user with the given login has super user access
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="hasSuperUserAccess"></param>
        /// <returns>ArrayList containing Hashtables of users objects</returns>
        public Hashtable setSuperUserAccess(
            string userLogin,
            bool hasSuperUserAccess)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("hasSuperUserAccess", hasSuperUserAccess)
            };

            return this.sendRequest<Hashtable>("setSuperUserAccess", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Check if the current piwik user has super user access
        /// </summary>
        /// <returns>True if the current user has super user access</returns>
        public bool hasSuperUserAccess()
        {
            return this.sendRequest<bool>("hasSuperUserAccess", new List<Parameter>());
        }

        /// <summary>
        /// Get all piwik users which have super user access
        /// </summary>
        /// <returns>ArrayList containing Hashtables of users objects</returns>
        public ArrayList getUsersHavingSuperUserAccess()
        {
            return this.sendRequest<ArrayList>("getUsersHavingSuperUserAccess", new List<Parameter>());
        }

        /// <summary>
        /// Update a piwik user
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="alias"></param>
        /// <returns>Hashtable containing the result message</returns>
        public Hashtable updateUser(
            string userLogin,
            string password = null,
            string email = null,
            string alias = null)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("password", password),
                new SimpleParameter("email", email),
                new SimpleParameter("alias", alias)
            };

            return this.sendRequest<Hashtable>("updateUser", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Delete a piwik user
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>Hashtable containing the result message</returns>
        public Hashtable deleteUser(
            string userLogin)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin)
            };

            return this.sendRequest<Hashtable>("deleteUser", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Check if a piwik user with given login exists
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public bool userExists(
            string userLogin)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin)
            };

            return this.sendRequest<bool>("userExists", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Check if a piwik user with given email exists
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool userEmailExists(
            string userEmail)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userEmail", userEmail)
            };

            return this.sendRequest<bool>("userEmailExists", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Get the login for a piwik user with a given email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public string getUserLoginFromUserEmail(
            string userEmail)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userEmail", userEmail)
            };

            return this.sendRequest<string>("getUserLoginFromUserEmail", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Set the access of a piwik user on a list of site ids
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="access"></param>
        /// <param name="idSites"></param>
        /// <returns>Hashtable containing the result message</returns>
        public Hashtable setUserAccess(
            string userLogin,
            UserAccess access,
            int[] idSites)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("access", access.ToString()),
                new SimpleParameter("idSites", String.Join(",", idSites))
            };

            return this.sendRequest<Hashtable>("setUserAccess", new List<Parameter>(parameters));
        }

        /// <summary>
        /// Calculates the token auth by using a user login and a md5 hashed password
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="md5Password"></param>
        /// <returns>A calculated token auth string</returns>
        public string getTokenAuth(
            string userLogin,
            string md5Password)
        {
            Parameter[] parameters =
            {
                new SimpleParameter("userLogin", userLogin),
                new SimpleParameter("md5Password", md5Password)
            };

            return this.sendRequest<string>("getTokenAuth", new List<Parameter>(parameters));
        }
    }
}
