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
    public class PlayerTrainTest
    {
        Hand h1;
        Hand h2;
        Domino d00;
        Domino d27;
        PlayerTrain p1Train;
        PlayerTrain p2Train;

        [SetUp]
        public void SetUpAllTests()
        {
            h1 = new Hand();
            h2 = new Hand();
            d00 = new Domino();
            d27 = new Domino(2, 7);
            p1Train = new PlayerTrain(h1, 6);
            p2Train = new PlayerTrain(h2, 6);
        }

        [Test]
        public void TestSimpleAddition()
        {
            int answer = 1 + 2;
            Assert.AreEqual(3, answer);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(6, p1Train.EngineValue);
            Assert.AreEqual(6, p2Train.EngineValue);
            PlayerTrain newPtrain = new PlayerTrain(h1, 2);
            Assert.AreEqual(2, newPtrain.EngineValue);
        }

        [Test]
        public void TestIsOpen()
        {
            Assert.False(p1Train.IsOpen);
            Assert.False(p2Train.IsOpen);
            PlayerTrain newTrain = new PlayerTrain(h1, 2);
            Assert.False(newTrain.IsOpen);
            p1Train.Open();
            p2Train.Open();
            newTrain.Open();
            Assert.True(p1Train.IsOpen);
            Assert.True(p2Train.IsOpen);
            Assert.True(newTrain.IsOpen);
        }

        [Test]
        public void TestOpen()
        {
            PlayerTrain newTrain = new PlayerTrain(h1, 2);
            Assert.False(newTrain.IsOpen);
            p1Train.Open();
            Assert.True(p1Train.IsOpen);
        }

        [Test]
        public void TestClose()
        {
            PlayerTrain newTrain = new PlayerTrain(h1, 7);
            Assert.False(newTrain.IsOpen);
            newTrain.Open();
            Assert.True(newTrain.IsOpen);
            newTrain.Close();
            Assert.False(newTrain.IsOpen);
        }

        [Test]
        public void TestIsPlayable()
        {
            bool mustFlip;
            Domino d67 = new Domino(6, 7);
            Domino d76 = new Domino(7, 6);
            Assert.False(p2Train.IsPlayable(h1, d67, out mustFlip));
            Assert.True(p1Train.IsPlayable(h1, d67, out mustFlip));

            Assert.False(p1Train.IsPlayable(h2, d76, out mustFlip));
            Assert.True(p1Train.IsPlayable(h1, d76, out mustFlip));
        }
    }
}
