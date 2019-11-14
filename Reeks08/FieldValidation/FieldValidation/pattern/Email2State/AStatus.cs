using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidation.pattern.Email2State
{
	abstract class AStatus : IStatus
	{
		protected IValidationBehaviour behaviour;

		//DI validation
		public AStatus(IValidationBehaviour behaviour)
		{
			this.behaviour = behaviour;
		}

		public abstract void At();
		public abstract void Punt();
		public abstract void Woord();
	}
}
