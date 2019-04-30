using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDTests
{
    [TestFixture]
    public class HandTests
    {
        Hand h1;
        Hand h2;

        [SetUp]
        public void SetUpAllTests()
        {
            h1 = new Hand();
            h2 = new Hand();
        }

        [Test]
        public void TestSimpleAddition()
        {
            int answer = 1 + 2;
            Assert.AreEqual(3, answer);
        }

        [Test]
        public void TestConstructors()
        {
            Assert.AreEqual
        }
    }
}
