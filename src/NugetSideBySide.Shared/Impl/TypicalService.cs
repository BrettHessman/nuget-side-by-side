using NugetSideBySide.Shared.Models;
using NugetSideBySide.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared.Impl
{
	internal class TypicalService : ITypicalServiceAbstraction
	{
		private readonly IVersionedServiceFactory<IVersionedServiceAbstraction> versionedServiceFactory;

		public TypicalService(IVersionedServiceFactory<IVersionedServiceAbstraction> versionedServiceFactory)
		{
			this.versionedServiceFactory = versionedServiceFactory;
		}

		public string DoTypicalBehavior(VersionedClientConsumer versionedClientConsumer)
		{
			var versionedService = versionedServiceFactory.Create(versionedClientConsumer.ConsumerVerison);

			return versionedService.GetSpecialResult(versionedClientConsumer);
		}
	}
}
