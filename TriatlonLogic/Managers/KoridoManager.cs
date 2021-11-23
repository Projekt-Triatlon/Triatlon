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
	public class KoridoManager
	{
		public List<Korido> GetAll()
		{
			var koridoRepository = TDI.Resolve<IKoridoRepository>();
			var koridoList = koridoRepository.GetAll().ToList();

			return koridoList;
		}

		public List<Korido> GetKoridok(string chipkod)
		{
			var koridoRepository = TDI.Resolve<IKoridoRepository>();
			var koridoList = koridoRepository.GetAll()
				.Include(x => x.VersenyVersenyzo)
				.Where(x => x.ChipKod == chipkod)
				.ToList();

			return koridoList;

			//var query = koridoRepository.GetAll()
			//	.Include(x => x.Landmark)
			//	.Include(x => x.Landmark.City)
			//	.Include(x => x.Landmark.City.Country)
			//	.Where(x => x.VisitedAt > dateToUse)
			//	.ToList()
			//	.GroupBy(x => x.Landmark.CityOID)
			//	.Select(x => new CityVisitCountDto()
			//	{
			//		CountryName = x.FirstOrDefault().Landmark.City.Country.Name,
			//		Name = x.FirstOrDefault().Landmark.City.Name,
			//		Longitude = x.FirstOrDefault().Landmark.City.Longitude,
			//		Latitude = x.FirstOrDefault().Landmark.City.Latitude,
			//		RequestedDate = dateToUse,
			//		VisitCountSince = x.Count()
			//	})
			//	.ToList();

			//return query;
		}

		public Korido Get(long oid)
		{
			var koridoRepository = TDI.Resolve<IKoridoRepository>();
			var korido = koridoRepository.Get(oid);
			return korido;
		}

		public KoridoDisplayDto GetKoridoDisplayDto(long oid)
		{
			var koridoRepository = TDI.Resolve<IKoridoRepository>();
			var korido = koridoRepository.Get(oid);

			var koridoDisplayDto = new KoridoDisplayDto();
			koridoDisplayDto.OID = korido.OID;
			koridoDisplayDto.ChipKod = korido.ChipKod;
			koridoDisplayDto.Szakasz = korido.Szakasz;
			koridoDisplayDto.KorSzama = korido.KorSzama;
			koridoDisplayDto.Ido = korido.Ido;
			koridoDisplayDto.VersenyVersenyzoOID = korido.VersenyVersenyzoOID;

			return koridoDisplayDto;
		}

		public long Add(Korido korido)
		{
			var koridoRepository = TDI.Resolve<IKoridoRepository>();
			var oid = koridoRepository.Add(korido);
			return oid;
		}

		public void Update(Korido tempKorido)
		{
			var koridoRepository = TDI.Resolve<IKoridoRepository>();
			var korido = koridoRepository.Get(tempKorido.OID);

			korido.ChipKod = tempKorido.ChipKod;
			korido.Szakasz = tempKorido.Szakasz;
			korido.KorSzama = tempKorido.KorSzama;
			korido.Ido = tempKorido.Ido;
			korido.VersenyVersenyzoOID = tempKorido.VersenyVersenyzoOID;

			koridoRepository.Update(korido);
		}

		public void Delete(long oid)
		{
			var koridoRepository = TDI.Resolve<IKoridoRepository>();
			var korido = koridoRepository.Get(oid);

			koridoRepository.Delete(korido);
		}
	}
}
