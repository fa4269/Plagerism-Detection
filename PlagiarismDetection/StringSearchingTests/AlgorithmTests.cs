using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StringSearching;

namespace StringSearchingTests
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        public void Algorithms_KMP_Search()
        {
            string w = "ABCDABD";
            string s = "ABC ABCDAB ABCDABCDABDE";

            var expected = new List<int> { 15 };
            var actual = Algorithms.KMP_Search(s, w);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
