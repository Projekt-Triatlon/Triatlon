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

		public List<Korido> GetKoridok(long oid)
		{
			var koridoRepository = TDI.Resolve<IKoridoRepository>();
			var koridoList = koridoRepository.GetAll()
				.Include(x => x.VersenyVersenyzo)
				.Where(x => x.VersenyVersenyzoOID == oid)
				.ToList();

			return koridoList;
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
