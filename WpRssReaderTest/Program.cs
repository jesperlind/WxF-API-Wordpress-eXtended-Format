using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wxf;
using WxfLib;

namespace WpRssReaderTest
{
    class Program
    {
        static private readonly string RssPath = AppDomain.CurrentDomain.BaseDirectory + "../../example.wp.3.2.1.xml";
        static private readonly string RssPathOut = AppDomain.CurrentDomain.BaseDirectory + "../../example.wp.3.2.1.export.xml";

        static void Main(string[] args)
        {
            Console.WriteLine("Path: " + RssPath);

            var blog = WxfReader.Parse(RssPath);

            //DownloadFeed();

            //AddCreatorTest(RssPathOut, RssPath);

            AddPostsTest(blog);
            blog.SaveXml(RssPathOut);

            //var rss = blog.ToRssFeed();
        }

        private static void AddPostsTest(WxfFeed blog)
        {

            WxfChannel channel = blog.Channels[0];

            try 
            {
                var image = channel.Image.Image;
            }
            catch(Exception e)
            {
                Console.WriteLine("Image problem: " + e.Message);
            }


            foreach (var i in channel.Items)
            {
                Console.WriteLine("Title: {0} \nPublishing Date: {1} \nCreator: {2} \nLink: {3}\n", i.Title, i.PublishingDate, i.Creator, i.Link);
            }

            var item = new WxfItem
            {
                Title = "Wordpress Test for namespaces2",
                Content = "Hello, World!",
                PostType = "post",
                Status = "publish"
            };
            channel.Items.Add(item);

            //var result = from i in channel.Items
            //             where !i.Title.Contains("Finding Prime")
            //             select i;

            //foreach (var i in result)
            //{
            //    Console.WriteLine("Title: {0} \nPublishing Date: {1} \nCreator: {2} \nLink: {3}\n", i.Title, i.PublishingDate, i.Creator, i.Link);

            //    foreach (var c in i.Comments)
            //    {
            //        Console.WriteLine("\nSender: {0} \nDate: {1} \nContent: {2}", c.Author, c.Date, c.Content);
            //    }
            //}

            //foreach (var i in result.ToList())
            //{
            //    i.Detach();
            //    //Console.WriteLine("Title: {0} \nPublishing Date: {1} \nCreator: {2} \nLink: {3} \nComments: {4}\n", i.Title, i.PublishingDate, i.Creator, i.Link, i.Comments.Count);
            //    Console.WriteLine("Items {0}", channel.Items.Count);
            //}

            //blog.SaveXml("example.xml");
        }

        private static void AddCreatorTest(string rssPathOut, string rssPath)
        {
//Test case Creator
            var blog = WxfReader.Parse(rssPath);

            WxfChannel channel2 = blog.Channels[0];

            var item2 = new WxfItem
                            {
                                Title = "Test",
                                Content = "The body",
                                PublishingDate = DateTime.Now,
                                PostDate = DateTime.Now,
                                Creator = "Creator name",
                                //Throws exception
                            };

            channel2.Items.Add(item2);

            blog.SaveXml(rssPathOut);
        }

        private static void DownloadFeed()
        {
            RssFeed feed = new RssFeed()
                               {
                                   Version = "2.0"
                               };

            var channel = new RssChannel()
                              {
                                  Title = "Rss Test Feed",
                                  Generator = "WxFLib",
                                  WebMaster = "Robertuzzu",
                                  Description = "Created by Robert Sundström",
                                  Link = new Uri("http://robertsundstrom.wordpress.com"),
                                  Language = "en",
                                  PublishingDate = DateTime.Now,
                                  LastBuildDate = DateTime.Now,
                                  ManagingEditor = "C#"
                              };
            feed.Channels.Add(channel);

            for (int i = 0; i < 10; i++)
            {
                var item = new RssItem()
                               {
                                   Title = string.Format("Item {0}", i),
                                   Description = "",
                                   Link = new Uri(string.Format("http://robertuzzu/posts/{0}/", i)),
                                   PublishingDate = DateTime.Now
                               };
                channel.Items.Add(item);
            }

            feed.SaveXml("rss.xml");
        }
    }
}
