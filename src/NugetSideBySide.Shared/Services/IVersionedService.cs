using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared.Services
{
	public interface IVersionedService
	{
		Version StrictlyLessThen { get; }
		Version GreaterThenOrEqualTo { get; }
	}
}
