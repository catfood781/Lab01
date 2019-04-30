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
    public class MexicanTrainTests
    {
        Domino d00;
        Domino d22;
        Domino d27;
        Hand hand;
        MexicanTrain mexicanTrain;

        [SetUp]
        public void SetUpAllTests()
        {
            d00 = new Domino();
            d22 = new Domino(2, 2);
            d27 = new Domino(2, 7);
            hand = new Hand();
            mexicanTrain = new MexicanTrain(7);
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
            Assert.AreEqual(7, mexicanTrain.EngineValue);
            MexicanTrain newTrain = new MexicanTrain(4);
            Assert.AreEqual(4, newTrain.EngineValue);
        }

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(0, mexicanTrain.Count);
            MexicanTrain newTrain = new MexicanTrain(8);
            Assert.AreEqual(0, newTrain.Count);
        }

        [Test]
        public void EngineValue()
        {
            MexicanTrain newTrain = new MexicanTrain(9);
            Assert.AreEqual(9, newTrain.EngineValue);
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.True(mexicanTrain.IsEmpty);
            MexicanTrain newTrain = new MexicanTrain(7);
            Assert.True(newTrain.IsEmpty);
        }

        [Test]
        public void TestLastDomino()
        {
            Assert.IsNull(mexicanTrain.LastDomino);
            mexicanTrain.Add(d27);
            Assert.AreEqual(d27, mexicanTrain.LastDomino);
        }

        [Test]
        public void TestPlayableValue()
        {
            Assert.AreEqual(7, mexicanTrain.PlayableValue);
            mexicanTrain.Add(d22);
            Assert.AreEqual(2, mexicanTrain.PlayableValue);
        }

        [Test]
        public void TestAdd()
        {
            mexicanTrain.Add(d22);
            Assert.AreEqual(1, mexicanTrain.Count);
            Assert.AreEqual(2, mexicanTrain.LastDomino.Side2);
        }

        [Test]
        public void TestIndexer()
        {
            mexicanTrain.Add(d00);
            mexicanTrain.Add(d27);
            Domino d1 = mexicanTrain[1];
            Assert.AreEqual(2, d1.Side1);
            Assert.AreEqual(7, d1.Side2);
        }

        [Test]
        public void TestExceptionIndexer()
        {
            mexicanTrain.Add(d00);
            mexicanTrain.Add(d27);
            Domino d2;

            Assert.Throws<Exception>(() => d2 = mexicanTrain[-3]);
            Assert.Throws<Exception>(() => d2 = mexicanTrain[3]);
            Assert.AreEqual(mexicanTrain[1], mexicanTrain.LastDomino);
        }

        [Test]
        public void TestPlayableHand()
        {
            bool mustFlip;
            Assert.True(mexicanTrain.IsPlayable(hand, d27, out mustFlip));
            Assert.False(mexicanTrain.IsPlayable(hand, d00, out mustFlip));
        }

        [Test]
        public void TestIsPlayable()
        {
            bool mustFlip;
            Domino d72 = new Domino(7, 2);
            Assert.True(mexicanTrain.IsPlayable(hand, d27, out mustFlip));
            Assert.True(mustFlip);
            Assert.True(mexicanTrain.IsPlayable(hand, d72, out mustFlip));
            Assert.False(mustFlip);
        }

        [Test]
        public void TestPlay()
        {
            Assert.AreEqual(7, mexicanTrain.PlayableValue);
            mexicanTrain.Play(hand, d27);
            Assert.AreEqual(2, mexicanTrain.PlayableValue);
        }



    }
}
