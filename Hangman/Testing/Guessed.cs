namespace Testing
{
    using System.Text;
    using HangMan.Interfaces;

    public class Guessed : IRendarable
    {
        private IRendarable renderable;

        public Guessed(IRendarable renderable)
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
