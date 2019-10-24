using System;
using System.Windows;

namespace Blaadjes.Pattern
{
    public class Leaf : APicture
    {
        public Leaf(string filename) : base(filename) {}
        
        public override Point Move(Point p)
        {
            int richting = new Random().Next(3) - 1;
            p.X = Math.Max(0, p.X + richting * (w / 2)); //nooit negatief
            p.Y = p.Y +  h / 2; //altijd halve figuur naar beneden
            return p;
        }
    }
}