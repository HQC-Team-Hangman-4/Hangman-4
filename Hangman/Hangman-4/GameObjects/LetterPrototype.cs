namespace HangMan.GameObjects
{
    using HangMan.Interfaces;

    public abstract class LetterPrototype
    {
        public abstract ILetter Clone();
    }
}
