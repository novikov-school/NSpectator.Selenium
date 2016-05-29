using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenite.Tests.Shared.Hosting;
using OpenQA.Selenite.Tests.Shared.Pages.Implementation;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Setup;
using OpenQA.Selenite.Setup.Environments;

namespace OpenQA.Selenite.Tests.Implementation
{
    // ReSharper disable InconsistentNaming
    
    [TestFixture, Ignore("Broken page")]
    public class Given_dialogs : HostThreadedSessionFixture
    {
        public override void Before()
        {
            Threaded<Session>
                .With<Chrome>()
                .NavigateTo<DialogPage>(Url("dialogs.html"));
        }
        
        [Test]
        public void When_alert_button_clicked_Then_alert_dialog_pops_up_and_dismiss_closes_it()
        {
            Threaded<Session>
                .CurrentBlock<DialogPage>()
                .VerifyThat(x => x.AlertResult.Should().Be("Not Clicked"))
                .AlertButton.Click()
                .VerifyThat(x => x.Text.Should().Be("alert"))
                .Dismiss<DialogPage>()
                .VerifyThat(x => x.AlertResult.Should().Be("Clicked"));
        }

        [Test]
        public void When_alert_button_clicked_Then_alert_dialog_pops_up_and_okay_button_closes_it()
        {
            Threaded<Session>
                .CurrentBlock<DialogPage>()
                .VerifyThat(x => x.AlertResult.Should().Be("Not Clicked"))
                .AlertButton.Click()
                .VerifyThat(x => x.Text.Should().Be("alert"))
                .Accept<DialogPage>()
                .VerifyThat(x => x.AlertResult.Should().Be("Clicked"));
        }

        [Test]
        public void When_confirm_button_clicked_Then_confirm_dialog_pops_up_and_cancel_button_sets_result_to_false()
        {
            Threaded<Session>
                .CurrentBlock<DialogPage>()
                .VerifyThat(x => x.ConfirmResult.Should().Be("Not Clicked"))
                .ConfirmButton.Click()
                .VerifyThat(x => x.Text.Should().Be("confirm"))
                .Dismiss<DialogPage>()
                .VerifyThat(x => x.ConfirmResult.Should().Be("false"));
        }

        [Test]
        public void When_confirm_button_clicked_Then_confirm_dialog_pops_up_and_okay_button_sets_result_to_true()
        {
            Threaded<Session>
                .CurrentBlock<DialogPage>()
                .VerifyThat(x => x.ConfirmResult.Should().Be("Not Clicked"))
                .ConfirmButton.Click()
                .VerifyThat(x => x.Text.Should().Be("confirm"))
                .Accept<DialogPage>()
                .VerifyThat(x => x.ConfirmResult.Should().Be("true"));
        }

        [Test]
        public void When_prompt_button_clicked_Then_prompt_dialog_pops_up_and_cancel_button_sets_result_to_null()
        {
            Threaded<Session>
                .CurrentBlock<DialogPage>()
                .VerifyThat(x => x.ConfirmResult.Should().Be("Not Clicked"))
                .PromptButton.Click()
                .VerifyThat(x => x.Text.Should().Be("prompt"))
                .Dismiss<DialogPage>()
                .VerifyThat(x => x.PromptResult.Should().Be("null"));
        }

        // TODO: it does not appear that it is possible to click 'Cancel' given the IAlertDialog interface

        [Test]
        public void When_prompt_button_clicked_Then_prompt_dialog_pops_up_and_ok_button_sets_result_to_default()
        {
            Threaded<Session>
                .CurrentBlock<DialogPage>()
                .VerifyThat(x => x.ConfirmResult.Should().Be("Not Clicked"))
                .PromptButton.Click()
                .VerifyThat(x => x.Text.Should().Be("prompt"))
                .Accept<DialogPage>()
                .VerifyThat(x => x.PromptResult.Should().Be("default"));
        }

        [Test]
        public void When_prompt_button_clicked_Then_prompt_dialog_pops_up_and_ok_button_sets_result_to_entered_text()
        {
            Threaded<Session>
                .CurrentBlock<DialogPage>()
                .VerifyThat(x => x.ConfirmResult.Should().Be("Not Clicked"))
                .PromptButton.Click()
                .VerifyThat(x => x.Text.Should().Be("prompt"))
                .EnterText("The Text")
                .Accept<DialogPage>()
                .VerifyThat(x => x.PromptResult.Should().Be("The Text"));
        }
    }
}