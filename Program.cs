﻿#region imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Tweetinvi;
using Tweetinvi.Parameters;
using Tweetinvi.Models;
#endregion

namespace TwitterBot
{
    #region Notes and Todos
    /*

        Notes:
            CoOBot maintained by @HBnotHP    
            CoOBot run by @<name>

    */
    #endregion
    class Program
    {
        static string[] tweets =
            {
                "Ui:\nSis, come on!\n You'd better get out of bed! \n Sis?!"
                "Yui:\nAh, it's eight!\nI'm late!"
            };
        static int count = 0;
        static System.Threading.Thread t_checkTime = new System.Threading.Thread(new System.Threading.ThreadStart(checkTime));
        static void Main(string[] args)
        {
            try
            {
                //Don't change the credentials, they are correct. If they aren't, tell me and I'll generate new ones.
                Auth.SetUserCredentials("", "", "", "");
                t_checkTime.Start();
                //This is just to make sure the connection went through and the thread started.
                Console.Write("done\n");
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message+"\nPress enter to continue...");
                Console.Read();
            }
        }
        ///<summary>
        ///Check the time and post tweet if time is correct
        ///<para>Currently does 5 tweets a day at 8,12,16,20 and 24 oclock</para>
        ///<para>Tweets includes a random image file specified in 
        ///<seealso cref="Main(string[])"/></para>
        ///</summary>
        static void checkTime()
        {
            try
            {
                while (true)
                {
                    #region TweetCode 
                    if (DateTime.Now.Hour == 8 && DateTime.Now.Minute == 0 || DateTime.Now.Hour == 12 && DateTime.Now.Minute == 0 || DateTime.Now.Hour == 16 && DateTime.Now.Minute == 0 || DateTime.Now.Hour == 20 && DateTime.Now.Minute == 0 || DateTime.Now.Hour == 24 && DateTime.Now.Minute == 0)
                    {
                        Tweet.PublishTweet(tweets[count]);
                        count++;
                    }
                    System.Threading.Thread.Sleep(45000); //Don't max out CPU pls.
                    //Every 45 seconds check. Since we check the minutes, we need to run a check under 60 seconds
                    #endregion
                }
            }
            catch(Exception ex)
            {
                Console.Write("\n\n"+ex.Message+"\n\n");
                Console.Read();
            }
        }
    }
}
