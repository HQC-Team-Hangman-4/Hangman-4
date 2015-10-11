namespace Testing
{
    using System.Text;
    using HangMan.Interfaces;

    public class Guessed : IRenderable
    {
        private IRenderable renderable;

        public Guessed(IRenderable renderable)
        {
            this.renderable = renderable;
        }

        public string GetBody()
        {
            var strB = new StringBuilder();
            strB.AppendLine(new string('-', 10));
            strB.AppendLine(this.renderable.GetBody());
            strB.AppendLine(new string('-', 10));

            return strB.ToString();
        }
    }
}
