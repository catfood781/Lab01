using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Domino class. Establishes a two sided
    /// domino with dots numbering between 0 
    /// and 12
    /// </summary>
    [Serializable()]
    public class Domino : ICloneable
    {
        private int side1;
        private int side2;

        public Domino()
        {
            side1 = 0;
            side2 = 0;
        }

        public Domino(int p1, int p2)
        {
            side1 = p1;
            side2 = p2;
        }

        // don't use an auto implemented property because of the validation in the setter - p 390
        public int Side1
        {
            get { return side1; }
            set
            {
                if (value >= 0 && value <= 12)
                {
                    side1 = value;
                }
                else
                {
                    throw new ArgumentException("Number of dots must be between 0 and 12");
                }
                side1 = value;
            }
        }


        public int Side2
        {
            get { return side2; }
            set
            {
                if (value >= 0 && value <= 12)
                {
                    side2 = value;
                }
                else
                {
                    throw new ArgumentException("Number of dots must be between 0 and 12");
                }
                side2 = value;
            }
        }

        public void Flip()
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        /// This is how I would have done this in 233N
        public int Score
        {
            get { return side1 + side2; }
        }

        // because it's a read only property, I can use the "expression bodied syntax" or a lamdba expression - p 393
        //public int Score => side1 + side2;

        //ditto for the first version of this method and the next one
        public bool IsDouble()
        {
            if (side1 == side2)
            {
                return true;
            }
            return false;
        }

        // could you do this one using a lambda expression?
        public string Filename
        {
            get
            {
                return String.Format("d{0}{1}.png", side1, side2);
            }
        }

        //public bool IsDouble() => (side1 == side2) ? true : false;

        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", side1, side2);
        }

        // could you overload the == and != operators?
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            //IDK if this is right. Everything I found in the book plus online had a line refrencing the class like this but I'm not sure about 
            // the "d" part. Everything else in this method I'm confident about. 
            Domino d = (Domino)obj;
            if (this.Side1 == d.Side1 && this.Side2 == d.side2)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public object Clone()
        {
            //This is what Mari did in class but it greys out
            //my code when it's not commented out
            //throw new NotImplementedException();
            //Here's my attempt to do what I think we were asked to do
            //from class
            Domino d = new Domino();
            d.Side1 = this.Side1;
            d.Side2 = this.Side2;
            return d;
        }
        
    }
}
