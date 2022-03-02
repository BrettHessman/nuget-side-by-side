using Autofac;
using NugetSideBySide.Shared.Models;
using NugetSideBySide.Shared.Services;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NugetSideBySide.App
{
	class Program
	{
		private readonly static Assembly RabbitMQ5Asm = Assembly.LoadFile($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/ClientSdk10/RabbitMQ.Client.dll");
		private readonly static Assembly RabbitMQ6Asm = Assembly.LoadFile($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/ClientSdk20/RabbitMQ.Client.dll");

		static void Main(string[] args)
		{
			Console.WriteLine("Bootstrap");
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

			var containerBuilder = new ContainerBuilder();

			Shared.Module.Register(containerBuilder);
			Shared.ClientSdk10.Module.Register(containerBuilder);
			Shared.ClientSdk20.Module.Register(containerBuilder);

			Console.WriteLine("Simulated Execution");

			var client1 = new VersionedClientConsumer { ConsumerName = "Old Clients", ConsumerVerison = new Version(3, 22) }; // --> should resolve to RabbitMqClient V5
			var client2 = new VersionedClientConsumer { ConsumerName = "Newer Clients", ConsumerVerison = new Version(7, 39) };// --> should resolve to RabbitMqClient V6


			using var container = containerBuilder.Build();
			using var scope = container.BeginLifetimeScope();

			var typicalService = scope.Resolve<ITypicalServiceAbstraction>();

			Console.WriteLine(typicalService.DoTypicalBehavior(client1));
			Console.WriteLine(typicalService.DoTypicalBehavior(client2));

			_ = Console.ReadKey();
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			// Obviously do error checking here
			var parts = args.Name.Split(", ");
			var versionPart = parts
				.Single(x => x.Contains("Version=", StringComparison.OrdinalIgnoreCase))
				.Replace("Version=", string.Empty, StringComparison.OrdinalIgnoreCase);
			var version = Version.Parse(versionPart);

			switch(parts[0])
			{
				case "RabbitMQ.Client":
					if (version.Major == 5)
					{
						return RabbitMQ5Asm;
					}
					else if(version.Major == 6)
					{
						return RabbitMQ6Asm;
					}
					else
					{
						return null;
					}
				case "other assemblies":
					if (version.Major == 6)
					{
						return null;
					}
					else
					{
						return null;
					}
				default:
					return null;
			}

		}
	}
}
