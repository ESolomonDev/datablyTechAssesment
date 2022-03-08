using System;

namespace CodingTest.TestQuestions.Question2
{
    public class MatchingAlgorithm
    {
        /// <summary>
        /// A Customer is looking to match their contact list to their users.  We have a list of contacts and a listing of their
        /// active directory logins for each computer.  Unfortunately, over the years, they have had different models of how they create
        /// their active directory logins, and so our algorithm should be able to determine whether a username matches based on a few different
        /// patterns
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="activeDirectoryLogin"></param>
        /// <returns></returns>
        public bool IsMatch(string FirstName, string LastName, string activeDirectoryLogin)
        {
            //empty string for comparision
            var adusername = "";

            //first username pattern to check first initial concat last name
            var username1 = FirstName.ToLower().Substring(0, 1) + LastName.ToLower();
            
            //second username pattern to check firstname.lastname format
            var username2 = FirstName.ToLower() + "." + LastName.ToLower();

            //if directory login is in a format containing \\
            if (activeDirectoryLogin.Contains("\\"))
            {   //split using \\ as a diliminator and refrence 2nd index
                adusername = activeDirectoryLogin.ToLower().Split('\\')[1];
            }
            else
            {
                adusername = activeDirectoryLogin.ToLower();
            }

            if (username1 == adusername)
            {
                return true;
            }
            else if (username2 == adusername)
            {
                return true;
            }
            //case 3 users from personal machines returns true for first letter of first name and ends with last name
            else if (adusername.StartsWith(username1.Substring(0, 1)) && adusername.EndsWith(LastName.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
