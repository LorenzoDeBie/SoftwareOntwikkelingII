using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.pattern.Email2State
{
	class I2Status : AStatus
	{

		public I2Status(IValidationBehaviour behaviour) : base(behaviour) { }

		public override void At()
		{
			throw new NotImplementedException();
		}

		public override void Punt()
		{
			throw new NotImplementedException();
		}

		public override void Woord()
		{
			throw new NotImplementedException();
		}
	}
}
