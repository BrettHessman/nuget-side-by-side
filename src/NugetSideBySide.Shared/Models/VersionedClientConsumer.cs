using System;
using System.Collections.Generic;
using System.Text;

namespace NugetSideBySide.Shared.Models
{
	public class VersionedClientConsumer
	{
		public string ConsumerName { get; set; }
		public Version ConsumerVerison { get; set; }
	}
}
