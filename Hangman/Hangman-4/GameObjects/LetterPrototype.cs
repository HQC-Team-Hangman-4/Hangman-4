namespace HangMan.GameObjects
{
    using HangMan.Interfaces;

    /// <summary>
    /// Defines common functionality for all letter.
    /// </summary>
    public abstract class LetterPrototype
    {
        /// <summary>
        /// Cloning is common functionality for all letters.
        /// </summary>
        /// <returns>ILetter object.</returns>
        public abstract ILetter Clone();
    }
}
