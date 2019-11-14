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
		public string Codeer(string zin)
		{
			//algemene shit
			zin = codering.Codeer(zin);
			// kleine letters
			zin = zin.ToLower();
			// spaties verwijderen
			StringBuilder zinBuffer = SpatieVerwijderen(zin);
			// lengte even maken
			zinBuffer = MaakEven(zinBuffer);
			// speciale tekens vervangen
			zinBuffer = VerwijderSpecialeTekens(zinBuffer);

			//specifieke shit
			return SpecifiekCodering(zinBuffer).ToString();
		}

		protected abstract StringBuilder SpecifiekCodering(StringBuilder zinBuffer);


		private StringBuilder MaakEven(StringBuilder zinBuffer)
		{
			// lengte even?
			if (zinBuffer.Length % 2 != 0)
			{
				zinBuffer.Length--;
			}
			return zinBuffer;
		}

		private StringBuilder SpatieVerwijderen(string zin)
		{
			string[] woorden = zin.Split(' ');
			// spaties in zin vervangen door 0
			StringBuilder zinBuffer = new StringBuilder();
			foreach (string woord in woorden)
			{
				zinBuffer.Append(woord);
				zinBuffer.Append('0');
			}
			return zinBuffer;
		}

		private StringBuilder VerwijderSpecialeTekens(StringBuilder zinBuffer)
		{
			// verwijder speciale tekens
			for (int i = 0; i < zinBuffer.Length; i++)
			{
				if (!char.IsLower(zinBuffer[i])
						&& !char.IsDigit(zinBuffer[i]))
				{
					zinBuffer[i] = '0';
				}
			}
			return zinBuffer;
		}
	}

}
