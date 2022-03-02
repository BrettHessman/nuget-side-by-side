extern alias RMQ5;

using RMQ5::RabbitMQ.Client;

using NugetSideBySide.Shared.ClientSdk10.Services;
using NugetSideBySide.Shared.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NugetSideBySide.Shared.Models;

namespace NugetSideBySide.Shared.ClientSdk10.Impl
{
	internal class VersionedService10 : IVersionedServiceAbstraction, ISpecifyVersion10
	{

		public string GetSpecialResult(VersionedClientConsumer versionedClientConsumer)
		{
			return $"{versionedClientConsumer.ConsumerName} is Using RabbitMQ.AmqpTcpEndpoint version:  {Assembly.GetAssembly(typeof(AmqpTcpEndpoint)).GetName().Version}";
		}
	}
}
