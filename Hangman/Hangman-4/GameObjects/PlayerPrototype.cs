namespace HangMan.GameObjects
{
    using HangMan.Interfaces;

    public abstract class PlayerPrototype
    {
        public abstract IPlayer Clone();
    }
}
