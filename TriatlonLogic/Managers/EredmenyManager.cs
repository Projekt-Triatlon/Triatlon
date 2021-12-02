using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriatlonCore.DependencyInjection;
using TriatlonDataAccess.Interfaces;
using TriatlonLogic.DataTransferObjects;
using TriatlonLogic.Models;

namespace TriatlonLogic.Managers
{
	public class EredmenyManager
	{
		public List<VersenyVersenyzo> GetAll()
		{
			var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
			var eredmenyList = eredmenyRepository.GetAll().ToList();

			return eredmenyList;
		}

		public List<VersenyVersenyzo> GetSelected(string oid, string nem, string kategoria)
		{
			DateTime startDate;
			DateTime endDate;
			switch (kategoria)
			{
				case "AbszÖssz":
					startDate = Convert.ToDateTime("1900.01.01");
					endDate = Convert.ToDateTime("2200.01.01");
					break;
				case "Össz":
					startDate = Convert.ToDateTime("1900.01.01");
					endDate = Convert.ToDateTime("2200.01.01");
					break;
				case "Újonc1":
					startDate = Convert.ToDateTime("2012.01.01");
					endDate = Convert.ToDateTime("2013.12.31");
					break;
				case "Újonc2":
					startDate = Convert.ToDateTime("2010.01.01");
					endDate = Convert.ToDateTime("2011.12.31");
					break;
				case "Gyermek":
					startDate = Convert.ToDateTime("2008.01.01");
					endDate = Convert.ToDateTime("2009.12.31");
					break;
				case "Serdülő":
					startDate = Convert.ToDateTime("2006.01.01");
					endDate = Convert.ToDateTime("2007.12.31");
					break;
				case "Ifjúsági":
					startDate = Convert.ToDateTime("2004.01.01");
					endDate = Convert.ToDateTime("2005.12.31");
					break;
				case "Junior":
					startDate = Convert.ToDateTime("2002.01.01");
					endDate = Convert.ToDateTime("2003.12.31");
					break;
				case "Felnőtt1":
					startDate = Convert.ToDateTime("1997.01.01");
					endDate = Convert.ToDateTime("2003.12.31");
					break;
				case "Felnőtt2":
					startDate = Convert.ToDateTime("1992.01.01");
					endDate = Convert.ToDateTime("1996.12.31");
					break;
				case "Felnőtt3":
					startDate = Convert.ToDateTime("1987.01.01");
					endDate = Convert.ToDateTime("1991.12.31");
					break;
				case "Felnőtt4":
					startDate = Convert.ToDateTime("1982.01.01");
					endDate = Convert.ToDateTime("1986.12.31");
					break;
				case "Szenior1":
					startDate = Convert.ToDateTime("1977.01.01");
					endDate = Convert.ToDateTime("1981.12.31");
					break;
				case "Szenior2":
					startDate = Convert.ToDateTime("1972.01.01");
					endDate = Convert.ToDateTime("1976.12.31");
					break;
				case "Szenior3":
					startDate = Convert.ToDateTime("1967.01.01");
					endDate = Convert.ToDateTime("1971.12.31");
					break;
				case "Szenior4":
					startDate = Convert.ToDateTime("1962.01.01");
					endDate = Convert.ToDateTime("1966.12.31");
					break;
				case "Veterán1":
					startDate = Convert.ToDateTime("1957.01.01");
					endDate = Convert.ToDateTime("1961.12.31");
					break;
				case "Veterán2":
					startDate = Convert.ToDateTime("1952.01.01");
					endDate = Convert.ToDateTime("1956.12.31");
					break;
				case "Veterán3":
					startDate = Convert.ToDateTime("1947.01.01");
					endDate = Convert.ToDateTime("1951.12.31");
					break;
				case "Veterán4":
					startDate = Convert.ToDateTime("1942.01.01");
					endDate = Convert.ToDateTime("1946.12.31");
					break;
				case "Veterán5":
					startDate = Convert.ToDateTime("1900.01.01");
					endDate = Convert.ToDateTime("1941.12.31");
					break;
				case "ElitU23":
					startDate = Convert.ToDateTime("1998.01.01");
					endDate = Convert.ToDateTime("2001.12.31");
					break;
				case "Elit":
					startDate = Convert.ToDateTime("1900.01.01");
					endDate = Convert.ToDateTime("2001.12.31");
					break;
				default:
					startDate = Convert.ToDateTime("1900.01.01");
					endDate = Convert.ToDateTime("2200.12.31");
					break;
			}



			var szam = Convert.ToInt32(oid);
			if (nem != null)
			{
				if (kategoria != null)
				{
					var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
					var eredmenyList = eredmenyRepository.GetAll()
						.Include(x => x.Verseny)
						.Include(y => y.Versenyzo)
						.Where(x => x.VersenyOID == szam)
						.Where(x => x.Versenyzo.Nem == nem)
						.Where(x=>x.Versenyzo.SzulIdo >= startDate && x.Versenyzo.SzulIdo<=endDate)
						.OrderBy(x => x.CelIdo)
						.ToList();

					return eredmenyList;
				}
				else
				{
					var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
					var eredmenyList = eredmenyRepository.GetAll()
						.Include(x => x.Verseny)
						.Include(y => y.Versenyzo)
						.Where(x => x.VersenyOID == szam)
						.Where(x => x.Versenyzo.Nem == nem)
						.OrderBy(x => x.CelIdo)
						.ToList();

					return eredmenyList;
				}
			}
			else 
			{
				if (kategoria != null)
				{
					var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
					var eredmenyList = eredmenyRepository.GetAll()
						.Include(x => x.Verseny)
						.Include(y => y.Versenyzo)
						.Where(x => x.VersenyOID == szam)
						.Where(x => x.Versenyzo.SzulIdo >= startDate && x.Versenyzo.SzulIdo <= endDate)
						.OrderBy(x => x.CelIdo)
						.ToList();

					return eredmenyList;
				}
				else 
				{
					var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
					var eredmenyList = eredmenyRepository.GetAll()
						.Include(x => x.Verseny)
						.Include(x => x.Versenyzo)
						.Where(x => x.VersenyOID == szam)
						.OrderBy(x => x.CelIdo)
						.ToList();
					return eredmenyList;
				}
				
			}

			

		}


