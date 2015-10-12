namespace HangMan.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Holds methods for validation of data.
    /// </summary>
    public class Validator
    {
        private const string NullMessage = "{0} cannot be null.";
        private const string OutOfRangeMessage = "{0} {1} is out of range {2} -- {3}";
        private const string NotLetterMessage = "{0} is not a letter.";
        private const int HighestPossibleScore = 1000;

        /// <summary>
        /// Checks if an item is null.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="item">Item.</param>
        /// <param name="name">Name of the parameter.</param>
        internal static void CheckIfNull<T>(T item, string name)
        {
            if (item == null)
            {
                throw new ArgumentNullException(string.Format(NullMessage, name));
            }
        }

        /// <summary>
        /// Checks if a number is in an open interval of values.
        /// </summary>
        /// <param name="number">Integer number.</param>
        /// <param name="name">Name of parameter.</param>
        /// <param name="min">Min value of interval.</param>
        /// <param name="max">Max value of interval.</param>
        internal static void CheckIfInRangeExcluded(int number, string name, int min, int max)
        {
            if (number <= min || max <= number)
            {
                throw new ArgumentException(string.Format(OutOfRangeMessage, name, number, min, max) + ", exclusive.");
            }
        }

        /// <summary>
        /// Checks if a number is in a closed interval of values.
        /// </summary>
        /// <param name="number">Integer number.</param>
        /// <param name="name">Name of parameter.</param>
        /// <param name="min">Min value of interval.</param>
        /// <param name="max">Max value of interval.</param>
        internal static void CheckIfInRangeIncluded(int number, string name, int min, int max)
        {
            if (number < min || max < number)
            {
                throw new ArgumentException(string.Format(OutOfRangeMessage, name, number, min, max) + ", inclusive.");
            }
        }

        /// <summary>
        /// Validates elements in collection are not null.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="collection">Collection.</param>
        /// <param name="name">Name of parameter.</param>
        internal static void CheckAllElementsInCollection<T>(IEnumerable<T> collection, string name)
        {
            foreach (var item in collection)
            {
                Validator.CheckIfNull(item, name);
            }
        }

        /// <summary>
        /// Check if a character is a letter.
        /// </summary>
        /// <param name="value">Character value.</param>
        /// <param name="name">Name of parameter.</param>
        internal static void CheckIfLetter(char value, string name)
        {
            if (!Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+"))
            {
                throw new ArgumentException(string.Format(NotLetterMessage, name));
            }
        }

        /// <summary>
        /// Checks if score is valid.
        /// </summary>
        /// <param name="score">Integer score.</param>
        /// <param name="name">String parameter name.</param>
        internal static void CheckIfValidScore(int score, string name)
        {
            if (score < 0 || HighestPossibleScore < score)
            {
                throw new ArgumentException(string.Format(OutOfRangeMessage, name, score, 0, HighestPossibleScore));
            }
        }
    }
}
