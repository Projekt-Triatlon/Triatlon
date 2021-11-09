using System;
using System.Collections.Generic;
using System.Text;
using TriatlonLogic.Managers;
using Unity;

namespace TriatlonLogic
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
			_unityContainer.RegisterType<VersenyManager>();
			_unityContainer.RegisterType<VersenyzoManager>();
			_unityContainer.RegisterType<EredmenyManager>();


		}
	}

}
