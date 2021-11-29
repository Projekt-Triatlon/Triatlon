using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TriatlonLogic.DataTransferObjects
{

	public class EredmenyDisplayDto2
	{
		public long OID { get; set; }

		[DisplayName("Helyezés")]
		public long AbszolutHelyezes { get; set; }

		[DisplayName("Rajtszám")]
		public long Rajtszam { get; set; }

		[DisplayName("Versenyző")]
		public string VersenyzoNev { get; set; }

		[DisplayName("Egyesület")]
		public string Egyesulet { get; set; }

		//-
		[DisplayName("Chip kód")]
		public string ChipKod { get; set; }

		[DisplayName("Úszás idő")]
		public TimeSpan UszasIdo { get; set; }

		[DisplayName("Depó 1 idő")]
		public TimeSpan Depo1Ido { get; set; }

		[DisplayName("Kerékpár idő")]
		public TimeSpan KerekparIdo { get; set; }

		[DisplayName("Depó 2 idő")]
		public TimeSpan Depo2Ido { get; set; }

		[DisplayName("Futás idő")]
		public TimeSpan FutasIdo { get; set; }

		[DisplayName("Cél idő")]
		public TimeSpan CelIdo { get; set; }

		[DisplayName("Ranglista pont")]
		public double RanglistaPont { get; set; }

	}
}


