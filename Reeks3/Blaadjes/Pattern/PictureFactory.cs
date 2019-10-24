using System;
using System.Collections.Generic;
using System.Linq;

namespace Blaadjes.Pattern
{
    public class PictureFactory
    {
        //name -- Picture
        private Dictionary<string, IPicture> _pictures = new Dictionary<string, IPicture>();
        
        private Random _random = new Random();

        private string[] SOORTEN =  {"pluim", "blad", "groenBlad", "roodBlad"};
        
        public IPicture this[string name]
        {
            get
            {
                if(!SOORTEN.Contains(name)) throw new ArgumentException("Invalid Picture soort");
                IPicture result;
                if (_pictures.ContainsKey(name))
                {
                    result = _pictures[name];
                }
                else
                {
                    string filename = "images\\" + name + ".png";
                    if (name.Equals("pluim"))
                    {
                        result = new Feather(@filename);
                    }
                    else
                    {
                        result = new Leaf(@filename);
                    }
                    _pictures.Add(name, result);
                }

                return result;
            }
        }

        public IPicture kiesBlad()
        {
            return this[SOORTEN[_random.Next(SOORTEN.Length - 2) + 1]];
        }
        
        
    }
}