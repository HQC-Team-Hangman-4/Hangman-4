namespace HangMan.GameObjects
{
    using HangMan.Interfaces;

    /// <summary>
    /// Defines common functionality for all players.
    /// </summary>
    public abstract class PlayerPrototype
    {
        /// <summary>
        /// Cloning is common functionality for all players.
        /// </summary>
        /// <returns>IPlayer object.</returns>
        public abstract IPlayer Clone();
    }
}
