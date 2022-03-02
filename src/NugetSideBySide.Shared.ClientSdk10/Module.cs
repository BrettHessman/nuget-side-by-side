using Autofac;
using NugetSideBySide.Shared.ClientSdk10.Impl;
using NugetSideBySide.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared.ClientSdk10
{
	public static class Module
	{
		public static void Register(ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterType<VersionedService10>()
				.As<IVersionedServiceAbstraction>()
				.SingleInstance();

		}

		public static void Main()
		{
			throw new Exception("This executable does nothing and should not be called for any reason.");
		}
	}


}
