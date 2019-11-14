using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen.Pattern
{
    public class CijferCodering : ACodering
    {
        public CijferCodering(ICodering codering) : base(codering)
        {
        }

		protected override StringBuilder SpecifiekCodering(StringBuilder zinBuffer)
		{
			StringBuilder result = new StringBuilder();
            for (int i = 0; i < zinBuffer.Length; i++)
            {
                int code = zinBuffer[i];
                result.Append(code);
            }
            return result;
        }
    }
}
