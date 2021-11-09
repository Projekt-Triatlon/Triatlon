using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace TriatlonCore.DependencyInjection
{
	public static class TDI
	{
		private static UnityContainer _di;
		public static UnityContainer DI
		{
			get
			{
				return _di;
			}
			set
			{
				_di = value;
			}
		}

		public static T Resolve<T>() where T : class
		{
			UnityContainer container = DI;
			return container?.Resolve<T>();
		}

		public static T Resolve<T>(string name) where T : class
		{
			UnityContainer container = DI;
			return container?.Resolve<T>(name);
		}
	}
}
