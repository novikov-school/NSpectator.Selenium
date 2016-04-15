using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Reddit
{
    public class Post : SpecificBlock
    {
        public Post(Session session, IWebElement tag) : base(session, tag)
        {
        }

        public IClickable<WebBlock> Title => new Clickable<WebBlock>(this, By.CssSelector("a.title"));

        public IClickable<WebBlock> Author => new Clickable<WebBlock>(this, By.ClassName("author"));

        public IClickable<WebBlock> Comments => new Clickable<WebBlock>(this, By.ClassName("comments"));

        public IClickable<WebBlock> Domain => new Clickable<WebBlock>(this, By.ClassName("domain"));

        public IClickable<RedditPage> Subreddit => new Clickable<RedditPage>(this, By.ClassName("subreddit"));

        public string Rank => FindElement(By.ClassName("rank")).Text;
    }
}