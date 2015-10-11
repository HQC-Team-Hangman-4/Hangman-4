namespace HangMan.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class FontConsoleHelper
    {
        private string[] fontArray;
        private int symbolHeight;

        public FontConsoleHelper(string fontFile)
        {
            this.fontArray = this.GetFontSymbols(fontFile);
            this.symbolHeight = this.fontArray.Length / 106;
        }

        public void Print(string text, int left, int top)
        {
            int totalLength = 0;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < this.symbolHeight; j++)
                {
                    Console.SetCursorPosition(left + totalLength, top + j);
                    Console.Write(this.fontArray[(text[i] - 32) * this.symbolHeight + j]);
                }

                totalLength += this.fontArray[(text[i] - 32) * this.symbolHeight + this.symbolHeight].Length;
            }
        }
        
        private string[] GetFontSymbols(string fontFile)
        {
            string[] fontLines = File.ReadAllLines(fontFile);

            return fontLines;
        }
    }
}
