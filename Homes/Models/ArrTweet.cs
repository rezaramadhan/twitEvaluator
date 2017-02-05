using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToTwitter;

namespace Homes.Models
{
    public class ArrTweet {
        public Tweet[] T;
        public int length;

        static SingleUserAuthorizer authorizer =
            new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = "xbWwhqM1iarSs6LuhADN4ichg",
                    ConsumerSecret = "HrgL2N9rqQ7DDG7wugCups3dQWkZbcNtJOOQHCKab2FnOmZraH",
                    AccessToken = "3833145554-X2VtS7Zh5cd5JMznoI3NOnS44KTZvmXPfopNxE1",
                    AccessTokenSecret = "e4YuRsBIM9JZzIZ8eSiDPJQbSobKmgq8oAFwLRC20651G"
                }
            };

        static List<Status> SearchTwitter(string searchTerm, int nCount)
        {
            var twitterContext = new TwitterContext(authorizer);

            var srch =
               Enumerable.SingleOrDefault((from search in
                                               twitterContext.Search
                                           where search.Type == SearchType.Search &&
                                              search.Query == searchTerm &&
                                              search.Count == nCount
                                           select search));
            if (srch != null && srch.Statuses.Count > 0)
            {
                return srch.Statuses.ToList();
            }

            return new List<Status>();
        }

        /* *
        * Buat array of tweet, dengan isi tweet sejumlah searchamount dan tweet adalah hasil search.
        * */
        public ArrTweet(String searchQuery, int searchAmount)
        {
            T = new Tweet[searchAmount];
            List<Status> tweets = SearchTwitter(searchQuery, searchAmount);
            int i = 0;
            foreach (Status tweet in tweets)
            {
                T[i] = new Tweet(tweet.Text, tweet.User.ScreenNameResponse, tweet.User.Name, tweet.User.ProfileImageUrl, tweet.StatusID);
                i++;
            }
            length = i;
        }

        public void AnalizeTweet(Category c, int n)
        {
            for (int i = 0; i < length; i++)
            {
                T[i].CategorizeTweet(c, n);
                T[i].makebold();
            }
        }

        public void cariAllTempat()
        {
            for (int i = 0; i < T.Length; i++)
            {
                T[i].caritempat();
            }
        }

        public override string ToString()
        {
            string tmp = "";
            for (int i = 0; i < length; i++)
            {
                tmp = i + ". " + T[i].ToString() + tmp;
                tmp = tmp + " \n\n";
            }
            return tmp;
        }
    }
}