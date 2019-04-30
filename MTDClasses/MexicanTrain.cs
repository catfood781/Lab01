using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class MexicanTrain : Train
    {
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return base.IsPlayable(d, out mustFlip);
        }
        public MexicanTrain(int engineValue) : base(engineValue)
        { }
    }
}
