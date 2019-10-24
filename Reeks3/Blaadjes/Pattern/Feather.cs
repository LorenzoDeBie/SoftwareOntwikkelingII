using System;
using System.Windows;

namespace Blaadjes.Pattern
{
    public class Feather : APicture
    {
        public Feather(string filename) : base(filename) {}

        public override Point Move(Point p)
        {
            p.X = Math.Max(0, p.X - (w / 2)); //altijd halve figuur naar links - nooit negatief
            p.Y = p.Y + h / 2; //altijd halve figuur naar beneden
            return p;
        }
    }
}