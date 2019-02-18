using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiAutomation.Test
{
    [TestFixture]
    class Anagrams
    {
        // --- Directions
        // Check to see if two provided strings are anagrams of eachother.
        // One string is an anagram of another if it uses the same characters
        // in the same quantity. Only consider characters, not spaces
        // or punctuation.  Consider capital letters to be the same as lower case
        // --- Examples
        //   anagrams('rail Safety', 'fairy tales') --> True
        //   anagrams('RAIL! SAFETY!', 'fairy tales') --> True
        //   anagrams('Hi there', 'Bye there') --> False

        public bool anagrams(string strA, string strB)
        {
            return String.Equals(cleanString(strA), cleanString(strB));
        }

        public string cleanString(string str)
        {
            string replacedString = Regex.Replace(str, @"[^\w\d]+", "").ToLower();
            return String.Concat(replacedString.OrderBy(s => s));
        }

        [TestCase("rail safety", "fairy tales", true)]
        [TestCase("RAIL! SAFETY!", "fairy tales", true)]
        [TestCase("Hi there", "Bye there", false)]

        public void tests(string a, string b, bool result)
        {
            Assert.AreEqual(result, anagrams(a, b));
        }

    }

}