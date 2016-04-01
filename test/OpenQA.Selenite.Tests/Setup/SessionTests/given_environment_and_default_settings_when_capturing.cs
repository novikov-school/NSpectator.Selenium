using System.IO;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenite.Tests.Shared.Hosting;
using OpenQA.Selenite.Tests.Shared.Pages.Implementation;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;

// ReSharper disable InconsistentNaming

namespace OpenQA.Selenite.Tests.Setup.SessionTests
{
    [TestFixture]
    public class Given_environment_and_default_settings_When_capturing : HostThreadedSessionFixture
    {
        private string path;
        private Session session;
        private Session _returnSession;

        public override void Before()
        {
            var currentMethod = string.Format("{0}.png", MethodBase.GetCurrentMethod().GetFullName());
            var defaultSettings = new Settings();

            path = Path.Combine(defaultSettings.ScreenCapturePath, currentMethod);
            File.Delete(path);

            var environment = new InternetExplorer();
            session = new Session(environment);
            session.NavigateTo<CheckboxPage>(Url("Checkbox.html"));

            _returnSession = session.CaptureScreen();
        }

        public override void After()
        {
            session.End();
            File.Delete(path);
        }

        [Test]
        public void should_return_session()
        {
            _returnSession.Should().Be(session);
        }

        [Test]
        public void should_save_in_executing_directory()
        {
            File.Exists(path).Should().BeTrue();
        }
    }
}