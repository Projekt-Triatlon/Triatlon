using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TriatlonLogic.DataTransferObjects
{

	public class EredmenyDisplayDto
	{
		public long OID { get; set; }

		[DisplayName("Helyezés")]
		public long AbszolutHelyezes { get; set; }

		[DisplayName("Verseny")]
		public string VersenyNev { get; set; }

		[DisplayName("Versenyző")]
		public string VersenyzoNev { get; set; }

		[DisplayName("Egyesület")]
		public string Egyesulet { get; set; }

		[DisplayName("Chip kód")]
		public string ChipKod { get; set; }

		[DisplayName("Rajtszám")]
		public long Rajtszam { get; set; }

		[DisplayName("Úszás idő")]
		public TimeSpan UszasIdo { get; set; }

		[DisplayName("Úszás helyezés")]
		public int UszasHelyezes { get; set; }

		[DisplayName("Depó 1 idő")]
		public TimeSpan Depo1Ido { get; set; }

		[DisplayName("Depó 1 helyezés")]
		public int Depo1Helyezes { get; set; }

		[DisplayName("Kerékpár idő")]
		public TimeSpan KerekparIdo { get; set; }

		[DisplayName("Kerékpár helyezés")]
		public int KerekparHelyezes { get; set; }

		[DisplayName("Depó 2 idő")]
		public TimeSpan Depo2Ido { get; set; }

		[DisplayName("Depó 2 helyezés")]
		public int Depo2Helyezes { get; set; }

		[DisplayName("Futás idő")]
		public TimeSpan FutasIdo { get; set; }

		[DisplayName("Futás helyezés")]
		public int FutasHelyezes { get; set; }

		[DisplayName("Cél idő")]
		public TimeSpan CelIdo { get; set; }

		[DisplayName("Ranglista pont")]
		public double RanglistaPont { get; set; }



	}
}
