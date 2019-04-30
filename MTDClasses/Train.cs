using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTDClasses
{
    /// <summary>
    /// Represents a generic Train for MTD
    /// </summary>
    public abstract class Train
    {
        protected List<Domino> dominos;
        protected int engineValue;
        
        public Train()
        {
            engineValue = 12;
            dominos = new List<Domino>();
        }

        public Train(int engValue)
        {
            engineValue = engValue;
            dominos = new List<Domino>();
        }

        public int Count
        {
            get { return dominos.Count; }
        }

        /// <summary>
        /// The first domino value that must be played on a train
        /// </summary>
        public int EngineValue
        {
            get { return engineValue; }
            set { engineValue = value; }
        }

        public bool IsEmpty
        {
            get { return dominos.Count == 0; }
        }

        public Domino LastDomino
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }
                return dominos[dominos.Count - 1];
            }
        }

        /// <summary>
        /// Side2 of the last domino in the train.  It's the value of the next domino that can be played.
        /// </summary>
        public int PlayableValue
        {
            get
            {
                if (IsEmpty)
                {
                    return engineValue;
                }
                return LastDomino.Side2;
            }
        }

        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        public Domino this[int index]
        {
            get
            {
                if (index < 0 || index >= dominos.Count)
                {
                    throw new Exception("dummy");
                }
                return dominos[index];
            }
        }

        /// <summary>
        /// Determines whether a hand can play a specific domino on this train and if the domino must be flipped.
        /// Because the rules for playing are different for Mexican and Player trains, this method is abstract.
        /// </summary>
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        /// <summary>
        /// A helper method that determines whether a specific domino can be played on this train.
        /// It can be called in the Mexican and Player train class implementations of the abstract method
        /// </summary>
        protected bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (IsEmpty)
            {
                if (engineValue == d.Side1)
                {
                    mustFlip = false;
                    return true;
                }
                else if (engineValue == d.Side2)
                {
                    mustFlip = true;
                    return true;
                }
                else
                {
                    mustFlip = false;
                    return false;
                }
            }
            else
            {
                Domino last = LastDomino;
                if (last.Side2 == d.Side1)
                {
                    mustFlip = false;
                    return true;
                }
                else if (last.Side2 == d.Side2)
                {
                    mustFlip = true;
                    return true;
                }
                else
                {
                    mustFlip = false;
                    return false;
                }
            }
            //This isnt in Mari's code but I got a run time error if I didnt add it
            //return true;
            //Fixed it. I missed the return true in the else if statement.
        }

        // assumes the domino has already been removed from the hand
        public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;
            if (IsPlayable(h, d, out mustFlip))
            {
                if (mustFlip)
                {
                    //raise the event
                    d.Flip();
                }
                Add(d);
            }
            else
            {
                throw new Exception("Domino" + d.ToString() + " does not match last domino.");
            }
        }

        public override string ToString()
        {
            string output = "";
            foreach (Domino d in dominos)
            {
                output += d.ToString() + "\t";
            }
            output += "\n";
            return output;
        }
    }
}