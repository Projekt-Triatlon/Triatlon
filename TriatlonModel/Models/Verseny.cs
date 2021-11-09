using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TriatlonLogic.Interfaces;

namespace TriatlonLogic.Models
{
	[Table("Verseny")]
	public class Verseny : IOid
	{
		[Key]
		public long OID { get; set; }

		[Required]
		[MaxLength(100)]
		[DisplayName("Verseny neve")]
		public string Nev { get; set; }

		[Required]
		[DisplayName("Dátum")]
		public DateTime Datum { get; set; }



		[Required]
		[DisplayName("Úszás távolság")]
		public double UTavolsag { get; set; }

		[DisplayName("Körök száma")]
		//[DefaultValue(1)]
		public int UKorokSzama { get; set; }

		[DisplayName("Úszópálya típusa")]
		public string UTipus { get; set; }

		[DisplayName("Neoprén használata")]
		public bool UNeopren { get; set; }

		[DisplayName("Úszópálya átlagos mélysége")]
		public double UMelyseg { get; set; }

		[DisplayName("Víz hőfok")]
		public double UVizHofok { get; set; }

		[DisplayName("Víz hullámzás mértéke")]
		public string UHullamzas { get; set; }

		[DisplayName("Szél erősség")]
		public double USzel { get; set; }

		[DisplayName("Csapadék")]
		public double UCsapadek { get; set; }

		[DisplayName("Levegő hőmérséklet")]
		public double ULevegoHomerseklet { get; set; }

		[DisplayName("Levegő páratartalom")]
		public double ULevegoParatartalom { get; set; }


		[Required]
		[DisplayName("Kerékpár távolság")]
		public double KTavolsag { get; set; }

		[MaxLength(100)]
		[DisplayName("Pálya minősége")]
		public string KMinoseg { get; set; }

		[DisplayName("Szintemelkedés")]
		public double KSzintemelkedes { get; set; }

		[DisplayName("Körök száma")]
		public int KKorokSzama { get; set; }

		[DisplayName("Szél")]
		public double KSzel { get; set; }

		[DisplayName("Csapadék")]
		public double KCsapadek { get; set; }

		[DisplayName("Levegő hőmérséklet")]
		public double KLevegoHomerseklet { get; set; }

		[DisplayName("Levegő páratartalom")]
		public double KLevegoParatartalom { get; set; }


		[Required]
		[DisplayName("Futás távolság")]
		public double FTavolsag { get; set; }

		[MaxLength(100)]
		[DisplayName("Futópálya minősége")]
		public string FMinoseg { get; set; }

		[DisplayName("Szintemelkedés")]
		public double FSzintemelkedes { get; set; }

		[DisplayName("Körök száma")]
		public int FKorokSzama { get; set; }

		[DisplayName("Szél erőssége")]
		public double FSzel { get; set; }

		[DisplayName("Csapadék")]
		public double FCsapadek { get; set; }

		[DisplayName("Levegő hőmérséklete")]
		public double FLevegoHomerseklet { get; set; }

		[DisplayName("Levegő páratartalom")]
		public double FLevegoParatartalom { get; set; }

		public virtual ICollection<VersenyVersenyzo> VersenyVersenyzok { get; set; }

	}
}
