namespace HangMan.InputProviders
{
    using System;
    using HangMan.Interfaces;

    public class ConsoleInputProvider : IInputProvider
    {
        private string command;

        public ConsoleInputProvider()
        {
            this.Command = default(string);
        }

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
            this.Command = Console.ReadLine();
        }
    }
}
