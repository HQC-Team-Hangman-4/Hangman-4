namespace HangMan.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Validator
    {
        private const string NullMessage = "{0} cannot be null.";
        private const string OutOfRangeMessage = "{0} is out of range {1} -- {2}";
        private const string NotLetterMessage = "{0} is not a letter.";

        //TODO: Put it in game logic to maintain reusability.
        private const int HighestPossibleScore = 1000;

        internal static void CheckIfNull<T>(T item, string name)
        {
            if (item == null)
            {
                throw new ArgumentNullException(string.Format(NullMessage, name));
            }
        }

        internal static void CheckIfInRangeExcluded(int number, string name, int min, int max)
        {
            if (number <= min || max <= number)
            {
                throw new ArgumentException(string.Format("{0} is out of scope {1}-{2}. Was {3}", name, min, max, number));
            }
        }

        internal static void CheckIfInRangeIncluded(int number, string name, int min, int max)
        {
            if (number < min || max < number)
            {
                throw new ArgumentException(string.Format(OutOfRangeMessage, name, min, max) + ", inclusive.");
            }
        }

        internal static void CheckAllElementsInCollection<T>(IEnumerable<T> collection, string name)
        {
            foreach (var item in collection)
            {
                Validator.CheckIfNull(item, name);
            }
        }

        internal static void CheckIfLetter(char value, string name)
        {
            if (!Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+"))
            {
                throw new ArgumentException(string.Format(NotLetterMessage, name));
            }
        }

        internal static void CheckIfValidScore(int score, string name)
        {
            if (score < 0 || HighestPossibleScore < score)
            {
                throw new ArgumentException(string.Format(OutOfRangeMessage, name, 0, HighestPossibleScore));
            }
        }
    }
}
