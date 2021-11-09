using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TouristLogic.DataTransferObjects;
using TriatlonCore.DependencyInjection;
using TriatlonDataAccess.Interfaces;
using TriatlonLogic.Models;

namespace TriatlonLogic.Managers
{
	public class VersenyManager
	{
		public List<Verseny> GetAll()
		{
			var versenyRepository = TDI.Resolve<IVersenyRepository>();
			var versenyek = versenyRepository.GetAll().ToList();
			return versenyek;
		}

		public Verseny Get(long oid)
		{
			var versenyRepository = TDI.Resolve<IVersenyRepository>();
			var verseny = versenyRepository.Get(oid);
			return verseny;
		}

		public VersenyCreateDto GetVersenyCreateDto()
		{
			var result = new VersenyCreateDto();
			return result;
		}

		public long Add(Verseny verseny)
		{
			var versenyRepository = TDI.Resolve<IVersenyRepository>();
			var oid = versenyRepository.Add(verseny);
			return oid;
		}

		public void Update(Verseny tempVerseny)
		{
			var versenyRepository = TDI.Resolve<IVersenyRepository>();
			var verseny = versenyRepository.Get(tempVerseny.OID);
			verseny.Nev = tempVerseny.Nev;
			verseny.Datum = tempVerseny.Datum;
			verseny.UTavolsag = tempVerseny.UTavolsag;
			verseny.UKorokSzama = tempVerseny.UKorokSzama;
			verseny.UTipus = tempVerseny.UTipus;
			verseny.UNeopren = tempVerseny.UNeopren;
			verseny.UMelyseg = tempVerseny.UMelyseg;
			verseny.UVizHofok = tempVerseny.UVizHofok;
			verseny.UHullamzas = tempVerseny.UHullamzas;
			verseny.USzel = tempVerseny.USzel;
			verseny.UCsapadek = tempVerseny.UCsapadek;
			verseny.ULevegoHomerseklet = tempVerseny.ULevegoHomerseklet;
			verseny.ULevegoParatartalom = tempVerseny.ULevegoParatartalom;
			verseny.KTavolsag = tempVerseny.KTavolsag;
			verseny.KMinoseg = tempVerseny.KMinoseg;
			verseny.KSzintemelkedes = tempVerseny.KSzintemelkedes;
			verseny.KKorokSzama = tempVerseny.KKorokSzama;
			verseny.KSzel = tempVerseny.KSzel;
			verseny.KCsapadek = tempVerseny.KCsapadek;
			verseny.KLevegoHomerseklet = tempVerseny.KLevegoHomerseklet;
			verseny.KLevegoParatartalom = tempVerseny.KLevegoParatartalom;
			verseny.FTavolsag = tempVerseny.FTavolsag;
			verseny.FMinoseg = tempVerseny.FMinoseg;
			verseny.FSzintemelkedes = tempVerseny.FSzintemelkedes;
			verseny.FKorokSzama = tempVerseny.FKorokSzama;
			verseny.FSzel = tempVerseny.FSzel;
			verseny.FCsapadek = tempVerseny.FCsapadek;
			verseny.FLevegoHomerseklet = tempVerseny.FLevegoHomerseklet;
			verseny.FLevegoParatartalom = tempVerseny.FLevegoParatartalom;

			versenyRepository.Update(verseny);
		}

		public void Delete(long oid)
		{
			var versenyRepository = TDI.Resolve<IVersenyRepository>();
			var verseny = versenyRepository.Get(oid);

			versenyRepository.Delete(verseny);
		}
	}
}