		public EredmenyCreateDto GetEredmenyCreateDto()
		{
			var versenyzoRepository = TDI.Resolve<IVersenyzoRepository>();
			var versenyRepository = TDI.Resolve<IVersenyRepository>();

			var result = new EredmenyCreateDto();

			var versenyzok = versenyzoRepository.GetAll();
			var versenyek = versenyRepository.GetAll();

			var versenyzoSelectList = versenyzok
										.Select(x => new SelectListItem()
										{
											Text = x.Nev,
											Value = x.OID.ToString()
										})
										.ToList();
			var versenySelectList = versenyek
										.Select(x => new SelectListItem()
										{
											Text = x.Nev,
											Value = x.OID.ToString()
										})
										.ToList();

			result.VersenySelectList = versenySelectList;
			result.VersenyzoSelectList = versenyzoSelectList;


			return result;
		}

		public EredmenySelectDto GetEredmenySelectDto()
		{
			var versenyRepository = TDI.Resolve<IVersenyRepository>();
			var versenyek = versenyRepository.GetAll();

			var result = new EredmenySelectDto();

			var versenySelectList = versenyek
										.Select(x => new SelectListItem()
										{
											Text = x.Nev,
											Value = x.OID.ToString()
										})
										.ToList();

			result.VersenySelectList = versenySelectList;


			return result;
		}

		public VersenyVersenyzo Get(long oid)
		{
			var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
			var eredmeny = eredmenyRepository.Get(oid);
			return eredmeny;
		}

