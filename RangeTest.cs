using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomation.Test
{
    [TestFixture]
    class Incomm
    {

        //The function will find the missing number between the min and max
        //so for input of [1,3,4] will return [2]
        public IEnumerable<int> FindMissing(IEnumerable<int> numbers)
        {
            if (numbers == null || numbers.GetEnumerator().MoveNext() == false)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            var list = new List<int>();
            var orderedNumbers = numbers.OrderBy(n => n);
            var max = orderedNumbers.Max();
            var min = orderedNumbers.Min();
            var allNumbers = Enumerable.Range(min, max);
            foreach (var number in allNumbers)
            {
                if (!orderedNumbers.Any(n => n == number))
                {
                    list.Add(number);
                }
            }
            return list;
        }

        [TestCase]
        public void HappyPath()
        {
            Assert.AreEqual(new List<int>(new int[] { 3 } ), FindMissing(new int[] { 1, 2, 4 }));
        }

        [Test]
        public void NoMissingItem()
        {
            Assert.AreEqual(new List<int>(new int[] { }), FindMissing(new int[] { 1, 2, 3, 4 }));
        }

        [Test]
        public void NoMissingItemDuplicates()
        {
            Assert.AreEqual(new List<int>(new int[] { }), FindMissing(new int[] { 1, 1, 1, 1 }));
        }

        [Test]
        public void SingleItemList()
        {
            Assert.AreEqual(new List<int>(new int[] { }), FindMissing(new int[] { 1 }));
        }

        //[Test]

        public void LargeList()
        {
            Assert.AreEqual(Enumerable.Range(Int32.MinValue + 1, Int32.MaxValue - 1), FindMissing(new int[] { Int32.MinValue, Int32.MaxValue }));
        }

        [Test]
        public void DescendingOrderedList()
        {
            Assert.AreEqual(new List<int>(new int[] { 1, 5, 8 }), FindMissing(new int[] { 10, 9, 7, 6, 4, 3 , 2, 0 }));
        }

        [Test]
        public void NullArgument()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => FindMissing(null));
            Assert.That(ex.Message, Is.EqualTo("Value cannot be null.\nParameter name: numbers"));
        }

        [Test]
        public void EmptyList()
        {
            var empty = new int[] { };
            var ex = Assert.Throws<ArgumentNullException>(() => FindMissing(empty));
            Assert.That(ex.Message, Is.EqualTo("Value cannot be null.\nParameter name: numbers"));
        }

    }

}