namespace HangMan.Interfaces
{
    public interface IInputProvider
    {
        string Command { get; set; }

        void GetInput();
    }
}
