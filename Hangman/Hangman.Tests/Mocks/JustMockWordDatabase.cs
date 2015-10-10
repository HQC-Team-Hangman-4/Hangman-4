namespace Hangman.Tests.Mocks
{
    using System;
    using System.ComponentModel;

    using HangMan.Helpers.Data;

    using Telerik.JustMock;

    public class JustMockWordDatabase : WordDataBaseMock
    {
        protected override void ArrangeDatabaseMock()
        {
            this.DB = Mock.Create<IWordDatabase>();
            Mock.Arrange(() => this.DB.GetRandomWordByCategory(Arg.IsAny<Categories>()))
                .Returns((Categories cat) => this.GetWord(cat));
        }
    }
}
