using OpenQA.Selenite.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace OpenQA.Selenite.Implementation
{
    internal class WebDragAndDropPerformer : IPerformsDragAndDrop
    {

        public WebDragAndDropPerformer(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; private set; }

        public void DragAndDrop(IWebElement drag, IWebElement drop)
        {
            new Actions(Driver).DragAndDrop(drag, drop).Build().Perform();
        }

        public void DragAndDrop(IWebElement drag, int xDrop, int yDrop)
        {
            new Actions(Driver).DragAndDropToOffset(drag, xDrop, yDrop).Build().Perform();
        }
    }
}