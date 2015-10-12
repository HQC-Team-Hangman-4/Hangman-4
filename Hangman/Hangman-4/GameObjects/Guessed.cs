namespace HangMan.GameObjects
{
    using System.Text;
    using HangMan.Helpers;
    using HangMan.Interfaces;

    /// <summary>
    /// Extends IRenderable functionality. 
    /// </summary>
    public class Guessed : IRenderable
    {
        private readonly IRenderable renderable;

        /// <summary>
        /// Guessed constructor.
        /// </summary>
        /// <param name="renderable">IRenderable object.</param>
        public Guessed(IRenderable renderable)
        {
            Validator.CheckIfNull(renderable, "Renderable cannot be null.");
            this.renderable = renderable;
        }

        /// <summary>
        /// Gets the body of a renderable object.
        /// </summary>
        /// <returns>String representation.</returns>
        public string GetBody()
        {
            var strB = new StringBuilder();
            var renderableBody = this.renderable.GetBody();
            strB.AppendLine(new string('-', renderableBody.Length + 2));
            strB.AppendLine('|' + renderableBody + '|');
            strB.AppendLine(new string('-', renderableBody.Length + 2));

            return strB.ToString();
        }
    }
}