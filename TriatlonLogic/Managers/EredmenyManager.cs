﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
			eredmenyDisplayDto.UszasIdo = eredmeny.UszasIdo;
			eredmenyDisplayDto.Depo1Ido = eredmeny.Depo1Ido;
			eredmenyDisplayDto.KerekparIdo = eredmeny.KerekparIdo;
			eredmenyDisplayDto.Depo2Ido = eredmeny.Depo2Ido;
			eredmenyDisplayDto.FutasIdo = eredmeny.FutasIdo;

			eredmenyDisplayDto.VersenyzoNev = versenyzo.Nev;
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
			eredmeny.UszasIdo = tempEredmeny.UszasIdo;
			eredmeny.Depo1Ido = tempEredmeny.Depo1Ido;
			eredmeny.KerekparIdo = tempEredmeny.KerekparIdo;
			eredmeny.Depo2Ido = tempEredmeny.Depo2Ido;
			eredmeny.FutasIdo = tempEredmeny.FutasIdo;

			eredmenyRepository.Update(eredmeny);
		}

		public void Delete(long oid)
		{
			var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
			var eredmeny = eredmenyRepository.Get(oid);

			eredmenyRepository.Delete(eredmeny);
		}

		public void SetDeleted(long oid)
		{
			var eredmenyRepository = TDI.Resolve<IVersenyVersenyzoRepository>();
			var eredmeny = eredmenyRepository.Get(oid);

			eredmeny.ChipKod = string.Empty;
			eredmeny.UszasIdo = TimeSpan.MinValue;
			eredmeny.Depo1Ido = TimeSpan.MinValue;
			eredmeny.KerekparIdo = TimeSpan.MinValue;
			eredmeny.Depo2Ido = TimeSpan.MinValue;
			eredmeny.FutasIdo = TimeSpan.MinValue;

			eredmenyRepository.Update(eredmeny);
		}
	}
}
