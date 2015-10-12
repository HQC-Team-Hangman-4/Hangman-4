namespace HangMan.InputProviders
{
    using System;
    using HangMan.Interfaces;

    /// <summary>
    /// Provides input functionality through the console.
    /// </summary>
    public class ConsoleInputProvider : IInputProvider
    {
        private string command;

        /// <summary>
        /// Console input provider constructor.
        /// </summary>
        public ConsoleInputProvider()
        {
            this.Command = default(string);
        }

        /// <summary>
        /// Gets and sets the command read from the console.
        /// </summary>
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

        /// <summary>
        /// Reads a command from the console.
        /// </summary>
        public void GetInput()
        {
            this.Command = Console.ReadLine();
        }
    }
}
