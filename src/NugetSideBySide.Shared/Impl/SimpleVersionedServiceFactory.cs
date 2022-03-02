using Autofac;
using NugetSideBySide.Shared.Services;
using System;
using System.Linq;

namespace NugetSideBySide.Shared.Impl
{
	internal class SimpleVersionedServiceFactory<T> : IVersionedServiceFactory<T> where T : IVersionedService
	{
		private readonly ILifetimeScope lifetimeScope;

		public SimpleVersionedServiceFactory(ILifetimeScope lifetimeScope)
		{
			this.lifetimeScope = lifetimeScope;
		}

		public T Create(Version version)
		{
			var availableTypes = lifetimeScope.Resolve<T[]>();

			// Do error checking and not this.
			return availableTypes.Single(x => version >= x.GreaterThenOrEqualTo && version < x.StrictlyLessThen);
		}
	}
}
