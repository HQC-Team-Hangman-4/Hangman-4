namespace HangMan.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Validator
    {
        //TODO: Put it in game logic to maintain reusability.
        private const int HighestPossibleScore = 1000;

        internal static void CheckIfNull<T>(T item, string name)
        {
            if (item == null)
            {
                throw new ArgumentNullException(name + " cannot be null.");
            }
        }

        internal static void CheckIfInRangeExcluded(int number, string name, int min, int max)
        {
            if (number <= min || max <= number)
            {
                throw new ArgumentException(string.Format("{0} is out of scope ({0},{1}).", name, min, max));
            }
        }

        internal static void CheckIfInRangeIncluded(int number, string name, int min, int max)
        {
            if (number < min || max < number)
            {
                throw new ArgumentException(string.Format("{0} is out of scope [{1},{2}].", name, min, max));
            }
        }

        internal static void CheckAllElementsInCollection<T>(IEnumerable<T> collection, string name)
        {
            foreach (var item in collection)
            {
                Validator.CheckIfNull(item, name);
            }
        }

        internal static void CheckIfLetter<T>(T value, string name)
        {
            if (!Regex.IsMatch(value.ToString(), @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException(name + " is not a letter.");
            }
        }

        internal static void CheckIfValidScore(int score, string name)
        {
            if (score < 0 || HighestPossibleScore < score)
            {
                throw new ArgumentException(string.Format("{0} cannot be higher than {1} or lower than 0.", name, HighestPossibleScore));
            }
        }
    }
}
