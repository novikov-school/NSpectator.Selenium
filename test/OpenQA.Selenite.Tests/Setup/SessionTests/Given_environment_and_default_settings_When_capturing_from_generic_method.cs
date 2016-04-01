using System.IO;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenite.Tests.Shared.Hosting;
using OpenQA.Selenite.Tests.Shared.Pages.Implementation;
using OpenQA.Selenite;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;

// ReSharper disable InconsistentNaming

namespace OpenQA.Selenite.Tests.Setup.SessionTests
{
    [TestFixture]
    public class Given_environment_and_default_settings_When_capturing_from_generic_method : HostThreadedSessionFixture
    {
        private string GenericMethod<T>(T session) where T : Session
        {
            var currentMethod = string.Format("{0}.png", CallStack.GetCurrentMethod().GetFullName());
            var defaultSettings = new Settings();

            var path = Path.Combine(defaultSettings.ScreenCapturePath, currentMethod);
            File.Delete(path);

            session.CaptureScreen();
            return path;
        }

        [Test]
        public void Should_save_in_executing_directory()
        {
            var environment = new InternetExplorer();
            var session = new Session(environment);
            session.NavigateTo<CheckboxPage>(Url("Checkbox.html"));

            var path = GenericMethod(session);

            File.Exists(path).Should().BeTrue();

            session.End();
            File.Delete(path);
        }
    }
}