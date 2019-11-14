using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen.Pattern
{
    public class WisselCodering : ACodering
    {
        public WisselCodering(ICodering codering) : base(codering)
        {

        }

		protected override StringBuilder SpecifiekCodering(StringBuilder zinBuffer)
		{
			return zinBuffer;
        }
    }
}
