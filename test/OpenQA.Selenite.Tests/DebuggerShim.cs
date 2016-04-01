using System.Linq;
using System.Reflection;
using FluentAssertions;
using NSpectator;
using NSpectator.Domain;
using NSpectator.Domain.Formatters;

/*
 * Howdy,
 * 
 * This is NSpectator's DebuggerShim.  It will allow you to use Resharper's test runner to run
 * NSpectator tests that are in the same Assembly as this class.
 */
//[TestFixture]
public class DebuggerShim
{
    //[Test]
    public void Debug(string tagOrClassName)
    {
        var types = GetType().Assembly.GetTypes();
        // OR
        // var types = new Type[]{typeof(Some_Type_Containg_some_Specs)};
        Debug(new SpecFinder(types, ""));
    }

    public void Debug(System.Type t)
    {
        Debug(new SpecFinder(new[] { t }, ""));
    }

    private void Debug(SpecFinder finder)
    {
        // var tagsFilter = new Tags().Parse(tagOrClassName);
        // var builder = new ContextBuilder(finder, tagsFilter, new DefaultConventions());
        var builder = new ContextBuilder(finder, new DefaultConventions());
        var runner = new ContextRunner(new Tags(), new ConsoleFormatter(), false);
        var results = runner.Run(builder.Contexts().Build());

        // assert that there aren't any failures
        results.Failures().Count().Should().Be(0, "all examples passed");
    }
}
