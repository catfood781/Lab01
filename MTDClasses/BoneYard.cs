using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Boneyard Class. Establishes a collection
    /// of dominos. Methods will shuffle and draw as
    /// well as tell us if the boneyard is empty
    ///and how many dominos are remaining. 
    /// </summary>
    public class BoneYard : IEnumerable<Domino>
    {
        public delegate void EmptyHandler(BoneYard by);
        public event EmptyHandler Empty;

        private List<Domino> dList = new List<Domino>();
        
        //public int dominos => dList.Count;

        public BoneYard(int maxDots)
        {
            dList = new List<Domino>();
            for (int side1 = 0; side1 <= maxDots; side1++)
            {
                for (int side2 = side1; side2 <= maxDots; side2++)
                {
                    dList.Add(new Domino(side1, side2));
                }
            }
            Empty = new EmptyHandler(HandleEmpty);
        }

        public void HandleEmpty(BoneYard by)
        {
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = 0; i < dList.Count; i++)
            {
                int randIndex = rand.Next(0, dList.Count);
                Domino firstDomino = dList[i];
                Domino secondDomino = dList[randIndex];

                dList[i] = secondDomino;
                dList[randIndex] = firstDomino;
            }
        }

        public bool IsEmpty()
        {
            if (dList.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int DominosRemaining
        {
            get { return dList.Count; }
        }

        public Domino Draw()
        {
            if (!IsEmpty())
            {
                Domino firstDomino = dList[0];
                dList.Remove(firstDomino);
                if (IsEmpty())
                {
                    Empty(this);
                }
                return firstDomino;
            }
            else
            {
                throw new Exception("Boneyard is empty");
            }
        }

        public Domino this[int i]
        {
            get { return dList[i]; }
        }

        public override string ToString()
        {
            string output = "";

            foreach (Domino d in dList)
            {
                output += d.ToString() + "\n";

            }
            return "";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Domino> GetEnumerator()
        {
            foreach (Domino d in dList)
            {
                yield return d;
            }
        }
    }
}
