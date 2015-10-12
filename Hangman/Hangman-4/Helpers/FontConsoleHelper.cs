namespace HangMan.Helpers
{
    using System;
    using System.IO;

    /// <summary>
    /// Fascilitates writing to the console with different fonts.
    /// </summary>
    public class FontConsoleHelper
    {
        private string[] fontArray;
        private int symbolHeight;

        /// <summary>
        /// FontConsoleHelper constructor.
        /// </summary>
        /// <param name="fontFile">File defining a font.</param>
        public FontConsoleHelper(string fontFile)
        {
            this.fontArray = this.GetFontSymbols(fontFile);
            this.symbolHeight = this.fontArray.Length / 106;
        }

        /// <summary>
        /// Prints a string to the console at some position with the current font.
        /// </summary>
        /// <param name="text">String text to be written to console.</param>
        /// <param name="left">Column index of top left corner position.</param>
        /// <param name="top">Row index of top left corner position.</param>
        public void Print(string text, int left, int top)
        {
            int totalLength = 0;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < this.symbolHeight; j++)
                {
                    Console.SetCursorPosition(left + totalLength, top + j);
                    Console.Write(this.fontArray[((text[i] - 32) * this.symbolHeight) + j]);
                }

                totalLength += this.fontArray[((text[i] - 32) * this.symbolHeight) + this.symbolHeight].Length;
            }
        }

        private string[] GetFontSymbols(string fontFile)
        {
            string[] fontLines = File.ReadAllLines(fontFile);

            return fontLines;
        }
    }
}
