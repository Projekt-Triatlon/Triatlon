using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TriatlonLogic.Interfaces;

namespace TriatlonLogic.Models
{
	[Table("VersenyVersenyzo")]
	public class VersenyVersenyzo : IOid
	{
		[Key]
		public long OID { get; set; }

		[DisplayName("Chip kód")]
		public string ChipKod { get; set; }

		[DisplayName("Rajtszám")]
		public long Rajtszam { get; set; }

		[DisplayName("Úszás idő [hh:min:sec]")]
		//[DisplayFormat(DataFormatString = "{0:hhmmssfff}", ApplyFormatInEditMode = true)]
		//[DataType(DataType.Time)]
		public TimeSpan UszasIdo { get; set; }

		[DisplayName("Depo 1 idő [hh:min:sec]")]
		public TimeSpan Depo1Ido { get; set; }

		[DisplayName("Kerékpár idő [hh:min:sec]")]
		public TimeSpan KerekparIdo { get; set; }

		[DisplayName("Depo 2 idő [hh:min:sec]")]
		public TimeSpan Depo2Ido { get; set; }

		[DisplayName("Futás idő [hh:min:sec]")]
		public TimeSpan FutasIdo { get; set; }

		[DisplayName("Cél idő [hh:min:sec]")]
		public TimeSpan CelIdo { get; set; }

		[DisplayName("Helyezés")]
		public long AbszolutHelyezes { get; set; }


		[DisplayName("Úszás helyezés")]
		public int UszasHelyezes { get; set; }

		[DisplayName("Úszás sebesség [min:sec/100m]")]
		public TimeSpan UszasSebesseg { get; set; }

		[DisplayName("Depó 1 helyezés")]
		public int Depo1Helyezes { get; set; }

		[DisplayName("Kerékpár helyezés")]
		public int KerekparHelyezes { get; set; }

		[DisplayName("Kerekpár sebesség [km/h]")]
		public double KerekparSebesseg { get; set; }

		[DisplayName("Depó 2 helyezés")]
		public int Depo2Helyezes { get; set; }

		[DisplayName("Futás helyezés")]
		public int FutasHelyezes { get; set; }

		[DisplayName("Futás sebesség [min:sec/km]")]
		public TimeSpan FutasSebesseg { get; set; }

		public long VersenyzoOID { get; set; }

		[ForeignKey("VersenyzoOID")]
		public virtual Versenyzo Versenyzo { get; set; }

		public long VersenyOID { get; set; }

		[ForeignKey("VersenyOID")]
		public virtual Verseny Verseny { get; set; }

		public virtual ICollection<Korido> Koridok { get; set; }

	}
}
