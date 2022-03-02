using Autofac;
using NugetSideBySide.Shared.Models;
using NugetSideBySide.Shared.Services;
using System;

namespace NugetSideBySide.App
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Bootstrap");

			var containerBuilder = new ContainerBuilder();

			Shared.Module.Register(containerBuilder);
			Shared.ClientSdk10.Module.Register(containerBuilder);
			Shared.ClientSdk20.Module.Register(containerBuilder);

			Console.WriteLine("Simulated Execution");

			var client1 = new VersionedClientConsumer { ConsumerName = "Old Clients", ConsumerVerison = new Version(3, 22) };
			var client2 = new VersionedClientConsumer { ConsumerName = "Newer Clients", ConsumerVerison = new Version(7, 39) };


			using var container = containerBuilder.Build();
			using var scope = container.BeginLifetimeScope();

			var typicalService = scope.Resolve<ITypicalServiceAbstraction>();

			typicalService.DoTypicalBehavior(client1);
			typicalService.DoTypicalBehavior(client2);

		}
	}
}
