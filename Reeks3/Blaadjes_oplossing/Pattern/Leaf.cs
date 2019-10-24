using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Blaadjes.Pattern
{
    public class Leaf : AImage
    {
        private Random random = new Random();
        
        public Leaf(string bestandsnaam) : base(bestandsnaam)
        {
           
        }

        public override Point Move(Point p)
        {
            int richting = random.Next(3)-1; //-1,O of 1
            p.X = Math.Max(0, p.X + richting * (w / 2)); //nooit negatief
            p.Y = p.Y +  h / 2; //altijd halve figuur naar beneden
            return p;
        }
    }
}
