using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen.Pattern
{
    public abstract class ACodering : ICodering
    {
        protected ICodering codering;

        /// <summary>
        ///
        /// </summary>
        /// <param name="codering">object om te decoreren</param>
        public ACodering(ICodering codering)
        {
            this.codering = codering;
        }

        /// <summary>
        /// Methode uit interface als abstracte methode.
        /// De verschillende decorators implementeren deze methode.
        /// </summary>
        /// <param name="zin"></param>
        /// <returns></returns>
        public abstract string Codeer(string zin);

    }

}
