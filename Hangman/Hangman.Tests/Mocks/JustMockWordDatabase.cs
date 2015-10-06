using System.ComponentModel;

namespace Hangman.Tests.Mocks
{
    using System;

    using Telerik.JustMock;

    using HangMan.Helpers.Data;


    public class JustMockWordDatabase : WordDataBaseMock
    {
        protected override void ArrangeDatabaseMock()
        {
            this.db = Mock.Create<IWordDatabase>();
            Mock.Arrange(() => this.db.GetRandomWordByCategory(Arg.IsAny<Categories>()))
                .Returns((Categories cat) => this.GetWord(cat));

        }
    }
}
