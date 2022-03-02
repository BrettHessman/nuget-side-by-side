using NugetSideBySide.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared.ClientSdk10.Services
{
	public interface ISpecifyVersion10 : IVersionedService
	{
		Version IVersionedService.StrictlyLessThen => new Version(0, 0);
		Version IVersionedService.GreaterThenOrEqualTo => new Version(5, 0);

	}
}
