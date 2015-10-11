using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangMan.Interfaces;

namespace Testing
{
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
            strB.AppendLine(new string('-',10));
            strB.AppendLine(renderable.GetBody());
            strB.AppendLine(new string('-', 10));

            return strB.ToString();
        }
    }
}
