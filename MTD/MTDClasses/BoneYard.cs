using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class BoneYard
    {
        private List<Domino> dList;
        
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
        }
        
        public void Shuffle()
        {
        }

        public bool IsEmpty()
        {
            return true;
        }

        public int DominosRemaining
        {
            get { return dList.Count; }
        }

        public Domino Draw()
        {
            return null;
        }
        
        public Domino this[int i]
        {
            get { return dList[i]; }
        }
        
        public override string ToString()
        {
            return "";
        }
        
    }
}
