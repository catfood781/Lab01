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
    public class DominoTests
    {
        Domino def;
        Domino d12;
        Domino d21;
        Domino d33;

        [SetUp]
        public void SetUpAllTests()
        {
            def = new Domino();
            d12 = new Domino(1, 2);
            d21 = new Domino(2, 1);
            d33 = new Domino(3, 3);
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
        public void TestOverloadedConstructor()
        {
            /// <summary>
            /// Testing overloaded constructor
            /// my d12 dice should have a 1 for
            /// side 1 and a 2 for side two
            /// </summary>
            Assert.AreEqual(1, d12.Side1);
            Assert.AreEqual(2, d12.Side2);
        }

        [Test]
        public void TestGetters()
        {
            /// <summary>
            /// Testing getters
            /// My d12 dice should have a 1 for side 
            /// 1 and a 2 for side 2. It should not
            /// have a five on either side.
            /// </summary>
            Assert.AreEqual(1, d12.Side1);
            Assert.AreEqual(2, d12.Side2);
            Assert.AreNotEqual(5, d12.Side1);
            Assert.AreNotEqual(5, d12.Side2);
        }

        [Test]
        public void TestSettersValid()
        {
            /// <summary>
            /// Testing Setters
            /// My d dice should have a 1 for
            /// side one and a 12 for side 12.
            /// It should not have a 7 on either
            /// side.
            /// </summary>
            Domino d = new Domino(3, 2);
            Assert.AreEqual(3, d.Side1);
            Assert.AreEqual(2, d.Side2);
            d.Side1 = 1;
            d.Side2 = 12;
            Assert.AreEqual(1, d.Side1);
            Assert.AreEqual(12, d.Side2);
            Assert.AreNotEqual(7, d.Side1);
            Assert.AreNotEqual(7, d.Side2);
        }

        [Test]
        public void TestSettersInValidTry()
        {
            /// <summary>
            /// Testing setters in valid try
            /// If the dots on either side if my domino is 
            /// less than zero or higher than
            /// 13 an exception should throw.
            /// </summary>
            Domino d = new Domino();
            try
            {
                d.Side1 = -1;
                Assert.Fail("The setter should throw an exception for negative values.");
            }
            catch (ArgumentException)
            {
                Assert.Pass("The setter threw an exception for a negative value as expected");
            }
            try
            {
                d.Side1 = 15;
                Assert.Fail("The setter should throw an exception for a value > 13.");
            }
            catch (ArgumentException)
            {
                Assert.Pass("The setter threw an exception for a value of 15 as expected");
            }
            Assert.AreEqual(0, d.Side1);
            Assert.AreEqual(0, d.Side2);
        }

        [Test]
        public void TestSettersInValidAssertThrows()
        {
            /// <summary>
            /// Testing assert throws
            /// This is the specific exception that 
            /// should be thrown
            /// </summary>
            Domino d = new Domino();
            Assert.Throws<ArgumentException>(() => d.Side1 = -1);
            Assert.Throws<ArgumentException>(() => d.Side1 = 15);
            Assert.AreEqual(0, d.Side1);
            Assert.AreEqual(0, d.Side2);
        }

        [Test]
        public void TestFlip()
        {
            /// <summary>
            /// Test flip
            /// Testing if system recognizes that 
            /// a domino with a 2 on side 2 and a 
            /// 1 on side one is the same as a domino
            /// with a 1 on side 2 and a 2 on side 1
            /// </summary>
            d12.Flip();
            Assert.AreEqual(2, d12.Side1);
            Assert.AreEqual(1, d12.Side2);
        }

        [Test]
        public void TestScore()
        {
            /// <summary>
            /// Testing score
            /// domino d12 should equal 3. 1 plus 2 is 3
            /// domino d33 should equal 6. 3 plus 3 is 6
            /// </summary>
            Assert.AreEqual(3, d12.Score);
            Assert.AreEqual(6, d33.Score);
        }

        [Test]
        public void TestIsDouble()
        {
            /// <summary>
            /// Testing is double
            /// testing if the numeric value of the sides of each
            /// domino are the same
            /// d33 should show true
            /// d12 should show false
            /// </summary>
            Assert.True(d33.IsDouble());
            Assert.False(d12.IsDouble());
        }

        [Test]
        public void TestEquals()
        {
            /// <summary>
            /// Testing Equals
            /// 
            /// </summary>
            Domino duplicate12 = new Domino(1, 2);
            Assert.True(d12.Equals(duplicate12));
            Assert.False(d12.Equals(d21));
        }
    }
}
