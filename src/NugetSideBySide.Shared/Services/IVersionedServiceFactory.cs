using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared.Services
{
	public interface IVersionedServiceFactory<T> where T : IVersionedService
	{
		T Create(Version version);
	}
}
