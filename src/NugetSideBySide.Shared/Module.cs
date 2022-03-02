using Autofac;
using NugetSideBySide.Shared.Impl;
using NugetSideBySide.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared
{
	public static class Module
	{
		public static void Register(ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterType<TypicalService>()
				.As<ITypicalServiceAbstraction>()
				.SingleInstance();

			containerBuilder.RegisterGeneric(typeof(SimpleVersionedServiceFactory<>))
				.As(typeof(IVersionedServiceFactory<>))
				.SingleInstance();


		}
	}
}
