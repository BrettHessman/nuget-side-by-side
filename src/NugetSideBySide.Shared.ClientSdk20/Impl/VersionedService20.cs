extern alias RMQ6;

using RMQ6::RabbitMQ.Client;

using NugetSideBySide.Shared.ClientSdk20.Services;
using NugetSideBySide.Shared.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NugetSideBySide.Shared.Models;

namespace NugetSideBySide.Shared.ClientSdk20.Impl
{
	internal class VersionedService20 : IVersionedServiceAbstraction, ISpecifyVersion20
	{

		public string GetSpecialResult(VersionedClientConsumer versionedClientConsumer)
		{
			return $"{versionedClientConsumer.ConsumerName} is Using RabbitMQ.AmqpTcpEndpoint version:  {Assembly.GetAssembly(typeof(AmqpTcpEndpoint)).GetName().Version}";
		}
	}
}
