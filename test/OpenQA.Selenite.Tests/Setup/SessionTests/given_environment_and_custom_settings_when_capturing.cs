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
    public class Given_environment_and_custom_settings_When_capturing : HostThreadedSessionFixture
    {
        private string _filePath;
        private Session _session;
        private Session _returnSession;

        public override void Before()
        {
            var currentMethod = CallStack.GetCurrentMethod().GetFullName();

            const string path = @"C:\Temp";
            _filePath = Path.ChangeExtension(Path.Combine(path, currentMethod), "png");
            File.Delete(_filePath);

            var settings = new Settings
            {
                ScreenCapturePath = path
            };

            var environment = new InternetExplorer();
            _session = new Session(environment, settings);
            _session.NavigateTo<CheckboxPage>(Url("Checkbox.html"));
            _returnSession = _session.CaptureScreen(_filePath);
        }

        public override void After()
        {
            _session.End();
            File.Delete(_filePath);
        }

        [Test]
        public void should_return_session()
        {
            _returnSession.Should().Be(_session);
        }

        [Test]
        public void should_save_in_path()
        {
            File.Exists(_filePath).Should().BeTrue();
        }
    }
}