using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using CardClasses;

namespace cardConsoleTest
{
    [TestFixture]
    class HandTest
    {
        Hand h1;
        Hand h2;

        [SetUp]
        public void SetUpAllTests()
        {
            h1 = new Hand();
        }

        [Test]
        public void TestSimpleAddition()
        {
            /// <summary>
            /// Tests if math works
            /// </summary>
            int answer = 1 + 2;
            Assert.AreEqual(3, answer);
        }

        [Test]
        public void TestHandConstructors()
        {
            Assert.AreEqual();
        }

    }
}
