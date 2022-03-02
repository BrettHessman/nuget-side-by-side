using NugetSideBySide.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared.Services
{
	public interface ITypicalServiceAbstraction
	{
		string DoTypicalBehavior(VersionedClientConsumer versionedClientConsumer);
	}
}
