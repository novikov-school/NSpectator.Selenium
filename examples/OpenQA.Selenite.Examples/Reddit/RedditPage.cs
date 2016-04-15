using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Reddit
{
    public class RedditPage : WebBlock
    {
        public RedditPage(Session session) : base(session)
        {
        }

        public IEnumerable<Post> Posts
        {
            get
            {
                return FindElements(By.CssSelector("#siteTable .link"))
                    .Select(tag => new Post(Session, tag));
            }
        }

        public IEnumerable<Post> RankedPosts
        {
            get { return Posts.Where(post => post.Rank != string.Empty); }
        }

        public IClickable<RedditPage> Next => new Clickable<RedditPage>(this, By.PartialLinkText("next"));

        public IClickable<RedditPage> Prev => new Clickable<RedditPage>(this, By.PartialLinkText("prev"));

        public IEnumerable<IClickable<RedditPage>> FeaturedSubreddits
        {
            get
            {
                return FindElements(By.CssSelector("#sr-bar a"))
                    .Where(a => a.Displayed)
                    .Select(a => new Clickable<RedditPage>(this, a));
            }
        }
    }
}