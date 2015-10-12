namespace HangMan.GameObjects
{
    using System.Text;
    using HangMan.Helpers;
    using HangMan.Interfaces;

    public class Guessed : IRenderable
    {
        private readonly IRenderable renderable;

        public Guessed(IRenderable renderable)
        {
            Validator.CheckIfNull(renderable, "Renderable cannot be null.");
            this.renderable = renderable;
        }

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