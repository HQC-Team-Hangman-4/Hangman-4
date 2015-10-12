namespace Hangman.Tests
{
    using Hangman.Tests.Mocks;
    using HangMan.Renderers;
    using NUnit.Framework;

    [TestFixture]
    public class ConsoleFancyRendererTests : ConsoleRendererTestsSetup
    {
        [TestCase]
        public void ConsoleFancyRendererShouldNotBeNullWhenInstantiated()
        {
            var consolefancyRenderer = new ConsoleFancyRenderer();

            Assert.IsNotNull(consolefancyRenderer);
        }
    }
}
