using Autofac;
using NugetSideBySide.Shared.ClientSdk20.Impl;
using NugetSideBySide.Shared.Services;
using System;

namespace NugetSideBySide.Shared.ClientSdk20
{
	public static class Module
	{
		public static void Register(ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterType<VersionedService20>()
				.As<IVersionedServiceAbstraction>()
				.SingleInstance();

		}

		public static void Main()
		{
			throw new Exception("This executable does nothing and should not be called for any reason.");
		}
	}
}
