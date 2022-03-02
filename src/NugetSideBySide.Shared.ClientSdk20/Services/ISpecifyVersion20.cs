using NugetSideBySide.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared.ClientSdk20.Services
{
	public interface ISpecifyVersion20 : IVersionedService
	{
		Version IVersionedService.StrictlyLessThen => new Version(999, 999);
		Version IVersionedService.GreaterThenOrEqualTo => new Version(6, 0);

	}
}