		public EredmenyDisplayDto GetEredmenyDisplayDto(long oid)
		{
			var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
			var eredmeny = eredmenyRepository.Get(oid);

			var versenyzoRepository = TDI.Resolve<IVersenyzoRepository>();
			var versenyzo = versenyzoRepository.Get(eredmeny.VersenyzoOID);

			var versenyRepository = TDI.Resolve<IVersenyRepository>();
			var verseny = versenyRepository.Get(eredmeny.VersenyOID);


			var eredmenyDisplayDto = new EredmenyDisplayDto();
			eredmenyDisplayDto.OID = eredmeny.OID;
			eredmenyDisplayDto.ChipKod = eredmeny.ChipKod;
			eredmenyDisplayDto.Rajtszam = eredmeny.Rajtszam;
			eredmenyDisplayDto.UszasIdo = eredmeny.UszasIdo;
			eredmenyDisplayDto.Depo1Ido = eredmeny.Depo1Ido;
			eredmenyDisplayDto.KerekparIdo = eredmeny.KerekparIdo;
			eredmenyDisplayDto.Depo2Ido = eredmeny.Depo2Ido;
			eredmenyDisplayDto.FutasIdo = eredmeny.FutasIdo;
			eredmenyDisplayDto.CelIdo = eredmeny.CelIdo;
			eredmenyDisplayDto.AbszolutHelyezes = eredmeny.AbszolutHelyezes;

			eredmenyDisplayDto.UszasHelyezes = eredmeny.UszasHelyezes;
			eredmenyDisplayDto.Depo1Helyezes = eredmeny.Depo1Helyezes;
			eredmenyDisplayDto.KerekparHelyezes = eredmeny.KerekparHelyezes;
			eredmenyDisplayDto.Depo2Helyezes = eredmeny.Depo2Helyezes;
			eredmenyDisplayDto.FutasHelyezes = eredmeny.FutasHelyezes;

			eredmenyDisplayDto.VersenyzoNev = versenyzo.Nev;
			eredmenyDisplayDto.Egyesulet = versenyzo.Egyesulet;
			eredmenyDisplayDto.VersenyNev = verseny.Nev;

			return eredmenyDisplayDto;
		}

		public long Add(VersenyVersenyzo eredmeny)
		{
			var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
			var oid = eredmenyRepository.Add(eredmeny);
			return oid;
		}

		public void Update(VersenyVersenyzo tempEredmeny)
		{
			var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
			var eredmeny = eredmenyRepository.Get(tempEredmeny.OID);
			eredmeny.ChipKod = tempEredmeny.ChipKod;
			eredmeny.Rajtszam = tempEredmeny.Rajtszam;
			eredmeny.UszasIdo = tempEredmeny.UszasIdo;
			eredmeny.Depo1Ido = tempEredmeny.Depo1Ido;
			eredmeny.KerekparIdo = tempEredmeny.KerekparIdo;
			eredmeny.Depo2Ido = tempEredmeny.Depo2Ido;
			eredmeny.FutasIdo = tempEredmeny.FutasIdo;
			eredmeny.CelIdo = tempEredmeny.CelIdo;
			eredmeny.AbszolutHelyezes = tempEredmeny.AbszolutHelyezes;
			eredmeny.UszasHelyezes = tempEredmeny.UszasHelyezes;
			eredmeny.Depo1Helyezes = tempEredmeny.Depo1Helyezes;
			eredmeny.KerekparHelyezes = tempEredmeny.KerekparHelyezes;
			eredmeny.Depo2Helyezes = tempEredmeny.Depo2Helyezes;
			eredmeny.FutasHelyezes = tempEredmeny.FutasHelyezes;

			eredmenyRepository.Update(eredmeny);
		}

		public void Delete(long oid)
		{
			var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
			var eredmeny = eredmenyRepository.Get(oid);

			eredmenyRepository.Delete(eredmeny);
		}

	}
}
