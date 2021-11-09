using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriatlonCore.DependencyInjection;
using TriatlonDataAccess.Interfaces;
using TriatlonLogic.Models;

namespace TriatlonLogic.Managers
{
	public class VersenyzoManager
	{
		public List<Versenyzo> GetAll()
		{
			var versenyzoRepository = TDI.Resolve<IVersenyzoRepository>();
			var versenyzoList = versenyzoRepository.GetAll().ToList();

			return versenyzoList;
		}

		public Versenyzo Get(long oid)
		{
			var versenyzoRepository = TDI.Resolve<IVersenyzoRepository>();
			var versenyzo = versenyzoRepository.Get(oid);
			return versenyzo;
		}

		public void Update(Versenyzo tempVersenyzo)
		{
			var versenyzoRepository = TDI.Resolve<IVersenyzoRepository>();
			var versenyzo = versenyzoRepository.Get(tempVersenyzo.OID);
			versenyzo.Nev = tempVersenyzo.Nev;
			versenyzo.Nem = tempVersenyzo.Nem;
			versenyzo.SzulIdo = tempVersenyzo.SzulIdo;
			versenyzo.Egyesulet = tempVersenyzo.Egyesulet;
			versenyzo.Licence = tempVersenyzo.Licence;
			versenyzoRepository.Update(versenyzo);
		}

		public long Add(Versenyzo versenyzo)
		{
			var versenyzoRepository = TDI.Resolve<IVersenyzoRepository>();
			var oid = versenyzoRepository.Add(versenyzo);
			return oid;
		}

		public void Delete(long oid)
		{
			var versenyzoRepository = TDI.Resolve<IVersenyzoRepository>();
			var versenyzo = versenyzoRepository.Get(oid);

			versenyzoRepository.Delete(versenyzo);
		}

		public void SetDeleted(long oid)
		{
			var versenyzoRepository = TDI.Resolve<IVersenyzoRepository>();
			var versenyzo = versenyzoRepository.Get(oid);

			versenyzo.Nev = string.Empty;
			versenyzo.Nem = string.Empty;
			versenyzo.SzulIdo = DateTime.MinValue;
			versenyzo.Egyesulet = string.Empty;
			versenyzo.Licence = string.Empty;

			versenyzoRepository.Update(versenyzo);
		}
	}
}
