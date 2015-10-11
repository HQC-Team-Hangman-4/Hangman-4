namespace Hangman.Tests.Mocks
{
    using HangMan.Interfaces;

    public class ConsoleInputProviderMock : IInputProvider
    {
        private string command;

         public string Command
         {
             get
             {
                 return this.command;
             }
             set 
             {
                 this.command = value;
             }           
         }

         public void GetInput()
         {
             this.Command = "string_134";
         }
    }
}
