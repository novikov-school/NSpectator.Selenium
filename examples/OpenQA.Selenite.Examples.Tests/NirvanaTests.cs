using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenite.Examples.Nirvana;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;

namespace OpenQA.Selenite.Examples.Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class NirvanaTests
    {
        private const string Url = "https://www.nirvanahq.com/login";
        private const string ValidUsername = "van.urgant@gmail.com";
        private const string Password = "P@ssw0rd";

        [SetUp]
        public void OpenLoginPage()
        {
            Threaded<Session>
                .With<Firefox>()
                .NavigateTo<LoggedOutPage>(Url);
        }

        [TearDown]
        public void TearDown()
        {
            Threaded<Session>
                .End();
        }


        [Test]
        public void given_valid_logged_in_user_when_adding_task_should_add_task()
        {
            Threaded<Session>
                .CurrentBlock<LoggedOutPage>()
                .Username.EnterText(ValidUsername)
                .Password.EnterText(Password)
                .Login.Click<UpgradePromptPage>();

            var taskInfo = new {Name = $"Task {Guid.NewGuid()}", Note = "This is a note."};

            Threaded<Session>
                .CurrentBlock<LoggedInPage>()
                .ToolBar
                .NewTask.Click()
                .Name.EnterText(taskInfo.Name)
                .Note.EnterText(taskInfo.Note)
                .Save.Click()
                .TaskLists.First()
                .TaskRows.First(row => row.Name == taskInfo.Name)
                .VerifyThat(row => row.Should().NotBeNull())
                .Delete();
        }
    }
}