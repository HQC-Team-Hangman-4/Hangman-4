using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HangMan.Helpers
{
    public class Validator
    {
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
                throw new ArgumentException(string.Format("{0} is out of scope {0}-{1}.", name, min, max));
            }
        }

        internal static void CheckIfInRangeIncluded(int number, string name, int min, int max)
        {
            if (number < min || max < number)
            {
                throw new ArgumentException(string.Format("{0} is out of scope {1}-{2}.", name, min, max));
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
    }
}
