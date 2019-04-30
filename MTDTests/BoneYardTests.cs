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
    public class BoneYardTests
    {
        BoneYard boneYard;
        BoneYard boneYardOverloaded;
        BoneYard boneNeg1;
        BoneYard bone1;
        int maxDots = 12;

        [SetUp]
        public void SetUpAllTests()
        {
            /// <summary>
            /// My boneyard instances
            /// </summary>
            boneYard = new BoneYard(0);
            boneYardOverloaded = new BoneYard(maxDots);
            boneNeg1 = new BoneYard(-1);
            bone1 = new BoneYard(1);
        }
        [Test]
        public void TestSimpleAddition()
        {
            /// <summary>
            /// Testing is math works
            /// </summary>
            int math = 1 + 2;
            Assert.AreEqual(3, math);
        }
        [Test]
        public void TestOverloadedConstructor()
        {
            /// <summary>
            /// Testing my overloaded constructor
            /// boneYard should equal 1
            /// boneYardOverloaded should equal 91
            /// boneNeg1 should equal zero
            /// bone1 should eqal 3
            /// </summary>
            Assert.AreEqual(1, boneYard.DominosRemaining);
            Assert.AreEqual(91, boneYardOverloaded.DominosRemaining);
            Assert.AreEqual(0, boneNeg1.DominosRemaining);
            Assert.AreEqual(3, bone1.DominosRemaining);
        }
        [Test]
        public void TestBoneYardShuffle()
        {
            /// <summary>
            /// Testing my shuffle
            /// Both sides of my domino should not
            /// equal 0. This might occasionally fail
            /// depending on what the shuffle is doing
            /// </summary>
            boneYardOverloaded.Shuffle();
            Domino firstDomino = boneYardOverloaded[0];
            Assert.AreNotEqual(0, firstDomino.Side1);
            Assert.AreNotEqual(0, firstDomino.Side2);
        }
        [Test]
        public void TestBoneyardIsEmpty()
        {
            /// <summary>
            /// Testing if boneyard is empty
            /// boneyardOverloaded should not be empty
            /// boneNeg1 should be empty
            /// </summary>
            Assert.AreEqual(false, boneYardOverloaded.IsEmpty());
            Assert.AreEqual(true, boneNeg1.IsEmpty());
        }
        [Test]
        public void TestDominosRemaining()
        {
            /// <summary>
            /// Testing dominos remaining
            /// bonyard should have 1
            /// boneyardOverloaded should have 91
            /// boneNeg1 should have zero
            /// bone1 should have 3
            /// </summary>
            Assert.AreEqual(1, boneYard.DominosRemaining);
            Assert.AreEqual(91, boneYardOverloaded.DominosRemaining);
            Assert.AreEqual(0, boneNeg1.DominosRemaining);
            Assert.AreEqual(3, bone1.DominosRemaining);
        }
        [Test]
        public void TestBoneyardDraw()
        {
            /// <summary>
            /// Testing draw
            /// firstDomino side one and side two 
            /// should both be zero
            /// secondDomino side one should be zero 
            /// and side two should be 1
            /// </summary>
            Domino firstDomino = boneYardOverloaded.Draw();
            Domino secondDomino = boneYardOverloaded.Draw();
            Assert.AreEqual(0, firstDomino.Side1);
            Assert.AreEqual(0, firstDomino.Side2);
            Assert.AreEqual(0, secondDomino.Side1);
            Assert.AreEqual(1, secondDomino.Side2);
        }
    }
}
