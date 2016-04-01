using System;
using NUnit.Framework;
using OpenQA.Selenite.Tests.Specs.Pages;
using OpenQA.Selenite.Tests.Specs.Setup;

namespace OpenQA.Selenite.Tests.Specs 
{
    [TestFixture]
    public class SpecRunner : DebuggerShim
    {
        /// <summary>
        /// Тест кейсы
        /// </summary>
        /// <param name="tagOrClassName">Имя запускаемой спецификации страницы</param>
        [TestCase(typeof(Describe_radio_buttons_page))]
        [TestCase(typeof(Describe_page_with_jQuery))]
        [TestCase(typeof(Describe_numeric_field))]
        public void RunSpec(Type tagOrClassName)
        {
            Debug(tagOrClassName);
        }
    }
}