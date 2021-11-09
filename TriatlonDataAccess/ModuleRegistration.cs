using System;
using System.Collections.Generic;
using System.Text;
using TriatlonDataAccess.Context;
using TriatlonDataAccess.Interfaces;
using TriatlonDataAccess.Repositories;
using Unity;

namespace TriatlonDataAccess
{
	public class ModuleRegistration
	{
		private readonly UnityContainer _unityContainer;

		public ModuleRegistration(UnityContainer unityContainer)
		{
			_unityContainer = unityContainer;
		}

		public void Register()
		{
			_unityContainer.RegisterType<TriatlonContext>();

			_unityContainer.RegisterType<IKoridoRepository, KoridoRepository>();
			_unityContainer.RegisterType<IVersenyRepository, VersenyRepository>();
			_unityContainer.RegisterType<IVersenyVersenyzoRepository, VersenyVersenyzoRepository>();
			_unityContainer.RegisterType<IVersenyzoRepository, VersenyzoRepository>();
			
		}
	}
}
